using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Weight Target Index", 0)]
	public class WeightTarget : WeightProcessor
	{
		[Tooltip("Check if a transform exist. If it is null then the Weight will be zero")]
		[Min(0f)]
		public int TargetIndex;

		public override float Process(IKSet set, float weight)
		{
			return weight * ((set.Targets[TargetIndex].Value != null) ? 1f : 0f);
		}
	}
}
