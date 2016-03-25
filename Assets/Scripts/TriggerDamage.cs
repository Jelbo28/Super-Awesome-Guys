using UnityEngine;
using System.Collections;

public class TriggerDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        int Number = 0;

        if (col.gameObject.tag == "Player 1" || col.gameObject.tag == "Player 2")
        {
            Debug.Log("Spike " + Number);
            Number++;
        }
    }
}
