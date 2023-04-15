using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Manager;
using System;

public class SCVReader : MonoBehaviour
{
    public string[] scvData;

    [SerializeField] private TextAsset _fileToRead;
    private readonly string[] _separators = new[] { "\r\n", ";" };

    public void ReadSCV()
    {
        scvData = null;
        scvData = _fileToRead.text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
    }
}
