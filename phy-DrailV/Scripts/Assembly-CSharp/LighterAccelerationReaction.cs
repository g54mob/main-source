using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Lighter))]
public class LighterAccelerationReaction : ItemAccelerationReaction
{
	public float suspendDelay = 0.1f;

	private Lighter lighter;

	private Coroutine SuspendReactionCoro;

	private bool suspendReaction;

	protected override void Start()
	{
		base.Start();
		lighter = GetComponent<Lighter>();
	}

	protected override void TryReactToAcceleration()
	{
		Vector3 worldAngularAccelerationEstimate = velocityEstimator.GetWorldAngularAccelerationEstimate();
		Vector3 worldAngularVelocityEstimate = velocityEstimator.GetWorldAngularVelocityEstimate();
		Vector3 vector = base.transform.InverseTransformDirection(worldAngularAccelerationEstimate);
		Vector3 vector2 = base.transform.InverseTransformDirection(worldAngularVelocityEstimate);
		if (lighter.isOpen == vector.z < 0f && lighter.isOpen == vector2.z < 0f && !suspendReaction && canReactToAcceleration && Mathf.Abs(vector.z) > accelerationThreshold)
		{
			DoReactToAcceleration();
		}
	}

	private void DoReactToAcceleration()
	{
		lighter.ReactToControllerAcceleration();
		if (SuspendReactionCoro != null)
		{
			StopCoroutine(SuspendReactionCoro);
		}
		SuspendReactionCoro = StartCoroutine(DelayNextReaction());
	}

	private IEnumerator DelayNextReaction()
	{
		suspendReaction = true;
		yield return WaitFor.Seconds(suspendDelay);
		suspendReaction = false;
	}
}
