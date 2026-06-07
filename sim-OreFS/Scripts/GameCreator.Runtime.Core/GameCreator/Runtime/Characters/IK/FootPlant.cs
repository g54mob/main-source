using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	internal class FootPlant
	{
		private const int RAYCAST_FIXED_SIZE = 10;

		private const float COEFFICIENT_RANGE_FEET_UP = 0.5f;

		private const float COEFFICIENT_RANGE_FEET_DOWN = 0.2f;

		[NonSerialized]
		private readonly RaycastHit[] m_RaycastHitsBuffer = new RaycastHit[10];

		[NonSerialized]
		private readonly AnimFloat m_Weight = new AnimFloat(0f, 0f);

		[NonSerialized]
		private readonly AnimVector3 m_DeltaPosition = new AnimVector3(Vector3.zero, 0f);

		[NonSerialized]
		private readonly AnimQuaternion m_DeltaRotation = new AnimQuaternion(Quaternion.identity, 0f);

		[NonSerialized]
		private Transform m_BoneTransform;

		[NonSerialized]
		private bool m_HasHit;

		[NonSerialized]
		private Vector3 m_HitPoint;

		[NonSerialized]
		private Vector3 m_HitNormal;

		[field: NonSerialized]
		private HumanBodyBones Bone { get; }

		[field: NonSerialized]
		private AvatarIKGoal AvatarIK { get; }

		[field: NonSerialized]
		private RigFeetPlant Rig { get; }

		[field: NonSerialized]
		private int Phase { get; }

		private IUnitDriver Driver => Rig.Character.Driver;

		private Transform BoneTransform
		{
			get
			{
				if (m_BoneTransform == null)
				{
					Animator animator = Rig.Animator;
					m_BoneTransform = animator.GetBoneTransform(Bone);
				}
				return m_BoneTransform;
			}
		}

		public FootPlant(HumanBodyBones bone, AvatarIKGoal avatarIK, RigFeetPlant rig, int phase)
		{
			Bone = bone;
			AvatarIK = avatarIK;
			Rig = rig;
			Phase = phase;
			Rig.Character.EventAfterChangeModel += RegisterAnimatorIK;
			RegisterAnimatorIK();
		}

		private void RegisterAnimatorIK()
		{
			Rig.Character.Animim.EventOnAnimatorIK -= OnAnimatorIK;
			Rig.Character.Animim.EventOnAnimatorIK += OnAnimatorIK;
		}

		private void OnAnimatorIK(int layerIndex)
		{
			OnAnimatorUpdateFoot();
			OnAnimatorSetFoot();
		}

		private void OnAnimatorUpdateFoot()
		{
			Animator animator = Rig.Animator;
			if (animator == null)
			{
				return;
			}
			float num = Rig.Character.Motion.Height * 0.5f;
			float num2 = Rig.Character.Motion.Height * 0.2f;
			Vector3 iKPosition = animator.GetIKPosition(AvatarIK);
			Vector3 down = Vector3.down;
			int num3 = Physics.RaycastNonAlloc(iKPosition - down * num, down, m_RaycastHitsBuffer, num + num2, Rig.FootMask, QueryTriggerInteraction.Ignore);
			float num4 = float.PositiveInfinity;
			RaycastHit raycastHit = default(RaycastHit);
			for (int i = 0; i < num3; i++)
			{
				RaycastHit raycastHit2 = m_RaycastHitsBuffer[i];
				if (!(raycastHit2.distance > num4))
				{
					raycastHit = raycastHit2;
					num4 = raycastHit2.distance;
				}
			}
			if (num3 > 0)
			{
				m_HasHit = true;
				m_HitPoint = raycastHit.point;
				m_HitNormal = raycastHit.normal;
			}
			else
			{
				m_HasHit = false;
				m_HitPoint = BoneTransform.position;
				m_HitNormal = Vector3.up;
			}
		}

		private void OnAnimatorSetFoot()
		{
			Animator animator = Rig.Animator;
			if (!(animator == null))
			{
				if (m_HasHit)
				{
					Vector3 axis = Vector3.Cross(Vector3.up, m_HitNormal);
					Quaternion target = Quaternion.AngleAxis(Vector3.Angle(Vector3.up, m_HitNormal), axis);
					float num = Rig.FootOffset + Driver.SkinWidth;
					Vector3 target2 = m_HitPoint + Vector3.up * num;
					target2 -= animator.GetIKPosition(AvatarIK);
					m_DeltaPosition.Target = target2;
					m_DeltaRotation.Target = target;
					m_Weight.Target = 1f;
				}
				else
				{
					m_DeltaPosition.Target = Vector3.zero;
					m_DeltaRotation.Target = Quaternion.identity;
					m_Weight.Target = 0f;
				}
				float value = ((Rig.IsActive && Driver.IsGrounded) ? (Rig.Character.Phases.Get(Phase) * m_Weight.Current) : 0f);
				Vector3 iKPosition = animator.GetIKPosition(AvatarIK);
				Quaternion iKRotation = animator.GetIKRotation(AvatarIK);
				animator.SetIKPositionWeight(AvatarIK, value);
				animator.SetIKPosition(AvatarIK, m_DeltaPosition.Current + iKPosition);
				animator.SetIKRotationWeight(AvatarIK, value);
				animator.SetIKRotation(AvatarIK, m_DeltaRotation.Current * iKRotation);
			}
		}

		public void Update()
		{
			float deltaTime = Rig.Character.Time.DeltaTime;
			float smoothTime = Rig.SmoothTime;
			m_Weight.Smooth = smoothTime;
			m_Weight.UpdateWithDelta(deltaTime);
			m_DeltaPosition.Smooth = Vector3.one * smoothTime;
			m_DeltaRotation.Smooth = smoothTime;
			m_DeltaPosition.UpdateWithDelta(deltaTime);
			m_DeltaRotation.UpdateWithDelta(deltaTime);
		}
	}
}
