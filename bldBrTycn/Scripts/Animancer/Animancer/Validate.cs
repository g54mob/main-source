using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Animancer
{
	public static class Validate
	{
		public enum Value
		{
			Any = 0,
			ZeroToOne = 1,
			IsNotNegative = 2,
			IsFinite = 3,
			IsFiniteOrNaN = 4
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void Disable(this OptionalWarning type)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void Enable(this OptionalWarning type)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void SetEnabled(this OptionalWarning type, bool enable)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void Log(this OptionalWarning type, string message, object context = null)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void AssertNotLegacy(AnimationClip clip)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void AssertRoot(AnimancerNode node, AnimancerPlayable root)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void AssertPlayable(AnimancerNode node)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		public static void AssertCanRemoveChild(AnimancerState state, IList<AnimancerState> childStates, int childCount)
		{
		}

		public static void ValueRule(ref float value, Value rule)
		{
			switch (rule)
			{
			case Value.ZeroToOne:
				if (!(value >= 0f))
				{
					value = 0f;
				}
				else if (value > 1f)
				{
					value = 1f;
				}
				break;
			case Value.IsNotNegative:
				if (!(value >= 0f))
				{
					value = 0f;
				}
				break;
			case Value.IsFinite:
				if (float.IsNaN(value))
				{
					value = 0f;
				}
				else if (float.IsPositiveInfinity(value))
				{
					value = float.MaxValue;
				}
				else if (float.IsNegativeInfinity(value))
				{
					value = float.MinValue;
				}
				break;
			case Value.IsFiniteOrNaN:
				if (float.IsPositiveInfinity(value))
				{
					value = float.MaxValue;
				}
				else if (float.IsNegativeInfinity(value))
				{
					value = float.MinValue;
				}
				break;
			}
		}
	}
}
