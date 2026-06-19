using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct HydraBossBuriedCombatStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._hydraBossBuriedCombatStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity) && c._distanceToPlayerGroup.HasComponent(entity))
		{
			return c._conditionEffectBufferGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		HydraBossBuriedCombatStateCD value = c._hydraBossBuriedCombatStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
		if (stateInfo.HasState(StateID.HydraBossBuriedCombat) || stateInfo.HasState(StateID.ShootMortarProjectile) || stateInfo.HasState(StateID.MeleeAttack) || value.disabled || c._conditionEffectBufferGroup[entity][98].value == 0)
		{
			return;
		}
		if (isInCombatCD.isInCombat)
		{
			if (!value.cooldownTimer.isRunning)
			{
				value.cooldownTimer.Start(d._elapsedTime, value.minCooldown);
			}
			else if (value.cooldownTimer.IsTimerElapsed(d._elapsedTime) && distanceToPlayerCD.minDistanceSq < 900f)
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.HydraBossBuriedCombat);
			}
		}
		c._hydraBossBuriedCombatStateGroup[entity] = value;
	}
}
