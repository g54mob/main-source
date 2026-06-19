using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.NetCode;

public struct MoveToPredictedByCombatOrInventoryInteractionCD : IComponentData, IQueryTypeParameter
{
	public NetworkTick lastInteractionTick;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetLastInteractionTick(NetworkTick currentTick)
	{
		if (!lastInteractionTick.IsValid || currentTick.IsNewerThan(lastInteractionTick))
		{
			lastInteractionTick = currentTick;
		}
	}
}
