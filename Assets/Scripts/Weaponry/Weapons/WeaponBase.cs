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

    public void FireWeapon()
    {
        ProjectileBase projectileInstance = PhotonNetwork.Instantiate(projectile.name, muzzle.transform.position, muzzle.transform.rotation).GetComponent<ProjectileBase>();
        switch (weaponType)
        {
            case EWeapon.SHOOT:
                projectileInstance.Fire(fireVelocity, false);
                break;
            default:
                projectileInstance.Fire(fireVelocity, true);
                break;
        }
    }
}
