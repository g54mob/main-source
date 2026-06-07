using System;
using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

namespace DV.Common
{
	[CreateAssetMenu(menuName = "DV/World stations extracted data")]
	public class WorldStationsExtractedData : ScriptableObject
	{
		[Serializable]
		public class StationData
		{
			public string id;

			public Vector3 worldAbsolutePosition;

			public Vector3 playerAnchorWorldPosition;

			public Vector3 playerAnchorRotation;

			public List<string> trackIds;

			public List<LocoSpawnChance> locoSpawnChances;

			public Color color;

			public StationData(string id, Vector3 worldAbsolutePosition, Vector3 playerAnchorWorldPosition, Vector3 playerAnchorRotation, List<string> trackIds, List<LocoSpawnChance> locoSpawnChances, Color color)
			{
				this.id = id;
				this.worldAbsolutePosition = worldAbsolutePosition;
				this.playerAnchorWorldPosition = playerAnchorWorldPosition;
				this.playerAnchorRotation = playerAnchorRotation;
				this.trackIds = trackIds;
				this.locoSpawnChances = locoSpawnChances;
				this.color = color;
			}
		}

		[Serializable]
		public class LocoSpawnChance
		{
			public TrainCarType_v2 type;

			public float chance;

			public LocoSpawnChance(TrainCarType_v2 type, float chance)
			{
				this.type = type;
				this.chance = chance;
			}
		}

		public List<StationData> stationsData;

		public List<string> schematicMapStationOrder;

		public (StationData data, int index) GetStationData(string stationId)
		{
			for (int i = 0; i < stationsData.Count; i++)
			{
				StationData stationData = stationsData[i];
				if (stationData.id == stationId)
				{
					return (data: stationData, index: i);
				}
			}
			return (data: null, index: -1);
		}
	}
}
