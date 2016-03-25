using UnityEngine;
using System.Collections;

public class MoneyPickup : MonoBehaviour 
{
    int timesUsed = 0;

	public void OnTriggerEnter2D (Collider2D other)
	{
        if (timesUsed < 1)
        {
            if (other.gameObject.tag == "Player 1")
            {
                timesUsed++;
                CheckMoney();
                GM.instance.PickupCoinOne();
                //Debug.Log("Coin");
                Destroy(gameObject);
            }
            else if (other.gameObject.tag == "Player 2")
            {
                timesUsed++;
                CheckMoney();
                GM.instance.PickupCoinTwo();
                //Debug.Log("Coin");
                Destroy(gameObject);
            }
        }
	}

    public void CheckMoney()
    {
        int reward = 0;
        switch (this.tag)
        {
            case "Green":
                reward = 1;
                break;
            case "Blue":
                reward = 5;
                break;
            case "Red":
                reward = 20;
                break;
        }
    }
}
