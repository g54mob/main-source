using System.Linq;
using DV.Common;
using DV.ThingTypes;
using UnityEngine;
using UnityEngine.UI;

namespace DV.Booklets
{
	public class LocoSpawnRateRenderer : MonoBehaviour
	{
		private static readonly Color GREEN = new Color32(154, 227, 121, byte.MaxValue);

		private static readonly Color YELLOW = new Color32(228, 218, 121, byte.MaxValue);

		public TrainCarType_v2 loco;

		public GameObject spawnRateIndicatorPrefab;

		public WorldStationsExtractedData stationData;

		private void Awake()
		{
			if (loco == null)
			{
				Debug.LogError("Did not assign loco to LocoSpawnRateRenderer!", base.gameObject);
				return;
			}
			if (stationData == null)
			{
				Debug.LogError("Did not assign stationData to LocoSpawnRateRenderer!", base.gameObject);
				return;
			}
			if (spawnRateIndicatorPrefab == null)
			{
				Debug.LogError("Did not assign spawnRateIndicatorPrefab to LocoSpawnRateRenderer!", base.gameObject);
				return;
			}
			foreach (string item in stationData.schematicMapStationOrder)
			{
				(WorldStationsExtractedData.StationData, int) tuple = stationData.GetStationData(item);
				if (tuple.Item2 == -1)
				{
					Debug.LogError("Did not find station with ID " + item);
					continue;
				}
				Image[] componentsInChildren = Object.Instantiate(spawnRateIndicatorPrefab, base.transform, worldPositionStays: false).GetComponentsInChildren<Image>();
				componentsInChildren[0].color = tuple.Item1.color;
				WorldStationsExtractedData.LocoSpawnChance locoSpawnChance = tuple.Item1.locoSpawnChances.FirstOrDefault((WorldStationsExtractedData.LocoSpawnChance chance) => chance.type == loco);
				if (locoSpawnChance == null || locoSpawnChance.chance < 0.001f)
				{
					componentsInChildren[1].color = Color.clear;
					componentsInChildren[2].enabled = true;
					continue;
				}
				componentsInChildren[2].enabled = false;
				if (locoSpawnChance.chance >= 0.99f)
				{
					componentsInChildren[1].color = GREEN;
				}
				else if (locoSpawnChance.chance >= 0.5f)
				{
					componentsInChildren[1].color = YELLOW;
				}
				else
				{
					componentsInChildren[1].color = Color.clear;
				}
			}
		}
	}
}
