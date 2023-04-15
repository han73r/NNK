using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class OilUI : MonoBehaviour
{
    public RowUI rowUI;

    public GameObject engine;

    private OilDataManager _oilDataManager;
    private Manager _manager;
    private SCVReader _scvReader;

    private bool isCreatedRows;

    private void Awake()
    {
        GetComponents();
    }

    public void PrepareOilData()
    {
        if (_scvReader == null || _oilDataManager == null)
        {
            GetComponents();
        }
        _scvReader.ReadSCV();
        _oilDataManager.FillOilData(_scvReader.scvData);
        CreateRows();
    }

    private void GetComponents()
    {
        _oilDataManager = engine.GetComponent<OilDataManager>();
        _manager = engine.GetComponent<Manager>();
        _scvReader = engine.GetComponent<SCVReader>();
    }

    private void CreateRows()
    {
        if (isCreatedRows)
            return;

        var oilData = _oilDataManager.GetOilData().ToArray();

        for (int i = 0; i < oilData.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.country.text = oilData[i].country;
            row.value.text = oilData[i].oilValue.ToString();
        }

        isCreatedRows = true;
    }

    
}
