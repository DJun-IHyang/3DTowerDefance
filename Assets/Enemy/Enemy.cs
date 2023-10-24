using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("적이 죽었을 경우 보상의 정도")]
    [SerializeField]
    int moneyReward = 25;
    [Tooltip("적이 죽었을 경우 벌점의 정도")]
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
