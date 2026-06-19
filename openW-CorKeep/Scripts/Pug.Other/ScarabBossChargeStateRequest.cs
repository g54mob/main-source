using System;
using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ScarabBossChargeStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._idleInCombatStateGroup.HasComponent(entity) && c._scarabChargeStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity))
		{
			return c._distanceToPlayerGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		ScarabBossChargeStateCD value = c._scarabChargeStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
		if (!stateInfo.HasState(StateID.ScarabBossCharge) && !stateInfo.IsCurrentState(StateID.ScarabBossAppear) && !stateInfo.IsCurrentState(StateID.ScarabBossSpawnBombScarabs) && !stateInfo.IsCurrentState(StateID.ShootMortarProjectile) && !value.disabled)
		{
			if (!isInCombatCD.isInCombat)
			{
				value.cooldownTimer.Stop();
			}
			else if (!value.cooldownTimer.isRunning)
			{
				value.cooldownTimer.Start(d._elapsedTime, value.minCooldown);
			}
			else if (value.cooldownTimer.IsTimerElapsed(d._elapsedTime) && distanceToPlayerCD.minDistanceSq < 900f)
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.ScarabBossCharge);
			}
			c._scarabChargeStateGroup[entity] = value;
		}
	}

	public void OnAfterUpdate(SystemBase system)
	{
		throw new NotImplementedException();
	}
}
