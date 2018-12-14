using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehiavour:MonoBehaviour{

    [SerializeField] PlateBehaviour plate;

    public int kindOfBird;
    public int selfCost;
    public int eggCost;
    public float eggTimeout;

    public int eggsCount = 0;

    public void Update(){

        if (eggsCount == 0){
            plate.deactivate();
        }
        else{
            plate.activate();
        }
    }

    public void Start(){

        StartCoroutine(waitingForEgg());
    }
    
    private void layAnEgg(){
        eggsCount++;
        plate.setValues(eggsCount);
    }

    private IEnumerator waitingForEgg(){
        yield return new WaitForSeconds(eggTimeout);
        layAnEgg();
        StartCoroutine(waitingForEgg());
    }
}
