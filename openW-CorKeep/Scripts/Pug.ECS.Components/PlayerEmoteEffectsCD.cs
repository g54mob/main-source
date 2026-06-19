using Unity.Entities;
using Unity.NetCode;

public struct PlayerEmoteEffectsCD : IComponentData, IQueryTypeParameter
{
	public NetworkTick thisIsGoingToTakeAWhileLastDamageTick;

	public int thisIsGoingToTakeAWhileHitsNeededToDestroy;
}
