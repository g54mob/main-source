using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BirdBossSpawnStonesStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._spawnStonesGroup.HasComponent(entity) && c._idleInCombatStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity))
		{
			return c._distanceToPlayerGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.BirdBossSpawnStones) && !stateInfo.HasState(StateID.BirdBossSpawnBeams))
		{
			BirdBossSpawnStonesStateCD value = c._spawnStonesGroup[entity];
			IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
			DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
			if (!isInCombatCD.isInCombat)
			{
				value.cooldownTimer.Stop();
			}
			else if (!value.cooldownTimer.isRunning)
			{
				value.cooldownTimer.Start(d._elapsedTime, value.minCooldown);
			}
			else if (value.cooldownTimer.IsTimerElapsed(d._elapsedTime) && distanceToPlayerCD.minDistanceSq < 400f)
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.BirdBossSpawnStones);
			}
			c._spawnStonesGroup[entity] = value;
		}
	}
}
