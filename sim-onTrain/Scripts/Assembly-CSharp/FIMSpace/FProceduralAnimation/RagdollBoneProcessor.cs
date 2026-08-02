using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RagdollBoneProcessor
	{
		private ConfigurableJoint joint;

		private Transform stransform;

		public Rigidbody rigidbody;

		internal Vector3 initLocalPos = Vector3.zero;

		internal Quaternion initLocalRot = Quaternion.identity;

		internal Quaternion calibrationLocalRotation = Quaternion.identity;

		private Quaternion jointAxisConversion;

		private Quaternion initialAxisCorrection;

		private Quaternion animatorRotation;

		private Vector3 animatorPosition;

		private float lastCaptureTime = -1f;

		public RagdollAnimator2BoneIndicator IndicatorComponent;

		private Vector3 averageTranslation;

		private Vector3 _lastFixedFramePosition;

		private float _translationCalculatedAtFixedTime = -2f;

		private float averageAngularity;

		private Quaternion _lastFixedFrameRotation;

		private float _angularCalculatedAtFixedTime = -2f;

		public RagdollChainBone BoneSetup { get; private set; }

		private Transform dtransform => BoneSetup.PhysicalDummyBone;

		public Vector3 lastAppliedPosition { get; private set; }

		public Quaternion animatorLocalRotation { get; private set; }

		public Quaternion AnimatorRotation => animatorRotation;

		public Vector3 AnimatorPosition => animatorPosition;

		public Vector3 LastMatchingRigidodyOrigin { get; private set; }

		public Vector3 updateLoopRelevantVelocity { get; private set; }

		public Vector3 PreviousFixedPosition { get; private set; }

		public Vector3 FixedPositionDelta { get; private set; }

		public float storedHardMatch { get; private set; }

		public RagdollBoneProcessor(RagdollChainBone settings)
			: this(settings.Joint, settings.SourceBone, settings.GameRigidbody)
		{
			BoneSetup = settings;
		}

		public RagdollBoneProcessor(ConfigurableJoint configurableJoint, Transform sourceTransform, Rigidbody rig)
		{
			joint = configurableJoint;
			stransform = sourceTransform;
			rigidbody = rig;
			initLocalPos = stransform.localPosition;
			initLocalRot = stransform.localRotation;
			calibrationLocalRotation = initLocalRot;
			ResetPoseParameters();
			InitWithJoint();
		}

		public void ResetPoseParameters()
		{
			animatorLocalRotation = stransform.localRotation;
			calibrationLocalRotation = stransform.localRotation;
			animatorPosition = stransform.position;
			animatorRotation = stransform.rotation;
			updateLoopRelevantVelocity = Vector3.zero;
			LastMatchingRigidodyOrigin = stransform.position + stransform.rotation * rigidbody.centerOfMass;
			PreviousFixedPosition = stransform.position;
			FixedPositionDelta = Vector3.zero;
			averageTranslation = Vector3.zero;
			_lastFixedFramePosition = stransform.position;
			lastAppliedPosition = _lastFixedFramePosition;
			averageAngularity = 0f;
			_lastFixedFrameRotation = stransform.rotation;
		}

		private void InitWithJoint()
		{
			Vector3 normalized = Vector3.Cross(joint.axis, joint.secondaryAxis).normalized;
			Vector3 normalized2 = Vector3.Cross(normalized, joint.axis).normalized;
			if (normalized == normalized2)
			{
				jointAxisConversion = Quaternion.identity;
				initialAxisCorrection = initLocalRot;
			}
			else
			{
				Quaternion quaternion = Quaternion.LookRotation(normalized, normalized2);
				jointAxisConversion = Quaternion.Inverse(quaternion);
				initialAxisCorrection = initLocalRot * quaternion;
			}
		}

		public void CaptureAnimatorPose()
		{
			animatorLocalRotation = stransform.localRotation;
			stransform.GetPositionAndRotation(out animatorPosition, out animatorRotation);
			CaptureAnimationVelocity();
		}

		private void CaptureAnimationVelocity()
		{
			float num = Time.unscaledTime - lastCaptureTime;
			lastCaptureTime = Time.unscaledTime;
			if (!(num <= 0f))
			{
				Vector3 vector = animatorPosition + animatorRotation * rigidbody.centerOfMass;
				updateLoopRelevantVelocity = (vector - LastMatchingRigidodyOrigin) / num;
				LastMatchingRigidodyOrigin = vector;
			}
		}

		public void CalibrateRotation()
		{
			stransform.localRotation = calibrationLocalRotation;
		}

		public void Calibrate()
		{
			CalibrateRotation();
			stransform.localPosition = initLocalPos;
		}

		public void StoreCalibrationPose()
		{
			calibrationLocalRotation = animatorLocalRotation;
		}

		public void RestoreCalibrationPose()
		{
			calibrationLocalRotation = initLocalRot;
		}

		public void SyncKinematicRigidbodyWithAnimatorPose()
		{
			if (!BoneSetup.BypassKinematicControl)
			{
				animatorRotation = animatorRotation.normalized;
				rigidbody.MovePosition(animatorPosition);
				rigidbody.MoveRotation(animatorRotation);
				AverageTranslationDataRequest();
			}
		}

		public void UpdateFixedPositionDelta()
		{
			if (!(rigidbody.position == PreviousFixedPosition))
			{
				Vector3 fixedPositionDelta = rigidbody.position - PreviousFixedPosition;
				FixedPositionDelta = fixedPositionDelta;
				PreviousFixedPosition = rigidbody.position;
			}
		}

		internal void AnimationJointMatchingUpdate(RagdollBonesChain chain)
		{
			if (rigidbody.isKinematic)
			{
				if (chain.ParentHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
				{
					SyncKinematicRigidbodyWithAnimatorPose();
				}
			}
			else
			{
				ApplyJointRotation();
			}
		}

		internal void ApplyAlternativeTensor()
		{
			RagdollHandlerUtilities.CalculateInertiaTensor(rigidbody);
		}

		public void ApplyJointRotation()
		{
			if (!(joint == null))
			{
				Quaternion targetRotation = jointAxisConversion * Quaternion.Inverse(animatorLocalRotation) * initialAxisCorrection;
				joint.targetRotation = targetRotation;
			}
		}

		internal void ApplyLocalRotationToAnimatorBone(Quaternion localRotation, float blend)
		{
			float num = BoneSetup.OverrideBlend;
			if (num == 0f)
			{
				num = blend * BoneSetup.BoneBlendMultiplier;
			}
			ApplyLocalRotationToAnimatorBoneFinal(localRotation, num);
		}

		public void ApplyLocalRotationToAnimatorBoneFinal(Quaternion localRotation, float blend)
		{
			if (blend >= 1f)
			{
				stransform.localRotation = localRotation;
			}
			else if (!(blend <= 0f))
			{
				stransform.localRotation = Quaternion.LerpUnclamped(stransform.localRotation, localRotation, blend);
			}
		}

		internal void ApplyPhysicalRotationToTheBone(float blend)
		{
			Quaternion localRotation = stransform.parent.rotation.QToLocal(dtransform.rotation);
			ApplyLocalRotationToAnimatorBone(localRotation, blend);
		}

		internal void ApplyPositionToAnimatorBone(Vector3 localPosition, float blend)
		{
			float num = BoneSetup.OverrideBlend;
			if (num == 0f)
			{
				num = blend * BoneSetup.BoneBlendMultiplier;
			}
			if (num >= 1f)
			{
				stransform.localPosition = localPosition;
			}
			else
			{
				if (num <= 0f)
				{
					return;
				}
				stransform.localPosition = Vector3.LerpUnclamped(stransform.localPosition, localPosition, num);
			}
			lastAppliedPosition = stransform.position;
		}

		internal void ApplyPhysicalPositionToTheBone(float blend)
		{
			Vector3 localPosition = BoneSetup.DetachParent.InverseTransformPoint(dtransform.position);
			ApplyPositionToAnimatorBone(localPosition, blend);
		}

		public void HardMatchBonePosition(float power)
		{
			Vector3 positionDifference = LastMatchingRigidodyOrigin - rigidbody.worldCenterOfMass;
			float num = power;
			num *= 1f / (positionDifference.sqrMagnitude * (15f + (1f - power) * 65f) + 1f);
			RagdollHandlerUtilities.AddAccelerationTowardsWorldPositionDiff(rigidbody, positionDifference, FixedPositionDelta, num, Time.fixedDeltaTime, power);
		}

		internal void StoreHardMatchFactor(RagdollBonesChain chain, float hardMatchMultiplier = 0f, float overallMultiplier = 1f)
		{
			UpdateFixedPositionDelta();
			storedHardMatch = CalculateHardMatchFactor(chain, hardMatchMultiplier, overallMultiplier);
		}

		private float CalculateHardMatchFactor(RagdollBonesChain chain, float hardMatchMultiplier = 0f, float overallMultiplier = 1f)
		{
			float num = BoneSetup.HardMatchOverride;
			if (num == 0f)
			{
				num = hardMatchMultiplier * BoneSetup.HardMatchingMultiply * chain.MusclesForce * chain.HardMatchMultiply;
				num = Mathf.Clamp01(num);
			}
			if (num * overallMultiplier == 0f)
			{
				return 0f;
			}
			return num;
		}

		internal void AnimationRotationHardMatchingStandUpdate(float hardMatch)
		{
			if (!rigidbody.isKinematic && !(hardMatch <= 0f))
			{
				Quaternion worldRotation = animatorRotation;
				BoneSetup.GameRigidbody.AddRigidbodyTorqueToRotateTowards(worldRotation, hardMatch * 1.25f);
			}
		}

		internal void AnimationRotationHardMatchingFallUpdate(float hardMatch = 0f)
		{
			if (!rigidbody.isKinematic && !(hardMatch <= 0f))
			{
				Quaternion worldRotation = BoneSetup.DetachParent.rotation.QToWorld(animatorLocalRotation);
				BoneSetup.GameRigidbody.AddRigidbodyTorqueToRotateTowards(worldRotation, hardMatch * 0.5f);
			}
		}

		private void UpdateTranslationData()
		{
			averageTranslation = Vector3.Lerp(averageTranslation, rigidbody.position - _lastFixedFramePosition, Time.fixedDeltaTime * 10f);
			_lastFixedFramePosition = rigidbody.position;
		}

		public Vector3 AverageTranslationDataRequest()
		{
			float num = Time.fixedTime - _translationCalculatedAtFixedTime;
			if (num < Time.fixedDeltaTime)
			{
				return averageTranslation;
			}
			if (num > Time.fixedDeltaTime * 10f)
			{
				averageTranslation = Vector3.zero;
				_lastFixedFramePosition = rigidbody.position;
			}
			_translationCalculatedAtFixedTime = Time.fixedTime;
			UpdateTranslationData();
			return averageTranslation;
		}

		public Vector3 AverageTranslationDataRequestRaw()
		{
			return averageTranslation;
		}

		internal void UpdateAngularData()
		{
			averageAngularity = Mathf.LerpAngle(averageAngularity, Quaternion.Angle(rigidbody.rotation, _lastFixedFrameRotation), Time.fixedDeltaTime * 10f);
			_lastFixedFrameRotation = rigidbody.rotation;
		}

		public float AverageAngularityDataRequest()
		{
			float num = Time.fixedTime - _angularCalculatedAtFixedTime;
			if (num < Time.fixedDeltaTime)
			{
				return averageAngularity;
			}
			if (num > Time.fixedDeltaTime * 10f)
			{
				averageAngularity = 0f;
				_lastFixedFrameRotation = rigidbody.rotation;
			}
			_angularCalculatedAtFixedTime = Time.fixedTime;
			UpdateAngularData();
			return averageAngularity;
		}

		public float AverageAngularityDataRequestRaw()
		{
			return averageAngularity;
		}
	}
}
