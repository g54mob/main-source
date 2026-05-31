using System;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class MathPlus
	{
		public static float Highest(float p_value1, float p_value2)
		{
			return Math.Max(p_value1, p_value2);
		}

		public static int Highest(int p_value1, int p_value2)
		{
			return Math.Max(p_value1, p_value2);
		}

		public static float Lowest(float p_value1, float p_value2)
		{
			return Math.Min(p_value1, p_value2);
		}

		public static int Lowest(int p_value1, int p_value2)
		{
			return Math.Min(p_value1, p_value2);
		}

		public static float HorizontalSqrMagnitude(Vector3 p_pos1, Vector3 p_pos2)
		{
			return (new Vector2(p_pos1.x, p_pos1.z) - new Vector2(p_pos2.x, p_pos2.z)).sqrMagnitude;
		}

		public static float AddTowards(float p_value, float p_add, float p_target)
		{
			p_add = Math.Abs(p_add);
			if (Math.Abs(p_value - p_target) <= 0.0001f)
			{
				return p_target;
			}
			if (Math.Sign(p_target - p_value) > 0)
			{
				return Math.Min(p_target, p_value + p_add);
			}
			return Math.Max(p_target, p_value - p_add);
		}

		public static int AddTowards(int value, int add, int target)
		{
			add = Math.Abs(add);
			if (Math.Abs(value - target) == 0)
			{
				return target;
			}
			if (Math.Sign(target - value) > 0)
			{
				return Math.Min(target, value + add);
			}
			return Math.Max(target, value - add);
		}
	}
}
