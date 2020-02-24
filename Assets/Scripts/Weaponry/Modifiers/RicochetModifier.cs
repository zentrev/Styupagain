using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetModifier : ModifierBase
{
    [SerializeField] int bounceCount = 2;
    private Vector3 lastFrameVelocity;
    [SerializeField] Vector3 minVelocity;
    private Rigidbody rb;

    private void Start()
    {
        m_projectile.TryGetComponent(out rb);
        weapon = m_projectile.owner;

    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player" && bounceCount != 0)
        {
            bounceCount--;
            Ricochet(collision.contacts[0].normal);
            Debug.Log("bounce");
        }
        Debug.Log(weapon);
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

    private void Ricochet(Vector3 collision)
    {
        float speed = lastFrameVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, collision);

        rb.velocity = direction * Mathf.Max(speed, minVelocity.magnitude);
    }


}
