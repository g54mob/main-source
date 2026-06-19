using System;
using UnityEngine;

[Serializable]
public class DogBehaviorPaired : DogBehaviorTargeted
{
	public override bool IsPairedBehavior()
	{
		return true;
	}

	public override void FinishBehavior(bool naturalFinish = true, GameObject objectCause = null)
	{
		base.FinishBehavior(naturalFinish, objectCause);
	}
}
