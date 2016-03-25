using UnityEngine;
using System.Collections;

public class Deadzone : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player 1")
        {
            GM.instance.PlayerOneLoseLife();
        }
        else if (other.gameObject.tag == "Player 2")
        {
            GM.instance.PlayerTwoLoseLife();
        }
    }
}
