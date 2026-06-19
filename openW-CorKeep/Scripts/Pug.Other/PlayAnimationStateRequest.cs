using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct PlayAnimationStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		return c._playAnimationStateGroup.HasComponent(entity);
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (c._playAnimationStateGroup.IsComponentEnabled(entity) && !stateInfo.HasState(StateID.PlayAnimation))
		{
			stateInfo.EnterState(StateID.PlayAnimation);
		}
	}
}
