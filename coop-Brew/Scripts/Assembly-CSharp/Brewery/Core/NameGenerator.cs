using System.Collections.Generic;
using Brewery.Data;
using UnityEngine;

namespace Brewery.Core
{
	public static class NameGenerator
	{
		private static string[] _vulgarPrefixes;

		private static string[] _lacedPrefixes;

		private static string[] _weedPrefixes;

		private static Dictionary<BrewTag, string[]> _normalPrefixes;

		private static Dictionary<BaseType, string[]> _baseNouns;

		private static Dictionary<string, string[]> _vulgarCombos;

		private static bool _cacheInitialized;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Init()
		{
		}

		public static void InvalidateCache()
		{
		}

		private static void EnsureCache()
		{
		}

		public static string GenerateName(BaseType baseType, BrewTag tags, LegendaryRecipe legendary = null)
		{
			return null;
		}

		private static string GetVulgarComboName(BrewTag tags, BaseType baseType)
		{
			return null;
		}

		private static string GetNormalPrefix(List<BrewTag> activeTags, BrewTag allTags)
		{
			return null;
		}

		private static string GetNoun(BaseType baseType, BrewTag tags)
		{
			return null;
		}

		private static string GetRandomFromArray(string[] array, BrewTag tags)
		{
			return null;
		}

		private static int GetDeterministicHash(BrewTag tags)
		{
			return 0;
		}

		private static List<BrewTag> GetActiveTags(BrewTag tags)
		{
			return null;
		}

		private static string GetSimpleName(BaseType baseType)
		{
			return null;
		}

		public static string GenerateDescription(BaseType baseType, BrewTag tags, List<CatalystData> catalysts)
		{
			return null;
		}

		private static string GetQualityAdjective(List<BrewTag> tags)
		{
			return null;
		}

		private static string GetFlavorDescription(List<BrewTag> tags)
		{
			return null;
		}
	}
}
