using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class OilData
{
    public List<Oil> oilList;

    public OilData()
    {
        oilList = new List<Oil>();
    }
}
