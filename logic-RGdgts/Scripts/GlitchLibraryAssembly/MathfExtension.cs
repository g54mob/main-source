using UnityEngine;

public static class MathfExtension
{
	public enum EaseFunctions
	{
		Linear = 0,
		InCubic = 1,
		OutCubic = 2,
		InOutCubic = 3
	}

	public static float RoundToMultiple(float value, float multiple)
	{
		return 0f;
	}

	public static float GetAngleBelow180Signed(float angle)
	{
		return 0f;
	}

	public static float GetAnglePositiveSafe(float angle)
	{
		return 0f;
	}

	public static bool IsWithinTolerance(float value, float target, float tolerance)
	{
		return false;
	}

	public static bool IsWithinTolerance(Vector3 value, Vector3 target, float tolerance)
	{
		return false;
	}

	public static bool IsWithinTolerance(Quaternion value, Quaternion target, float tolerance)
	{
		return false;
	}

	public static float CircularInterpolation(float from, float to, float amount)
	{
		return 0f;
	}

	public static float NormalizeAngle(float value, float start, float end)
	{
		return 0f;
	}

	public static float ClampAngle0360(float eulerAngles)
	{
		return 0f;
	}

	public static Quaternion FromToRotation(Vector3 dir1, Vector3 dir2)
	{
		return default(Quaternion);
	}

	public static float Ease(float progress, EaseFunctions function)
	{
		return 0f;
	}
}
