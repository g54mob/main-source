using UnityEngine;

public static class NumberUtil
{
	public static bool IsInfinityMinMaxNaN(float number)
	{
		if (!float.IsNaN(number) && !float.IsInfinity(number) && number != float.MinValue)
		{
			return number == float.MaxValue;
		}
		return true;
	}

	public static bool IsInfinityMinMaxNaN(double number)
	{
		if (!double.IsNaN(number) && !double.IsInfinity(number) && number != double.MinValue)
		{
			return number == double.MaxValue;
		}
		return true;
	}

	public static bool AnyInfinityMinMaxNaN(Vector3 vector)
	{
		if (!IsInfinityMinMaxNaN(vector.x) && !IsInfinityMinMaxNaN(vector.y))
		{
			return IsInfinityMinMaxNaN(vector.z);
		}
		return true;
	}

	public static bool IsSquare(float number)
	{
		if (number >= 0f)
		{
			return Mathf.Sqrt(number) % 1f == 0f;
		}
		return false;
	}

	public static float Map(float value, float min1, float max1, float min2, float max2)
	{
		return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
	}

	public static float MapClamp(float value, float min1, float max1, float min2, float max2)
	{
		return Mathf.Clamp(Map(value, min1, max1, min2, max2), Mathf.Min(min2, max2), Mathf.Max(max2, min2));
	}

	public static float SmoothDampNoOvershoot(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
	{
		smoothTime = Mathf.Max(0.0001f, smoothTime);
		float num = 2f / smoothTime;
		float num2 = num * deltaTime;
		float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
		float value = current - target;
		float num4 = maxSpeed * smoothTime;
		value = Mathf.Clamp(value, 0f - num4, num4);
		target = current - value;
		float num5 = (currentVelocity + num * value) * deltaTime;
		currentVelocity = (currentVelocity - num * num5) * num3;
		return target + (value + num5) * num3;
	}

	public static bool IsInRange(this int number, int minimum, int maximum)
	{
		if (number >= minimum)
		{
			return number <= maximum;
		}
		return false;
	}

	public static bool IsInRange(this int number, float minimum, float maximum)
	{
		if ((float)number >= minimum)
		{
			return (float)number <= maximum;
		}
		return false;
	}

	public static bool IsInRange(this int number, double minimum, double maximum)
	{
		if ((double)number >= minimum)
		{
			return (double)number <= maximum;
		}
		return false;
	}

	public static bool IsInRange(this float number, float minimum, float maximum)
	{
		if (number >= minimum)
		{
			return number <= maximum;
		}
		return false;
	}

	public static bool IsInRange(this float number, double minimum, double maximum)
	{
		if ((double)number >= minimum)
		{
			return (double)number <= maximum;
		}
		return false;
	}

	public static bool IsInRange(this double number, double minimum, double maximum)
	{
		if (number >= minimum)
		{
			return number <= maximum;
		}
		return false;
	}

	public static float FloorMod(this float dividend, float divisor)
	{
		if (dividend >= 0f && divisor >= 0f)
		{
			return dividend % divisor;
		}
		return dividend - Mathf.Floor(dividend / divisor) * divisor;
	}

	public static int ToBit(this bool value)
	{
		if (!value)
		{
			return 0;
		}
		return 1;
	}

	public static int ToDir(this bool value)
	{
		if (!value)
		{
			return -1;
		}
		return 1;
	}

	public static float SmoothExponential(float current, float target, float smoothTime, float maxSpeed = float.PositiveInfinity, float delta = -1f)
	{
		if (delta < 0f)
		{
			delta = Time.deltaTime;
		}
		if (delta == 0f)
		{
			return current;
		}
		float num = delta * maxSpeed;
		if (smoothTime == 0f)
		{
			return Mathf.Clamp(target, current - num, current + num);
		}
		float num2 = (target - current) / smoothTime;
		float a = current + num2 * delta;
		if (target > current)
		{
			float b = Mathf.Min(target, current + num);
			return Mathf.Min(a, b);
		}
		float b2 = Mathf.Max(target, current - num);
		return Mathf.Max(a, b2);
	}
}
