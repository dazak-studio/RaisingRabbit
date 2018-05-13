using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRabbitScript : MonoBehaviour {

	public GameObject rabbitModel;
    public AudioSource biteSound;
	private const float rabbitVelocity = 5.0f;
	private Vector3 destinationPos;
    private int growth = 1;

	void Start () {
	}
	
	void Update () {
		SetDestinationWhenClicked ();
		MoveIfNotArrived ();
	}

    private void SetScaleByGrowth()
    {
        float scaleLength = Mathf.Pow((float)growth, 0.333f);
        transform.localScale = new Vector3(scaleLength, scaleLength, scaleLength);
    }

	private void SetDestinationWhenClicked()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 hitPos = GetHitPosWithYZero (ray.origin, ray.direction);
			destinationPos = hitPos;
		}
	}

	private Vector3 GetHitPosWithYZero(Vector3 origin, Vector3 direction)
	{
		float x = -origin.y / direction.y;
		return origin + x * direction;
	}

	private void MoveIfNotArrived()
	{
		if (Vector3.Distance(destinationPos, transform.position) < Time.deltaTime * rabbitVelocity)
		{
			transform.position = destinationPos;
		}
		else
		{
			Vector3 direction = Vector3.Normalize (destinationPos - transform.position);
			transform.position += direction * Time.deltaTime * rabbitVelocity;
			rabbitModel.transform.rotation = Quaternion.LookRotation (direction);
		}
	}

    public void IncreaseGrowth(int incGrowth)
    {
        growth += incGrowth;
        SetScaleByGrowth();
    }

    public void PlayBiteSound()
    {
        biteSound.time = 0.0f;
        biteSound.Play();
    }
}
