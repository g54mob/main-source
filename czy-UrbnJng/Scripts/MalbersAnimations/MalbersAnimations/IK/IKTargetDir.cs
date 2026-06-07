using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Target Direction", 0)]
	public class IKTargetDir : IKProcessor
	{
		[Tooltip("The specific body part (hand or foot) that will be controlled by the IK system.")]
		[SerializeField]
		private AvatarIKGoal avatarIKGoal;

		[Tooltip("LayerMask used for detecting valid IK target layers.")]
		[SerializeField]
		private LayerMask detectionLayer;

		[Tooltip("The tag used to identify valid IK targets.")]
		[SerializeField]
		private Tag iKTargetTag;

		[Tooltip("Radius of the SphereCast to detect IK targets.")]
		[SerializeField]
		private float detectionRadius = 0.2f;

		[Tooltip("If true, the direction of the IK target detection is flattened along the Y-axis (useful for horizontal detection).")]
		[SerializeField]
		private bool flattenDirection;

		[Tooltip("Offset applied to the hit point where the raycast intersects the target. This offset is relative to the hit surface.")]
		[SerializeField]
		private Vector3 positionOffset = Vector3.zero;

		[Tooltip("Offset applied to the start position of the raycast. This offset is relative to the character's transform.")]
		[SerializeField]
		private Vector3 rayStartOffset = Vector3.zero;

		[Tooltip("Enable or disable the rotation adjustment for the IK target.")]
		[SerializeField]
		private bool enableRotation;

		[Hide("enableRotation", false)]
		[Tooltip("Rotation offset applied to the hit normal at the raycast hit point.")]
		[SerializeField]
		private Vector3 rotationOffset = Vector3.zero;

		private Transform iKTarget;

		private Transform bodyPart;

		public float lerpSpeed = 5f;

		private Vector3 currentIKPosition;

		public override bool RequireTargets => true;

		public override void Start(IKSet IKSet, Animator anim, int index)
		{
			switch (avatarIKGoal)
			{
			case AvatarIKGoal.LeftFoot:
				bodyPart = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
				break;
			case AvatarIKGoal.RightFoot:
				bodyPart = anim.GetBoneTransform(HumanBodyBones.RightFoot);
				break;
			case AvatarIKGoal.LeftHand:
				bodyPart = anim.GetBoneTransform(HumanBodyBones.LeftHand);
				break;
			case AvatarIKGoal.RightHand:
				bodyPart = anim.GetBoneTransform(HumanBodyBones.RightHand);
				break;
			}
		}

		public override void OnAnimatorIK(IKSet IKSet, Animator anim, int index, float weight)
		{
			IKSet.Targets = FindIKTargetsUsingSphereCast(bodyPart, iKTargetTag, detectionRadius, detectionLayer);
			if (IKSet.Targets.Length == 0)
			{
				return;
			}
			Transform transform = anim.transform.NearestTransform(IKSet.Targets);
			if (transform != null)
			{
				Vector3 vector = PerformRaycast(anim, bodyPart, transform, positionOffset, rayStartOffset);
				Vector3 vector2 = vector + anim.transform.TransformDirection(positionOffset);
				currentIKPosition = Vector3.Lerp(currentIKPosition, vector2, Time.deltaTime * lerpSpeed);
				anim.SetIKPositionWeight(avatarIKGoal, weight);
				anim.SetIKPosition(avatarIKGoal, vector2);
				if (enableRotation && vector != bodyPart.position)
				{
					Quaternion goalRotation = anim.transform.rotation * Quaternion.Euler(rotationOffset);
					anim.SetIKRotationWeight(avatarIKGoal, weight);
					anim.SetIKRotation(avatarIKGoal, goalRotation);
				}
			}
		}

		public TransformReference[] FindIKTargetsUsingSphereCast(TransformReference parent, Tag tag, float radius, LayerMask detectionLayer)
		{
			List<TransformReference> list = new List<TransformReference>();
			RaycastHit[] array = Physics.SphereCastAll(parent.position, radius, parent.Value.forward, 0.1f, detectionLayer);
			foreach (RaycastHit raycastHit in array)
			{
				Transform[] componentsInChildren = raycastHit.transform.GetComponentsInChildren<Transform>();
				foreach (Transform transform in componentsInChildren)
				{
					if (transform.HasMalbersTag(tag))
					{
						list.Add(transform);
					}
				}
			}
			return list.ToArray();
		}

		private Vector3 PerformRaycast(Animator anim, Transform rayStart, Transform target, Vector3 hitOffset, Vector3 rayStartOffset)
		{
			if (rayStart == null || target == null)
			{
				return rayStart.position;
			}
			Vector3 vector = rayStart.position + anim.transform.TransformDirection(rayStartOffset);
			Vector3 vector2 = (target.position - vector).normalized;
			if (flattenDirection)
			{
				vector2 = vector2.FlattenY();
			}
			if (Physics.Raycast(vector, vector2, out var hitInfo, detectionRadius, detectionLayer))
			{
				return hitInfo.point + anim.transform.TransformDirection(hitOffset);
			}
			return rayStart.position;
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			if (iKTargetTag == null)
			{
				Debug.LogWarning("<B>[IK Processor: " + name + "]</B>  <color=red>[No Tag defined]</color>");
			}
			else
			{
				Debug.Log("<B>[IK Processor: " + name + "]</B>  <color=green>[OK]</color>");
			}
		}

		public override void OnDrawGizmos(IKSet IKSet, Animator anim, float weight)
		{
			if (!(bodyPart != null))
			{
				return;
			}
			Vector3 vector = bodyPart.position + anim.transform.TransformDirection(rayStartOffset);
			Gizmos.color = Color.white;
			if (IKSet.Targets.Length != 0)
			{
				Transform transform = anim.transform.NearestTransform(IKSet.Targets);
				if (transform != null)
				{
					Vector3 vector2 = (transform.position - vector).normalized;
					if (flattenDirection)
					{
						vector2 = vector2.FlattenY();
					}
					if (Physics.Raycast(vector, vector2, out var hitInfo, detectionRadius, detectionLayer))
					{
						Gizmos.color = Color.green;
						Gizmos.DrawSphere(hitInfo.point, 0.1f);
					}
					else
					{
						Gizmos.color = Color.white;
					}
					Gizmos.DrawLine(vector, vector + vector2 * detectionRadius);
				}
			}
			else
			{
				Gizmos.color = Color.white;
			}
			Gizmos.DrawWireSphere(vector, detectionRadius);
		}
	}
}
