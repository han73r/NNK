using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;
using System;
using System.Linq;
public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public OilUI OilUI;
    public WeatherAPIRequest weatherAPIRequest;
    public VLCYouTubePlayback vLCYouTubePlayback;
    
    [SerializeField] private GameObject _videoScreen;
    [SerializeField] private GameObject _webCamScreen;
    [SerializeField] private GameObject _webPageScreen;
    [SerializeField] private GameObject _weatherScreen;
    [SerializeField] private GameObject _dataScreen;
    [SerializeField] private GameObject _closeAllButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    public void ShowVideoScreen()
    {
        _videoScreen.SetActive(true);
        _closeAllButton.SetActive(true);
    }
    public void ShowWebCamScreen()
    {
        _webCamScreen.SetActive(true);
        //vLCYouTubePlayback.StartPlayback();
        _closeAllButton.SetActive(true);
    }

    public void ShowWebPageScreen() 
    {
        _webPageScreen.SetActive(true);
        _closeAllButton.SetActive(true);
    }

    public void ShowWeatherScreen()
    {
        weatherAPIRequest.GetWeatherForecast();
        _weatherScreen.SetActive(true);
        _closeAllButton.SetActive(true);
    }

    public void ShowDataScreen()
    {
        PrePareData();
        _dataScreen.SetActive(true);
        _closeAllButton.SetActive(true);
    }

    private void PrePareData()
    {
        OilUI.PrepareOilData();
    }

    public void DisableAll()
    {
        _videoScreen?.SetActive(false);
        _webCamScreen?.SetActive(false);
        _webPageScreen?.SetActive(false);
        _weatherScreen?.SetActive(false);
        _dataScreen?.SetActive(false);
        _closeAllButton?.SetActive(false);
    }

    public void AplicationQuit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
