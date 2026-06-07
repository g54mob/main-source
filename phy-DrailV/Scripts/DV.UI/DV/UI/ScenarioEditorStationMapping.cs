using System;
using System.Collections.Generic;
using System.Linq;
using DV.Common;
using UnityEngine;

namespace DV.UI
{
	[CreateAssetMenu(menuName = "DV/Station Mapping for Scenario Editor UI")]
	public class ScenarioEditorStationMapping : ScriptableObject
	{
		public class TrackPickerAttribute : PropertyAttribute
		{
		}

		[Serializable]
		public class Mapping
		{
			public string id;

			[TrackPicker]
			public string trackId;

			public bool reverseTrain;

			public Mapping(string id, string trackId, bool reverseTrain)
			{
				this.id = id;
				this.trackId = trackId;
				this.reverseTrain = reverseTrain;
			}
		}

		public WorldStationsExtractedData sourceData;

		public List<Mapping> mappings;

		public (Vector3 playerPos, float playerRotationY, string trackID, bool reverseTrain) GetSpawnData(string mappingID)
		{
			(Vector3, int, string, bool) tuple = (Vector3.zero, 0, "", false);
			if (string.IsNullOrEmpty(mappingID))
			{
				Debug.LogError("Given mappingID is null or empty", this);
				(Vector3, int, string, bool) tuple2 = tuple;
				return (playerPos: tuple2.Item1, playerRotationY: tuple2.Item2, trackID: tuple2.Item3, reverseTrain: tuple2.Item4);
			}
			Mapping mapping = mappings.FirstOrDefault((Mapping m) => m.id == mappingID);
			if (mapping == null)
			{
				Debug.LogError("There's not mapping for '" + mappingID + "'", this);
				(Vector3, int, string, bool) tuple2 = tuple;
				return (playerPos: tuple2.Item1, playerRotationY: tuple2.Item2, trackID: tuple2.Item3, reverseTrain: tuple2.Item4);
			}
			try
			{
				var (stationData, index) = Map(mapping);
				return (playerPos: stationData.playerAnchorWorldPosition, playerRotationY: stationData.playerAnchorRotation.y, trackID: stationData.trackIds[index], reverseTrain: mapping.reverseTrain);
			}
			catch (ArgumentException ex)
			{
				Debug.LogError(ex.Message, this);
				(Vector3, int, string, bool) tuple2 = tuple;
				return (playerPos: tuple2.Item1, playerRotationY: tuple2.Item2, trackID: tuple2.Item3, reverseTrain: tuple2.Item4);
			}
		}

		public (WorldStationsExtractedData.StationData station, int trackIndex) Map(Mapping mapping)
		{
			foreach (WorldStationsExtractedData.StationData stationsDatum in sourceData.stationsData)
			{
				for (int i = 0; i < stationsDatum.trackIds.Count; i++)
				{
					if (stationsDatum.trackIds[i] == mapping.trackId)
					{
						return (station: stationsDatum, trackIndex: i);
					}
				}
			}
			return (station: null, trackIndex: -1);
		}

		public (int index, Mapping mapping) Unmap(string trackID, bool reverseTrain)
		{
			for (int i = 0; i < mappings.Count; i++)
			{
				Mapping mapping = mappings[i];
				var (stationData, index) = Map(mapping);
				if (stationData.trackIds[index] == trackID && mapping.reverseTrain == reverseTrain)
				{
					return (index: i, mapping: mapping);
				}
			}
			return (index: -1, mapping: null);
		}

		public List<string> Validate()
		{
			List<string> list = new List<string>();
			if (sourceData == null)
			{
				list.Add("sourceData is null");
				return list;
			}
			if (mappings == null || mappings.Count == 0)
			{
				list.Add("mappings list is null or empty");
				return list;
			}
			for (int i = 0; i < mappings.Count; i++)
			{
				Mapping mapping = mappings[i];
				if (mapping == null)
				{
					list.Add($"Mapping at index {i} is null");
					continue;
				}
				if (string.IsNullOrWhiteSpace(mapping.id))
				{
					list.Add($"Mapping at index {i} has empty ID");
				}
				if (string.IsNullOrWhiteSpace(mapping.trackId))
				{
					list.Add($"Mapping at index {i} has empty Track ID");
				}
				var (stationData, num) = Map(mapping);
				if (stationData == null)
				{
					list.Add($"Mapping at index {i} maps to null station");
				}
				else if (num == -1)
				{
					list.Add($"Mapping at index {i} maps to track index -1");
				}
			}
			List<Mapping> list2 = mappings.Where((Mapping m) => m != null).ToList();
			int num2 = list2.Count - list2.Select((Mapping m) => m.id).Distinct().Count();
			if (num2 > 0)
			{
				list.Add($"There are {num2} mappings with duplicate IDs");
			}
			return list;
		}
	}
}
