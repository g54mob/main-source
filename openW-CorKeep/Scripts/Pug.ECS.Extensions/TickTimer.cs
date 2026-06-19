using Unity.Mathematics;
using Unity.NetCode;

public struct TickTimer
{
	[GhostField]
	public NetworkTick startTick;

	[GhostField]
	public uint targetTicks;

	[GhostField]
	public NetworkTick stopTick;

	public bool isRunning
	{
		get
		{
			if (startTick.IsValid)
			{
				return !stopTick.IsValid;
			}
			return false;
		}
	}

	public bool HasStarted => startTick.IsValid;

	public TickTimer(uint targetTicks)
	{
		startTick = default(NetworkTick);
		stopTick = default(NetworkTick);
		this.targetTicks = targetTicks;
	}

	public TickTimer(float seconds, uint tickRate)
	{
		startTick = default(NetworkTick);
		stopTick = default(NetworkTick);
		targetTicks = NetworkTimeUtilities.SecondsToTicks(seconds, tickRate);
	}

	public void Start(NetworkTick startTick)
	{
		this.startTick = startTick;
		stopTick = default(NetworkTick);
	}

	public void Start(NetworkTick startTick, uint targetTicks)
	{
		this.startTick = startTick;
		this.targetTicks = targetTicks;
		stopTick = default(NetworkTick);
	}

	public void Start(NetworkTick startTick, float seconds, uint tickRate)
	{
		this.startTick = startTick;
		targetTicks = NetworkTimeUtilities.SecondsToTicks(seconds, tickRate);
		stopTick = default(NetworkTick);
	}

	public void ClearStart()
	{
		startTick = default(NetworkTick);
	}

	public void Stop(NetworkTick stopTick)
	{
		this.stopTick = stopTick;
	}

	public void SetTargetTicks(float seconds, uint tickRate)
	{
		targetTicks = NetworkTimeUtilities.SecondsToTicks(seconds, tickRate);
	}

	public float GetPercentageFinished(NetworkTick currentTick)
	{
		if (!startTick.IsValid)
		{
			return 0f;
		}
		if (stopTick.IsValid)
		{
			return math.clamp((float)stopTick.TicksSince(startTick) / (float)targetTicks, 0f, 1f);
		}
		NetworkTick otherTick = startTick;
		otherTick.Add(targetTicks);
		if (currentTick.IsSameOrNewerThan(otherTick))
		{
			return 1f;
		}
		return (float)currentTick.TicksSince(startTick) / (float)targetTicks;
	}

	public readonly bool IsTimerElapsed(NetworkTick currentTick)
	{
		if (!startTick.IsValid)
		{
			return false;
		}
		NetworkTick otherTick = startTick;
		otherTick.Add(targetTicks);
		if (stopTick.IsValid)
		{
			return stopTick.IsSameOrNewerThan(otherTick);
		}
		return currentTick.IsSameOrNewerThan(otherTick);
	}

	public readonly int GetElapsedTicks(NetworkTick currentTick)
	{
		if (!startTick.IsValid)
		{
			return 0;
		}
		return currentTick.TicksSince(startTick);
	}

	public int GetElapsedTicksWithStop(NetworkTick currentTick)
	{
		bool isValid = startTick.IsValid;
		if (stopTick.IsValid && isValid)
		{
			return stopTick.TicksSince(startTick);
		}
		if (!isValid)
		{
			return (int)targetTicks;
		}
		return currentTick.TicksSince(startTick);
	}

	public readonly float GetElapsedSeconds(NetworkTick currentTick, uint tickRate)
	{
		if (!startTick.IsValid)
		{
			return 0f;
		}
		return (float)currentTick.TicksSince(startTick) / (float)tickRate;
	}

	public float GetElapsedSeconds(NetworkTick currentTick, float tickFraction, uint tickRate)
	{
		return NetworkTimeUtilities.TimeSincePastTickInSeconds(startTick, currentTick, tickFraction, tickRate);
	}

	public float GetElapsedSecondsWithStop(NetworkTick currentTick, uint tickRate)
	{
		if (!startTick.IsValid)
		{
			return 0f;
		}
		if (stopTick.IsValid)
		{
			return (float)stopTick.TicksSince(startTick) / (float)tickRate;
		}
		return (float)currentTick.TicksSince(startTick) / (float)tickRate;
	}

	public readonly float GetElapsedRatio(NetworkTick currentTick)
	{
		return math.clamp((float)GetElapsedTicks(currentTick) / (float)targetTicks, 0f, 1f);
	}

	public readonly float GetInvElapsedRatio(NetworkTick currentTick)
	{
		return 1f - GetElapsedRatio(currentTick);
	}

	public readonly float GetRemainingSeconds(in NetworkTick currentTick, uint tickRate)
	{
		int ticks = (int)targetTicks;
		if (HasStarted)
		{
			ticks = (int)targetTicks - currentTick.TicksSince(startTick);
		}
		return NetworkTimeUtilities.TicksToSeconds(ticks, tickRate);
	}
}
