using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Weight Animation Paramameter", 0)]
	public class WeightAnimParam : WeightProcessor
	{
		[Tooltip("Name of the Animator Parameter to check")]
		[AnimatorParam(AnimatorControllerParameterType.Float)]
		public string Parameter;

		[Tooltip("Normalize the weight by this value")]
		public float normalizedBy = 1f;

		[HideInInspector]
		public int AnimParamHash;

		[Tooltip("Inverth the value of the Animation Curve (One Minus) 1-Value")]
		public bool invert;

		public override float Process(IKSet set, float weight)
		{
			if (AnimParamHash == 0)
			{
				AnimParamHash = Animator.StringToHash(Parameter);
			}
			float num = 1f;
			if (AnimParamHash != 0)
			{
				num = set.Animator.GetFloat(AnimParamHash) / normalizedBy;
				if (invert)
				{
					num = 1f - num;
				}
			}
			return weight * num;
		}
	}
}
