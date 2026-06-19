using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.NetCode;

public static class NetworkTimeUtilities
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint SecondsToTicks(float seconds, uint tickRate)
	{
		return (uint)math.round((float)tickRate * seconds);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static NetworkTick SecondsToTick(float seconds, NetworkTick baseTick, uint tickRate)
	{
		NetworkTick result = baseTick;
		uint delta = (uint)math.round((float)tickRate * seconds);
		result.Add(delta);
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TicksToSeconds(uint ticks, uint tickRate)
	{
		return (float)ticks / (float)tickRate;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TicksToSeconds(int ticks, uint tickRate)
	{
		return (float)ticks / (float)tickRate;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TicksToSeconds(uint ticks, float secondsPerTick)
	{
		return (float)ticks * secondsPerTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TicksToSeconds(int ticks, float secondsPerTick)
	{
		return (float)ticks * secondsPerTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TimeBetweenTicksInSeconds(NetworkTick currentTick, NetworkTick futureTick, uint tickRate, float invalidValue = 0f)
	{
		if (!currentTick.IsValid || !futureTick.IsValid)
		{
			return invalidValue;
		}
		return TicksToSeconds(futureTick.TicksSince(currentTick), tickRate);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TimeToFutureTickInSeconds(NetworkTick currentTick, float currentTickFraction, NetworkTick futureTick, uint tickRate, float invalidValue = 0f)
	{
		if (!currentTick.IsValid || !futureTick.IsValid)
		{
			return invalidValue;
		}
		return ((float)futureTick.TicksSince(currentTick) + 1f - currentTickFraction) / (float)tickRate;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TimeSincePastTickInSeconds(NetworkTick pastTick, NetworkTick currentTick, float currentTickFraction, uint tickRate, float invalidValue = 0f)
	{
		if (!pastTick.IsValid || !currentTick.IsValid)
		{
			return invalidValue;
		}
		return ((float)currentTick.TicksSince(pastTick) - 1f + currentTickFraction) / (float)tickRate;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsSpawnTickForBeginECBCreatedGhost(in GhostInstance ghostInstance, NetworkTick currentTick, bool isServer)
	{
		NetworkTick a = ghostInstance.spawnTick;
		if (!a.IsValid)
		{
			return true;
		}
		if (!isServer)
		{
			a.Increment();
		}
		return a == currentTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static NetworkTick GetSpawnTickForBeginECBCreatedGhost(in GhostInstance ghostInstance, bool isServer)
	{
		NetworkTick spawnTick = ghostInstance.spawnTick;
		if (!spawnTick.IsValid)
		{
			return spawnTick;
		}
		if (!isServer)
		{
			spawnTick.Increment();
		}
		return spawnTick;
	}
}
