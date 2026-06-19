using System.Runtime.CompilerServices;
using Unity.Entities;

public static class ConditionTickTimerUtilities
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ref TickTimer GetOrCreateTickTimer(DynamicBuffer<ConditionTickTimerBuffer> buffer, ConditionID condition)
	{
		for (int i = 0; i < buffer.Length; i++)
		{
			if (buffer[i].condition == condition)
			{
				return ref buffer.ElementAt(i).tickTimer;
			}
		}
		buffer.Add(new ConditionTickTimerBuffer
		{
			condition = condition,
			tickTimer = default(TickTimer)
		});
		return ref buffer.ElementAt(buffer.Length - 1).tickTimer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void RemoveTickTimer(DynamicBuffer<ConditionTickTimerBuffer> buffer, ConditionID condition)
	{
		for (int num = buffer.Length - 1; num >= 0; num--)
		{
			if (buffer[num].condition == condition)
			{
				buffer.RemoveAtSwapBack(num);
			}
		}
	}
}
