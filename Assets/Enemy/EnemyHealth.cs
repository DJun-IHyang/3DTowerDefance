using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ƼŬ�� �浹���� �� �������� �Դ´�.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int maxHP = 3;
    [Tooltip("���� ���� �� maxHP�� �߰��� ����")]
    [SerializeField]
    int difficultyInscrese = 1;

    int currentHP = 0;
    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHP = maxHP;
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Damaged();
    }

    private void Damaged()
    {
        currentHP--;

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            maxHP += difficultyInscrese;
            enemy.RewardMoney();
        }
    }
}
