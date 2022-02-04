using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingAmount = 150;

    [SerializeField] int currentAmount;

    [SerializeField] TextMeshProUGUI goldText;

    public int CurrentAmount { get { return currentAmount; } }

    private void Start()
    {

        currentAmount = startingAmount;
        goldText.text = "Gold: " + currentAmount;
    }

    public void Deposit(int amount)
    {
        currentAmount += amount;
        goldText.text = "Gold: " + currentAmount;
    }

    public void Withdraw(int amount)
    {
        currentAmount -= amount;
        goldText.text = "Gold: " + currentAmount;

        if (currentAmount < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
