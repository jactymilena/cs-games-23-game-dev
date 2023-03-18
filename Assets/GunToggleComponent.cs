using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GunToggleComponent : MonoBehaviour
{
    private List<Gun> Guns;
    private Gun selectedGun;
    [SerializeField] private TMP_Text _gunText;

    private void Awake()
    {
        Guns = new List<Gun>();
        foreach (var gun in GetComponentsInChildren<Gun>())
        {
            Guns.Add(gun);
            gun.enabled = false;
        }
        
        selectedGun = Guns[0];
        selectedGun.enabled = true;
    }
    
    private void Start()
    {
        SetGunText();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleGun();
        }
    }
    
    public void ToggleGun()
    {
        selectedGun.enabled = false;
        selectedGun = Guns[(Guns.IndexOf(selectedGun) + 1) % Guns.Count];
        selectedGun.enabled = true;
        SetGunText();
    }

    private void SetGunText()
    {
        _gunText.text = selectedGun.GunName;
        selectedGun.PrintGunState();
    }
}
