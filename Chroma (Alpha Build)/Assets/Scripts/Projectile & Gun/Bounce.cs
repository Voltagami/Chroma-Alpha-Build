using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Auff�lligkeiten: - man kann gegen den Bounce ankommen, besser w�re es, wenn man sich �berall bewegen kann, ausser der Richtung des Bounces
    //                  - es klappt zu ziemlich 100% mit der Funktion aus einer H�he springen und wieder zur gleichen zur�ckkommen (muss nur aufpassen wie schnell man in den Trigger kommt, sonst hat es keine Zeit rechtzeitig zu reagieren)
    //                    Ausserdem sollte man, wenn man in der Luft ist, nicht zu sp�t schiessen, sonst wird der Trigger zu sp�t erstellt, um deine Velocity zu �bernehmen.
    //                    Zus�tzlich, wenn, wieso auch immer, 2 Splatter-Decals sich verflechten, dann gibt es keinen Bounce, aber nur, wenn man die Linie, wo velocity mit transform.forward gleichgesetzt wird, wegmacht!!!
    //                  - der Bounce ist nicht wirklich korrekt, es reflektiert nicht den Vektor, sondern man bounced zu der Vektorrichtung, wo das Splatter-Decal hinzeigt
    //                  - wenn man von der Wand abgeprall wird und auf einen Bounce-Decal auf den Boden landet und wieder von der Wand abgeprallt wird usw. Dann baut sich der Bounce immer weiter auf...

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

        bounceTrigger.canJump = false;
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

        bounceTrigger.canJump = false;
    }
}
