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
    [SerializeField] private int _magSizeMax = 30;
    [SerializeField] private int _magSize;
    private bool HasAmmunition => _magSize > 0;

    private void Awake()
    {
        _currentCooldown = _totalCooldownTime;
        _magSize = _magSizeMax;
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
        
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(ReloadCoroutine());


        _currentCooldown -= Time.deltaTime;
    }
    
    public void Fire()
    {
        if (HasAmmunition){
            var bulletInstance =
                Instantiate(Bullet, _bulletSpawn.position, _bulletSpawn.rotation);

            bulletInstance.AddForce(transform.forward * _bulletForce, ForceMode.VelocityChange);
            --_magSize;
        }
        else 
            StartCoroutine(ReloadCoroutine());
        
        // OnGunShoot.Invoke();
    }
    
    // Reloading coroutine
    IEnumerator ReloadCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Reloading");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Reloading done ");

        _magSize = _magSizeMax;
    }
}

