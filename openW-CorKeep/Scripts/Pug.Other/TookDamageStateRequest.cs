using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct TookDamageStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._tookDamageStateGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.TookDamage))
		{
			TookDamageStateCD value = c._tookDamageStateGroup[entity];
			HealthCD healthCD = c._healthGroup[entity];
			if (healthCD.health < healthCD.maxHealth && healthCD.health > 0 && c._damageTakenGroup.TryGetComponent(entity, out var componentData) && c._damageTakenGroup.IsComponentEnabled(entity) && !componentData.skipRequestTookDamageState)
			{
				stateInfo.EnterState(StateID.TookDamage);
				value.internalState = 0;
			}
			c._tookDamageStateGroup[entity] = value;
		}
	}
}
