using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_HeroBigFallDamage : Demo_Ragd_HeroFallDamage
	{
		[Space(5f)]
		public float FallAfter = 1f;

		public float DragOnVelocity = 10f;

		private bool fallSwitchFlag;

		private float fallingTime;

		private float lastFallingTime;

		private float startFallY;

		protected override void Start()
		{
			base.Start();
			Mover.Rigb.SetMaxLinearVelocityU2022(25f);
		}

		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!Mover.isGrounded)
			{
				if (Mover.Rigb.velocity.y < -0.25f)
				{
					fallingTime += Time.fixedDeltaTime;
				}
				lastFallingTime = fallingTime;
				if (!fallSwitchFlag && !Ragdoll.IsInFallingOrSleepMode && fallingTime > FallAfter)
				{
					startFallY = Ragdoll.User_GetPosition_BottomCenter().y;
					Ragdoll.User_SwitchFallState();
					Ragdoll.Handler.Mecanim.CrossFadeInFixedTime("Fall", 0.25f);
					Ragdoll.Handler.GetAnchorBoneController.GameRigidbody.maxAngularVelocity = 20f;
					Ragdoll.User_SetPhysicalTorqueOnRigidbody(Ragdoll.Handler.GetAnchorBoneController.GameRigidbody, Ragdoll.User_BoneWorldRight(Ragdoll.Handler.GetAnchorBoneController) * 15f, 0.75f, relativeSpace: false, ForceMode.VelocityChange);
					Ragdoll.User_ChangeAllRigidbodiesDrag(0.5f);
					Ragdoll.User_SwitchAllBonesMaxVelocity(30f);
					fallSwitchFlag = true;
				}
			}
			else
			{
				fallingTime = 0f;
				if (fallSwitchFlag)
				{
					Ragdoll.User_ChangeAllRigidbodiesDrag();
					Ragdoll.User_SwitchAllBonesMaxVelocity(10000f);
					fallSwitchFlag = false;
				}
			}
		}

		protected override float GetDamage(float velocity)
		{
			if (startFallY - Ragdoll.User_GetPosition_BottomCenter().y > 20f)
			{
				lastFallingTime = 0f;
				fallingTime = 0f;
				startFallY = Ragdoll.User_GetPosition_BottomCenter().y;
				return 100f;
			}
			return base.GetDamage(velocity);
		}
	}
}
