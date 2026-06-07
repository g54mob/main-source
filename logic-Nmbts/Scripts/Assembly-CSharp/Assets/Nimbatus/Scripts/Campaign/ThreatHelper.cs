using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	public static class ThreatHelper
	{
		public class SectorNode
		{
			public GalaxyMapSector Sector;

			public int GCost;

			public int HCost;

			public SectorNode Parent;
		}

		public static float CalculateBaseIncrease(int galaxySize, int level)
		{
			float num = 15f / (float)galaxySize;
			float num2 = 1f;
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				int num3 = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GalaxyProgression.Count - 2;
				num2 += (float)Mathf.Clamp(level - 1, 0, num3) * (0.5f / (float)num3);
			}
			return num * num2;
		}

		public static float CalculateDeployCost()
		{
			if (!RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat || SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				return 0f;
			}
			return 4f;
		}

		public static float CalculateTravelCost(LocationData start, LocationData end, out bool foundPath)
		{
			float num;
			if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				num = 16f;
			}
			else
			{
				num = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.BaseThreatIncrease;
				num *= 1f - GetThreatReduction(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(EMothershipUpgradeType.Drive));
				num *= (float)RuntimeGlobals.GameModeSettings.ThreatIncrease / 100f;
			}
			float result = 0f;
			if (end != start)
			{
				if (end.Sector == start.Sector)
				{
					result = num;
				}
				else
				{
					int num2 = Pathfinder(start, end);
					if (num2 < 0)
					{
						foundPath = false;
						return -1f;
					}
					result = ((!start.Sector.IsDeadEnd && !end.Sector.IsDeadEnd) ? (num * 3f * (float)num2) : ((!end.Sector.GetNeighbours().Contains(start.Sector)) ? (num * 3f * (float)(num2 - 1) + num * 1.5f) : (num * 1.5f * (float)num2)));
				}
			}
			foundPath = true;
			return result;
		}

		public static float GetThreatReduction(int level)
		{
			return 0.125f * (float)level;
		}

		private static int Pathfinder(LocationData start, LocationData end)
		{
			List<SectorNode> list = new List<SectorNode>
			{
				new SectorNode
				{
					Sector = start.Sector
				}
			};
			List<SectorNode> list2 = new List<SectorNode>();
			while (list.Count > 0)
			{
				SectorNode sectorNode = list[0];
				for (int i = 1; i < list.Count; i++)
				{
					if (list[i].GCost + list[i].HCost < sectorNode.GCost + sectorNode.HCost || (list[i].GCost + list[i].HCost == sectorNode.GCost + sectorNode.HCost && list[i].HCost < sectorNode.HCost))
					{
						sectorNode = list[i];
					}
				}
				list.Remove(sectorNode);
				list2.Add(sectorNode);
				if (sectorNode.Sector == end.Sector)
				{
					return Retrace(list2.Find((SectorNode s) => s.Sector == start.Sector), list2.Find((SectorNode s) => s.Sector == end.Sector)).Count;
				}
				foreach (GalaxyMapSector neighbour in sectorNode.Sector.GetNeighbours())
				{
					if (neighbour.Explored && list2.Find((SectorNode s) => s.Sector == neighbour) == null && list.Find((SectorNode s) => s.Sector == neighbour) == null)
					{
						SectorNode sectorNode2 = new SectorNode();
						sectorNode2.Sector = neighbour;
						sectorNode2.GCost = sectorNode.GCost + GetEstimate(sectorNode.Sector, end.Sector);
						sectorNode2.HCost = GetEstimate(neighbour, end.Sector);
						sectorNode2.Parent = sectorNode;
						list.Add(sectorNode2);
					}
				}
			}
			return -1;
		}

		private static int GetEstimate(GalaxyMapSector first, GalaxyMapSector second)
		{
			return Mathf.RoundToInt(Vector2.Distance(first.Position, second.Position));
		}

		private static List<SectorNode> Retrace(SectorNode start, SectorNode end)
		{
			List<SectorNode> list = new List<SectorNode>();
			for (SectorNode sectorNode = end; sectorNode != start; sectorNode = sectorNode.Parent)
			{
				list.Add(sectorNode);
			}
			list.Reverse();
			return list;
		}
	}
}
