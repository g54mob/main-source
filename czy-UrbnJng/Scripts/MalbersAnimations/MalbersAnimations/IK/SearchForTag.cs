using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/Search For Tag", 0)]
	public class SearchForTag : IKProcessor
	{
		[Tooltip("Target limb to lock using IK.")]
		[SerializeField]
		private AvatarIKGoal avatarIKGoal;

		[Tooltip("LayerMask used for detecting valid IK target layers.")]
		[SerializeField]
		private LayerMask detectionLayer;

		[Tooltip("The tag used to identify valid IK targets.")]
		[SerializeField]
		private Tag iKTargetTag;

		[Tooltip("If true, use the transform-based method for IK target detection, otherwise use raycast-based detection.")]
		[SerializeField]
		private bool useTransform;

		[Hide("useTransform", false)]
		[Tooltip("Radius of the SphereCast to detect IK targets.")]
		[Min(0f)]
		[SerializeField]
		private float detectionRadius = 0.2f;

		[Hide("useTransform", true)]
		[Tooltip("The angle by which we rotate the forward vector when determining the direction of the raycast.")]
		[SerializeField]
		private float detectionAngle = 45f;

		[Hide("useTransform", true)]
		[Tooltip("The maximum length of the spherecast or raycast used to detect targets.")]
		[Min(0f)]
		[SerializeField]
		private float castLenght = 0.7f;

		[Tooltip("Offset to apply to the IK target's position.")]
		[SerializeField]
		private Vector3 positionOffset;

		[Tooltip("Enable or disable the rotation adjustment for the IK target.")]
		[SerializeField]
		private bool enableRotation;

		[Hide("enableRotation", false)]
		[Tooltip("Optional offset to apply to the IK target's rotation.")]
		[SerializeField]
		private Vector3 rotationOffset;

		private Transform[] iKTargets;

		private Transform iKTarget;

		private Vector3 ikHitPoint;

		private Transform bodyPart;

		public override bool RequireTargets => false;

		public override void Validate(IKSet set, Animator animator, int index)
		{
			if (iKTargetTag == null)
			{
				Debug.LogWarning("<B>[IK Processor: " + name + "][SearchForTag]</B>  <color=red>[No Tag defined]</color>");
			}
			else
			{
				Debug.Log("<B>[IK Processor: " + name + "][SearchForTag]</B>  <color=green>[OK]</color>");
			}
		}

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

		public override void OnAnimatorIK(IKSet IKSet, Animator anim, int index, float weight)
		{
			bodyPart = IKSet.Var[index].Bone;
			if (useTransform)
			{
				GetIKTargetTransform(anim, iKTargets);
				if (iKTarget != null)
				{
					ApplyIKPositionRotation(anim, iKTarget.position, weight);
				}
			}
			else
			{
				GetIKTargetHitPoint(anim);
				if (ikHitPoint != Vector3.zero)
				{
					ApplyIKPositionRotation(anim, ikHitPoint, weight);
				}
			}
		}

		private void ApplyIKPositionRotation(Animator anim, Vector3 position, float weight)
		{
			Vector3 goalPosition = position + anim.transform.TransformDirection(positionOffset);
			anim.SetIKPositionWeight(avatarIKGoal, weight);
			anim.SetIKPosition(avatarIKGoal, goalPosition);
			if (enableRotation)
			{
				Quaternion goalRotation = anim.transform.rotation * Quaternion.Euler(rotationOffset);
				anim.SetIKRotationWeight(avatarIKGoal, weight);
				anim.SetIKRotation(avatarIKGoal, goalRotation);
			}
		}

		public void GetIKTargetHitPoint(Animator anim)
		{
			Vector3 direction = Quaternion.AngleAxis(detectionAngle, Vector3.up) * anim.transform.forward;
			if (Physics.Raycast(bodyPart.position, direction, out var hitInfo, castLenght, detectionLayer))
			{
				if (hitInfo.transform.HasMalbersTag(iKTargetTag))
				{
					ikHitPoint = hitInfo.point;
				}
			}
			else
			{
				ikHitPoint = Vector3.zero;
			}
		}

		public void GetIKTargetTransform(Animator anim, Transform[] IKTargets)
		{
			IKTargets = FindIKTargetsUsingSphereCast(bodyPart, iKTargetTag, detectionRadius, detectionLayer);
			if (IKTargets == null || IKTargets.Length == 0)
			{
				iKTarget = null;
			}
			else
			{
				iKTarget = anim.transform.NearestTransform(IKTargets);
			}
		}

		public Transform[] FindIKTargetsUsingSphereCast(Transform parent, Tag tag, float radius, LayerMask detectionLayer)
		{
			List<Transform> list = new List<Transform>();
			RaycastHit[] array = Physics.SphereCastAll(parent.position, radius, parent.forward, castLenght, detectionLayer);
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

		public override void OnDrawGizmos(IKSet IKSet, Animator anim, float weight)
		{
			if (bodyPart == null)
			{
				return;
			}
			if (useTransform)
			{
				Vector3 position = bodyPart.position;
				RaycastHit[] array = Physics.SphereCastAll(position, detectionRadius, bodyPart.forward, castLenght, detectionLayer);
				if (array.Length != 0)
				{
					RaycastHit[] array2 = array;
					foreach (RaycastHit raycastHit in array2)
					{
						Gizmos.color = Color.green;
						Gizmos.DrawLine(position, raycastHit.transform.position);
					}
				}
				else
				{
					Gizmos.color = Color.white;
				}
				Gizmos.DrawWireSphere(position, detectionRadius);
			}
			else
			{
				Vector3 vector = Quaternion.AngleAxis(detectionAngle, Vector3.up) * anim.transform.forward;
				Vector3 position2 = bodyPart.position;
				if (Physics.Raycast(position2, vector, out var hitInfo, castLenght, detectionLayer))
				{
					Gizmos.color = Color.green;
					Gizmos.DrawSphere(hitInfo.point, 0.05f);
				}
				else
				{
					Gizmos.color = Color.white;
				}
				Gizmos.DrawLine(position2, position2 + vector * castLenght);
			}
		}
	}
}
