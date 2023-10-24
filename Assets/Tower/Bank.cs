using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// 계좌 잔액을 보관, 입금, 인출
public class Bank : MonoBehaviour
{
    [Tooltip("현재 은행이 가지고 있는 잔고를 표현하기 위한 TMPro Text")]
    [SerializeField]
    TextMeshProUGUI balaceText;
    [Tooltip("현재 은행이 가지고있는 잔고를 표현하기 위한 TMPro Text")]
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
        //Mathf.Abs => +값이 들어오던 -값이 들어오던 무조건 더해주는 함수
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
