using UnityEngine;

public class UnbouncableDog : MonoBehaviour
{
	private int lastCollisionFrame = -10000;

	private int unbouncableFrameCount = 1;

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
			lastCollisionFrame = Time.frameCount;
		}
	}

	private void FixedUpdate()
	{
		if (lastCollisionFrame + unbouncableFrameCount >= Time.frameCount)
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
		else
		{
			lastCollisionFrame = -1000;
		}
	}
}
