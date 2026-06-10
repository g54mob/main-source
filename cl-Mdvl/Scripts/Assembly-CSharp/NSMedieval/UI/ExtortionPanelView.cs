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
	public class ExtortionPanelView : PopupView
	{
		private const float ScrollDefaultOffset = 20f;

		private const float ElementHeight = 32f;

		private const float MAX_XP_AFTER_TRADE = 300f;

		[SerializeField]
		private ApplyExtortionPrompt applyExtortionPrompt;

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
		private TMP_Text sellLabel;

		[SerializeField]
		private TMP_Text barLabel;

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
		private Color barFillBalanceValid;

		[SerializeField]
		private Color barFillBalanceInvalid;

		[SerializeField]
		private TMP_Text sellValueLabel;

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
		private TMP_Text storageLevelText;

		[SerializeField]
		private TMP_Text storageLevelTraderText;

		[SerializeField]
		private TMP_Text nutritionLevelText;

		private readonly List<ExtortionEntryLayoutItemView> tradeEntries = new List<ExtortionEntryLayoutItemView>();

		private readonly List<ExtortionEntryLayoutItemView> pinnedTradeEntries = new List<ExtortionEntryLayoutItemView>();

		private const int FilterOffsetIndex = 3;

		private const int AnimalFilterIndex = 1;

		private const int PrisonerFilterIndex = 2;

		private bool isApplyButtonEnabled;

		private bool isBalanceOk;

		private bool isTraderWeightOk;

		private bool isWeightOk;

		private ITrader otherTrader;

		private ITrader playerTrader;

		private bool sortDirection;

		private SortMode sortMode;

		private readonly List<LayoutGroupItemView> sellResources = new List<LayoutGroupItemView>();

		public string BarLabelTextKey { get; set; }

		public string GiveTextKey { get; set; }

		public string AskingTitleTextKey { get; set; }

		public string AskingDescTextKey { get; set; }

		public string WontTakeTextKey { get; set; }

		public string AreYouSureTextKey { get; set; }

		public string CantContinueTextKey { get; set; }

		public string OverCarryWeightTextKey { get; set; }

		public string AnimalLockedTextKey { get; set; }

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
			applyExtortionPrompt.Hide();
			MonoSingleton<TradingManager>.Instance.BalanceChangedEvent += OnBalanceChanged;
			this.otherTrader = otherTrader;
			this.playerTrader = playerTrader;
			List<TradeResource> resources = this.playerTrader.GetResources(this.otherTrader);
			MonoSingleton<TradingManager>.Instance.SetPlayerResources(resources);
			MonoSingleton<TradingManager>.Instance.SetTraderResources(new List<TradeResource>());
			Show();
			content.SetActive(value: true);
			MonoSingleton<UIController>.Instance.TradeWindowActive = true;
			barLabel.SetText(BarLabelTextKey.ToLocalized());
			playerName.SetText(this.playerTrader.GetTraderName());
			playerVillage.SetText(this.playerTrader.GetSettlementName());
			playerHeraldry.SetSprites(this.playerTrader.GetHeraldryCrest(), this.playerTrader.GetHeraldryBackground());
			playerHeraldryBackground.sprite = this.playerTrader.GetHeraldryBackground();
			traderName.SetText(this.otherTrader.GetTraderName());
			traderVillage.SetText(this.otherTrader.GetSettlementName());
			traderHeraldry.SetSprites(this.otherTrader.GetHeraldryCrest(), this.otherTrader.GetHeraldryBackground());
			traderHeraldryBackground.sprite = this.otherTrader.GetHeraldryBackground();
			HashSet<Resource> hashSet = new HashSet<Resource>();
			foreach (TradeResource item in resources.Where((TradeResource playerResource) => !ResourceUtils.IsItem(playerResource.Resource)))
			{
				if (!item.IsCreature)
				{
					hashSet.Add(item.Resource);
				}
			}
			int num = 0;
			int num2 = 0;
			foreach (Resource resourceType in hashSet)
			{
				TradeResource tradeResource = resources.FirstOrDefault((TradeResource item) => item.Resource == resourceType);
				ExtortionEntryLayoutItemView at;
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
				at.InitWithResource(this, resourceType, tradeResource, otherTrader.CanTradeResource(tradeResource));
			}
			foreach (TradeResource item2 in resources)
			{
				if (item2.IsItem)
				{
					tradeEntries.GetAt(tradingEntriesParent.GetComponent<LayoutGroupView>(), num).InitWithResource(this, item2.Resource, item2, otherTrader.CanTradeResource(item2));
					num++;
				}
			}
			foreach (TradeResource item3 in resources)
			{
				if (item3.IsCreature)
				{
					tradeEntries.GetAt(tradingEntriesParent.GetComponent<LayoutGroupView>(), num).InitWithCreature(this, item3, !item3.IsForbidden);
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
			OnBalanceChanged(0f, 0f, isBalanceOk: true, playerStorageWeight, playerNutrition, 0f);
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
			foreach (ExtortionEntryLayoutItemView pinnedTradeEntry in pinnedTradeEntries)
			{
				pinnedTradeEntry.ResetTrade();
			}
			foreach (ExtortionEntryLayoutItemView tradeEntry in tradeEntries)
			{
				tradeEntry.ResetTrade();
			}
		}

		private void CannotClickOnApplyTrade()
		{
			if (!isBalanceOk)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(CantContinueTextKey.ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()));
			}
		}

		private void ApplyTrade()
		{
			MonoSingleton<TradingManager>.Instance.ApplyTrade(300f);
			Hide();
		}

		private void ShowApplyTrade()
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("caravan_trade_finalize_title");
			string newValue = ((otherTrader.GetTraderVillagePlace() != null) ? otherTrader.GetTraderVillagePlace().FactionInstance.NameLocalized : string.Empty);
			string message = MonoSingleton<LocalizationController>.Instance.GetText(AreYouSureTextKey).Replace("<faction_name>", newValue);
			GetSellItemList(out var sellList);
			applyExtortionPrompt.SetDataAndShow(text, message, sellList, ApplyTrade);
		}

		private void OnBalanceChanged(float toBuyBalance, float toSellBalance, bool isBalanceOk, float playerStorageWeight, float playerNutrition, float otherTraderStorageWeight)
		{
			float num = Mathf.Max(1f, MonoSingleton<TradingManager>.Instance.ExtortionModeData.ValueDemanded);
			float num2 = toSellBalance / num;
			leftBar.value = Mathf.Clamp01(num2);
			sellValueLabel.text = $"{ExtortionEntryLayoutItemView.ValueSprite} {toSellBalance:N2} / {num:N2}";
			scalesTooltipView.SetLines(GetScalesTooltip());
			float num3 = otherTrader.GetStorageCapacity();
			if (num3 >= 0f)
			{
				num3 -= (float)MonoSingleton<TradingManager>.Instance.GetPlayerAdditionalStorageCapacity();
			}
			float num4 = playerTrader.GetStorageCapacity();
			if (num4 >= 0f)
			{
				num4 += (float)MonoSingleton<TradingManager>.Instance.GetPlayerAdditionalStorageCapacity();
			}
			string text = ((playerStorageWeight <= num4 || num4 <= 0f) ? "DefaultGreen" : "DefaultRed");
			string text2 = MonoSingleton<LocalizationController>.Instance.GetText("general_kg");
			string text3 = ((num4 > 0f) ? $"/ {num4:N1} {text2}</style>" : string.Empty);
			storageLevelText.SetText(string.Format("{0}: <style={1}>{2:N1} {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("storage"), text, playerStorageWeight, text3));
			storageLevelText.gameObject.SetActive(playerTrader is CaravanInstance);
			if (num3 <= 0f)
			{
				storageLevelTraderText.gameObject.SetActive(value: false);
			}
			else
			{
				num4 = num3;
				text = ((otherTraderStorageWeight <= num4 || num4 <= 0f) ? "DefaultGreen" : "DefaultRed");
				text3 = ((num4 > 0f) ? $"/ {num4:N1} {text2}</style>" : string.Empty);
				storageLevelTraderText.SetText(string.Format("{0}: <style={1}>{2:N1} {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("storage"), text, otherTraderStorageWeight, text3));
				storageLevelTraderText.gameObject.SetActive(value: true);
			}
			float minimumNutrition = playerTrader.GetMinimumNutrition();
			string text4 = ((playerNutrition < minimumNutrition) ? "DefaultRed" : "DefaultGreen");
			string text5 = ((minimumNutrition > 0f) ? $"/ {minimumNutrition:N1}" : string.Empty);
			nutritionLevelText.SetText(string.Format("{0}: <style={1}>{2:N1} {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("caravan_food"), text4, playerNutrition, text5));
			nutritionLevelText.gameObject.SetActive(playerTrader is CaravanInstance);
			FillBuySellItemsList(toSellBalance);
			isWeightOk = playerTrader.GetStorageCapacity() == -1 || playerStorageWeight <= num4;
			isTraderWeightOk = num3 <= 0f || otherTraderStorageWeight <= num3;
			this.isBalanceOk = num2 >= 1f && isBalanceOk;
			isApplyButtonEnabled = this.isBalanceOk && isWeightOk && isTraderWeightOk;
			applyButton.Button.interactable = isApplyButtonEnabled;
			PrepareApplyButtonTooltip();
			if (leftBarFill != null)
			{
				leftBarFill.color = (isBalanceOk ? barFillBalanceValid : barFillBalanceInvalid);
			}
		}

		private List<string> GetScalesTooltip()
		{
			return new List<string>
			{
				TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText(AskingTitleTextKey), TooltipStyles.TooltipTitle),
				TooltipStyles.ApplyStyle(MonoSingleton<LocalizationController>.Instance.GetText(AskingDescTextKey), TooltipStyles.TooltipDescriptionLine)
			};
		}

		private void PrepareApplyButtonTooltip()
		{
			if (isWeightOk && isBalanceOk && isTraderWeightOk)
			{
				applyButton.TooltipNew.enabled = false;
				return;
			}
			LocalizedTextTooltipView localizedTextTooltipView = applyButton.TooltipNew as LocalizedTextTooltipView;
			if (!(localizedTextTooltipView == null))
			{
				localizedTextTooltipView.TextKeys.Clear();
				localizedTextTooltipView.enabled = true;
				if (!isWeightOk)
				{
					localizedTextTooltipView.TextKeys.Add("caravan_message_mass");
				}
				if (!isTraderWeightOk)
				{
					localizedTextTooltipView.TextKeys.Add(OverCarryWeightTextKey);
				}
				if (!isBalanceOk)
				{
					localizedTextTooltipView.TextKeys.Add(CantContinueTextKey.ToLocalized(MonoSingleton<TradingManager>.Instance.GetTraderBodyType()));
				}
			}
		}

		private void GetSellItemList(out List<KeyValuePair<string, List<string>>> sellList)
		{
			sellList = new List<KeyValuePair<string, List<string>>>();
			foreach (Tuple<TradeResource, TradeResource, int> tradeGood in MonoSingleton<TradingManager>.Instance.TradeGoods)
			{
				int item = tradeGood.Item3;
				TradeResource tradeResource = ((item > 0) ? tradeGood.Item2 : tradeGood.Item1);
				string textIcon = tradeResource.GetTextIcon();
				KeyValuePair<string, List<string>> item2 = new KeyValuePair<string, List<string>>(textIcon + " " + item, GetItemTooltip(tradeResource));
				if (item < 0)
				{
					sellList.Add(item2);
				}
			}
		}

		protected List<string> GetItemTooltip(TradeResource tradeResource)
		{
			if (tradeResource.IsCreature)
			{
				if (tradeResource.Creature is HumanoidInstance humanoid)
				{
					return HumanoidUtils.GetTradeTooltipLines(humanoid);
				}
				if (tradeResource.Creature is AnimalInstance animalInstance)
				{
					List<string> list = new List<string>();
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

		private void FillBuySellItemsList(float toSellBalance)
		{
			sellLabel.text = $"{MonoSingleton<LocalizationController>.Instance.GetText(GiveTextKey)} (<sprite=\"value\" name=\"\"><color=#F5E3A1>{(int)toSellBalance}</color>)";
			GetSellItemList(out var sellList);
			sellResources.SetAllActive(active: false);
			foreach (KeyValuePair<string, List<string>> item in sellList)
			{
				item.Deconstruct(out var key, out var value);
				string text = key;
				List<string> lines = value;
				LayoutGroupItemView next = sellResources.GetNext(sellGroup);
				next.gameObject.SetActive(value: true);
				next.SetText(text);
				next.TooltipNew.SetLines(lines);
			}
		}

		private void SortEntries()
		{
			tradeEntries.Sort(TradeEntrySortComparison);
			int num = 0;
			foreach (ExtortionEntryLayoutItemView tradeEntry in tradeEntries)
			{
				if (tradeEntry.CanTrade)
				{
					tradeEntry.transform.SetSiblingIndex(num++);
				}
			}
			foreach (ExtortionEntryLayoutItemView tradeEntry2 in tradeEntries)
			{
				if (!tradeEntry2.CanTrade)
				{
					tradeEntry2.transform.SetSiblingIndex(num++);
				}
			}
		}

		private int TradeEntrySortComparison(ExtortionEntryLayoutItemView a, ExtortionEntryLayoutItemView b)
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
			case SortMode.PlayerPrice:
				num = (int)(1000f * (((a.PlayerResource != null) ? a.PlayerPriceValue : 0f) - ((b.PlayerResource != null) ? b.PlayerPriceValue : 0f)));
				break;
			case SortMode.Weight:
				num = (int)(1000f * (((a.Resource != null) ? a.Resource.Weight : 0f) - ((b.Resource != null) ? b.Resource.Weight : 0f)));
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
			foreach (ExtortionEntryLayoutItemView tradeEntry in tradeEntries)
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
