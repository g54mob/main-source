using System;
using System.Collections.Generic;
using DV.Damage;
using DV.ThingTypes;
using LocoSim.Implementations;
using LocoSim.Resources;
using UnityEngine;

namespace DV.PitStops
{
	public class SimulatedCarPitStopParameters : CarPitStopParametersBase
	{
		private DamageController dmgController;

		private List<ResourceContainer> resourceContainers;

		private List<ResourceType> existingResources;

		public event Action ParametersUpdated;

		public void Initialize(List<ResourceContainer> resourceContainers, DamageController dmgController)
		{
			this.resourceContainers = resourceContainers;
			this.dmgController = dmgController;
			InitPitStopParameters();
		}

		protected override void InitPitStopParameters()
		{
			existingResources = new List<ResourceType>();
			carPitStopParameters = new Dictionary<ResourceType, LocoParameterData>();
			carPitStopParameters.Add(ResourceType.Car_DMG, new LocoParameterData(dmgController.bodyDamage.EffectiveHealthPercentage100Notation, 100f));
			if (dmgController.wheels != null)
			{
				carPitStopParameters.Add(ResourceType.Wheels_DMG, new LocoParameterData(dmgController.wheels.HealthPercentage100Notation, 100f));
			}
			if (dmgController.mechanicalPT != null)
			{
				carPitStopParameters.Add(ResourceType.MechanicalPowertrain_DMG, new LocoParameterData(dmgController.mechanicalPT.HealthPercentage100Notation, 100f));
			}
			if (dmgController.electricalPT != null)
			{
				carPitStopParameters.Add(ResourceType.ElectricalPowertrain_DMG, new LocoParameterData(dmgController.electricalPT.HealthPercentage100Notation, 100f));
			}
			foreach (ResourceContainer resourceContainer in resourceContainers)
			{
				ResourceType resourceType = resourceContainer.resourceType.ConvertToDVResource();
				if (carPitStopParameters.TryGetValue(resourceType, out var value))
				{
					value.maxValue += resourceContainer.capacity;
					value.value += resourceContainer.amountReadOut.Value;
				}
				else
				{
					carPitStopParameters.Add(resourceType, new LocoParameterData(resourceContainer.amountReadOut.Value, resourceContainer.capacity));
					existingResources.Add(resourceType);
				}
			}
		}

		public override void UpdateCarPitStopParameter(ResourceType parameter, float changeAmount)
		{
			switch (parameter)
			{
			case ResourceType.Car_DMG:
				dmgController.bodyDamage.RepairCarEffectivePercentage(changeAmount / 100f);
				if (dmgController.windows != null && dmgController.bodyDamage.DamagePercentage < 0.05f)
				{
					dmgController.windows.RepairWindows();
				}
				break;
			case ResourceType.Wheels_DMG:
				dmgController.wheels.RepairDamagePercentage(changeAmount / 100f);
				break;
			case ResourceType.MechanicalPowertrain_DMG:
				dmgController.mechanicalPT.RepairDamagePercentage(changeAmount / 100f);
				break;
			case ResourceType.ElectricalPowertrain_DMG:
				dmgController.electricalPT.RepairDamagePercentage(changeAmount / 100f);
				break;
			case ResourceType.Fuel:
			case ResourceType.Sand:
			case ResourceType.Oil:
			case ResourceType.Water:
			case ResourceType.Coal:
			case ResourceType.ElectricCharge:
			{
				float num = changeAmount;
				foreach (ResourceContainer resourceContainer in resourceContainers)
				{
					ResourceType resourceType = resourceContainer.resourceType.ConvertToDVResource();
					if (parameter == resourceType)
					{
						float value = resourceContainer.amountReadOut.Value;
						float num2 = resourceContainer.capacity - value;
						if (num2 >= num)
						{
							resourceContainer.refillExtIn.ExternalValueUpdate(num);
							num = 0f;
						}
						else
						{
							resourceContainer.refillExtIn.ExternalValueUpdate(num2);
							num -= num2;
						}
					}
					if (num <= 0f)
					{
						break;
					}
				}
				if (num > 0f)
				{
					Debug.LogError($"Unexpected state: {num} of {parameter} doesn't have space in containers to be refilled. Something is wrong, but not critical!");
				}
				break;
			}
			default:
				Debug.LogWarning("Shouldn't have happened. Trying to refill/repair something that is not part of this loco", base.gameObject);
				break;
			}
			this.ParametersUpdated?.Invoke();
		}

		protected override void RefreshParameters()
		{
			carPitStopParameters[ResourceType.Car_DMG].value = dmgController.bodyDamage.EffectiveHealthPercentage100Notation;
			if (dmgController.wheels != null)
			{
				carPitStopParameters[ResourceType.Wheels_DMG].value = dmgController.wheels.HealthPercentage100Notation;
			}
			if (dmgController.mechanicalPT != null)
			{
				carPitStopParameters[ResourceType.MechanicalPowertrain_DMG].value = dmgController.mechanicalPT.HealthPercentage100Notation;
			}
			if (dmgController.electricalPT != null)
			{
				carPitStopParameters[ResourceType.ElectricalPowertrain_DMG].value = dmgController.electricalPT.HealthPercentage100Notation;
			}
			foreach (ResourceType existingResource in existingResources)
			{
				carPitStopParameters[existingResource].value = 0f;
			}
			foreach (ResourceContainer resourceContainer in resourceContainers)
			{
				ResourceType key = resourceContainer.resourceType.ConvertToDVResource();
				carPitStopParameters[key].value += resourceContainer.amountReadOut.Value;
			}
		}
	}
}
