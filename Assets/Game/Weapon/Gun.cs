using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using TextMeshPro = TMPro.TextMeshPro;

public class Gun : MonoBehaviour
{
    // Private fields
    [SerializeField] private float _totalCooldownTime;
    private float _currentCooldown = 0;
    
    [SerializeField] private bool _isAutomatic = true;
    [SerializeField] protected float _bulletForce = 2f;
    [SerializeField] protected Transform _bulletSpawn;
    [SerializeField] private int _magSizeMax = 30; 
    [FormerlySerializedAs("_magSize")] [SerializeField]
    protected int _ammoCount;
    private bool _isReloading = false;
    
    // Text mesh
    [SerializeField] private TMP_Text _reloadText;
    [SerializeField] private TMP_Text _cooldownText;
    
    // Protected properties
    protected bool HasAmmunition => _ammoCount > 0;
    
    // Public Properties
    public float ReloadTime = 2f;
    public string GunName;
    public Rigidbody Bullet;

    
    // Text mesh
    
    protected virtual void Awake()
    {
        _ammoCount = _magSizeMax;
        GunName = "Machine Gun";
    }

    protected virtual void Start()
    {
        PrintGunState();
        var canvas = FindObjectOfType<Canvas>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_isReloading && _currentCooldown <= 0f) {
            if (_isAutomatic)
            {
                if (Input.GetMouseButton(0))
                {
                    // OnGunShoot.Invoke();
                    SetCooldown();
                    Fire();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SetCooldown();
                    Fire();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ReloadCoroutine());
            }

        }

        _currentCooldown -= Time.deltaTime;
        _cooldownText.text = $"{_currentCooldown:0.00}";
        _cooldownText.enabled = _currentCooldown > 0f;
    }

    private void SetCooldown()
    {
        _currentCooldown = _totalCooldownTime;
        _cooldownText.enabled = true;
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
    }

    public void PrintGunState()
    {
        _reloadText.text = @$"{_ammoCount}/{_magSizeMax}";
    }

    // Reloading coroutine
    protected IEnumerator ReloadCoroutine()
    {
        _isReloading = true;
        _reloadText.text = "Reloading...";
        
        yield return new WaitForSeconds(ReloadTime);

        _isReloading = false;
        _ammoCount = _magSizeMax;
        PrintGunState();
    }
}

