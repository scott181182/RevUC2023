using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Move : MonoBehaviour
{
    private float speed;
    public float scalespeed;
    // public Vector3 StartPos;
    public GameObject target;
    public Vector3 NPCpos;
    public GameObject[] Waypoints;
    // public int positionNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        speed = scalespeed * 11.5f * Time.deltaTime;
        NPCpos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        if (transform.position == target.transform.position) {
            Debug.Log("Bing");
            // StartCoroutine(Nexttarget());
            if (target==Waypoints[Waypoints.Length - 1]) {
                this.gameObject.SetActive(false);
                transform.position = NPCpos;
                target = Waypoints[0];
            } else {
                for(int i = 0; i < this.Waypoints.Length; i++)
                {
                    if(transform.position == Waypoints[i].transform.position) {
                        target = Waypoints[i+1];
                    }
                }
            }
        }
    
    }

    // private IEnumerator Nexttarget()
    // {
    //     if (transform.position == Waypoint1.transform.position)
    //     {
    //         Debug.Log("Ding");
    //         target = Waypoint2;
    //         yield return new WaitForSeconds(.1f);
    //     }
    //     else if (transform.position == Waypoint2.transform.position)
    //     {
    //         target = Waypoint3;
    //         yield return new WaitForSeconds(.1f);
    //     }
    //     else if (transform.position == Waypoint3.transform.position)
    //     {
    //         target = Waypoint4;
    //         yield return new WaitForSeconds(.1f);
    //     }
    //     else if (transform.position == Waypoint4.transform.position)
    //     {
    //         target = Waypoint5;
    //         yield return new WaitForSeconds(.1f);
    //     }
    //     else if (transform.position == Waypoint5.transform.position)
    //     {
    //         target = Waypoint6;
    //         yield return new WaitForSeconds(.1f);
    //     }
    //     else if (transform.position == Waypoint6.transform.position)
    //     {
    //         target = Waypoint7;
    //         yield return new WaitForSeconds(.1f);
    //     }
    //     else
    //     {
    //         this.gameObject.SetActive(false);
    //         transform.position = NPCpos;
    //     }
    // }
}


    

