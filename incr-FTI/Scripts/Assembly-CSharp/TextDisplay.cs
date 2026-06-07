using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
	public static string FractionFormat = "{0}/{1}";

	private const string TwoValueSpaced = "{0} {1}";

	private const string TwoValueUnspaced = "{0}{1}";

	public const string TimeFormatShort = "{0:g}";

	public const string TimeFormatMinutes = "{0:h\\:mm}";

	public const string TimeFormatMinutesSeconds = "{0:m\\:ss}";

	public const string TimeFormatMinutesSecondsLeadingZero = "{0}:{1:mm\\:ss}";

	public const string TimeFormatDays = "{0}:{1:mm\\:ss}";

	public static string KeyValueFormat = "{0}:{1}";

	public static string KeyValueFormatSpaced = "{0}: {1}";

	public static string ParensFormat = "({0})";

	private static string PercentFormat = "{0:#0.%}";

	private static string DividerLong = " / ";

	public static string Multiplier = "x";

	public static string NewLine = "\n";

	public static string Indent = "   ";

	public static string Ellipsis = "...";

	public const string NoRateCharacter = "";

	public const string HyphenDivider = "-----";

	private static readonly Dictionary<double, string> CachedFormattedFloats = new Dictionary<double, string>(1000);

	private static readonly Dictionary<double, string> CachedFormattedInts = new Dictionary<double, string>(1000);

	private static readonly Dictionary<EntityId, string> CachedEntityLabels = new Dictionary<EntityId, string>(50);

	public const string Infinity = "∞";

	private static string LevelFormat = "Level {0}";

	public static string LevelFormatShort = "Lv {0}";

	private static string PerSecondFormat = string.Empty;

	private static string PerSecondFormatRounded = string.Empty;

	private static string PositivePerSecondFormat = string.Empty;

	private static string NegativePerSecondFormat = string.Empty;

	private static string NegativePerSecondFormatRounded = string.Empty;

	private static string PositivePerSecondFormatRounded = string.Empty;

	public static StringBuilder sb = new StringBuilder();

	public static StringBuilder highlightTextBuilder = new StringBuilder();

	private static CultureInfo cultureInfo = CultureInfo.InvariantCulture;

	public const string HighlightColorStart = "<color=#FFFF00>";

	public const string PositiveModifierColorStart = "<color=#00FF00>";

	public const string NegativeModifierColorStart = "<color=#FF0000>";

	public const string PartialProgressModifierColorStart = "<color=#FFFF00>";

	public const string OutputFullModifierColorStart = "<color=#40B2E6>";

	public const string OutputSlowedModifierColorStart = "<color=#59D9D9>";

	public const string RateSlowedModifierColorStart = "<color=#26A6A6>";

	public static string GreenHighlightArrow = "<color=#00FF00>></color>";

	public const string NextValueArrow = " -> ";

	public const string HighlightColorEnd = "</color>";

	public const string BoldStart = "<b>";

	public const string BoldEnd = "</b>";

	public static bool debug;

	public static void ReloadLabels()
	{
		cultureInfo = CultureInfo.CurrentCulture;
		PerSecondFormat = "{0:F2}/" + "TimeSecondsAbbreviation".Localized();
		PerSecondFormatRounded = "{0:F0}/" + "TimeSecondsAbbreviation".Localized();
		PositivePerSecondFormat = "+{0:F2}/" + "TimeSecondsAbbreviation".Localized();
		NegativePerSecondFormat = "-{0:F2}/" + "TimeSecondsAbbreviation".Localized();
		PositivePerSecondFormatRounded = "+{0:F0}/" + "TimeSecondsAbbreviation".Localized();
		NegativePerSecondFormatRounded = "-{0:F0}/" + "TimeSecondsAbbreviation".Localized();
		LevelFormat = "FormattedCampaignLevel".Localized();
		LevelFormatShort = "FormattedLevelAbbreviation".Localized();
	}

	public static void SetStatAmount(TextMeshProUGUI label, string localizationKey, float amount)
	{
		sb.Clear();
		sb.AppendFormat(KeyValueFormatSpaced, localizationKey.Localized(), LocalizedNumber(amount));
		label.SetText(sb);
	}

	public static void SetStatLevel(TextMeshProUGUI label, string localizationKey, int level)
	{
		sb.Clear();
		sb.AppendFormat(KeyValueFormatSpaced, localizationKey.Localized(), LocalizedNumber(level));
		label.SetText(sb);
	}

	public static string LocalizedKeyValueFormat()
	{
		if (LocalizationManager.IsCurrentLanguageSpaced())
		{
			return KeyValueFormatSpaced;
		}
		return KeyValueFormat;
	}

	public static string LocalizedTwoValueFormat()
	{
		if (LocalizationManager.IsCurrentLanguageSpaced())
		{
			return "{0} {1}";
		}
		return "{0}{1}";
	}

	public static void SetFraction(TextMeshProUGUI label, double current, double max)
	{
		double value = Math.Floor(current);
		if (current <= 0.0)
		{
			value = 0.0;
		}
		double value2 = Math.Floor(max);
		sb.Clear();
		sb.AppendFormat(FractionFormat, LocalizedNumber(value), LocalizedNumber(value2));
		label.SetText(sb);
	}

	public static void ClearLocalizationCache()
	{
		CachedEntityLabels.Clear();
		CachedFormattedFloats.Clear();
		CachedFormattedInts.Clear();
	}

	public static void FormatLevel(TextMeshProUGUI label, int num)
	{
		sb.Clear();
		sb.Append("Level".Localized());
		sb.Append(' ');
		sb.Append(LocalizedNumber(num));
		label.SetText(sb);
	}

	public static string GetFormattedLevel(int level)
	{
		return string.Format(LevelFormat, LocalizedNumber(level));
	}

	public static string GetFormattedLevelAbbreviation(int level)
	{
		return string.Format(LevelFormatShort, LocalizedNumber(level));
	}

	public static void FormatLevelAbbreviation(TextMeshProUGUI label, int num)
	{
		sb.Clear();
		sb.AppendFormat(LevelFormatShort, LocalizedNumber(num));
		label.SetText(sb);
	}

	public static string LocalizedNumber(int value)
	{
		double key = ((value >= 10000 || value <= -10000) ? GameUtility.TruncateToSignificantDigits(value, 3) : ((double)value));
		if (CachedFormattedInts.TryGetValue(key, out var value2))
		{
			return value2;
		}
		value2 = GenerateLocalizedNumber(value);
		CachedFormattedInts[key] = value2;
		return value2;
	}

	private static string GenerateLocalizedNumber(int value)
	{
		if ((float)value > -10000f && (float)value < 10000f)
		{
			return $"{value:0}";
		}
		return GenerateLocalizedNumber((double)value);
	}

	public static string FormattedSeconds(float seconds)
	{
		return LocalizedNumber(seconds) + "TimeSecondsAbbreviation".Localized();
	}

	public static string FormattedHoursMinutes(float seconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		return string.Format(LocalizationManager.Instance.cultureInfo, "{0:h\\:mm}", timeSpan);
	}

	public static string FormattedHoursMinutesSeconds(float seconds)
	{
		float num = 86400f;
		int num2 = Mathf.RoundToInt(seconds / num);
		if (num2 < 100)
		{
			try
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
				int num3 = Mathf.FloorToInt(seconds / 3600f);
				if (num3 > 0)
				{
					string format = "{0}:{1:mm\\:ss}";
					return string.Format(LocalizationManager.Instance.cultureInfo, format, num3, timeSpan);
				}
				string format2 = "{0:m\\:ss}";
				return string.Format(LocalizationManager.Instance.cultureInfo, format2, timeSpan);
			}
			catch (Exception)
			{
			}
		}
		if (LocalizationManager.IsEnglish())
		{
			return LocalizedNumber(num2) + " days";
		}
		return LocalizedNumber(num2);
	}

	public static string Debug(double value)
	{
		return $"{value:n0}";
	}

	public static string LocalizedNumber(double value, bool round = true)
	{
		_ = debug;
		if (round && value < 10000.0 && value > -10000.0)
		{
			int num = Convert.ToInt32(value);
			if (GameUtility.NearlyEquals(num, value))
			{
				return LocalizedNumber(num);
			}
		}
		int digits = 3;
		if (value < 10000.0 && value > -10000.0)
		{
			digits = 4;
		}
		double num2 = GameUtility.TruncateToSignificantDigits(value, digits);
		_ = debug;
		if (CachedFormattedFloats.TryGetValue(num2, out var value2))
		{
			_ = debug;
			return value2;
		}
		value2 = GenerateLocalizedNumber(num2);
		_ = debug;
		CachedFormattedFloats[num2] = value2;
		return value2;
	}

	public static string LocalizedNumber(float value, bool round = true)
	{
		return LocalizedNumber((double)value, round);
	}

	private static string GenerateLocalizedNumber(double value)
	{
		_ = debug;
		double num = Math.Abs(value);
		if (num < 1.0)
		{
			return $"{value:0.00}";
		}
		if (num < 10.0)
		{
			return $"{value:0.0}";
		}
		if (num < 100.0)
		{
			return $"{value:0}";
		}
		if (num < 1000.0)
		{
			return $"{value:0}";
		}
		if (num < 10000.0)
		{
			return $"{value:0}";
		}
		int num2 = Mathf.FloorToInt(GameUtility.AsFloat(Math.Log10(num)));
		_ = debug;
		if (num2 < 3)
		{
			_ = debug;
			return $"{value:0}";
		}
		double num3 = Math.Pow(10.0, num2 - 2);
		double num4 = Math.Floor(num / num3) * num3;
		_ = debug;
		double num5 = Math.Pow(10.0, num2 / 3 * 3);
		double num6 = num4 / num5;
		string text = SuffixForNumTripleZeros(Mathf.FloorToInt(num2 / 3));
		_ = debug;
		if (text != null)
		{
			if (value < 0.0)
			{
				return $"-{num6:g3}{text}";
			}
			return $"{num6:g3}{text}";
		}
		return $"{value:g2}";
	}

	private static string SuffixForNumTripleZeros(int n)
	{
		return n switch
		{
			1 => Text("FormattedNumberThousands"), 
			2 => Text("FormattedNumberMillions"), 
			3 => Text("FormattedNumberBillions"), 
			4 => Text("FormattedNumberTrillions"), 
			5 => Text("FormattedNumber_e15"), 
			6 => Text("FormattedNumber_e18"), 
			7 => Text("FormattedNumber_e21"), 
			8 => Text("FormattedNumber_e24"), 
			9 => Text("FormattedNumber_e27"), 
			10 => Text("FormattedNumber_e30"), 
			11 => Text("FormattedNumber_e33"), 
			_ => null, 
		};
	}

	public static string LabelForBiome(BiomeType t)
	{
		return Text("BiomeType" + t);
	}

	public static string LabelForBiomeModifier(BiomeModifier m)
	{
		string value;
		switch (m.effect)
		{
		case BiomeModifierType.CraftingSpeed:
			value = "CraftingSpeed";
			break;
		case BiomeModifierType.ResourceRegen:
			value = "ResourceRegen";
			break;
		case BiomeModifierType.CultivationProductivity:
			value = "Productivity";
			break;
		case BiomeModifierType.ProspectingProductivity:
			value = "Productivity";
			break;
		case BiomeModifierType.RecipeProductivity:
			value = "Productivity";
			break;
		case BiomeModifierType.Land:
			return "Land".Localized();
		case BiomeModifierType.UniqueResource:
			value = "UniqueResource";
			break;
		case BiomeModifierType.UniqueRecipe:
			value = "UniqueResource";
			break;
		case BiomeModifierType.UniqueBuilding:
			value = "UniqueBuilding";
			break;
		case BiomeModifierType.ResourceCapacity:
			value = "ResourceCapacity";
			break;
		case BiomeModifierType.BuildingEffectiveness:
			value = "Effectiveness";
			break;
		case BiomeModifierType.MarketDemand:
			value = "Demand";
			break;
		case BiomeModifierType.Excluded:
			value = "Excluded";
			break;
		default:
			value = "BiomeModifier " + m.effect;
			break;
		}
		return value.Localized() + ": " + LabelForEntity(m.target);
	}

	public static string LabelForMultiplier(float value)
	{
		if (value > -10f && value < 10f)
		{
			double value2 = Math.Round((double)value * 100.0) / 100.0;
			return "x" + LocalizedNumber(value2, round: false);
		}
		return "x" + LocalizedNumber(value);
	}

	public static string Percent(float value)
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		if (value > 0f && value < 0.01f)
		{
			return "< " + string.Format(invariantCulture, PercentFormat, 0.01f);
		}
		return string.Format(invariantCulture, PercentFormat, value);
	}

	public static string SignedPercent(float value)
	{
		sb.Clear();
		if (value >= -0.0001f)
		{
			sb.Append("+");
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		sb.AppendFormat(invariantCulture, PercentFormat, value);
		return sb.ToString();
	}

	public static void SetPercent(TextMeshProUGUI label, float value, bool signed = false)
	{
		sb.Clear();
		if (signed && value >= -0.0001f)
		{
			sb.Append("+");
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		if (value > 0f && value < 0.01f)
		{
			sb.Append("< ");
			sb.AppendFormat(invariantCulture, PercentFormat, 0.01f);
		}
		else
		{
			value *= 100f;
			sb.Append(LocalizedNumber(value));
			sb.Append('%');
		}
		label.SetText(sb);
	}

	public static string GetRate(float value)
	{
		if (value >= 0f)
		{
			return "+" + string.Format(cultureInfo, PerSecondFormat, value);
		}
		return "-" + string.Format(cultureInfo, PerSecondFormat, Mathf.Abs(value));
	}

	public static void FormatInventoryChangeRate(TextMeshProUGUI label, ConsumableState itemState)
	{
		double perSecondAttemptedDelta = itemState.perSecondAttemptedDelta;
		_ = debug;
		label.color = itemState.TextColor();
		SetRate(label, GameUtility.AsFloat(perSecondAttemptedDelta));
	}

	public static string PerSecondRate(double value)
	{
		LoadRateIntoStringBuilder(GameUtility.AsFloat(value));
		return sb.ToString();
	}

	public static string PerSecondRate(float value)
	{
		LoadRateIntoStringBuilder(value);
		return sb.ToString();
	}

	private static void LoadRateIntoStringBuilder(float value, bool signed = true)
	{
		float num = -0.01f;
		sb.Clear();
		if (signed)
		{
			if (value > num)
			{
				sb.Append('+');
			}
			else
			{
				sb.Append('-');
			}
		}
		if (value > -0.01f && value < 0.01f)
		{
			sb.AppendFormat(PerSecondFormat, LocalizedNumber(0));
		}
		else if (value >= 1000f)
		{
			sb.AppendFormat(PerSecondFormatRounded, LocalizedNumber(value));
		}
		else if (value >= 100f)
		{
			sb.AppendFormat(cultureInfo, PerSecondFormatRounded, (int)value);
		}
		else if (value > 0f)
		{
			sb.AppendFormat(cultureInfo, PerSecondFormat, value);
		}
		else if (value <= -1000f)
		{
			sb.AppendFormat(cultureInfo, PerSecondFormatRounded, LocalizedNumber(Mathf.Abs(value)));
		}
		else if (value <= -100f)
		{
			sb.AppendFormat(cultureInfo, PerSecondFormatRounded, (int)Mathf.Abs(value));
		}
		else
		{
			sb.AppendFormat(cultureInfo, PerSecondFormat, Mathf.Abs(value));
		}
	}

	public static void SetRate(TextMeshProUGUI label, double value, bool signed = true)
	{
		LoadRateIntoStringBuilder(GameUtility.AsFloat(value), signed);
		label.SetText(sb);
	}

	public static void SetRate(TextMeshProUGUI label, float value)
	{
		LoadRateIntoStringBuilder(value);
		label.SetText(sb);
	}

	public static void SetNumber(TextMeshProUGUI label, double value)
	{
		label.SetText(LocalizedNumber(value));
	}

	public static void SetNumber(TextMeshProUGUI label, int value)
	{
		label.SetText(LocalizedNumber(value));
	}

	public static string LabelForRecipeType(RecipeType t)
	{
		EntityId key = EntityId.FromRecipe(t);
		if (CachedEntityLabels.TryGetValue(key, out var value))
		{
			return value;
		}
		if (Crafting.recipeCache.TryGetValue(t, out var value2))
		{
			ItemType itemType = value2.PrimaryOutputItem();
			if (itemType != ItemType.None)
			{
				value = LabelForItem(itemType);
				CachedEntityLabels[key] = value;
				return value;
			}
		}
		return Text("RecipeType" + t);
	}

	public static string LabelForDynamicResearch(DynamicResearchType t)
	{
		return Text("DynamicResearchType" + t);
	}

	public static string DescriptionForFarmingTool(FarmingToolType t)
	{
		return Text("FarmingToolDesc" + t);
	}

	public static string LabelForFarmingTool(FarmingToolType t)
	{
		EntityId key = EntityId.FromFarmingTool(t);
		if (CachedEntityLabels.TryGetValue(key, out var value))
		{
			return value;
		}
		value = Text("FarmingTool" + t);
		CachedEntityLabels[key] = value;
		return value;
	}

	public static string LabelForResearch(ResearchType t)
	{
		EntityId key = EntityId.FromResearch(t);
		if (CachedEntityLabels.TryGetValue(key, out var value))
		{
			return value;
		}
		switch (t)
		{
		case ResearchType.MarketCostUpgrades:
			return Strings.Def("Enhanced Market Construction", "ConstructionCost".Localized());
		case ResearchType.ManaPowerChainsawTanks:
			return "ManaPowerChainsawTank".Localized();
		case ResearchType.ManaPowerHarvesterDrills:
			return "ManaPowerDrills".Localized();
		case ResearchType.ManaPowerTractors:
			return "ManaPowerTractors".Localized();
		case ResearchType.ManaPowerCropHarvesters:
			return "ManaPowerCropHarvesters".Localized();
		case ResearchType.EtherBonusFirePower:
			value = "EtherBonus".Localized() + ": " + LabelForItem(ItemType.UtilityElementalFirePower);
			break;
		case ResearchType.EtherBonusWaterPower:
			value = "EtherBonus".Localized() + ": " + LabelForItem(ItemType.UtilityElementalWaterPower);
			break;
		case ResearchType.EtherBonusAirPower:
			value = "EtherBonus".Localized() + ": " + LabelForItem(ItemType.UtilityElementalAirPower);
			break;
		case ResearchType.EtherBonusEarthPower:
			value = "EtherBonus".Localized() + ": " + LabelForItem(ItemType.UtilityElementalEarthPower);
			break;
		case ResearchType.EtherBonusManaPower:
			value = "EtherBonus".Localized() + ": " + LabelForItem(ItemType.ManaPower);
			break;
		case ResearchType.InfiniteManaReactorProductivity:
			value = string.Format(LocalizedTwoValueFormat(), LabelForBuilding(BuildingType.ManaReactor), "Productivity".Localized());
			break;
		case ResearchType.InfiniteOmniTempleProductivity:
			value = string.Format(LocalizedTwoValueFormat(), LabelForBuilding(BuildingType.OmniTemple), "Productivity".Localized());
			break;
		case ResearchType.InfiniteOmnistoneValue:
			value = string.Format(LocalizedTwoValueFormat(), LabelForItem(ItemType.Omnistone), "SellValue".Localized());
			break;
		}
		if (value == null)
		{
			value = ((Crafting.researchCache.TryGetValue(t, out var value2) && value2.TryGetLocalizedOutput(out var s)) ? s : ((GameManager.Instance.activeTown == null || !GameManager.Instance.activeTown.research.TryGetValue(t, out var value3)) ? Text("ResearchType" + t) : value3.GetLocalizedOutput()));
		}
		LocalizationManager.IsEnglish();
		GameUtility.GlobalDebugFlag = false;
		CachedEntityLabels[key] = value;
		return value;
	}

	public static string LabelForQuest(QuestType t)
	{
		if (t == QuestType.AssignWorkersForGeneralStore)
		{
			return "AssignWorkers".Localized();
		}
		if (LocalizationManager.IsEnglish() && t == QuestType.SecondTownForTradingPost)
		{
			return "Town Expansion";
		}
		if (Crafting.questCache.TryGetValue(t, out var value))
		{
			int num = (int)t;
			if (num > Quest.DynamicQuestIdOffset)
			{
				QuestCategory t2;
				int num2 = (int)(t2 = (QuestCategory)(num / Quest.DynamicQuestIdOffset)) * Quest.DynamicQuestIdOffset;
				int num3 = (num - num2) / Quest.DynamicQuestLevelOffset;
				int num4 = num3 * Quest.DynamicQuestLevelOffset;
				string text;
				if (value.localizationEntity.type != EntityType.None)
				{
					text = string.Format(KeyValueFormatSpaced, LabelforQuestCategory(t2), LabelForEntity(value.localizationEntity));
				}
				else
				{
					Requirement requirement = GameManager.Instance.DisplayedRequirementForQuest(t);
					text = ((requirement == null) ? (LabelforQuestCategory(t2) + " " + num) : LabelForRequirement(requirement));
				}
				if (num3 > 0)
				{
					return text + " (" + GetFormattedLevelAbbreviation(num3 + 1) + ")";
				}
				return text;
			}
			if (value.localizationEntity.type != EntityType.None)
			{
				return LabelForEntity(value.localizationEntity);
			}
			Requirement requirement2 = GameManager.Instance.DisplayedRequirementForQuest(t);
			if (requirement2 != null)
			{
				return LabelForRequirement(requirement2);
			}
			return Text("Quest" + t);
		}
		return Text("Quest" + t);
	}

	public static string LabelforQuestCategory(QuestCategory t)
	{
		return t switch
		{
			QuestCategory.SoldGoods => "SellValue".Localized(), 
			QuestCategory.MiningSkillUpgrades => "Prospecting".Localized(), 
			QuestCategory.FarmingSkillUpgrades => "Cultivation".Localized(), 
			_ => Text("QuestCategory" + t), 
		};
	}

	public static string LabelForNaturalResource(NaturalResource t)
	{
		string text = OverrideLocalizationKeyForNaturalResource(t);
		if (text == null)
		{
			text = "ResourceLabel" + Item.ItemFromNaturalResource(t);
		}
		string text2 = LocalizationManager.LocalizedValueForKey(text);
		if (text2 != null)
		{
			return text2;
		}
		return LabelForItem(Item.ItemFromNaturalResource(t));
	}

	private static string OverrideLocalizationKeyForNaturalResource(NaturalResource t)
	{
		return t switch
		{
			NaturalResource.Ruby => "ResourceLabelRuby", 
			NaturalResource.Amethyst => "ResourceLabelAmethyst", 
			NaturalResource.Sapphire => "ResourceLabelSapphire", 
			NaturalResource.Topaz => "ResourceLabelTopaz", 
			NaturalResource.GoldOre => "ResourceLabelGold", 
			NaturalResource.Sand => "ResourceLabelSand", 
			_ => null, 
		};
	}

	public static string LabelForState(ConsumableState state)
	{
		if (state is ItemState itemState)
		{
			return LabelForItem(itemState.type);
		}
		if (state is ResourceState resourceState)
		{
			return LabelForNaturalResource(resourceState.type);
		}
		return string.Empty;
	}

	public static string LabelForItem(ItemType t, bool tryPlural = false)
	{
		EntityId key = EntityId.FromItem(t);
		if (!LocalizationManager.IsEnglish())
		{
			tryPlural = false;
		}
		if (tryPlural)
		{
			key = new EntityId((int)(t + 100000), EntityType.Item);
		}
		if (CachedEntityLabels.TryGetValue(key, out var value))
		{
			return value;
		}
		if (tryPlural)
		{
			switch (t)
			{
			case ItemType.Worker:
				value = "Workers";
				break;
			case ItemType.UtilityQuestCoin:
				value = "Quest Coins";
				break;
			case ItemType.TimeToken:
				value = "Time Tokens";
				break;
			}
		}
		if (value == null)
		{
			string text = OverrideLocalizationKeyForItem(t);
			value = ((text != null) ? text.Localized() : (t switch
			{
				ItemType.UtilityResearchGroupBasicProcessing => FormattedKeyValue("PermanentResearch", "BasicProcessing".Localized()), 
				ItemType.UtilityResearchGroupCultivation => FormattedKeyValue("PermanentResearch", "Cultivation".Localized()), 
				_ => Text("ItemLabel" + t), 
			}));
		}
		CachedEntityLabels[key] = value;
		return value;
	}

	private static string OverrideLocalizationKeyForItem(ItemType t)
	{
		return t switch
		{
			ItemType.UtilityHappiness => "Fulfillment", 
			ItemType.ClothConveyorBelt => "ItemLabelConveyorBeltCloth", 
			ItemType.MetalConveyorBelt => "ItemLabelConveyorBelt", 
			ItemType.MagicConveyorBelt => "ItemLabelConveyorBeltMagic", 
			ItemType.UtilityPrestigePoint => "PrestigePoints", 
			ItemType.UtilityLand => "Land", 
			ItemType.UtilityAutoAssign => "AutomaticAssignment", 
			ItemType.UtilityAutoClaim => "ClaimAutomatically", 
			ItemType.UtilityPrioritization => "Prioritization", 
			ItemType.UtilityVictory => "Victory", 
			ItemType.UtilityInput => "SlotTypeInput", 
			ItemType.UtilityOutput => "SlotTypeOutput", 
			ItemType.UtilityStorage => "Storage", 
			ItemType.UtilityTradeLocal => "Inventory", 
			ItemType.UtilityTradeGlobal => "GlobalTradeBalance", 
			ItemType.FishingNet => "FishingNet", 
			ItemType.MagicFishingNet => "EnchantedFishingNet", 
			ItemType.Star => "ItemLabelKnowledgeOrb", 
			ItemType.UtilityIdleRewardBoost => "ItemLabelRewardBoost", 
			_ => null, 
		};
	}

	public static string LabelforPauseState(PauseState pauseState)
	{
		return pauseState switch
		{
			PauseState.DefaultNone => "Default".Localized() + "/" + "Inherit".Localized(), 
			PauseState.Paused => "Paused".Localized(), 
			PauseState.Play => "Unpause".Localized(), 
			_ => string.Empty, 
		};
	}

	public static string LabelforPauseState(OverrideState overrideState)
	{
		return overrideState switch
		{
			OverrideState.None => "Default".Localized() + "/" + "Inherit".Localized(), 
			OverrideState.On => "Paused".Localized(), 
			OverrideState.Off => "Unpause".Localized(), 
			_ => string.Empty, 
		};
	}

	public static string LabelForPriority(StatePriority p)
	{
		return p switch
		{
			StatePriority.Highest => "Highest".Localized(), 
			StatePriority.High => "High".Localized(), 
			StatePriority.Regular => "Normal".Localized(), 
			StatePriority.Low => "Low".Localized(), 
			StatePriority.Lowest => "Lowest".Localized(), 
			_ => "Default".Localized() + "/" + "Inherit".Localized(), 
		};
	}

	public static string DescriptionForPriority(StatePriority p)
	{
		return p switch
		{
			StatePriority.Highest => "TooltipPriorityHighest".Localized(), 
			StatePriority.High => "TooltipPriorityHigh".Localized(), 
			StatePriority.Regular => "TooltipPriorityDefault".Localized(), 
			StatePriority.Low => "TooltipPriorityLow".Localized(), 
			StatePriority.Lowest => "TooltipPriorityLowest".Localized(), 
			_ => "TooltipPriorityDefault".Localized(), 
		};
	}

	public static string TooltipForTradeMode(TradeMode m)
	{
		if (m == TradeMode.Import || m == TradeMode.Export || m == TradeMode.None || m == TradeMode.Off)
		{
			return LabelForTradeMode(m);
		}
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append("Autobalance".Localized());
		pooledStringBuilder.Append(' ');
		pooledStringBuilder.Append('-');
		pooledStringBuilder.Append(' ');
		pooledStringBuilder.Append(LabelForTradeMode(m));
		pooledStringBuilder.Append(NewLine);
		pooledStringBuilder.Append('(');
		switch (m)
		{
		case TradeMode.AutoTradeLocalBalance:
			pooledStringBuilder.Append("AutoBalanceLocalDesc".Localized());
			break;
		case TradeMode.AutoTradeGlobalBalance:
			pooledStringBuilder.Append("AutoBalanceGlobalDesc".Localized());
			break;
		case TradeMode.AutoTradeLocalFill:
			pooledStringBuilder.Append("AutoBalanceLocalFillDesc".Localized());
			break;
		case TradeMode.AutoTradeGlobalFill:
			pooledStringBuilder.Append("AutoBalanceGlobalFillDesc".Localized());
			break;
		}
		pooledStringBuilder.Append(')');
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	public static string LabelForTradeMode(TradeMode m)
	{
		return m switch
		{
			TradeMode.None => "Default".Localized() + "/" + "Inherit".Localized(), 
			TradeMode.Off => "Off".Localized(), 
			TradeMode.Export => "Export".Localized(), 
			TradeMode.Import => "Import".Localized(), 
			TradeMode.AutoTradeLocalBalance => "AutoBalanceLocal".Localized(), 
			TradeMode.AutoTradeGlobalBalance => "AutoBalanceGlobal".Localized(), 
			TradeMode.AutoTradeLocalFill => "AutoBalanceLocalFill".Localized(), 
			TradeMode.AutoTradeGlobalFill => "AutoBalanceGlobalFill".Localized(), 
			_ => string.Empty, 
		};
	}

	public static string LabelForBuilding(BuildingType t, bool plural = false)
	{
		EntityId key = EntityId.FromBuilding(t);
		if (LocalizationManager.Instance.currentLanguage != UserLanguage.DefaultEnglish)
		{
			plural = false;
		}
		if (plural)
		{
			key = new EntityId((int)(t + 10000), EntityType.Building);
		}
		if (CachedEntityLabels.TryGetValue(key, out var value))
		{
			return value;
		}
		if (plural)
		{
			switch (t)
			{
			case BuildingType.House:
				value = "Houses";
				break;
			case BuildingType.LumberMill:
				value = "Lumber Mills";
				break;
			case BuildingType.TradingPost:
				value = "Trading Posts";
				break;
			case BuildingType.HarvesterHut:
				value = "Harvester Huts";
				break;
			}
		}
		if (value == null)
		{
			value = t switch
			{
				BuildingType.Chute => Text("StructureChute"), 
				BuildingType.HarvesterDrill => Text("ItemLabelHarvester"), 
				BuildingType.Airship => Text("ItemLabelAirship"), 
				BuildingType.Barrel => Text("StructureBarrel"), 
				BuildingType.Market => Text("BuildingLabelMarket"), 
				BuildingType.GeneralGoods => Text("BuildingLabelGeneralGoods"), 
				BuildingType.HardwareStore => Text("BuildingLabelHardwareStore"), 
				BuildingType.Minecart => Text("ItemLabelRailCart"), 
				BuildingType.SteamTrain => Text("ItemLabelSteamTrainEngine"), 
				BuildingType.Caravan => Text("ItemLabelCaravan"), 
				BuildingType.MagicRailTile => Text("ItemLabelRailTileMagic"), 
				BuildingType.MagicConveyorBelt => Text("ItemLabelConveyorBeltMagic"), 
				BuildingType.MagicForge => Text("BuildingLabelEnchantedForge"), 
				BuildingType.FishingBoat => Text("ItemLabelFishingBoat"), 
				BuildingType.ManaTransmitter => Text("BuildingLabelExtractor"), 
				BuildingType.ArcaneStore => Text("BuildingLabelMagicStore"), 
				BuildingType.Apothecary => Text("BuildingLabelHospital"), 
				_ => Text("BuildingLabel" + t), 
			};
		}
		CachedEntityLabels[key] = value;
		return value;
	}

	public static string DescriptionForBuilding(BuildingType b)
	{
		if (b == BuildingType.TradingPost)
		{
			return "BuildingDescriptionTradingPost".Localized();
		}
		return null;
	}

	public static string DescriptionForActiveTownUpgrade(UpgradeType u, int level)
	{
		if (GameManager.Instance.activeTown.upgrades.TryGetValue(u, out var value))
		{
			return DescriptionForUpgrade(value.type, level);
		}
		return null;
	}

	public static string DescriptionForUpgrade(UpgradeType upgradeType, int forcedLevel = -1)
	{
		if (!Crafting.upgradeCache.TryGetValue(upgradeType, out var value))
		{
			return null;
		}
		string text = "UpgradeDescription" + upgradeType;
		if (upgradeType == UpgradeType.OmniResearchSpeed)
		{
			text = "UpgradeDescriptionResearchSpeed";
		}
		Upgrade value2;
		float num = ((forcedLevel >= 0) ? Upgrade.BonusForUpgrade(upgradeType) : ((!GameManager.Instance.activeTown.upgrades.TryGetValue(upgradeType, out value2)) ? Upgrade.BonusForUpgrade(upgradeType) : value2.growthValue));
		switch (upgradeType)
		{
		case UpgradeType.Exploration:
			return string.Format(text.Localized(), num);
		case UpgradeType.HouseCapacity:
			return string.Format(Text("PerkDescriptionHousingCapacity"), Percent(num));
		case UpgradeType.ConstructionEfficiency:
			return string.Format(text.Localized(), Percent(Mathf.Abs(num)));
		case UpgradeType.BuildingConstructionSpeedGrowth:
			return string.Format("DescriptionConstructionSpeedGrowth".Localized(), Percent(num));
		case UpgradeType.PickaxeMiningYield:
			return string.Format("UpgradeDescriptionProductivityBooster".Localized(), LabelForBuilding(BuildingType.GemMine), Percent(num));
		case UpgradeType.ChainsawTankYield:
			return string.Format("UpgradeDescriptionProductivityBooster".Localized(), LabelForBuilding(BuildingType.ChainsawTank), Percent(num));
		case UpgradeType.FishingBoatYield:
			return string.Format("UpgradeDescriptionProductivityBooster".Localized(), LabelForBuilding(BuildingType.FishingBoat), Percent(num));
		case UpgradeType.CropHarvesterYield:
			return string.Format("UpgradeDescriptionProductivityBooster".Localized(), LabelForBuilding(BuildingType.CropHarvester), Percent(num));
		case UpgradeType.HarvesterDrillYield:
			return string.Format("UpgradeDescriptionProductivityBooster".Localized(), LabelForBuilding(BuildingType.HarvesterDrill), Percent(num));
		case UpgradeType.FuelEfficiency:
			return string.Format("UpgradeDescriptionEfficiencyBooster".Localized(), LabelForItem(ItemType.Fire), Percent(num));
		case UpgradeType.PowerLineSpeed:
		case UpgradeType.ManaPipeSpeed:
		case UpgradeType.SteamPipeSpeed:
		case UpgradeType.OmniPipeSpeed:
		case UpgradeType.MagmaPipeSpeed:
			return LabelForEntity(value.linkedEntity) + " " + "TradingSpeed".Localized() + " +" + Percent(num);
		case UpgradeType.ManaPowerDrills_Legacy:
		case UpgradeType.ManaPowerCropHarvesters_Legacy:
		case UpgradeType.FurnaceSpeed:
		case UpgradeType.OmniSpeedLumberMill:
		case UpgradeType.OmniSpeedGrainMill:
		case UpgradeType.OmniSpeedWorkshop:
		case UpgradeType.OmniSpeedTailor:
		case UpgradeType.OmniSpeedStoneMason:
		case UpgradeType.OmniSpeedPasture:
		case UpgradeType.OmniSpeedForge:
		case UpgradeType.OmniSpeedBakery:
		case UpgradeType.OmniSpeedGourmetKitchen:
		case UpgradeType.OmniSpeedJeweler:
		case UpgradeType.OmniSpeedMachineShop:
		case UpgradeType.OmniSpeedMedicineHut:
		case UpgradeType.OmniSpeedEnchantedForge:
		case UpgradeType.OmniSpeedExtractor:
		case UpgradeType.OmniSpeedEnchanter:
		case UpgradeType.OmniSpeedRefinery:
		case UpgradeType.OmniSpeedManaReactor:
		case UpgradeType.OmniSpeedFarm:
		case UpgradeType.OmniSpeedForester:
		case UpgradeType.OmniSpeedQuarry:
		case UpgradeType.OmniSpeedMine:
		case UpgradeType.OmniSpeedGemMine:
		case UpgradeType.OmniSpeedFishery:
		case UpgradeType.ManaChainsawTanks_Legacy:
		case UpgradeType.OmniSpeedStudy:
		case UpgradeType.OmniSpeedTechLab:
		case UpgradeType.OmniSpeedMagicLab:
		case UpgradeType.OmniSpeedOmniTemple:
		case UpgradeType.OmniSpeedHarvesterHut:
		case UpgradeType.OmniSpeedChainsawTank:
		case UpgradeType.OmniSpeedHarvesterDrill:
		case UpgradeType.OmniSpeedCropHarvester:
		case UpgradeType.OmniSpeedFireShrine:
		case UpgradeType.OmniSpeedWaterShrine:
		case UpgradeType.OmniSpeedEarthShrine:
		case UpgradeType.OmniSpeedAirShrine:
		case UpgradeType.OmniSpeedFurnace:
		case UpgradeType.OmniSpeedWaterPump:
		case UpgradeType.OmniSpeedSteamBoiler:
		case UpgradeType.OmniSpeedSteamPowerGenerator:
		case UpgradeType.OmniSpeedAqueduct:
		case UpgradeType.OmniSpeedWell:
			return string.Format("TooltipProductionSpeedBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.OmniProductivityLumberMill:
		case UpgradeType.OmniProductivityGrainMill:
		case UpgradeType.OmniProductivityWorkshop:
		case UpgradeType.OmniProductivityTailor:
		case UpgradeType.OmniProductivityStoneMason:
		case UpgradeType.OmniProductivityPasture:
		case UpgradeType.OmniProductivityForge:
		case UpgradeType.OmniProductivityBakery:
		case UpgradeType.OmniProductivityGourmetKitchen:
		case UpgradeType.OmniProductivityJeweler:
		case UpgradeType.OmniProductivityMachineShop:
		case UpgradeType.OmniProductivityMedicineHut:
		case UpgradeType.OmniProductivityEnchantedForge:
		case UpgradeType.OmniProductivityExtractor:
		case UpgradeType.OmniProductivityEnchanter:
		case UpgradeType.OmniProductivityRefinery:
		case UpgradeType.OmniProductivityManaReactor:
		case UpgradeType.OmniProductivityFarm:
		case UpgradeType.OmniProductivityForester:
		case UpgradeType.OmniProductivityQuarry:
		case UpgradeType.OmniProductivityMine:
		case UpgradeType.OmniProductivityGemMine:
		case UpgradeType.OmniProductivityFishery:
		case UpgradeType.OmniProductivityStudy:
		case UpgradeType.OmniProductivityTechLab:
		case UpgradeType.OmniProductivityMagicLab:
		case UpgradeType.OmniProductivityOmniTemple:
			return string.Format("TooltipProductivityBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.FireShrineSpeed:
		case UpgradeType.WaterShrineSpeed:
		case UpgradeType.EarthShrineSpeed:
		case UpgradeType.AirShrineSpeed:
			return string.Format("TooltipProductionSpeedBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.ShrineSpeed_Legacy:
			return string.Format("TooltipProductionSpeedBooster".Localized(), "Shrine".Localized(), Percent(num));
		case UpgradeType.TempleEffectivenessMana:
			return string.Format("TooltipEffectivenessBooster".Localized(), LabelForBuilding(BuildingType.ManaTemple), Percent(num));
		case UpgradeType.TempleEffectivenessFire:
			return string.Format("TooltipEffectivenessBooster".Localized(), LabelForBuilding(BuildingType.FireTemple), Percent(num));
		case UpgradeType.TempleEffectivenessWater:
			return string.Format("TooltipEffectivenessBooster".Localized(), LabelForBuilding(BuildingType.WaterTemple), Percent(num));
		case UpgradeType.TempleEffectivenessEarth:
			return string.Format("TooltipEffectivenessBooster".Localized(), LabelForBuilding(BuildingType.EarthTemple), Percent(num));
		case UpgradeType.TempleEffectivenessAir:
			return string.Format("TooltipEffectivenessBooster".Localized(), LabelForBuilding(BuildingType.AirTemple), Percent(num));
		case UpgradeType.ManaPowerTractors_Legacy:
			return string.Format("TooltipEffectivenessBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.ResearchSpeed:
		case UpgradeType.SkillGainSpeed:
		case UpgradeType.SkillEffectCrafting:
		case UpgradeType.SkillEffectHarvesting:
		case UpgradeType.SkillEffectCultivation:
		case UpgradeType.SkillEffectProspecting:
		case UpgradeType.HouseCost:
		case UpgradeType.OmniResearchSpeed:
			return string.Format(text.Localized(), Percent(num));
		case UpgradeType.SellValueYellowCoin:
		case UpgradeType.SellValueRedCoin:
		case UpgradeType.SellValueBlueCoin:
		case UpgradeType.SellValuePurpleCoin:
			return string.Format("TooltipSellValue".Localized(), Percent(num), LabelForEntity(value.linkedEntity));
		case UpgradeType.WarehouseCapacity:
		case UpgradeType.EtherStorageCapacity:
		case UpgradeType.ManaBatteryCapacity:
		case UpgradeType.OmnistoneStorageCapacity:
		case UpgradeType.LibraryCapacity:
		case UpgradeType.BatteryCapacity:
		case UpgradeType.CropSiloCapacity:
		case UpgradeType.OreSiloCapacity:
		case UpgradeType.PantryCapacity:
		case UpgradeType.TreasuryCapacity:
		case UpgradeType.StockpileCapacity:
		case UpgradeType.CrystalariumCapacity:
		case UpgradeType.ReservoirCapacity:
		case UpgradeType.FurnaceStorageCapacity:
		case UpgradeType.SteamBoilerStorageCapacity:
		case UpgradeType.BarrelCapacity:
		case UpgradeType.TradingPostStorageCapacity:
			return string.Format("TooltipStorageBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.FoodMarketCapacity:
		case UpgradeType.GeneralGoodsCapacity:
		case UpgradeType.ApothecaryCapacity:
		case UpgradeType.JewelryStoreCapacity:
		case UpgradeType.FancyFoodsCapacity:
		case UpgradeType.ClothingStoreCapacity:
		case UpgradeType.HardwareStoreCapacity:
		case UpgradeType.BookstoreCapacity:
		case UpgradeType.TradingPostWorkersPerBuilding:
		case UpgradeType.OmniCapacityFoodMarket:
		case UpgradeType.OmniCapacityGeneralStore:
		case UpgradeType.OmniCapacityHardwareStore:
		case UpgradeType.OmniCapacityBookstore:
		case UpgradeType.OmniCapacityClothingStore:
		case UpgradeType.OmniCapacityGourmetFoods:
		case UpgradeType.OmniCapacityApothecary:
		case UpgradeType.OmniCapacityJewelryStore:
		case UpgradeType.ArcaneStoreCapacity:
		case UpgradeType.OmniCapacityArcaneStore:
			return string.Format("TooltipMarketCapacityBooster".Localized(), LabelForEntity(value.linkedEntity), LocalizedNumber(num));
		case UpgradeType.MarketConsumptionFood:
		case UpgradeType.MarketConsumptionGeneralGoods:
		case UpgradeType.MarketConsumptionMedicine:
		case UpgradeType.MarketConsumptionJewelryStore:
		case UpgradeType.MarketConsumptionGourmetFood:
		case UpgradeType.MarketConsumptionClothing:
		case UpgradeType.MarketConsumptionHardwareStore:
		case UpgradeType.MarketConsumptionBookstore:
		case UpgradeType.MarketConsumptionArcaneGoods:
			return string.Format("TooltipConsumptionBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.StoneMasonProficiency:
		case UpgradeType.TailorProficiency:
		case UpgradeType.WorkshopProficiency:
		case UpgradeType.GrainMillProficiency:
		case UpgradeType.ForgeProficiency:
		case UpgradeType.BakeryProficiency:
		case UpgradeType.MachineShopProficiency:
		case UpgradeType.MedicineHutProficiency:
		case UpgradeType.LumberMillProficiency:
		case UpgradeType.MineProficiency:
		case UpgradeType.FarmingProficiency:
		case UpgradeType.FisheryProficiency:
		case UpgradeType.ForesterProficiency:
		case UpgradeType.EnchantedForgeProficiency:
		case UpgradeType.EnchanterProficiency:
		case UpgradeType.QuarryProficiency:
		case UpgradeType.GemMineProficiency:
		case UpgradeType.ExtractorProficiency:
		case UpgradeType.RefineryProficiency:
		case UpgradeType.JewelerProficiency:
		case UpgradeType.PastureProficiency:
		case UpgradeType.GourmetKitchenProficiency:
		case UpgradeType.StudyProficiency:
		case UpgradeType.TechLabProficiency:
		case UpgradeType.MagicLabProficiency:
		case UpgradeType.HarvesterHutProficiency:
		case UpgradeType.FishingBoatProficiency:
		case UpgradeType.CropHarvesterProficiency:
		case UpgradeType.ChainsawTankProficiency:
		case UpgradeType.HarvesterDrillProficiency:
			return string.Format("TooltipBuildingCapacityBooster".Localized(), LabelForEntity(value.linkedEntity), LocalizedNumber(num));
		case UpgradeType.GrainFarmingSpeed:
		case UpgradeType.CottonFarmingSpeed:
		case UpgradeType.HerbFarmingSpeed:
		case UpgradeType.PotatoFarmingSpeed:
		case UpgradeType.TomatoFarmingSpeed:
		case UpgradeType.SugarFarmingSpeed:
		case UpgradeType.AppleFarmingSpeed:
		case UpgradeType.PearFarmingSpeed:
		case UpgradeType.BerryFarmingSpeed:
		case UpgradeType.CactusFarmingSpeed:
		case UpgradeType.DragonFarmingSpeed:
		case UpgradeType.CarrotFarmingSpeed:
		case UpgradeType.TreeFarmingSpeed:
		case UpgradeType.FishFarmingSpeed:
			return string.Format("TooltipCultivationSpeedBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.CoalProspectingSpeed:
		case UpgradeType.IronProspectingSpeed:
		case UpgradeType.CopperProspectingSpeed:
		case UpgradeType.GoldProspectingSpeed:
		case UpgradeType.ManaProspectingSpeed:
		case UpgradeType.GemRedProspectingSpeed:
		case UpgradeType.GemYellowProspectingSpeed:
		case UpgradeType.GemAquaProspectingSpeed:
		case UpgradeType.GemPurpleProspectingSpeed:
		case UpgradeType.SilverProspectingSpeed:
		case UpgradeType.RockProspectingSpeed:
			return string.Format("TooltipProspectingSpeedBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.RockHarvestingSpeed:
		case UpgradeType.CoalHarvestingSpeed:
		case UpgradeType.IronHarvestingSpeed:
		case UpgradeType.CopperHarvestingSpeed:
		case UpgradeType.GoldHarvestingSpeed:
		case UpgradeType.ManaHarvestingSpeed:
		case UpgradeType.GemRedHarvestingSpeed:
		case UpgradeType.GemYellowHarvestingSpeed:
		case UpgradeType.GemAquaHarvestingSpeed:
		case UpgradeType.GemPurpleHarvestingSpeed:
		case UpgradeType.GrainHarvestingSpeed:
		case UpgradeType.CottonHarvestingSpeed:
		case UpgradeType.HerbHarvestingSpeed:
		case UpgradeType.PotatoHarvestingSpeed:
		case UpgradeType.TomatoHarvestingSpeed:
		case UpgradeType.SugarHarvestingSpeed:
		case UpgradeType.AppleHarvestingSpeed:
		case UpgradeType.PearHarvestingSpeed:
		case UpgradeType.BerryHarvestingSpeed:
		case UpgradeType.CactusHarvestingSpeed:
		case UpgradeType.DragonHarvestingSpeed:
		case UpgradeType.CarrotHarvestingSpeed:
		case UpgradeType.TreeHarvestingSpeed:
		case UpgradeType.FishHarvestingSpeed:
		case UpgradeType.SilverHarvestingSpeed:
		case UpgradeType.WaterHarvestingSpeed:
		case UpgradeType.FishingNetHarvestingSpeed:
		case UpgradeType.FishingMagicNetHarvestingSpeed:
		case UpgradeType.SandHarvestingSpeed:
			return string.Format("TooltipHarvestingSpeedBooster".Localized(), LabelForEntity(value.linkedEntity), Percent(num));
		case UpgradeType.MarketCostFood:
		case UpgradeType.MarketCostGeneral:
		case UpgradeType.MarketCostHardware:
		case UpgradeType.MarketCostBookstore:
		case UpgradeType.MarketCostClothing:
		case UpgradeType.MarketCostGourmet:
		case UpgradeType.MarketCostApothecary:
		case UpgradeType.MarketCostJewelry:
		case UpgradeType.MarketCostArcane:
		{
			EntityId linkedEntity = value.linkedEntity;
			return string.Format("UpgradeDescriptionCost".Localized(), LabelForEntity(linkedEntity), Percent(Mathf.Abs(num)));
		}
		case UpgradeType.AqueductEffectiveness:
		case UpgradeType.WaterPumpCountSpeed:
		case UpgradeType.SteamBoilerCountSpeed:
		case UpgradeType.FurnaceCountSpeed:
		case UpgradeType.ExtractorCountSpeed:
		case UpgradeType.WellEffectiveness:
		case UpgradeType.WaterWheelEffectiveness:
		case UpgradeType.SteamPowerGeneratorCountSpeed:
		case UpgradeType.SolarPanelEffectiveness:
		case UpgradeType.OmniSolarPanelEffectiveness:
		{
			if (LocalizationManager.IsEnglish())
			{
				return "Boosts production speed of " + LabelForEntity(value.linkedEntity) + "s by " + Percent(num);
			}
			string arg3 = string.Format("TooltipProductionBooster".Localized(), Percent(num));
			string arg4 = LabelForEntity(value.linkedEntity);
			return string.Format(LocalizedTwoValueFormat(), arg3, arg4);
		}
		case UpgradeType.FurnaceProductivity:
		{
			if (LocalizationManager.IsEnglish())
			{
				return "Increases " + LabelForEntity(value.linkedEntity) + " production amounts by " + Percent(num);
			}
			string arg = string.Format("TooltipProductivityBooster".Localized(), Percent(num));
			string arg2 = LabelForEntity(value.linkedEntity);
			return string.Format(LocalizedTwoValueFormat(), arg, arg2);
		}
		case UpgradeType.Supermarket:
		{
			if (value.linkedEntity.TryAsBuilding(out var b))
			{
				return string.Format("UpgradeDescriptionMarketSpeed".Localized(), LabelForBuilding(b), Percent(num));
			}
			break;
		}
		case UpgradeType.SellSpeedYellowCoin:
		case UpgradeType.SellSpeedRedCoin:
		case UpgradeType.SellSpeedBlueCoin:
		case UpgradeType.SellSpeedPurpleCoin:
		case UpgradeType.SellSpeedOmniCoin:
		{
			if (value.linkedEntity.TryAsItem(out var i2))
			{
				return string.Format("UpgradeDescriptionSellSpeed".Localized(), Percent(num), LabelForItem(i2));
			}
			break;
		}
		case UpgradeType.YellowCoinXP:
		case UpgradeType.RedCoinXP:
		case UpgradeType.BlueCoinXP:
		case UpgradeType.PurpleCoinXP:
		case UpgradeType.OmniCoinXP:
		{
			if (value.linkedEntity.TryAsItem(out var i))
			{
				return string.Format("UpgradeDescriptionCoinXPBoost".Localized(), LabelForItem(i), Percent(num));
			}
			break;
		}
		case UpgradeType.UpgradeEfficiency:
			return string.Format("PerkDescriptionUpgradeEfficiency".Localized(), Percent(Mathf.Abs(num)));
		}
		if (!LocalizationManager.HasLocalizedValueForKey(text))
		{
			return null;
		}
		return Text(text);
	}

	private static string FormattedDescriptionForDemand(string localizedFormat, bool usePercent, float current, float next, bool isAtMax)
	{
		current = Mathf.Abs(current);
		next = Mathf.Abs(next);
		sb.Clear();
		sb.Append("<color=#FFFF00>");
		if (usePercent)
		{
			sb.Append(Percent(current));
		}
		else
		{
			sb.Append(LocalizedNumber(current));
		}
		sb.Append("</color>");
		string value = string.Format("PerkDescriptionDemand".Localized(), localizedFormat, sb);
		sb.Clear();
		sb.Append(value);
		if (!isAtMax)
		{
			sb.Append(NewLine);
			sb.Append("NextLevel".Localized());
			sb.Append(' ');
			sb.Append("<color=#FFFF00>");
			if (usePercent)
			{
				sb.Append(Percent(next));
			}
			else
			{
				sb.Append(LocalizedNumber(next));
			}
			sb.Append("</color>");
		}
		return sb.ToString();
	}

	private static string FormattedDescriptionForPerk(string key, bool usePercent, float current, float next, bool isAtMax)
	{
		current = Mathf.Abs(current);
		next = Mathf.Abs(next);
		sb.Clear();
		sb.Append("<color=#FFFF00>");
		if (usePercent)
		{
			sb.Append(Percent(current));
		}
		else
		{
			sb.Append(LocalizedNumber(current));
		}
		sb.Append("</color>");
		string value = string.Format(key.Localized(), sb);
		sb.Clear();
		sb.Append(value);
		if (!isAtMax)
		{
			sb.Append(NewLine);
			sb.Append("NextLevel".Localized());
			sb.Append(' ');
			sb.Append("<color=#FFFF00>");
			if (usePercent)
			{
				sb.Append(Percent(next));
			}
			else
			{
				sb.Append(LocalizedNumber(next));
			}
			sb.Append("</color>");
		}
		return sb.ToString();
	}

	public static string LocalizationKeyForResearchDescription(ResearchType t)
	{
		switch (t)
		{
		case ResearchType.InfiniteCraftingSpeed:
			return "PerkDescriptionCraftingSpeed";
		case ResearchType.InfiniteNaturalResourceCapacity:
			return "PerkDescriptionNaturalResourceCapacity";
		case ResearchType.InfiniteGoodsConsumption:
			return "PerkDescriptionGoodsConsumption";
		case ResearchType.InfiniteResourceRegeneration:
			return "PerkDescriptionResourceRegen";
		case ResearchType.InfiniteKnowledgeSpeed:
			return "PerkDescriptionKnowledgeSpeed";
		case ResearchType.InfiniteMarketSellSpeed:
			return "ResearchDescMarketSellSpeed";
		case ResearchType.InfiniteSkillGainSpeed:
			return "UpgradeDescriptionSkillGainSpeed";
		case ResearchType.InfiniteOmnistoneValue:
			return "UpgradeDescriptionSellValue";
		case ResearchType.InfiniteManaReactorProductivity:
		case ResearchType.InfiniteOmniTempleProductivity:
			return "UpgradeDescriptionProductivityBooster";
		default:
			return "ResearchDesc" + t;
		}
	}

	public static string DescriptionForResearch(ResearchType t)
	{
		if (!Crafting.researchCache.TryGetValue(t, out var value))
		{
			return null;
		}
		switch (t)
		{
		case ResearchType.SupplyChain_Disabled:
			return "ConstructionManagementDesc".Localized();
		case ResearchType.InfiniteManaReactorProductivity:
		case ResearchType.InfiniteOmniTempleProductivity:
		{
			EntityId localizationEntity = value.localizationEntity;
			return string.Format(LocalizationKeyForResearchDescription(t).Localized(), LabelForEntity(localizationEntity), Percent(Research.GrowthValueForResearch(t)));
		}
		case ResearchType.InfiniteProspectingSpeed:
		{
			string localizedValue2 = SignedPercent(Research.GrowthValueForResearch(t));
			return FormattedKeyValue("ProspectingSpeed", localizedValue2);
		}
		case ResearchType.InfiniteCultivationSpeed:
		{
			string localizedValue = SignedPercent(Research.GrowthValueForResearch(t));
			return FormattedKeyValue("CultivationSpeed", localizedValue);
		}
		case ResearchType.InfiniteOmnistoneValue:
			return string.Format(LocalizationKeyForResearchDescription(t).Localized(), LabelForItem(ItemType.Omnistone), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.InfiniteKnowledgeSpeed:
		case ResearchType.InfiniteCraftingSpeed:
		case ResearchType.InfiniteResourceRegeneration:
		case ResearchType.InfiniteMarketSellSpeed:
		case ResearchType.InfiniteSkillGainSpeed:
		case ResearchType.InfiniteNaturalResourceCapacity:
		case ResearchType.InfiniteGoodsConsumption:
			return string.Format(LocalizationKeyForResearchDescription(t).Localized(), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.GrainProcessingSpeed:
		case ResearchType.WoodProcessingSpeed:
		case ResearchType.StoneProcessingSpeed:
		case ResearchType.MetalProcessingSpeed:
			return string.Format("TooltipProductionBooster".Localized(), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.PearFarming:
		case ResearchType.AppleFarming:
		case ResearchType.BerryFarming:
		case ResearchType.CottonFarming:
		case ResearchType.HerbFarming:
		case ResearchType.PotatoFarming:
		case ResearchType.CarrotFarming:
		case ResearchType.TomatoFarming:
		case ResearchType.SugarFarming:
		case ResearchType.CactusFarming:
		case ResearchType.DragonfruitFarming:
			return string.Format("TooltipCultivationSpeedBooster".Localized(), LabelForEntity(value.localizationEntity), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.CopperMining:
		case ResearchType.ManaMining:
		case ResearchType.GoldMining:
		case ResearchType.CoalMining:
		case ResearchType.SilverMining:
		case ResearchType.RubyMining:
		case ResearchType.SapphireMining:
		case ResearchType.AmethystMining:
		case ResearchType.TopazMining:
			return string.Format("TooltipProspectingSpeedBooster".Localized(), LabelForEntity(value.localizationEntity), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.ManaPowerHarvesterDrills:
			return string.Format("TooltipProductionSpeedBooster".Localized(), LabelForEntity(EntityId.FromBuilding(BuildingType.HarvesterDrill)), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.ManaPowerChainsawTanks:
			return string.Format("TooltipProductionSpeedBooster".Localized(), LabelForEntity(EntityId.FromBuilding(BuildingType.ChainsawTank)), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.ManaPowerCropHarvesters:
			return string.Format("TooltipProductionSpeedBooster".Localized(), LabelForEntity(EntityId.FromBuilding(BuildingType.CropHarvester)), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.ManaPowerTractors:
			return string.Format("TooltipProductionSpeedBooster".Localized(), LabelForEntity(EntityId.FromBuilding(BuildingType.Tractor)), Percent(Research.GrowthValueForResearch(t)));
		case ResearchType.EtherBonusManaPower:
		case ResearchType.EtherBonusFirePower:
		case ResearchType.EtherBonusWaterPower:
		case ResearchType.EtherBonusEarthPower:
		case ResearchType.EtherBonusAirPower:
		{
			EntityId entityId = Research.DerivedLinkedEntity(t);
			float value2 = Research.GrowthValueForResearch(t);
			if (LocalizationManager.IsEnglish())
			{
				return "Increases " + LabelForEntity(entityId) + " production amounts by " + Percent(value2);
			}
			string arg = string.Format("TooltipProductivityBooster".Localized(), Percent(value2));
			string arg2 = LabelForEntity(entityId);
			return string.Format(LocalizedTwoValueFormat(), arg, arg2);
		}
		default:
			return null;
		}
	}

	public static string LabelForDemandPerkCategory(PerkType t)
	{
		return t switch
		{
			PerkType.GourmetFoodsDemand => LabelForBuilding(BuildingType.FancyFoods), 
			PerkType.BooksDemand => LabelForBuilding(BuildingType.Bookstore), 
			PerkType.ConstructionDemand => LabelForBuilding(BuildingType.GeneralGoods), 
			PerkType.HardwareDemand => LabelForBuilding(BuildingType.HardwareStore), 
			PerkType.JewelryDemand => LabelForBuilding(BuildingType.JewelryStore), 
			PerkType.ClothingDemand => LabelForBuilding(BuildingType.ClothingStore), 
			PerkType.MedicineDemand => LabelForBuilding(BuildingType.Apothecary), 
			PerkType.MagicDemand => LabelForBuilding(BuildingType.ArcaneStore), 
			PerkType.GourmetFoodsStoreSpeed => LabelForBuilding(BuildingType.FancyFoods), 
			PerkType.BookStoreSpeed => LabelForBuilding(BuildingType.Bookstore), 
			PerkType.ConstructionStoreSpeed => LabelForBuilding(BuildingType.GeneralGoods), 
			PerkType.HardwareStoreSpeed => LabelForBuilding(BuildingType.HardwareStore), 
			PerkType.JewelryStoreSpeed => LabelForBuilding(BuildingType.JewelryStore), 
			PerkType.ClothingStoreSpeed => LabelForBuilding(BuildingType.ClothingStore), 
			PerkType.MedicineStoreSpeed => LabelForBuilding(BuildingType.Apothecary), 
			PerkType.MagicStoreSpeed => LabelForBuilding(BuildingType.ArcaneStore), 
			_ => string.Empty, 
		};
	}

	private static string FormattedValueForPerkLevel(PerkType t, int level)
	{
		GameManager instance = GameManager.Instance;
		switch (t)
		{
		case PerkType.MoreStartingLand:
		case PerkType.ExtraQuestCoins:
			return LocalizedNumber(instance.AdjustedMultiplierForPerkLevel(t, level));
		case PerkType.IdleGain:
			return LocalizedNumber(GameManager.MaxTimeTokensForPerkLevel(level));
		case PerkType.SpecializationCount:
			return LocalizedNumber(GameManager.Instance.MaxNumSpecialtiesForPerkLevel(level));
		case PerkType.SpecializationValue:
			return Percent(GameManager.Instance.SpecializationValueBonusPerPerkLevel(level));
		case PerkType.SpecializationDemand:
			return Percent(GameManager.Instance.SpecializationDemandBonusPerPerkLevel(level));
		case PerkType.SkillGainSpeed:
		case PerkType.CraftingSpeed:
		case PerkType.NaturalResourceCapacity:
		case PerkType.ResearchSpeed:
		case PerkType.ResearchEfficiency:
		case PerkType.GoodsConsumption:
		case PerkType.HousingCapacity:
		case PerkType.CultivationSpeed:
		case PerkType.MarketValue:
		case PerkType.ConstructionCost:
		case PerkType.ConstructionSpeed:
		case PerkType.ProspectingSpeed:
		case PerkType.MinigameXPGainSpeed:
		case PerkType.GlobalXPBoost:
		case PerkType.UpgradeEfficiency:
		case PerkType.LandCapacity:
		case PerkType.ResourceRegen:
		case PerkType.ConstructionEfficiency:
		case PerkType.ClickPower:
		case PerkType.HarvestingSpeed:
		case PerkType.GourmetFoodsDemand:
		case PerkType.BooksDemand:
		case PerkType.ConstructionDemand:
		case PerkType.HardwareDemand:
		case PerkType.JewelryDemand:
		case PerkType.ClothingDemand:
		case PerkType.MedicineDemand:
		case PerkType.MagicDemand:
		case PerkType.TownTradingSpeed:
		case PerkType.TownXPBoost:
		case PerkType.TownOmnistoneDemand:
		case PerkType.RemoveBiomeNegatives:
		case PerkType.GourmetFoodsStoreSpeed:
		case PerkType.BookStoreSpeed:
		case PerkType.ConstructionStoreSpeed:
		case PerkType.HardwareStoreSpeed:
		case PerkType.JewelryStoreSpeed:
		case PerkType.ClothingStoreSpeed:
		case PerkType.MedicineStoreSpeed:
		case PerkType.MagicStoreSpeed:
		case PerkType.GlobalMarketSpeed:
		case PerkType.GlobalTradingSpeed:
		case PerkType.KnowledgeSpeed:
		case PerkType.GlobalResearchSpeed:
			return Percent(Mathf.Abs(instance.AdjustedMultiplierForPerkLevel(t, level) - 1f));
		case PerkType.GlobalTradingCapacity:
			return Percent(Mathf.Abs(instance.AdjustedMultiplierForPerkLevel(t, level)));
		case PerkType.StorageBoost:
		{
			float f = instance.AdjustedMultiplierForPerkLevel(t, level);
			return "PeakDemand".Localized() + " x " + Percent(Mathf.Abs(f));
		}
		default:
			return Percent(instance.AdjustedMultiplierForPerkLevel(t, level));
		}
	}

	public static string DescriptionForPerk(PerkState perkState)
	{
		int num = GameUtility.RoundToInt(perkState.currentCount);
		if (num == 0)
		{
			return DescriptionForPerkTypeNew(perkState.type, 1, useNextFormatting: false);
		}
		return DescriptionForPerkTypeNew(perkState.type, num, useNextFormatting: true);
	}

	public static string LocalizedFormatStringForPerk(PerkType type)
	{
		string value;
		switch (type)
		{
		case PerkType.ConstructionCost:
			value = "PerkDescriptionConstructionCost";
			break;
		case PerkType.GlobalResearchSpeed:
			value = "PerkDescriptionResearchSpeed";
			break;
		case PerkType.ConstructionEfficiency:
			value = "PerkDescriptionConstructionEfficiency";
			break;
		case PerkType.GlobalTradingCapacity:
			value = "TooltipTradingStorageDemandBoost";
			break;
		case PerkType.GlobalXPBoost:
		case PerkType.TownXPBoost:
			value = "PerkDescriptionTownXPAmount";
			break;
		case PerkType.TownOmnistoneDemand:
		{
			string arg2 = LabelForItem(ItemType.Omnistone);
			return string.Format("PerkDescriptionDemand".Localized(), arg2, "{0}");
		}
		case PerkType.GourmetFoodsDemand:
		case PerkType.BooksDemand:
		case PerkType.ConstructionDemand:
		case PerkType.HardwareDemand:
		case PerkType.JewelryDemand:
		case PerkType.ClothingDemand:
		case PerkType.MedicineDemand:
		case PerkType.MagicDemand:
		{
			string arg = LabelForDemandPerkCategory(type);
			return string.Format("PerkDescriptionDemand".Localized(), arg, "{0}");
		}
		case PerkType.GlobalMarketSpeed:
			return "ResearchDescMarketSellSpeed".Localized();
		case PerkType.TownTradingSpeed:
			if (LocalizationManager.IsEnglish())
			{
				return "Increases trading speed within this Town by {0}";
			}
			return "PerkDescriptionTradingSpeed".Localized();
		case PerkType.GlobalTradingSpeed:
			if (LocalizationManager.IsEnglish())
			{
				return "Increases trading speed for all Towns by {0}";
			}
			return "PerkDescriptionTradingSpeed".Localized();
		case PerkType.GourmetFoodsStoreSpeed:
		case PerkType.BookStoreSpeed:
		case PerkType.ConstructionStoreSpeed:
		case PerkType.HardwareStoreSpeed:
		case PerkType.JewelryStoreSpeed:
		case PerkType.ClothingStoreSpeed:
		case PerkType.MedicineStoreSpeed:
		case PerkType.MagicStoreSpeed:
		{
			string arg3 = LabelForDemandPerkCategory(type);
			return string.Format("UpgradeDescriptionMarketSpeed".Localized(), arg3, "{0}");
		}
		case PerkType.IdleGain:
		{
			StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
			pooledStringBuilder.Append(LabelForItem(ItemType.TimeToken));
			if (LocalizationManager.IsCurrentLanguageSpaced())
			{
				pooledStringBuilder.Append(' ');
			}
			pooledStringBuilder.Append("Max".Localized());
			pooledStringBuilder.Append(':');
			if (LocalizationManager.IsCurrentLanguageSpaced())
			{
				pooledStringBuilder.Append(' ');
			}
			pooledStringBuilder.Append("{0}");
			pooledStringBuilder.Append(NewLine);
			pooledStringBuilder.Append("TooltipTimeTokens".Localized());
			return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
		}
		default:
			value = "PerkDescription" + type;
			break;
		}
		return value.Localized();
	}

	public static string DescriptionForPerkTypeNew(PerkType type, int overrideLevel, bool useNextFormatting)
	{
		int num = int.MaxValue;
		if (Crafting.perkDefCache.TryGetValue(type, out var value))
		{
			num = value.maxLevel;
		}
		string text = LocalizedFormatStringForPerk(type);
		if (type == PerkType.Specialization)
		{
			return text;
		}
		string value2 = FormattedValueForPerkLevel(type, overrideLevel);
		bool flag = overrideLevel >= num;
		sb.Clear();
		sb.Append("<color=#FFFF00>");
		sb.Append(value2);
		sb.Append("</color>");
		string value3 = string.Format(text, sb);
		sb.Clear();
		sb.Append(value3);
		if (useNextFormatting && !flag)
		{
			string value4 = FormattedValueForPerkLevel(type, overrideLevel + 1);
			sb.Append(NewLine);
			sb.Append("NextLevel".Localized());
			sb.Append(' ');
			sb.Append("<color=#FFFF00>");
			sb.Append(value4);
			sb.Append("</color>");
		}
		return sb.ToString();
	}

	public static string LabelforBuildingCategory(BuildingCategory c)
	{
		return LocalizationKeyforBuildingCategory(c).Localized();
	}

	public static string LocalizationKeyforAvailability(BuildObjectAvailability a)
	{
		return a switch
		{
			BuildObjectAvailability.Available => "Available", 
			BuildObjectAvailability.Locked => "Locked", 
			BuildObjectAvailability.Completed => "Completed", 
			BuildObjectAvailability.InProgress => "InProgress", 
			_ => a.ToString(), 
		};
	}

	public static string LocalizationKeyforBuildingCategory(BuildingCategory c)
	{
		return c switch
		{
			BuildingCategory.Housing => "Buildings", 
			BuildingCategory.Markets => "Markets", 
			BuildingCategory.Production => "Crafting", 
			BuildingCategory.Cultivation => "Cultivation", 
			BuildingCategory.Harvesting => "Harvesting", 
			BuildingCategory.Trading => "Trading", 
			BuildingCategory.Prospecting => "Prospecting", 
			BuildingCategory.Storage => "Storage", 
			BuildingCategory.Research => "Knowledge", 
			BuildingCategory.None => "Default", 
			_ => Text("BuildingCategory" + c), 
		};
	}

	public static string LabelForUpgrade(UpgradeType t)
	{
		EntityId key = EntityId.FromUpgrade(t);
		if (CachedEntityLabels.TryGetValue(key, out var value))
		{
			return value;
		}
		string text = DerivedLabelForUpgrade(t);
		CachedEntityLabels[key] = text;
		return text;
	}

	private static string DerivedLabelForUpgrade(UpgradeType t)
	{
		switch (t)
		{
		case UpgradeType.ConstructionEfficiency:
			return "ConstructionEfficiency".Localized();
		case UpgradeType.UpgradeEfficiency:
			return "UpgradeEfficiency".Localized();
		case UpgradeType.LuckyPickaxe:
			return Text("LuckyPickaxe");
		case UpgradeType.BuildingConstructionSpeedGrowth:
			return Text("BuildingConstructionSpeed");
		case UpgradeType.AqueductEffectiveness:
			return BuildingModifier(BuildingType.Aqueduct, "Effectiveness");
		case UpgradeType.WellEffectiveness:
			return BuildingModifier(BuildingType.Well, "Effectiveness");
		case UpgradeType.WaterWheelEffectiveness:
			return BuildingModifier(BuildingType.WaterWheel, "Effectiveness");
		case UpgradeType.SolarPanelEffectiveness:
			return BuildingModifier(BuildingType.SolarPanel, "Effectiveness");
		case UpgradeType.PowerLineSpeed:
			return BuildingModifier(BuildingType.PowerLine, "TradingSpeed");
		case UpgradeType.SteamPipeSpeed:
			return BuildingModifier(BuildingType.SteamPipeline, "TradingSpeed");
		case UpgradeType.MagmaPipeSpeed:
			return BuildingModifier(BuildingType.MagmaPipeline, "TradingSpeed");
		case UpgradeType.ManaPipeSpeed:
			return BuildingModifier(BuildingType.ManaPipeline, "TradingSpeed");
		case UpgradeType.OmniPipeSpeed:
			return BuildingModifier(BuildingType.OmniPipeline, "TradingSpeed");
		case UpgradeType.OmniSolarPanelEffectiveness:
			return BuildingModifier(BuildingType.SolarPanel, "Effectiveness");
		case UpgradeType.PickaxeMiningYield:
			return BuildingModifier(BuildingType.GemMine, "Productivity");
		case UpgradeType.ChainsawTankYield:
			return BuildingModifier(BuildingType.ChainsawTank, "Productivity");
		case UpgradeType.FishingBoatYield:
			return BuildingModifier(BuildingType.FishingBoat, "Productivity");
		case UpgradeType.CropHarvesterYield:
			return BuildingModifier(BuildingType.CropHarvester, "Productivity");
		case UpgradeType.HarvesterDrillYield:
			return BuildingModifier(BuildingType.HarvesterDrill, "Productivity");
		case UpgradeType.HouseCost:
			if (LocalizationManager.IsEnglish())
			{
				return "Cheaper Houses";
			}
			return Text("HouseCost");
		case UpgradeType.HouseCapacity:
			return Text("HouseCapacity");
		case UpgradeType.ManaPowerDrills_Legacy:
			return Text("ManaPowerDrills");
		case UpgradeType.ManaChainsawTanks_Legacy:
			return Text("ManaPowerChainsawTank");
		case UpgradeType.ManaPowerCropHarvesters_Legacy:
			return Text("ManaPowerCropHarvesters");
		case UpgradeType.ManaPowerTractors_Legacy:
			return Text("ManaPowerTractors");
		case UpgradeType.SkillEffectCrafting:
			return "SkillEffectStrength".Localized() + ": " + "Crafting".Localized();
		case UpgradeType.SkillEffectCultivation:
			return "SkillEffectStrength".Localized() + ": " + "Cultivation".Localized();
		case UpgradeType.SkillEffectHarvesting:
			return "SkillEffectStrength".Localized() + ": " + "Harvesting".Localized();
		case UpgradeType.SkillEffectProspecting:
			return "SkillEffectStrength".Localized() + ": " + "Prospecting".Localized();
		case UpgradeType.ResearchSpeed:
			return "ResearchSpeed".Localized();
		case UpgradeType.OmniResearchSpeed:
			return "ResearchSpeed".Localized();
		case UpgradeType.SkillGainSpeed:
			return "SkillGainSpeed".Localized();
		case UpgradeType.FurnaceSpeed:
			return "SpeedBoost".Localized() + ": " + LabelForBuilding(BuildingType.Furnace);
		case UpgradeType.FuelEfficiency:
			return "FuelEfficiency".Localized();
		case UpgradeType.Supermarket:
			return "Supermarket".Localized();
		case UpgradeType.SellSpeedYellowCoin:
			return "SellSpeedYellow".Localized();
		case UpgradeType.SellSpeedRedCoin:
			return "SellSpeedRed".Localized();
		case UpgradeType.SellSpeedBlueCoin:
			return "SellSpeedBlue".Localized();
		case UpgradeType.SellSpeedPurpleCoin:
			return "SellSpeedPurple".Localized();
		case UpgradeType.SellSpeedOmniCoin:
			return "SellSpeedOmniCoin".Localized();
		case UpgradeType.Exploration:
			return "Exploration".Localized();
		case UpgradeType.TempleEffectivenessMana:
			return "Effectiveness".Localized() + ": " + LabelForBuilding(BuildingType.ManaTemple);
		case UpgradeType.TempleEffectivenessFire:
			return "Effectiveness".Localized() + ": " + LabelForBuilding(BuildingType.FireTemple);
		case UpgradeType.TempleEffectivenessWater:
			return "Effectiveness".Localized() + ": " + LabelForBuilding(BuildingType.WaterTemple);
		case UpgradeType.TempleEffectivenessEarth:
			return "Effectiveness".Localized() + ": " + LabelForBuilding(BuildingType.EarthTemple);
		case UpgradeType.TempleEffectivenessAir:
			return "Effectiveness".Localized() + ": " + LabelForBuilding(BuildingType.AirTemple);
		case UpgradeType.FireShrineSpeed:
			return "SpeedBoost".Localized() + ": " + LabelForBuilding(BuildingType.FireShrine);
		case UpgradeType.WaterShrineSpeed:
			return "SpeedBoost".Localized() + ": " + LabelForBuilding(BuildingType.WaterShrine);
		case UpgradeType.EarthShrineSpeed:
			return "SpeedBoost".Localized() + ": " + LabelForBuilding(BuildingType.EarthShrine);
		case UpgradeType.AirShrineSpeed:
			return "SpeedBoost".Localized() + ": " + LabelForBuilding(BuildingType.AirShrine);
		case UpgradeType.ShrineSpeed_Legacy:
			return "SpeedBoost".Localized() + ": " + "Shrine".Localized();
		case UpgradeType.YellowCoinXP:
			return "TownXPMultiplier".Localized() + ": " + LabelForItem(ItemType.YellowCoin);
		case UpgradeType.RedCoinXP:
			return "TownXPMultiplier".Localized() + ": " + LabelForItem(ItemType.RedCoin);
		case UpgradeType.BlueCoinXP:
			return "TownXPMultiplier".Localized() + ": " + LabelForItem(ItemType.BlueCoin);
		case UpgradeType.PurpleCoinXP:
			return "TownXPMultiplier".Localized() + ": " + LabelForItem(ItemType.PurpleCoin);
		case UpgradeType.OmniCoinXP:
			return "TownXPMultiplier".Localized() + ": " + LabelForItem(ItemType.OmniCoin);
		case UpgradeType.MarketCostFood:
		case UpgradeType.MarketCostGeneral:
		case UpgradeType.MarketCostHardware:
		case UpgradeType.MarketCostBookstore:
		case UpgradeType.MarketCostClothing:
		case UpgradeType.MarketCostGourmet:
		case UpgradeType.MarketCostApothecary:
		case UpgradeType.MarketCostJewelry:
		case UpgradeType.MarketCostArcane:
		{
			UpgradeDef upgradeDef = Crafting.upgradeCache[t];
			return "ConstructionCost".Localized() + ": " + LabelForEntity(upgradeDef.linkedEntity);
		}
		default:
		{
			if (Crafting.upgradeCache.TryGetValue(t, out var value) && value.linkedEntity.type != EntityType.None && value.linkedModifierKey != null)
			{
				if (LocalizationManager.IsEnglish())
				{
					return $"{LabelForEntity(value.linkedEntity)} {value.linkedModifierKey.Localized()}";
				}
				return string.Format(CurrentLanguageKeyValueFormat(), value.linkedModifierKey.Localized(), LabelForEntity(value.linkedEntity));
			}
			return Text("Upgrade" + t);
		}
		}
	}

	public static string LocalizationKeyForQuestGrouping(QuestGroup g)
	{
		if (g == QuestGroup.Completed)
		{
			return "Completed";
		}
		return "QuestGroup" + g;
	}

	public static string LocalizationKeyForSpecialty(Specialty t)
	{
		return t switch
		{
			Specialty.None => "ItemLabelNone", 
			Specialty.UniqueExport => "UniqueResource", 
			Specialty.UniqueImport => "UniqueResource", 
			Specialty.AnimalProducts => "AnimalProducts", 
			Specialty.Clothing => "Clothing", 
			Specialty.Construction => "Construction", 
			Specialty.PlantProducts => "PlantProducts", 
			Specialty.Jewelry => "Jewelry", 
			Specialty.Knowledge => "Knowledge", 
			Specialty.Magic => "Magic", 
			Specialty.Medicine => "Medicine", 
			Specialty.Metal => "Metal", 
			Specialty.Tech => "Tech", 
			Specialty.Enchanting => "Enchanting", 
			Specialty.Crops => "Crops", 
			Specialty.Minerals => "Minerals", 
			Specialty.Energy => "Energy", 
			Specialty.Gourmet => "Gourmet", 
			Specialty.NaturalResources => "NaturalResources", 
			Specialty.Currencies => "Coins", 
			Specialty.ElementalCrystals => "ElementalCrystals", 
			Specialty.ElementalPower => "ElementalPower", 
			_ => "Specialty" + t, 
		};
	}

	public static string LabelForSpecialty(Specialty t)
	{
		return Text(LocalizationKeyForSpecialty(t));
	}

	public static string FormattedBuildingCount(BuildingType t, float amount)
	{
		sb.Clear();
		sb.AppendFormat(KeyValueFormat, LabelForBuilding(t), LocalizedNumber(amount));
		return sb.ToString();
	}

	public static string CurrentLanguageKeyValueFormat()
	{
		if (!LocalizationManager.IsCurrentLanguageSpaced())
		{
			return KeyValueFormat;
		}
		return KeyValueFormatSpaced;
	}

	public static string FormattedKeyValue(string key, string localizedValue)
	{
		string format = CurrentLanguageKeyValueFormat();
		sb.Clear();
		sb.AppendFormat(format, key.Localized(), localizedValue);
		return sb.ToString();
	}

	public static string LabelForResearchLevel(ResearchType t, int level)
	{
		sb.Clear();
		sb.Append(LabelForResearch(t));
		sb.Append(" ");
		sb.AppendFormat(LevelFormatShort, LocalizedNumber(level));
		return sb.ToString();
	}

	public static string LabelForDynamicResearchLevel(DynamicResearchType t, int level)
	{
		sb.Clear();
		sb.Append(LabelForDynamicResearch(t));
		sb.Append(" ");
		sb.AppendFormat(LevelFormatShort, LocalizedNumber(level));
		return sb.ToString();
	}

	public static string LabelForUpgradeLevel(UpgradeType t, int level)
	{
		sb.Clear();
		sb.Append(LabelForUpgrade(t));
		sb.Append(" ");
		sb.AppendFormat(LevelFormatShort, LocalizedNumber(level));
		return sb.ToString();
	}

	public static string LabelForCommand(string formatString, double amount, string localizedObject)
	{
		return string.Format(formatString.Localized(), LocalizedNumber(amount), localizedObject);
	}

	public static string LabelForRequirement(Requirement r)
	{
		if (!(r is RequiredFullGame))
		{
			if (!(r is RequiredPopulationCount requiredPopulationCount))
			{
				if (!(r is RequiredProductionCount requiredProductionCount))
				{
					if (!(r is RequiredQuest requiredQuest))
					{
						if (!(r is RequiredBiome requiredBiome))
						{
							if (!(r is RequiredUpgradeCount requiredUpgradeCount))
							{
								if (!(r is RequiredMarketSellCount requiredMarketSellCount))
								{
									if (!(r is RequiredMinigameLevel requiredMinigameLevel))
									{
										if (!(r is RequiredCoinSpendCount requiredCoinSpendCount))
										{
											if (!(r is RequiredMinBuildingCount requiredMinBuildingCount))
											{
												if (!(r is RequiredMinResearchCount requiredMinResearchCount))
												{
													if (!(r is RequiredResearch requiredResearch))
													{
														if (!(r is RequiredGenericFlag requiredGenericFlag))
														{
															if (!(r is RequiredGenericCount requiredGenericCount))
															{
																if (!(r is RequiredTownLevel requiredTownLevel))
																{
																	if (!(r is RequiredSkillXP requiredSkillXP))
																	{
																		if (!(r is RequiredSkillLevelCount requiredSkillLevelCount))
																		{
																			if (!(r is RequiredBuildingSkills requiredBuildingSkills))
																			{
																				if (!(r is RequiredPerk requiredPerk))
																				{
																					if (!(r is RequiredUpgrade requiredUpgrade))
																					{
																						if (!(r is RequiredNaturalResource requiredNaturalResource))
																						{
																							if (!(r is RequiredHarvestRecipe requiredHarvestRecipe))
																							{
																								if (!(r is RequiredItem requiredItem))
																								{
																									if (r is RequiredSkillLevel requiredSkillLevel)
																									{
																										string format = Text("ReachSpecificLevelFormat");
																										string text;
																										if (requiredSkillLevel.skillType == SkillType.Crafting)
																										{
																											text = LabelForEntity(requiredSkillLevel.skillId);
																											if (LocalizationManager.IsEnglish())
																											{
																												text += " Crafting";
																											}
																										}
																										else if (requiredSkillLevel.skillType == SkillType.Harvesting)
																										{
																											text = LabelForEntity(requiredSkillLevel.skillId);
																											if (LocalizationManager.IsEnglish())
																											{
																												text += " Harvesting";
																											}
																										}
																										else
																										{
																											text = string.Format(LocalizedTwoValueFormat(), LabelForEntity(requiredSkillLevel.skillId), LabelForSkillCategory(requiredSkillLevel.skillType));
																										}
																										return string.Format(format, LocalizedNumber(requiredSkillLevel.targetLevel), text);
																									}
																									return Text("Requirement" + r);
																								}
																								return FormattedRewardEntityWithType(EntityId.FromItem(requiredItem.itemType));
																							}
																							return FormattedRewardEntityWithType(EntityId.FromHarvestRecipe(requiredHarvestRecipe.harvestRecipeType));
																						}
																						return FormattedRewardEntityWithType(EntityId.FromNaturalResource(requiredNaturalResource.resourceType));
																					}
																					string text2 = LocalizationKeyForRewardEntity(EntityType.Upgrade).Localized();
																					string text3 = LabelForUpgradeLevel(requiredUpgrade.upgradeType, requiredUpgrade.targetLevel);
																					return "(" + text2 + ") " + text3;
																				}
																				string text4 = ((!Crafting.globalPerks.Contains(requiredPerk.perkType)) ? "TownPerks".Localized() : "Perks".Localized());
																				if (requiredPerk.targetLevel == 0)
																				{
																					return "(" + text4 + ") " + LabelForPerk(requiredPerk.perkType);
																				}
																				string arg = string.Format(LevelFormatShort, LocalizedNumber(requiredPerk.targetLevel));
																				string text5 = string.Format(LocalizedTwoValueFormat(), LabelForPerk(requiredPerk.perkType), arg);
																				return "(" + text4 + ") " + text5;
																			}
																			string arg2 = LabelForBuilding(requiredBuildingSkills.buildingType);
																			return string.Format("HaveTotalSkillLevelsFormat".Localized(), LocalizedNumber(requiredBuildingSkills.totalLevels), arg2);
																		}
																		if (requiredSkillLevelCount.skillType == SkillType.None)
																		{
																			return string.Format("HaveSkillsFormat".Localized(), LocalizedNumber(requiredSkillLevelCount.targetCount), requiredSkillLevelCount.targetLevel);
																		}
																		string arg3 = LabelForSkillCategory(requiredSkillLevelCount.skillType);
																		return string.Format("HaveCategorySkillsFormat".Localized(), LocalizedNumber(requiredSkillLevelCount.targetCount), arg3, requiredSkillLevelCount.targetLevel);
																	}
																	string text6 = null;
																	text6 = (LocalizationManager.IsEnglish() ? "Have {0} {1} {2} {3}" : ((!LocalizationManager.IsCurrentLanguageSpaced()) ? "{0}{1}{2}{3}" : "{0} {1} {2} {3}"));
																	string text7 = LabelForSkillCategory(requiredSkillXP.skillType);
																	return string.Format(text6, LocalizedNumber(requiredSkillXP.targetCount), text7, "Skill".Localized(), "ExperiencePointsShort".Localized());
																}
																if (requiredTownLevel.requiredBiome != BiomeType.None)
																{
																	return string.Format("ReachTownLevelInBiomeFormat".Localized(), LocalizedNumber(requiredTownLevel.requiredTownLevel), LabelForBiome(requiredTownLevel.requiredBiome));
																}
																return string.Format("ReachTownLevelFormat".Localized(), LocalizedNumber(requiredTownLevel.requiredTownLevel));
															}
															if (LocalizationManager.IsEnglish() && requiredGenericCount.tooltipLocalizationKey == "AssignWorkers")
															{
																return "Assign Tree Harvesters";
															}
															return requiredGenericCount.tooltipLocalizationKey.Localized();
														}
														return requiredGenericFlag.tooltipLocalizationKey.Localized();
													}
													return FormattedRewardEntityWithType(EntityId.FromResearch(requiredResearch.researchType));
												}
												return string.Format("CompleteResearchFormat".Localized(), LocalizedNumber(requiredMinResearchCount.amount));
											}
											if (LocalizationManager.IsEnglish() && requiredMinBuildingCount.buildingType == BuildingType.Base)
											{
												string text8 = LocalizedNumber(requiredMinBuildingCount.numBuildingsRequired);
												return "Have Towns in " + text8 + " different Biomes";
											}
											if (requiredMinBuildingCount.buildingType == BuildingType.None)
											{
												return LabelForCommand("BuildQuestFormat", requiredMinBuildingCount.numBuildingsRequired, "Buildings".Localized());
											}
											return LabelForCommand("BuildQuestFormat", requiredMinBuildingCount.numBuildingsRequired, LabelForBuilding(requiredMinBuildingCount.buildingType, requiredMinBuildingCount.numBuildingsRequired > 1));
										}
										return string.Format("SpendCoinsFormat".Localized(), LocalizedNumber(requiredCoinSpendCount.targetCount), LabelForItem(requiredCoinSpendCount.coinType));
									}
									string headerKey = requiredMinigameLevel.GetHeaderKey();
									return string.Format("ReachSpecificLevelFormat".Localized(), LocalizedNumber(requiredMinigameLevel.requiredLevel), Text(headerKey));
								}
								return string.Format("SellQuestFormat".Localized(), LocalizedNumber(requiredMarketSellCount.targetCount), LabelForBuilding(requiredMarketSellCount.buildingType));
							}
							return string.Format("CompleteUpgradesFormat".Localized(), LocalizedNumber(requiredUpgradeCount.targetCount));
						}
						return FormattedEntityWithType(EntityId.FromBiome(requiredBiome.biomeType));
					}
					return FormattedRewardEntityWithType(EntityId.FromQuest(requiredQuest.questType));
				}
				if (Item.MatchesFilterCache(requiredProductionCount.itemType, ItemType.FilterNaturalResource))
				{
					return LabelForCommand("HarvestQuestFormat", requiredProductionCount.targetCount, LabelForItem(requiredProductionCount.itemType));
				}
				return LabelForCommand("ProduceQuestFormat", requiredProductionCount.targetCount, LabelForItem(requiredProductionCount.itemType));
			}
			return FormattedKeyValue("ItemLabelUtilityPopulationSize", LocalizedNumber(requiredPopulationCount.targetCount));
		}
		return "RequiresFullGame".Localized();
	}

	public static string LabelForSkillCategory(SkillType t)
	{
		return t switch
		{
			SkillType.Crafting => Text("Crafting"), 
			SkillType.Cultivation => Text("Cultivation"), 
			SkillType.Harvesting => Text("Harvesting"), 
			SkillType.Prospecting => Text("Prospecting"), 
			_ => t.ToString(), 
		};
	}

	public static string LocalizationKeyForRewardEntity(EntityType t)
	{
		return t switch
		{
			EntityType.Building => "Building", 
			EntityType.Research => "Research", 
			EntityType.Upgrade => "Upgrade", 
			EntityType.Quest => "Quest", 
			EntityType.Recipe => "Recipe", 
			EntityType.MenuPanel => "Menu", 
			EntityType.NaturalResource => "NaturalResource", 
			EntityType.Farming => "Cultivation", 
			EntityType.Item => "Item", 
			EntityType.Mining => "Prospecting", 
			EntityType.HarvestRecipe => "Harvesting", 
			EntityType.Biome => "Biome", 
			EntityType.Perk => "Perks", 
			EntityType.BuildingCategory => "Menu", 
			_ => t.ToString(), 
		};
	}

	public static string LabelForEntityType(EntityType t)
	{
		return Text(LocalizationKeyForRewardEntity(t));
	}

	public static string LabelForEntity(EntityId entityId, bool tryPlural = false)
	{
		if (CachedEntityLabels.TryGetValue(entityId, out var value))
		{
			return value;
		}
		return entityId.type switch
		{
			EntityType.Building => LabelForBuilding(entityId.AsBuilding, tryPlural), 
			EntityType.Recipe => LabelForRecipeType(entityId.AsRecipe), 
			EntityType.Item => LabelForItem(entityId.AsItem, tryPlural), 
			EntityType.NaturalResource => LabelForNaturalResource(entityId.AsNaturalResource), 
			EntityType.Farming => LabelForNaturalResource(entityId.AsFarming), 
			EntityType.Mining => LabelForNaturalResource(entityId.AsMining), 
			EntityType.MenuPanel => Text(MenuManager.Instance.HeaderKeyForPanel(entityId.AsMenuPanel)), 
			EntityType.Quest => LabelForQuest(entityId.AsQuest), 
			EntityType.Upgrade => LabelForUpgrade(entityId.AsUpgrade), 
			EntityType.Research => LabelForResearch(entityId.AsResearch), 
			EntityType.FarmingTool => LabelForFarmingTool(entityId.AsFarmingTool), 
			EntityType.Biome => LabelForBiome(entityId.AsBiome), 
			EntityType.Perk => LabelForPerk(entityId.AsPerk), 
			EntityType.Specialty => LocalizationKeyForSpecialty(entityId.AsSpecialty).Localized(), 
			EntityType.HarvestRecipe => LabelForHarvestRecipe(entityId.AsHarvestRecipe), 
			EntityType.BuildingCategory => LabelforBuildingCategory(entityId.AsBuildingCategory), 
			_ => entityId.ToString(), 
		};
	}

	public static void PrependMultiplier(TextMeshProUGUI label)
	{
		sb.Clear();
		sb.Append(Multiplier);
		sb.Append(label.text);
		label.SetText(sb);
	}

	public static string Text(string key)
	{
		if (key == null)
		{
			return string.Empty;
		}
		bool flag = true;
		string text = LocalizationManager.LocalizedValueForKey(key);
		if (text == null)
		{
			if (flag)
			{
				return "*N/A*" + key;
			}
			text = LocalizationManager.EnglishValueForKey(key);
			if (text == null)
			{
				return key;
			}
			text = "*" + text + "*";
		}
		return text;
	}

	public static string LabelForHarvestRecipe(HarvestRecipeType r)
	{
		switch (r)
		{
		case HarvestRecipeType.FishingBoatNet:
			return LabelForItem(ItemType.FishingNet);
		case HarvestRecipeType.FishingBoatMagicNet:
			return LabelForItem(ItemType.MagicFishingNet);
		default:
		{
			if (Crafting.harvestRecipeCache.TryGetValue(r, out var value))
			{
				_ = value.producingBuildingType;
				_ = value.resourceType;
				return LabelForItem(value.harvestedItemType);
			}
			return "Harvest" + r;
		}
		}
	}

	public static string LabelForPerk(PerkType t)
	{
		switch (t)
		{
		case PerkType.ConstructionCost:
			return "ConstructionCost".Localized();
		case PerkType.ConstructionEfficiency:
			return "ConstructionEfficiency".Localized();
		case PerkType.UpgradeEfficiency:
			return "UpgradeEfficiency".Localized();
		case PerkType.MoreStartingLand:
			return "MoreStartingLand".Localized();
		case PerkType.LandCapacity:
			return "LandCapacity".Localized();
		case PerkType.ConstructionSpeed:
			return "ConstructionSpeed".Localized();
		case PerkType.CraftingSpeed:
			return "CraftingSpeed".Localized();
		case PerkType.KnowledgeSpeed:
			return "KnowledgeSpeed".Localized();
		case PerkType.TownTradingSpeed:
			return "TradingSpeed".Localized();
		case PerkType.GlobalTradingSpeed:
			return Strings.Def("Global Trading Speed", "TradingSpeed".Localized());
		case PerkType.CultivationSpeed:
			return "CultivationSpeed".Localized();
		case PerkType.GlobalXPBoost:
			return "TownExperienceProductivity".Localized();
		case PerkType.TownXPBoost:
			return "TownExperienceProductivity".Localized();
		case PerkType.DiceMinigame:
			return "MinigameDice".Localized();
		case PerkType.FarmingMinigame:
			return "MinigameFarming".Localized();
		case PerkType.GoodsConsumption:
			return "GoodsConsumption".Localized();
		case PerkType.HousingCapacity:
			return "HouseCapacity".Localized();
		case PerkType.MarketValue:
			return "SellValue".Localized();
		case PerkType.MiningMinigame:
			return "MinigameMining".Localized();
		case PerkType.ProspectingSpeed:
			return "ProspectingSpeed".Localized();
		case PerkType.ResearchEfficiency:
			return "ResearchEfficiency".Localized();
		case PerkType.ClickPower:
			return "ClickPower".Localized();
		case PerkType.IdleGain:
			return "IdleGain".Localized();
		case PerkType.ResearchMinigame:
			return "MinigameResearch".Localized();
		case PerkType.ResearchSpeed:
			return "ResearchSpeed".Localized();
		case PerkType.GlobalResearchSpeed:
			return Strings.Def("Global Research Speed", "ResearchSpeed".Localized());
		case PerkType.TownOmnistoneDemand:
			return string.Format(LocalizedTwoValueFormat(), LabelForItem(ItemType.Omnistone), "Demand".Localized());
		case PerkType.GourmetFoodsDemand:
		case PerkType.BooksDemand:
		case PerkType.ConstructionDemand:
		case PerkType.HardwareDemand:
		case PerkType.JewelryDemand:
		case PerkType.ClothingDemand:
		case PerkType.MedicineDemand:
		case PerkType.MagicDemand:
			return string.Format(LocalizedTwoValueFormat(), LabelForDemandPerkCategory(t), "Demand".Localized());
		case PerkType.GlobalMarketSpeed:
			return "MarketSellSpeed".Localized();
		case PerkType.GourmetFoodsStoreSpeed:
		case PerkType.BookStoreSpeed:
		case PerkType.ConstructionStoreSpeed:
		case PerkType.HardwareStoreSpeed:
		case PerkType.JewelryStoreSpeed:
		case PerkType.ClothingStoreSpeed:
		case PerkType.MedicineStoreSpeed:
		case PerkType.MagicStoreSpeed:
			return string.Format(LocalizedTwoValueFormat(), LabelForDemandPerkCategory(t), "SpeedBoost".Localized());
		case PerkType.WaterMinigame:
			return "MinigameWater".Localized();
		case PerkType.WoodMinigame:
			return "MinigameWood".Localized();
		case PerkType.HarvestingSpeed:
			return "HarvestingSpeed".Localized();
		case PerkType.NaturalResourceCapacity:
			return "NaturalResourceCapacity".Localized();
		case PerkType.ResourceRegen:
			return "ResourceRegen".Localized();
		case PerkType.SkillGainSpeed:
			return "SkillGainSpeed".Localized();
		case PerkType.MinigameXPGainSpeed:
			return "MinigameXPGainSpeed".Localized();
		default:
			return Text("Perk" + t);
		}
	}

	public static string BuildingModifier(BuildingType t, string modifierKey)
	{
		return LabelForBuilding(t) + " " + modifierKey.Localized();
	}

	public static string BuildingModifier(string localizedBuilding, string modifierKey)
	{
		return localizedBuilding + " " + modifierKey.Localized();
	}

	public static string LabelForStraight(int numDice)
	{
		return "Straight".Localized();
	}

	public static string LabelForDiceMatch(int face, int numDice)
	{
		if (face == 6 && numDice == 5)
		{
			return "Jackpot".Localized();
		}
		if (numDice == 2)
		{
			return "Pair".Localized();
		}
		return string.Format("NumOfAKind".Localized(), LocalizedNumber(numDice));
	}

	public static string LocalizationKeyForMenuPanel(MenuPanelType p)
	{
		return p switch
		{
			MenuPanelType.MinigameDice => "MinigameDice", 
			MenuPanelType.MinigameWood => "MinigameWood", 
			MenuPanelType.MinigameFarming => "MinigameFarming", 
			MenuPanelType.MinigameResearch => "MinigameResearch", 
			MenuPanelType.MinigameWater => "MinigameWater", 
			MenuPanelType.MinigameMining => "MinigameMining", 
			MenuPanelType.Clickables => "MenuPanelClicker", 
			MenuPanelType.Cultivation => "Cultivation", 
			MenuPanelType.Research => "Research", 
			MenuPanelType.Prospecting => "Prospecting", 
			MenuPanelType.Buildings => "Construction", 
			MenuPanelType.CombinedProduction => "Crafting", 
			MenuPanelType.Markets => "Markets", 
			MenuPanelType.Trading => "Trading", 
			MenuPanelType.All => "Default", 
			MenuPanelType.Perks => "Perks", 
			MenuPanelType.TownPerks => "TownPerks", 
			MenuPanelType.World => "World", 
			MenuPanelType.Upgrades => "Upgrades", 
			MenuPanelType.Quests => "Quests", 
			MenuPanelType.QuestsPopup => "Quests", 
			MenuPanelType.InventoryPopup => "Inventory", 
			MenuPanelType.TimeTokens => "TimeManagement", 
			MenuPanelType.Inventory => "Inventory", 
			MenuPanelType.Log => "Notifications", 
			MenuPanelType.GameMenu => "Menu", 
			MenuPanelType.FileList => "Files", 
			_ => Text("MenuPanel" + p), 
		};
	}

	public static string LabelForMenuPanel(MenuPanelType p)
	{
		return Text(LocalizationKeyForMenuPanel(p));
	}

	public static string FormattedEntityWithType(EntityId id)
	{
		return FormattedKeyValue(LocalizationKeyForRewardEntity(id.type), LabelForEntity(id));
	}

	public static string FormattedRewardEntityWithType(EntityId id)
	{
		if (id.TryAsPerk(out var i))
		{
			if (Perk.IsGlobal(i))
			{
				return "(" + "Perks".Localized() + ") " + LabelForEntity(id);
			}
			return "(" + "TownPerks".Localized() + ") " + LabelForEntity(id);
		}
		return "(" + LocalizationKeyForRewardEntity(id.type).Localized() + ") " + LabelForEntity(id);
	}

	public static string FormattedRewardEntityWithType(EntityId id, int level)
	{
		if (id.TryAsItem(out var i) && Item.IsUtility(i))
		{
			return LabelForEntity(id);
		}
		sb.Clear();
		sb.Append('(');
		sb.Append(LocalizationKeyForRewardEntity(id.type).Localized());
		sb.Append(')');
		sb.Append(' ');
		sb.Append(LabelForEntity(id));
		sb.Append(' ');
		sb.AppendFormat(LevelFormatShort, LocalizedNumber(level));
		return sb.ToString();
	}

	public static string TextForInvalidReason(InvalidReason t)
	{
		if (LocalizationManager.IsEnglish())
		{
			switch (t)
			{
			case InvalidReason.NotEnoughLand:
				return "Not enough land to create another building.\nLevel up your town, or equip Perks\nthat increase Land Capacity";
			case InvalidReason.NotEnoughWorkers:
				if (GameManager.Instance.activeTown.townLevel >= 1)
				{
					return "Not enough Workers - build more Houses,\nor equip Perks that increase Workers per House";
				}
				return "Not enough Workers - build more Houses";
			}
		}
		return Text("InvalidReason" + t);
	}

	public static string LabelForEvaluation(MinigameEvaluation t)
	{
		return Text("Evaluation" + t);
	}

	public static string LabelForUserLanguage(UserLanguage t)
	{
		return Text("UserLanguage" + t);
	}

	public static string LabelForPreferenceOption(string key, string optionString)
	{
		switch (key)
		{
		case "PrefInterfaceKeyScaling":
			if (optionString == "PrefInterfaceOptionScalingAuto")
			{
				return Text(optionString);
			}
			return Percent(Preferences.ScalingForVideoOption(optionString));
		case "PrefVideoKeyResolution":
			return optionString;
		case "PrefInterfaceKeyLanguage":
			return LabelForUserLanguage(LocalizationManager.LanguageForCode(optionString));
		case "PrefInterfaceKeyAutosave":
			if (optionString == "Off")
			{
				return Text(optionString);
			}
			return Minutes(Preferences.IntervalForAutosaveOption(optionString));
		default:
			return Text(optionString);
		}
	}

	public static string Minutes(int minutes)
	{
		return string.Format(((minutes == 1) ? "FormattedMinute" : "FormattedMinutes").Localized(), LocalizedNumber(minutes));
	}

	public static bool HasLocalization(string testKey)
	{
		return LocalizationManager.HasLocalizedValueForKey(testKey);
	}

	public static void FormatDecreaseLabel(TextMeshProUGUI label, int count, bool hideIfDefault)
	{
		if (count == 1)
		{
			if (hideIfDefault)
			{
				label.enabled = false;
				return;
			}
			label.text = "-";
			label.fontStyle = FontStyles.Bold;
			label.fontSize = 30f;
			label.rectTransform.SetPosY(2f);
		}
		else
		{
			label.enabled = true;
			label.text = "-" + LocalizedNumber(count);
			label.fontStyle = FontStyles.Normal;
			label.fontSize = 20f;
			label.rectTransform.SetPosY(0f);
		}
	}

	public static void FormatIncreaseLabel(TextMeshProUGUI label, int count, bool hideIfDefault)
	{
		if (count == 1)
		{
			if (hideIfDefault)
			{
				label.enabled = false;
				return;
			}
			label.text = "+";
			label.fontStyle = FontStyles.Bold;
			label.fontSize = 30f;
			label.rectTransform.SetPosY(1f);
		}
		else
		{
			label.enabled = true;
			label.text = "+" + LocalizedNumber(count);
			label.fontStyle = FontStyles.Normal;
			label.fontSize = 20f;
			label.rectTransform.SetPosY(0f);
		}
	}

	public static void AppendIfSpaced(StringBuilder stringBuilder)
	{
		if (LocalizationManager.IsCurrentLanguageSpaced())
		{
			stringBuilder.Append(' ');
		}
	}

	public static string FormattedTimeTokenValue()
	{
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append(LocalizedNumber(1));
		AppendIfSpaced(pooledStringBuilder);
		pooledStringBuilder.Append(LabelForItem(ItemType.TimeToken));
		AppendIfSpaced(pooledStringBuilder);
		pooledStringBuilder.Append('=');
		AppendIfSpaced(pooledStringBuilder);
		pooledStringBuilder.Append(LocalizedNumber(60f));
		pooledStringBuilder.Append("TimeSecondsAbbreviation".Localized());
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	public static string LabelForTimeMode(int mode, float simStepMultiplier)
	{
		if (mode < 0)
		{
			return "Paused".Localized();
		}
		int targetSpeedMultiplier = TimeManager.targetSpeedMultiplier;
		switch (mode)
		{
		case 1:
			return FormattedKeyValue("TurboMode", LocalizedNumber(targetSpeedMultiplier) + "x");
		case 2:
		{
			string arg = string.Format(LocalizedTwoValueFormat(), "TurboMode".Localized(), "Max".Localized());
			string arg2 = LocalizedNumber(targetSpeedMultiplier) + "x";
			return string.Format(LocalizedKeyValueFormat(), arg, arg2);
		}
		default:
			return FormattedKeyValue("BaselineSpeed", LocalizedNumber(targetSpeedMultiplier) + "x");
		}
	}

	public static string LabelForInput(KeyCode keyCode)
	{
		switch (keyCode)
		{
		case KeyCode.Alpha0:
			return "0";
		case KeyCode.Alpha1:
			return "1";
		case KeyCode.Alpha2:
			return "2";
		case KeyCode.Alpha3:
			return "3";
		case KeyCode.Alpha4:
			return "4";
		case KeyCode.Alpha5:
			return "5";
		case KeyCode.Alpha6:
			return "6";
		case KeyCode.Alpha7:
			return "7";
		case KeyCode.Alpha8:
			return "8";
		case KeyCode.Alpha9:
			return "9";
		case KeyCode.LeftArrow:
			return "←";
		case KeyCode.RightArrow:
			return "→";
		case KeyCode.UpArrow:
			return "↑";
		case KeyCode.DownArrow:
			return "↓";
		case KeyCode.LeftShift:
			return "InputBindingShift".Localized();
		default:
		{
			string text = "InputBinding" + keyCode;
			if (LocalizationManager.HasLocalizedValueForKey(text))
			{
				return text.Localized();
			}
			return keyCode.ToString();
		}
		}
	}

	public static string FulfillmentTooltipForTown(Town displayedTown)
	{
		if (displayedTown == null)
		{
			return null;
		}
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append(FormattedKeyValue("AverageFulfillment", Percent(displayedTown.happinessAverage)));
		pooledStringBuilder.Append(NewLine);
		pooledStringBuilder.Append(FormattedKeyValue("FulfillmentScore", LocalizedNumber(displayedTown.fulfillmentScore)));
		pooledStringBuilder.Append(NewLine);
		string localizedValue = SignedPercent((float)Mathf.FloorToInt(displayedTown.happinessMultiplier * 100f) * 0.01f - 1f);
		pooledStringBuilder.Append(FormattedKeyValue("TownXPMultiplier", localizedValue));
		if (LocalizationManager.IsEnglish())
		{
			pooledStringBuilder.Append("\n(Raise Fulfillment by selling items at the Market)");
		}
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	public static void AppendModifiers(StringBuilder stringBuilder, List<ProductionModifier> modifiers, string optionalHeaderText = null)
	{
		if (modifiers == null)
		{
			return;
		}
		bool flag = optionalHeaderText == null;
		foreach (ProductionModifier modifier in modifiers)
		{
			if (!GameUtility.NearlyEquals(1f, modifier.multiplier))
			{
				if (!flag)
				{
					stringBuilder.Append(NewLine);
					stringBuilder.Append("-----");
					stringBuilder.Append(NewLine);
					stringBuilder.Append("<b>");
					stringBuilder.Append("Modifiers".Localized());
					stringBuilder.Append(':');
					stringBuilder.Append(' ');
					stringBuilder.Append(optionalHeaderText);
					stringBuilder.Append("</b>");
					flag = true;
				}
				stringBuilder.Append(NewLine);
				stringBuilder.AppendFormat(KeyValueFormatSpaced, modifier.DisplayLabel(), LabelForMultiplier(modifier.multiplier));
			}
		}
	}

	public static string RateHighlightText(StateManager state)
	{
		StringBuilder stringBuilder = highlightTextBuilder;
		stringBuilder.Clear();
		bool flag = state is ResearchState || state is ConstructionState;
		if (flag)
		{
			if (state.baseProductionRate > 0f)
			{
				stringBuilder.AppendFormat(KeyValueFormatSpaced, "BaselineDuration".Localized(), FormattedHoursMinutesSeconds(1f / state.baseProductionRate));
			}
		}
		else
		{
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "BaselineSpeed".Localized(), GetRate(state.baseProductionRate));
		}
		if (state.primaryOutput != null && GameUtility.NotEquals(state.primaryOutput.totalAmount, 1.0))
		{
			stringBuilder.Append(NewLine);
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "Productivity".Localized(), LocalizedNumber(state.primaryOutput.totalAmount));
		}
		bool flag2 = state.numWorkersAssigned > 0f;
		stringBuilder.Append(NewLine);
		if (!flag2)
		{
			stringBuilder.Append("<color=#FF0000>");
		}
		stringBuilder.AppendFormat(arg0: ((state.IsWorkerAssignment() || !LocalizationManager.HasLocalizedValueForKey("AssignedProductionCapacity")) ? "Workers" : "AssignedProductionCapacity").Localized(), format: KeyValueFormatSpaced, arg1: LabelForMultiplier(state.numWorkersAssigned));
		if (!flag2)
		{
			stringBuilder.Append("</color>");
		}
		AppendModifiers(stringBuilder, state.productionSpeedModifiers, "SpeedBoost".Localized());
		AppendModifiers(stringBuilder, state.productionAmountModifiers, "Productivity".Localized());
		AppendModifiers(stringBuilder, state.xpModifiers, "ExperiencePoints".Localized());
		if (LocalizationManager.IsEnglish())
		{
			AppendModifiers(stringBuilder, state.inputAmountModifiers, "Input Efficiency");
		}
		if (state.activePauseState)
		{
			stringBuilder.Append(NewLine);
			stringBuilder.Append("-----");
			stringBuilder.Append(NewLine);
			stringBuilder.Append("<color=#FF0000>");
			stringBuilder.Append("Paused".Localized());
			stringBuilder.Append("</color>");
			return stringBuilder.ToString();
		}
		stringBuilder.Append(NewLine);
		stringBuilder.Append("-----");
		if (flag)
		{
			if (state.displayedPotentialRateForPrimaryOutput > 0f)
			{
				stringBuilder.Append(NewLine);
				stringBuilder.AppendFormat(KeyValueFormatSpaced, "PotentialDuration".Localized(), FormattedHoursMinutesSeconds(1f / state.displayedPotentialRateForPrimaryOutput));
			}
		}
		else
		{
			stringBuilder.Append(NewLine);
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "Potential".Localized(), PerSecondRate(state.displayedPotentialRateForPrimaryOutput));
		}
		if (state.onlyConsumesSurplus)
		{
			bool num = state.appliedMaxRate <= state.surplusMaxRate;
			if (num)
			{
				stringBuilder.Append("<color=#26A6A6>");
			}
			if (state is TradingState tradingState)
			{
				stringBuilder.Append(NewLine);
				stringBuilder.AppendFormat(KeyValueFormatSpaced, "TradeMode".Localized(), LabelForTradeMode(tradingState.appliedTradeMode));
			}
			stringBuilder.Append(NewLine);
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "OnlyUseSurplus".Localized(), PerSecondRate(state.surplusMaxRate));
			if (num)
			{
				stringBuilder.Append("</color>");
			}
		}
		if (state.rateCapacityState != AffordabilityState.CanFullyProduce && state.rateCapacityRatio > 0.0)
		{
			stringBuilder.Append("<color=#26A6A6>");
			stringBuilder.Append(NewLine);
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "MaxRate".Localized(), PerSecondRate(state.appliedMaxRate));
			stringBuilder.Append("</color>");
		}
		if (flag2)
		{
			stringBuilder.Append(NewLine);
			if (state.inputAffordabilityState == AffordabilityState.CanNotProduce)
			{
				stringBuilder.Append("<color=#FF0000>");
			}
			else if (state.inputAffordabilityState == AffordabilityState.CanPartiallyProduce)
			{
				stringBuilder.Append("<color=#FFFF00>");
			}
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "InputAvailability".Localized(), Percent(GameUtility.AsTruncatedFloat(state.inputSupplyRatio)));
			if (state.inputAffordabilityState != AffordabilityState.CanFullyProduce)
			{
				stringBuilder.Append("</color>");
			}
			stringBuilder.Append(NewLine);
			if (state.outputCapacityState == AffordabilityState.CanNotProduce)
			{
				stringBuilder.Append("<color=#40B2E6>");
			}
			else if (state.outputCapacityState == AffordabilityState.CanPartiallyProduce)
			{
				stringBuilder.Append("<color=#59D9D9>");
			}
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "OutputAvailability".Localized(), Percent(Mathf.Clamp01(GameUtility.AsTruncatedFloat(state.outputCapacityRatio))));
			if (state.outputCapacityState != AffordabilityState.CanFullyProduce)
			{
				stringBuilder.Append("</color>");
			}
		}
		if (flag)
		{
			stringBuilder.Append(NewLine);
			if (state.displayedRecipeUnitRate > 0f)
			{
				stringBuilder.AppendFormat(KeyValueFormatSpaced, "ActualDuration".Localized(), FormattedHoursMinutesSeconds(1f / state.displayedRecipeUnitRate));
				if (LocalizationManager.HasLocalizedValueForKey("TimeRemaining") && state.displayedRecipeUnitRate > 1E-06f)
				{
					stringBuilder.Append(NewLine);
					float f = 1f / state.displayedRecipeUnitRate * (1f - GameUtility.AsFloat(state.unitProgress));
					f = Mathf.Ceil(f);
					stringBuilder.AppendFormat(KeyValueFormatSpaced, "TimeRemaining".Localized(), FormattedHoursMinutesSeconds(GameUtility.AsFloat(f)));
				}
			}
			else
			{
				stringBuilder.AppendFormat(KeyValueFormatSpaced, "ActualProductionSpeed".Localized(), "-");
			}
		}
		else
		{
			stringBuilder.Append(NewLine);
			stringBuilder.AppendFormat(KeyValueFormatSpaced, "ActualProductionSpeed".Localized(), PerSecondRate(state.displayedOutputRate));
		}
		return stringBuilder.ToString();
	}

	public static string LabelForGameModifier(GameModifier modifier)
	{
		return Text("GameModifier" + modifier);
	}

	public static string DescriptionForGameModifier(GameModifier modifier)
	{
		return Text("GameModifierDesc" + modifier);
	}

	public static string ProductionHighlightText(bool useWorkers)
	{
		sb.Clear();
		if (useWorkers)
		{
			sb.Append("Workers".Localized());
		}
		else
		{
			sb.Append("ProductionCapacity".Localized());
		}
		sb.Append(NewLine);
		sb.Append('(');
		sb.Append("Available".Localized());
		sb.Append(' ');
		sb.Append('/');
		sb.Append(' ');
		sb.Append("Max".Localized());
		sb.Append(')');
		return sb.ToString();
	}
}
