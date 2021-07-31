using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private heart _heartTemplate;

    private List<heart> _hearts = new List<heart>();

    private void OnEnable()
    {
        _player.HealthChenged += OnHaelthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChenged -= OnHaelthChanged;
    }

    private void OnHaelthChanged(int value)
    {
        if(_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;
            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            int deleteHeart = _hearts.Count - value;
            for (int i = 0; i < deleteHeart; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHeart(heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<heart>());
        newHeart.ToFill();
    }
}
