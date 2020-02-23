using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceModifier : ModifierBase
{
    private Rigidbody rb;
    private Vector3 velocity;
    private WeaponBase weapon;

    private void OnEnable()
    {
        m_projectile.TryGetComponent(out rb);
        m_projectile.TryGetComponent(out weapon);
    }

    private void Update()
    {
        velocity = rb.velocity;
        if(rb.velocity != velocity)
        {
            rb.velocity = velocity;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag != "Player")
        {
            Physics.IgnoreCollision(collision.GetContact(0).thisCollider, collision.collider);
            rb.velocity = velocity;
        }
        if (weapon.weaponType == WeaponBase.EWeapon.ROLL)
        {
            if (rb.velocity.magnitude == 0.02f)
            {
                m_projectile.Destruct();
            }
        }
        else
        {
            m_projectile.Destruct();
        }
    }

}
