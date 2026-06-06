using System;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[Serializable]
	[AddTypeMenu("Aimer has Target", 0)]
	public class WeightAimTarget : WeightProcessor
	{
		[Tooltip("If the Aimer component does not have a target then set the weight to 1")]
		public bool invert;

		public override float Process(IKSet set, float weight)
		{
			float num = weight * ((set.aimer != null && (bool)set.aimer.AimTarget) ? 1f : 0f);
			if (invert)
			{
				num = 1f - num;
			}
			return num;
		}
	}
}
