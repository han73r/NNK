using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Cryptography;

[Serializable]
public class OilDataManager : MonoBehaviour
{
    private OilData _od;

    /// <summary>
    /// Separate string[] data for 2 coloumns
    /// </summary>
    /// <param name="data"></param>
    public void FillOilData(string[] data)
    {
        _od = new OilData();
        for (int i = 0; i < data.Length; i+=2)
        {
            AddOilData(new Oil(data[i], int.Parse(data[(i + 1)])));
        }
    }

    public void AddOilData(Oil oil)
    {
        _od.oilList.Add(oil);
    }

    public IEnumerable<Oil> GetOilData()
    {
        return _od.oilList.OrderByDescending(x => x.oilValue);
    }
}
