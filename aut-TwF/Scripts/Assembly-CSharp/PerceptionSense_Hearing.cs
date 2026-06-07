using UnityEngine;

public class PerceptionSense_Hearing : PerceptionSense
{
	private SphereCollider hearingCollider;

	public override void InitSense(PerceptionAI perceptionAI)
	{
		base.InitSense(perceptionAI);
		hearingCollider = base.gameObject.AddComponent<SphereCollider>();
		hearingCollider.radius = perceptionAI.HearingRadius;
		hearingCollider.isTrigger = true;
	}
}
