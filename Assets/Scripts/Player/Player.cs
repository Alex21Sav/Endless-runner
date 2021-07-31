 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChenged;

    public event UnityAction Died;

    private void Start()
    {
        HealthChenged?.Invoke(_health);
    }
    public void AplliyDamage(int damage)
    {
        _health -= damage;
        HealthChenged?.Invoke(_health);
        if (_health <= 0)
        {
            Die();
        }
    }

     public void Die()
    {
        Died?.Invoke();        
    }
}
