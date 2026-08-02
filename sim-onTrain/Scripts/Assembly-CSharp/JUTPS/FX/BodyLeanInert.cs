using JUTPSActions;
using UnityEngine;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Body Lean")]
	public class BodyLeanInert : JUTPSAction
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public JUFootPlacement JUFootPlacer;

		public Transform RootBone;

		public bool RootBoneSpineLean = true;

		public bool RootBoneSpineMovement = true;

		public float RootBoneLeanIntensity = 30f;

		public float RootBoneLeanSpeed = 8f;

		public float RootBoneDownMovementIntensity = 0.5f;

		public float BlockForwardLeanWeight = 8f;

		private float Speed;

		private float Lean;

		private Vector3 NotAffectedEulerAngles;

		private Vector3 NotAffectedUpward;

		public Axis AxisToLean;

		public override void Awake()
		{
			base.Awake();
			if (JUFootPlacer == null)
			{
				JUFootPlacer = GetComponent<JUFootPlacement>();
			}
			if (RootBone == null)
			{
				RootBone = anim.GetBoneTransform(HumanBodyBones.Hips);
			}
			anim.updateMode = AnimatorUpdateMode.AnimatePhysics;
		}

		private void OnAnimatorIK()
		{
			NotAffectedEulerAngles = RootBone.localEulerAngles;
		}

		private void LateUpdate()
		{
			DoInert();
		}

		private void DoInert()
		{
			Vector3 notAffectedEulerAngles = NotAffectedEulerAngles;
			NotAffectedUpward = RootBone.up;
			if (TPSCharacter.IsMeleeAttacking || TPSCharacter.IsRagdolled || TPSCharacter.IsAiming || TPSCharacter.FiringMode || TPSCharacter.IsDriving || TPSCharacter.IsDead || !TPSCharacter.IsGrounded)
			{
				Speed = 0f;
				Lean = 0f;
				return;
			}
			Speed = Mathf.Lerp(Speed, TPSCharacter.VelocityMultiplier, 10f * Time.deltaTime);
			if (TPSCharacter.IsMoving)
			{
				Lean = Mathf.Lerp(Lean, Speed * RootBoneLeanIntensity / BlockForwardLeanWeight, RootBoneLeanSpeed * Time.deltaTime);
			}
			else
			{
				Lean = Mathf.Lerp(Lean, 0f - Speed * RootBoneLeanIntensity / 2f, RootBoneLeanSpeed * Time.deltaTime);
				if (JUFootPlacer != null && RootBoneSpineMovement)
				{
					JUFootPlacer.LastBodyPositionY -= RootBoneDownMovementIntensity * Mathf.Abs(Lean) / 10f * Time.deltaTime;
				}
			}
			switch (AxisToLean)
			{
			case Axis.X:
				notAffectedEulerAngles.x += Lean;
				break;
			case Axis.Y:
				notAffectedEulerAngles.y += Lean;
				break;
			case Axis.Z:
				notAffectedEulerAngles.z += Lean;
				break;
			}
			RootBone.localRotation = Quaternion.Euler(notAffectedEulerAngles);
		}
	}
}
