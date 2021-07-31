using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _helthDisplay;


    private void OnEnable()
    {
        _player.HealthChenged += OnHealthChanget;
    }

    private void OnDisable()
    {
        _player.HealthChenged -= OnHealthChanget;
    }

    private void OnHealthChanget(int health)
    {
        _helthDisplay.text = health.ToString();
    }
}
