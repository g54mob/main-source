using System;
using UnityEngine;

namespace MalbersAnimations
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class AnimatorParamAttribute : PropertyAttribute
	{
		public string AnimatorName { get; private set; }

		public AnimatorControllerParameterType? AnimatorParamType { get; private set; }

		public AnimatorParamAttribute(string animatorName)
		{
			AnimatorName = animatorName;
			AnimatorParamType = null;
		}

		public AnimatorParamAttribute(AnimatorControllerParameterType animatorParamType)
		{
			AnimatorName = string.Empty;
			AnimatorParamType = null;
		}

		public AnimatorParamAttribute(string animatorName, AnimatorControllerParameterType animatorParamType)
		{
			AnimatorName = animatorName;
			AnimatorParamType = animatorParamType;
		}
	}
}
