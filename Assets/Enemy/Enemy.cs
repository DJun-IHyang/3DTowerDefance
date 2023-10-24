using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("���� �׾��� ��� ������ ����")]
    [SerializeField]
    int moneyReward = 25;
    [Tooltip("���� �׾��� ��� ������ ����")]
    [SerializeField]
    int moneyPanalty = 25;

    Bank bank;

    private void Start()
    {
        bank = GetComponent<Bank>();
    }

    public void RewardMoney()
    {
        bank.Deposit(moneyReward);
    }

    public void StealMoney()
    {
        bank.Withdraw(moneyPanalty);
    }
}
