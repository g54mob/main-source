using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ExtortionEntryLayoutItemView : TradingBaseLayoutItemView
	{
		private static string valueSprite;

		[SerializeField]
		private BasicLayoutItemView playerAmount;

		[SerializeField]
		private BasicLayoutItemView playerPrice;

		[SerializeField]
		private TradingInputLayoutItemView tradingInput;

		[SerializeField]
		private Image background;

		[SerializeField]
		private Color entryChangedColor;

		[SerializeField]
		private Color entryDisabledColor;

		[SerializeField]
		private Color entryGrayColor = Color.gray;

		[SerializeField]
		private Color entryOriginalColor = Color.clear;

		[SerializeField]
		private GameObject priceGroup;

		[SerializeField]
		private TMP_Text noTradeText;

		private bool canTrade = true;

		private SafeTMP_InputField inputField;

		private TradeResource playerResource;

		private int tradeValue;

		private float playerPriceValue;

		public static string ValueSprite
		{
			get
			{
				string result = valueSprite ?? AssetUtils.GetSpriteAsset("value");
				valueSprite = result;
				return result;
			}
		}

		public TradingInputLayoutItemView TradingInput => tradingInput;

		public bool CanTrade => canTrade;

		public TradeResource PlayerResource => playerResource;

		public float PlayerPriceValue => playerPriceValue;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			valueSprite = null;
		}

		public void InitWithCreature(ExtortionPanelView parentView, TradeResource playerResource, bool canTrade)
		{
			this.playerResource = playerResource;
			this.canTrade = canTrade;
			tradingInput.SetInteractable(canTrade);
			priceGroup.SetActive(canTrade);
			noTradeText.gameObject.SetActive(!canTrade);
			if (!canTrade)
			{
				TradeForbiddenReason tradeForbiddenReason = TradeForbiddenReason.None;
				if (playerResource != null && playerResource.IsForbidden && playerResource.ForbiddenReason != TradeForbiddenReason.None)
				{
					tradeForbiddenReason = playerResource.ForbiddenReason;
				}
				if (tradeForbiddenReason == TradeForbiddenReason.AnimalLocked)
				{
					noTradeText.SetText(base.Localize.GetText(parentView.AnimalLockedTextKey));
				}
				else
				{
					noTradeText.SetText(parentView.WontTakeTextKey.ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()));
				}
			}
			CreatureBase creatureBase = null;
			if (playerResource != null)
			{
				creatureBase = playerResource.Creature;
			}
			tradeValue = 0;
			TradeResource primaryTradeResource = GetPrimaryTradeResource();
			float sellPrice = MonoSingleton<TradingManager>.Instance.GetSellPrice(primaryTradeResource);
			int num = playerResource?.Count ?? 0;
			Initialize(creatureBase);
			SetItemCount();
			SetPrice(sellPrice);
			float health = -1f;
			if (num > 0 && playerResource != null)
			{
				health = playerResource.Health;
			}
			SetHealth(health);
			tradingInput.AmountChangedEvent -= OnTradeValueChanged;
			tradingInput.AmountChangedEvent += OnTradeValueChanged;
			tradingInput.SetTradeValue(0);
			tradingInput.SetMinMax(-(this.playerResource?.Count ?? 0), 0);
			itemName.SetDataText(GetItemName(), GetItemTooltip());
			SetBackgroundColor();
		}

		public void InitWithResource(ExtortionPanelView parentView, Resource resourceType, TradeResource playerResource, bool canTrade)
		{
			this.playerResource = playerResource;
			this.canTrade = canTrade;
			tradingInput.SetInteractable(canTrade);
			priceGroup.SetActive(canTrade);
			noTradeText.gameObject.SetActive(!canTrade);
			if (!canTrade)
			{
				noTradeText.SetText(parentView.WontTakeTextKey.ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()));
			}
			tradeValue = 0;
			float sellPrice = MonoSingleton<TradingManager>.Instance.GetSellPrice(playerResource);
			int num = playerResource?.Count ?? 0;
			Initialize(resourceType);
			SetItemCount();
			SetPrice(sellPrice);
			if (base.IsEquipment || base.IsBuilding)
			{
				float health = -1f;
				if (num > 0 && playerResource != null)
				{
					health = playerResource.Health;
				}
				SetHealth(health);
			}
			else
			{
				SetHealth(0f);
			}
			tradingInput.AmountChangedEvent -= OnTradeValueChanged;
			tradingInput.AmountChangedEvent += OnTradeValueChanged;
			tradingInput.SetTradeValue(0);
			tradingInput.SetMinMax(-(this.playerResource?.Count ?? 0), 0);
			itemName.SetDataText(GetItemName(), GetItemTooltip());
			SetBackgroundColor();
		}

		private void SetPrice(float playerPrice)
		{
			playerPriceValue = playerPrice;
			int num = playerResource?.Count ?? 0;
			string text = ((num > 0) ? $"{ValueSprite} {playerPrice:N2}" : string.Empty);
			this.playerPrice.SetText(text);
			this.playerPrice.SetTooltipLines(GetPlayerPriceTooltip());
			this.playerPrice.TooltipNew.enabled = num > 0;
		}

		private TradeResource GetPrimaryTradeResource()
		{
			if (playerResource != null && (playerResource.Resource != null || playerResource.IsCreature))
			{
				return playerResource;
			}
			return null;
		}

		private List<string> GetPlayerPriceTooltip()
		{
			TradeResource primaryTradeResource = GetPrimaryTradeResource();
			float wealthPoints = primaryTradeResource.WealthPoints;
			List<string> list = new List<string> { UiUtils.Localize.GetText("wealth_price_sell") };
			if (primaryTradeResource.ConstantWealthPoints)
			{
				return list;
			}
			float min = MonoSingleton<TradingManager>.Instance.GetTraderMultipliers().Min;
			if (!Mathf.Approximately(min, 1f))
			{
				list.Add(string.Format("{0}: <style=AltColor>{1:F1}</style> * <style=AltColor>{2:F}</style>", MonoSingleton<LocalizationController>.Instance.GetText("base_trade_value"), wealthPoints, min));
			}
			float num = 1f - MonoSingleton<TradingManager>.Instance.GetPlayerMultipliers().Max;
			if (!Mathf.Approximately(num, 1f))
			{
				list.Add(string.Format("{0}: <style=AltColor>+{1:P}</style>", MonoSingleton<LocalizationController>.Instance.GetText("settler_trade_bonus"), num));
			}
			string text = string.Empty;
			if ((double)Math.Abs(MonoSingleton<TradingManager>.Instance.GetGlobalTraderMultiplier(primaryTradeResource) - 1f) > 0.01)
			{
				text = $"{MonoSingleton<TradingManager>.Instance.GetGlobalTraderMultiplier(primaryTradeResource)}";
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return list;
			}
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("global_trade_multiplier_name") + ": * <style=AltColor>" + text + "</style>");
			list.Add(TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText("global_trade_multiplier_info"), TooltipStyles.TooltipDescriptionLine));
			return list;
		}

		private void SetItemCount()
		{
			int num = playerResource?.Count ?? 0;
			string dataText = ((num > 0) ? $"{SpriteString} {num}" : string.Empty);
			playerAmount.SetDataText(dataText);
			playerAmount.TooltipNew.enabled = num > 0;
			MonoSingleton<TradingManager>.Instance.SetBuySellAmount(playerResource, null, tradeValue);
		}

		private void OnTradeValueChanged(int tradeValue)
		{
			this.tradeValue = tradeValue;
			SetBackgroundColor();
			SetItemCount();
		}

		private void SetBackgroundColor()
		{
			if (background == null)
			{
				return;
			}
			if (!canTrade)
			{
				if (playerResource != null && playerResource.IsForbidden)
				{
					background.color = entryGrayColor;
				}
				else
				{
					background.color = entryDisabledColor;
				}
			}
			else
			{
				background.color = ((tradeValue != 0) ? entryChangedColor : entryOriginalColor);
			}
		}

		public void ResetTrade()
		{
			OnTradeValueChanged(0);
			tradingInput.SetTradeValue(0);
		}
	}
}
