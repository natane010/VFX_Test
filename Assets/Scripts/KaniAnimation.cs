using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    Vector3 latestPos;
    Vector3 speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = ((this.gameObject.transform.position - latestPos) / Time.deltaTime).normalized;
        latestPos = this.gameObject.transform.position;
        //Debug.Log(speed.magnitude);
        if(speed.magnitude != 0)
        {
            animator.SetBool("Walk_Cycle_1", true);
        }
        else
        {
            animator.SetBool("Rest_1", true);
        }
    }
}
