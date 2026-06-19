using System.Runtime.InteropServices;
using Pug.Automation;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ActivatedByElectricityStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._activatedByElectricityGroup.HasComponent(entity))
		{
			return c._electricityGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		ActivatedByElectricityStateCD value = c._activatedByElectricityGroup[entity];
		ElectricityCD electricityCD = c._electricityGroup[entity];
		if (!stateInfo.HasState(StateID.ActivatedByElectricity) && electricityCD.hasEnoughElectricityToPowerStuff)
		{
			stateInfo.EnterState(StateID.ActivatedByElectricity);
			value.internalState = ActivatedByElectricityStateCD.State.Initializing;
		}
		c._activatedByElectricityGroup[entity] = value;
	}
}
