using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct GiantCicadaBossAppearStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._giantCicadaAppearStateGroup.HasComponent(entity) && c._bossGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._giantCicadaHasAppearedGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.GiantCicadaBossAppear) && !c._giantCicadaHasAppearedGroup[entity].Value)
		{
			GiantCicadaBossAppearStateCD value = c._giantCicadaAppearStateGroup[entity];
			BossCD value2 = c._bossGroup[entity];
			HealthCD healthCD = c._healthGroup[entity];
			if (healthCD.health >= healthCD.maxHealth && value.internalState == 0)
			{
				value.internalState = 1;
				stateInfo.EnterState(StateID.GiantCicadaBossAppear);
				c._giantCicadaAppearStateGroup[entity] = value;
				c._bossGroup[entity] = value2;
			}
			else
			{
				value.internalState = 3;
				c._giantCicadaAppearStateGroup[entity] = value;
			}
		}
	}
}
