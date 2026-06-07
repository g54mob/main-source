using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_WaterDropCharacter : FimpossibleComponent
	{
		public RagdollAnimator2 ParentRagdoll;

		public AudioSource HittedAudio;

		public float ImpactPower = 2f;

		public float FallOnHitPower = 10f;

		public float BodyPushPower = 10f;

		private float hitCulldown = -1f;

		public void RagdollAnimator2BoneCollision(RA2BoneCollisionHandler hitted)
		{
			Collision latestEnterCollision = hitted.LatestEnterCollision;
			float magnitude = latestEnterCollision.relativeVelocity.magnitude;
			float magnitude2 = latestEnterCollision.impulse.magnitude;
			if ((bool)HittedAudio && hitted.LatestEnterCollision.collider.gameObject.layer == 4 && (magnitude >= FallOnHitPower || magnitude2 > 40f) && Time.unscaledTime - hitCulldown > 0.1f)
			{
				hitCulldown = Time.unscaledTime;
				HittedAudio.Play();
			}
			if (!ParentRagdoll.IsInFallingOrSleepMode && !(magnitude < FallOnHitPower))
			{
				ParentRagdoll.User_FallImpact(latestEnterCollision.relativeVelocity.normalized, ImpactPower, 0f, BodyPushPower, hitted.DummyBoneRigidbody);
				ParentRagdoll.Handler.Mecanim.CrossFadeInFixedTime("Fall", 0.2f);
			}
		}
	}
}
