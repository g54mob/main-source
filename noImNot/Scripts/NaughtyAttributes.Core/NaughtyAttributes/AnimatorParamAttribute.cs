using System;
using UnityEngine;

namespace NaughtyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class AnimatorParamAttribute : DrawerAttribute
	{
		public string AnimatorName { get; private set; }

		public AnimatorControllerParameterType? AnimatorParamType { get; private set; }

		public AnimatorParamAttribute(string animatorName)
		{
		}

		public AnimatorParamAttribute(string animatorName, AnimatorControllerParameterType animatorParamType)
		{
		}
	}
}
