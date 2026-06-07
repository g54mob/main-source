using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class TraderElementUI : UIListElement
{
	[SerializeField]
	private Image icon;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private TextMeshProUGUI buyPriceText;

	[SerializeField]
	private GameObject buyDiscountIcon;

	[SerializeField]
	private TextMeshProUGUI sellPriceText;

	[SerializeField]
	private GameObject sellDiscountIcon;

	[SerializeField]
	private FillBar demandFillBar;

	[SerializeField]
	private Image background;

	[SerializeField]
	private TooltipComponent_text buyDiscountTooltip;

	[SerializeField]
	private TooltipComponent_text sellDiscountTooltip;

	private SelectableUI_trader selectableUITrader;

	private TraderElement traderElement;

	public SelectableUI_trader SelectableUITrader
	{
		get
		{
			return selectableUITrader;
		}
		set
		{
			selectableUITrader = value;
		}
	}

	public TraderElement TraderElement
	{
		get
		{
			return traderElement;
		}
		private set
		{
			traderElement = value;
		}
	}

	public void OnClikTraderElement()
	{
		SelectableUITrader.LoadTraderElement(traderElement);
	}

	public override void LoadData()
	{
		TraderElement = base.Data as TraderElement;
		TraderElement.onPriceChanged += OnPriceChanged;
		TraderElement.onDemandChanged += OnDemandChanged;
		icon.sprite = TraderElement.ResourceData.InventoryImage;
		nameText.text = TraderElement.ResourceData.DisplayName;
		UpdatePrice();
		UpdateDemand(traderElement.Demand);
		Dictionary<string, object> dictionary = new Dictionary<string, object> { 
		{
			"amount",
			Mathf.RoundToInt(50f)
		} };
		buyDiscountTooltip.TooltipText = new LocalizedString("UI_InGame", "UI_InGame_selectable_trader_tooltip_discount_purchase").GetLocalizedString(dictionary);
		sellDiscountTooltip.TooltipText = new LocalizedString("UI_InGame", "UI_InGame_selectable_trader_tooltip_discount_sale").GetLocalizedString(dictionary);
		if (base.Index % 2 == 0)
		{
			background.color = new Color(0f, 0f, 0f, 0.2f);
		}
		else
		{
			background.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
		}
	}

	private void OnDestroy()
	{
		TraderElement.onPriceChanged -= OnPriceChanged;
		TraderElement.onDemandChanged -= OnDemandChanged;
	}

	private void UpdatePrice()
	{
		buyPriceText.text = TraderElement.BuyPrice.ToString();
		sellPriceText.text = TraderElement.SellPrice.ToString();
		buyDiscountIcon.SetActive(TraderElement.HasPurchaseDiscount);
		sellDiscountIcon.SetActive(TraderElement.HasSaleDiscount);
	}

	private void UpdateDemand(float demand)
	{
		demandFillBar.SetBarValue(demand);
	}

	private void OnPriceChanged()
	{
		UpdatePrice();
	}

	private void OnDemandChanged(float demand)
	{
		UpdateDemand(demand);
	}
}
