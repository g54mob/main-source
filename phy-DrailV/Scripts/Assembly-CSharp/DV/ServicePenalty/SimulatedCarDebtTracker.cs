using System.Collections.Generic;
using DV.Damage;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using DV.ThingTypes;
using LocoSim.Implementations;
using LocoSim.Resources;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class SimulatedCarDebtTracker : LocoDebtTrackerBase
	{
		private DamageController dmgController;

		private Dictionary<ResourceType, List<ResourceContainer>> resourceToResourceContainers;

		private Dictionary<ResourceType, List<EnvironmentDamager>> resourceToEnvironmentDamage;

		public SimulatedCarDebtTracker(DamageController dmgController, ResourceContainerController resourceContainerController, EnvironmentDamageController envDamageController, SimulationFlow simFlow, string id, TrainCarType carType)
		{
			this.dmgController = dmgController;
			resourceToResourceContainers = new Dictionary<ResourceType, List<ResourceContainer>>();
			foreach (ResourceContainer resourceContainer in resourceContainerController.resourceContainers)
			{
				AddResourceTypeMappedItemToDictionary<ResourceContainer>(resourceContainer.resourceType.ConvertToDVResource(), resourceContainer, resourceToResourceContainers);
			}
			resourceToEnvironmentDamage = new Dictionary<ResourceType, List<EnvironmentDamager>>();
			if (envDamageController != null)
			{
				EnvironmentDamager[] entries = envDamageController.entries;
				foreach (EnvironmentDamager environmentDamager in entries)
				{
					AddResourceTypeMappedItemToDictionary<EnvironmentDamager>(environmentDamager.environmentDamageResource, environmentDamager, resourceToEnvironmentDamage);
				}
			}
			debtData = new CarDebtData(id, carType, InitializeDebtComponents());
			void AddResourceTypeMappedItemToDictionary<T>(ResourceType resourceType, T item, Dictionary<ResourceType, List<T>> dictionary)
			{
				if (dictionary.TryGetValue(resourceType, out var value))
				{
					value.Add(item);
				}
				else
				{
					dictionary.Add(resourceType, new List<T> { item });
				}
			}
		}

		public override DebtComponent[] InitializeDebtComponents()
		{
			int num = 1;
			if (dmgController.wheels != null)
			{
				num++;
			}
			if (dmgController.mechanicalPT != null)
			{
				num++;
			}
			if (dmgController.electricalPT != null)
			{
				num++;
			}
			int count = resourceToResourceContainers.Count;
			int count2 = resourceToEnvironmentDamage.Count;
			DebtComponent[] array = new DebtComponent[num + count + count2];
			int num2 = 0;
			array[num2++] = new DebtComponent(dmgController.bodyDamage.EffectiveHealthPercentage100Notation, ResourceType.Car_DMG);
			if (dmgController.wheels != null)
			{
				array[num2++] = new DebtComponent(dmgController.wheels.HealthPercentage100Notation, ResourceType.Wheels_DMG);
			}
			if (dmgController.mechanicalPT != null)
			{
				array[num2++] = new DebtComponent(dmgController.mechanicalPT.HealthPercentage100Notation, ResourceType.MechanicalPowertrain_DMG);
			}
			if (dmgController.electricalPT != null)
			{
				array[num2++] = new DebtComponent(dmgController.electricalPT.HealthPercentage100Notation, ResourceType.ElectricalPowertrain_DMG);
			}
			foreach (ResourceType key in resourceToResourceContainers.Keys)
			{
				float num3 = 0f;
				foreach (ResourceContainer item in resourceToResourceContainers[key])
				{
					num3 += item.amountReadOut.Value;
				}
				array[num2++] = new DebtComponent(num3, key);
			}
			foreach (ResourceType key2 in resourceToEnvironmentDamage.Keys)
			{
				array[num2++] = new DebtComponent(0f, key2);
			}
			return array;
		}

		public override void UpdateDebtValues()
		{
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			foreach (DebtComponent debtComponent in trackedDebts)
			{
				ResourceType type = debtComponent.Type;
				switch (type)
				{
				case ResourceType.Car_DMG:
					debtComponent.UpdateEndValue(dmgController.bodyDamage.EffectiveHealthPercentage100Notation);
					break;
				case ResourceType.Wheels_DMG:
					debtComponent.UpdateEndValue(dmgController.wheels.HealthPercentage100Notation);
					break;
				case ResourceType.MechanicalPowertrain_DMG:
					debtComponent.UpdateEndValue(dmgController.mechanicalPT.HealthPercentage100Notation);
					break;
				case ResourceType.ElectricalPowertrain_DMG:
					debtComponent.UpdateEndValue(dmgController.electricalPT.HealthPercentage100Notation);
					break;
				case ResourceType.Fuel:
				case ResourceType.Sand:
				case ResourceType.Oil:
				case ResourceType.Water:
				case ResourceType.Coal:
				case ResourceType.ElectricCharge:
				{
					float num2 = 0f;
					foreach (ResourceContainer item in resourceToResourceContainers[type])
					{
						num2 += item.amountReadOut.Value;
					}
					debtComponent.UpdateEndValue(num2);
					break;
				}
				case ResourceType.EnvironmentDamageFuel:
				case ResourceType.EnvironmentDamageCoal:
				{
					float num = 0f;
					foreach (EnvironmentDamager item2 in resourceToEnvironmentDamage[type])
					{
						num += item2.Damage;
					}
					debtComponent.UpdateStartValue(num);
					break;
				}
				default:
					Debug.LogError($"Unexpected state: {type} debt component, which is not supported!");
					break;
				}
			}
		}

		public override void ResetState()
		{
			TurnOffDebtSources();
			dmgController.RepairAll();
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			foreach (DebtComponent debtComponent in trackedDebts)
			{
				ResourceType type = debtComponent.Type;
				switch (type)
				{
				case ResourceType.Car_DMG:
					debtComponent.ResetComponent(dmgController.bodyDamage.EffectiveHealthPercentage100Notation);
					break;
				case ResourceType.Wheels_DMG:
					debtComponent.ResetComponent(dmgController.wheels.HealthPercentage100Notation);
					break;
				case ResourceType.MechanicalPowertrain_DMG:
					debtComponent.ResetComponent(dmgController.mechanicalPT.HealthPercentage100Notation);
					break;
				case ResourceType.ElectricalPowertrain_DMG:
					debtComponent.ResetComponent(dmgController.electricalPT.HealthPercentage100Notation);
					break;
				case ResourceType.Fuel:
				case ResourceType.Sand:
				case ResourceType.Oil:
				case ResourceType.Water:
				case ResourceType.Coal:
				case ResourceType.ElectricCharge:
				{
					float num = 0f;
					foreach (ResourceContainer item in resourceToResourceContainers[type])
					{
						item.refillExtIn.ExternalValueUpdate(item.capacity - item.amountReadOut.Value);
						num += item.capacity;
					}
					debtComponent.ResetComponent(num);
					break;
				}
				case ResourceType.EnvironmentDamageFuel:
				case ResourceType.EnvironmentDamageCoal:
					foreach (EnvironmentDamager item2 in resourceToEnvironmentDamage[type])
					{
						item2.ResetDamage();
					}
					debtComponent.ResetComponent(0f);
					break;
				default:
					Debug.LogError($"Unexpected state: {type} debt component, which is not supported!");
					break;
				}
			}
		}

		public override void TurnOffDebtSources()
		{
			dmgController?.GetComponent<SimController>()?.controlsOverrider?.SetNeutralState();
		}

		public override bool IsDebtOnlyEnvironmental()
		{
			bool flag = false;
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			foreach (DebtComponent debtComponent in trackedDebts)
			{
				ResourceType type = debtComponent.Type;
				switch (type)
				{
				case ResourceType.Fuel:
				case ResourceType.Sand:
				case ResourceType.Oil:
				case ResourceType.Water:
				case ResourceType.Coal:
				case ResourceType.ElectricCharge:
				case ResourceType.Car_DMG:
				case ResourceType.Wheels_DMG:
				case ResourceType.MechanicalPowertrain_DMG:
				case ResourceType.ElectricalPowertrain_DMG:
					if (debtComponent.StartToEndDiff > 0f)
					{
						return false;
					}
					break;
				case ResourceType.EnvironmentDamageFuel:
				case ResourceType.EnvironmentDamageCoal:
					flag = flag || debtComponent.StartToEndDiff > 0f;
					break;
				default:
					Debug.LogError($"Unexpected state: {type} debt component, which is not supported!");
					break;
				}
			}
			return flag;
		}
	}
}
