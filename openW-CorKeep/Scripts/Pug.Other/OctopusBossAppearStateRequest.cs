using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct OctopusBossAppearStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._octopusAppearStateGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity) && c._octopusHasAppearedGroup.HasComponent(entity))
		{
			return c._octopusBossGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.OctopusBossAppear) && !c._octopusHasAppearedGroup[entity].Value)
		{
			OctopusBossAppearStateCD value = c._octopusAppearStateGroup[entity];
			OctopusBossCD octopusBossCD = c._octopusBossGroup[entity];
			if (c._isInCombatGroup[entity].isInCombat || octopusBossCD.isFighting)
			{
				value.internalState = 0;
				stateInfo.EnterState(StateID.OctopusBossAppear);
			}
			c._octopusAppearStateGroup[entity] = value;
		}
	}
}
