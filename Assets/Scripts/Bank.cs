using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingAmount = 150;

    [SerializeField] int currentAmount;

    public int CurrentAmount { get { return currentAmount; } }

    private void Start()
    {
        currentAmount = startingAmount;
    }

    public void Deposit(int amount)
    {
        currentAmount += amount;
    }

    public void Withdraw(int amount)
    {
        currentAmount -= amount;

        if (currentAmount < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
