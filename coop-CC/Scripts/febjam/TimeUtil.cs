using System.Runtime.CompilerServices;
using UnityEngine;

public static class TimeUtil
{
	public const int FRAMES_PER_SECOND = 60;

	public const float FIXED_DELTA_TIME = 1f / 60f;

	public const double FIXED_DELTA_TIME_DBL = 1.0 / 60.0;

	public const float FIXED_DELTA_TIME_SQR = 0.0002777778f;

	public const int FRAMES_PER_SECOND_ANIM = 60;

	public const float FIXED_DELTA_TIME_ANIM = 1f / 60f;

	public const int FRAMES_PER_ANIM_FRAME = 1;

	public static int frame;

	public static float elapsedTimeInFrame => (float)(Time.timeAsDouble - Time.fixedTimeAsDouble);

	public static double elapsedTimeInFrameAsDouble => Time.timeAsDouble - Time.fixedTimeAsDouble;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FramesForTime(float duration)
	{
		return Mathf.CeilToInt((float)((double)duration / 0.01666666753590107));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FramesForTime(double duration)
	{
		return Mathf.CeilToInt((float)(duration / 0.01666666753590107));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FramesForTimeAnim(float duration)
	{
		return FramesForTimeAnim((double)duration);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FramesForTimeAnim(double duration)
	{
		int num = FramesForTime(duration);
		int num2 = num % 1;
		if (num2 != 0)
		{
			num += 1 - num2;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float GetFrameFixedTimeAnim(float duration)
	{
		return (float)FramesForTimeAnim(duration) * (1f / 60f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double GetFrameFixedTimeAnim(double duration)
	{
		return (float)FramesForTimeAnim(duration) * (1f / 60f);
	}
}
