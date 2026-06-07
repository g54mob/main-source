using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gh.Tk
{
	public static class CsvData
	{
		private static class ConfigType
		{
			public const string IngredientConfig = "ingredientConfig";

			public const string ShopItemConfig = "shopItemConfig";

			public const string GameItemConfig = "gameItemConfig";

			public const string WeaponConfig = "weaponConfig";

			public const string LarderBoundGameItemConfig = "larderBoundGameItemConfig";

			public const string FireExtinguisherGameItemConfig = "fireExtinguisherGameItemConfig";

			public const string GiftBoxItemConfig = "giftBoxGameItemConfig";
		}

		public static Dictionary<string, Dictionary<string, string>> raceConfig;

		private static Dictionary<string, Dictionary<string, string>> _propConfigData;

		private static Dictionary<string, Dictionary<string, string>> _decorConfigData;

		public static Dictionary<string, Dictionary<string, string>> levelData;

		private static readonly Dictionary<string, List<Dictionary<string, string>>> ConfigCache;

		internal static Dictionary<string, List<string>> _textData;

		public static Dictionary<string, List<string>> RawTextData => null;

		public static void Init()
		{
		}

		public static void Init(string level)
		{
		}

		private static string ReadTextFile(string path)
		{
			return null;
		}

		public static List<Dictionary<string, string>> LoadListConfigData(string file)
		{
			return null;
		}

		public static Dictionary<string, List<string>> LoadColumnLists(string file)
		{
			return null;
		}

		public static Dictionary<string, Dictionary<string, string>> LoadConfigData(string file)
		{
			return null;
		}

		public static Dictionary<string, Dictionary<string, string>> GetPropConfigData()
		{
			return null;
		}

		public static Dictionary<string, Dictionary<string, string>> GetDecorConfigData()
		{
			return null;
		}

		public static void FlushDecorConfigData()
		{
		}

		public static void CheckDecorConfigWriteable()
		{
		}

		public static void SaveDecorConfigData(Dictionary<string, Dictionary<string, string>> dict)
		{
		}

		private static string EscapeCsvContent(string content)
		{
			return null;
		}

		private static void ApplyConfigurationFiles()
		{
		}

		private static void ApplyMusicTrackData()
		{
		}

		public static void ApplyWorldMapData(WorldmapController worldmapController)
		{
		}

		private static void ApplyLevelData(string level)
		{
		}

		private static void ApplyMerchantConfig()
		{
		}

		public static List<string> GetAllItemTypes()
		{
			return null;
		}

		public static void LoadItemTypeConfig()
		{
		}

		private static List<Dictionary<string, string>> GetConfig(string configType)
		{
			return null;
		}

		public static void LoadGameItemConfiguration()
		{
		}

		private static void LoadGameItemConfiguration(GameController gc, List<string> ids, string configType)
		{
		}

		public static void LoadGazetteData(string level)
		{
		}

		private static void ApplyGazetteMainStories(string fileName, List<GazetteMainStory> mainStories)
		{
		}

		private static void ApplyGazetteSideStories(string fileName, Dictionary<string, List<string>> sideStories)
		{
		}

		private static void ApplyGazetteData(string fileName, List<string> prices)
		{
		}

		public static void ApplyConfigData(object obj, Dictionary<string, string> data)
		{
		}

		private static FieldInfo GetFieldForCsv(this Type type, string name)
		{
			return null;
		}

		private static PropertyInfo GetPropertyForCsv(this Type type, string name)
		{
			return null;
		}

		public static string[] SplitArrayString(string value, bool removeEmpties = false)
		{
			return null;
		}

		public static Dictionary<string, T> ConvertStringToDictionary<T>(string dictString)
		{
			return null;
		}

		public static string ConvertDictionaryToString<T>(Dictionary<string, T> dict)
		{
			return null;
		}

		public static WeightingsProfile ConvertStringToWeightingsProfile(string dictString)
		{
			return null;
		}

		public static bool ContainsTextForKey(string key)
		{
			return false;
		}

		public static IEnumerable<string> GetListForKey(string key)
		{
			return null;
		}

		public static IEnumerable<string> FilterGender(IEnumerable<string> values, string gender)
		{
			return null;
		}

		public static string GetRandomTextForKeyOrDefault(string key, string gender = null)
		{
			return null;
		}

		internal static void ReadTextData()
		{
		}

		public static bool CheckTextLists(Dictionary<string, List<string>> textData, string templatesPrefix, string listsPrefix, bool ignoreUnusedLists = false, string errorLogAddOn = "")
		{
			return false;
		}
	}
}
