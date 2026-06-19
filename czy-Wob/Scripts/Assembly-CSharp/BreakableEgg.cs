using UnityEngine;

public class BreakableEgg : ClickableObject
{
	public DogEgg eggRef;

	private float breakVelocity = 50f;

	private void Awake()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void CheckBreak(Collision c)
	{
		if (c.relativeVelocity.magnitude >= breakVelocity)
		{
			eggRef.Break();
		}
	}
}
