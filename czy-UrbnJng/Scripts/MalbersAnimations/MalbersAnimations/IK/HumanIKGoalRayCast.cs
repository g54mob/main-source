using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Goal RayCast", 0)]
	public class HumanIKGoalRayCast : IKProcessor
	{
		[Tooltip("Target to to lock any of the limbs ")]
		public AvatarIKGoal goal;

		public RangedFloat RayDistance = new RangedFloat(0.5f, 2f);

		public LayerReference HitMask = new LayerReference(1);

		public AxisDirection direction = AxisDirection.Forward;

		public bool position = true;

		[Hide("position")]
		public float NormalOffset;

		public bool rotation = true;

		[Hide("rotation")]
		public Vector3 Offset;

		public bool gizmos = true;

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
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
				set.Var[index].RootBone = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
				break;
			case AvatarIKGoal.RightFoot:
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.RightFoot);
				set.Var[index].RootBone = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
				break;
			case AvatarIKGoal.LeftHand:
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.LeftHand);
				set.Var[index].RootBone = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
				break;
			case AvatarIKGoal.RightHand:
				set.Var[index].Bone = anim.GetBoneTransform(HumanBodyBones.RightHand);
				set.Var[index].RootBone = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
				break;
			}
		}

		public override void OnAnimatorIK(IKSet set, Animator anim, int index, float weight)
		{
			Vector3 vector = Direction(anim);
			Vector3 vector2 = vector * RayDistance.Min;
			Transform bone = set.Var[index].Bone;
			NormalFromDirection(anim);
			Vector3 vector3 = MTools.ClosestPointOnPlane(set.Var[index].RootBone.position, vector, bone.position);
			MDebug.DrawWireSphere(vector3, Color.magenta, 0.025f);
			MDebug.DrawWireSphere(bone.position, Color.white, 0.025f);
			MDebug.DrawRay(vector3, vector2, Color.green);
			MDebug.DrawRay(vector3 + vector2, vector * RayDistance.Difference, Color.red);
			if (Physics.Raycast(vector3, vector, out var hitInfo, RayDistance.maxValue, HitMask, QueryTriggerInteraction.Ignore))
			{
				Vector3 point = hitInfo.point;
				MDebug.DrawWireSphere(vector3, Color.green, 0.04f);
				weight *= hitInfo.distance.CalculateRangeWeight(RayDistance.Min, RayDistance.Max);
				MDebug.DrawRay(point, hitInfo.normal * 0.2f, Color.yellow);
				Quaternion quaternion = Quaternion.FromToRotation(-vector, hitInfo.normal);
				quaternion = Quaternion.Inverse(bone.rotation) * quaternion;
				Quaternion goalRotation = anim.rootRotation * bone.rotation * quaternion * Quaternion.Euler(Offset);
				point += hitInfo.normal * NormalOffset;
				if (position)
				{
					anim.SetIKPositionWeight(goal, weight);
					anim.SetIKPosition(goal, point);
				}
				if (rotation)
				{
					anim.SetIKRotationWeight(goal, weight);
					anim.SetIKRotation(goal, goalRotation);
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
				switch (goal)
				{
				case AvatarIKGoal.LeftFoot:
					transform = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
					break;
				case AvatarIKGoal.RightFoot:
					transform = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
					break;
				case AvatarIKGoal.LeftHand:
					transform = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
					break;
				case AvatarIKGoal.RightHand:
					transform = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
					break;
				}
				Vector3 vector2 = transform.position;
				Gizmos.color = Color.green;
				MDebug.GizmoRay(vector2, vector * RayDistance.Min);
				Gizmos.DrawSphere(vector2, 0.02f);
				Gizmos.color = Color.red;
				MDebug.GizmoRay(vector2 + vector * RayDistance.Min, vector * RayDistance.Difference);
				Gizmos.DrawSphere(vector2 + vector * RayDistance.Max, 0.02f);
			}
		}
	}
}
