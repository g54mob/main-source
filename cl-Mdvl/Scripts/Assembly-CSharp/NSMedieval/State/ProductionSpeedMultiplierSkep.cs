using System;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	public class ProductionSpeedMultiplierSkep
	{
		[SerializeField]
		private float bonusPerPlant;

		[SerializeField]
		private float bonusPerSkep;

		[SerializeField]
		private float radius;

		public float Radius => radius;

		public float CalculateMultiplier(MapNode skepNode, ref SkepProductionMultiplierData data)
		{
			ref ConcurrentHashSet<PlantMapResourceInstance> plants = ref data.Plants;
			if (plants == null)
			{
				plants = new ConcurrentHashSet<PlantMapResourceInstance>();
			}
			data.Plants.Clear();
			data.PlantsCount = 0;
			data.SkepCount = 0;
			foreach (MapNode item in FloodFillUtil.IterateFloodFill3D(skepNode.Map, skepNode.Position, radius))
			{
				if (item == skepNode)
				{
					continue;
				}
				if ((item.DataType & GridDataType.PlantMapResource) != GridDataType.None)
				{
					PlantMapResourceInstance plant = MonoSingleton<PlantResourceManager>.Instance.GetPlant(item.Position);
					if (plant.Blueprint.LifePhases[plant.CurrentPhase].IsTastyForBees)
					{
						data.Plants.Add(plant);
						data.PlantsCount++;
					}
				}
				if (item.ContainsBuilding())
				{
					BaseBuildingInstance firstBuilding = item.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.ProductionBuilding, item.Position);
					if (firstBuilding != null && firstBuilding.BlueprintId == "skep")
					{
						data.SkepCount++;
					}
				}
			}
			data.TotalPlantBonus = (float)data.PlantsCount * bonusPerPlant;
			data.TotalSkepPenalty = (float)data.SkepCount * bonusPerSkep;
			float value = data.TotalPlantBonus + data.TotalSkepPenalty;
			data.LastMultiplier = Mathf.Clamp(value, 0.05f, 1.5f);
			return data.LastMultiplier;
		}
	}
}
