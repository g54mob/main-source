using System.Runtime.InteropServices;
using Pug.Properties;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct AttackContinuouslyStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		return c._attackContinuouslyStateGroup.HasComponent(entity);
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (!stateInfo.HasState(StateID.MeleeAttackContinuous))
		{
			AttackContinuouslyCD value = c._attackContinuouslyStateGroup[entity];
			ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
			if ((c._electricityGroup.HasComponent(entity) && c._electricityGroup[entity].hasEnoughElectricityToPowerStuff) || !objectPropertiesCD.Has(-736887470))
			{
				value.hasTriggeredIdleAnimationOnEnteringState = false;
				stateInfo.EnterState(StateID.MeleeAttackContinuous);
			}
			c._attackContinuouslyStateGroup[entity] = value;
		}
	}
}
