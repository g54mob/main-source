using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class AnimatorParamNest1
	{
		public Animator animator1;

		[AnimatorParam("Animator1", AnimatorControllerParameterType.Bool)]
		public int hash1;

		[AnimatorParam("Animator1", AnimatorControllerParameterType.Float)]
		public string name1;

		public AnimatorParamNest2 nest2;

		private Animator Animator1 => animator1;
	}
}
