using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotScript : MonoBehaviour {
    
	void Start () {
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == MainManagerScript.GetInstance().playerRabbit)
        {
            MainManagerScript.GetInstance().GetPlayerRabbitScript().IncreaseGrowth(1);
            MainManagerScript.GetInstance().GetPlayerRabbitScript().PlayBiteSound();
            Destroy(this.gameObject);
        }
    }
}
