using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// ���� �ܾ��� ����, �Ա�, ����
public class Bank : MonoBehaviour
{
    [Tooltip("���� ������ ������ �ִ� �ܰ� ǥ���ϱ� ���� TMPro Text")]
    [SerializeField]
    TextMeshProUGUI balaceText;
    [Tooltip("���� ������ �������ִ� �ܰ� ǥ���ϱ� ���� TMPro Text")]
    [SerializeField]
    int startBalance = 150;
    [SerializeField]
    int currentBalance;
    public int CurrentBalance
    {
        get 
        { 
            return currentBalance; 
        }
    }

    private void Awake()
    {
        currentBalance = startBalance;
         
    }
    
    public void Deposit(int amount)
    {
        //Mathf.Abs => +���� ������ -���� ������ ������ �����ִ� �Լ�
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= amount;

        if(currentBalance < 0)
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
