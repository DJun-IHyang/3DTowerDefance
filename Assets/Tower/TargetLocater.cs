using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TargetLocater : MonoBehaviour
{
    [Tooltip("Ÿ������ ��ü�� ���� ȸ���ϴ� ���� ������Ʈ")]
    [SerializeField]
    Transform weapon;
    
    [Tooltip("Ÿ���� ���� �߻� ����")]
    [SerializeField]
    Transform target;

    [Tooltip("Ÿ���� ����(��ƼŬ)")]
    [SerializeField]
    float range = 15f;
    [SerializeField]
    ParticleSystem weaponParticle;

    private void Start()
    {   
        target = FindObjectOfType<EnemyMover>().transform;
    }
    private void Update()
    {
        FindClosestTarget();
        AimTarget();
    }

    private void FindClosestTarget()
    {
        EnemyMover[] enemies = FindObjectsOfType<EnemyMover>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (EnemyMover enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                   maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void AimTarget()
    {
        weapon.LookAt(target);

        // Target���� �Ÿ��� Range ���� ��� Attack(true)!, �ƴϸ� Attack(false)
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    // Attack �Լ��� emission�� �Ѱ� ���� �Լ�
    void Attack(bool isActive)
    {
        var emission = weaponParticle.emission;
        emission.enabled = isActive;

        weaponParticle.playOnAwake = isActive;
    }
}
