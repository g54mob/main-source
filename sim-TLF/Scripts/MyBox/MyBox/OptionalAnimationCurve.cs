using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class OptionalAnimationCurve : Optional<AnimationCurve>
	{
		public OptionalAnimationCurve(AnimationCurve value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}
	}
}
