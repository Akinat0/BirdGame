using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HitPlacing : MonoBehaviour {

    [SerializeField] PlayerBehaviour player;

    public Camera cam;
    public GameObject prefab;

    public bool active = false;

    // Update is called once per frame
    void Update () {
        
        if (Input.GetMouseButtonUp(0)&& !EventSystem.current.IsPointerOverGameObject())
        {
            
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit)) {

                    if((hit.collider.tag == "plate")){
                    Debug.Log("Money getting");
                        gettingMoney(hit.collider);
                    }

                    if (!(hit.collider.tag == "plate") && active){
                        Debug.Log("Tag of collider = " + hit.collider.tag + " gamoObject name " + hit.collider.gameObject.name);
                        GameObject go = Instantiate(prefab, hit.point, Quaternion.identity);
                        go.transform.LookAt(new Vector3(cam.transform.position.x, go.transform.position.y, cam.transform.position.z));
                        active = false;
                    }    
            }
            else
            {
                Debug.Log("It's impossible to place bird through plate");
            }
      }
    }

    void gettingMoney(Collider collider){
        BirdBehiavour bird = collider.gameObject.GetComponent<BirdBehiavour>();
        player.money += bird.eggsCount * bird.eggCost;
        bird.eggsCount = 0;
    }
}