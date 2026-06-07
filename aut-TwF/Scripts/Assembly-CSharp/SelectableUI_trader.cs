using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SelectableUI_trader : SelectableUI
{
	[SerializeField]
	private UIList traderElementsList;

	[Space]
	[SerializeField]
	private GameObject unselectedPanel;

	[SerializeField]
	private GameObject selectedElementPanel;

	[Space]
	[SerializeField]
	private Image selectedElementIcon;

	[SerializeField]
	private TextMeshProUGUI selectedElementName;

	[SerializeField]
	private Slider selectedElementAmountSlider;

	[Space]
	[SerializeField]
	private TextMeshProUGUI tokensText;

	[Space]
	[SerializeField]
	private TextMeshProUGUI buyButtonText;

	[SerializeField]
	private AutoTransformRebuild buyButtonAutoRebuild;

	[SerializeField]
	private TextMeshProUGUI sellButtonText;

	[SerializeField]
	private AutoTransformRebuild sellButtonAutoRebuild;

	private Trader trader;

	private TraderElement selectedTraderElement;

	private int currentElementAmount;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			Trader = SelectedObject as Trader;
			LoadTraderElementsList();
			LoadTraderElement(Trader.LastSelectedElement);
			selectedElementAmountSlider.SetValueWithoutNotify(trader.LastSelectedAmount);
			CurrentElementAmount = trader.LastSelectedAmount;
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	public Trader Trader
	{
		get
		{
			return trader;
		}
		set
		{
			trader = value;
			OnTokensChanged(trader.Tokens);
			trader.OnTokensChanged += OnTokensChanged;
		}
	}

	private int CurrentElementAmount
	{
		get
		{
			return currentElementAmount;
		}
		set
		{
			currentElementAmount = value;
			trader.LastSelectedAmount = currentElementAmount;
			UpdateButtonsText();
		}
	}

	private void OnDestroy()
	{
		trader.OnTokensChanged -= OnTokensChanged;
	}

	private void LoadTraderElementsList()
	{
		int currentTier = LTFunctionLibrary.GetMaxTierUnlocked();
		traderElementsList.LoadList(trader.TraderElements.FindAll((TraderElement x) => x.Tier <= currentTier));
		foreach (UIListElement element in traderElementsList.Elements)
		{
			(element as TraderElementUI).SelectableUITrader = this;
		}
	}

	public void LoadTraderElement(TraderElement traderElement)
	{
		unselectedPanel.SetActive(traderElement == null);
		selectedElementPanel.SetActive(traderElement != null);
		if (traderElement != null)
		{
			selectedTraderElement = traderElement;
			trader.LastSelectedElement = traderElement;
			selectedElementIcon.sprite = selectedTraderElement.ResourceData.Image;
			selectedElementName.text = selectedTraderElement.ResourceData.DisplayName;
			UpdateButtonsText();
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	private void UpdateButtonsText()
	{
		if (selectedTraderElement != null)
		{
			int num = selectedTraderElement.BuyPrice * CurrentElementAmount;
			int num2 = selectedTraderElement.SellPrice * CurrentElementAmount;
			buyButtonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_selectable_trader_label_buy", null, FallbackBehavior.UseProjectSettings) + " - " + num;
			buyButtonAutoRebuild.RebuildTransform();
			sellButtonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_selectable_trader_label_sell", null, FallbackBehavior.UseProjectSettings) + " - " + num2;
			sellButtonAutoRebuild.RebuildTransform();
		}
	}

	public void OnAmountSliderChanged(float newValue)
	{
		CurrentElementAmount = Mathf.RoundToInt(newValue);
	}

	private void OnTokensChanged(int newTokens)
	{
		tokensText.text = newTokens.ToString();
	}

	public void OnBuyTraderElementPressed()
	{
		trader.BuyTraderElement(selectedTraderElement, CurrentElementAmount);
		UpdateButtonsText();
	}

	public void OnSellTraderElementPressed()
	{
		trader.SellTraderElement(selectedTraderElement, CurrentElementAmount);
		UpdateButtonsText();
	}
}
