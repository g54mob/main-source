using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class TileGenConfiguration : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public GroupType groupType;

		internal bool _003CGetGroupTypeConfiguration_003Eb__0(GroupTypeConfiguration x)
		{
			return x.groupType == groupType;
		}

		internal bool _003CGetGroupTypeConfiguration_003Eb__1(GroupTypeConfiguration x)
		{
			return x.groupType == groupType;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<TilePresetConfiguration, bool> _003C_003E9__19_0;

		internal bool _003CGetFilteredTilePresets_003Eb__19_0(TilePresetConfiguration x)
		{
			return x.occupiedEdges < 5;
		}
	}

	[SerializeField]
	private float defaultProbability = 10f;

	[SerializeField]
	private bool autoUpdate = true;

	[FormerlySerializedAs("groupTypeProbabilities")]
	public List<GroupTypeConfiguration> globalGroupTypeProbabilities;

	public List<SegmentPresetCollection> segmentPresetCollections;

	public List<TilePresetConfigurationCollection> tilePresetCollections;

	public List<TilePresetConfiguration> allTilePresets;

	public List<SegmentPresetInfo> allSegmentPresets;

	private void OnValidate()
	{
		if (autoUpdate)
		{
			UpdateValues();
		}
	}

	public void UpdateValues()
	{
		UpdateGlobalGroupTypeProbabilities();
		UpdateSegmentProbabilities();
		UpdateTilePresetProbabilities();
		UpdateAllTilePresetsList();
		UpdateAllSegmentsList();
	}

	private void UpdateAllSegmentsList()
	{
		allSegmentPresets.Clear();
		foreach (SegmentPresetCollection segmentPresetCollection in segmentPresetCollections)
		{
			allSegmentPresets.AddRange(segmentPresetCollection.segmentPresets);
		}
	}

	private void UpdateAllTilePresetsList()
	{
		allTilePresets.Clear();
		foreach (TilePresetConfigurationCollection tilePresetCollection in tilePresetCollections)
		{
			if (tilePresetCollection.subCollections != null && tilePresetCollection.subCollections.Count > 0)
			{
				foreach (TilePresetConfigurationSubCollection subCollection in tilePresetCollection.subCollections)
				{
					allTilePresets.AddRange(subCollection.tilePresets);
				}
			}
			else if (tilePresetCollection.tilePresets != null && tilePresetCollection.tilePresets.Count > 0)
			{
				allTilePresets.AddRange(tilePresetCollection.tilePresets);
			}
			else
			{
				Debug.LogError("collection " + tilePresetCollection.name + " has no subCollections and no tilePresets!");
			}
		}
	}

	private void UpdateGlobalGroupTypeProbabilities()
	{
		float num = Randomizer.TotalProbability(globalGroupTypeProbabilities);
		foreach (GroupTypeConfiguration globalGroupTypeProbability in globalGroupTypeProbabilities)
		{
			globalGroupTypeProbability.probabilityInPercent = ((num == 0f) ? 0f : (globalGroupTypeProbability.Probability / num));
			globalGroupTypeProbability._displayProbability = globalGroupTypeProbability.probabilityInPercent * 100f;
		}
	}

	private void UpdateSegmentProbabilities()
	{
		foreach (SegmentPresetCollection segmentPresetCollection in segmentPresetCollections)
		{
			float num = 0f;
			foreach (GroupTypeConfiguration groupTypeProbability in segmentPresetCollection.groupTypeProbabilities)
			{
				num += groupTypeProbability.Probability * GetGroupTypeConfiguration(globalGroupTypeProbabilities, groupTypeProbability.groupType).probabilityInPercent;
			}
			foreach (GroupTypeConfiguration groupTypeProbability2 in segmentPresetCollection.groupTypeProbabilities)
			{
				float probabilityInPercent = GetGroupTypeConfiguration(globalGroupTypeProbabilities, groupTypeProbability2.groupType).probabilityInPercent;
				groupTypeProbability2.probabilityInPercent = ((num == 0f) ? 0f : (groupTypeProbability2.Probability * probabilityInPercent / num));
				groupTypeProbability2._displayProbability = groupTypeProbability2.probabilityInPercent * 100f;
			}
			foreach (SegmentPresetInfo segmentPreset in segmentPresetCollection.segmentPresets)
			{
				float num2 = 0f;
				foreach (GroupTypeConfiguration possibleType in segmentPreset.possibleTypes)
				{
					num2 += possibleType.Probability * GetGroupTypeConfiguration(segmentPresetCollection.groupTypeProbabilities, possibleType.groupType).probabilityInPercent;
				}
				foreach (GroupTypeConfiguration possibleType2 in segmentPreset.possibleTypes)
				{
					float probabilityInPercent2 = GetGroupTypeConfiguration(segmentPresetCollection.groupTypeProbabilities, possibleType2.groupType).probabilityInPercent;
					possibleType2.probabilityInPercent = ((num2 == 0f) ? 0f : (possibleType2.Probability * probabilityInPercent2 / num2));
					possibleType2._displayProbability = possibleType2.probabilityInPercent * 100f;
				}
			}
		}
	}

	private void UpdateTilePresetProbabilities()
	{
		float num = Randomizer.TotalProbability(tilePresetCollections);
		foreach (TilePresetConfigurationCollection tilePresetCollection in tilePresetCollections)
		{
			tilePresetCollection.collectionProbability = ((num == 0f) ? 0f : (tilePresetCollection.Probability / num));
			tilePresetCollection._displayProbability = tilePresetCollection.collectionProbability * 1000f;
			if (tilePresetCollection.subCollections != null && tilePresetCollection.subCollections.Count > 0)
			{
				float num2 = Randomizer.TotalProbability(tilePresetCollection.subCollections);
				foreach (TilePresetConfigurationSubCollection subCollection in tilePresetCollection.subCollections)
				{
					subCollection.subCollectionProbability = ((num2 == 0f) ? 0f : (subCollection.Probability / num2 * tilePresetCollection.collectionProbability));
					subCollection._displayProbability = subCollection.subCollectionProbability * 1000f;
					float num3 = 0f;
					foreach (TilePresetConfiguration tilePreset in subCollection.tilePresets)
					{
						num3 += tilePreset.rawProbability;
					}
					foreach (TilePresetConfiguration tilePreset2 in subCollection.tilePresets)
					{
						tilePreset2.tilePresetProbability = ((num3 * subCollection.subCollectionProbability == 0f) ? 0f : (tilePreset2.rawProbability / num3 * subCollection.subCollectionProbability));
						UpdateTilePresetSegmentProbabilities(tilePreset2);
					}
				}
			}
			else if (tilePresetCollection.tilePresets != null && tilePresetCollection.tilePresets.Count > 0)
			{
				float num4 = 0f;
				foreach (TilePresetConfiguration tilePreset3 in tilePresetCollection.tilePresets)
				{
					num4 += tilePreset3.rawProbability;
				}
				foreach (TilePresetConfiguration tilePreset4 in tilePresetCollection.tilePresets)
				{
					tilePreset4.tilePresetProbability = ((num4 * tilePresetCollection.collectionProbability == 0f) ? 0f : (tilePreset4.rawProbability / num4 * tilePresetCollection.collectionProbability));
					UpdateTilePresetSegmentProbabilities(tilePreset4);
				}
			}
			else
			{
				Debug.LogError("collection " + tilePresetCollection.name + " has no subCollections and no tilePresets");
			}
		}
	}

	private void UpdateTilePresetSegmentProbabilities(TilePresetConfiguration tilePreset)
	{
		tilePreset._displayProbability = tilePreset.tilePresetProbability * 1000f;
		tilePreset.occupiedEdges = 0;
		foreach (SegmentPresetInfo segmentProbability in tilePreset.segmentProbabilities)
		{
			float num = 0f;
			foreach (GroupTypeConfiguration possibleType in segmentProbability.possibleTypes)
			{
				List<GroupTypeConfiguration> segmentGroupTypes = GetSegmentGroupTypes(segmentProbability.segmentType);
				num += possibleType.Probability * GetGroupTypeConfiguration(segmentGroupTypes, possibleType.groupType).probabilityInPercent;
			}
			foreach (GroupTypeConfiguration possibleType2 in segmentProbability.possibleTypes)
			{
				List<GroupTypeConfiguration> segmentGroupTypes2 = GetSegmentGroupTypes(segmentProbability.segmentType);
				float probabilityInPercent = GetGroupTypeConfiguration(segmentGroupTypes2, possibleType2.groupType).probabilityInPercent;
				possibleType2.probabilityInPercent = ((num == 0f) ? 0f : (possibleType2.Probability * probabilityInPercent / num));
				possibleType2._displayProbability = possibleType2.probabilityInPercent * 100f;
			}
			tilePreset.occupiedEdges += segmentProbability.segmentType.edges.Count;
		}
	}

	private GroupTypeConfiguration GetGroupTypeConfiguration(List<GroupTypeConfiguration> availableConfigurations, GroupType groupType)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals3.groupType = groupType;
		if (Enumerable.Count(availableConfigurations, (GroupTypeConfiguration x) => x.groupType == CS_0024_003C_003E8__locals3.groupType) > 0)
		{
			return Enumerable.First(availableConfigurations, (GroupTypeConfiguration x) => x.groupType == CS_0024_003C_003E8__locals3.groupType);
		}
		return null;
	}

	private List<GroupTypeConfiguration> GetSegmentGroupTypes(SegmentType wantedSegmentType)
	{
		foreach (SegmentPresetCollection segmentPresetCollection in segmentPresetCollections)
		{
			foreach (SegmentPresetInfo segmentPreset in segmentPresetCollection.segmentPresets)
			{
				if (segmentPreset.segmentType == wantedSegmentType)
				{
					return segmentPreset.possibleTypes;
				}
			}
		}
		Debug.LogError($"Can't find groupProbabilities for {wantedSegmentType}");
		return null;
	}

	public TilePresetConfiguration GetTilePresetConfiguration(TilePreset referencePreset)
	{
		foreach (TilePresetConfigurationCollection tilePresetCollection in tilePresetCollections)
		{
			if (tilePresetCollection.subCollections != null && tilePresetCollection.subCollections.Count > 0)
			{
				foreach (TilePresetConfigurationSubCollection subCollection in tilePresetCollection.subCollections)
				{
					foreach (TilePresetConfiguration tilePreset in subCollection.tilePresets)
					{
						if (tilePreset.tilePreset.name == referencePreset.name)
						{
							return tilePreset;
						}
					}
				}
				continue;
			}
			if (tilePresetCollection.tilePresets != null && tilePresetCollection.tilePresets.Count > 0)
			{
				foreach (TilePresetConfiguration tilePreset2 in tilePresetCollection.tilePresets)
				{
					if (tilePreset2.tilePreset.name == referencePreset.name)
					{
						return tilePreset2;
					}
				}
				continue;
			}
			return null;
		}
		return null;
	}

	private void ImportProbabilities(string pathWithinPersistenDataPath = "Dorfromantik_TilePresets.csv", int nameColumn = 1, int probabilityValueColumn = 7)
	{
		string[] array = File.ReadAllText(Path.Combine(Application.persistentDataPath, pathWithinPersistenDataPath)).Split("\n"[0]);
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Trim().Split(',');
			if (array2.Length > probabilityValueColumn && array2.Length > nameColumn)
			{
				string text = array2[nameColumn].Trim().Replace(" ", "_");
				if (float.TryParse(array2[probabilityValueColumn].Replace("\"", ""), NumberStyles.Float, new CultureInfo("en-US"), out var result) && !string.IsNullOrWhiteSpace(text))
				{
					dictionary.Add(text, result);
				}
			}
		}
		foreach (TilePresetConfigurationCollection tilePresetCollection in tilePresetCollections)
		{
			float num = 0f;
			if (tilePresetCollection.subCollections != null && tilePresetCollection.subCollections.Count > 0)
			{
				foreach (TilePresetConfigurationSubCollection subCollection in tilePresetCollection.subCollections)
				{
					float num2 = 0f;
					foreach (TilePresetConfiguration tilePreset in subCollection.tilePresets)
					{
						if (!dictionary.ContainsKey(tilePreset.name.Trim()))
						{
							Debug.LogError("no entry found for preset " + tilePreset.name);
							continue;
						}
						float num3 = dictionary[tilePreset.name.Trim()];
						Debug.Log($"detected probability for preset {tilePreset.name}: {num3}");
						tilePreset.rawProbability = num3;
						num2 += num3;
						num += num3;
					}
					subCollection.subCollectionRawProbability = num2;
					Debug.Log($"detected probability for {subCollection.name}: {num2}");
				}
			}
			else
			{
				foreach (TilePresetConfiguration tilePreset2 in tilePresetCollection.tilePresets)
				{
					if (!dictionary.ContainsKey(tilePreset2.name.Trim()))
					{
						Debug.LogError($"no entry found for preset {tilePreset2}");
						continue;
					}
					float num4 = dictionary[tilePreset2.name.Trim()];
					Debug.Log($"detected probability for preset {tilePreset2.name}: {num4}");
					tilePreset2.rawProbability = num4;
					num += num4;
				}
			}
			tilePresetCollection.collectionRawProbability = num;
			Debug.Log($"detected probability for {tilePresetCollection.name}: {num}");
		}
		UpdateValues();
	}

	public List<TilePresetConfiguration> GetFilteredTilePresets(TileGenFilter usedFilter)
	{
		if (usedFilter == TileGenFilter.AtLeastTwoEmptyEdges)
		{
			return Enumerable.ToList(Enumerable.Where(allTilePresets, (TilePresetConfiguration x) => x.occupiedEdges < 5));
		}
		return allTilePresets;
	}
}
