using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;
public abstract class ProjectileBase : MonoBehaviourPun
{
    public enum EProjectileType
    {
        NONE = 0,
        BULLET = 1,
        GRENADE = 2,
        MISSILE = 3,
        MOLOTOV = 4
    }

    public EProjectileType projectileType;
    public WeaponBase owner;
    public ModifierBase modifier;

    public Rigidbody rb;
    public float Damage;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public abstract void Fire(float power, bool gravity);

    public abstract void Destruct();

}