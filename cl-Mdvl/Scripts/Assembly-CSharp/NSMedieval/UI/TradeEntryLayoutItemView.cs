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
	public class TradeEntryLayoutItemView : TradingBaseLayoutItemView
	{
		private static string valueSprite;

		[SerializeField]
		private BasicLayoutItemView traderAmount;

		[SerializeField]
		private BasicLayoutItemView traderPrice;

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

		private bool isTraderFriendly;

		private TradeResource playerResource;

		private TradeResource traderResource;

		private int tradeValue;

		private float playerPriceValue;

		private float traderPriceValue;

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

		public TradeResource TraderResource => traderResource;

		public float PlayerPriceValue => playerPriceValue;

		public float TraderPriceValue => traderPriceValue;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			valueSprite = null;
		}

		public void InitWithCreature(TradeResource playerResource, TradeResource traderResource, bool canTrade, bool isTraderFriendly)
		{
			this.playerResource = playerResource;
			this.traderResource = traderResource;
			this.isTraderFriendly = isTraderFriendly;
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
				if (traderResource != null && traderResource.IsForbidden && traderResource.ForbiddenReason != TradeForbiddenReason.None)
				{
					tradeForbiddenReason = traderResource.ForbiddenReason;
				}
				switch (tradeForbiddenReason)
				{
				case TradeForbiddenReason.AnimalLocked:
					noTradeText.SetText(base.Localize.GetText("trade_animal_locked"));
					break;
				case TradeForbiddenReason.AnimalNoTrade:
					noTradeText.SetText(base.Localize.GetText("trader_wont_sell_animal"));
					break;
				case TradeForbiddenReason.PrisonerNotOwnFaction:
					noTradeText.SetText(base.Localize.GetText("cannot_trade_prisoner_wrong_faction"));
					break;
				case TradeForbiddenReason.WontOfferMorePrisoners:
					noTradeText.SetText(base.Localize.GetText("cannot_trade_prisoner_wont_offer"));
					break;
				default:
					noTradeText.SetText("trade_wont_buy".ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()));
					break;
				}
			}
			CreatureBase creatureBase = null;
			if (playerResource != null)
			{
				creatureBase = playerResource.Creature;
			}
			if (creatureBase == null && traderResource != null)
			{
				creatureBase = traderResource.Creature;
			}
			tradeValue = 0;
			TradeResource primaryTradeResource = GetPrimaryTradeResource();
			float buyPrice = MonoSingleton<TradingManager>.Instance.GetBuyPrice(primaryTradeResource);
			float sellPrice = MonoSingleton<TradingManager>.Instance.GetSellPrice(primaryTradeResource);
			int num = playerResource?.Count ?? 0;
			int num2 = traderResource?.Count ?? 0;
			Initialize(creatureBase);
			SetItemCount();
			SetPrice(sellPrice, buyPrice);
			float health = -1f;
			if (num > 0 && playerResource != null)
			{
				health = playerResource.Health;
			}
			if (num2 > 0 && traderResource != null)
			{
				health = traderResource.Health;
			}
			SetHealth(health);
			tradingInput.AmountChangedEvent -= OnTradeValueChanged;
			tradingInput.AmountChangedEvent += OnTradeValueChanged;
			tradingInput.SetTradeValue(0);
			int max = (isTraderFriendly ? (this.traderResource?.Count ?? 0) : 0);
			tradingInput.SetMinMax(-(this.playerResource?.Count ?? 0), max);
			itemName.SetDataText(GetItemName(), GetItemTooltip());
			SetBackgroundColor();
		}

		public void InitWithResource(Resource resourceType, TradeResource playerResource, TradeResource traderResource, bool canTrade, bool isTraderFriendly)
		{
			this.playerResource = playerResource;
			this.traderResource = traderResource;
			this.isTraderFriendly = isTraderFriendly;
			this.canTrade = canTrade;
			tradingInput.SetInteractable(canTrade);
			priceGroup.SetActive(canTrade);
			noTradeText.gameObject.SetActive(!canTrade);
			noTradeText.SetText("trade_wont_buy".ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()));
			tradeValue = 0;
			TradeResource primaryTradeResource = GetPrimaryTradeResource();
			float buyPrice = MonoSingleton<TradingManager>.Instance.GetBuyPrice(primaryTradeResource);
			float num = ((playerResource != null) ? MonoSingleton<TradingManager>.Instance.GetSellPrice(playerResource) : MonoSingleton<TradingManager>.Instance.GetSellPriceRes(traderResource));
			int num2 = playerResource?.Count ?? 0;
			int num3 = traderResource?.Count ?? 0;
			Initialize(resourceType);
			SetItemCount();
			SetPrice(num, buyPrice);
			if (base.IsEquipment || base.IsBuilding)
			{
				float health = -1f;
				if (num2 > 0 && playerResource != null)
				{
					health = playerResource.Health;
				}
				if (num3 > 0 && traderResource != null)
				{
					health = traderResource.Health;
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
			int max = (isTraderFriendly ? (this.traderResource?.Count ?? 0) : 0);
			tradingInput.SetMinMax(-(this.playerResource?.Count ?? 0), max);
			itemName.SetDataText(GetItemName(), GetItemTooltip());
			SetBackgroundColor();
		}

		private void SetPrice(float playerPrice, float traderPrice)
		{
			playerPriceValue = playerPrice;
			traderPriceValue = traderPrice;
			int num = playerResource?.Count ?? 0;
			int num2 = traderResource?.Count ?? 0;
			string text = ((num > 0) ? $"{ValueSprite} {playerPrice:N2}" : string.Empty);
			string text2 = ((num2 > 0 && isTraderFriendly) ? $"{ValueSprite} {traderPrice:N2}" : string.Empty);
			this.playerPrice.SetText(text);
			this.playerPrice.SetTooltipLines(GetPlayerPriceTooltip());
			this.playerPrice.TooltipNew.enabled = num > 0;
			this.traderPrice.SetText(text2);
			this.traderPrice.SetTooltipLines(GetTraderPriceTooltip());
			this.traderPrice.TooltipNew.enabled = num2 > 0;
		}

		private TradeResource GetPrimaryTradeResource()
		{
			if (playerResource != null && (playerResource.Resource != null || playerResource.IsCreature))
			{
				return playerResource;
			}
			return traderResource;
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

		private List<string> GetTraderPriceTooltip()
		{
			TradeResource primaryTradeResource = GetPrimaryTradeResource();
			float wealthPoints = primaryTradeResource.WealthPoints;
			List<string> list = new List<string> { "wealth_price_buy".ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()) };
			if (primaryTradeResource.ConstantWealthPoints)
			{
				return list;
			}
			string text = string.Empty;
			if ((double)Math.Abs(MonoSingleton<TradingManager>.Instance.GetGlobalTraderMultiplier(primaryTradeResource) - 1f) > 0.01)
			{
				text = $"{MonoSingleton<TradingManager>.Instance.GetGlobalTraderMultiplier(primaryTradeResource)}";
			}
			float max = MonoSingleton<TradingManager>.Instance.GetTraderMultipliers().Max;
			if (!Mathf.Approximately(max, 1f))
			{
				list.Add(TooltipStyles.ApplyStyle(string.Format("{0}: <style=AltColor>{1:F1}</style> * <style=AltColor>{2:F}</style>", MonoSingleton<LocalizationController>.Instance.GetText("base_trade_value"), wealthPoints, max), TooltipStyles.TooltipAttribute));
			}
			float tradeDealMultiplier = MonoSingleton<TradingManager>.Instance.GetTradeDealMultiplier();
			if (!Mathf.Approximately(tradeDealMultiplier, 1f))
			{
				list.Add(TooltipStyles.ApplyStyle(string.Format("{0}: <style=AltColor>-{1:F1}%</style>", MonoSingleton<LocalizationController>.Instance.GetText("trade_deal_bonus"), 100f - tradeDealMultiplier * 100f), TooltipStyles.TooltipAttribute));
			}
			float num = 1f - MonoSingleton<TradingManager>.Instance.GetPlayerMultipliers().Min;
			if (!Mathf.Approximately(num, 1f))
			{
				list.Add(TooltipStyles.ApplyStyle(string.Format("{0}: <style=AltColor>{1:P}</style>", MonoSingleton<LocalizationController>.Instance.GetText("settler_trade_bonus"), num), TooltipStyles.TooltipAttribute));
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return list;
			}
			list.Add(TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText("global_trade_multiplier_name") + ": * <style=AltColor>" + text + "</style>", TooltipStyles.TooltipAttribute));
			list.Add(TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText("global_trade_multiplier_info"), TooltipStyles.TooltipDescriptionLine));
			return list;
		}

		private void SetItemCount()
		{
			int num = playerResource?.Count ?? 0;
			int num2 = traderResource?.Count ?? 0;
			string dataText = ((num > 0) ? $"{SpriteString} {num}" : string.Empty);
			string dataText2 = ((num2 > 0 && isTraderFriendly) ? $"{SpriteString} {num2}" : string.Empty);
			playerAmount.SetDataText(dataText);
			playerAmount.TooltipNew.enabled = num > 0;
			traderAmount.SetDataText(dataText2);
			traderAmount.TooltipNew.SetLines(new string[1] { "trade_number_merchant".ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()) });
			traderAmount.TooltipNew.enabled = num2 > 0;
			MonoSingleton<TradingManager>.Instance.SetBuySellAmount(playerResource, traderResource, tradeValue);
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

		protected override void OnDestroy()
		{
			base.OnDestroy();
			playerResource = null;
			traderResource = null;
		}
	}
}
