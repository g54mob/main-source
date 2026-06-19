using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public static class PathFindUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GetDirection(in PathFindCD pathFindCD, DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer, float2 currentPos, out float2 direction)
	{
		direction = default(float2);
		if (pathFindCD.pathValidTime < 0f)
		{
			return false;
		}
		float num = float.MaxValue;
		PathFindNodeBuffer pathFindNodeBuffer2 = pathFindNodeBuffer[0];
		for (int i = 1; i < pathFindNodeBuffer.Length; i++)
		{
			PathFindNodeBuffer pathFindNodeBuffer3 = pathFindNodeBuffer2;
			pathFindNodeBuffer2 = pathFindNodeBuffer[i];
			float2 x = pathFindNodeBuffer2.position - currentPos;
			float num2 = math.lengthsq(x);
			if (!(num2 >= num))
			{
				float2 float5 = math.normalizesafe(pathFindNodeBuffer2.position - pathFindNodeBuffer3.position);
				float2 y = math.normalizesafe(x);
				if (!(math.dot(float5, y) <= 0f))
				{
					direction = float5;
					num = num2;
				}
			}
		}
		return num < float.MaxValue;
	}

	public static int GetNodesForTargetMovementSettings(float agentMaximumMovementSpeed, float dampeningFactor, int tickRate)
	{
		float num = 1f / (float)tickRate;
		if (dampeningFactor == 0f)
		{
			Debug.LogError("Dampening factor is 0, this will cause possible infinite velocity which we cannot accommodate for pathfinding");
			dampeningFactor = 1f;
		}
		float num2 = agentMaximumMovementSpeed * (1f - dampeningFactor * num) / dampeningFactor * 0.3f;
		int num3 = 1;
		float num4 = math.sqrt(2f);
		float num5 = num4 - (float)num3;
		float num6 = num4 * 0.5f;
		int num7 = 3;
		for (num2 -= num6; num2 > 0f; num2 -= num5)
		{
			num7++;
			num2 -= (float)num3;
			if (num2 <= 0f)
			{
				break;
			}
			num7++;
		}
		if (num7 > 5)
		{
			Debug.LogError($"Pathfinding node count exceeded maximum node count of {5}, " + "this is likely due to a very high movement speed or low dampening factor");
		}
		return math.clamp(num7, 3, 5);
	}
}
