using System.Collections.Generic;
using UnityEngine;

public class Unbouncable : MonoBehaviour
{
	private List<GameObject> activeCollisions = new List<GameObject>();

	private List<GameObject> activeTriggerCollisions = new List<GameObject>();

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision c)
	{
		if (rb.velocity.y > 0f && rb.velocity.y <= rb.mass)
		{
			StopBounce();
			activeCollisions.Add(c.gameObject);
		}
	}

	private void OnCollisionExit(Collision c)
	{
		if (activeCollisions.Contains(c.gameObject))
		{
			activeCollisions.Remove(c.gameObject);
		}
	}

	private void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.GetComponent<PipeFlyZone>() != null)
		{
			activeTriggerCollisions.Add(c.gameObject);
		}
	}

	private void OnTriggerExit(Collider c)
	{
		if (c.gameObject.GetComponent<PipeFlyZone>() != null)
		{
			activeTriggerCollisions.Remove(c.gameObject);
		}
	}

	private void Update()
	{
		for (int i = 0; i < activeCollisions.Count; i++)
		{
			if (activeCollisions[i].Equals(null))
			{
				activeCollisions.RemoveAt(i);
				break;
			}
		}
		for (int j = 0; j < activeTriggerCollisions.Count; j++)
		{
			if (activeTriggerCollisions[j].Equals(null))
			{
				activeTriggerCollisions.RemoveAt(j);
				break;
			}
		}
	}

	private void FixedUpdate()
	{
		if (activeCollisions.Count != 0 && activeTriggerCollisions.Count <= 0)
		{
			StopBounce();
		}
	}

	private void StopBounce()
	{
		Vector3 velocity = rb.velocity;
		if (velocity.y > 0f && velocity.y <= rb.mass)
		{
			velocity.y = 0f;
			rb.velocity = velocity;
		}
	}
}
