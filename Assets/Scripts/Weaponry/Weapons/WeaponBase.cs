using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeaponBase : MonoBehaviour
{
    public enum EWeapon
    {
        NONE = 0,
        THROWN = 1,
        SHOOT = 2,
        LAUNCH = 3,
        ROLL = 4,
    }

    public EWeapon weaponType = EWeapon.NONE;
    public float fireVelocity = 0f;
    public Transform muzzle = null;
    public ProjectileBase projectile = null;
    public WeaponManager  weaponManager = null;

    public void FireWeapon()
    {
        ProjectileBase projectileInstance = PhotonNetwork.Instantiate(projectile.name, muzzle.transform.position, muzzle.transform.rotation).GetComponent<ProjectileBase>();
        projectileInstance.owner = GetComponent<WeaponBase>();

        switch (weaponManager.modifierSelected)
        {
            case ModifierBase.EModifier.CLUSTER:
                projectileInstance.gameObject.AddComponent<ClusterModifier>().m_projectile = projectileInstance;
                break;
            case ModifierBase.EModifier.RICOCHET:
                projectileInstance.gameObject.AddComponent<RicochetModifier>().m_projectile = projectileInstance;
                break;
            case ModifierBase.EModifier.THREEWAY:
                projectileInstance.gameObject.AddComponent<ThreeWayModifier>().m_projectile = projectileInstance;
                break;
            case ModifierBase.EModifier.PIERCE:
                projectileInstance.gameObject.AddComponent<PierceModifier>().m_projectile = projectileInstance;
                break;
        }

        ModifierBase mod = projectileInstance.gameObject.AddComponent<RicochetModifier>();
        mod.m_projectile = projectileInstance;
        switch (weaponType)
        {
            case EWeapon.SHOOT:
                projectileInstance.Fire(fireVelocity, false);
                break;
            default:
                projectileInstance.Fire(fireVelocity, true);
                break;
        }
        Debug.Log("Firing");
    }
}
