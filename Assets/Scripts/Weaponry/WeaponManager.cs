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
        wb.transform.parent = weaponSpawnPosition;
        wb.weaponType = weaponSelected;
        GetComponent<FirstPersonPlayer>().m_weapon = wb;
        wb.projectile = BulletProjectile;
        Debug.Log(wb.projectile);

        ProjectileBase b = null;
        switch (projectileSelected)
        {
            case ProjectileBase.EProjectileType.BULLET:
                
                b = Instantiate(BulletProjectile).GetComponent<ProjectileBase>();
                break;
            case ProjectileBase.EProjectileType.GRENADE:
                b = Instantiate(GrenadeProjectile).GetComponent<ProjectileBase>();
                break;
            case ProjectileBase.EProjectileType.MISSILE:
                b = Instantiate(MissileProjectile).GetComponent<ProjectileBase>();
                break;
            case ProjectileBase.EProjectileType.MOLOTOV:
                b = Instantiate(MolotovProjectile).GetComponent<ProjectileBase>();
                break;
        }

        switch (modifierSelected)
        {
            case ModifierBase.EModifier.CLUSTER:
                b.gameObject.AddComponent<ClusterModifier>().m_projectile = b;
                break;
            case ModifierBase.EModifier.RICOCHET:
                b.gameObject.AddComponent<RicochetModifier>().m_projectile = b;
                break;
            case ModifierBase.EModifier.THREEWAY:
                b.gameObject.AddComponent<ThreeWayModifier>().m_projectile = b;
                break;
            case ModifierBase.EModifier.PIERCE:
                b.gameObject.AddComponent<PierceModifier>().m_projectile = b;
                break;
        }
    }
}
