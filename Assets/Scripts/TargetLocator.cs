using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem bulletsParticleSystem;
    [SerializeField] float range = 15;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMover>()?.transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
        LocateClosestTarget();
    }

    private void LocateClosestTarget()
    {
        EnemyMover[] enemies = FindObjectsOfType<EnemyMover>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(EnemyMover enemy in enemies)
        {
            float targetDistance = Vector3.Distance(enemy.transform.position, transform.position);

            if (targetDistance < maxDistance)
            {
                maxDistance = targetDistance;
                closestTarget = enemy.transform;
            }
        }

        target = closestTarget;
    }

    private void AimWeapon()
    {

        if (target)
        {
            float targetDistance = Vector3.Distance(target.position, transform.position);
            if (targetDistance <= range)
            {
                weapon.LookAt(target);
                var emission = bulletsParticleSystem.emission;
                emission.enabled = true;
            }
        } else
        {
            var emission = bulletsParticleSystem.emission;
            emission.enabled = false;
        }
    }
}
