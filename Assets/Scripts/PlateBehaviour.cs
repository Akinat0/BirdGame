using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateBehaviour : MonoBehaviour {

    [SerializeField] Text text;
    [SerializeField] GameObject plate;

    public void setValues(int eggsCount){
        text.text = "X" + eggsCount;
        
    }

    public void deactivate()
    {
        plate.SetActive(false);
    }

    public void activate()
    {
        plate.SetActive(true);
    }
}
