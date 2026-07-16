using System.Collections.Generic;
using MLCN_Localization;
using TMPro;
using UnityEngine;

public class PirceOverviewManager : MonoBehaviour
{
	[Header("Income")]
	[SerializeField]
	private TMP_Text labelValueSoldCoffee;

	[SerializeField]
	private TMP_Text labelValueTips;

	[SerializeField]
	private TMP_Text labelValueDeposit;

	[SerializeField]
	private TMP_Text labelValueSubtotal;

	[Header("Turnover")]
	[SerializeField]
	private TMP_Text labelValueUpkeep;

	[SerializeField]
	private TMP_Text labelValueTurnoverSummary;

	[Header("Expenses")]
	[SerializeField]
	private TMP_Text labelTitleRent;

	[SerializeField]
	private TMP_Text labelValueRent;

	[SerializeField]
	private TMP_Text labelValueLights;

	[SerializeField]
	private TMP_Text labelValueOthers;

	[SerializeField]
	private TMP_Text labelValueExtensionExpenses;

	[Header("Orders")]
	[SerializeField]
	private GameObject orderSlotPrefab;

	[SerializeField]
	private RectTransform contentOrderSlots;

	private List<FinanceOrderSlot> orderSlots = new List<FinanceOrderSlot>();

	private int rentCosts;

	private int lightCosts;

	private int otherCosts;

	[Header("Flavours")]
	[SerializeField]
	private GameObject flavourSlotPrefab;

	[SerializeField]
	private RectTransform contentFlavourSlots;

	private List<FinanceFlavourSlot> flavourSlots = new List<FinanceFlavourSlot>();

	[Header("Sizes")]
	[SerializeField]
	private GameObject cupSizeSlotPrefab;

	[SerializeField]
	private RectTransform contentSizesSlots;

	private List<FinanceCupSizeSlot> cupSizesSlots = new List<FinanceCupSizeSlot>();

	private void Start()
	{
		LocalizationManager.OnLanguageChange.AddListener(delegate
		{
			InitMarketList();
			UpdateOrderNames();
		});
		CafeShopManager.OnResetFinanceStats.AddListener(ClearTodaysValues);
		CafeShopManager.OnCafeRatingChanged.AddListener(delegate
		{
			UpdateMarketList();
		});
		InitTurnover();
		InitMarketList();
	}

	private void InitTurnover()
	{
		ClearTodaysValues();
		CafeShopManager.OnTurnoverChanged.AddListener(UpdateValueSoldCoffee);
		CafeShopManager.OnTipsChanged.AddListener(UpdateValueTips);
		CafeShopManager.OnDepositsChanged.AddListener(UpdateValueDeposits);
		CafeShopManager.OnUpkeepChanged.AddListener(delegate
		{
			UpdateDailyExpenses();
		});
		CafeShopManager.OnUpkeepChanged.AddListener(delegate
		{
			UpdateValueTotalExpenses();
		});
		ShopBuilder.OnRoomCountChanged.AddListener(UpdateTitleRent);
		CafeShopManager.OnRoomUpkeepChanged.AddListener(delegate(int x)
		{
			UpdateValueRent(x);
		});
		CafeShopManager.OnExtensionsChanged.AddListener(UpdateValueExtensions);
		OrderManager.OnPlaceOrderEvent.AddListener(AddOrderSlot);
		UpdateValueSoldCoffee();
		UpdateValueTips();
		UpdateValueDeposits();
		UpdateValueSubTotal();
		UpdateValueTotalExpenses();
		UpdateValueSummary();
		UpdateTitleRent();
		UpdateDailyExpenses();
		UpdateValueExtensions(0);
	}

	private void InitMarketList()
	{
		flavourSlots.ForEach(delegate(FinanceFlavourSlot x)
		{
			Object.Destroy(x.gameObject);
		});
		cupSizesSlots.ForEach(delegate(FinanceCupSizeSlot x)
		{
			Object.Destroy(x.gameObject);
		});
		flavourSlots.Clear();
		cupSizesSlots.Clear();
		string[] allTagsWithLocalization = AnomalyTag.GetAllTagsWithLocalization();
		for (int num = 0; num < allTagsWithLocalization.Length; num++)
		{
			FinanceFlavourSlot component = Object.Instantiate(flavourSlotPrefab, contentFlavourSlots).GetComponent<FinanceFlavourSlot>();
			ProductFlavourOption productFlavourOptionByName = ProductManager.GetProductFlavourOptionByName(AnomalyTag.anomalyOptions[num]);
			component.Init(allTagsWithLocalization[num], productFlavourOptionByName.priceValue, ProductManager.GetCafeRatingMaxFactor(productFlavourOptionByName.priceValue), productFlavourOptionByName.locked);
			flavourSlots.Add(component);
		}
		ProductSizeOption[] allProductSizes = ProductManager.GetAllProductSizes();
		for (int num2 = 0; num2 < allProductSizes.Length; num2++)
		{
			FinanceCupSizeSlot component2 = Object.Instantiate(cupSizeSlotPrefab, contentSizesSlots).GetComponent<FinanceCupSizeSlot>();
			component2.Init(allProductSizes[num2].GetLocalizedName(), allProductSizes[num2].GetFactor(), allProductSizes[num2].locked);
			cupSizesSlots.Add(component2);
		}
	}

	private void UpdateMarketList()
	{
		for (int i = 0; i < flavourSlots.Count; i++)
		{
			ProductFlavourOption productFlavourOptionByName = ProductManager.GetProductFlavourOptionByName(AnomalyTag.anomalyOptions[i]);
			flavourSlots[i].UpdateSlot(flavourSlots[i].flavourName, productFlavourOptionByName.priceValue, ProductManager.GetCafeRatingMaxFactor(productFlavourOptionByName.priceValue), productFlavourOptionByName.locked);
		}
	}

	private void AddOrderSlot(PlacedOrder order, GameTime time)
	{
		FinanceOrderSlot component = Object.Instantiate(orderSlotPrefab, contentOrderSlots).GetComponent<FinanceOrderSlot>();
		component.Init(order, time, orderSlots.Count + 1);
		orderSlots.Add(component);
	}

	private void UpdateOrderNames()
	{
		orderSlots.ForEach(delegate(FinanceOrderSlot x)
		{
			x.UpdateNameLocalization();
		});
	}

	private void ClearTodaysValues()
	{
		labelValueSoldCoffee.text = "0";
		labelValueTips.text = "0";
		labelValueDeposit.text = "0";
		labelValueSubtotal.text = "0<sprite=0>";
		labelValueUpkeep.text = "0";
		labelValueTurnoverSummary.text = "0<sprite=0>";
		labelValueExtensionExpenses.text = "0";
		orderSlots.ForEach(delegate(FinanceOrderSlot x)
		{
			Object.Destroy(x.gameObject);
		});
		orderSlots.Clear();
	}

	private void UpdateValueSoldCoffee()
	{
		labelValueSoldCoffee.text = CafeShopManager.GetTurnOverNoTip();
		UpdateValueSubTotal();
		UpdateValueSummary();
	}

	private void UpdateValueTips()
	{
		labelValueTips.text = CafeShopManager.GetTips();
		UpdateValueSubTotal();
		UpdateValueSummary();
	}

	private void UpdateValueDeposits()
	{
		labelValueDeposit.text = CafeShopManager.GetDepositTurnOver().ToString();
		UpdateValueSubTotal();
		UpdateValueSummary();
	}

	private void UpdateValueSubTotal()
	{
		labelValueSubtotal.text = CafeShopManager.GetTurnoverSubtotal().ToString();
	}

	private void UpdateValueTotalExpenses()
	{
		labelValueUpkeep.text = CafeShopManager.GetDailyUpkeep().ToString();
		UpdateValueSummary();
	}

	private void UpdateValueSummary()
	{
		labelValueTurnoverSummary.text = CafeShopManager.GetTurnoverSummary();
	}

	private void UpdateDailyExpenses()
	{
		lightCosts = 0;
		otherCosts = 0;
		List<UpkeepComponent> upkeepComponents = CafeShopManager.GetUpkeepComponents();
		for (int i = 0; i < upkeepComponents.Count; i++)
		{
			if ((bool)upkeepComponents[i].GetComponent<LampComponent>())
			{
				lightCosts += upkeepComponents[i].ampunt;
			}
			else
			{
				otherCosts += upkeepComponents[i].ampunt;
			}
		}
		UpdateValueLights(lightCosts);
		UpdateValueOthers(otherCosts);
	}

	private void UpdateTitleRent()
	{
		labelTitleRent.text = LocalizationManager.GetLocalizedString("com_finance_label_rent", LocalizationDataTable.Tables.ComputerElements) + " (" + ShopBuilder.GetRoomCount() + ")";
	}

	private void UpdateValueRent(int value)
	{
		labelValueRent.text = value.ToString();
	}

	private void UpdateValueLights(int value)
	{
		labelValueLights.text = value.ToString();
	}

	private void UpdateValueOthers(int value)
	{
		labelValueOthers.text = value.ToString();
	}

	private void UpdateValueExtensions(int value)
	{
		labelValueExtensionExpenses.text = value.ToString();
	}
}
