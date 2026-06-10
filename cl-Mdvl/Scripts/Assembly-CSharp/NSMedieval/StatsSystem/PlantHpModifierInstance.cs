using NSMedieval.State;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	public class PlantHpModifierInstance : CustomAttributeModifierInstance
	{
		private PlantMapResourceInstance plant;

		private PlantMapResourceInstance Plant => plant ?? (plant = base.Owner.Owner as PlantMapResourceInstance);

		public PlantHpModifierInstance(AttributeType attributeType, float value, string tag, bool negativeStacking = false)
			: base(attributeType, value, tag, negativeStacking)
		{
		}

		public override void Apply()
		{
			if (attributeInstance == null)
			{
				return;
			}
			PlantMapResourceInstance plantMapResourceInstance = Plant;
			if (plantMapResourceInstance != null && plantMapResourceInstance.Blueprint != null)
			{
				float num = plantMapResourceInstance.Blueprint.HealthRecoverySpeed;
				if (plantMapResourceInstance.IsDyingLowTemperature)
				{
					num = Mathf.Min(num, 0f - plantMapResourceInstance.Blueprint.FreezeDyingSpeed.Random());
				}
				if (plantMapResourceInstance.Blueprint.UseSunlight && plantMapResourceInstance.IsDyingLowSunlight)
				{
					num = Mathf.Min(num, 0f - plantMapResourceInstance.Blueprint.NoLightDyingSpeed.Random());
				}
				if (plantMapResourceInstance.IsDyingHighTemperature)
				{
					num = Mathf.Min(num, 0f - plantMapResourceInstance.Blueprint.OverheatDyingSpeed.Random());
				}
				if (plantMapResourceInstance.IsDyingFlooded || plantMapResourceInstance.IsDyingNoWater)
				{
					WaterDepthLevel waterLevelAsDepth = plant.Map.WaterManager.GetWaterLevelAsDepth(plant.GridDataPosition);
					float hpLossOnWaterLevel = plantMapResourceInstance.Blueprint.GetHpLossOnWaterLevel((int)waterLevelAsDepth);
					if (hpLossOnWaterLevel > 0f)
					{
						num = Mathf.Min(num, 0f - hpLossOnWaterLevel);
					}
				}
				attributeInstance.SetMultiplier(num);
			}
			else
			{
				attributeInstance.SetMultiplier(0f);
			}
		}
	}
}
