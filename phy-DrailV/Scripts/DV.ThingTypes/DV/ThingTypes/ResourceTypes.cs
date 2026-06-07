using System;
using System.Linq;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

namespace DV.ThingTypes
{
	public static class ResourceTypes
	{
		public const float SERVICE_TAX = 2f;

		private const float PERCENTAGE_PRICE = 0.01f;

		private static ResourceType[] _consumableResources;

		private static ResourceType[] _damageableResources;

		public static ResourceType[] ConsumableResources
		{
			get
			{
				if (_consumableResources == null)
				{
					_consumableResources = (from ResourceType rt in Enum.GetValues(typeof(ResourceType))
						where rt.ToV2().isConsumable
						select rt).ToArray();
				}
				return _consumableResources;
			}
		}

		public static ResourceType[] DamageableResources
		{
			get
			{
				if (_damageableResources == null)
				{
					_damageableResources = (from ResourceType rt in Enum.GetValues(typeof(ResourceType))
						where rt.ToV2().canBeDamaged
						select rt).ToArray();
				}
				return _damageableResources;
			}
		}

		public static float GetFullUnitPriceOfResource(ResourceType resource, TrainCarLivery carLivery = null, CargoType_v2 cargoType = null, ResourceGameParams gameParams = null)
		{
			float num = 0f;
			ResourceType_v2 resourceType_v = resource.ToV2();
			if (resourceType_v == null)
			{
				return num;
			}
			TrainCarType_v2 trainCarType_v = ((carLivery != null) ? carLivery.parentType : null);
			switch (resource)
			{
			case ResourceType.Car_DMG:
				if (trainCarType_v != null)
				{
					num = trainCarType_v.damage.bodyPrice * 0.01f;
				}
				break;
			case ResourceType.Wheels_DMG:
				if (trainCarType_v != null)
				{
					num = trainCarType_v.damage.wheelsPrice * 0.01f;
				}
				break;
			case ResourceType.MechanicalPowertrain_DMG:
				if (trainCarType_v != null)
				{
					num = trainCarType_v.damage.mechanicalPowertrainPrice * 0.01f;
				}
				break;
			case ResourceType.ElectricalPowertrain_DMG:
				if (trainCarType_v != null)
				{
					num = trainCarType_v.damage.electricalPowertrainPrice * 0.01f;
				}
				break;
			case ResourceType.Cargo_DMG:
				if (cargoType != null)
				{
					num = cargoType.fullDamagePrice * 0.01f;
				}
				break;
			case ResourceType.EnvironmentDamageCargo:
				if (cargoType != null)
				{
					num = cargoType.environmentDamagePrice * 0.01f;
				}
				break;
			default:
				num = resourceType_v.price;
				break;
			}
			if (gameParams != null)
			{
				if (resourceType_v.isConsumable)
				{
					num *= gameParams.ConsumablesPriceModifier;
				}
				if (resource == ResourceType.Cargo_DMG)
				{
					num *= gameParams.CargoDamagePriceModifier;
				}
				else if (resourceType_v.canBeDamaged)
				{
					num *= gameParams.DamageablePriceModifier;
				}
				if (resourceType_v.canDamageEnvironment)
				{
					num *= gameParams.EnvironmentDamagePriceModifier;
				}
			}
			else
			{
				Debug.LogWarning("gameParams not provided, price modifiers not applied.");
			}
			return (float)Math.Round(num, 2);
		}
	}
}
