using UnityEngine;

public class DebrisCollision : MonoBehaviour
{
	private void Update()
	{
		if (GetComponent<Rigidbody>().IsSleeping())
		{
			GetComponent<Rigidbody>().WakeUp();
		}
	}

	private void OnTriggerEnter(Collider col)
	{
	}

	private void OnTriggerStay(Collider col)
	{
	}

	private void OnCollisionEnter(Collision col)
	{
		int num = 0;
		num++;
	}
}
