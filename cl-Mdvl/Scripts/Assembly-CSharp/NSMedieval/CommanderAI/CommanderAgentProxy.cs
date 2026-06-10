using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.BuildingComponents;
using NSMedieval.Village.Map;
using Raid.Config;
using UnityEngine;

namespace NSMedieval.CommanderAI
{
	public class CommanderAgentProxy : MonoBehaviour
	{
		public BehaviourTreeCommanderAgent Agent { get; set; }

		public SiegePathfinderPenaltyModifiers SiegePathfinderModifiers { get; set; }

		public VillageMap Map => Agent.Map;

		public ICollection<CommanderAIUnit> Units => Agent?.Units;

		public List<BaseBuildingInstance> DeployedSiegeWeapons => Agent?.DeployedSiegeWeapons;

		public Dictionary<string, int> SiegeWeaponInventory => Agent?.SiegeWeaponInventory;

		public bool HasArtilleryAmmo
		{
			get
			{
				if (Agent != null)
				{
					return Agent.HasArtilleryAmmo;
				}
				return false;
			}
		}

		public int TotalSiegeWeaponsCount
		{
			get
			{
				int num = 0;
				foreach (int value in SiegeWeaponInventory.Values)
				{
					num += value;
				}
				return num + DeployedSiegeWeapons.Count;
			}
		}

		public void DebugLog(object obj)
		{
			Log.Info(obj.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\Agents\\CommanderAgentProxy.cs");
		}

		public int GetSiegeWeaponInventoryCount(string blueprintId)
		{
			if (Agent == null)
			{
				return -1;
			}
			return Agent.GetSiegeWeaponInventoryCount(blueprintId);
		}
	}
}
