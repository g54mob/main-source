using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_AutoGetup : FimpossibleComponent
	{
		[Tooltip("Script reads mecanim animator reference from the ragdoll animator")]
		public RagdollAnimator2 ragdoll;

		public Rigidbody controllerRigibody;

		public MonoBehaviour controller;

		[Space(6f)]
		[Range(0f, 1f)]
		public float MinimumWaitTime = 0.3f;

		public LayerMask GroundMask = 0;

		public float TransitionDuration = 0.85f;

		private float fallingDuration;

		private ERagdollGetUpType getUpType;

		private RaycastHit getupHit;

		private float stableTime;

		private void Update()
		{
			if (!ragdoll.Handler.IsFallingOrSleep)
			{
				fallingDuration = 0f;
				return;
			}
			getUpType = ERagdollGetUpType.None;
			CalculateGetUpType();
			if (getUpType != ERagdollGetUpType.None)
			{
				TriggerGetUp();
			}
		}

		private void CalculateGetUpType()
		{
			fallingDuration += Time.deltaTime;
			if (fallingDuration < MinimumWaitTime)
			{
				return;
			}
			ERagdollGetUpType eRagdollGetUpType = ragdoll.User_CanGetUpByRotation();
			float magnitude = ragdoll.User_GetChainBonesAverageTranslation(ERagdollChainType.Core).magnitude;
			if (magnitude > 0.075f)
			{
				stableTime = 0f;
				return;
			}
			if (ragdoll.User_GetChainAngularVelocity(ERagdollChainType.Core).magnitude > 1f * ragdoll.Settings.User_CoreLowTranslationFactor(magnitude))
			{
				stableTime = 0f;
				return;
			}
			stableTime += Time.deltaTime;
			if (!(stableTime < 0.15f))
			{
				RaycastHit raycastHit = ragdoll.Handler.ProbeGroundBelowHips(GroundMask, ragdoll.Settings.GetAnchorBoneController.MainBoneCollider.bounds.size.magnitude + 0.01f);
				if (!(raycastHit.transform == null))
				{
					getupHit = raycastHit;
					getUpType = eRagdollGetUpType;
				}
			}
		}

		private void TriggerGetUp()
		{
			base.transform.position = getupHit.point;
			base.transform.rotation = ragdoll.User_GetMappedRotationHipsToLegsMiddle();
			if ((bool)controllerRigibody)
			{
				controllerRigibody.position = base.transform.position;
				controllerRigibody.rotation = base.transform.rotation;
			}
			if ((bool)controller)
			{
				controller.enabled = true;
			}
			string stateName = ((getUpType != ERagdollGetUpType.FromFacedown) ? "Get Up Back" : "Get Up Face");
			ragdoll.Handler.Mecanim.CrossFadeInFixedTime(stateName, 0.175f);
			ragdoll.User_TransitionToStandingMode(TransitionDuration, 0.6f, 0.1f, 0.125f);
			ragdoll.User_FadeMusclesPowerMultiplicator(1f, TransitionDuration);
		}
	}
}
