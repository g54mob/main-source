using System;
using CTS;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using TMPro;
using UnityEngine;

public class UI_ConstructionFacture : MonoSingleton<UI_ConstructionFacture>
{
	[SerializeField]
	private TMP_Text _totalPrice;

	[SerializeField]
	private TMP_Text _failText;

	[SerializeField]
	[ReadOnly]
	private int _currentPriceToPay;

	public static event Func<int, int> BuyingConstruction;

	protected override void SingletonAwake()
	{
		ConstructionSystem.OnBuyingDataChanged += UpdateFacture;
		ConstructionSystem.BuyGeneratedCells += Buy;
		SurfaceObjectPaintingSystem.OnBuyPaint += Buy;
	}

	protected override void OnSingletonDestroy()
	{
		ConstructionSystem.OnBuyingDataChanged -= UpdateFacture;
		ConstructionSystem.BuyGeneratedCells -= Buy;
		SurfaceObjectPaintingSystem.OnBuyPaint -= Buy;
	}

	private void Buy()
	{
		if (_currentPriceToPay > 0)
		{
			MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Expense, Mathf.Abs(_currentPriceToPay), TransactionTag.Renovation);
		}
		else
		{
			MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, -_currentPriceToPay, TransactionTag.OtherSale);
		}
		UI_ConstructionFacture.BuyingConstruction(-_currentPriceToPay);
		_currentPriceToPay = 0;
		UpdateShellPanelShowed();
	}

	public void UpdateFacture(int currentCost)
	{
		_currentPriceToPay = currentCost + MonoSingleton<SurfaceObjectPaintingSystem>.Instance.CurrentCost;
		_totalPrice.text = MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetToMoneyStringFormat(_currentPriceToPay);
		UpdateShellPanelShowed();
	}

	public void UpdateFacture(BuyingData cellBuyingData, BuyingData pricesData)
	{
		_currentPriceToPay = cellBuyingData.WallsToBuild * pricesData.WallsToBuild + cellBuyingData.FloorsToBuild * pricesData.FloorsToBuild + cellBuyingData.WallsToDestroy * pricesData.WallsToDestroy + cellBuyingData.FloorsToDestroy * pricesData.FloorsToDestroy + MonoSingleton<SurfaceObjectPaintingSystem>.Instance.CurrentCost;
		_totalPrice.text = MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetToMoneyStringFormat(_currentPriceToPay);
		UpdateShellPanelShowed();
	}

	private void UpdateShellPanelShowed()
	{
		if (_currentPriceToPay == 0)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
