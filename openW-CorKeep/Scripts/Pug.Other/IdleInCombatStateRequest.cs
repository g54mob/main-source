using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct IdleInCombatStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._idleInCombatStateGroup.HasComponent(entity) && c._healthGroup.HasComponent(entity))
		{
			return c._distanceToPlayerGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.IdleInCombat))
		{
			return;
		}
		IdleInCombatStateCD value = c._idleInCombatStateGroup[entity];
		HealthCD healthCD = c._healthGroup[entity];
		DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
		if (healthCD.health < healthCD.maxHealth)
		{
			bool flag = false;
			if ((!value.checkDistanceToPlayerFromSpawnPointInsteadOfSelf || !c._spawnPointGroup.HasComponent(entity) || !c._localTransformGroup.HasComponent(distanceToPlayerCD.closestPlayer)) ? (distanceToPlayerCD.minDistanceSq < value.sqrDistanceToLeaveCombat) : (math.distancesq(c._spawnPointGroup[entity].position, c._localTransformGroup[distanceToPlayerCD.closestPlayer].Position) < value.sqrDistanceToLeaveCombat))
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.IdleInCombat);
			}
		}
		c._idleInCombatStateGroup[entity] = value;
	}
}
