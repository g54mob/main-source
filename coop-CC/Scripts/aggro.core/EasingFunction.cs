using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

public static class EasingFunction
{
	public delegate float Function(float s, float e, float v);

	public enum Ease
	{
		EaseInQuad = 0,
		EaseOutQuad = 1,
		EaseInOutQuad = 2,
		EaseInCubic = 3,
		EaseOutCubic = 4,
		EaseInOutCubic = 5,
		EaseInQuart = 6,
		EaseOutQuart = 7,
		EaseInOutQuart = 8,
		EaseInQuint = 9,
		EaseOutQuint = 10,
		EaseInOutQuint = 11,
		EaseInSine = 12,
		EaseOutSine = 13,
		EaseInOutSine = 14,
		EaseInExpo = 15,
		EaseOutExpo = 16,
		EaseInOutExpo = 17,
		EaseInCirc = 18,
		EaseOutCirc = 19,
		EaseInOutCirc = 20,
		Linear = 21,
		Spring = 22,
		EaseInBounce = 23,
		EaseOutBounce = 24,
		EaseInOutBounce = 25,
		EaseInBack = 26,
		EaseOutBack = 27,
		EaseInOutBack = 28,
		EaseInElastic = 29,
		EaseOutElastic = 30,
		EaseInOutElastic = 31
	}

	private const float NATURAL_LOG_OF_2 = 0.6931472f;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Linear(float start, float end, float value)
	{
		return math.lerp(start, end, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Spring(float start, float end, float value)
	{
		value = math.saturate(value);
		value = (math.sin(value * MathF.PI * (0.2f + 2.5f * value * value * value)) * math.pow(1f - value, 2.2f) + value) * (1f + 1.2f * (1f - value));
		return start + (end - start) * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInQuad(float start, float end, float value)
	{
		end -= start;
		return end * value * value + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutQuad(float start, float end, float value)
	{
		end -= start;
		return (0f - end) * value * (value - 2f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutQuad(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end * 0.5f * value * value + start;
		}
		value -= 1f;
		return (0f - end) * 0.5f * (value * (value - 2f) - 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInCubic(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutCubic(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * (value * value * value + 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutCubic(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end * 0.5f * value * value * value + start;
		}
		value -= 2f;
		return end * 0.5f * (value * value * value + 2f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInQuart(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value * value + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutQuart(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return (0f - end) * (value * value * value * value - 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutQuart(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end * 0.5f * value * value * value * value + start;
		}
		value -= 2f;
		return (0f - end) * 0.5f * (value * value * value * value - 2f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInQuint(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value * value * value + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutQuint(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * (value * value * value * value * value + 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutQuint(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end * 0.5f * value * value * value * value * value + start;
		}
		value -= 2f;
		return end * 0.5f * (value * value * value * value * value + 2f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInSine(float start, float end, float value)
	{
		end -= start;
		return (0f - end) * math.cos(value * (MathF.PI / 2f)) + end + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutSine(float start, float end, float value)
	{
		end -= start;
		return end * math.sin(value * (MathF.PI / 2f)) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutSine(float start, float end, float value)
	{
		end -= start;
		return (0f - end) * 0.5f * (math.cos(MathF.PI * value) - 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInExpo(float start, float end, float value)
	{
		end -= start;
		return end * math.pow(2f, 10f * (value - 1f)) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutExpo(float start, float end, float value)
	{
		end -= start;
		return end * (0f - math.pow(2f, -10f * value) + 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutExpo(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end * 0.5f * math.pow(2f, 10f * (value - 1f)) + start;
		}
		value -= 1f;
		return end * 0.5f * (0f - math.pow(2f, -10f * value) + 2f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInCirc(float start, float end, float value)
	{
		end -= start;
		return (0f - end) * (math.sqrt(1f - value * value) - 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutCirc(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * math.sqrt(1f - value * value) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutCirc(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return (0f - end) * 0.5f * (math.sqrt(1f - value * value) - 1f) + start;
		}
		value -= 2f;
		return end * 0.5f * (math.sqrt(1f - value * value) + 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInBounce(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		return end - EaseOutBounce(0f, end, num - value) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutBounce(float start, float end, float value)
	{
		value /= 1f;
		end -= start;
		if (value < 0.36363637f)
		{
			return end * (7.5625f * value * value) + start;
		}
		if (value < 0.72727275f)
		{
			value -= 0.54545456f;
			return end * (7.5625f * value * value + 0.75f) + start;
		}
		if ((double)value < 0.9090909090909091)
		{
			value -= 0.8181818f;
			return end * (7.5625f * value * value + 0.9375f) + start;
		}
		value -= 21f / 22f;
		return end * (7.5625f * value * value + 63f / 64f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutBounce(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		if (value < num * 0.5f)
		{
			return EaseInBounce(0f, end, value * 2f) * 0.5f + start;
		}
		return EaseOutBounce(0f, end, value * 2f - num) * 0.5f + end * 0.5f + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInBack(float start, float end, float value)
	{
		end -= start;
		value /= 1f;
		float num = 1.70158f;
		return end * value * value * ((num + 1f) * value - num) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutBack(float start, float end, float value)
	{
		float num = 1.70158f;
		end -= start;
		value -= 1f;
		return end * (value * value * ((num + 1f) * value + num) + 1f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutBack(float start, float end, float value)
	{
		float num = 1.70158f;
		end -= start;
		value /= 0.5f;
		if (value < 1f)
		{
			num *= 1.525f;
			return end * 0.5f * (value * value * ((num + 1f) * value - num)) + start;
		}
		value -= 2f;
		num *= 1.525f;
		return end * 0.5f * (value * value * ((num + 1f) * value + num) + 2f) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInElastic(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (value == 0f)
		{
			return start;
		}
		if ((value /= num) == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < math.abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / (MathF.PI * 2f) * math.asin(end / num3);
		}
		return 0f - num3 * math.pow(2f, 10f * (value -= 1f)) * math.sin((value * num - num4) * (MathF.PI * 2f) / num2) + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutElastic(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (value == 0f)
		{
			return start;
		}
		if ((value /= num) == 1f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < math.abs(end))
		{
			num3 = end;
			num4 = num2 * 0.25f;
		}
		else
		{
			num4 = num2 / (MathF.PI * 2f) * math.asin(end / num3);
		}
		return num3 * math.pow(2f, -10f * value) * math.sin((value * num - num4) * (MathF.PI * 2f) / num2) + end + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutElastic(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		if (value == 0f)
		{
			return start;
		}
		if ((value /= num * 0.5f) == 2f)
		{
			return start + end;
		}
		float num4;
		if (num3 == 0f || num3 < math.abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / (MathF.PI * 2f) * math.asin(end / num3);
		}
		if (value < 1f)
		{
			return -0.5f * (num3 * math.pow(2f, 10f * (value -= 1f)) * math.sin((value * num - num4) * (MathF.PI * 2f) / num2)) + start;
		}
		return num3 * math.pow(2f, -10f * (value -= 1f)) * math.sin((value * num - num4) * (MathF.PI * 2f) / num2) * 0.5f + end + start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float LinearD(float start, float end, float value)
	{
		return end - start;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInQuadD(float start, float end, float value)
	{
		return 2f * (end - start) * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutQuadD(float start, float end, float value)
	{
		end -= start;
		return (0f - end) * value - end * (value - 2f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutQuadD(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end * value;
		}
		value -= 1f;
		return end * (1f - value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInCubicD(float start, float end, float value)
	{
		return 3f * (end - start) * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutCubicD(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return 3f * end * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutCubicD(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return 1.5f * end * value * value;
		}
		value -= 2f;
		return 1.5f * end * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInQuartD(float start, float end, float value)
	{
		return 4f * (end - start) * value * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutQuartD(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return -4f * end * value * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutQuartD(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return 2f * end * value * value * value;
		}
		value -= 2f;
		return -2f * end * value * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInQuintD(float start, float end, float value)
	{
		return 5f * (end - start) * value * value * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutQuintD(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return 5f * end * value * value * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutQuintD(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return 2.5f * end * value * value * value * value;
		}
		value -= 2f;
		return 2.5f * end * value * value * value * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInSineD(float start, float end, float value)
	{
		return (end - start) * 0.5f * MathF.PI * math.sin(MathF.PI / 2f * value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutSineD(float start, float end, float value)
	{
		end -= start;
		return MathF.PI / 2f * end * math.cos(value * (MathF.PI / 2f));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutSineD(float start, float end, float value)
	{
		end -= start;
		return end * 0.5f * MathF.PI * math.sin(MathF.PI * value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInExpoD(float start, float end, float value)
	{
		return 6.931472f * (end - start) * math.pow(2f, 10f * (value - 1f));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutExpoD(float start, float end, float value)
	{
		end -= start;
		return 3.465736f * end * math.pow(2f, 1f - 10f * value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutExpoD(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return 3.465736f * end * math.pow(2f, 10f * (value - 1f));
		}
		value -= 1f;
		return 3.465736f * end / math.pow(2f, 10f * value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInCircD(float start, float end, float value)
	{
		return (end - start) * value / math.sqrt(1f - value * value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutCircD(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return (0f - end) * value / math.sqrt(1f - value * value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutCircD(float start, float end, float value)
	{
		value /= 0.5f;
		end -= start;
		if (value < 1f)
		{
			return end * value / (2f * math.sqrt(1f - value * value));
		}
		value -= 2f;
		return (0f - end) * value / (2f * math.sqrt(1f - value * value));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInBounceD(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		return EaseOutBounceD(0f, end, num - value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutBounceD(float start, float end, float value)
	{
		value /= 1f;
		end -= start;
		if (value < 0.36363637f)
		{
			return 2f * end * 7.5625f * value;
		}
		if (value < 0.72727275f)
		{
			value -= 0.54545456f;
			return 2f * end * 7.5625f * value;
		}
		if ((double)value < 0.9090909090909091)
		{
			value -= 0.8181818f;
			return 2f * end * 7.5625f * value;
		}
		value -= 21f / 22f;
		return 2f * end * 7.5625f * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutBounceD(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		if (value < num * 0.5f)
		{
			return EaseInBounceD(0f, end, value * 2f) * 0.5f;
		}
		return EaseOutBounceD(0f, end, value * 2f - num) * 0.5f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInBackD(float start, float end, float value)
	{
		float num = 1.70158f;
		return 3f * (num + 1f) * (end - start) * value * value - 2f * num * (end - start) * value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutBackD(float start, float end, float value)
	{
		float num = 1.70158f;
		end -= start;
		value -= 1f;
		return end * ((num + 1f) * value * value + 2f * value * ((num + 1f) * value + num));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutBackD(float start, float end, float value)
	{
		float num = 1.70158f;
		end -= start;
		value /= 0.5f;
		if (value < 1f)
		{
			num *= 1.525f;
			return 0.5f * end * (num + 1f) * value * value + end * value * ((num + 1f) * value - num);
		}
		value -= 2f;
		num *= 1.525f;
		return 0.5f * end * ((num + 1f) * value * value + 2f * value * ((num + 1f) * value + num));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInElasticD(float start, float end, float value)
	{
		return EaseOutElasticD(start, end, 1f - value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseOutElasticD(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		float num4;
		if (num3 == 0f || num3 < math.abs(end))
		{
			num3 = end;
			num4 = num2 * 0.25f;
		}
		else
		{
			num4 = num2 / (MathF.PI * 2f) * math.asin(end / num3);
		}
		return num3 * MathF.PI * num * math.pow(2f, 1f - 10f * value) * math.cos(MathF.PI * 2f * (num * value - num4) / num2) / num2 - 3.465736f * num3 * math.pow(2f, 1f - 10f * value) * math.sin(MathF.PI * 2f * (num * value - num4) / num2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EaseInOutElasticD(float start, float end, float value)
	{
		end -= start;
		float num = 1f;
		float num2 = num * 0.3f;
		float num3 = 0f;
		float num4;
		if (num3 == 0f || num3 < math.abs(end))
		{
			num3 = end;
			num4 = num2 / 4f;
		}
		else
		{
			num4 = num2 / (MathF.PI * 2f) * math.asin(end / num3);
		}
		if (value < 1f)
		{
			value -= 1f;
			return -3.465736f * num3 * math.pow(2f, 10f * value) * math.sin(MathF.PI * 2f * (num * value - 2f) / num2) - num3 * MathF.PI * num * math.pow(2f, 10f * value) * math.cos(MathF.PI * 2f * (num * value - num4) / num2) / num2;
		}
		value -= 1f;
		return num3 * MathF.PI * num * math.cos(MathF.PI * 2f * (num * value - num4) / num2) / (num2 * math.pow(2f, 10f * value)) - 3.465736f * num3 * math.sin(MathF.PI * 2f * (num * value - num4) / num2) / math.pow(2f, 10f * value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float SpringD(float start, float end, float value)
	{
		value = math.saturate(value);
		end -= start;
		return end * (6f * (1f - value) / 5f + 1f) * (-2.2f * math.pow(1f - value, 1.2f) * math.sin(MathF.PI * value * (2.5f * value * value * value + 0.2f)) + math.pow(1f - value, 2.2f) * (MathF.PI * (2.5f * value * value * value + 0.2f) + 23.561945f * value * value * value) * math.cos(MathF.PI * value * (2.5f * value * value * value + 0.2f)) + 1f) - 6f * end * (math.pow(1f - value, 2.2f) * math.sin(MathF.PI * value * (2.5f * value * value * value + 0.2f)) + value / 5f);
	}

	public static Function GetEasingFunction(Ease ease)
	{
		return ease switch
		{
			Ease.EaseInQuad => EaseInQuad, 
			Ease.EaseOutQuad => EaseOutQuad, 
			Ease.EaseInOutQuad => EaseInOutQuad, 
			Ease.EaseInCubic => EaseInCubic, 
			Ease.EaseOutCubic => EaseOutCubic, 
			Ease.EaseInOutCubic => EaseInOutCubic, 
			Ease.EaseInQuart => EaseInQuart, 
			Ease.EaseOutQuart => EaseOutQuart, 
			Ease.EaseInOutQuart => EaseInOutQuart, 
			Ease.EaseInQuint => EaseInQuint, 
			Ease.EaseOutQuint => EaseOutQuint, 
			Ease.EaseInOutQuint => EaseInOutQuint, 
			Ease.EaseInSine => EaseInSine, 
			Ease.EaseOutSine => EaseOutSine, 
			Ease.EaseInOutSine => EaseInOutSine, 
			Ease.EaseInExpo => EaseInExpo, 
			Ease.EaseOutExpo => EaseOutExpo, 
			Ease.EaseInOutExpo => EaseInOutExpo, 
			Ease.EaseInCirc => EaseInCirc, 
			Ease.EaseOutCirc => EaseOutCirc, 
			Ease.EaseInOutCirc => EaseInOutCirc, 
			Ease.Linear => Linear, 
			Ease.Spring => Spring, 
			Ease.EaseInBounce => EaseInBounce, 
			Ease.EaseOutBounce => EaseOutBounce, 
			Ease.EaseInOutBounce => EaseInOutBounce, 
			Ease.EaseInBack => EaseInBack, 
			Ease.EaseOutBack => EaseOutBack, 
			Ease.EaseInOutBack => EaseInOutBack, 
			Ease.EaseInElastic => EaseInElastic, 
			Ease.EaseOutElastic => EaseOutElastic, 
			Ease.EaseInOutElastic => EaseInOutElastic, 
			_ => null, 
		};
	}

	public static Function GetEasingFunctionDerivative(Ease ease)
	{
		return ease switch
		{
			Ease.EaseInQuad => EaseInQuadD, 
			Ease.EaseOutQuad => EaseOutQuadD, 
			Ease.EaseInOutQuad => EaseInOutQuadD, 
			Ease.EaseInCubic => EaseInCubicD, 
			Ease.EaseOutCubic => EaseOutCubicD, 
			Ease.EaseInOutCubic => EaseInOutCubicD, 
			Ease.EaseInQuart => EaseInQuartD, 
			Ease.EaseOutQuart => EaseOutQuartD, 
			Ease.EaseInOutQuart => EaseInOutQuartD, 
			Ease.EaseInQuint => EaseInQuintD, 
			Ease.EaseOutQuint => EaseOutQuintD, 
			Ease.EaseInOutQuint => EaseInOutQuintD, 
			Ease.EaseInSine => EaseInSineD, 
			Ease.EaseOutSine => EaseOutSineD, 
			Ease.EaseInOutSine => EaseInOutSineD, 
			Ease.EaseInExpo => EaseInExpoD, 
			Ease.EaseOutExpo => EaseOutExpoD, 
			Ease.EaseInOutExpo => EaseInOutExpoD, 
			Ease.EaseInCirc => EaseInCircD, 
			Ease.EaseOutCirc => EaseOutCircD, 
			Ease.EaseInOutCirc => EaseInOutCircD, 
			Ease.Linear => LinearD, 
			Ease.Spring => SpringD, 
			Ease.EaseInBounce => EaseInBounceD, 
			Ease.EaseOutBounce => EaseOutBounceD, 
			Ease.EaseInOutBounce => EaseInOutBounceD, 
			Ease.EaseInBack => EaseInBackD, 
			Ease.EaseOutBack => EaseOutBackD, 
			Ease.EaseInOutBack => EaseInOutBackD, 
			Ease.EaseInElastic => EaseInElasticD, 
			Ease.EaseOutElastic => EaseOutElasticD, 
			Ease.EaseInOutElastic => EaseInOutElasticD, 
			_ => null, 
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Evaluate(Ease ease, float start, float end, float value)
	{
		return ease switch
		{
			Ease.EaseInQuad => EaseInQuad(start, end, value), 
			Ease.EaseOutQuad => EaseOutQuad(start, end, value), 
			Ease.EaseInOutQuad => EaseInOutQuad(start, end, value), 
			Ease.EaseInCubic => EaseInCubic(start, end, value), 
			Ease.EaseOutCubic => EaseOutCubic(start, end, value), 
			Ease.EaseInOutCubic => EaseInOutCubic(start, end, value), 
			Ease.EaseInQuart => EaseInQuart(start, end, value), 
			Ease.EaseOutQuart => EaseOutQuart(start, end, value), 
			Ease.EaseInOutQuart => EaseInOutQuart(start, end, value), 
			Ease.EaseInQuint => EaseInQuint(start, end, value), 
			Ease.EaseOutQuint => EaseOutQuint(start, end, value), 
			Ease.EaseInOutQuint => EaseInOutQuint(start, end, value), 
			Ease.EaseInSine => EaseInSine(start, end, value), 
			Ease.EaseOutSine => EaseOutSine(start, end, value), 
			Ease.EaseInOutSine => EaseInOutSine(start, end, value), 
			Ease.EaseInExpo => EaseInExpo(start, end, value), 
			Ease.EaseOutExpo => EaseOutExpo(start, end, value), 
			Ease.EaseInOutExpo => EaseInOutExpo(start, end, value), 
			Ease.EaseInCirc => EaseInCirc(start, end, value), 
			Ease.EaseOutCirc => EaseOutCirc(start, end, value), 
			Ease.EaseInOutCirc => EaseInOutCirc(start, end, value), 
			Ease.Linear => Linear(start, end, value), 
			Ease.Spring => Spring(start, end, value), 
			Ease.EaseInBounce => EaseInBounce(start, end, value), 
			Ease.EaseOutBounce => EaseOutBounce(start, end, value), 
			Ease.EaseInOutBounce => EaseInOutBounce(start, end, value), 
			Ease.EaseInBack => EaseInBack(start, end, value), 
			Ease.EaseOutBack => EaseOutBack(start, end, value), 
			Ease.EaseInOutBack => EaseInOutBack(start, end, value), 
			Ease.EaseInElastic => EaseInElastic(start, end, value), 
			Ease.EaseOutElastic => EaseOutElastic(start, end, value), 
			Ease.EaseInOutElastic => EaseInOutElastic(start, end, value), 
			_ => -1f, 
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Evaluate(Ease ease, float value)
	{
		return Evaluate(ease, 0f, 1f, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EvaluateD(Ease ease, float start, float end, float value)
	{
		return ease switch
		{
			Ease.EaseInQuad => EaseInQuadD(start, end, value), 
			Ease.EaseOutQuad => EaseInQuadD(start, end, value), 
			Ease.EaseInOutQuad => EaseInQuadD(start, end, value), 
			Ease.EaseInCubic => EaseInQuadD(start, end, value), 
			Ease.EaseOutCubic => EaseInQuadD(start, end, value), 
			Ease.EaseInOutCubic => EaseInQuadD(start, end, value), 
			Ease.EaseInQuart => EaseInQuadD(start, end, value), 
			Ease.EaseOutQuart => EaseInQuadD(start, end, value), 
			Ease.EaseInOutQuart => EaseInQuadD(start, end, value), 
			Ease.EaseInQuint => EaseInQuadD(start, end, value), 
			Ease.EaseOutQuint => EaseInQuadD(start, end, value), 
			Ease.EaseInOutQuint => EaseInQuadD(start, end, value), 
			Ease.EaseInSine => EaseInQuadD(start, end, value), 
			Ease.EaseOutSine => EaseInQuadD(start, end, value), 
			Ease.EaseInOutSine => EaseInQuadD(start, end, value), 
			Ease.EaseInExpo => EaseInQuadD(start, end, value), 
			Ease.EaseOutExpo => EaseInQuadD(start, end, value), 
			Ease.EaseInOutExpo => EaseInQuadD(start, end, value), 
			Ease.EaseInCirc => EaseInQuadD(start, end, value), 
			Ease.EaseOutCirc => EaseInQuadD(start, end, value), 
			Ease.EaseInOutCirc => EaseInQuadD(start, end, value), 
			Ease.Linear => EaseInQuadD(start, end, value), 
			Ease.Spring => EaseInQuadD(start, end, value), 
			Ease.EaseInBounce => EaseInQuadD(start, end, value), 
			Ease.EaseOutBounce => EaseInQuadD(start, end, value), 
			Ease.EaseInOutBounce => EaseInQuadD(start, end, value), 
			Ease.EaseInBack => EaseInQuadD(start, end, value), 
			Ease.EaseOutBack => EaseInQuadD(start, end, value), 
			Ease.EaseInOutBack => EaseInQuadD(start, end, value), 
			Ease.EaseInElastic => EaseInQuadD(start, end, value), 
			Ease.EaseOutElastic => EaseInQuadD(start, end, value), 
			Ease.EaseInOutElastic => EaseInQuadD(start, end, value), 
			_ => -1f, 
		};
	}
}
