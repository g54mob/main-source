using System.Runtime.InteropServices;
using Pug.Properties;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct EnrageStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._enrageStateGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.Enrage))
		{
			EnrageStateCD value = c._enrageStateGroup[entity];
			HealthCD healthCD = c._healthGroup[entity];
			ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
			bool flag = (float)healthCD.health / (float)healthCD.maxHealth <= objectPropertiesCD.Get<float>(-621727198);
			bool flag2 = (float)healthCD.health / (float)healthCD.maxHealth >= objectPropertiesCD.Get<float>(1395754404);
			if (!value.isEnraged && flag)
			{
				value.internalState = EnrageStateCD.InternalState.Init;
				stateInfo.EnterState(StateID.Enrage);
			}
			else if (value.isEnraged && flag2)
			{
				value.isEnraged = false;
			}
			c._enrageStateGroup[entity] = value;
		}
	}
}
