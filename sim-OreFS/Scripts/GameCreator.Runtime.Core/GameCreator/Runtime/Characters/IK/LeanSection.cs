using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	internal class LeanSection
	{
		private const float UP_SPEED = 0.25f;

		private const float DW_SPEED = 0.5f;

		private readonly AnimFloat m_RatioForward = new AnimFloat(0f, 0.5f);

		private readonly AnimFloat m_RatioSides = new AnimFloat(0f, 0.5f);

		[field: NonSerialized]
		private RigLean Rig { get; }

		[field: NonSerialized]
		private Transform Bone { get; }

		[field: NonSerialized]
		private float SidesAngle { get; }

		[field: NonSerialized]
		private float ForwardPositive { get; }

		[field: NonSerialized]
		private float ForwardNegative { get; }

		public LeanSection(RigLean rig, HumanBodyBones bone, float sidesAngle, float forwardNegative, float forwardPositive)
		{
			Rig = rig;
			Bone = rig.Character.Animim.Animator.GetBoneTransform(bone);
			SidesAngle = sidesAngle;
			ForwardNegative = forwardNegative;
			ForwardPositive = forwardPositive;
			rig.Character.EventAfterChangeModel += RegisterLateUpdate;
			RegisterLateUpdate();
		}

		private void RegisterLateUpdate()
		{
			Rig.Character.EventBeforeLateUpdate -= OnLateUpdate;
			Rig.Character.EventBeforeLateUpdate += OnLateUpdate;
		}

		private void OnLateUpdate()
		{
			if (!(Rig.Animator == null))
			{
				Quaternion quaternion = ((m_RatioForward.Current >= 0f) ? Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(ForwardPositive, 0f, 0f), m_RatioForward.Current) : Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(ForwardNegative, 0f, 0f), 0f - m_RatioForward.Current));
				Quaternion quaternion2 = Quaternion.SlerpUnclamped(Quaternion.identity, Quaternion.Euler(0f, 0f, 0f - SidesAngle), m_RatioSides.Current);
				if (!(Bone == null))
				{
					Bone.localRotation *= quaternion * quaternion2;
				}
			}
		}

		public void Update(float forward, float sides)
		{
			float deltaTime = Rig.Character.Time.DeltaTime;
			float num = ((Rig.IsActive && !Rig.Character.Ragdoll.IsRagdoll) ? 1f : 0f);
			m_RatioForward.UpdateWithDelta(forward * num, (forward >= m_RatioForward.Current) ? 0.25f : 0.5f, deltaTime);
			m_RatioSides.UpdateWithDelta(sides * num, 0.5f, deltaTime);
		}
	}
}
