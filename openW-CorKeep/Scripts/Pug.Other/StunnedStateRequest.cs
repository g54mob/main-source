using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct StunnedStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._stunnedStateGroup.HasComponent(entity))
		{
			return c._conditionEffectBufferGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.Stunned) && c._conditionEffectBufferGroup[entity][58].value > 0)
		{
			stateInfo.EnterState(StateID.Stunned);
		}
	}
}
