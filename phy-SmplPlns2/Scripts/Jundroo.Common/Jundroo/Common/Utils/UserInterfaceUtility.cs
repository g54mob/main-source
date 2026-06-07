using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class UserInterfaceUtility
	{
		private const float SnapStepEpsilon = 0.05f;

		public static float GetNextSnapStep(float current, float minimumValue = 0.001f, float epsilon = 0.05f)
		{
			if (current == 0f)
			{
				return minimumValue;
			}
			float num = StepToLinear(current);
			int num2 = (int)math.round(num);
			int linear = ((!(math.abs((float)num2 - num) <= epsilon)) ? ((int)math.ceil(num)) : (num2 + 1));
			return LinearIntToStep(linear) - current;
		}

		public static float GetPrevSnapStep(float current, float minimumValue = 0.001f, float epsilon = 0.05f)
		{
			if (current <= minimumValue)
			{
				return 0f;
			}
			float num = StepToLinear(current);
			int num2 = (int)math.round(num);
			int linear = ((!(math.abs((float)num2 - num) <= epsilon)) ? ((int)math.floor(num)) : (num2 - 1));
			return current - LinearIntToStep(linear);
		}

		public static void GetRectCornersInLocalSpace(RectTransform rect, RectTransform canvas, Vector2[] points, Camera camera)
		{
			Vector3[] array = new Vector3[4];
			rect.GetWorldCorners(array);
			for (int i = 0; i < 4; i++)
			{
				array[i] = RectTransformUtility.WorldToScreenPoint(camera, array[i]);
				RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, array[i], null, out var localPoint);
				points[i] = localPoint;
			}
		}

		private static float LinearIntToStep(int linear)
		{
			int result;
			int num = System.Math.DivRem(linear, 3, out result);
			if (result < 0)
			{
				result += 3;
				num--;
			}
			float num2 = 1f + (float)(result * result);
			return math.pow(10f, num) * num2;
		}

		private static float StepToLinear(float x)
		{
			float num = math.modf(Mathf.Log10(x), out var i);
			if (num < 0f)
			{
				num += 1f;
				i -= 1f;
			}
			num *= 3f;
			float num2 = num * (1.3858f + num * (-0.385799f + num * 0.0857332f));
			return i * 3f + num2;
		}
	}
}
