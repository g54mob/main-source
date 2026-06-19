using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct SleepStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._sleepStateGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.Sleep))
		{
			return;
		}
		SleepStateCD value = c._sleepStateGroup[entity];
		HealthCD healthCD = (c._healthGroup.HasComponent(entity) ? c._healthGroup[entity] : default(HealthCD));
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		if (!float.IsNaN(value.sleepCooldown) && !isInCombatCD.isInCombat && healthCD.health >= healthCD.maxHealth && (!value.stayAwakeUntilNoVisiblePlayer || !c._distanceToPlayerGroup.TryGetComponent(entity, out var componentData) || !componentData.isVisible))
		{
			value.sleepCooldown -= d._deltaTime;
			if (value.sleepCooldown <= 0f)
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.Sleep);
			}
		}
		else
		{
			value.sleepCooldown = d._rng.NextFloat(value.minSleepCooldown, value.maxSleepCooldown);
		}
		c._sleepStateGroup[entity] = value;
	}
}
