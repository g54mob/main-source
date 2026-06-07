using UnityEngine;

namespace RLD
{
	public static class SnapMath
	{
		public static NumSnapSteps CalculateNumSnapSteps(float snapStep, float total)
		{
			NumSnapSteps result = default(NumSnapSteps);
			result.FltNumSteps = total / snapStep;
			result.AbsFltNumSteps = Mathf.Abs(result.FltNumSteps);
			result.IntNumSteps = (int)result.FltNumSteps;
			result.AbsIntNumSteps = Mathf.Abs(result.IntNumSteps);
			result.AbsFracSteps = result.AbsFltNumSteps - (float)result.AbsIntNumSteps;
			return result;
		}

		public static bool CanExtractSnap(float snapStep, float accumulated)
		{
			return Mathf.Abs(accumulated) >= snapStep;
		}

		public static float ExtractSnap(float snapStep, ref float accumulated)
		{
			float num = (float)(int)(accumulated / snapStep) * snapStep;
			accumulated -= num;
			return num;
		}

		public static float ExtractSnap(float snapStep, float accumulated)
		{
			return (float)(int)(accumulated / snapStep) * snapStep;
		}
	}
}
