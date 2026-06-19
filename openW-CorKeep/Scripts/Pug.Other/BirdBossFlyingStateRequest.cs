using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BirdBossFlyingStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._birdBossFlyingGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._healthGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.BirdBossFlyingAbove))
		{
			BirdBossFlyingAboveStateCD value = c._birdBossFlyingGroup[entity];
			HealthCD healthCD = c._healthGroup[entity];
			IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
			if ((!value.cooldownTimer.isRunning || value.cooldownTimer.IsTimerElapsed(d._elapsedTime)) && !isInCombatCD.isInCombat && healthCD.health >= healthCD.maxHealth)
			{
				stateInfo.EnterState(StateID.BirdBossFlyingAbove);
			}
			c._birdBossFlyingGroup[entity] = value;
		}
	}
}
