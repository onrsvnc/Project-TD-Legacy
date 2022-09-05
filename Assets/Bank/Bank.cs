using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 1000;

    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayGold;
    
    public int CurrentBalance { get { return currentBalance; } }

    void Awake() 
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
        if(currentBalance >= 2000)
        {
            SceneManager.LoadScene("Win Screen");
        }
    }
    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if(currentBalance < 0)
        {
            ReloadScene();
        }

    }
    void UpdateDisplay()
    {
        displayGold.text = currentBalance.ToString();
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    


}
