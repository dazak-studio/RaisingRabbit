using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerScript : MonoBehaviour {

    private static MainManagerScript instance = null;

    public GameObject playerRabbit;
    public GameObject carrot;
    private PlayerRabbitScript playerRabbitScript;

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
    }

    public static MainManagerScript GetInstance()
    {
        return instance;
    }
    
    void Start () {
        playerRabbitScript = playerRabbit.GetComponent<PlayerRabbitScript>();
        MakeCarrots();
	}
	
	void Update () {
		
	}

    public PlayerRabbitScript GetPlayerRabbitScript()
    {
        return playerRabbitScript;
    }

    private void MakeCarrots()
    {
        for(int i = -10; i < 10; i++)
        {
            for(int j = -10; j < 10; j++)
            {
                Instantiate(carrot, new Vector3(
                    i*5.0f + Random.Range(-2.5f, 2.5f), 
                    0.0f, 
                    j*5.0f + Random.Range(-2.5f, 2.5f)), 
                    Quaternion.identity);
            }
        }
    }
}
