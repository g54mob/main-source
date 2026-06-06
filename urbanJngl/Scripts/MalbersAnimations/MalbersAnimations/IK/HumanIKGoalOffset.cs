using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Humanoid/IK Goal Offset", 0)]
	public class HumanIKGoalOffset : IKProcessor
	{
		[Tooltip("Target to to lock any of the limbs ")]
		public AvatarIKGoal goal = AvatarIKGoal.RightHand;

		public bool RelativeToRoot = true;

		[Hide("RelativeToRoot", true)]
		[SearcheableEnum]
		public HumanBodyBones RelativeTo = HumanBodyBones.UpperChest;

		public Vector3 GoalOffset;

		public Vector3 GoalRotation;

		public bool FixHint = true;

		[Hide("FixHint", false)]
		public Vector3 HintOffset;

		public bool position = true;

		public bool rotation = true;

		public bool gizmos = true;

		[Tooltip("States that the IK Set will be active")]
		public List<StateID> states;

		private List<int> statesID;

		[Tooltip("Stances that the IK Set will be active")]
		public List<StanceID> stances;

		private List<int> stancesID;

		[Tooltip("Lerp the Goal Offset")]
		public float lerp = 10f;

		public override bool RequireTargets => false;

		public override void Start(IKSet set, Animator animator, int index)
		{
			set.Var[index].RootBone = (RelativeToRoot ? animator.transform : animator.GetBoneTransform(RelativeTo));
			if (states != null)
			{
				statesID = new List<int>();
				foreach (StateID state in states)
				{
					statesID.Add(state.ID);
				}
			}
			if (stances != null)
			{
				stancesID = new List<int>();
				foreach (StanceID stance in stances)
				{
					stancesID.Add(stance.ID);
				}
			}
			set.sharedVars.TryAdd($"GoalOffset{index}", GoalOffset);
			set.sharedVars.TryAdd($"HintOffset{index}", HintOffset);
			set.sharedVars.TryAdd($"GoalRotation{index}", GoalRotation);
		}

		private AvatarIKHint GetHint()
		{
			return goal switch
			{
				AvatarIKGoal.LeftFoot => AvatarIKHint.LeftKnee, 
				AvatarIKGoal.RightFoot => AvatarIKHint.RightKnee, 
				AvatarIKGoal.LeftHand => AvatarIKHint.LeftElbow, 
				AvatarIKGoal.RightHand => AvatarIKHint.RightElbow, 
				_ => AvatarIKHint.LeftKnee, 
			};
		}

		private Transform GetGoal(Animator ani)
		{
			return goal switch
			{
				AvatarIKGoal.LeftFoot => ani.GetBoneTransform(HumanBodyBones.LeftFoot), 
				AvatarIKGoal.RightFoot => ani.GetBoneTransform(HumanBodyBones.RightFoot), 
				AvatarIKGoal.LeftHand => ani.GetBoneTransform(HumanBodyBones.LeftHand), 
				AvatarIKGoal.RightHand => ani.GetBoneTransform(HumanBodyBones.RightHand), 
				_ => ani.GetBoneTransform(HumanBodyBones.LeftFoot), 
			};
		}

		public override void OnAnimatorIK(IKSet set, Animator animator, int index, float weight)
		{
			if (statesID != null && statesID.Count > 0)
			{
				weight = (statesID.Contains(set.CurrentState) ? weight : 0f);
			}
			if (stancesID != null && stancesID.Count > 0)
			{
				weight = (stancesID.Contains(set.CurrentStance) ? weight : 0f);
			}
			if (weight == 0f)
			{
				return;
			}
			Transform rootBone = set.Var[index].RootBone;
			Vector3 a = set.sharedVars.Get<Vector3>($"GoalOffset{index}");
			Vector3 a2 = set.sharedVars.Get<Vector3>($"HintOffset{index}");
			Vector3 vector = set.sharedVars.Get<Vector3>($"GoalRotation{index}");
			set.sharedVars[$"GoalOffset{index}"] = Vector3.Lerp(a, GoalOffset, lerp * Time.deltaTime);
			set.sharedVars[$"HintOffset{index}"] = Vector3.Lerp(a2, HintOffset, lerp * Time.deltaTime);
			set.sharedVars[$"GoalRotation{index}"] = Vector3.Lerp(vector, GoalRotation, lerp * Time.deltaTime);
			Vector3 goalPosition = rootBone.TransformPoint(a);
			Vector3 hintPosition = rootBone.TransformPoint(a2);
			if (position)
			{
				animator.SetIKPositionWeight(goal, weight);
				animator.SetIKPosition(goal, goalPosition);
				MDebug.DrawWireSphere(goalPosition, Color.green, 0.05f);
				if (FixHint)
				{
					animator.SetIKHintPositionWeight(GetHint(), weight);
					animator.SetIKHintPosition(GetHint(), hintPosition);
					MDebug.DrawWireSphere(hintPosition, Color.green, 0.05f);
				}
			}
			if (rotation)
			{
				animator.SetIKRotationWeight(goal, weight);
				animator.SetIKRotation(goal, rootBone.rotation * Quaternion.Euler(vector));
			}
		}

		public override void OnDrawGizmos(IKSet IKSet, Animator anim, float weight)
		{
			if (!gizmos)
			{
				return;
			}
			Transform transform = (RelativeToRoot ? anim.transform : anim.GetBoneTransform(RelativeTo));
			Transform transform2 = GetGoal(anim);
			if (!(transform == null))
			{
				Matrix4x4 matrix = Gizmos.matrix;
				Gizmos.matrix = transform.localToWorldMatrix;
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(Vector3.zero + GoalOffset, 0.05f);
				Gizmos.DrawSphere(Vector3.zero + GoalOffset, 0.05f);
				Gizmos.matrix = matrix;
				Vector3 vector = transform.TransformPoint(GoalOffset);
				Gizmos.color = Color.green;
				Gizmos.DrawLine(transform2.position, vector);
				Gizmos.color = Color.gray;
				Gizmos.DrawLine(transform.position, vector);
				Gizmos.color = Color.green;
				Gizmos.DrawRay(vector, transform.rotation * Quaternion.Euler(GoalRotation) * Vector3.up * 0.2f);
				Gizmos.color = Color.red;
				Gizmos.DrawRay(vector, transform.rotation * Quaternion.Euler(GoalRotation) * Vector3.right * 0.2f);
				Gizmos.color = Color.blue;
				Gizmos.DrawRay(vector, transform.rotation * Quaternion.Euler(GoalRotation) * Vector3.forward * 0.2f);
				if (FixHint)
				{
					Gizmos.color = Color.blue;
					Gizmos.DrawSphere(transform.TransformPoint(HintOffset), 0.05f);
				}
			}
		}

		public override void Validate(IKSet set, Animator animator, int index)
		{
			Debug.Log("<B>[IK Processor: " + name + "][HumanIK Goal]</B>  <color=yellow>[OK]</color>");
		}
	}
}
