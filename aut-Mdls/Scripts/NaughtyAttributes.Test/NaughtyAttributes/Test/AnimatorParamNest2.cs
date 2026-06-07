using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class AnimatorParamNest2
	{
		public Animator animator2;

		[AnimatorParam("GetAnimator2", AnimatorControllerParameterType.Int)]
		public int hash1;

		[AnimatorParam("GetAnimator2", AnimatorControllerParameterType.Trigger)]
		public string name1;

		private Animator GetAnimator2()
		{
			return animator2;
		}
	}
}
