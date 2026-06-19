using System.Collections.Generic;
using UnityEngine;

public class LevelTriggerRigidbody : LevelTrigger
{
	public enum KinematicProperty
	{
		UNSET = 0,
		TRUE = 1,
		FALSE = 2
	}

	public List<Rigidbody> rigidbodies = new List<Rigidbody>();

	public KinematicProperty setIsKinematic;

	protected override void OnDogEnter(GameObject dog)
	{
		base.OnDogEnter(dog);
		for (int i = 0; i < rigidbodies.Count; i++)
		{
			if (setIsKinematic == KinematicProperty.TRUE)
			{
				rigidbodies[i].isKinematic = true;
			}
			else if (setIsKinematic == KinematicProperty.FALSE)
			{
				rigidbodies[i].isKinematic = false;
			}
		}
		Object.Destroy(this);
	}
}
