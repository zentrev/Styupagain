using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using StayupolKnights;
public class WeaponManager : MonoBehaviour
{
    [Header("Weapon Prefabs")]
    [SerializeField] GameObject WeaponBase;
    [Header("Projectiled Prefabs")]
    [SerializeField] ProjectileBase BulletProjectile;
    [SerializeField] ProjectileBase MolotovProjectile;
    [SerializeField] ProjectileBase GrenadeProjectile;
    [SerializeField] ProjectileBase MissileProjectile;

    [Header("Player's Selections")]
    public ProjectileBase.EProjectileType projectileSelected;
    public WeaponBase.EWeapon weaponSelected;
    public ModifierBase.EModifier modifierSelected;

    public Transform weaponSpawnPosition;

    public void SetUpSelections()
    {
        WeaponBase wb = PhotonNetwork.Instantiate(WeaponBase.name, weaponSpawnPosition.position, weaponSpawnPosition.rotation).GetComponent<WeaponBase>();
        wb.weaponManager = this;
        wb.transform.parent = weaponSpawnPosition;
        wb.weaponType = weaponSelected;
        GetComponent<FirstPersonPlayer>().m_weapon = wb;
        wb.projectile = BulletProjectile;
        Debug.Log(wb.projectile);

        switch (projectileSelected)
        {
            case ProjectileBase.EProjectileType.BULLET:
                wb.projectile = BulletProjectile;
               
                break;
            case ProjectileBase.EProjectileType.GRENADE:
                wb.projectile = GrenadeProjectile;
               
                break;
            case ProjectileBase.EProjectileType.MISSILE:
                wb.projectile = MissileProjectile;
                
                break;
            case ProjectileBase.EProjectileType.MOLOTOV:
                wb.projectile = MolotovProjectile;
         
                break;
        }
    }
}
