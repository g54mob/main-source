using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_ObstacleSceneReceiver : MonoBehaviour, IRagdollAnimator2Receiver
	{
		private float ResetOnDelay = 0.15f;

		private float accumulatedVelocity;

		private float lastHitTime = -100f;

		private float lastAppliedImpulse;

		public void RagdollAnimator2_OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision mainCollision)
		{
			Demo_Ragd_TripThreshold component = mainCollision.GetContact(0).otherCollider.GetComponent<Demo_Ragd_TripThreshold>();
			if (!component)
			{
				return;
			}
			float num = (component.LastImpulsePower = mainCollision.impulse.magnitude);
			if (Time.fixedUnscaledTime - lastHitTime > ResetOnDelay)
			{
				accumulatedVelocity = 0f;
			}
			lastHitTime = Time.fixedUnscaledTime;
			accumulatedVelocity += num;
			if (num >= component.HitApplyThreshold)
			{
				lastAppliedImpulse = num;
				hitted.ParentRagdollProcessor.User_SwitchFallState(RagdollHandler.EAnimatingMode.Falling);
				if (component.HitImpact != 0f)
				{
					hitted.DummyBoneRigidbody.AddForce(mainCollision.impulse * component.HitImpact, ForceMode.Impulse);
				}
			}
		}
	}
}
