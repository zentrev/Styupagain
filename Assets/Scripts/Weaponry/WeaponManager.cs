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
        
        GetComponent<FirstPersonPlayer>().m_weapon = wb;
    }

    public void UpdateWeapon()
    {

        GetComponent<FirstPersonPlayer>().m_weapon.weaponType = weaponSelected;

        switch (projectileSelected)
        {
            case ProjectileBase.EProjectileType.BULLET:
                GetComponent<FirstPersonPlayer>().m_weapon.projectile = BulletProjectile;
                break;
            case ProjectileBase.EProjectileType.GRENADE:
                GetComponent<FirstPersonPlayer>().m_weapon.projectile = GrenadeProjectile;
                break;
            case ProjectileBase.EProjectileType.MISSILE:
                GetComponent<FirstPersonPlayer>().m_weapon.projectile = MissileProjectile;
                break;
            case ProjectileBase.EProjectileType.MOLOTOV:
                GetComponent<FirstPersonPlayer>().m_weapon.projectile = MolotovProjectile;
                break;
        }
    }
}
