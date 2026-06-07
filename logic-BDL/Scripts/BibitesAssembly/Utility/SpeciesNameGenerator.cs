using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using ScriptHelpers;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace Utility
{
	public static class SpeciesNameGenerator
	{
		private static int n;

		private const float DefaultPatronWeight = 1.5f;

		private const int SpeciesInGenusCount = 5;

		private static string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

		public static List<string> latinNames;

		public static string RandomName()
		{
			return RandomUnusedGenus() + " " + RandomUnusedSpecific();
		}

		public static void GenerateNewName(this Species species)
		{
			string genericName = species.genericName;
			if (string.IsNullOrEmpty(genericName))
			{
				species.genericName = RandomUnusedGenus();
			}
			else
			{
				int num = 0;
				Species parentSpecies = species.parentSpecies;
				while (parentSpecies != null && parentSpecies.genericName == genericName && num <= 5)
				{
					num++;
					parentSpecies = parentSpecies.parentSpecies;
				}
				if (num >= 5)
				{
					species.genericName = RandomUnusedGenus();
				}
			}
			species.specificName = RandomUnusedSpecific(species.genericName);
		}

		public static bool GenusIsUsed(string genus)
		{
			return GlobalLineageManager.Instance.recordedSpecies.Any((Species s) => s.genericName == genus);
		}

		public static string RandomUnusedGenus()
		{
			List<Species> recordedSpecies = GlobalLineageManager.Instance.recordedSpecies;
			int num = latinNames.Count * 2;
			string name;
			do
			{
				name = WeightedRandomPatron(4f);
			}
			while (recordedSpecies.Any((Species s) => s.genericName == name) && num-- > 0);
			if (num <= 0)
			{
				return RandomString().Capitalize();
			}
			return name.Capitalize();
		}

		public static string RandomUnusedSpecific(string genus = null)
		{
			IEnumerable<Species> source = GlobalLineageManager.Instance.recordedSpecies.ToList();
			if (genus != null)
			{
				source = source.Where((Species s) => s.genericName == genus);
			}
			int num = latinNames.Count / 2;
			string name;
			do
			{
				name = WeightedRandomPatron().ToLower();
			}
			while (source.Any((Species s) => s.specificName == name) && num-- > 0);
			if (num <= 0)
			{
				return RandomString();
			}
			return name;
		}

		private static string WeightedRandomPatron(float? weight = null)
		{
			float num = 1f - Mathf.Pow(Random.value, weight ?? 1.5f);
			int index = Mathf.Min(Mathf.FloorToInt((float)latinNames.Count * num), latinNames.Count - 1);
			return latinNames[index];
		}

		private static string RandomString(int length = 15)
		{
			string text = "";
			for (int i = 0; i < length; i++)
			{
				text += Random.Range(0, chars.Length);
			}
			return text;
		}
	}
}
