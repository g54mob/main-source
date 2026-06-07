using System;
using System.Collections.Generic;

namespace Gh.Tk.Story
{
	public static class StoryHelper
	{
		public class InkInstruction
		{
			public string Keyword;

			private Delegate _delegate;

			public InkInstruction(string keyword, Delegate @delegate)
			{
			}

			public void Execute(ActiveStory story, string data)
			{
			}
		}

		private static StoryHelperReferences _refs;

		internal static string _openingTalkTag;

		internal static string _closingTalkTag;

		public const string AnyKeyword = "any";

		private static List<string> _gameItemTemplateIds;

		private static List<string> _unlockableGameItemTemplateIds;

		private static List<string> _weaponTemplateIds;

		private static Dictionary<string, List<string>> _propGroupTypes;

		public const string AnyTapPropOption = "Any Tap";

		public const string AnyBarPropOption = "Any Bar";

		public const string AnyMealProducerOption = "Any Meal Producer Prop";

		public const string AnyTableTaproomPropOption = "Any Table (Taproom)";

		public const string AnyTablePropOption = "Any Table";

		public const string AnyBed = "Any Bed";

		public const string AnyLarderStorageProp = "Any Larder Storage Prop";

		public const string AnyDecorationOption = "Any Decoration";

		public static List<string> GroupPropOptions;

		private static List<string> _defaultStoryGiverPropIds;

		private static Dictionary<string, string> _decoPropCache;

		private static Dictionary<string, string> _creatorCustomTemplatesCache;

		private static Dictionary<string, string> _creatorNameCache;

		private static List<string> _allCraftProcessOptionsCache;

		private static readonly string[] _weatherEffects;

		private static string[] _musicTracks;

		public const string SKILL_TAG_PREFIX = ">>";

		public const int MAX_FATE_PIPS = 12;

		private static Dictionary<string, InkInstruction> _instructions;

		public static List<string> GameItemTemplateIds => null;

		public static List<string> UnlockableGameItemTemplateIds => null;

		public static List<string> WeaponTemplateIds => null;

		public static List<string> TemplateIds => null;

		public static StoryHelperReferences GetRefs()
		{
			return null;
		}

		internal static string[] GetNamedDayCurves()
		{
			return null;
		}

		internal static string[] GetConversationAnimationPresets()
		{
			return null;
		}

		internal static string[] GetPatronTraits()
		{
			return null;
		}

		internal static string[] GetActorTraits()
		{
			return null;
		}

		internal static string[] GetPropTraits()
		{
			return null;
		}

		internal static string[] GetAllUnlockableTraits()
		{
			return null;
		}

		internal static string[] GetStaffTraits()
		{
			return null;
		}

		internal static string[] GetIngredientTraits()
		{
			return null;
		}

		internal static string[] GetMentalBreakTraits()
		{
			return null;
		}

		internal static string[] GetIconsAndIconPresets()
		{
			return null;
		}

		internal static string[] GetIcons()
		{
			return null;
		}

		public static List<string> GetGreenbackRewardIds()
		{
			return null;
		}

		public static List<string> GetZoneIds()
		{
			return null;
		}

		public static StringBuilderPool.DisposableStringBuilder ParseTextVariables(StringBuilderPool.DisposableStringBuilder sb, ActiveStory story)
		{
			return null;
		}

		private static string GetVariableText(ActiveStory story, string key)
		{
			return null;
		}

		public static bool DoesLevelMatch(GameLevel level, bool includeDesignWorkshopAsAnyLevel = false)
		{
			return false;
		}

		public static Actor GetActor(IDataStore dataStore, string dataStoreKey)
		{
			return null;
		}

		public static List<string> GetRaces()
		{
			return null;
		}

		internal static List<string> GetFinanceCategories()
		{
			return null;
		}

		public static string[] GetStarRatingCategories()
		{
			return null;
		}

		public static List<string> GetAllGameItemTemplateIds()
		{
			return null;
		}

		public static List<string> GetAllUnlockableGameItemTemplateIds()
		{
			return null;
		}

		public static List<string> GetAllWeapons()
		{
			return null;
		}

		internal static string[] GetTaxCategories()
		{
			return null;
		}

		private static void CachePropGroupTypes()
		{
		}

		public static IEnumerable<string> GetPropsMatchingGroup(string groupOption)
		{
			return null;
		}

		public static bool DoesPropMatchGroupOption(string groupOption, string propUniqueType)
		{
			return false;
		}

		public static bool FitsPropGroupFilter(Prop prop, string filter)
		{
			return false;
		}

		public static string[] GetAllPropsWithoutConvenientGroupOptions()
		{
			return null;
		}

		public static List<string> GetAllPropOptions()
		{
			return null;
		}

		public static List<string> GetDefaultStoryGiverPropIds()
		{
			return null;
		}

		public static List<string> GetAllPropOptionsWithoutAnyX()
		{
			return null;
		}

		public static List<string> GetAllDecoPropKeys()
		{
			return null;
		}

		public static Dictionary<string, string> GetAllDecoProps()
		{
			return null;
		}

		public static Dictionary<string, string> GetCreatorCustomTemplates()
		{
			return null;
		}

		public static string GetCreatorDecoNameFromKey(string key)
		{
			return null;
		}

		public static string GetCreatorNameFromKey(string key)
		{
			return null;
		}

		public static string GetDecoPropKeyFromName(string name)
		{
			return null;
		}

		public static List<string> GetAllCraftProcessOptions()
		{
			return null;
		}

		public static List<string> GetAllRatingCategories()
		{
			return null;
		}

		public static List<string> GetAllZones()
		{
			return null;
		}

		public static List<string> GetTavernLevelIds()
		{
			return null;
		}

		public static string GetTavernName(string tavernLevelId)
		{
			return null;
		}

		public static List<string> GetAllScheduleItems()
		{
			return null;
		}

		public static List<string> GetAllRoles()
		{
			return null;
		}

		public static List<string> GetAllHeaderImages()
		{
			return null;
		}

		public static List<string> GetAllMailSeals()
		{
			return null;
		}

		public static string[] GetAllPatronNeedTypes()
		{
			return null;
		}

		public static string[] GetSecondaryNeedTypes()
		{
			return null;
		}

		public static List<string> GetAllConversationThemes()
		{
			return null;
		}

		public static List<string> GetConversationThemes()
		{
			return null;
		}

		public static List<string> GetVipConversationThemes()
		{
			return null;
		}

		public static string[] GetAllActorStats()
		{
			return null;
		}

		public static string[] GetAllAiModifierValueComponents()
		{
			return null;
		}

		public static List<string> GetAllItemTypes()
		{
			return null;
		}

		public static List<string> GetAllItemCategories()
		{
			return null;
		}

		public static string[] GetAllWeatherEffects()
		{
			return null;
		}

		public static List<string> GetAllStoryFlags()
		{
			return null;
		}

		public static List<string> GetSpawnableItemsForConversations()
		{
			return null;
		}

		public static string[] GetGenders()
		{
			return null;
		}

		public static string[] GetActorTypes()
		{
			return null;
		}

		public static DataStore GetTargetDataStore(this ActiveStory story, StoryFlagScope scope)
		{
			return null;
		}

		public static string[] GetAllInputPaths()
		{
			return null;
		}

		public static string[] GetAllDialogIds()
		{
			return null;
		}

		public static string[] GetAllMusicTracks()
		{
			return null;
		}

		public static (int, int) CalculateSkillChance(string skill, string difficulty, int seed)
		{
			return default((int, int));
		}

		public static (string, string, string) ParseSkillTag(string fullText)
		{
			return default((string, string, string));
		}

		public static string GetOpeningTalkTag()
		{
			return null;
		}

		public static string GetClosingTalkTag()
		{
			return null;
		}

		public static string[] GetTavernFlagCategories()
		{
			return null;
		}

		public static List<string> GetRandomStoryGroupIds()
		{
			return null;
		}

		public static string[] GetUIThemes()
		{
			return null;
		}

		public static List<string> GetUnlockableDecorationPackIds()
		{
			return null;
		}

		public static IEnumerable<string> GetAllTimelineIcons()
		{
			return null;
		}

		public static string GetIfSceneId(string textKey)
		{
			return null;
		}

		public static string GetTavernNameKey(string levelId)
		{
			return null;
		}

		public static InkInstruction GetInkInstruction(string instructionName)
		{
			return null;
		}

		public static string ParseInstructionName(string tag)
		{
			return null;
		}

		public static void ExecuteInstruction(ActiveStory story, string tag)
		{
		}

		public static void RegisterInstruction(InkInstruction instruction)
		{
		}

		static StoryHelper()
		{
		}
	}
}
