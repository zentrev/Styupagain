using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MolotovProjectile : ProjectileBase
{
    public GameObject FloodPrefab;
    public float Range;

    public override void Fire(float power, bool gravity)
    {
        rb.useGravity = gravity;
        rb.AddForce(transform.forward * power, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(Random.value * 90.0f, 0, 0), ForceMode.Impulse);

    }

    public override void Destruct()
    {

        List<Health> hpObjs = Physics.OverlapSphere(transform.position, 1.0f).Where(h => h.GetComponent<Health>()).Select(h => h.GetComponent<Health>()).ToList();
        foreach (Health c in hpObjs)
        {
            if (c.tag == "Player")
            {
                c.DealDamage(Damage); //* modifier
            }
        }
        Instantiate(FloodPrefab, transform.position, transform.rotation, null);
        Destroy(gameObject);

    }
}
