using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Brewery.Data
{
	[CreateAssetMenu(fileName = "BreweryDatabase", menuName = "Brewery/Database")]
	public class BreweryDatabase : ScriptableObject
	{
		private static BreweryDatabase m_Instance;

		[Header("Data Collections")]
		[SerializeField]
		private List<CatalystData> m_Catalysts;

		[SerializeField]
		private List<FactionData> m_Factions;

		[SerializeField]
		private List<LegendaryRecipe> m_LegendaryRecipes;

		[Header("Configuration")]
		[SerializeField]
		private string m_ResourcesPath;

		public List<CatalystData> Catalysts => null;

		public List<FactionData> Factions => null;

		public List<LegendaryRecipe> LegendaryRecipes => null;

		public static BreweryDatabase Instance => null;

		public CatalystData GetCatalyst(string id)
		{
			return null;
		}

		public List<CatalystData> GetCatalystsByTag(BrewTag tag)
		{
			return null;
		}

		public List<CatalystData> GetCatalystsByRarity(Rarity rarity)
		{
			return null;
		}

		public FactionData GetFaction(FactionType type)
		{
			return null;
		}

		public List<FactionData> GetFactionsPreferringTag(BrewTag tag)
		{
			return null;
		}

		public List<FactionData> GetFactionsRefusingTag(BrewTag tag)
		{
			return null;
		}

		public LegendaryRecipe GetLegendaryByName(string name)
		{
			return null;
		}

		public List<LegendaryRecipe> GetPossibleLegendaries()
		{
			return null;
		}

		public BrewingResult CalculateBrew(BaseType baseType, List<CatalystData> catalysts)
		{
			return null;
		}

		public Dictionary<FactionType, List<BrewingResult>> FindBestCombinations(int topCount = 3)
		{
			return null;
		}

		public bool ValidateDatabase()
		{
			return false;
		}

		private void OnValidate()
		{
		}
	}
}
