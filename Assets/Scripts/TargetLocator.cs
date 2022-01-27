using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem bulletsParticleSystem;
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
    }

    private void AimWeapon()
    {
        if (target)
        {
            weapon.LookAt(target);
            if (bulletsParticleSystem && bulletsParticleSystem.isStopped)
            {
                bulletsParticleSystem.Play();
            }
        } else
        {
            if (bulletsParticleSystem && bulletsParticleSystem.isPlaying)
            {
                bulletsParticleSystem.Play();
            }
        }
    }
}
