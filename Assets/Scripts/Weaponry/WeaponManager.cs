using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapon Prefabs")]
    [SerializeField] GameObject WeaponBase;
    [Header("Projectiled Prefabs")]
    [SerializeField] GameObject BulletProjectile;
    [SerializeField] GameObject MolotovProjectile;
    [SerializeField] GameObject GrenadeProjectile;
    [SerializeField] GameObject MissileProjectile;

    [Header("Player's Selections")]
    public ProjectileBase.EProjectileType projectileSelected;
    public WeaponBase.EWeapon weaponSelected;
    public ModifierBase.EModifier modifierSelected;

    public Transform weaponSpawnPosition;

    public void SetUpSelections()
    {
         Instantiate(WeaponBase, weaponSpawnPosition).GetComponent<WeaponBase>().weaponType = weaponSelected;

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
