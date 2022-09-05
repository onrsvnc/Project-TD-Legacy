using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] int goldReward = 100;
   [SerializeField] int goldPenalty = 100;
   
   Bank bank;
   
   void Start()
   {
        bank = FindObjectOfType<Bank>(); 
   }

   public void GoldRewarded()
   {
        if(bank == null) {return;}
        bank.Deposit(goldReward);
   }
   public void GoldPenalty()
   {
        if(bank == null) {return;}
        bank.Withdrawal(goldPenalty);
   }

   
}
