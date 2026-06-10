using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.UI.TradingViewUtils;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TradingPanelView : PopupView
	{
		private const float ScrollDefaultOffset = 20f;

		private const float ElementHeight = 32f;

		[SerializeField]
		private ApplyTradePrompt applyTradePrompt;

		[SerializeField]
		private GameObject content;

		[SerializeField]
		private SoundButton resetButton;

		[SerializeField]
		private ButtonLayoutItemView applyButton;

		[SerializeField]
		private SoundButton cancelButton;

		[SerializeField]
		private Image traderHeraldryBackground;

		[SerializeField]
		private Image playerHeraldryBackground;

		[SerializeField]
		private HeraldrySymbolElement playerHeraldry;

		[SerializeField]
		private HeraldrySymbolElement traderHeraldry;

		[SerializeField]
		private TMP_Text buyLabel;

		[SerializeField]
		private TMP_Text sellLabel;

		[SerializeField]
		private LayoutGroupView buyGroup;

		[SerializeField]
		private LayoutGroupView sellGroup;

		[SerializeField]
		private TMP_Text traderName;

		[SerializeField]
		private TMP_Text traderVillage;

		[SerializeField]
		private TMP_Text playerName;

		[SerializeField]
		private TMP_Text playerVillage;

		[SerializeField]
		private TooltipViewNew scalesTooltipView;

		[SerializeField]
		private Slider leftBar;

		[SerializeField]
		private Image leftBarFill;

		[SerializeField]
		private Slider rightBar;

		[SerializeField]
		private Image rightBarFill;

		[SerializeField]
		private Color barFillBalanceValid;

		[SerializeField]
		private Color barFillBalanceInvalid;

		[SerializeField]
		private TMP_Text sellValueLabel;

		[SerializeField]
		private TMP_Text diffValueLabel;

		[SerializeField]
		private TMP_Text buyValueLabel;

		[SerializeField]
		private SoundButton[] sortingButtons;

		[SerializeField]
		private SortMode[] sortingButtonModes;

		[SerializeField]
		private SearchFilterView searchFilterView;

		[SerializeField]
		private string[] filterGroups;

		[SerializeField]
		private GameObject tradingEntriesParent;

		[SerializeField]
		private GameObject pinnedTradingEntriesParent;

		[SerializeField]
		private RectTransform entriesScroll;

		[SerializeField]
		private RectTransform sortingButtonsParent;

		[SerializeField]
		private GameObject thresholdMark;

		[SerializeField]
		private RectTransform rightBarRectTransform;

		[SerializeField]
		private TMP_Text storageLevelText;

		[SerializeField]
		private TMP_Text storageLevelTraderText;

		[SerializeField]
		private TMP_Text nutritionLevelText;

		private readonly List<TradeEntryLayoutItemView> tradeEntries = new List<TradeEntryLayoutItemView>();

		private readonly List<TradeEntryLayoutItemView> pinnedTradeEntries = new List<TradeEntryLayoutItemView>();

		private const int FilterOffsetIndex = 3;

		private const int AnimalFilterIndex = 1;

		private const int PrisonerFilterIndex = 2;

		private float buyBalance;

		private bool isApplyButtonEnabled;

		private bool isBalanceOk;

		private bool isNutritionOk;

		private bool isTraderWeightOk;

		private bool isWeightOk;

		private ITrader otherTrader;

		private ITrader playerTrader;

		private float sellBalance;

		private bool sortDirection;

		private SortMode sortMode;

		private readonly List<LayoutGroupItemView> sellResources = new List<LayoutGroupItemView>();

		private readonly List<LayoutGroupItemView> buyResources = new List<LayoutGroupItemView>();

		private void Start()
		{
			cancelButton.onClick.AddListener(Hide);
			resetButton.onClick.AddListener(ResetTrade);
			applyButton.Button.onClick.AddListener(ShowApplyTrade);
			applyButton.Button.onNonInteractableClick.AddListener(CannotClickOnApplyTrade);
			SoundButton[] array = sortingButtons;
			foreach (SoundButton sortingButton in array)
			{
				if (!(sortingButton == null))
				{
					sortingButton.onClick.RemoveAllListeners();
					sortingButton.onClick.AddListener(delegate
					{
						OnSortColumnClicked(sortingButton);
					});
				}
			}
			SetSortArrows(0);
			SetupSearchFilter();
		}

		public void Show(ITrader playerTrader, ITrader otherTrader)
		{
			if (IsShowing())
			{
				return;
			}
			applyTradePrompt.Hide();
			MonoSingleton<TradingManager>.Instance.BalanceChangedEvent += OnBalanceChanged;
			this.otherTrader = otherTrader;
			this.playerTrader = playerTrader;
			List<TradeResource> resources = this.playerTrader.GetResources(this.otherTrader);
			List<TradeResource> resources2 = this.otherTrader.GetResources(this.playerTrader);
			MonoSingleton<TradingManager>.Instance.SetPlayerResources(resources);
			MonoSingleton<TradingManager>.Instance.SetTraderResources(resources2);
			Show();
			content.SetActive(value: true);
			MonoSingleton<UIController>.Instance.TradeWindowActive = true;
			playerName.SetText(this.playerTrader.GetTraderName());
			playerVillage.SetText(this.playerTrader.GetSettlementName());
			playerHeraldry.SetSprites(this.playerTrader.GetHeraldryCrest(), this.playerTrader.GetHeraldryBackground());
			playerHeraldryBackground.sprite = this.playerTrader.GetHeraldryBackground();
			traderName.SetText(this.otherTrader.GetTraderName());
			traderVillage.SetText(this.otherTrader.GetSettlementName());
			traderHeraldry.SetSprites(this.otherTrader.GetHeraldryCrest(), this.otherTrader.GetHeraldryBackground());
			traderHeraldryBackground.sprite = this.otherTrader.GetHeraldryBackground();
			HashSet<Resource> allResourceTypes = new HashSet<Resource>();
			foreach (TradeResource item in resources.Where((TradeResource playerResource) => !ResourceUtils.IsItem(playerResource.Resource) && !allResourceTypes.Contains(playerResource.Resource)))
			{
				if (!item.IsCreature)
				{
					allResourceTypes.Add(item.Resource);
				}
			}
			bool flag = otherTrader.IsTraderFriendly();
			if (flag)
			{
				foreach (TradeResource item2 in resources2.Where((TradeResource traderResource) => traderResource.Resource != null && !ResourceUtils.IsItem(traderResource.Resource) && !allResourceTypes.Contains(traderResource.Resource)))
				{
					if (!item2.IsCreature)
					{
						allResourceTypes.Add(item2.Resource);
					}
				}
			}
			int num = 0;
			int num2 = 0;
			foreach (Resource resourceType in allResourceTypes)
			{
				TradeResource tradeResource = resources.FirstOrDefault((TradeResource item) => item.Resource == resourceType);
				TradeResource tradeResource2 = resources2.FirstOrDefault((TradeResource item) => item.Resource == resourceType);
				TradeEntryLayoutItemView at;
				if (resourceType.ConstantWealthPoints)
				{
					at = pinnedTradeEntries.GetAt(pinnedTradingEntriesParent.GetComponent<LayoutGroupView>(), num2);
					num2++;
				}
				else
				{
					at = tradeEntries.GetAt(tradingEntriesParent.GetComponent<LayoutGroupView>(), num);
					num++;
				}
				at.InitWithResource(resourceType, tradeResource, tradeResource2, otherTrader.CanTradeResource(tradeResource ?? tradeResource2), otherTrader.IsTraderFriendly());
			}
			foreach (TradeResource item3 in resources)
			{
				if (item3.IsItem)
				{
					tradeEntries.GetAt(tradingEntriesParent.GetComponent<LayoutGroupView>(), num).InitWithResource(item3.Resource, item3, null, otherTrader.CanTradeResource(item3), flag);
					num++;
				}
			}
			foreach (TradeResource item4 in resources)
			{
				if (item4.IsCreature)
				{
					tradeEntries.GetAt(tradingEntriesParent.GetComponent<LayoutGroupView>(), num).InitWithCreature(item4, null, !item4.IsForbidden && otherTrader.CanTradeResource(item4), flag);
					num++;
				}
			}
			if (flag)
			{
				foreach (TradeResource item5 in resources2)
				{
					if (item5.IsItem)
					{
						tradeEntries.GetAt(tradingEntriesParent.GetComponent<LayoutGroupView>(), num).InitWithResource(item5.Resource, null, item5, !item5.IsForbidden && otherTrader.CanTradeResource(item5), isTraderFriendly: true);
						num++;
					}
				}
			}
			foreach (TradeResource item6 in resources2)
			{
				if (item6.IsCreature)
				{
					tradeEntries.GetAt(tradingEntriesParent.GetComponent<LayoutGroupView>(), num).InitWithCreature(null, item6, !item6.IsForbidden, flag);
					num++;
				}
			}
			pinnedTradingEntriesParent.SetActive(num2 > 0);
			float num3 = (float)num2 * 32f;
			sortingButtonsParent.anchoredPosition = new Vector2(0f, 0f - num3);
			float num4 = 20f + num3;
			entriesScroll.offsetMax = new Vector2(0f, 0f - num4);
			tradeEntries.SetActiveFromIndex(num, active: false);
			SortEntries();
			searchFilterView.ResetFilter();
			float playerStorageWeight = resources.Sum((TradeResource resource) => (float)resource.Count * resource.Weight);
			float playerNutrition = resources.Sum((TradeResource resource) => (float)resource.Count * resource.Nutrition);
			float otherTraderStorageWeight = resources2.Sum((TradeResource resource) => (float)resource.Count * resource.Weight);
			OnBalanceChanged(0f, 0f, isBalanceOk: true, playerStorageWeight, playerNutrition, otherTraderStorageWeight);
		}

		protected override void OnHide()
		{
			base.OnHide();
			MonoSingleton<TradingManager>.Instance.SetPlayerResources(null);
			MonoSingleton<TradingManager>.Instance.SetTraderResources(null);
			MonoSingleton<TradingManager>.Instance.BalanceChangedEvent -= OnBalanceChanged;
			content.SetActive(value: true);
			MonoSingleton<UIController>.Instance.TradeWindowActive = false;
		}

		private void ResetTrade()
		{
			foreach (TradeEntryLayoutItemView pinnedTradeEntry in pinnedTradeEntries)
			{
				pinnedTradeEntry.ResetTrade();
			}
			foreach (TradeEntryLayoutItemView tradeEntry in tradeEntries)
			{
				tradeEntry.ResetTrade();
			}
		}

		private void CannotClickOnApplyTrade()
		{
			if (!isNutritionOk)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_food"));
			}
			if (!isWeightOk)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_mass"));
			}
			if (!isTraderWeightOk)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("trader_message_mass"));
			}
			if (!isBalanceOk)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("trade_message_cant_continue"));
			}
		}

		private void ApplyTrade()
		{
			if (IsShowing())
			{
				MonoSingleton<TradingManager>.Instance.ApplyTrade();
				Hide();
			}
		}

		private void ShowApplyTrade()
		{
			bool flag = buyBalance <= 0f && sellBalance > 0f;
			string text = MonoSingleton<LocalizationController>.Instance.GetText(flag ? "caravan_trade_gift_only_title" : "caravan_trade_finalize_title");
			string newValue = ((otherTrader.GetTraderVillagePlace() != null) ? otherTrader.GetTraderVillagePlace().FactionInstance.NameLocalized : string.Empty);
			string message = (flag ? MonoSingleton<LocalizationController>.Instance.GetText("caravan_gift_message", otherTrader.GetTraderVillagePlace()).Replace("<faction_name>", newValue) : ((!(sellBalance - buyBalance > 5f)) ? MonoSingleton<LocalizationController>.Instance.GetText("caravan_trade_are_you_sure").Replace("<faction_name>", newValue) : MonoSingleton<LocalizationController>.Instance.GetText("caravan_gift_giving_more").Replace("<faction_name>", newValue)));
			GetBuyBuySellSellItemList(out var buyList, out var sellList);
			applyTradePrompt.SetDataAndShow(text, message, buyList, sellList, ApplyTrade);
		}

		private void OnBalanceChanged(float toBuyBalance, float toSellBalance, bool isBalanceOk, float playerStorageWeight, float playerNutrition, float otherTraderStorageWeight)
		{
			buyBalance = toBuyBalance;
			sellBalance = toSellBalance;
			float num = toBuyBalance - toSellBalance;
			float num2 = toBuyBalance + toSellBalance;
			float num3 = num / num2;
			rightBar.value = ((num3 > 0f) ? num3 : 0f);
			leftBar.value = ((num3 < 0f) ? Mathf.Abs(num3) : 0f);
			sellValueLabel.text = $"{TradeEntryLayoutItemView.ValueSprite} {toSellBalance:N2}";
			buyValueLabel.text = $"{TradeEntryLayoutItemView.ValueSprite} {toBuyBalance:N2}";
			diffValueLabel.text = $"{TradeEntryLayoutItemView.ValueSprite} {num:N2}";
			scalesTooltipView.SetLines(GetScalesTooltip());
			float num4 = otherTrader.GetStorageCapacity();
			if (num4 >= 0f)
			{
				num4 -= (float)MonoSingleton<TradingManager>.Instance.GetPlayerAdditionalStorageCapacity();
			}
			float num5 = playerTrader.GetStorageCapacity();
			if (num5 >= 0f)
			{
				num5 += (float)MonoSingleton<TradingManager>.Instance.GetPlayerAdditionalStorageCapacity();
			}
			string text = ((playerStorageWeight <= num5 || num5 <= 0f) ? "DefaultGreen" : "DefaultRed");
			string text2 = MonoSingleton<LocalizationController>.Instance.GetText("general_kg");
			string text3 = ((num5 > 0f) ? $"/ {num5:N1} {text2}</style>" : string.Empty);
			storageLevelText.SetText(string.Format("{0}: <style={1}>{2:N1} {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("storage"), text, playerStorageWeight, text3));
			storageLevelText.gameObject.SetActive(playerTrader is CaravanInstance);
			if (num4 <= 0f)
			{
				storageLevelTraderText.gameObject.SetActive(value: false);
			}
			else
			{
				num5 = num4;
				text = ((otherTraderStorageWeight <= num5 || num5 <= 0f) ? "DefaultGreen" : "DefaultRed");
				text3 = ((num5 > 0f) ? $"/ {num5:N1} {text2}</style>" : string.Empty);
				storageLevelTraderText.SetText(string.Format("{0}: <style={1}>{2:N1} {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("storage"), text, otherTraderStorageWeight, text3));
				storageLevelTraderText.gameObject.SetActive(value: true);
			}
			float num6 = 0f;
			if (playerTrader is CaravanInstance caravanInstance)
			{
				num6 = caravanInstance.GetMinimumNutrition(MonoSingleton<TradingManager>.Instance.GetPlayerAdditionalHumansCount());
			}
			float num7 = playerTrader.GetMinimumNutrition() + num6;
			string text4 = ((playerNutrition < num7) ? "DefaultRed" : "DefaultGreen");
			string text5 = ((num7 > 0f) ? $"/ {num7:N1}" : string.Empty);
			nutritionLevelText.SetText(string.Format("{0}: <style={1}>{2:N1} {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("caravan_food"), text4, playerNutrition, text5));
			nutritionLevelText.gameObject.SetActive(playerTrader is CaravanInstance);
			if (num2 > 0f)
			{
				thresholdMark.transform.localPosition = playerTrader.GetBargainMultiplier() * Vector3.right * rightBarRectTransform.rect.width;
			}
			FillBuySellItemsList(toBuyBalance, toSellBalance);
			isWeightOk = playerTrader.GetStorageCapacity() == -1 || playerStorageWeight <= num5;
			isTraderWeightOk = num4 <= 0f || otherTraderStorageWeight <= num4;
			isNutritionOk = num7 <= 0f || playerNutrition >= num7;
			this.isBalanceOk = isBalanceOk;
			isApplyButtonEnabled = toSellBalance != 0f && isBalanceOk && isWeightOk && isNutritionOk && isTraderWeightOk;
			applyButton.Button.interactable = isApplyButtonEnabled;
			PrepareApplyButtonTooltip();
			if (leftBarFill != null && rightBarFill != null)
			{
				leftBarFill.color = (isBalanceOk ? barFillBalanceValid : barFillBalanceInvalid);
				rightBarFill.color = (isBalanceOk ? barFillBalanceValid : barFillBalanceInvalid);
			}
		}

		private List<string> GetScalesTooltip()
		{
			return new List<string>
			{
				TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText("trade_balance_title"), TooltipStyles.TooltipTitle),
				TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText("trade_balance_desc"), TooltipStyles.TooltipDescriptionLine),
				string.Format("{0}: <style=AltColor>{1:p}</style>", MonoSingleton<LocalizationController>.Instance.GetText("trade_balance_bargain"), playerTrader.GetBargainMultiplier())
			};
		}

		private void PrepareApplyButtonTooltip()
		{
			if (isNutritionOk && isWeightOk && isBalanceOk && isTraderWeightOk)
			{
				applyButton.TooltipNew.enabled = false;
				return;
			}
			LocalizedTextTooltipView localizedTextTooltipView = applyButton.TooltipNew as LocalizedTextTooltipView;
			if (!(localizedTextTooltipView == null))
			{
				List<string> list = new List<string>();
				if (!isNutritionOk)
				{
					list.Add("caravan_message_food");
				}
				if (!isWeightOk)
				{
					list.Add("caravan_message_mass");
				}
				if (!isTraderWeightOk)
				{
					list.Add("trader_message_mass");
				}
				if (!isBalanceOk)
				{
					list.Add("trade_message_cant_continue");
				}
				localizedTextTooltipView.TextKeys = list;
				localizedTextTooltipView.enabled = true;
			}
		}

		private void GetBuyBuySellSellItemList(out List<KeyValuePair<string, List<string>>> buyList, out List<KeyValuePair<string, List<string>>> sellList)
		{
			buyList = new List<KeyValuePair<string, List<string>>>();
			sellList = new List<KeyValuePair<string, List<string>>>();
			foreach (Tuple<TradeResource, TradeResource, int> tradeGood in MonoSingleton<TradingManager>.Instance.TradeGoods)
			{
				int item = tradeGood.Item3;
				TradeResource tradeResource = ((item > 0) ? tradeGood.Item2 : tradeGood.Item1);
				string textIcon = tradeResource.GetTextIcon();
				KeyValuePair<string, List<string>> item2 = new KeyValuePair<string, List<string>>(textIcon + " " + item, GetItemTooltip(tradeResource));
				if (item > 0)
				{
					buyList.Add(item2);
				}
				else if (item < 0)
				{
					sellList.Add(item2);
				}
			}
		}

		protected List<string> GetItemTooltip(TradeResource tradeResource)
		{
			if (tradeResource.IsCreature)
			{
				if (tradeResource.Creature is HumanoidInstance)
				{
					return new List<string>();
				}
				if (tradeResource.Creature is AnimalInstance animalInstance)
				{
					List<string> list = new List<string>();
					if (animalInstance.HasDied || animalInstance.HasDisposed || animalInstance.Stats == null)
					{
						return list;
					}
					list.Add(AnimalUtils.GetLocalizedName(animalInstance.Blueprint) + " (" + AnimalUtils.GetLocalizedGender(animalInstance) + ")");
					list.Add(AnimalUtils.GetLocalizedHealth(animalInstance));
					list.AddRange(AnimalUtils.GetModifiers(animalInstance));
					return list;
				}
				return new List<string>();
			}
			Equipment equipmentFromResource = EquipmentUtils.GetEquipmentFromResource(tradeResource.Resource);
			if (equipmentFromResource != null)
			{
				List<string> list2 = new List<string>();
				list2.Add(TooltipStyles.ApplyStyle(EquipmentUtils.GetTooltipTitle(equipmentFromResource), TooltipStyles.TooltipTitle));
				list2.Add(MonoSingleton<LocalizationController>.Instance.GetText("menu_quality") + ": " + MonoSingleton<LocalizationController>.Instance.GetText("quality_" + tradeResource.Resource.Quality.ToString().ToLower()));
				list2.Add(string.Format("{0}: {1:P1}", MonoSingleton<LocalizationController>.Instance.GetText("menu_health"), tradeResource.Health));
				list2.Add(string.Format("{0}: {1}{2}", UiUtils.Localize.GetText("menu_character_weight"), tradeResource.Resource.Weight, UiUtils.Localize.GetText("general_kg")));
				list2.AddRange(EquipmentUtils.GetTooltipLines(equipmentFromResource, null));
				return list2;
			}
			return ResourceUtils.GetTooltipData(tradeResource.Resource.GetID());
		}

		private void GetBuyBuySellSellItemListSimple(out List<string> buyList, out List<string> sellList)
		{
			buyList = new List<string>();
			sellList = new List<string>();
			foreach (Tuple<TradeResource, TradeResource, int> tradeGood in MonoSingleton<TradingManager>.Instance.TradeGoods)
			{
				int item = tradeGood.Item3;
				TradeResource item2 = tradeGood.Item1;
				TradeResource item3 = tradeGood.Item2;
				TradeResource tradeResource = ((item > 0) ? item3 : item2);
				string item4 = $"{tradeResource.GetTextIcon()} {Math.Abs(item)}";
				if (item > 0)
				{
					buyList.Add(item4);
				}
				else if (item < 0)
				{
					sellList.Add(item4);
				}
			}
		}

		private void FillBuySellItemsList(float toBuyBalance, float toSellBalance)
		{
			buyLabel.text = string.Format("{0} (<sprite=\"value\" name=\"\"><color=#F5E3A1>{1}</color>)", MonoSingleton<LocalizationController>.Instance.GetText("trade_buy"), (int)toBuyBalance);
			sellLabel.text = string.Format("{0} (<sprite=\"value\" name=\"\"><color=#F5E3A1>{1}</color>)", MonoSingleton<LocalizationController>.Instance.GetText("trade_sell"), (int)toSellBalance);
			GetBuyBuySellSellItemList(out var buyList, out var sellList);
			buyResources.SetAllActive(active: false);
			string key;
			List<string> value;
			foreach (KeyValuePair<string, List<string>> item in buyList)
			{
				item.Deconstruct(out key, out value);
				string text = key;
				List<string> lines = value;
				LayoutGroupItemView next = buyResources.GetNext(buyGroup);
				next.gameObject.SetActive(value: true);
				next.SetText(text);
				next.TooltipNew.SetLines(lines);
			}
			sellResources.SetAllActive(active: false);
			foreach (KeyValuePair<string, List<string>> item2 in sellList)
			{
				item2.Deconstruct(out key, out value);
				string text2 = key;
				List<string> lines2 = value;
				LayoutGroupItemView next2 = sellResources.GetNext(sellGroup);
				next2.gameObject.SetActive(value: true);
				next2.SetText(text2);
				next2.TooltipNew.SetLines(lines2);
			}
		}

		private void SortEntries()
		{
			tradeEntries.Sort(TradeEntrySortComparison);
			int num = 0;
			foreach (TradeEntryLayoutItemView tradeEntry in tradeEntries)
			{
				if (tradeEntry.CanTrade)
				{
					tradeEntry.transform.SetSiblingIndex(num++);
				}
			}
			foreach (TradeEntryLayoutItemView tradeEntry2 in tradeEntries)
			{
				if (!tradeEntry2.CanTrade)
				{
					tradeEntry2.transform.SetSiblingIndex(num++);
				}
			}
		}

		private int TradeEntrySortComparison(TradeEntryLayoutItemView a, TradeEntryLayoutItemView b)
		{
			int num = 0;
			switch (sortMode)
			{
			case SortMode.Name:
				num = string.Compare(b.ItemNameString, a.ItemNameString, StringComparison.CurrentCultureIgnoreCase);
				break;
			case SortMode.PlayerAmount:
				num = (a.PlayerResource?.Count ?? 0) - (b.PlayerResource?.Count ?? 0);
				break;
			case SortMode.TraderAmount:
				num = (a.TraderResource?.Count ?? 0) - (b.TraderResource?.Count ?? 0);
				break;
			case SortMode.PlayerPrice:
				num = Mathf.RoundToInt(1000f * ((a.PlayerResource != null) ? a.PlayerPriceValue : 0f)) - Mathf.RoundToInt(1000f * ((b.PlayerResource != null) ? b.PlayerPriceValue : 0f));
				break;
			case SortMode.TraderPrice:
				num = Mathf.RoundToInt(1000f * ((a.TraderResource != null) ? a.TraderPriceValue : 0f)) - Mathf.RoundToInt(1000f * ((b.TraderResource != null) ? b.TraderPriceValue : 0f));
				break;
			case SortMode.Weight:
				num = Mathf.RoundToInt(1000f * ((a.Resource != null) ? a.Resource.Weight : 0f)) - Mathf.RoundToInt(1000f * ((b.Resource != null) ? b.Resource.Weight : 0f));
				break;
			}
			if (!sortDirection)
			{
				return -num;
			}
			return num;
		}

		private void SetSortMode(SortMode mode)
		{
			if (sortMode == mode)
			{
				sortDirection = !sortDirection;
				SortEntries();
			}
			else
			{
				sortDirection = false;
				sortMode = mode;
				SortEntries();
			}
		}

		private void OnSortColumnClicked(SoundButton sortButton)
		{
			int num = -1;
			for (int i = 0; i < sortingButtons.Length; i++)
			{
				if (sortingButtons[i] == sortButton)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				SetSortMode(sortingButtonModes[num]);
				SetSortArrows(num);
			}
		}

		private void SetSortArrows(int selectedButtonIndex)
		{
			for (int i = 0; i < sortingButtons.Length; i++)
			{
				TradingSortArrowImages component = sortingButtons[i].GetComponent<TradingSortArrowImages>();
				if (component != null)
				{
					bool upDown = i == selectedButtonIndex && sortDirection;
					component.SetArrows(upDown, i == selectedButtonIndex);
				}
			}
		}

		private void OnFilterApplied(int filterIndex)
		{
			string mainGroupName = null;
			if (filterIndex >= 3)
			{
				mainGroupName = filterGroups[filterIndex - 3];
			}
			foreach (TradeEntryLayoutItemView tradeEntry in tradeEntries)
			{
				if (filterIndex == 0)
				{
					tradeEntry.gameObject.SetActive(value: true);
					continue;
				}
				if (filterIndex < 3)
				{
					if (tradeEntry.Resource != null)
					{
						tradeEntry.gameObject.SetActive(value: false);
					}
					else
					{
						tradeEntry.gameObject.SetActive((filterIndex == 1) ? (!tradeEntry.IsHuman) : tradeEntry.IsHuman);
					}
					continue;
				}
				if (tradeEntry.Resource == null)
				{
					tradeEntry.gameObject.SetActive(value: false);
					continue;
				}
				Resource resource = tradeEntry.Resource;
				if (string.IsNullOrEmpty(resource.SortingGroup))
				{
					tradeEntry.gameObject.SetActive(value: false);
					continue;
				}
				bool active = Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.CheckGroup(resource.SortingGroup, mainGroupName);
				tradeEntry.gameObject.SetActive(active);
			}
		}

		private void SetupSearchFilter()
		{
			List<string> list = new List<string>();
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("filter_all_items"));
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("filter_animals"));
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("filter_prisoners"));
			string[] array = filterGroups;
			foreach (string text in array)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("resource_group_" + text));
			}
			searchFilterView.SetupFilters(list);
			searchFilterView.OnFilterChanged += OnFilterApplied;
		}
	}
}
