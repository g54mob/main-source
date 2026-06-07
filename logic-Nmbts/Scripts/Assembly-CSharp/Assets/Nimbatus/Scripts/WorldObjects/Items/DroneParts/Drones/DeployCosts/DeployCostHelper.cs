using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DeployCosts
{
	public static class DeployCostHelper
	{
		public static DeployCost CalculateDeployCost(int parts)
		{
			return new DeployCost
			{
				Threat = ThreatHelper.CalculateDeployCost(),
				Resource = ETerrainMaterial.CommonOre,
				ResourceAmount = GetDeployCost(parts)
			};
		}

		private static int GetDeployCost(int parts)
		{
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation is WormHoleLocationData)
			{
				return 0;
			}
			int threshold = GetThreshold(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.DroneHangar));
			int partCost = GetPartCost(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.DroneFabrication));
			return Mathf.FloorToInt((float)((parts > threshold) ? ((parts - threshold) * -partCost) : 0) * RuntimeGlobals.DeployCostModifier);
		}

		public static int GetThreshold(int level)
		{
			return 10 + level * 5;
		}

		public static int GetPartCost(int level)
		{
			return 5 - level;
		}

		public static bool HasEnoughResources(DeployCost cost)
		{
			if (!RuntimeGlobals.GameModeSettings.DeployCost)
			{
				return true;
			}
			return SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetAvailableResources(cost.Resource) >= (double)Mathf.Abs(cost.ResourceAmount);
		}

		public static void CommitDeployment(DeployCost cost)
		{
			if (cost != null)
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.IncreaseThreatByAmount(cost.Threat);
				SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.AddResources(cost.Resource, cost.ResourceAmount);
			}
		}
	}
}
