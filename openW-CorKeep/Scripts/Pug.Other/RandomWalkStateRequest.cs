using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct RandomWalkStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		return c._randomWalkStateGroup.HasComponent(entity);
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		RandomWalkStateCD value = c._randomWalkStateGroup[entity];
		if (!stateInfo.HasState(StateID.RandomWalking))
		{
			if (!value.cooldownTimer.isRunning || value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
			{
				value.isNewStateTrigger = true;
				stateInfo.EnterState(StateID.RandomWalking);
			}
			c._randomWalkStateGroup[entity] = value;
		}
	}
}
