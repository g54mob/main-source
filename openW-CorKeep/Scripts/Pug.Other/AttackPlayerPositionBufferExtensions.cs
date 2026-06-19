using Unity.Collections;
using Unity.Mathematics;
using Unity.NetCode;

public static class AttackPlayerPositionBufferExtensions
{
	public static float3 GetPositionAtTick(this NativeArray<AttackPlayerPositionBuffer> buffer, NetworkTick tick, float3 defaultPosition = default(float3))
	{
		for (int num = buffer.Length - 1; num >= 0; num--)
		{
			if (buffer[num].tick.IsSameOrOlderThan(tick))
			{
				return buffer[num].position;
			}
		}
		if (buffer.Length > 0)
		{
			return buffer[0].position;
		}
		return defaultPosition;
	}

	public static bool TryGetPositionAtTick(this NativeArray<AttackPlayerPositionBuffer> buffer, NetworkTick tick, out float3 outPosition, out bool isDead)
	{
		outPosition = default(float3);
		for (int num = buffer.Length - 1; num >= 0; num--)
		{
			if (buffer[num].tick.IsSameOrOlderThan(tick))
			{
				outPosition = buffer[num].position;
				isDead = buffer[num].dead;
				if (num + 1 >= buffer.Length)
				{
					return true;
				}
				NetworkTick tick2 = buffer[num].tick;
				float tickFraction = buffer[num].tickFraction;
				NetworkTick tick3 = buffer[num + 1].tick;
				float tickFraction2 = buffer[num + 1].tickFraction;
				float3 start = outPosition;
				float3 position = buffer[num + 1].position;
				float num2 = (float)tick3.TicksSince(tick2) + (1f - tickFraction) - (1f - tickFraction2);
				float t = ((float)tick.TicksSince(tick2) + (1f - tickFraction)) / num2;
				outPosition = math.lerp(start, position, t);
				return true;
			}
		}
		if (buffer.Length > 0)
		{
			outPosition = buffer[0].position;
			isDead = buffer[0].dead;
			return true;
		}
		isDead = false;
		return false;
	}
}
