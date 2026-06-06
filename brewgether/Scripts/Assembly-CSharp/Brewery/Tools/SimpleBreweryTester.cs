using System.Collections.Generic;
using System.Text;
using Brewery.Core;
using Brewery.Data;
using UnityEngine;

namespace Brewery.Tools
{
	public class SimpleBreweryTester : MonoBehaviour
	{
		[Header("Test Data")]
		[SerializeField]
		private BreweryDatabase breweryDatabase;

		[Header("Test Options")]
		[SerializeField]
		private int maxCatalystsPerBrew;

		[SerializeField]
		private int maxCombinationsToTest;

		[ContextMenu("\ud83d\udd25 Generate Thousands of Combinations")]
		public void GenerateThousandsOfCombinations()
		{
		}

		private void TestCombination(BaseType baseType, List<CatalystData> catalysts, List<FactionData> factions, List<LegendaryRecipe> legendaryRecipes, ref int count, ref int legendaryCount, ref float highestPrice, ref BrewingResult mostExpensive, StringBuilder report)
		{
		}

		[ContextMenu("\ud83e\uddea Test Brewing System")]
		public void TestBrewingSystem()
		{
		}

		private void TestBasicBrewing(BaseType baseType, List<CatalystData> catalysts, List<FactionData> factions, List<LegendaryRecipe> legendaryRecipes, StringBuilder report)
		{
		}

		private void TestItemCreation(List<CatalystData> catalysts, List<FactionData> factions, List<LegendaryRecipe> legendaryRecipes, StringBuilder report)
		{
		}

		private List<CatalystData> GetTestCatalysts()
		{
			return null;
		}

		private List<FactionData> GetTestFactions()
		{
			return null;
		}

		private List<LegendaryRecipe> GetTestLegendaryRecipes()
		{
			return null;
		}

		[ContextMenu("\ud83d\udccb List Available Test Data")]
		public void ListAvailableTestData()
		{
		}
	}
}
