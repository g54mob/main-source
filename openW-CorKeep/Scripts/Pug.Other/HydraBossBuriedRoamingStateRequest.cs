using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct HydraBossBuriedRoamingStateRequest : IStateRequester
{
	private const float PLAYER_MIN_DISTANCE_SQ = 1600f;

	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._hydraBossBuriedRoamingStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity) && c._distanceToPlayerGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		HydraBossBuriedRoamingStateCD value = c._hydraBossBuriedRoamingStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		_ = c._distanceToPlayerGroup[entity];
		if (!stateInfo.HasState(StateID.HydraBossBuriedRoaming) && !isInCombatCD.isInCombat && !value.disabled)
		{
			if (c._healthGroup[entity].HasFullHealth)
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.HydraBossBuriedRoaming);
			}
			c._hydraBossBuriedRoamingStateGroup[entity] = value;
		}
	}
}
