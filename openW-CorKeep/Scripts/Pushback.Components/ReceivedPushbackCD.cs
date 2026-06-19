using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

public struct ReceivedPushbackCD : IComponentData, IQueryTypeParameter
{
	public const float PushbackTime = 0.1f;

	[GhostField]
	public bool enabled;

	[GhostField]
	public float2 pushback;

	[GhostField]
	public float3 startPosition;

	[GhostField]
	public NetworkTick pushbackStartTick;

	public static void TryAddPushback(Entity targetEntity, float2 pushback, float3 startPosition, NetworkTick currentTick, uint tickRate, ComponentLookup<ImmuneToPushBackCD> immuneToPushbackLookup, ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup)
	{
		if (!immuneToPushbackLookup.HasComponent(targetEntity))
		{
			if (!receivedPushbackLookup.HasComponent(targetEntity))
			{
				Debug.LogError("Attempting to add pushback to entity without ReceivedPushbackCD component");
			}
			else
			{
				receivedPushbackLookup.GetRefRW(targetEntity).ValueRW.AddPushback(pushback, currentTick, tickRate, startPosition);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddPushback(float2 newPushback, NetworkTick currentTick, uint tickRate, float3 newStartPosition = default(float3))
	{
		if (math.lengthsq(newPushback) != 0f && currentTick.IsValid)
		{
			if (!pushbackStartTick.IsValid || currentTick.TicksSince(pushbackStartTick) >= NetworkTimeUtilities.SecondsToTicks(0.1f, tickRate))
			{
				pushback = newPushback;
				startPosition = newStartPosition;
				pushbackStartTick = currentTick;
				enabled = true;
				return;
			}
			int num = currentTick.TicksSince(pushbackStartTick);
			uint num2 = NetworkTimeUtilities.SecondsToTicks(0.1f, tickRate);
			float targetPushbackDistanceAlpha = GetTargetPushbackDistanceAlpha(math.clamp((float)num / (float)num2, 0f, 1f));
			float num3 = 1f - targetPushbackDistanceAlpha;
			float num4 = math.max(math.length(newPushback), math.length(num3 * pushback));
			pushback = num4 * math.normalizesafe(num3 * pushback + newPushback);
			startPosition = newStartPosition;
			pushbackStartTick = currentTick;
			enabled = true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float GetTargetPushbackDistanceAlpha(float pushbackTimeNormalized)
	{
		return math.sqrt(pushbackTimeNormalized);
	}

	public void ClearPushback()
	{
		pushback = float2.zero;
		enabled = false;
	}
}
