using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    [SerializeField]
    private int _bulletCount = 5;
    
    protected override void Awake()
    {
        base.Awake();
        GunName = "Shotgun";
    }
    
    protected override void Fire()
    {
        if (HasAmmunition){
            for (int i = 0; i < _bulletCount; i++)
            {
                Rigidbody bullet = Instantiate(Bullet, _bulletSpawn.position, _bulletSpawn.rotation);
                var bulletDirection = _bulletSpawn.forward + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
                bullet.AddForce(bulletDirection * _bulletForce, ForceMode.Impulse);
            }
            --_ammoCount;
            PrintGunState();
        }
        else
        {
            StartCoroutine(ReloadCoroutine());
        }
    }
}
