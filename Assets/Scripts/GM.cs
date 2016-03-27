using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
	bool playerTwoOn = false;
	bool levelEnd = false;
    [SerializeField]
	int playerOneLives = 3;
    [SerializeField]
	int playerTwoLives = 3;
    [SerializeField]
	public float playerOneMoney = 0.00f;
    [SerializeField]
	public float playerTwoMoney = 0.00f;

	public static GM instance = null;
    public GameObject ScreenBorder;
	public GameObject Player1;
	public GameObject P1Camera;
	public GameObject PlayerOneDead;
	public GameObject Player2;
    public GameObject PlayerTwo;
	public GameObject P2Camera;
	public GameObject PlayerTwoDead;
    public GameObject PlayerTwoJoin;


	private GameObject clonePlayer1;
	private GameObject cloneCamera1;
	private GameObject clonePlayer2;
	private GameObject cloneCamera2;

    AudioSource coinPickup;

    [SerializeField]
    Text livesTextOne;
    [SerializeField]
	Text livesTextTwo;
    [SerializeField]
    Text moneyTextOne;
    [SerializeField]
    Text moneyTextTwo;


    void Awake()
	{
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        coinPickup = GetComponent<AudioSource>();

        moneyTextOne.text = moneyTextOne.text + playerOneMoney.ToString("C", CultureInfo.CurrentCulture);
		moneyTextTwo.text = moneyTextTwo.text + playerTwoMoney.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
		livesTextOne.text = livesTextOne.text + playerOneLives;
		livesTextTwo.text = livesTextTwo.text + playerTwoLives;

        RespawnPlayerOne();
        cloneCamera1.GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
        ScreenBorder.SetActive(false);
        PlayerTwo.SetActive(false);
	}

	void RespawnPlayerOne()
	{
		clonePlayer1 = Instantiate (Player1, transform.position, Quaternion.identity) as GameObject;
		cloneCamera1 = Instantiate (P1Camera, new Vector3 (0, 1, -10), Quaternion.identity) as GameObject;
		if (playerTwoOn == true)
		{
			cloneCamera1.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
			//PlayerOneDead.GetComponent<RectTransform>().rect = new RectTransform(10, 0, 800, 0);
		}
		PlayerOneDead.SetActive(false); 
	}

	void RespawnPlayerTwo()
	{
		playerTwoOn = true;
        //Debug.Log("Spawn P2!");
		clonePlayer2 = Instantiate (Player2, transform.position, Quaternion.identity) as GameObject;
		cloneCamera2 = Instantiate (P2Camera, new Vector3 (0, 1, -10), Quaternion.identity) as GameObject;
		PlayerTwoDead.SetActive(false); 
	}

	void CheckGameover()
	{
		if (levelEnd == true)
		{

		}

		if (playerOneLives <= 0 && playerTwoLives <= 0)
		{

		}
	}

	public void PlayerOneLoseLife()
	{
		playerOneLives--;
		livesTextOne.text = livesTextOne.text + playerOneLives;
		Destroy (clonePlayer1);
		PlayerOneDead.SetActive(true); 
		Destroy (cloneCamera1);
		Invoke ("RespawnPlayerOne", 3);
		CheckGameover ();
	}

	public void PlayerTwoLoseLife()
	{
		playerTwoLives--;
		livesTextTwo.text = livesTextTwo.text + playerTwoLives;
		Destroy (clonePlayer2);
		PlayerTwoDead.SetActive(true); 
		Destroy (cloneCamera2);
		Invoke ("RespawnPlayerTwo", 3);
		CheckGameover ();
	}
	
	public void PickupCoin()
	{
        coinPickup.Play();
        /*
        GameObject gem = GameObject.Find("gemGreen");
        MoneyPickup gemScript = gem.GetComponent<MoneyPickup>();
        playerOneMoney = playerOneMoney + gemScript.;
        */
        Debug.Log(playerOneMoney);
        moneyTextOne.text = "Cash: " + playerOneMoney.ToString("C", CultureInfo.CurrentCulture);
        moneyTextTwo.text = "Mula: " + playerTwoMoney.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
    }

    public void PlayerTwoStart()
    {
        cloneCamera1.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        ScreenBorder.SetActive(true);
        PlayerTwo.SetActive(true);
        PlayerTwoJoin.SetActive(false);
        RespawnPlayerTwo ();
    }

}
