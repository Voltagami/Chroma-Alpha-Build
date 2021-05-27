using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Auffälligkeiten: - man kann gegen den Bounce ankommen, besser wäre es, wenn man sich überall bewegen kann, ausser der Richtung des Bounces
    //                  - es klappt nicht immer zu 100%, dass aus egal welcher Höhe zu dieser Höhe zurückspringt, sondern es macht den Mindestbounce von 13f zum Teil
    //                  - der Bounce ist nicht wirklich korrekt, es reflektiert nicht den Vektor, sondern man bounced zu der Vektorrichtung, wo das Splatter-Decal hinzeigt

    private void OnTriggerEnter(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("First Person Player");
        PlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<PlayerMovement>();

        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom"))
        {
            bounceTrigger.velocity = this.transform.forward * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.velocity.normalized, this.transform.forward);
            bounceTrigger.velocity = direction * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);
        }

        if (other.gameObject.tag == "Body")
        {
            bounceTrigger.velocity = this.transform.forward * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.velocity.normalized, this.transform.forward);
            bounceTrigger.velocity = direction * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);

            bounceTrigger.velocity.y = bounceTrigger.velocity.magnitude * 0.27f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("First Person Player");
        PlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<PlayerMovement>();

        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom"))
        {
            bounceTrigger.velocity = this.transform.forward * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.velocity.normalized, this.transform.forward);
            bounceTrigger.velocity = direction * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);
        }

        if (other.gameObject.tag == "Body")
        {
            bounceTrigger.velocity = this.transform.forward * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.velocity.normalized, this.transform.forward);
            bounceTrigger.velocity = direction * Mathf.Max(bounceTrigger.velocity.magnitude, 13f);

            bounceTrigger.velocity.y = bounceTrigger.velocity.magnitude * 0.27f;
        }
    }
}
