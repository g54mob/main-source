using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using Dorfromantik.CreativeMode;
using UnityEngine;

public class BiomeSectionManager : SectionManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Biome, bool> _003C_003E9__3_0;

		internal bool _003CSetupAvailableBiomes_003Eb__3_0(Biome x)
		{
			return x.IsUnlocked;
		}
	}

	[SerializeField]
	private List<Biome> allAvailableBiomes = new List<Biome>();

	public List<Biome> currentlyAvailableBiomes = new List<Biome>();

	private Dictionary<BiomeId, Biome> biomeById = new Dictionary<BiomeId, Biome>();

	public void SetupAvailableBiomes(List<BiomeId> excludedBiomeIds = null)
	{
		biomeById.Clear();
		foreach (Biome allAvailableBiome in allAvailableBiomes)
		{
			biomeById.Add(allAvailableBiome.Id, allAvailableBiome);
		}
		if (excludedBiomeIds == null)
		{
			currentlyAvailableBiomes = allAvailableBiomes;
			return;
		}
		currentlyAvailableBiomes = new List<Biome>(allAvailableBiomes);
		foreach (BiomeId excludedBiomeId in excludedBiomeIds)
		{
			if (currentlyAvailableBiomes.Count > 1)
			{
				currentlyAvailableBiomes.Remove(biomeById[excludedBiomeId]);
			}
		}
		if (Enumerable.Count(currentlyAvailableBiomes, (Biome x) => x.IsUnlocked) == 0)
		{
			currentlyAvailableBiomes.Add(biomeById[BiomeId.Standard]);
		}
	}

	public void SetupAvailableBiomesFromPlayerPrefs()
	{
		List<BiomeId> excludedBiomeIds = CreativeModeConfiguration.BiomeIdListFromString(PlayerPrefsAccessor.GetString("ExcludedBiomesClassic"));
		SetupAvailableBiomes(excludedBiomeIds);
	}
}
