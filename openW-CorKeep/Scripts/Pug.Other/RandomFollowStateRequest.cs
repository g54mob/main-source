using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct RandomFollowStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		return c._randomFollowStateGroup.HasComponent(entity);
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		RandomFollowStateCD value = c._randomFollowStateGroup[entity];
		if (!value.isDisabled && !stateInfo.HasState(StateID.RandomFollowing))
		{
			if (!value.cooldownTimer.isRunning || value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
			{
				value.replayAnimation = true;
				stateInfo.EnterState(StateID.RandomFollowing);
			}
			c._randomFollowStateGroup[entity] = value;
		}
	}
}
