using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class HumanoidUtils
	{
		public static List<string> GetTradeTooltipLines(HumanoidInstance humanoid)
		{
			CreatureInfoBase info = humanoid.GetInfo();
			CharacterInfoBase characterInfo = humanoid.GetCharacterInfo();
			return new List<string>
			{
				$"{characterInfo.GetFullName()} ({info.Age})",
				MonoSingleton<LocalizationController>.Instance.GetText("general_faction") + ": " + humanoid.Faction?.NameLocalized,
				string.Format("{0}: {1:F}%", MonoSingleton<LocalizationController>.Instance.GetText("worker_health"), humanoid.Stats.GetStat(StatType.Health).GetNormalizedPercentage() * 100f)
			};
		}

		public static string GetPseudonymLocalized(HumanoidInstance humanoid)
		{
			Pseudonym byID = Repository<PseudonymRepository, Pseudonym>.Instance.GetByID(humanoid.Info.PseudonymId);
			if (byID == null)
			{
				return string.Empty;
			}
			return TextFormatting.FormatPseudonymText(MonoSingleton<LocalizationController>.Instance.GetText("pseudonym_pattern"), GetPseudonymLocalized(byID, humanoid), humanoid);
		}

		private static string GetPseudonymLocalized(Pseudonym pseudonym, HumanoidInstance humanoid)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(pseudonym.LocKeys), humanoid);
		}

		public static List<string> GetPseudonymTooltipLines(Pseudonym pseudonym, HumanoidInstance humanoid, bool showCharacterPoints = false)
		{
			List<string> list = new List<string>();
			list.Add(TooltipStyles.ApplyStyle(GetPseudonymLocalized(pseudonym, humanoid), TooltipStyles.TooltipTitle));
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(pseudonym.LocKeys), humanoid));
			foreach (SkillValuePair skillModifier in pseudonym.SkillModifiers)
			{
				list.Add(TooltipStyles.ApplyStyle(SkillNameAndValue(skillModifier), TooltipStyles.TooltipAttribute));
			}
			if (pseudonym.GoalPreferences.Count > 0)
			{
				list.Add("\n");
				list.Add(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText("job_preferences"), TooltipStyles.TooltipSubtitleLineStyle));
				foreach (StringIntPair goalPreference in pseudonym.GoalPreferences)
				{
					list.Add(TooltipStyles.ApplyStyle(JobTypeAndPreference(goalPreference), TooltipStyles.TooltipAttribute));
				}
			}
			if (showCharacterPoints)
			{
				list.Add(string.Format("{0}: <b>{1}</b>", UiUtils.Localize.GetText("character_points_cost"), pseudonym.CreationPointCost));
			}
			return list;
		}

		public static List<string> GetPseudonymTooltipLines(HumanoidInstance humanoid, bool showCharacterPoints = false)
		{
			List<string> list = new List<string>();
			Pseudonym byID = Repository<PseudonymRepository, Pseudonym>.Instance.GetByID(humanoid.Info.PseudonymId);
			if (byID == null)
			{
				return list;
			}
			list.AddRange(GetPseudonymTooltipLines(byID, humanoid, showCharacterPoints));
			list.RemoveAt(0);
			list.Insert(0, TooltipStyles.ApplyStyle(GetPseudonymLocalized(humanoid), TooltipStyles.TooltipTitle));
			return list;
		}

		public static string GetProducerName(int uniqueId)
		{
			HumanoidInstance workerByCreationID = GlobalSaveController.CurrentVillageData.GetWorkerByCreationID(uniqueId);
			if (workerByCreationID != null)
			{
				return UiUtils.GetWorkerLink(workerByCreationID);
			}
			return string.Empty;
		}

		public static string GetBackgroundNameMerged(HumanoidInstance humanoid)
		{
			string spaceChar = UiUtils.Localize.GetCurrentLanguageEnum() switch
			{
				Language.Chinese => "", 
				Language.Japanese => "", 
				_ => " ", 
			};
			string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(humanoid.Info.BackStory.LocKeys));
			string text2 = UiUtils.Localize.GetText(LocKeyUtils.GetName(humanoid.Info.Background.LocKeys));
			return TextFormatting.GetBackgroundName(text, text2, humanoid.Info.BodyType == BodyType.Male, spaceChar);
		}

		public static List<string> GetBackgroundTooltipLines(string id, HumanoidInstance humanoid)
		{
			Background byID = Repository<BackgroundRepository, Background>.Instance.GetByID(id);
			List<string> list = new List<string>();
			list.Add(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys), humanoid.Info.BodyType), TooltipStyles.TooltipTitle));
			list.Add(TooltipStyles.ApplyStyle(TextFormatting.FormatText(UiUtils.Localize.GetText(LocKeyUtils.GetInfo(byID.LocKeys)), humanoid), TooltipStyles.TooltipDescriptionLine));
			foreach (SkillValuePair skillModifier in byID.SkillModifiers)
			{
				list.Add(TooltipStyles.ApplyStyle(SkillNameAndValue(skillModifier), TooltipStyles.TooltipAttribute));
			}
			if (byID.GoalPreferences.Count > 0)
			{
				list.Add("\n");
				list.Add(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText("job_preferences"), TooltipStyles.TooltipSubtitleLineStyle));
				foreach (StringIntPair goalPreference in byID.GoalPreferences)
				{
					if (goalPreference.Value != 3)
					{
						list.Add(TooltipStyles.ApplyStyle(JobTypeAndPreference(goalPreference), TooltipStyles.TooltipAttribute));
					}
				}
			}
			list.Add(string.Format("{0}: <b>{1}</b>", UiUtils.Localize.GetText("character_points_cost"), byID.CreationPointCost));
			return list;
		}

		public static List<string> GetBackstoryTooltipLines(string id, HumanoidInstance humanoid)
		{
			BackStory byID = Repository<BackStoryRepository, BackStory>.Instance.GetByID(id);
			List<string> list = new List<string>();
			string text = TextFormatting.FormatText(LocKeyUtils.GetInfo(byID.LocKeys).ToLocalized(humanoid.Info.BodyType), humanoid);
			string text2 = " ";
			if (text[0] == ',' || MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Chinese || MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Japanese)
			{
				text2 = string.Empty;
			}
			text = ($"background_context_link_0{humanoid.Info.BackgroundContextLink}".ToLocalized(humanoid.Info.BodyType) + text2 + text).CapitalizeFirst();
			list.Add(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys), humanoid.Info.BodyType), TooltipStyles.TooltipTitle));
			list.Add(TooltipStyles.ApplyStyle(text, TooltipStyles.TooltipDescriptionLine));
			foreach (SkillValuePair skillModifier in byID.SkillModifiers)
			{
				list.Add(TooltipStyles.ApplyStyle(SkillNameAndValue(skillModifier), TooltipStyles.TooltipAttribute));
			}
			if (byID.GoalPreferences.Count > 0)
			{
				list.Add("\n");
				list.Add(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText("job_preferences"), TooltipStyles.TooltipSubtitleLineStyle));
				foreach (StringIntPair goalPreference in byID.GoalPreferences)
				{
					list.Add(TooltipStyles.ApplyStyle(JobTypeAndPreference(goalPreference), TooltipStyles.TooltipAttribute));
				}
			}
			list.Add(string.Format("{0}: <b>{1}</b>", UiUtils.Localize.GetText("character_points_cost"), byID.CreationPointCost));
			return list;
		}

		public static string JobTypeAndPreference(StringIntPair goalPreferenceLevelPair)
		{
			GoalPreferenceLevel value = (GoalPreferenceLevel)goalPreferenceLevelPair.Value;
			GoalPreference byID = Repository<GoalPreferenceRepository, GoalPreference>.Instance.GetByID(goalPreferenceLevelPair.Key);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Goal preference with id ");
					messageBuilder.AppendFormatted(goalPreferenceLevelPair.Key);
					messageBuilder.AppendLiteral(" not found");
				}
				Log.Error(messageBuilder);
			}
			return AssetUtils.GetSpriteAsset(value.ToString().ToLower()) + "  " + UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys));
		}

		public static string GetPreferenceLevelName(GoalPreferenceLevel goalPreferenceLevel)
		{
			return AssetUtils.GetSpriteAsset(goalPreferenceLevel.ToString().ToLower()) + " " + MonoSingleton<LocalizationController>.Instance.GetText($"goal_preference_name_{goalPreferenceLevel}");
		}

		public static List<string> GetPerkTooltipLines(string id, HumanoidInstance humanoid, bool includeDescription = true, bool includeCreationData = false)
		{
			Perk byID = Repository<PerkRepository, Perk>.Instance.GetByID(id);
			if (byID == null)
			{
				return new List<string>();
			}
			LocalizationController localize = UiUtils.Localize;
			string text = localize.GetText(LocKeyUtils.GetName(byID.LocKeys), humanoid);
			List<string> list = new List<string> { TooltipStyles.ApplyStyle(text, TooltipStyles.TooltipTitle) };
			if (includeDescription)
			{
				list.Add(localize.GetText(LocKeyUtils.GetInfo(byID.LocKeys), humanoid));
			}
			foreach (SkillValuePair skillModifier in byID.SkillModifiers)
			{
				list.Add(SkillNameAndValue(skillModifier));
			}
			foreach (AttributeModifierPair attributeModifier in byID.AttributeModifiers)
			{
				NSMedieval.StatsSystem.Attribute byType = Repository<AttributeRepository, NSMedieval.StatsSystem.Attribute>.Instance.GetByType(attributeModifier.Key);
				string localizedAttributeName = AttributeUtils.GetLocalizedAttributeName(byType);
				if (!string.IsNullOrEmpty(localizedAttributeName))
				{
					list.Add(TooltipStyles.ApplyStyle(localizedAttributeName + " " + AttributeUtils.GetLocalizedAttributeModifier(byType, attributeModifier.Value), TooltipStyles.TooltipAttribute));
				}
			}
			if (byID.GoalPreferences.Count > 0)
			{
				list.Add("\n");
				list.Add(TooltipStyles.ApplyStyle(UiUtils.Localize.GetText("job_preferences"), TooltipStyles.TooltipSubtitleLineStyle));
				foreach (StringIntPair goalPreference in byID.GoalPreferences)
				{
					list.Add(TooltipStyles.ApplyStyle(JobTypeAndPreference(goalPreference), TooltipStyles.TooltipAttribute));
				}
			}
			if (includeCreationData)
			{
				list.Add(string.Format("{0}: <b>{1}</b>", localize.GetText("character_points_cost"), byID.CreationPointCost));
				List<Perk> allFromCategory = Repository<PerkRepository, Perk>.Instance.GetAllFromCategory(byID);
				if (allFromCategory == null || allFromCategory.Count <= 1)
				{
					return list;
				}
				list.Add(localize.GetText("character_perk_conflicts") + ":");
				foreach (Perk item in allFromCategory)
				{
					if (!item.Equals(byID))
					{
						list.Add(" - " + localize.GetText(LocKeyUtils.GetName(item.LocKeys), humanoid));
					}
				}
			}
			return list;
		}

		public static Dictionary<GoalPreferenceLevel, string> GetPrefLevelNamesLocalized(HumanoidInstance humanoidInstance)
		{
			Dictionary<GoalPreferenceLevel, string> dictionary = new Dictionary<GoalPreferenceLevel, string>();
			foreach (KeyValuePair<GoalPreference, GoalPreferenceLevelData> item in humanoidInstance.GoalPreferences.GetGoalPrefDictionary())
			{
				if (item.Value.PreferenceLevel != GoalPreferenceLevel.None && !dictionary.TryAdd(item.Value.PreferenceLevel, GetJobsPerPreferenceLevel(item.Key)))
				{
					dictionary[item.Value.PreferenceLevel] = dictionary[item.Value.PreferenceLevel] + ", " + GetJobsPerPreferenceLevel(item.Key);
				}
			}
			return dictionary;
			static string GetJobsPerPreferenceLevel(GoalPreference goalPreference)
			{
				return UiUtils.Localize.GetText(LocKeyUtils.GetName(goalPreference.LocKeys)) ?? "";
			}
		}

		public static Dictionary<GoalPreferenceLevel, string> GetPrefLevelsLocalized(HumanoidInstance humanoidInstance)
		{
			Dictionary<GoalPreferenceLevel, string> dictionary = new Dictionary<GoalPreferenceLevel, string>();
			foreach (KeyValuePair<GoalPreference, GoalPreferenceLevelData> item in humanoidInstance.GoalPreferences.GetGoalPrefDictionary())
			{
				if (item.Value.PreferenceLevel != GoalPreferenceLevel.None && !dictionary.TryAdd(item.Value.PreferenceLevel, GetJobsPerPreferenceLevel(item.Key)))
				{
					dictionary[item.Value.PreferenceLevel] = dictionary[item.Value.PreferenceLevel] + "\n" + GetJobsPerPreferenceLevel(item.Key);
				}
			}
			return dictionary;
			static string GetJobsPerPreferenceLevel(GoalPreference goalPreference)
			{
				return UiUtils.Localize.GetText(LocKeyUtils.GetName(goalPreference.LocKeys)) + "\n<style=Desc><indent=5%>" + UiUtils.Localize.GetText(LocKeyUtils.GetInfo(goalPreference.LocKeys)) + "</indent></style>";
			}
		}

		public static string GetLocalizedGoalPrefLevel(HumanoidInstance humanoidInstance, GoalPreferenceLevel preferenceLevel)
		{
			string result = string.Empty;
			if (GetPrefLevelsLocalized(humanoidInstance).TryGetValue(preferenceLevel, out var value))
			{
				result = value;
			}
			return result;
		}

		public static string GetReligiousThresholdLocalized(HumanoidInstance humanoid)
		{
			return GetReligiousThresholdLocalized((int)(humanoid.Stats.GetStat(StatType.ReligiousAlignment).GetNormalizedPercentage() * 100f), humanoid);
		}

		public static string GetReligiousThresholdLocalized(int statValue, HumanoidInstance humanoid)
		{
			StatThresholdTrigger[] thresholdTriggers = Repository<StatsModelRepository, StatsModel>.Instance.GetStatByType("worker", StatType.ReligiousAlignment).ThresholdTriggers;
			for (int num = thresholdTriggers.Length - 1; num >= 0; num--)
			{
				if (statValue < thresholdTriggers[num].Trigger)
				{
					return MonoSingleton<LocalizationController>.Instance.GetText(thresholdTriggers[num].Name, humanoid.GetInfo().BodyType);
				}
			}
			return MonoSingleton<LocalizationController>.Instance.GetText(thresholdTriggers.LastOrDefault()?.Name, humanoid.GetInfo().BodyType);
		}

		public static HumanoidInstance SetPerks(HumanoidInstance humanoid, List<SerializableIdValuePair> forcedPerks)
		{
			humanoid.SetPerks(GetRandomPerks(humanoid, forcedPerks));
			foreach (Perk perk in humanoid.Perks)
			{
				humanoid.Info.SetIgnoredTypes(humanoid.Info.IgnoredTypes.Union(perk.IgnoreCharacteristicType).ToList());
			}
			return humanoid;
		}

		public static IntRange GetPossiblePerksRange(int workerAge)
		{
			AgeCategory ageCategory = Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.AgeCategories.FirstOrDefault((AgeCategory category) => category.Category.InRange(workerAge));
			if (ageCategory == null)
			{
				return new IntRange(0, 1);
			}
			return ageCategory.PossiblePerks;
		}

		public static List<Perk> GetRandomPerks(HumanoidInstance humanoid, List<SerializableIdValuePair> forcedPerks)
		{
			List<WorkerCharacteristicType> ignoredTypes = humanoid.Info.IgnoredTypes;
			List<Perk> list = new List<Perk>();
			List<Perk> list2 = new List<Perk>();
			List<KeyValuePair<Perk, float>> list3 = new List<KeyValuePair<Perk, float>>();
			foreach (SerializableIdValuePair forcedPerk in forcedPerks)
			{
				Perk byID = Repository<PerkRepository, Perk>.Instance.GetByID(forcedPerk.Id);
				if (forcedPerk.Value == 0f)
				{
					list2.Add(Repository<PerkRepository, Perk>.Instance.GetByID(forcedPerk.Id));
				}
				else if ((double)Math.Abs(forcedPerk.Value - 100f) < 0.01)
				{
					list.Add(byID);
					list2.Add(byID);
				}
				else
				{
					list3.Add(new KeyValuePair<Perk, float>(byID, forcedPerk.Value));
				}
			}
			int num = GetPossiblePerksRange(humanoid.Info.Age).RandomMaxInclusive();
			if (num <= list.Count)
			{
				return list;
			}
			System.Random random = new System.Random();
			while (list3.Count > 0 && list.Count < num)
			{
				int index = random.Next(0, list3.Count);
				if (UnityEngine.Random.Range(0f, 1f) <= list3[index].Value / 100f)
				{
					list.Add(list3[index].Key);
					list2.Add(list3[index].Key);
				}
				list3.RemoveAt(index);
			}
			while (list.Count < num)
			{
				Perk randomPerk = Repository<PerkRepository, Perk>.Instance.GetRandomPerk(list2, ignoredTypes);
				if (randomPerk == null)
				{
					return list;
				}
				list.Add(randomPerk);
				list2.Add(randomPerk);
			}
			return list;
		}

		public static HumanoidInstance SetBackground(HumanoidInstance humanoid, Background background)
		{
			humanoid.Info.SetBackground(background);
			humanoid.Info.SetIgnoredTypes(humanoid.Info.IgnoredTypes.Union(humanoid.Info.Background.IgnoreCharacteristicType).ToList());
			humanoid.SetBlockedActionTags(humanoid.Info.Background.BlockedActionTags);
			return humanoid;
		}

		public static HumanoidInstance SetBackStory(HumanoidInstance humanoid, BackStory backstory)
		{
			humanoid.Info.SetBackStory(backstory);
			humanoid.Info.SetIgnoredTypes(humanoid.Info.IgnoredTypes.Union(humanoid.Info.BackStory.IgnoreCharacteristicType).ToList());
			humanoid.SetBlockedActionTags(humanoid.Info.BackStory.BlockedActionTags);
			return humanoid;
		}

		public static HumanoidInstance SetPseudonym(HumanoidInstance humanoid, string pseudonymId = "random")
		{
			humanoid.Info.SetPseudonym((pseudonymId == "random") ? GetRandomPseudonym(humanoid.Info.Age, (int)(humanoid.Info.ReligiousAlignment * 100f), humanoid.Info.IgnoredTypes) : pseudonymId);
			if (!humanoid.Info.PseudonymId.Equals(string.Empty))
			{
				humanoid.Info.SetIgnoredTypes(humanoid.Info.IgnoredTypes.Union(Repository<PseudonymRepository, Pseudonym>.Instance.GetPseudonym(humanoid.Info.PseudonymId).IgnoreCharacteristicType).ToList());
			}
			return humanoid;
		}

		private static string GetRandomPseudonym(int age, int religiousAlignment, List<WorkerCharacteristicType> ignoredTypes)
		{
			if (age < Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.PseudonymLimit || UnityEngine.Random.Range(0, 100) > Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.PseudonymChance)
			{
				return null;
			}
			return Repository<PseudonymRepository, Pseudonym>.Instance.GetPseudonym(ignoredTypes, religiousAlignment);
		}

		public static string GetSkillsListLocalized(HumanoidInstance humanoid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			foreach (WorkerSkill item in humanoid.SkillsOrdered)
			{
				if (item.Id != SkillType.None)
				{
					stringBuilder.AppendLine("<indent=2%>" + GetSkillSpriteAsset(item.Id) + " " + GetSkillNameLocalized(item.Id) + ": " + ColorUtils.GetSkillLevelColor(item.Level) + "</align></indent>");
					num++;
				}
			}
			return stringBuilder.ToString();
		}

		private static string GetSkillSpriteAsset(SkillType skill)
		{
			return AssetUtils.GetSpriteAsset(skill.ToString().ToLower(CultureInfo.InvariantCulture) ?? "") ?? "";
		}

		private static string GetSkillNameLocalized(SkillType skill)
		{
			return UiUtils.Localize.GetText("skill_name_" + skill) ?? "";
		}

		public static string StillNameOptionalValue(SkillValuePair skill)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(AssetUtils.GetSpriteAsset(skill.Key.ToString().ToLower(CultureInfo.InvariantCulture) ?? ""));
			stringBuilder.Append(string.Format("{0}({1})", UiUtils.Localize.GetText("skill_name_" + skill.Key), skill.Value));
			return stringBuilder.ToString();
		}

		public static string SkillNameAndValue(SkillValuePair skill)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetSkillSpriteAsset(skill.Key));
			stringBuilder.Append(GetSkillNameLocalized(skill.Key) + ": ");
			stringBuilder.Append($"{ColorUtils.GetSkillModifierColor(skill.Value)}{skill.Value}</color>");
			return stringBuilder.ToString();
		}

		public static void GenerateSkillLevels(HumanoidInstance humanoid, bool isNpc = false)
		{
			if (GetBaseCreationPoints(humanoid) >= Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.MaxCreationPoints)
			{
				return;
			}
			int num = Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.MaxCreationPoints - GetBaseCreationPoints(humanoid);
			if (isNpc)
			{
				num = Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.NpcSkillCount;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Total points:  ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" = ");
				messageBuilder.AppendFormatted(Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.MaxCreationPoints);
				messageBuilder.AppendLiteral(" - ");
				messageBuilder.AppendFormatted(GetBaseCreationPoints(humanoid));
			}
			Log.Trace(messageBuilder);
			HashSet<SkillType> hashSet = new HashSet<SkillType>();
			HashSet<SkillType> hashSet2 = new HashSet<SkillType>();
			foreach (WorkerSkill skill in humanoid.Skills.Skills)
			{
				if (skill.Id == SkillType.None || humanoid.SkillIsBlocked(skill.Id))
				{
					continue;
				}
				int baseSkillPoints = GetBaseSkillPoints(humanoid, skill);
				if (baseSkillPoints <= 0)
				{
					if (baseSkillPoints < 0)
					{
						hashSet2.Add(skill.Id);
					}
				}
				else
				{
					humanoid.SetSkillLevel(skill.Id, baseSkillPoints);
					hashSet.Add(skill.Id);
				}
			}
			int num2 = Enum.GetNames(typeof(SkillType)).Length - 1;
			int num3 = Mathf.RoundToInt(num / num2);
			int num4 = 1;
			int num5 = 0;
			foreach (WorkerSkill skill2 in humanoid.Skills.Skills)
			{
				if (skill2.Id == SkillType.None || humanoid.SkillIsBlocked(skill2.Id) || hashSet2.Contains(skill2.Id))
				{
					continue;
				}
				int num6 = num4 * num3 + new IntRange(-num3, num3).RandomMaxInclusive();
				if (num4 > 1)
				{
					if (num6 < num5)
					{
						num6 = num5;
					}
					if (num4 == humanoid.Skills.Skills.Count - 1)
					{
						num6 = num;
					}
				}
				int num7 = num6 - num5;
				num5 = num6;
				humanoid.SetSkillLevel(skill2.Id, skill2.Level + num7);
				num4++;
			}
			int num8 = 0;
			foreach (WorkerSkill skill3 in humanoid.Skills.Skills)
			{
				num8 += skill3.Level - GetBaseSkillPoints(humanoid, skill3);
			}
			int num9 = num - num8;
			int num10 = 500;
			while (num9 != 0)
			{
				num10--;
				if (num10 == 0)
				{
					FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Operation timed out. Points difference: ");
						messageBuilder2.AppendFormatted(num9);
					}
					Log.Info(messageBuilder2);
					break;
				}
				WorkerSkill random = humanoid.Skills.Skills.GetRandom();
				if (random.Id == SkillType.None || hashSet.Contains(random.Id) || hashSet2.Contains(random.Id))
				{
					continue;
				}
				if (num9 < 0)
				{
					if (random.Level >= 1)
					{
						humanoid.SetSkillLevel(random.Id, random.Level - 1);
						num9++;
					}
				}
				else
				{
					humanoid.SetSkillLevel(random.Id, random.Level + 1);
					num9--;
				}
			}
		}

		public static int GetBaseSkillPoints(HumanoidInstance humanoid, WorkerSkill skill)
		{
			int num = 0;
			SkillValuePair skillValuePair = humanoid.Info.BackStory.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
			if (skillValuePair != null)
			{
				num += Mathf.RoundToInt(skillValuePair.Value);
			}
			SkillValuePair skillValuePair2 = humanoid.Info.Background.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
			if (skillValuePair2 != null)
			{
				num += Mathf.RoundToInt(skillValuePair2.Value);
			}
			Pseudonym byID = Repository<PseudonymRepository, Pseudonym>.Instance.GetByID(humanoid.Info.PseudonymId);
			if (byID != null)
			{
				SkillValuePair skillValuePair3 = byID.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
				if (skillValuePair3 != null)
				{
					num += Mathf.RoundToInt(skillValuePair3.Value);
				}
			}
			foreach (Perk perk in humanoid.Perks)
			{
				SkillValuePair skillValuePair4 = perk.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
				if (skillValuePair4 != null)
				{
					num += Mathf.RoundToInt(skillValuePair4.Value);
				}
			}
			return num;
		}

		public static List<string> GetBaseSkillModifiers(HumanoidInstance humanoid, string skillId)
		{
			List<string> list = new List<string>();
			if (humanoid == null || humanoid.HasDisposed || humanoid.HasDied || humanoid.Skills?.Skills == null)
			{
				return list;
			}
			WorkerSkill skill = humanoid.Skills.Skills.FirstOrDefault((WorkerSkill s) => s?.Id.ToString().Equals(skillId, StringComparison.CurrentCultureIgnoreCase) ?? false);
			if (skill == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Problem with string parsing. The ");
					messageBuilder.AppendFormatted(skillId);
					messageBuilder.AppendLiteral(" skill doesn't exist!");
				}
				Log.Error(messageBuilder);
				return list;
			}
			SkillValuePair skillValuePair = humanoid.Info.BackStory.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
			if (skillValuePair != null)
			{
				int num = Mathf.RoundToInt(skillValuePair.Value);
				list.Add($"{UiUtils.Localize.GetText(LocKeyUtils.GetName(humanoid.Info.BackStory.LocKeys))}: {ColorUtils.GetSkillModifierColor(num)}{num}</color>");
			}
			skillValuePair = humanoid.Info.Background.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
			if (skillValuePair != null)
			{
				string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(humanoid.Info.Background.LocKeys));
				text = text[0].ToString().ToUpper() + text.Substring(1);
				int num2 = Mathf.RoundToInt(skillValuePair.Value);
				list.Add($"{text}: {ColorUtils.GetSkillModifierColor(num2)}{num2}</color>");
			}
			Pseudonym byID = Repository<PseudonymRepository, Pseudonym>.Instance.GetByID(humanoid.Info.PseudonymId);
			if (byID != null)
			{
				skillValuePair = byID.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
				if (skillValuePair != null)
				{
					int num3 = Mathf.RoundToInt(skillValuePair.Value);
					list.Add($"{GetPseudonymLocalized(humanoid)}: {ColorUtils.GetSkillModifierColor(num3)}{num3}</color>");
				}
			}
			foreach (Perk perk in humanoid.Perks)
			{
				skillValuePair = perk.SkillModifiers.FirstOrDefault((SkillValuePair item) => item.Key == skill.Id);
				if (skillValuePair != null)
				{
					int num4 = Mathf.RoundToInt(skillValuePair.Value);
					list.Add($"{UiUtils.Localize.GetText(LocKeyUtils.GetName(perk.LocKeys))}: {ColorUtils.GetSkillModifierColor(num4)}{num4}</color>");
				}
			}
			return list;
		}

		public static string GetTradeName(HumanoidInstance human)
		{
			return $"{human.Info.GetFullName()} ({human.Info.Age})";
		}

		public static int CompareWorkersSort(HumanoidInstance humanA, HumanoidInstance humanB)
		{
			bool flag = humanA.IsInIncognitoMode();
			bool flag2 = humanB.IsInIncognitoMode();
			if (flag && !flag2)
			{
				return 1;
			}
			if (!flag && flag2)
			{
				return -1;
			}
			return string.Compare(humanA.Info.GetFullName(), humanB.Info.GetFullName(), StringComparison.CurrentCulture);
		}

		public static List<WorkerCharacteristicType> GetPhysicalIgnoreTypes(List<WorkerCharacteristicType> ignoreList, BodyType bodyType, float height, float weightCoefficient)
		{
			BodyType[] bodyTypes = EnumValues.BodyTypes;
			for (int i = 0; i < bodyTypes.Length; i++)
			{
				BodyType bodyType2 = bodyTypes[i];
				WorkerCharacteristicType item = (WorkerCharacteristicType)Enum.Parse(typeof(WorkerCharacteristicType), bodyType2.ToString());
				if (!bodyType.ToString().Equals(bodyType2.ToString()) && !ignoreList.Contains(item))
				{
					ignoreList.Add((WorkerCharacteristicType)Enum.Parse(typeof(WorkerCharacteristicType), bodyType2.ToString()));
				}
			}
			if (height < Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.HeightNormalRange.Min)
			{
				ignoreList.Add(WorkerCharacteristicType.NormalHeight);
				ignoreList.Add(WorkerCharacteristicType.TallHeight);
			}
			else if (height > Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.HeightNormalRange.Max)
			{
				ignoreList.Add(WorkerCharacteristicType.ShortHeight);
				ignoreList.Add(WorkerCharacteristicType.NormalHeight);
			}
			else
			{
				ignoreList.Add(WorkerCharacteristicType.ShortHeight);
				ignoreList.Add(WorkerCharacteristicType.TallHeight);
			}
			if (weightCoefficient < Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.WeightNormalRange.Min)
			{
				ignoreList.Add(WorkerCharacteristicType.OptimalWeight);
				ignoreList.Add(WorkerCharacteristicType.OverWeight);
			}
			else if (weightCoefficient > Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.WeightNormalRange.Max)
			{
				ignoreList.Add(WorkerCharacteristicType.UnderWeight);
				ignoreList.Add(WorkerCharacteristicType.OptimalWeight);
			}
			else
			{
				ignoreList.Add(WorkerCharacteristicType.UnderWeight);
				ignoreList.Add(WorkerCharacteristicType.OverWeight);
			}
			return ignoreList;
		}

		public static int GetBirthday()
		{
			return UnityEngine.Random.Range(1, Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().Seasons.Count * Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().DaysInSeason);
		}

		public static void UpdateCreationPoints(HumanoidInstance humanoid, bool balance = false)
		{
			int maxCreationPoints = Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.MaxCreationPoints;
			int baseCreationPoints = GetBaseCreationPoints(humanoid);
			int skillCreationPointsSum = GetSkillCreationPointsSum(humanoid);
			int num = ((balance && baseCreationPoints < maxCreationPoints) ? BalanceSkillPoints(maxCreationPoints - baseCreationPoints - skillCreationPointsSum, humanoid) : 0);
			int num2 = baseCreationPoints + skillCreationPointsSum + num;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(48, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Base ");
				messageBuilder.AppendFormatted(baseCreationPoints);
				messageBuilder.AppendLiteral(" + skill ");
				messageBuilder.AppendFormatted(skillCreationPointsSum);
				messageBuilder.AppendLiteral(" + balancedSkill ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" = Total points: ");
				messageBuilder.AppendFormatted(num2);
			}
			Log.Trace(messageBuilder);
			humanoid.Info.SetCreationPoints(num2);
		}

		private static int GetSkillCreationPointsSum(HumanoidInstance humanoid)
		{
			int num = 0;
			foreach (WorkerSkill skill in humanoid.Skills.Skills)
			{
				num += GetSkillCreationPoints(humanoid, skill);
			}
			return num;
		}

		public static int GetSkillCreationPoints(HumanoidInstance humanoid, WorkerSkill skill)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Skill CP ");
				messageBuilder.AppendFormatted(skill.Id);
				messageBuilder.AppendLiteral("  level ");
				messageBuilder.AppendFormatted(skill.Level);
				messageBuilder.AppendLiteral(" - base ");
				messageBuilder.AppendFormatted(GetBaseSkillPoints(humanoid, skill));
				messageBuilder.AppendLiteral(" = ");
				messageBuilder.AppendFormatted(skill.Level - GetBaseSkillPoints(humanoid, skill));
			}
			Log.Trace(messageBuilder);
			return skill.Level - GetBaseSkillPoints(humanoid, skill);
		}

		private static int BalanceSkillPoints(int pointsBudget, HumanoidInstance humanoid)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Balancing skill points with pointsBudget: ");
				messageBuilder.AppendFormatted(pointsBudget);
			}
			Log.Debug(messageBuilder);
			int num = 500;
			int num2 = pointsBudget;
			while (num2 != 0)
			{
				num--;
				if (num == 0)
				{
					FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Balancing skill points timed out. allocated: ");
						messageBuilder2.AppendFormatted(num2);
					}
					Log.Info(messageBuilder2);
					return 0;
				}
				WorkerSkill workerSkill;
				if (num2 > 0)
				{
					num2--;
					workerSkill = GetLowestSkill();
					if (workerSkill != null)
					{
						int num3 = workerSkill.Level + 1;
						FVLogTraceInterpolationHandler messageBuilder3 = new FVLogTraceInterpolationHandler(14, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("++ ");
							messageBuilder3.AppendFormatted(workerSkill.Id);
							messageBuilder3.AppendLiteral(" level: ");
							messageBuilder3.AppendFormatted(workerSkill.Level);
							messageBuilder3.AppendLiteral(" (");
							messageBuilder3.AppendFormatted(num3);
							messageBuilder3.AppendLiteral(")");
						}
						Log.Trace(messageBuilder3);
						workerSkill.SetLevel(num3);
					}
					continue;
				}
				num2++;
				workerSkill = GetHighestSkill();
				if (workerSkill != null)
				{
					int num3 = workerSkill.Level - 1;
					FVLogTraceInterpolationHandler messageBuilder3 = new FVLogTraceInterpolationHandler(14, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\HumanoidUtils.cs");
					if (isEnabled)
					{
						messageBuilder3.AppendLiteral("-- ");
						messageBuilder3.AppendFormatted(workerSkill.Id);
						messageBuilder3.AppendLiteral(" level: ");
						messageBuilder3.AppendFormatted(workerSkill.Level);
						messageBuilder3.AppendLiteral(" (");
						messageBuilder3.AppendFormatted(num3);
						messageBuilder3.AppendLiteral(")");
					}
					Log.Trace(messageBuilder3);
					workerSkill.SetLevel(num3);
				}
			}
			return pointsBudget;
			WorkerSkill GetHighestSkill()
			{
				WorkerSkill workerSkill2 = null;
				foreach (WorkerSkill skill in humanoid.Skills.Skills)
				{
					if (skill.Id != SkillType.None && skill.Level > GetBaseSkillPoints(humanoid, skill) && (workerSkill2 == null || skill.Level > workerSkill2.Level))
					{
						workerSkill2 = skill;
					}
				}
				return workerSkill2;
			}
			WorkerSkill GetLowestSkill()
			{
				WorkerSkill workerSkill2 = null;
				foreach (WorkerSkill skill2 in humanoid.Skills.Skills)
				{
					if (skill2.Id != SkillType.None && GetBaseSkillPoints(humanoid, skill2) >= 0 && (workerSkill2 == null || skill2.Level < workerSkill2.Level))
					{
						workerSkill2 = skill2;
					}
				}
				return workerSkill2;
			}
		}

		private static int GetBaseCreationPoints(HumanoidInstance humanoid)
		{
			int num = 0;
			foreach (Perk perk in humanoid.Perks)
			{
				num += perk.CreationPointCost;
			}
			num += humanoid.Info.Background.CreationPointCost;
			num += humanoid.Info.BackStory.CreationPointCost;
			if (!humanoid.Info.PseudonymId.Equals(string.Empty))
			{
				num += Repository<PseudonymRepository, Pseudonym>.Instance.GetByID(humanoid.Info.PseudonymId).CreationPointCost;
			}
			return num;
		}

		private static Dictionary<SkillType, float> GetSkillCreationPointsModifiers(HumanoidInstance humanoid)
		{
			Dictionary<SkillType, float> dictionary = new Dictionary<SkillType, float>();
			foreach (Perk perk in humanoid.Perks)
			{
				foreach (SkillValuePair skillModifier in perk.SkillModifiers)
				{
					dictionary[skillModifier.Key] += skillModifier.Value;
				}
			}
			return dictionary;
		}
	}
}
