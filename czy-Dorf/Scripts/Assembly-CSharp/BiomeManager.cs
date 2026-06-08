using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public class BiomeManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<KeyValuePair<BiomeObjectConfiguration, float>, bool> _003C_003E9__12_0;

		public static Func<KeyValuePair<BiomeObjectConfiguration, float>, BiomeObjectConfiguration> _003C_003E9__12_1;

		public static Func<KeyValuePair<BiomeObjectConfiguration, float>, float> _003C_003E9__12_2;

		internal bool _003CApplyBiomeToObject_003Eb__12_0(KeyValuePair<BiomeObjectConfiguration, float> x)
		{
			return x.Key.visual == finalConfiguration.visual;
		}

		internal BiomeObjectConfiguration _003CApplyBiomeToObject_003Eb__12_1(KeyValuePair<BiomeObjectConfiguration, float> x)
		{
			return x.Key;
		}

		internal float _003CApplyBiomeToObject_003Eb__12_2(KeyValuePair<BiomeObjectConfiguration, float> x)
		{
			return x.Value;
		}
	}

	[SerializeField]
	private List<Biome> biomes;

	[SerializeField]
	private BiomeSectionManager biomeSectionManager;

	[SerializeField]
	private Vector2Int biomeBorder = new Vector2Int(5, 5);

	[SerializeField]
	private int biomeTransitionRange = 4;

	public Action<Dictionary<Biome, float>> OnFocusBiomeUpdated;

	private static Dictionary<BiomeObjectConfiguration, float> blendedConfigurations = new Dictionary<BiomeObjectConfiguration, float>();

	private static Dictionary<string, Dictionary<object, float>> valuesToBlendByKey = new Dictionary<string, Dictionary<object, float>>();

	private static Dictionary<string, Dictionary<BiomeEffectValue, float>> effectValuesByKey = new Dictionary<string, Dictionary<BiomeEffectValue, float>>();

	private static BiomeObjectConfiguration finalConfiguration = new BiomeObjectConfiguration();

	public void ApplyBiome(Tile tileToUpdate, Biome overwriteBiome = null)
	{
		Dictionary<Biome, float> dictionary = new Dictionary<Biome, float>();
		dictionary = ((!(overwriteBiome != null)) ? DetermineBiomeInfluence(tileToUpdate.GridPos) : new Dictionary<Biome, float> { { overwriteBiome, 1f } });
		ApplyBiomesToTile(tileToUpdate, dictionary);
	}

	public static void ApplyBiomeToTile(Tile tile, Biome biome, SessionQuestReward filterReward = null, bool forceApplyingBiome = false)
	{
		ApplyBiomesToTile(tile, new Dictionary<Biome, float> { { biome, 1f } }, filterReward, forceApplyingBiome);
	}

	public static void ApplyBiomesToTile(Tile tile, Dictionary<Biome, float> biomeInfluence, SessionQuestReward filterReward = null, bool forceApplyingBiome = false)
	{
		if (!forceApplyingBiome && ListHelper.Equals(biomeInfluence, tile.CurrentBiomeInfluence))
		{
			return;
		}
		tile.SetBiomeInfluence(biomeInfluence);
		ApplyBiomeToObject(tile.TileVisual, biomeInfluence);
		if (tile is QuestTile questTile)
		{
			ApplyBiomeToObject(questTile.QuestGiver, biomeInfluence, filterReward);
		}
		foreach (ElementGroupSegment allElementGroupSegment in tile.AllElementGroupSegments)
		{
			if (allElementGroupSegment.InstanceableSegmentGround.isInitialized)
			{
				ApplyBiomeToObject(allElementGroupSegment.InstanceableSegmentGround, biomeInfluence, filterReward);
			}
			else if ((bool)allElementGroupSegment.SegmentFloor)
			{
				ApplyBiomeToObject(allElementGroupSegment.SegmentFloor, biomeInfluence, filterReward);
			}
			foreach (Element allElement in allElementGroupSegment.AllElements)
			{
				ApplyBiomeToObject(allElement, biomeInfluence, filterReward);
			}
			foreach (InstanceableVisual allElementDatum in allElementGroupSegment.AllElementData)
			{
				ApplyBiomeToObject(allElementDatum, biomeInfluence, filterReward);
				foreach (InstanceableVisual subInstanceable in allElementDatum.SubInstanceables)
				{
					ApplyBiomeToObject(subInstanceable, biomeInfluence, filterReward);
				}
			}
		}
		foreach (Element item in tile.Decoration)
		{
			if (!(item is DecorationElement { ShouldUpdateBiome: false, HasBiomeConfiguration: not false }))
			{
				ApplyBiomeToObject(item, biomeInfluence, filterReward);
			}
		}
		foreach (InstanceableVisual item2 in tile.InstanceableDecoration)
		{
			ApplyBiomeToObject(item2, biomeInfluence, filterReward);
		}
	}

	public static void ApplyBiomeToObject(IBiomeAffectedObject targetObject, Dictionary<Biome, float> biomeInfluence, SessionQuestReward filterReward = null)
	{
		finalConfiguration.Clear();
		blendedConfigurations.Clear();
		finalConfiguration.biomeInfluence = biomeInfluence;
		foreach (KeyValuePair<Biome, float> item in biomeInfluence)
		{
			BiomeObjectConfiguration biomeObjectConfiguration = item.Key.GetBiomeObjectConfiguration(targetObject, filterReward);
			if (biomeObjectConfiguration != null)
			{
				blendedConfigurations.Add(biomeObjectConfiguration, item.Value);
			}
		}
		if (blendedConfigurations.Count == 0)
		{
			return;
		}
		UnityEngine.Random.InitState(targetObject.Seed);
		BiomeObjectConfiguration biomeObjectConfiguration2 = Randomizer.SelectWeightedRandom(blendedConfigurations);
		finalConfiguration.visual = biomeObjectConfiguration2.visual;
		blendedConfigurations = Enumerable.ToDictionary(Enumerable.Where(blendedConfigurations, (KeyValuePair<BiomeObjectConfiguration, float> x) => x.Key.visual == finalConfiguration.visual), (KeyValuePair<BiomeObjectConfiguration, float> x) => x.Key, (KeyValuePair<BiomeObjectConfiguration, float> x) => x.Value);
		valuesToBlendByKey.Clear();
		effectValuesByKey.Clear();
		foreach (KeyValuePair<BiomeObjectConfiguration, float> blendedConfiguration in blendedConfigurations)
		{
			foreach (KeyValuePair<string, object> biomeValue in blendedConfiguration.Key.biomeValues)
			{
				if (!valuesToBlendByKey.ContainsKey(biomeValue.Key))
				{
					valuesToBlendByKey.Add(biomeValue.Key, new Dictionary<object, float>());
				}
				if (!valuesToBlendByKey[biomeValue.Key].ContainsKey(biomeValue.Value))
				{
					valuesToBlendByKey[biomeValue.Key].Add(biomeValue.Value, 0f);
				}
				valuesToBlendByKey[biomeValue.Key][biomeValue.Value] += blendedConfiguration.Value;
			}
			foreach (BiomeEffectValue biomeEffectValue2 in blendedConfiguration.Key.biomeEffectValues)
			{
				if (!effectValuesByKey.ContainsKey(biomeEffectValue2.key))
				{
					effectValuesByKey.Add(biomeEffectValue2.key, new Dictionary<BiomeEffectValue, float>());
				}
				effectValuesByKey[biomeEffectValue2.key].Add(biomeEffectValue2, blendedConfiguration.Value);
			}
		}
		foreach (KeyValuePair<string, Dictionary<object, float>> item2 in valuesToBlendByKey)
		{
			object obj = Enumerable.ToList(item2.Value.Keys)[0];
			float num = 0f;
			object value = null;
			if (obj is float)
			{
				float num2 = 0f;
				foreach (KeyValuePair<object, float> item3 in item2.Value)
				{
					float num3 = (float)item3.Key;
					num2 += item3.Value * num3;
					num += item3.Value;
				}
				value = num2 / num;
			}
			finalConfiguration.biomeValues.Add(item2.Key, value);
		}
		foreach (KeyValuePair<string, Dictionary<BiomeEffectValue, float>> item4 in effectValuesByKey)
		{
			BiomeEffectValue biomeEffectValue = Enumerable.ToList(item4.Value.Keys)[0];
			object value2 = biomeEffectValue.value;
			float num4 = 0f;
			object value3 = null;
			if (value2 is Color)
			{
				Color black = Color.black;
				foreach (KeyValuePair<BiomeEffectValue, float> item5 in item4.Value)
				{
					if (item5.Key.rendererIndices == null)
					{
						Debug.LogError($"{targetObject} has null as rendererIndices");
					}
					if (item5.Key.rendererIndices.Count != biomeEffectValue.rendererIndices.Count)
					{
						Debug.LogError("blending between " + ListHelper.ListDebugString(Enumerable.ToList(biomeInfluence.Keys)));
						Debug.LogError($"different renderer indices for object {targetObject}!" + "\n" + biomeEffectValue.key + " rendererIndices " + ListHelper.ListDebugString(biomeEffectValue.rendererIndices) + "\n" + item5.Key.key + " rendererIndex " + ListHelper.ListDebugString(item5.Key.rendererIndices));
					}
					Color color = (Color)item5.Key.value;
					black += item5.Value * color;
					num4 += item5.Value;
				}
				value3 = black / num4;
			}
			if (value2 is Texture)
			{
				value3 = Randomizer.SelectWeightedRandom(item4.Value).value;
			}
			if (value2 is float)
			{
				float num5 = 0f;
				foreach (KeyValuePair<BiomeEffectValue, float> item6 in item4.Value)
				{
					float num6 = (float)item6.Key.value;
					num5 += item6.Value * num6;
					num4 += item6.Value;
				}
				value3 = num5 / num4;
			}
			finalConfiguration.biomeEffectValues.Add(new BiomeEffectValue(item4.Key, value3, biomeEffectValue.rendererIndices));
		}
		targetObject.ApplyBiomeConfiguration(finalConfiguration);
		Randomizer.RandomizeSeed();
	}

	public Dictionary<Biome, float> DetermineBiomeInfluence(Vector2Int gridPos, bool createSections = true, bool includeEmptySections = true)
	{
		new Dictionary<Biome, float>();
		Vector3 worldPos = GridCalculator.GridToWorldPos(gridPos);
		return DetermineBiomeInfluence(worldPos, createSections, includeEmptySections);
	}

	public Dictionary<Biome, float> DetermineBiomeInfluence(Vector3 worldPos, bool createSections, bool includeEmptySections = true)
	{
		Dictionary<Biome, float> dictionary = new Dictionary<Biome, float>();
		foreach (KeyValuePair<Section, float> item in biomeSectionManager.GetSectionInfluence(worldPos, createSections, includeEmptySections))
		{
			Biome biome = ((Section_Biome)item.Key).Biome;
			if (!dictionary.ContainsKey(biome))
			{
				dictionary.Add(biome, 0f);
			}
			dictionary[biome] += item.Value;
		}
		return dictionary;
	}

	public void Debug_OverrideBiomes(Biome previewBiome)
	{
		biomes = new List<Biome> { previewBiome, previewBiome, previewBiome, previewBiome };
	}

	public void SetBiomes(Biome seBiome, Biome swBiome, Biome neBiome, Biome nwBiome)
	{
		biomes = new List<Biome> { seBiome, swBiome, neBiome, nwBiome };
	}

	public List<Biome> GetBiomes()
	{
		return biomes;
	}
}
