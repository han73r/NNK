using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class HighLightAndSelectManager : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material _originalMaterialHighlight;
    private Material _originalMaterialSelection;

    private Transform _highlight;
    private Transform _selection;

    private RaycastHit _raycastHit;

    private readonly string _selectTAG = "Selectable";

    void Update()
    {

        
        // Highlight
        if (_highlight != null)
        {
            _highlight.GetComponent<MeshRenderer>().sharedMaterial = _originalMaterialHighlight;
            _highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out _raycastHit)) 
        {
            _highlight = _raycastHit.transform;
            if (_highlight.CompareTag(_selectTAG) && _highlight != _selection)
            {
                if (_highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {
                    _originalMaterialHighlight = _highlight.GetComponent<MeshRenderer>().material;
                    _highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
            else
                _highlight = null;
        }
        
        // Selection
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (_highlight)
            {
                if (_selection != null)
                {
                    _selection.GetComponent<MeshRenderer>().material = _originalMaterialSelection;
                }
                _selection = _raycastHit.transform;

                if (_selection.GetComponent<MeshRenderer>().material != selectionMaterial)
                {
                    _originalMaterialSelection = _originalMaterialHighlight;
                    Manager.Instance.ShowDataScreen();
                    _selection.GetComponent<MeshRenderer>().material = _originalMaterialSelection;
                    _selection = null;
                }
                _highlight = null;
            }
            else
            {
                if (_selection)
                {
                    _selection.GetComponent<MeshRenderer>().material = _originalMaterialSelection;
                    _selection = null;
                }
            }
        }
    }
}
