using System.Text;
using UnityEngine.UI;

public class FulfillmentProgressBar : MenuButton
{
	public ProgressBar fulfillmentProgress;

	public Image fulfillmentImage;

	public SellState displayedSellState;

	protected override void Awake()
	{
		base.Awake();
		fulfillmentImage.color = ColorManager.fulfillment;
	}

	public override string HighlightText()
	{
		StringBuilder highlightTextBuilder = TextDisplay.highlightTextBuilder;
		highlightTextBuilder.Clear();
		if (displayedSellState != null)
		{
			highlightTextBuilder.Append(Strings.Def(TextDisplay.LabelForItem(displayedSellState.itemType) + " Demand", "Fulfillment".Localized()));
			highlightTextBuilder.Append(TextDisplay.NewLine);
			highlightTextBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), "Baseline".Localized(), TextDisplay.PerSecondRate(displayedSellState.sellData.baselineDemand));
			double num = (double)displayedSellState.sellData.demandPerHouse * displayedSellState.parentTown.numHouses;
			if (num > 0.0)
			{
				highlightTextBuilder.Append(TextDisplay.NewLine);
				highlightTextBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(BuildingType.House, plural: true), TextDisplay.LocalizedNumber(displayedSellState.parentTown.cachedHouseState.currentCount));
				highlightTextBuilder.Append(" (" + TextDisplay.PerSecondRate(num) + ")");
			}
			float value = displayedSellState.sellData.townLevelScaling * (float)displayedSellState.parentTown.townLevel;
			if (GameUtility.IsNotZero(value))
			{
				highlightTextBuilder.Append(TextDisplay.NewLine);
				highlightTextBuilder.Append(TextDisplay.FormattedKeyValue("TownLevel", TextDisplay.LocalizedNumber(displayedSellState.parentTown.townLevel)));
				highlightTextBuilder.Append(" (" + TextDisplay.SignedPercent(value) + ")");
			}
			if (GameUtility.NotEquals(displayedSellState.biomeModifierDemand, 1f))
			{
				highlightTextBuilder.Append(TextDisplay.NewLine);
				highlightTextBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBiome(displayedSellState.parentTown.biomeType), " (+" + TextDisplay.Percent(displayedSellState.biomeModifierDemand - 1f) + ")");
			}
			if (displayedSellState.cachedDemandPerk != null && displayedSellState.cachedDemandPerk.currentCount > 0.0)
			{
				highlightTextBuilder.Append(TextDisplay.NewLine);
				highlightTextBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForPerk(displayedSellState.cachedDemandPerk.type), "x" + displayedSellState.parentTown.MultiplierForPerk(displayedSellState.cachedDemandPerk.type));
			}
			if (displayedSellState.itemType == ItemType.Omnistone && displayedSellState.parentTown.townPerks.TryGetValue(PerkType.TownOmnistoneDemand, out var value2) && value2.currentCount > 0.0)
			{
				highlightTextBuilder.Append(TextDisplay.NewLine);
				highlightTextBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForPerk(value2.type), "x" + displayedSellState.parentTown.MultiplierForPerk(value2.type));
			}
			highlightTextBuilder.Append(TextDisplay.NewLine);
			string format = TextDisplay.CurrentLanguageKeyValueFormat();
			highlightTextBuilder.AppendFormat(format, "TotalDemand".Localized(), TextDisplay.PerSecondRate(displayedSellState.happinessRate));
			highlightTextBuilder.Append(TextDisplay.NewLine);
			highlightTextBuilder.Append("---");
			highlightTextBuilder.Append(TextDisplay.NewLine);
			if (GameManager.Instance.isConsumptionInfinite)
			{
				highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "MaxSupply".Localized(), TextDisplay.LabelForGameModifier(GameModifier.InfiniteConsumption));
			}
			else
			{
				highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "Oversupply".Localized() + " (" + "Baseline".Localized() + ")", " x1");
				float num2 = displayedSellState.parentTown.MultiplierForResearch(ResearchType.InfiniteGoodsConsumption);
				if (num2 > 1f)
				{
					highlightTextBuilder.Append(TextDisplay.NewLine);
					string arg = TextDisplay.FormattedRewardEntityWithType(EntityId.FromResearch(ResearchType.InfiniteGoodsConsumption));
					highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, arg, " x" + TextDisplay.LocalizedNumber(num2));
				}
				float num3 = GameManager.Instance.MultiplierForGlobalPerk(PerkType.GoodsConsumption);
				if (num3 > 1f)
				{
					highlightTextBuilder.Append(TextDisplay.NewLine);
					string arg2 = TextDisplay.FormattedRewardEntityWithType(EntityId.FromPerk(PerkType.GoodsConsumption));
					highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, arg2, " x" + TextDisplay.LocalizedNumber(num3));
				}
				float num4 = displayedSellState.parentTown.DemandBonusForBuilding(displayedSellState.sellData.derivedSellBuilding);
				if (num4 > 1f)
				{
					highlightTextBuilder.Append(TextDisplay.NewLine);
					string arg3 = TextDisplay.FormattedRewardEntityWithType(EntityId.FromUpgrade(displayedSellState.parentTown.DemandUpgradeForBuilding(displayedSellState.sellData.derivedSellBuilding)));
					highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, arg3, " x" + TextDisplay.LocalizedNumber(num4));
				}
				float num5 = 1f;
				if (displayedSellState.isSpecialty)
				{
					highlightTextBuilder.Append(TextDisplay.NewLine);
					num5 = GameManager.Instance.SpecializationDemandBonusPerPerkLevel();
					highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "Specialty".Localized(), " x" + TextDisplay.LocalizedNumber(num5));
				}
				if (LocalizationManager.IsEnglish() && displayedSellState.recipeMaxRate > displayedSellState.happinessRate)
				{
					highlightTextBuilder.Append(TextDisplay.NewLine);
					highlightTextBuilder.AppendFormat(format, "Oversupply".Localized(), TextDisplay.PerSecondRate(displayedSellState.recipeMaxRate - displayedSellState.happinessRate));
				}
				highlightTextBuilder.Append(TextDisplay.NewLine);
				highlightTextBuilder.AppendFormat(format, Strings.Def("Total Max Supply (Demand + Oversupply)", "TotalMaxSupply".Localized()), TextDisplay.PerSecondRate(displayedSellState.recipeMaxRate));
			}
			highlightTextBuilder.Append(TextDisplay.NewLine);
			highlightTextBuilder.Append("---");
			highlightTextBuilder.Append(TextDisplay.NewLine);
			highlightTextBuilder.Append(TextDisplay.FormattedKeyValue("Supplied", TextDisplay.PerSecondRate(displayedSellState.satisfactionSupplyRate)));
			highlightTextBuilder.Append(' ');
			highlightTextBuilder.Append('(');
			highlightTextBuilder.Append(TextDisplay.Percent(displayedSellState.fulfillmentRatio));
			highlightTextBuilder.Append(')');
			highlightTextBuilder.Append(TextDisplay.NewLine);
			highlightTextBuilder.Append(TextDisplay.FormattedKeyValue("FulfillmentScore", TextDisplay.LocalizedNumber(displayedSellState.fulfillmentScore)));
		}
		return highlightTextBuilder.ToString();
	}
}
