using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Oil
{
    public string country;
    public int oilValue;

    public Oil(string country, int oilValue)
    {
        this.country = country;
        this.oilValue = oilValue;
    }
}
