using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct CoreBossSpawnBeamsStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._coreBossSpawnBeamsGroup.HasComponent(entity) && c._idleInCombatStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._distanceToPlayerGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		CoreBossSpawnBeamsStateCD value = c._coreBossSpawnBeamsGroup[entity];
		if (!value.isDisabled && !stateInfo.HasState(StateID.CoreBossSpawnBeams))
		{
			DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
			if (!c._isInCombatGroup[entity].isInCombat)
			{
				value.cooldownTimer.Stop();
			}
			else if (!value.cooldownTimer.isRunning)
			{
				value.cooldownTimer.Start(d._elapsedTime, 2f);
			}
			else if (value.cooldownTimer.IsTimerElapsed(d._elapsedTime) && distanceToPlayerCD.isVisible)
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.CoreBossSpawnBeams);
			}
			c._coreBossSpawnBeamsGroup[entity] = value;
		}
	}
}
