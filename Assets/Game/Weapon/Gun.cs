using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;

public class Gun : Weapon
{
    public UnityEvent OnGunShoot;

    [SerializeField] private float _totalCooldownTime;
    private float _currentCooldown;

    [SerializeField] private bool _isAutomatic = true;
    [SerializeField] private float _bulletForce = 2f;
    public Rigidbody Bullet;
    [SerializeField] private Transform _bulletSpawn;
    
    private void Awake()
    {
        _currentCooldown = _totalCooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAutomatic)
        {
            if (Input.GetMouseButton(0) && _currentCooldown <= 0f)
            {
                // OnGunShoot.Invoke();
                _currentCooldown = _totalCooldownTime;
                Fire();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && _currentCooldown <= 0f)
            {
                // OnGunShoot.Invoke();
                _currentCooldown = _totalCooldownTime;
                Fire();
            }
        }

        _currentCooldown -= Time.deltaTime;
    }
    
    public void Fire()
    {
        
        var bulletInstance = 
            Instantiate(Bullet, _bulletSpawn.position, _bulletSpawn.rotation);

        bulletInstance.AddForce(transform.forward * _bulletForce, ForceMode.VelocityChange);
        // OnGunShoot.Invoke();
    }
}

