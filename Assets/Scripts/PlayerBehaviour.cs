using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] HitPlacing placing;
    [SerializeField] BirdBehiavour redBird;
    [SerializeField] Text moneyText;

    public int money = 100;

    private void Update()
    {
        moneyText.text = money + "";
    }

    public void buy(){
        if(money - redBird.selfCost >= 0){
            money -= redBird.selfCost;
            placing.active = true;
      //      moneyText.text = money + "";
        }
    }

}
