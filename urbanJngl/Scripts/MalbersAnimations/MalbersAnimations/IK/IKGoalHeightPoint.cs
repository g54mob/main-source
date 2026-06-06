using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Goal Height Point", 0)]
	public class IKGoalHeightPoint : IKProcessor
	{
		[Tooltip("Target limb to lock using IK. Options: LeftFoot, RightFoot, LeftHand, RightHand.")]
		[SerializeField]
		private AvatarIKGoal avatarIKGoal;

		[Tooltip("Layer mask to specify which objects are detected.")]
		[SerializeField]
		private LayerMask detectionLayer;

		[Tooltip("Radius of the SphereCast used for initial detection.")]
		[Min(0f)]
		[SerializeField]
		private float sphereCastRadius = 0.15f;

		[Tooltip("Maximum distance for the SphereCast.")]
		[Min(0f)]
		[SerializeField]
		private float sphereCastDistance = 1f;

		[Tooltip("Adjustment for how deep into the surface the SphereCast should detect.")]
		[Min(0f)]
		[SerializeField]
		private float heightOriginPenetrationDepth = 0.05f;

		[Tooltip("Height offset applied to adjust the raycast origin relative to the hit surface. What should be the max height?")]
		[Min(0f)]
		[SerializeField]
		private float heightOriginUpOffset = 0.5f;

		[Tooltip("Forward offset applied to the initial ray origin, relative to the character's position.")]
		[SerializeField]
		private Vector3 sphereCastOffset = new Vector3(0f, 0f, -0.5f);

		[Tooltip("Additional offset applied to adjust the IK target's final position.")]
		[SerializeField]
		private Vector3 targetPosOffsetDistance;

		[Tooltip("Enable or disable the rotation adjustment for the IK target.")]
		[SerializeField]
		private bool enableRotation;

		[Hide("enableRotation", false)]
		[Tooltip("Offset to apply in Euler angles when adjusting rotation.")]
		[SerializeField]
		private Vector3 rotationOffset;

		private Transform bodyPart;

		public override bool RequireTargets => false;

		public override void Start(IKSet set, Animator anim, int index)
		{
			switch (avatarIKGoal)
			{
			case AvatarIKGoal.LeftFoot:
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
				break;
			case AvatarIKGoal.RightFoot:
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.RightFoot);
				break;
			case AvatarIKGoal.LeftHand:
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.LeftHand);
				break;
			case AvatarIKGoal.RightHand:
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.RightHand);
				break;
			}
		}

		public override void OnAnimatorIK(IKSet set, Animator anim, int index, float weight)
		{
			bodyPart = set.Var[index].Bone;
			CheckForHeighestPoint(set, anim, index, weight);
		}

		public void CheckForHeighestPoint(IKSet set, Animator anim, int index, float weight)
		{
			if (Physics.SphereCast(bodyPart.position + anim.transform.TransformDirection(sphereCastOffset), sphereCastRadius, anim.transform.forward, out var hitInfo, sphereCastDistance, detectionLayer))
			{
				Vector3 up = Vector3.up;
				if (Physics.Raycast(hitInfo.point + anim.transform.forward * heightOriginPenetrationDepth + up * heightOriginUpOffset, -up, out var hitInfo2, heightOriginUpOffset * 1.1f, detectionLayer))
				{
					ApplyIKPositionRotation(anim, hitInfo2.point, weight);
				}
			}
		}

		private void ApplyIKPositionRotation(Animator anim, Vector3 position, float weight)
		{
			Vector3 goalPosition = position + anim.transform.TransformDirection(targetPosOffsetDistance);
			anim.SetIKPositionWeight(avatarIKGoal, weight);
			anim.SetIKPosition(avatarIKGoal, goalPosition);
			if (enableRotation)
			{
				Quaternion goalRotation = anim.transform.rotation * Quaternion.Euler(rotationOffset);
				anim.SetIKRotationWeight(avatarIKGoal, weight);
				anim.SetIKRotation(avatarIKGoal, goalRotation);
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			bool flag = true;
			if (heightOriginPenetrationDepth < 0.01f)
			{
				Debug.LogWarning($"<B>[IK Processor: {name}]</B>  <color=red>[Warning]</color> Penetration Depth is too small, it should be greater than {0.01f}.");
				flag = false;
			}
			if (heightOriginUpOffset < 0.1f)
			{
				Debug.LogWarning($"<B>[IK Processor: {name}]</B>  <color=red>[Warning]</color> Height Up Offset is too small, it should be greater than {0.1f}.");
				flag = false;
			}
			if (sphereCastRadius < 0.05f)
			{
				Debug.LogWarning($"<B>[IK Processor: {name}]</B>  <color=red>[Warning]</color> SphereCast Radius is too small, it should be greater than {0.05f}.");
				flag = false;
			}
			if (sphereCastDistance < 0.1f)
			{
				Debug.LogWarning($"<B>[IK Processor: {name}]</B>  <color=red>[Warning]</color> SphereCast Distance is too small, it should be greater than {0.1f}.");
				flag = false;
			}
			if (flag)
			{
				Debug.Log("<B>[IK Processor: " + name + "][IKGoalHeightPoint]</B>  <color=green>[OK]</color> All parameters are valid.");
			}
		}

		public override void OnDrawGizmos(IKSet IKSet, Animator anim, float weight)
		{
			if (!(bodyPart != null))
			{
				return;
			}
			Vector3 vector = bodyPart.position + anim.transform.TransformDirection(sphereCastOffset);
			Gizmos.color = Color.white;
			RaycastHit hitInfo;
			bool num = Physics.SphereCast(vector, sphereCastRadius, anim.transform.forward, out hitInfo, sphereCastDistance, detectionLayer);
			if (num)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawSphere(hitInfo.point, 0.05f);
				Vector3 up = Vector3.up;
				Vector3 vector2 = hitInfo.point + anim.transform.forward * heightOriginPenetrationDepth + up * heightOriginUpOffset;
				if (Physics.Raycast(vector2, -up, out var hitInfo2, heightOriginUpOffset * 1.1f, detectionLayer))
				{
					Gizmos.color = Color.green;
					Gizmos.DrawLine(vector2, hitInfo2.point);
					Gizmos.DrawSphere(hitInfo2.point, 0.05f);
				}
				else
				{
					Gizmos.color = Color.white;
					Gizmos.DrawLine(vector2, vector2 - up * heightOriginUpOffset);
				}
			}
			Gizmos.color = (num ? Color.green : Color.white);
			Gizmos.DrawWireSphere(vector, sphereCastRadius);
			Gizmos.DrawLine(vector, vector + anim.transform.forward * sphereCastDistance);
		}
	}
}
