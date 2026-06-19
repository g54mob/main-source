using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct DeathStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		return c._entityDestroyedGroup.HasComponent(entity);
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.Death) && c._entityDestroyedGroup.IsComponentEnabled(entity))
		{
			stateInfo.newState = StateID.Death;
			stateInfo.locked = true;
		}
	}
}
