using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Goal RayCast Plane", 0)]
	public class HumanIKGoalRayCastPlane : IKProcessor
	{
		[Tooltip("Target to to lock any of the limbs ")]
		public AvatarIKGoal goal;

		public LayerReference HitMask = new LayerReference(1);

		public AxisDirection direction = AxisDirection.Forward;

		public float AdditiveDistance = 0.2f;

		[Min(0.001f)]
		public float radius = 0.05f;

		public bool position = true;

		[Hide("position")]
		public float NormalOffset;

		public bool rotation = true;

		[Hide("rotation")]
		public Vector3 Offset;

		public bool gizmos = true;

		private Transform Bone;

		private Transform RootBone;

		private Quaternion BeforeRotation;

		public override bool RequireTargets => false;

		public Vector3 Direction(Animator anim)
		{
			return direction switch
			{
				AxisDirection.None => Vector3.zero, 
				AxisDirection.Right => anim.transform.right, 
				AxisDirection.Left => -anim.transform.right, 
				AxisDirection.Up => anim.transform.up, 
				AxisDirection.Down => -anim.transform.up, 
				AxisDirection.Forward => anim.transform.forward, 
				AxisDirection.Backward => -anim.transform.forward, 
				_ => Vector3.zero, 
			};
		}

		public Vector3 NormalFromDirection(Animator anim)
		{
			return direction switch
			{
				AxisDirection.None => Vector3.up, 
				AxisDirection.Right => anim.transform.forward, 
				AxisDirection.Left => -anim.transform.forward, 
				AxisDirection.Up => anim.transform.right, 
				AxisDirection.Down => -anim.transform.right, 
				AxisDirection.Forward => anim.transform.up, 
				AxisDirection.Backward => -anim.transform.up, 
				_ => Vector3.up, 
			};
		}

		public override void Start(IKSet set, Animator anim, int index)
		{
			switch (goal)
			{
			case AvatarIKGoal.LeftFoot:
				Bone = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
				RootBone = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
				break;
			case AvatarIKGoal.RightFoot:
				Bone = anim.GetBoneTransform(HumanBodyBones.RightFoot);
				RootBone = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
				break;
			case AvatarIKGoal.LeftHand:
				Bone = anim.GetBoneTransform(HumanBodyBones.LeftHand);
				RootBone = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
				break;
			case AvatarIKGoal.RightHand:
				Bone = anim.GetBoneTransform(HumanBodyBones.RightHand);
				RootBone = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
				break;
			}
		}

		public override void OnAnimatorIK(IKSet set, Animator anim, int index, float weight)
		{
			Vector3 vector = Direction(anim);
			Vector3 vector2 = MTools.ClosestPointOnPlane(RootBone.position, vector, Bone.position);
			Vector3 b = Bone.position;
			float num = Vector3.Distance(vector2, b);
			Vector3 vector3 = vector * num;
			MDebug.DrawWireSphere(vector2, Color.white, radius);
			MDebug.DrawWireSphere(b, Color.white, radius);
			MDebug.DrawRay(vector2, vector3 * 2f, Color.green);
			BeforeRotation = Bone.rotation;
			if (Physics.SphereCast(vector2, radius, vector, out var hitInfo, num * 2f, HitMask, QueryTriggerInteraction.Ignore))
			{
				Vector3 point = hitInfo.point;
				MDebug.DrawWireSphere(vector2, Color.green, radius);
				MDebug.DrawWireSphere(point, Color.yellow, radius);
				MDebug.DrawRay(point, hitInfo.normal * 0.2f, Color.yellow);
				float num2 = hitInfo.distance - NormalOffset;
				float a = ((!(num2 + radius < num)) ? 0f : 1f);
				float a2 = num2.CalculateRangeWeight(num, num + AdditiveDistance);
				Quaternion quaternion = Quaternion.FromToRotation(-vector, hitInfo.normal) * anim.rootRotation;
				quaternion = Quaternion.Inverse(Bone.rotation) * quaternion;
				Quaternion goalRotation = Bone.rotation * quaternion * Quaternion.Euler(Offset);
				point += hitInfo.normal * NormalOffset;
				MDebug.DrawRay(Bone.position, Bone.rotation * Vector3.forward * 0.2f, Color.blue);
				MDebug.DrawRay(Bone.position, Bone.rotation * Vector3.right * 0.2f, Color.red);
				MDebug.DrawRay(Bone.position, Bone.rotation * Vector3.up * 0.2f, Color.green);
				if (position)
				{
					anim.SetIKPositionWeight(goal, Mathf.Min(a, weight));
					anim.SetIKPosition(goal, point);
				}
				if (rotation)
				{
					anim.SetIKRotationWeight(goal, Mathf.Min(a2, weight));
					anim.SetIKRotation(goal, goalRotation);
				}
				else
				{
					anim.SetIKRotationWeight(goal, 1f);
					anim.SetIKRotation(goal, anim.rootRotation * BeforeRotation * Quaternion.Inverse(Bone.rotation));
				}
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			Debug.Log("<B>[IK Processor: " + name + "][HumanIK Goal RayCast]</B>  <color=yellow>[OK]</color>");
		}

		public override void OnDrawGizmos(IKSet IKSet, Animator anim, float weight)
		{
			if (!gizmos)
			{
				return;
			}
			Vector3 vector = Direction(anim);
			if (!Application.isPlaying)
			{
				Transform transform = null;
				Transform transform2 = null;
				switch (goal)
				{
				case AvatarIKGoal.LeftFoot:
					transform = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
					transform2 = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
					break;
				case AvatarIKGoal.RightFoot:
					transform = anim.GetBoneTransform(HumanBodyBones.RightFoot);
					transform2 = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
					break;
				case AvatarIKGoal.LeftHand:
					transform = anim.GetBoneTransform(HumanBodyBones.LeftHand);
					transform2 = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
					break;
				case AvatarIKGoal.RightHand:
					transform = anim.GetBoneTransform(HumanBodyBones.RightHand);
					transform2 = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
					break;
				}
				Vector3 vector2 = transform2.position;
				float num = Vector3.Distance(transform2.position, transform.position);
				Vector3 vector3 = vector * (num + AdditiveDistance);
				Gizmos.color = Color.green;
				MDebug.GizmoRay(vector2, vector * num);
				Gizmos.DrawSphere(vector2, radius);
				Gizmos.color = Color.red;
				MDebug.GizmoRay(vector2 + vector * num, vector * AdditiveDistance);
				Gizmos.DrawSphere(vector2 + vector3, radius);
			}
		}
	}
}
