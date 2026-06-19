using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct OctopusBossLurkStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._lurkingBelowGroup.HasComponent(entity) && c._octopusBossGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._healthGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		OctopusBossLurkingBelowStateCD value = c._lurkingBelowGroup[entity];
		OctopusBossCD value2 = c._octopusBossGroup[entity];
		HealthCD healthCD = c._healthGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		value2.canLeaveFightTimer -= d._deltaTime;
		if (!stateInfo.HasState(StateID.OctopusBossLurkingBelow) && (!value.cooldownTimer.isRunning || value.cooldownTimer.IsTimerElapsed(d._elapsedTime)) && !isInCombatCD.isInCombat && healthCD.health >= healthCD.maxHealth && value2.canLeaveFightTimer <= 0f)
		{
			stateInfo.EnterState(StateID.OctopusBossLurkingBelow);
		}
		c._lurkingBelowGroup[entity] = value;
		c._octopusBossGroup[entity] = value2;
	}
}
