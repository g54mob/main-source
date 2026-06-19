using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

public struct Timer : IComparable<Timer>
{
	public int raw;

	private const int FRAME_INCREMENT = 100;

	public Timer(int frames)
	{
		raw = frames * 100;
	}

	public Timer(float duration)
		: this(TimeUtil.FramesForTime(duration))
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetTimer(int frames)
	{
		raw = frames * 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetTimerIfGreater(int frames)
	{
		raw = math.max(frames * 100, raw);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetTimerIfLess(int frames)
	{
		raw = math.max(math.min(frames * 100, raw), 0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetTimerIfLess(float duration)
	{
		SetTimerIfLess(TimeUtil.FramesForTime(duration));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddToTimer(int frames)
	{
		raw += 100 * frames;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddToTimer(float duration)
	{
		AddToTimer(TimeUtil.FramesForTime(duration));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetTimer(float duration)
	{
		SetTimer(TimeUtil.FramesForTime(duration));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetTimerIfGreater(float duration)
	{
		SetTimerIfGreater(TimeUtil.FramesForTime(duration));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void DecrementTimer(int speedPercentage = 0)
	{
		raw -= 100 + speedPercentage;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void IncrementTimer(int speedPercentage = 0)
	{
		raw += 100 + speedPercentage;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool IsFinished()
	{
		return raw <= 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly float GetSecondsRemaining(int speedPercentage = 0)
	{
		return (float)GetFramesRemaining(speedPercentage) * (1f / 60f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int GetFramesRemaining(int speedPercentage = 0)
	{
		if (raw <= 0)
		{
			return 0;
		}
		int num = math.max(100 + speedPercentage, 0);
		if (num == 0)
		{
			return int.MaxValue;
		}
		return raw / num + ((raw % num != 0) ? 1 : 0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly float GetTotalSeconds()
	{
		return (float)((double)math.max(raw, 0) / 100.0 * (1.0 / 60.0));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int GetTotalFrames()
	{
		return raw / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Clear()
	{
		raw = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Timer Max(Timer timer1, Timer timer2)
	{
		return new Timer
		{
			raw = math.max(timer1.raw, timer2.raw)
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Timer Min(Timer timer1, Timer timer2)
	{
		return new Timer
		{
			raw = math.min(timer1.raw, timer2.raw)
		};
	}

	public int CompareTo(Timer other)
	{
		return raw.CompareTo(other.raw);
	}
}
