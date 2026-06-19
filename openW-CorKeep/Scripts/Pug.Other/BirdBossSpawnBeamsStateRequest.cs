using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BirdBossSpawnBeamsStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._birdBossSpawnBeamsGroup.HasComponent(entity) && c._idleInCombatStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._distanceToPlayerGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.BirdBossSpawnBeams) && !stateInfo.HasState(StateID.BirdBossSpawnStones))
		{
			DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
			IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
			BirdBossSpawnBeamsStateCD value = c._birdBossSpawnBeamsGroup[entity];
			if (!isInCombatCD.isInCombat)
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
				stateInfo.EnterState(StateID.BirdBossSpawnBeams);
			}
			c._birdBossSpawnBeamsGroup[entity] = value;
		}
	}
}
