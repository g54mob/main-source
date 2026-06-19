using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.NetCode;

public static class PlayerRecentAttackersBufferUtilities
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasRecentlyBeenAttackedByEntity(this DynamicBuffer<PlayerRecentAttackersBuffer> buffer, Entity entity, NetworkTick currentTick, uint tickRate)
	{
		for (int i = 0; i < buffer.Length; i++)
		{
			if (!(buffer[i].attacker != entity))
			{
				NetworkTick tick = buffer[i].Tick;
				if (tick.IsValid && currentTick.TicksSince(tick) < tickRate)
				{
					return true;
				}
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void AddAttacker(this DynamicBuffer<PlayerRecentAttackersBuffer> buffer, ref PlayerRecentAttackersBufferPointerCD playerRecentAttackersBufferPointerCD, Entity attacker, NetworkTick currentTick, uint tickRate)
	{
		NetworkTick tickForNextOverridenElement = buffer.GetTickForNextOverridenElement(in playerRecentAttackersBufferPointerCD);
		if (tickForNextOverridenElement.IsValid && currentTick.TicksSince(tickForNextOverridenElement) < tickRate)
		{
			buffer.ResizePreserveOrder(in playerRecentAttackersBufferPointerCD, buffer.Capacity * 2);
		}
		buffer.AddToRingBuffer(ref playerRecentAttackersBufferPointerCD, new PlayerRecentAttackersBuffer
		{
			Tick = currentTick,
			attacker = attacker
		});
	}
}
