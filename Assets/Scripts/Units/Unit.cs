using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] public int _maxHealth;
    [SerializeField] private int _damageValue;
    [SerializeField] private float _attackDistance;
    [SerializeField] public GameObject _healthBarPrefab;
    private HealthBar _healthBar;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _healthBar.SetHealth(_health, _maxHealth);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Start()
    {
       
        _maxHealth = _health;
        GameObject healthBar = Instantiate(_healthBarPrefab);
        _healthBar = healthBar.GetComponent<HealthBar>();
         _healthBar.Setup(transform);
    }

    private void OnDestroy()
    {
        if (_healthBar)
        {
            Destroy(_healthBar.gameObject);
        }
    }

}
