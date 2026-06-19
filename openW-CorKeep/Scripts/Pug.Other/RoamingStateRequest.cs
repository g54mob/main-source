using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct RoamingStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		return c._roamingStateGroup.HasComponent(entity);
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		RoamingStateCD value = c._roamingStateGroup[entity];
		if (!value.isDisabled && !stateInfo.HasState(StateID.Roaming))
		{
			value.internalState = RoamingStateCD.RoamingInternalState.Idle;
			stateInfo.EnterState(StateID.Roaming);
			c._roamingStateGroup[entity] = value;
		}
	}
}
