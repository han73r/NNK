using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Networking;
using WeatherAPIData;
using TMPro;

public class WeatherAPIRequest : MonoBehaviour
{
    [SerializeField] private string _url;
    [SerializeField] private TextMeshProUGUI _dateAndTimeTM;
    [SerializeField] private TextMeshProUGUI _temperatureTM;
    [SerializeField] private TextMeshProUGUI _windTM;

    public void GetWeatherForecast()
    {
        StartCoroutine(GetRequest(_url));
    }
    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Someting went wrong: {0}", webRequest.error));
                    break;

                case UnityWebRequest.Result.Success:
                    WeatherRoot weatherRoot = JsonConvert.DeserializeObject<WeatherRoot>(webRequest.downloadHandler.text);

                    SetTemperatureTM(weatherRoot);
                    SetDateTM(weatherRoot);
                    SetWindTM(weatherRoot);
                    
                    break;
            }
        }
    }

    private void SetTemperatureTM(WeatherRoot weatherRoot)
    {
        string temp = weatherRoot.current.temp_c.ToString();

        if (weatherRoot.current.temp_c > 0)
            _temperatureTM.text = $"+{temp}";
        else if (weatherRoot.current.temp_c < 0)
            _temperatureTM.text = $"-{temp}";
    }

    private void SetDateTM(WeatherRoot weatherRoot)
    {
        _dateAndTimeTM.text = weatherRoot.current.last_updated;
    }

    private void SetWindTM(WeatherRoot weatherRoot)
    {
        _windTM.text = $"{weatherRoot.current.wind_kph.ToString()} κμ/χ";
    }

}
