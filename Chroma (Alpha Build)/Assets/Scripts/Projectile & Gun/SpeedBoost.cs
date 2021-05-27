using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("First Person Player");
        PlayerMovement speedTrigger = firstPersonPlayer.GetComponent<PlayerMovement>();

        if (other.gameObject.tag == "Bottom")
        {
            if (speedTrigger.isGrounded == true)
            {
                speedTrigger.speed = 24f;
            }

            if (speedTrigger.isOnObject == true)
            {
                speedTrigger.speed = 24f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("First Person Player");
        PlayerMovement speedTrigger = firstPersonPlayer.GetComponent<PlayerMovement>();

        if (other.gameObject.tag == "Bottom")
        {
            if (speedTrigger.isGrounded == true)
            {
                speedTrigger.speed = 24f;
            }

            if (speedTrigger.isOnObject == true)
            {
                speedTrigger.speed = 24f;
            }
        }
    }
}
