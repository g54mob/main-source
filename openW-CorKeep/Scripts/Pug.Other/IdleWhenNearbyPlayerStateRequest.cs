using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct IdleWhenNearbyPlayerStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._idleNearbyPlayerStateGroup.HasComponent(entity))
		{
			return c._distanceToPlayerGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.IdleWhenNearbyPlayer))
		{
			IdleWhenNearbyPlayerStateCD value = c._idleNearbyPlayerStateGroup[entity];
			DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
			if (distanceToPlayerCD.minDistanceSq < value.sqDistanceToStartIdle)
			{
				value.internalState = 0;
				value.currentNearPlayer = distanceToPlayerCD.closestPlayer;
				value.lookAtPlayerTimer.Stop();
				stateInfo.EnterState(StateID.IdleWhenNearbyPlayer);
			}
			c._idleNearbyPlayerStateGroup[entity] = value;
		}
	}
}
