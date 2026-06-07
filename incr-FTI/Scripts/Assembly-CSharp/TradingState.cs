using System.Diagnostics;
using UnityEngine;

public class TradingState : StateManager
{
	public ItemType itemType;

	public ItemState globalWarehouseState;

	public ItemState localItemState;

	public TradeMode appliedTradeMode;

	public TradeMode activeTradeMode;

	public Specialty cachedTradingSpecialty;

	public const int MetadataTriggerNever = 0;

	public const int MetadataTriggerIfChanged = 1;

	public const int MetadataTriggerAlways = 2;

	public int autoTradeCooldown;

	private const double FullnessThresholdHigh = 0.999;

	private const double FullnessThresholdLow = 0.98;

	public bool isUseSurplusStale;

	public TradeMode localTradeMode => localSettings.tradingConfig.value;

	public TradingState()
	{
		Initialize();
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromItem(itemType);
	}

	public override EntityId SkillEntity()
	{
		return EntityId.FromItem(itemType);
	}

	public override void LoadModifiers()
	{
		if (base.producingBuilding != null)
		{
			if (base.producingBuilding.type == BuildingType.TradingPost)
			{
				AddInputAmountModifier(new ProductionModifierBuildingCount(parentTown, BuildingType.Packager));
				AddOutputAmountModifier(new ProductionModifierBuildingCount(parentTown, BuildingType.Packager));
				AddModifier(BuildingType.SteamTrain);
				AddModifier(BuildingType.Caravan);
				AddModifier(BuildingType.RiverHarbor);
			}
			else if (base.producingBuilding.type == BuildingType.PowerLine)
			{
				AddModifier(UpgradeType.PowerLineSpeed);
			}
			else if (base.producingBuilding.type == BuildingType.ManaPipeline)
			{
				AddModifier(UpgradeType.ManaPipeSpeed);
			}
			else if (base.producingBuilding.type == BuildingType.SteamPipeline)
			{
				AddModifier(UpgradeType.SteamPipeSpeed);
			}
			else if (base.producingBuilding.type == BuildingType.MagmaPipeline)
			{
				AddModifier(UpgradeType.MagmaPipeSpeed);
			}
			else if (base.producingBuilding.type == BuildingType.OmniPipeline)
			{
				AddModifier(UpgradeType.OmniPipeSpeed);
			}
		}
		AddModifier(PerkType.TownTradingSpeed);
		AddModifier(PerkType.GlobalTradingSpeed);
	}

	public override void StoreItemStateCache()
	{
		_ = parentTown.debug;
		base.StoreItemStateCache();
		globalWarehouseState = GameManager.Instance.globalInventory[itemType];
		localItemState = parentTown.inventory[itemType];
		float num = 1f;
		float num2 = 0f;
		if (Crafting.cachedItemDefs.TryGetValue(itemType, out var value) && value.tradeBuilding != BuildingType.None && parentTown.buildings.TryGetValue(value.tradeBuilding, out var value2))
		{
			SetProductionBuilding(value2);
			if (value.tradeBuilding == BuildingType.PowerLine)
			{
				num = 10f;
				num2 = 0.1f;
			}
			else if (value.tradeBuilding == BuildingType.SteamPipeline)
			{
				num = 5f;
				num2 = 1f;
			}
			else if (value.tradeBuilding == BuildingType.MagmaPipeline)
			{
				num = 5f;
				num2 = 1f;
			}
			else if (value.tradeBuilding == BuildingType.OmniPipeline)
			{
				num = 5f;
				num2 = 1f;
			}
			else if (value.tradeBuilding == BuildingType.ManaPipeline)
			{
				if (value.specialty == Specialty.Energy)
				{
					num = 10f;
					num2 = 0.1f;
				}
				else
				{
					num = 1f;
					num2 = 1f;
				}
			}
			else
			{
				num = 1f;
				float level = 1f;
				if (Crafting.houseSellData.TryGetValue(itemType, out var value3))
				{
					level = value3.GetExchangeValue();
				}
				num2 = GameUtility.Poly(level, 1.95f, 0.05f, 0.0002f);
			}
		}
		if (num2 > 0f)
		{
			baseProductionRate = 1f / num2;
		}
		else
		{
			baseProductionRate = 0.5f;
		}
		baseProductionRate = Mathf.Round(baseProductionRate * 20f);
		baseProductionRate *= 0.05f;
		if (baseProductionRate < 0.05f)
		{
			baseProductionRate = 0.05f;
		}
		float num3 = Crafting.DerivedItemXP(localItemState.type);
		if (activeTradeMode == TradeMode.Export)
		{
			ItemRateData i = new ItemRateData(localItemState, num, baseProductionRate, this);
			AddInput(i);
			if (GameManager.Instance.globalInventory.TryGetValue(itemType, out var value4))
			{
				primaryOutput = new ItemRateData(value4, num, baseProductionRate, this);
				AddOutput(primaryOutput);
			}
			if (GameManager.Instance.isUsingExchangeTokens)
			{
				ItemRateData o = new ItemRateData(parentTown.inventory[ItemType.ExchangeToken], num * num3, baseProductionRate, this);
				AddOutput(o);
			}
		}
		else if (activeTradeMode == TradeMode.Import)
		{
			if (GameManager.Instance.globalInventory.TryGetValue(itemType, out var value5))
			{
				AddInput(value5, num, baseProductionRate);
			}
			if (GameManager.Instance.isUsingExchangeTokens)
			{
				ItemRateData i2 = new ItemRateData(parentTown.inventory[ItemType.ExchangeToken], num * num3, baseProductionRate, this);
				AddInput(i2);
			}
			primaryOutput = new ItemRateData(localItemState, num, baseProductionRate, this);
			AddOutput(primaryOutput);
		}
		else
		{
			primaryOutput = null;
		}
	}

	protected override bool ShouldBeAvailable()
	{
		return true;
	}

	public override string ToString()
	{
		return "[Trade " + itemType.ToString() + " " + activeTradeMode.ToString() + " " + parentTown.biomeType.ToString() + "]";
	}

	public bool IsAutoTradeLocal()
	{
		return true;
	}

	public bool CalcActiveTradeMode()
	{
		autoTradeCooldown = 5;
		TradeMode tradeMode = TradeMode.None;
		if (appliedTradeMode == TradeMode.Import || appliedTradeMode == TradeMode.Export || appliedTradeMode == TradeMode.Off)
		{
			tradeMode = appliedTradeMode;
		}
		else
		{
			_ = debugAutoTrade;
			double num = 0.0;
			if (appliedTradeMode == TradeMode.AutoTradeLocalBalance)
			{
				double num2 = localItemState.frameLocalConsumed * num;
				if (localItemState.lastFrameSurplus < 0.0 - num2)
				{
					tradeMode = TradeMode.Import;
				}
				else if (localItemState.lastFrameSurplus > num2)
				{
					tradeMode = TradeMode.Export;
				}
				else
				{
					tradeMode = TradeMode.Off;
					if (debugAutoTrade && tradeMode == activeTradeMode)
					{
					}
				}
			}
			else if (appliedTradeMode == TradeMode.AutoTradeGlobalBalance)
			{
				double num3 = globalWarehouseState.frameLocalConsumed * num;
				double lastFrameSurplus = globalWarehouseState.lastFrameSurplus;
				tradeMode = ((lastFrameSurplus < 0.0 - num3) ? TradeMode.Export : ((lastFrameSurplus > num3) ? TradeMode.Import : TradeMode.Off));
			}
			else if (appliedTradeMode == TradeMode.AutoTradeLocalFill)
			{
				double num4;
				double num5;
				switch (activeTradeMode)
				{
				case TradeMode.Import:
					num4 = 0.999;
					num5 = 0.999;
					break;
				case TradeMode.Export:
					num4 = 0.98;
					num5 = 0.999;
					break;
				default:
					num4 = 0.98;
					num5 = 0.98;
					break;
				}
				if (localItemState.lastFrameSurplus - localItemState.frameImported < 0.0)
				{
					tradeMode = TradeMode.Import;
				}
				else if (localItemState.currentCount <= localItemState.maxCount * num4)
				{
					tradeMode = TradeMode.Import;
				}
				else if (localItemState.lastFrameSurplus <= 0.0)
				{
					tradeMode = TradeMode.Off;
				}
				else if (globalWarehouseState.currentCount <= globalWarehouseState.maxCount * num5)
				{
					tradeMode = TradeMode.Export;
				}
				else
				{
					double num6 = 0.0;
					if (activeTradeMode == TradeMode.Export && primaryOutput != null)
					{
						num6 = potentialWorkUnits * primaryOutput.deltaPerWorkUnit;
					}
					tradeMode = ((!(globalWarehouseState.lastFrameSurplus - num6 < 0.1)) ? TradeMode.Off : TradeMode.Export);
				}
			}
			else if (appliedTradeMode == TradeMode.AutoTradeGlobalFill)
			{
				double num7;
				double num8;
				switch (activeTradeMode)
				{
				case TradeMode.Export:
					num7 = 0.999;
					num8 = 0.999;
					break;
				case TradeMode.Import:
					num7 = 0.98;
					num8 = 0.999;
					break;
				default:
					num7 = 0.98;
					num8 = 0.98;
					break;
				}
				double num9 = 0.0;
				if (activeTradeMode == TradeMode.Export && primaryOutput != null)
				{
					num9 = potentialWorkUnits * primaryOutput.deltaPerWorkUnit;
				}
				_ = debugAutoTrade;
				tradeMode = ((globalWarehouseState.lastFrameSurplus - num9 < 0.1) ? TradeMode.Export : ((globalWarehouseState.currentCount <= globalWarehouseState.maxCount * num7) ? TradeMode.Export : ((globalWarehouseState.lastFrameSurplus <= 0.0) ? TradeMode.Off : ((localItemState.currentCount <= localItemState.maxCount * num8) ? TradeMode.Import : TradeMode.Off))));
			}
		}
		if (activeTradeMode != tradeMode)
		{
			activeTradeMode = tradeMode;
			isUseSurplusStale = true;
			_ = debugAutoTrade;
			return true;
		}
		return false;
	}

	public void CalcUseSurplusFlag()
	{
		isUseSurplusStale = false;
		switch (appliedTradeMode)
		{
		case TradeMode.AutoTradeGlobalBalance:
		case TradeMode.AutoTradeGlobalFill:
			onlyConsumesSurplus = activeTradeMode == TradeMode.Import;
			break;
		case TradeMode.AutoTradeLocalBalance:
		case TradeMode.AutoTradeLocalFill:
			onlyConsumesSurplus = activeTradeMode == TradeMode.Export;
			break;
		default:
			onlyConsumesSurplus = false;
			break;
		}
	}

	[Conditional("UNITY_EDITOR")]
	private void TradeDebug(TradeMode nextTradeMode, string reason)
	{
		if (debugAutoTrade)
		{
			_ = activeTradeMode;
		}
	}

	private bool CanExport()
	{
		return true;
	}

	private bool CanImport()
	{
		return true;
	}

	public bool CalcAppliedTradeMode()
	{
		TradeMode num = appliedTradeMode;
		appliedTradeMode = localSettings.DerivedTradeMode();
		if (appliedTradeMode == TradeMode.None)
		{
			appliedTradeMode = TradeMode.Off;
		}
		if (num != appliedTradeMode)
		{
			isUseSurplusStale = true;
			return true;
		}
		return false;
	}
}
