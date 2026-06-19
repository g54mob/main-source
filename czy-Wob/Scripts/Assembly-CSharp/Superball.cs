using UnityEngine;

public class Superball : MonoBehaviour
{
	private float trueMaxVel = 50f;

	private float windDownBounce = 2f;

	private float zeroMultBounce = 10f;

	private float currentBounceNum;

	private float throwMultiplier = 12f;

	private float bounceMultiplierMax = 1.25f;

	private float minVel = 175f;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision c)
	{
		float magnitude = c.impulse.magnitude;
		if (magnitude >= minVel && currentBounceNum >= windDownBounce + zeroMultBounce)
		{
			InitiateBounce();
		}
		float num = ((!(currentBounceNum >= windDownBounce) && !(magnitude < minVel)) ? (1f + bounceMultiplierMax * (windDownBounce - Mathf.Min(currentBounceNum, windDownBounce)) / windDownBounce) : 1f);
		rb.velocity = rb.velocity.normalized * Mathf.Max(Mathf.Min(rb.velocity.magnitude * num, trueMaxVel), rb.velocity.magnitude);
		if (currentBounceNum < windDownBounce + zeroMultBounce)
		{
			currentBounceNum += 1f;
		}
	}

	public void InitiateBounce()
	{
		currentBounceNum = 0f;
	}

	public void StopBounce()
	{
		currentBounceNum = windDownBounce;
	}

	public void ApplyThrowMultiplier()
	{
		rb.velocity *= throwMultiplier;
	}

	public void ApplyBiteMultiplier(Vector3 biteVector)
	{
		rb.AddForce(biteVector.normalized * 25f, ForceMode.Impulse);
	}
}
