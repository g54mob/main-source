using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Look At Range", 0)]
	public class WeightLookAt : WeightProcessor
	{
		public enum UpVectorType
		{
			VectorUp = 0,
			Local = 1,
			Global = 2
		}

		[Tooltip("Limits the Look At from the Min to Max Value")]
		public RangedFloat LookAtLimit = new RangedFloat(90f, 120f);

		[Tooltip("Offset the Aim Direction by this angle")]
		public float AngleOffset;

		[Tooltip("Normalize the weight by this value")]
		public float normalizedBy = 1f;

		public UpVectorType upVector;

		[Hide("upVector", new int[] { 1 })]
		public Vector3 LocalUp = new Vector3(0f, 1f, 0f);

		[Hide("upVector", new int[] { 2 })]
		public Vector3Var WorldUp;

		public float GizmoRadius = 1f;

		public Color GizmoColor = Color.green;

		public Vector3 UpVector(Animator anim)
		{
			return upVector switch
			{
				UpVectorType.Local => anim.transform.TransformDirection(LocalUp), 
				UpVectorType.Global => WorldUp, 
				_ => Vector3.up, 
			};
		}

		public override float Process(IKSet set, float weight)
		{
			if (set.aimer == null)
			{
				return 0f;
			}
			Animator animator = set.Animator;
			Vector3 aimDirection = set.aimer.AimDirection;
			Vector3 vector = animator.transform.forward;
			if (AngleOffset != 0f)
			{
				vector = Quaternion.Euler(UpVector(animator) * AngleOffset) * vector;
			}
			float value = Vector3.Angle(vector, aimDirection);
			if (LookAtLimit.maxValue != 0f && LookAtLimit.minValue != 0f)
			{
				weight = Mathf.Min(weight, value.CalculateRangeWeight(LookAtLimit.minValue, LookAtLimit.maxValue));
			}
			return weight;
		}
	}
}
