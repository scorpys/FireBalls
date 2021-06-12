using System;
using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;
    [SerializeField] private String _winMessage;

    private void OnEnable()
    {
        _tower.SizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        if (size > 0)
        {
            _sizeView.text = size.ToString();
        }
        else
        {
            _sizeView.text = _winMessage;
        }
        
    }
}
