using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Almanac;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UI.Enums;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class UiUtils
	{
		public static WorldDate WorldDate
		{
			get
			{
				if (GlobalSaveController.CurrentVillageData == null)
				{
					return null;
				}
				return GlobalSaveController.CurrentVillageData.DateAndTime;
			}
		}

		public static LocalizationController Localize => MonoSingleton<LocalizationController>.Instance;

		private static int DaysInYear => GlobalSaveController.CurrentVillageData.DateAndTime.DaysInSeason * 4;

		private static int HoursInDay => GlobalSaveController.CurrentVillageData.DateAndTime.HoursInDay;

		private static int MinutesInHour => GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;

		public static string JoinLocalizedLinks(List<string> localizationKeys, LinkType linkType, char delimiter = ',')
		{
			string text = string.Empty;
			foreach (string localizationKey in localizationKeys)
			{
				string localizedAlmanacLink = GetLocalizedAlmanacLink(localizationKey);
				if (!localizedAlmanacLink.Equals(string.Empty))
				{
					text += $"{localizedAlmanacLink}{delimiter} ";
				}
			}
			return text.Trim().TrimEnd(delimiter);
		}

		public static string GetLocalizedAlmanacLink(string localizationKey)
		{
			string repositoryLink = GetRepositoryLink(localizationKey);
			if (!repositoryLink.Equals(string.Empty))
			{
				return $"<Style={LinkType.LinkAlmanac}><link=\"{repositoryLink}\">{Localize.GetText(localizationKey)}</link></style>";
			}
			return repositoryLink;
		}

		public static string GetLocalizedAlmanacLinks(List<string> list, string lastEntrySeparator = "", string separator = ", ")
		{
			if (string.IsNullOrEmpty(lastEntrySeparator))
			{
				lastEntrySeparator = " " + "list_or".ToLocalized() + " ";
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (list[0] != null)
			{
				stringBuilder.Append(GetLocalizedAlmanacLink(list[0] ?? ""));
			}
			if (!string.IsNullOrEmpty(separator))
			{
				for (int i = 1; i < list.Count; i++)
				{
					if (i == list.Count - 1)
					{
						stringBuilder.Append(lastEntrySeparator ?? "");
					}
					else
					{
						stringBuilder.Append(separator);
					}
					if (list[i] != null)
					{
						stringBuilder.Append(GetLocalizedAlmanacLink(list[i] ?? ""));
					}
				}
			}
			else
			{
				for (int j = 1; j < list.Count; j++)
				{
					if (list[j] != null)
					{
						stringBuilder.Append(GetLocalizedAlmanacLink(list[j] ?? ""));
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetRepositoryLink(string localizationKey)
		{
			return Repository<LinkRepository, Links>.Instance.GetLinkIdByKey(localizationKey);
		}

		public static string GetLocalizedYesNo(bool isTrue)
		{
			object obj;
			if (!isTrue)
			{
				obj = Localize.GetText("general_no");
				if (obj == null)
				{
					return "";
				}
			}
			else
			{
				obj = Localize.GetText("general_yes") ?? "";
			}
			return (string)obj;
		}

		public static string GetPercentStr(float? normalizedPercentage)
		{
			if (!normalizedPercentage.HasValue)
			{
				return string.Empty;
			}
			return $"{Mathf.RoundToInt((normalizedPercentage * 100f).Value)}%";
		}

		public static string GetReservedByLocalized(IReservable reservable)
		{
			string output = string.Empty;
			if (!MonoSingleton<ReservationManager>.Instance.IsReserved(reservable))
			{
				return output;
			}
			MonoSingleton<ReservationManager>.Instance.ForEachReserver(reservable, delegate(IGoapAgentOwner agent)
			{
				if (!(agent is AnimalInstance animalInstance))
				{
					if (agent is HumanoidInstance humanoid)
					{
						output = output + GetWorkerLink(humanoid) + " ";
					}
				}
				else
				{
					output = output + GetAnimalLink(animalInstance) + " ";
				}
			});
			if (!output.Equals(string.Empty))
			{
				return Localize.GetText("reserved_by") + ": " + output;
			}
			return output;
		}

		public static string GetAnimalLink(AnimalInstance animalInstance)
		{
			return GetAnimalLink(animalInstance, AnimalUtils.GetFullName(animalInstance));
		}

		public static string GetAnimalLink(AnimalInstance animalInstance, string linkText)
		{
			return string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_animal", animalInstance.UniqueId, LinkType.LinkAnimal, linkText);
		}

		public static string GetNPCLink(HumanoidInstance humanoidInstance)
		{
			return GetNPCLink(humanoidInstance, humanoidInstance.GetFullName());
		}

		public static string GetNPCLink(HumanoidInstance humanoidInstance, string linkText)
		{
			return string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_enemy", humanoidInstance.UniqueId, LinkType.LinkNPC, linkText);
		}

		public static string GetWorkerLink(HumanoidInstance humanoid, string linkText)
		{
			return string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_worker", humanoid.UniqueId, LinkType.LinkWorker, linkText);
		}

		public static string GetCreatureLink(CreatureBase creatureBase)
		{
			if (!(creatureBase is HumanoidInstance humanoidInstance))
			{
				if (creatureBase is AnimalInstance animalInstance)
				{
					return GetAnimalLink(animalInstance);
				}
				return creatureBase.GetCharacterInfo().FirstName;
			}
			if (humanoidInstance.WorkerBehaviour == null)
			{
				return GetNPCLink(humanoidInstance);
			}
			return GetWorkerLink(humanoidInstance);
		}

		public static string GetWorkerLink(HumanoidInstance humanoid)
		{
			return GetWorkerLink(humanoid, humanoid.Info.FirstName);
		}

		public static string GetWebLink(string linkKey, string linkText)
		{
			return $"<link=\"{linkKey}\"><style={LinkType.LinkWorker}>{MonoSingleton<LocalizationController>.Instance.GetText(linkText)}</style></link>";
		}

		public static string GetFactionLink(FactionInstance factionInstance, string linkText)
		{
			return string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_faction", factionInstance.Blueprint.GetID(), LinkType.LinkFaction, linkText);
		}

		public static string GetMaterialLink(string material, string linkText)
		{
			return string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_material", material, LinkType.LinkMaterial, linkText);
		}

		public static string GetResearchLink(string researchId, string linkText)
		{
			return string.Format("<link=\"{0}_{1}\"><style={2}>{3}</style></link>", "select_research", researchId, LinkType.LinkMaterial, linkText);
		}

		public static string GetNPCName(HumanoidInstance humanoidInstance, bool isFullName = true)
		{
			if (!isFullName)
			{
				return humanoidInstance.GetCharacterInfo().FirstName + " (" + Localize.GetText(humanoidInstance.Id) + ")";
			}
			return humanoidInstance.GetFullName() + " (" + Localize.GetText(humanoidInstance.Id) + ")";
		}

		public static string GetColoredPercentStr(float? normalizedPercentage)
		{
			string percentStr = GetPercentStr(normalizedPercentage);
			if (string.IsNullOrEmpty(percentStr))
			{
				return percentStr;
			}
			string text = ((normalizedPercentage <= 0.5f) ? "DefaultRed" : ((!(normalizedPercentage < 1f)) ? "DefaultGreen" : "DefaultOrange"));
			return "<style=" + text + ">" + percentStr + "</style>";
		}

		public static string FormatPositiveNeutralNegative(string text, float value, float negativeThreshold, float positiveThreshold, bool addPlusSign = true)
		{
			string text2 = "DefaultGrey";
			if (value < negativeThreshold)
			{
				text2 = "DefaultRed";
				text = text ?? "";
			}
			if (value > positiveThreshold)
			{
				text2 = "DefaultGreen";
				text = (addPlusSign ? "+" : string.Empty) + text;
			}
			return "<style=" + text2 + ">" + text + "</style>";
		}

		public static string FormatReligiousAlignment(float value, string religionId, float midpoint = 0f)
		{
			string text = "DarkGray";
			string text2 = $"{value:F1}";
			if (!((double)Math.Abs(value - midpoint) > 0.001))
			{
				return "<style=" + text + ">" + text2 + "</style>";
			}
			if (religionId.Equals("pagan"))
			{
				text = "DefaultYellow";
				if (value > midpoint)
				{
					text2 = $"-{Mathf.Abs(value):F1}";
				}
				if (value < midpoint)
				{
					text2 = $"+{Mathf.Abs(value):F1}";
				}
			}
			else
			{
				text = "DefaultPurple";
				if (value > midpoint)
				{
					text2 = $"+{Mathf.Abs(value):F1}";
				}
			}
			return "<style=" + text + ">" + text2 + "</style>";
		}

		public static string FormatPositiveNegative(string text, float value, float midpoint = 0f, bool invert = false, bool addPlusSign = true)
		{
			string text2 = "DarkGray";
			if (value > midpoint)
			{
				text2 = (invert ? "DefaultRed" : "DefaultGreen");
				text = (addPlusSign ? "+" : string.Empty) + text;
			}
			if (value < midpoint)
			{
				text2 = (invert ? "DefaultGreen" : "DefaultRed");
			}
			return "<style=" + text2 + ">" + text + "</style>";
		}

		public static string GetTimeFormatByDays(float totalDays, bool isDuration = false)
		{
			float num = Mathf.Floor(totalDays / (float)DaysInYear);
			float num2 = ((num > 0f) ? Mathf.Floor(totalDays % (float)DaysInYear) : Mathf.Floor(totalDays));
			string obj = ((num > 0f) ? GetYearsShortLocalized(num, isDuration) : string.Empty);
			string text = ((num > 0f || num2 > 0f) ? GetDaysShortLocalized(num2, isDuration) : string.Empty);
			return FormatShortTimeLocalized((obj + " " + text).Trim());
		}

		public static string GetTimeFormatByHours(float totalHours, bool isDuration = false)
		{
			if (totalHours == 0f)
			{
				return GetHoursShortLocalized(totalHours, isDuration);
			}
			float num = Mathf.Abs(totalHours / (float)HoursInDay);
			float num2 = Mathf.Floor(num / (float)DaysInYear);
			float num3 = ((num2 > 0f) ? Mathf.Floor(num % (float)DaysInYear) : Mathf.Floor(num));
			float num4 = Mathf.Floor(Mathf.Abs(totalHours % (float)HoursInDay));
			string text = ((num2 > 0f) ? GetYearsShortLocalized(num2, isDuration) : string.Empty);
			string text2 = ((num2 > 0f || num3 > 0f) ? GetDaysShortLocalized(num3, isDuration) : string.Empty);
			string text3 = ((num2 > 0f || num3 > 0f || num4 > 0f) ? GetHoursShortLocalized(num4, isDuration) : string.Empty);
			return FormatShortTimeLocalized((text + " " + text2 + " " + text3).Trim());
		}

		public static string GetTimeFormatByMinutes(float totalMinutes, bool isDuration = false)
		{
			float num = Mathf.Abs(totalMinutes / (float)MinutesInHour);
			float num2 = Mathf.Floor(totalMinutes % (float)MinutesInHour);
			string text = ((num > 1f) ? GetTimeFormatByHours(num, isDuration) : string.Empty);
			string text2 = ((num2 > 0f) ? GetMinutesShortLocalized(num2, isDuration) : string.Empty);
			if (text == string.Empty)
			{
				return text2;
			}
			if (text2 == string.Empty)
			{
				return text;
			}
			return FormatShortTimeLocalized((text + " " + text2).Trim());
		}

		private static string GetYearsShortLocalized(float value, bool isDuration)
		{
			string arg = (isDuration ? "general_year_short_duration".ToLocalized() : "general_year_short".ToLocalized());
			return $"{value}{arg}";
		}

		private static string GetDaysShortLocalized(float value, bool isDuration)
		{
			string arg = (isDuration ? "general_day_short_duration".ToLocalized() : "general_day_short".ToLocalized());
			return $"{value}{arg}";
		}

		private static string GetHoursShortLocalized(float value, bool isDuration)
		{
			string arg = (isDuration ? "general_hour_short_duration".ToLocalized() : "general_hour_short".ToLocalized());
			return $"{value}{arg}";
		}

		private static string GetMinutesShortLocalized(float value, bool isDuration)
		{
			string arg = (isDuration ? "general_minute_short_duration".ToLocalized() : "general_minute_short".ToLocalized());
			return $"{value}{arg}";
		}

		private static string FormatShortTimeLocalized(string input)
		{
			if (Localize.GetCurrentLanguageEnum() != Language.Japanese)
			{
				return input;
			}
			return new string(input.Where((char c) => !char.IsWhiteSpace(c)).ToArray());
		}

		public static string GetLocalizedSeason(int seasonValue)
		{
			List<Season> seasons = Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().Seasons;
			return Localize.GetText("general_" + seasons[seasonValue].Name);
		}

		public static string GetLocalizedDay()
		{
			if (Localize.GetCurrentLanguageEnum() == Language.Japanese || Localize.GetCurrentLanguageEnum() == Language.Korean || Localize.GetCurrentLanguageEnum() == Language.Chinese)
			{
				return string.Format("{0}{1}", GlobalSaveController.CurrentVillageData.DateAndTime.Day, MonoSingleton<LocalizationController>.Instance.GetText("general_day"));
			}
			if (Localize.GetCurrentLanguageEnum() == Language.Turkish)
			{
				return string.Format("{0}. {1}", GlobalSaveController.CurrentVillageData.DateAndTime.Day, MonoSingleton<LocalizationController>.Instance.GetText("general_day"));
			}
			return string.Format("{0} {1}", MonoSingleton<LocalizationController>.Instance.GetText("general_day"), GlobalSaveController.CurrentVillageData.DateAndTime.Day);
		}

		public static string GetEffectorName(StatEffector effector, BodyType getBodyType)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(effector.LocKeys), getBodyType);
			return SkillBuffCheck(effector, text);
		}

		public static string GetEffectorInfo(StatEffector effector, BodyType getBodyType, HumanoidInstance humanoid)
		{
			string input = ((humanoid == null) ? MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(effector.LocKeys), getBodyType) : MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(effector.LocKeys), humanoid));
			return SkillBuffCheck(effector, input);
		}

		private static string SkillBuffCheck(StatEffector effector, string input)
		{
			if (string.IsNullOrEmpty(effector.Category) || effector.Category != "skillBuff")
			{
				return input;
			}
			int num = effector.GetID().IndexOf("skillBuff", StringComparison.OrdinalIgnoreCase);
			string text = ((num >= 0) ? effector.GetID().Substring(num + "skillBuff".Length) : string.Empty);
			return input.Replace("<skill_name>", ("skill_name_" + text).ToLocalized());
		}

		public static string BuildBallparkEnemiesListing(IReadOnlyList<IEnemyPurchaseUnit> enemies, int randomSeed, IReadOnlyList<SiegeWeaponComponentBlueprint> siegeWeapons = null)
		{
			System.Random random = new System.Random(randomSeed);
			SortedDictionary<string, int> sortedDictionary = CountEnemies(enemies, siegeWeapons);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, int> item in sortedDictionary)
			{
				item.Deconstruct(out var key, out var value);
				string arg = key;
				int num = value;
				int val = Mathf.RoundToInt((float)random.Next(70, 100) / 100f * (float)num);
				val = Math.Max(0, val);
				int num2 = Mathf.CeilToInt((float)random.Next(100, 130) / 100f * (float)num);
				if (num2 - num < 2)
				{
					num2 += 2;
				}
				stringBuilder.AppendLine($"{arg} {val}-{num2}".ToRed());
			}
			return stringBuilder.ToString();
		}

		public static string BuildPreciseEnemiesListing(IReadOnlyList<IEnemyPurchaseUnit> enemies, IReadOnlyList<SiegeWeaponComponentBlueprint> siegeWeapons = null)
		{
			SortedDictionary<string, int> sortedDictionary = CountEnemies(enemies, siegeWeapons);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var (arg, num2) in sortedDictionary)
			{
				stringBuilder.AppendLine($"{arg} ~{num2}".ToRed());
			}
			return stringBuilder.ToString();
		}

		private static SortedDictionary<string, int> CountEnemies(IReadOnlyList<IEnemyPurchaseUnit> enemies, IReadOnlyList<SiegeWeaponComponentBlueprint> siegeWeapons = null)
		{
			SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
			foreach (IEnemyPurchaseUnit enemy in enemies)
			{
				if (enemy != null)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText(enemy.GetID());
					if (!sortedDictionary.TryAdd(text, 1))
					{
						sortedDictionary[text]++;
					}
				}
			}
			if (siegeWeapons != null)
			{
				foreach (SiegeWeaponComponentBlueprint siegeWeapon in siegeWeapons)
				{
					if (!(siegeWeapon == null))
					{
						string text2 = MonoSingleton<LocalizationController>.Instance.GetText(siegeWeapon.GetID());
						if (!sortedDictionary.TryAdd(text2, 1))
						{
							sortedDictionary[text2]++;
						}
					}
				}
			}
			return sortedDictionary;
		}
	}
}
