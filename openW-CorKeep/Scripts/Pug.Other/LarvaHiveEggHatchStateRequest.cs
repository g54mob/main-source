using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct LarvaHiveEggHatchStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._larvaHiveHatchStateGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.LarvaHiveEggHatch))
		{
			LarvaHiveEggHatchStateCD larvaHiveEggHatchStateCD = c._larvaHiveHatchStateGroup[entity];
			HealthCD healthCD = c._healthGroup[entity];
			if ((larvaHiveEggHatchStateCD.internalTimer.isRunning && larvaHiveEggHatchStateCD.internalTimer.IsTimerElapsed(d._elapsedTime)) || larvaHiveEggHatchStateCD.internalState == 0 || healthCD.health <= 0)
			{
				stateInfo.EnterState(StateID.LarvaHiveEggHatch);
			}
		}
	}
}
