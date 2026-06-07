using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_DismemberBonesCharacter : FimpossibleComponent, IRagdollAnimator2Receiver
	{
		public RagdollAnimator2 Ragdoll;

		public AudioSource HitAudio;

		public EDismemberType DismemberType = EDismemberType.Disconnect;

		private RAF_DismembermentManager dismemberementManager;

		private float hitCulldown;

		private bool llegDism;

		private bool rlegDism;

		private void Start()
		{
			dismemberementManager = Ragdoll.Handler.GetExtraFeature<RAF_DismembermentManager>();
			if (dismemberementManager == null)
			{
				Debug.Log("No Dismemberement Feature in " + Ragdoll.name + "!");
				base.enabled = false;
			}
		}

		public void RagdollAnimator2_OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision mainCollision)
		{
			if (base.enabled && !(Time.fixedTime - hitCulldown < 0.3f) && mainCollision.gameObject.layer == 4)
			{
				if ((bool)HitAudio)
				{
					HitAudio.Play();
					hitCulldown = Time.fixedTime - 0.2f;
				}
				if (!hitted.BoneSettings.WasDismembered && !hitted.BoneSettings.ParentDismembered && mainCollision.impulse.magnitude > 7f)
				{
					dismemberementManager.DismemberBone(hitted.BoneSettings, DismemberType);
					hitted.DummyBoneRigidbody.AddForce(mainCollision.relativeVelocity.normalized, ForceMode.VelocityChange);
					OnDismember(hitted.BodyBoneID, hitted.ChainType);
					hitCulldown = Time.fixedTime;
				}
			}
		}

		private void OnDismember(ERagdollBoneID bone, ERagdollChainType chain)
		{
			switch (chain)
			{
			case ERagdollChainType.LeftLeg:
				llegDism = true;
				Ragdoll.Handler.Mecanim.CrossFadeInFixedTime("Left Leg", 0.1f);
				break;
			case ERagdollChainType.RightLeg:
				rlegDism = true;
				Ragdoll.Handler.Mecanim.CrossFadeInFixedTime("Right Leg", 0.1f);
				break;
			case ERagdollChainType.LeftArm:
				Ragdoll.Handler.Mecanim.CrossFadeInFixedTime("Left Arm", 0.1f);
				break;
			case ERagdollChainType.RightArm:
				Ragdoll.Handler.Mecanim.CrossFadeInFixedTime("Right Arm", 0.1f);
				break;
			case ERagdollChainType.Core:
				if (bone == ERagdollBoneID.Head)
				{
					Ragdoll.Handler.Mecanim.CrossFadeInFixedTime("Head", 0.1f);
				}
				else
				{
					Ragdoll.Handler.Mecanim.CrossFadeInFixedTime("Body", 0.1f);
				}
				break;
			}
			if (llegDism && rlegDism)
			{
				if (!Ragdoll.Handler.IsFallingOrSleep)
				{
					Ragdoll.User_SwitchFallState();
				}
				Ragdoll.Handler.AnchorBoneAttach = 0f;
			}
		}
	}
}
