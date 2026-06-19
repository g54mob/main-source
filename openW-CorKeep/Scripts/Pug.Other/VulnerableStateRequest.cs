using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct VulnerableStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._vulnerableStateGroup.HasComponent(entity) && c._healthGroup.HasComponent(entity) && c._conditionEffectBufferGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		VulnerableStateCD value = c._vulnerableStateGroup[entity];
		if (!value.cooldownTimer.isRunning)
		{
			value.cooldownTimer.Start(d._elapsedTime, 1f);
			c._vulnerableStateGroup[entity] = value;
		}
		else if (c._isInCombatGroup[entity].isInCombat && !stateInfo.HasState(StateID.Vulnerable) && !stateInfo.HasState(StateID.HydraBossBuriedRoaming) && (!value.cooldownTimer.isRunning || value.cooldownTimer.IsTimerElapsed(d._elapsedTime)) && c._conditionEffectBufferGroup[entity][98].value <= 0)
		{
			stateInfo.EnterState(StateID.Vulnerable);
			c._vulnerableStateGroup[entity] = value;
		}
	}
}
