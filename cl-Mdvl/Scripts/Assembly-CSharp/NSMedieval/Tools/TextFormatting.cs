using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.WorldMap;
using UI.Enums;
using UnityEngine;

namespace NSMedieval.Tools
{
	public static class TextFormatting
	{
		private static StringBuilder stringBuilderGender = new StringBuilder(2000);

		private static Dictionary<LinkType, Regex> linkTypeRegexPatterns;

		private static int randomWorkerCounter;

		private static bool linkTypeTermInit;

		private static Dictionary<string, LinkType> linkTypeTermCache;

		private const string SquareBracketsRegexPattern = "(\\[)(.|.[^\\/]+)(\\/)(.|.[^\\]]+)(\\])";

		private const string HashtagIndexRegexPattern = "(\\#\\d*)((\\[)(.|.[^\\]+)(\\)(.|.[^\\]]+)(\\]))";

		private const string ParenthesisRegexPattern = "(\\()([\\w\\d\\s\\S]*)(\\))";

		private const string FilenameRegexPattern = "([a-zA-Z]+?\\.cs:\\d*)";

		private static readonly Regex FormatSquareBracketsRegex = new Regex("(\\[)(.|.[^\\/]+)(\\/)(.|.[^\\]]+)(\\])");

		private static readonly Regex FormatSHashtagIndexRegex = new Regex("(\\#\\d*)((\\[)(.|.[^\\]+)(\\)(.|.[^\\]]+)(\\]))");

		private static readonly Regex FormatParenthesisRegex = new Regex("(\\()([\\w\\d\\s\\S]*)(\\))");

		private static readonly Regex FormatFilenameRegex = new Regex("([a-zA-Z]+?\\.cs:\\d*)");

		private static VillageSaveData VillageSave => GlobalSaveController.CurrentVillageData ?? GlobalSaveController.CurrentVillageData;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			linkTypeRegexPatterns = null;
			linkTypeTermCache = null;
			randomWorkerCounter = 0;
			linkTypeTermInit = false;
			stringBuilderGender = new StringBuilder(2000);
		}

		public static string HighlightOccurrences(string str, string pattern, string color = "yellow")
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (true)
			{
				int num2 = str.IndexOf(pattern, num, StringComparison.InvariantCultureIgnoreCase);
				if (num2 < 0)
				{
					break;
				}
				if (num2 > num)
				{
					stringBuilder.Append(str.Substring(num, num2 - num));
				}
				stringBuilder.Append("<color=" + color + ">");
				stringBuilder.Append(str.Substring(num2, pattern.Length));
				stringBuilder.Append("</color>");
				num = num2 + pattern.Length;
			}
			stringBuilder.Append(str.Substring(num));
			return stringBuilder.ToString();
		}

		public static string GetCheckmarkIcon(bool checkmarkChecked)
		{
			return AssetUtils.GetSpriteAsset(checkmarkChecked ? "checkmark_yes" : "checkmark_no");
		}

		public static string FormatText(string text)
		{
			return FormatText(text, (HumanoidInstance)null);
		}

		public static string FormatText(string text, BodyType bodyType)
		{
			return FormatTextForGender(text, bodyType);
		}

		public static string FormatText(string text, CharacterInfoBase characterInfo)
		{
			return FormatCharacterTextVariables(text, characterInfo);
		}

		public static string FormatText(string text, HumanoidInstance humanoid)
		{
			return FormatWorkerTextVariables(text, humanoid);
		}

		public static string FormatText(string text, WorldMapPlace place)
		{
			if (!text.Contains("<"))
			{
				return text;
			}
			return text.Replace("<village_name>", (place != null) ? place.Name : string.Empty).Replace("<faction_name>", (place?.FactionInstance != null) ? place.FactionInstance.NameLocalized : string.Empty);
		}

		public static string RemoveTextInXmlTag(string startTag, string endTag, string text)
		{
			while (true)
			{
				int num = text.IndexOf(startTag, StringComparison.Ordinal);
				if (num < 0)
				{
					break;
				}
				if (num >= 1 && text[num - 1] == '\n')
				{
					num--;
				}
				int num2 = text.IndexOf(endTag, num, StringComparison.Ordinal);
				if (num2 < 0)
				{
					break;
				}
				if (text.Length < num2 - 1 && text[num2] == '\n')
				{
					num2++;
				}
				text = text.Remove(num, num2 + endTag.Length - num);
			}
			return text;
		}

		private static string HandleXmlTag(string text, string xmlTag, bool leaveTextInTags)
		{
			string text2 = xmlTag.Replace("<", "</");
			if (!leaveTextInTags)
			{
				return RemoveTextInXmlTag(xmlTag, text2, text);
			}
			return text.Replace(xmlTag, string.Empty).Replace(text2, string.Empty);
		}

		public static string FormatRaidText(string text, ActiveRaidInfo raidInfo)
		{
			string allVillagers = GetAllVillagers();
			string tailSeparator = " " + MonoSingleton<LocalizationController>.Instance.GetText("list_and") + " ";
			string text2 = MonoSingleton<LocalizationController>.Instance.GetText("general_" + VillageSave.DateAndTime.Season.Name.ToLower());
			List<string> source = raidInfo.BuildingsDestroyed.Distinct().ToList();
			source = source.Select(BuildingUtils.GetLocalizedName).ToList();
			string newValue = ((source.Count > 0) ? source.Aggregate((string item1, string item2) => item1 + ", " + item2) : string.Empty);
			string durationString = GetDurationString(raidInfo);
			string newValue2 = ((raidInfo.WorkersAttacked.Count == 0) ? string.Empty : raidInfo.WorkersAttacked.Aggregate((KeyValuePair<string, float> x, KeyValuePair<string, float> y) => (!(x.Value > y.Value)) ? y : x).Key);
			string newValue3 = ((raidInfo.DamageTaken.Count == 0) ? string.Empty : raidInfo.DamageTaken.Aggregate((KeyValuePair<string, float> x, KeyValuePair<string, float> y) => (!(x.Value > y.Value)) ? y : x).Key);
			string newValue4 = ((raidInfo.HitsBlocked.Count == 0) ? string.Empty : raidInfo.HitsBlocked.Aggregate((KeyValuePair<string, float> x, KeyValuePair<string, float> y) => (!(x.Value > y.Value)) ? y : x).Key);
			text = HandleXmlTag(text, "<if_all_villagers_survived>", raidInfo.WorkersDied.Count == 0);
			text = HandleXmlTag(text, "<if_not_all_villagers_survived>", raidInfo.WorkersDied.Count != 0);
			text = HandleXmlTag(text, "<if_enemy_died>", raidInfo.EnemiesDied.Count != 0);
			text = HandleXmlTag(text, "<if_no_enemy_died>", raidInfo.EnemiesDied.Count == 0);
			text = HandleXmlTag(text, "<if_most_active_in_fight>", raidInfo.WorkersAttacked.Count != 0);
			text = HandleXmlTag(text, "<if_no_most_active_in_fight>", raidInfo.WorkersAttacked.Count == 0);
			text = HandleXmlTag(text, "<if_most_damage_taken>", raidInfo.DamageTaken.Count != 0);
			text = HandleXmlTag(text, "<if_no_most_damage_taken>", raidInfo.DamageTaken.Count == 0);
			text = HandleXmlTag(text, "<if_most_hits_blocked>", raidInfo.HitsBlocked.Count != 0);
			text = HandleXmlTag(text, "<if_no_most_hits_blocked>", raidInfo.HitsBlocked.Count == 0);
			text = HandleXmlTag(text, "<if_buildings_destroyed>", raidInfo.BuildingsDestroyed.Count != 0);
			text = HandleXmlTag(text, "<if_no_buildings_destroyed>", raidInfo.BuildingsDestroyed.Count == 0);
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("<village_name>", HighlightBlue(VillageSave.Name)).Replace("<year>", HighlightBlue(VillageSave.DateAndTime.Year.ToString())).Replace("<season>", text2)
				.Replace("<villagers_died>", GetNamesList(raidInfo.WorkersDied, ", ", tailSeparator))
				.Replace("<villagers_died_count>", raidInfo.WorkersDied.Count.ToString())
				.Replace("<villagers_survived>", allVillagers)
				.Replace("<villagers_survived_count>", VillageSave.Workers.Count.ToString())
				.Replace("<enemy_dead>", GetNamesList(raidInfo.EnemiesDied, ", ", tailSeparator))
				.Replace("<enemy_dead_count>", raidInfo.EnemiesDied.Count.ToString())
				.Replace("<enemy_survived>", GetNamesList(raidInfo.EnemiesSurvived, ", ", tailSeparator))
				.Replace("<enemy_survived_count>", raidInfo.EnemiesSurvived.Count.ToString())
				.Replace("<buildings_destroyed>", newValue)
				.Replace("<raid_duration>", durationString)
				.Replace("<most_active_in_fight>", newValue2)
				.Replace("<most_damage_taken>", newValue3)
				.Replace("<most_hits_blocked>", newValue4);
			return stringBuilder.ToString();
		}

		public static string GetDurationString(ActiveRaidInfo raidInfo)
		{
			return UiUtils.GetTimeFormatByMinutes(GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal - raidInfo.StartTime, isDuration: true);
		}

		public static string GetNamesList(IReadOnlyList<string> list, string separator, string tailSeparator)
		{
			return JoinStringList(list, list.Count, separator, tailSeparator);
		}

		public static string JoinStringList(IEnumerable<string> list, int listCount, string separator, string tailSeparator)
		{
			switch (listCount)
			{
			case 0:
				return string.Empty;
			case 1:
				return list.First();
			default:
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = listCount - 2;
				int num2 = 0;
				foreach (string item in list)
				{
					stringBuilder.Append(item);
					if (num2 < listCount - 1)
					{
						stringBuilder.Append((num2 == num) ? tailSeparator : separator);
					}
					num2++;
				}
				return stringBuilder.ToString();
			}
			}
		}

		public static string FormatRandomWorkerText(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			text = text.Replace("<random_villager>", "<name>");
			return FormatWorkerTextVariables(text, GetNextWorker());
		}

		public static string FormatBirthdayText(string text, string season, int birthday, int age)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("<age>", $"{age}");
			stringBuilder.Replace("<birthday>", $"{birthday}");
			stringBuilder.Replace("<season>", season);
			return stringBuilder.ToString();
		}

		public static string FormatPseudonymText(string text, string pseudonym, HumanoidInstance humanoidInstance)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("<pseudonym>", pseudonym);
			stringBuilder.Replace("<origin>", humanoidInstance.Info.OriginTown);
			return stringBuilder.ToString();
		}

		public static string FormatAnimalTrainingText(string text, string workerName, string animalName)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("<settler>", workerName);
			stringBuilder.Replace("<animal_name>", animalName);
			return stringBuilder.ToString();
		}

		public static string FormatAnimalTamingText(string text, string workerName, string animalTypeName)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("<settler>", workerName);
			stringBuilder.Replace("<animal>", animalTypeName);
			return stringBuilder.ToString();
		}

		public static string FormatEquippedDestroyed(string text, string workerName, string equipmentName)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("<settler>", "<Style=DefaultOrange>" + workerName + "</style>");
			stringBuilder.Replace("<equipment>", "<Style=DefaultOrange>" + equipmentName + "</style>");
			return stringBuilder.ToString();
		}

		public static string GetErrorFilename(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return "unknown";
			}
			MatchCollection matchCollection = FormatFilenameRegex.Matches(str);
			if (matchCollection.Count > 0 && matchCollection[0] != null)
			{
				return matchCollection[0].Value;
			}
			string text = str.Split('\r', '\n').FirstOrDefault();
			if (string.IsNullOrEmpty(text))
			{
				return "unknown";
			}
			int num = text.IndexOf('(');
			if (num > 0)
			{
				text = text.Substring(0, num);
			}
			return text;
		}

		public static string GetBackgroundName(string backstoryName, string backgroundName, bool genderIsMale, string spaceChar)
		{
			backstoryName = FormatGenderSquareBrackets(backstoryName, genderIsMale);
			backgroundName = FormatGenderSquareBrackets(backgroundName, genderIsMale);
			MatchCollection matchCollection = FormatParenthesisRegex.Matches(backstoryName);
			if (matchCollection.Count >= 1)
			{
				return backgroundName + spaceChar + matchCollection[0].Groups[2].Value;
			}
			return backstoryName + spaceChar + backgroundName;
		}

		public static string ParsedTerm(string term)
		{
			StringBuilder stringBuilder = new StringBuilder(term);
			stringBuilder.Replace("\\'", "'").Replace("\\n", "\n").Replace("\\b", "\b")
				.Replace("\\r", "\r")
				.Replace("\\t", "\t")
				.Replace("\\0", "\0");
			return FormatLinks(stringBuilder.ToString());
		}

		public static string FormatNewLines(string textLine, int maxCharacters)
		{
			string text = textLine;
			List<string> list = ListPool<string>.Get();
			int num;
			Regex regex;
			do
			{
				num = text.IndexOf("<", StringComparison.Ordinal);
				if (num != -1)
				{
					list.Add(text.Substring(num, text.IndexOf(">", StringComparison.Ordinal) - num + 1));
					regex = new Regex(Regex.Escape(list[list.Count - 1]));
					text = regex.Replace(text, "$", 1);
				}
			}
			while (num != -1);
			for (int num2 = GetLineEnd(maxCharacters, text, maxCharacters); num2 < text.Length; num2 = GetLineEnd(num2 + maxCharacters, text, maxCharacters))
			{
				int num3 = text.LastIndexOf(" ", num2, maxCharacters, StringComparison.Ordinal);
				if (num3 > 0)
				{
					text = text.Insert(num3, "\n");
					num2 += 2;
				}
			}
			regex = new Regex(Regex.Escape("$"));
			foreach (string item in list)
			{
				text = regex.Replace(text, item, 1);
			}
			ListPool<string>.Return(list);
			return text;
			static int GetLineEnd(int num4, string t, int max)
			{
				while (num4 < t.Length && t.LastIndexOf("\n", num4, max, StringComparison.Ordinal) != -1)
				{
					num4 = t.LastIndexOf("\n", num4, max, StringComparison.Ordinal) + max + 2;
				}
				return num4;
			}
		}

		public static string FormatKeyInputEvent(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(text);
			int startIndex = 0;
			while (true)
			{
				int num = stringBuilder.ToString().IndexOf("<input:", startIndex, StringComparison.Ordinal);
				if (num == -1)
				{
					break;
				}
				int num2 = num + "<input:".Length;
				int num3 = stringBuilder.ToString().IndexOf(">", num2, StringComparison.Ordinal);
				if (num3 == -1)
				{
					break;
				}
				string text2 = stringBuilder.ToString().Substring(num2, num3 - num2);
				if (!Enum.TryParse<KeyInputEvent>(text2, out var result))
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\TextFormatting.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Invalid key ");
						messageBuilder.AppendFormatted(text2);
						messageBuilder.AppendLiteral(" in text: ");
						messageBuilder.AppendFormatted(text);
					}
					Log.Error(messageBuilder);
					startIndex = num3 + 1;
				}
				else
				{
					string text3 = MonoSingleton<LocalizationController>.Instance.GetText("keycode_" + MonoSingleton<GlobalSaveController>.Instance.GetKeyCode(result));
					string text4 = stringBuilder.ToString().Substring(num, num3 - num + 1);
					stringBuilder.Remove(num, text4.Length);
					stringBuilder.Insert(num, text3);
					startIndex = num + text3.Length;
				}
			}
			Log.Debug(stringBuilder.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\TextFormatting.cs");
			return stringBuilder.ToString();
		}

		public static string Join(List<string> list, char delimiter = ',')
		{
			if (list.Count <= 1)
			{
				return list.FirstOrDefault();
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				stringBuilder.Append(list[i]);
				if (i < list.Count - 1)
				{
					stringBuilder.Append(delimiter);
					stringBuilder.Append(" ");
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetFormatedItemCount(int count, string name)
		{
			return GetFormatedItemCount(count.ToString(CultureInfo.CurrentCulture), name);
		}

		public static string GetFormatedItemCount(float count, string name)
		{
			return GetFormatedItemCount(count.ToString(CultureInfo.CurrentCulture), name);
		}

		public static string GetFormatedItemCount(string count, string name)
		{
			Language currentLanguageEnum = MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum();
			if (currentLanguageEnum != Language.Chinese && currentLanguageEnum != Language.Korean)
			{
				return count + "x " + name;
			}
			return name + " x " + count;
		}

		public static string GetFormatedXpAmountUp(int amount, string xpLocalized)
		{
			Language currentLanguageEnum = MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum();
			if (currentLanguageEnum != Language.Chinese && currentLanguageEnum != Language.Korean)
			{
				return $"+{amount} {xpLocalized}";
			}
			return $"{xpLocalized} +{amount}";
		}

		private static string RemoveSentenceWith(string text, string wordToRemove)
		{
			string pattern = "[^.?!\\n\\r\\t]*(?<=[.?\\s!])" + wordToRemove + "(?=[\\s.?!])[^.?!]*[.?!]";
			MatchCollection matchCollection = Regex.Matches(text, pattern, RegexOptions.Multiline);
			StringBuilder stringBuilder = new StringBuilder(text);
			for (int num = matchCollection.Count - 1; num >= 0; num--)
			{
				if (matchCollection[num].Success)
				{
					stringBuilder.Remove(matchCollection[num].Index, matchCollection[num].Length);
				}
			}
			return stringBuilder.ToString();
		}

		private static HumanoidInstance GetNextWorker()
		{
			List<HumanoidInstance> workers = VillageSave.Workers;
			if (workers.Count == 0)
			{
				return null;
			}
			return workers[randomWorkerCounter++ % workers.Count];
		}

		private static string FormatCharacterTextVariables(string textToFormat, CharacterInfoBase info)
		{
			StringBuilder stringBuilder = new StringBuilder(textToFormat);
			stringBuilder.Replace("<age>", info.Age.ToString());
			stringBuilder.Replace("<name>", HighlightOrange(info.FirstName));
			stringBuilder.Replace("<surname>", HighlightOrange(info.LastName));
			return FormatTextVariables(FormatTextForGender(stringBuilder.ToString(), info.BodyType));
		}

		private static string FormatWorkerTextVariables(string textToFormat, HumanoidInstance humanoid)
		{
			string text = textToFormat;
			if (humanoid == null)
			{
				return FormatTextVariables(text);
			}
			if (!text.Contains('<'))
			{
				return FormatTextForGender(text, humanoid.Info.BodyType);
			}
			HumanoidInfo info = humanoid.Info;
			LocalizationController instance = MonoSingleton<LocalizationController>.Instance;
			string text2 = instance.GetText(info.BackgroundId + "_name");
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("<age>", info.Age.ToString());
			stringBuilder.Replace("<name>", HighlightOrange(info.FirstName));
			stringBuilder.Replace("<surname>", HighlightOrange(info.LastName));
			stringBuilder.Replace("<origin>", HighlightBlue(info.OriginTown));
			stringBuilder.Replace("<background>", HighlightOrange(text2));
			if (info.PseudonymId.Length > 0)
			{
				stringBuilder.Replace("<pseudonym>", HighlightOrange("The " + instance.GetText(info.PseudonymId + "_name")));
				text = stringBuilder.ToString();
			}
			else
			{
				text = RemoveSentenceWith(stringBuilder.ToString(), "<pseudonym>");
			}
			text = FormatTextForGender(text, info.BodyType);
			return FormatTextVariables(text);
		}

		public static string FormatTextVariables(string textToFormat)
		{
			if (VillageSave == null)
			{
				textToFormat = textToFormat.Replace("<village_name>", HighlightBlue(MonoSingleton<GameStartController>.Instance.SelectedVillageName));
				return textToFormat;
			}
			StringBuilder stringBuilder = new StringBuilder(textToFormat);
			stringBuilder.Replace("<village_name>", HighlightBlue(VillageSave.Name));
			stringBuilder.Replace("<year>", HighlightBlue(VillageSave.DateAndTime.Year.ToString()));
			stringBuilder.Replace("<season_description>", GetRandomStartingSeasonInfo());
			stringBuilder.Replace("<all_villagers>", GetAllVillagers());
			return stringBuilder.ToString();
		}

		public static string FormatVillage(this string str)
		{
			return str.Replace("<village_name>", HighlightBlue(VillageSave.Name));
		}

		public static string FormatTextForGender(string text, BodyType bodyType)
		{
			if (bodyType.Equals(BodyType.None) || !text.Contains('['))
			{
				return text;
			}
			return FormatGenderSquareBrackets(text, bodyType.Equals(BodyType.Male));
		}

		public static string FormatTextForGender(string text, List<BodyType> bodyTypes)
		{
			if (bodyTypes == null || bodyTypes.Count == 0)
			{
				return text;
			}
			if (!text.Contains('#'))
			{
				return FormatTextForGender(text, bodyTypes.FirstOrDefault((BodyType type) => !type.Equals(BodyType.None)));
			}
			StringBuilder stringBuilder = new StringBuilder(text);
			MatchCollection matchCollection = FormatSHashtagIndexRegex.Matches(stringBuilder.ToString());
			bool isEnabled;
			for (int num = matchCollection.Count - 1; num >= 0; num--)
			{
				BodyType t = GetBodyType(matchCollection[num].Groups[1].Value);
				if (matchCollection[num].Groups[1].Index + matchCollection[num].Groups[1].Length <= stringBuilder.Length)
				{
					stringBuilder.Remove(matchCollection[num].Groups[1].Index, matchCollection[num].Groups[1].Length);
				}
				else
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\TextFormatting.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Invalid match in text: ");
						messageBuilder.AppendFormatted(text);
					}
					Log.Error(messageBuilder);
				}
				stringBuilder.Replace(matchCollection[num].Groups[2].Value, FormatGenderSquareBrackets(matchCollection[num].Groups[2].Value, t.Equals(BodyType.Male)));
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(26, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\TextFormatting.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("After replacing ");
					messageBuilder2.AppendFormatted(matchCollection[num].Groups[2].Value);
					messageBuilder2.AppendLiteral(" with ");
					messageBuilder2.AppendFormatted(t);
					messageBuilder2.AppendLiteral(":\n'");
					messageBuilder2.AppendFormatted(stringBuilder);
					messageBuilder2.AppendLiteral("'");
				}
				Log.Debug(messageBuilder2);
			}
			if (stringBuilder.ToString().Contains('#'))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(41, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\TextFormatting.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Hashtag still present in: ");
					messageBuilder.AppendFormatted(stringBuilder);
					messageBuilder.AppendLiteral("./nInput text: ");
					messageBuilder.AppendFormatted(text);
				}
				Log.Error(messageBuilder);
			}
			return FormatGenderSquareBrackets(stringBuilder.ToString(), bodyTypes.FirstOrDefault((BodyType bt) => !bt.Equals(BodyType.None)).Equals(BodyType.Male));
			BodyType GetBodyType(string hashtag)
			{
				if (hashtag == "#1")
				{
					return bodyTypes[0];
				}
				if (hashtag == "#2")
				{
					return bodyTypes[1];
				}
				return BodyType.None;
			}
		}

		private static string FormatGenderSquareBrackets(string str, bool genderIsMale)
		{
			if (str.Contains('#'))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\TextFormatting.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Hashtag found in: ");
					messageBuilder.AppendFormatted(str);
				}
				Log.Warning(messageBuilder);
			}
			MatchCollection matchCollection = FormatSquareBracketsRegex.Matches(str);
			stringBuilderGender.Clear();
			int num = 0;
			foreach (Match item in matchCollection)
			{
				stringBuilderGender.Append(str, num, item.Index - num);
				string value = (genderIsMale ? item.Groups[2].Value : item.Groups[4].Value);
				stringBuilderGender.Append(value);
				num = item.Index + item.Length;
			}
			if (num < str.Length)
			{
				stringBuilderGender.Append(str, num, str.Length - num);
			}
			return stringBuilderGender.ToString();
		}

		private static string GetAllVillagers(bool fullName = false)
		{
			List<HumanoidInstance> workers = VillageSave.Workers;
			if (workers.Count == 1)
			{
				return HighlightOrange(workers.FirstOrDefault()?.Info.GetFullName());
			}
			Language currentLanguageEnum = MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum();
			string text = ((currentLanguageEnum == Language.Chinese || currentLanguageEnum == Language.Japanese) ? "、" : ", ");
			object obj;
			switch (currentLanguageEnum)
			{
			default:
				obj = " " + MonoSingleton<LocalizationController>.Instance.GetText("list_and") + " ";
				break;
			case Language.Chinese:
			case Language.Japanese:
				obj = MonoSingleton<LocalizationController>.Instance.GetText("list_and");
				break;
			case Language.Korean:
				obj = ", ";
				break;
			}
			string text2 = (string)obj;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < workers.Count; i++)
			{
				string text3 = HighlightOrange(fullName ? workers[i].Info.GetFullName() : workers[i].Info.FirstName) ?? "";
				if (i == 0)
				{
					stringBuilder.Append(text3);
				}
				else if (i == workers.Count - 1)
				{
					stringBuilder.Append(text2 + text3);
				}
				else
				{
					stringBuilder.Append(text + text3);
				}
			}
			return stringBuilder.ToString();
		}

		private static string GetRandomStartingSeasonInfo(int variations = 4)
		{
			Season season = Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().Seasons[WorldDate.GameStartSeason];
			return MonoSingleton<LocalizationController>.Instance.GetText($"{season.Name}_description_{UnityEngine.Random.Range(1, variations)}");
		}

		public static string HighlightOrange(string input)
		{
			return "<style=DefaultOrange>" + input + "</style>";
		}

		public static string HighlightBlue(string input)
		{
			return "<style=SettlementName>" + input + "</style>";
		}

		private static string FormatLinks(string term)
		{
			if (!linkTypeTermInit)
			{
				linkTypeTermInit = true;
				linkTypeTermCache = new Dictionary<string, LinkType>();
				LinkType[] linkTypes = EnumValues.LinkTypes;
				foreach (LinkType linkType in linkTypes)
				{
					linkTypeTermCache.Add($"<{linkType}=", linkType);
				}
			}
			LinkType linkType2 = LinkType.None;
			foreach (KeyValuePair<string, LinkType> item in linkTypeTermCache)
			{
				if (term.Contains(item.Key))
				{
					linkType2 = item.Value;
					break;
				}
			}
			if (linkType2 == LinkType.None)
			{
				return term;
			}
			string value = $"<style={linkType2}>";
			MatchCollection matchCollection = GetLinkRegex(linkType2).Matches(term);
			if (matchCollection.Count == 0)
			{
				return term;
			}
			StringBuilder stringBuilder = new StringBuilder(term);
			for (int num = matchCollection.Count - 1; num >= 0; num--)
			{
				int index = matchCollection[num].Index;
				int index2 = index + matchCollection[num].Length;
				stringBuilder.Insert(index2, "</style>");
				stringBuilder.Insert(index, value);
			}
			stringBuilder.Replace("<" + linkType2.ToString() + "=", "<link=");
			return stringBuilder.ToString();
		}

		private static Regex GetLinkRegex(LinkType linkType)
		{
			if (linkTypeRegexPatterns != null)
			{
				return linkTypeRegexPatterns[linkType];
			}
			linkTypeRegexPatterns = new Dictionary<LinkType, Regex>();
			LinkType[] linkTypes = EnumValues.LinkTypes;
			foreach (LinkType linkType2 in linkTypes)
			{
				if (linkType2 != LinkType.None)
				{
					linkTypeRegexPatterns.Add(linkType2, new Regex($"(<)(?'linkType'{linkType2})(=\")(?'linkId'[\\w\\d\\S]+)(\">)(?'linkText'[\\w+\\s]+)(<\\/link>)"));
				}
			}
			return linkTypeRegexPatterns[linkType];
		}

		public static bool IsCharacterInvalid(char ch)
		{
			if ((ch < '!' || ch > '/') && (ch < ':' || ch > '@') && (ch < '[' || ch > '`'))
			{
				if (ch >= '{')
				{
					return ch <= '~';
				}
				return false;
			}
			return true;
		}

		public static string RemoveInvalidCharsFromString(string inputString)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in inputString)
			{
				if (!IsCharacterInvalid(c))
				{
					stringBuilder.Append(c);
				}
			}
			if (stringBuilder.Length == 0)
			{
				return null;
			}
			return stringBuilder.ToString();
		}
	}
}
