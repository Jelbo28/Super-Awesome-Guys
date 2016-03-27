using UnityEngine;

public class MoneyPickup : MonoBehaviour 
{
    //string playerMoney;
	public void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.tag == "Player 1")
        {
            //playerMoney = "playerOneMoney";
            //CheckMoney();
            switch (this.tag)
            {
                case "Green":
                    GM.instance.playerOneMoney += 0.01f;
                    break;
                case "Blue":
                    GM.instance.playerOneMoney += 0.05f;
                    break;
                case "Red":
                    GM.instance.playerOneMoney += 0.2f;
                    break;
            }
        }
        else if (other.gameObject.tag == "Player 2")
        {
            //playerMoney = "playerTwoMoney";
            //CheckMoney();
            switch (this.tag)
            {
                case "Green":
                    GM.instance.playerTwoMoney += 0.01f;
                    break;
                case "Blue":
                    GM.instance.playerTwoMoney += 0.05f;
                    break;
                case "Red":
                    GM.instance.playerTwoMoney += 0.2f;
                    break;
            }
        }
        GM.instance.PickupCoin();
        //Debug.Log("Coin");
        Destroy(gameObject);
    }

    /*
    public void CheckMoney()
    {
        switch (this.tag)
        {
            case "Green":
                GM.instance. (playerMoney) += 1;
                break;
            case "Blue":
                GM.instance. += 5;
                break;
            case "Red":
                GM.instance. += 20;
                break;
        }
    }
    */
}
