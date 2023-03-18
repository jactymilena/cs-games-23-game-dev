using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using TextMeshPro = TMPro.TextMeshPro;

public class Gun : Weapon
{
    public UnityEvent OnGunShoot;

    [SerializeField] private float _totalCooldownTime;
    private float _currentCooldown;

    [SerializeField] private bool _isAutomatic = true;
    [SerializeField] protected float _bulletForce = 2f;
    public Rigidbody Bullet;
    [SerializeField] protected Transform _bulletSpawn;
    [SerializeField] private Transform _reloadRotationPoint;
    [SerializeField] private int _magSizeMax = 30; 
    [FormerlySerializedAs("_magSize")] [SerializeField]
    protected int _ammoCount;
    [SerializeField] private TMP_Text _reloadText;
    private bool _isReloading = false;
    protected bool HasAmmunition => _ammoCount > 0;
    public float ReloadTime = 2f;

    
    // Text mesh
    
    private void Awake()
    {
        _currentCooldown = _totalCooldownTime;
        _ammoCount = _magSizeMax;
    }

    private void Start()
    {
        PrintGunState();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_isReloading) {
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
            {
                StartCoroutine(ReloadCoroutine());
            }
        }

        _currentCooldown -= Time.deltaTime;
    }

    protected virtual void Fire()
    {
        if (HasAmmunition){
            var bulletInstance =
                Instantiate(Bullet, _bulletSpawn.position, _bulletSpawn.rotation);

            bulletInstance.AddForce(transform.forward * _bulletForce, ForceMode.VelocityChange);
            --_ammoCount;
            PrintGunState();
        }
        else
        {
            StartCoroutine(ReloadCoroutine());
        }
        // OnGunShoot.Invoke();
    }

    protected void PrintGunState()
    {
        _reloadText.text = @$"{_ammoCount}/{_magSizeMax}";
    }

    // Reloading coroutine
    protected IEnumerator ReloadCoroutine()
    {
        _isReloading = true;
        _reloadText.text = "Reloading...";

        //yield on a new YieldInstruction that waits for 5 seconds.

        yield return new WaitForSeconds(ReloadTime);

        //After we have waited 5 seconds print the time again.
        _isReloading = false;
        _ammoCount = _magSizeMax;
        PrintGunState();
    }
}

