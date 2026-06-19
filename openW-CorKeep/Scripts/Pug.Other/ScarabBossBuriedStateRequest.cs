using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ScarabBossBuriedStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._scarabBossBuriedGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._healthGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		ScarabBossBuriedStateCD value = c._scarabBossBuriedGroup[entity];
		HealthCD healthCD = c._healthGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		if (!stateInfo.HasState(StateID.ScarabBossBuried) && (!value.cooldownTimer.isRunning || value.cooldownTimer.IsTimerElapsed(d._elapsedTime)) && !isInCombatCD.isInCombat && healthCD.health >= healthCD.maxHealth)
		{
			stateInfo.EnterState(StateID.ScarabBossBuried);
		}
		c._scarabBossBuriedGroup[entity] = value;
	}

	public void OnAfterUpdate(SystemBase system)
	{
	}
}
