using System;
using I2.Loc;
using TMPro;
using UnityEngine;

public class StockSellOfferItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[SerializeField]
	private TextMeshProUGUI companyNameText;

	[SerializeField]
	private TextMeshProUGUI quantityText;

	[SerializeField]
	private TextMeshProUGUI priceText;

	[SerializeField]
	private TextMeshProUGUI totalPriceText;

	[SerializeField]
	private GameObject inspectObject;

	private StockDemandData _offer;

	private Action<StockDemandData> _onInspectCallback;

	private Func<string, int> _getStockCountFunc;

	public StockDemandData Offer => _offer;

	public void Initialize(StockDemandData offer, Action<StockDemandData> onInspect = null, Func<string, int> getStockCount = null)
	{
		_offer = offer;
		_onInspectCallback = onInspect;
		_getStockCountFunc = getStockCount;
		UpdateUI();
	}

	public void UpdateOffer(StockDemandData updatedOffer)
	{
		_offer = updatedOffer;
		UpdateUI();
		Debug.Log($"[StockSellOfferItemUI] UpdateOffer - NewAmount: {_offer.demandedAmount}");
	}

	public void UpdateUI()
	{
		if (_offer.IsValid)
		{
			if (companyNameText != null)
			{
				companyNameText.text = _offer.companyName;
			}
			if (quantityText != null)
			{
				quantityText.text = $"x{_offer.demandedAmount}";
			}
			if (priceText != null)
			{
				priceText.text = $"{_offer.pricePerUnit:N0}";
			}
			if (totalPriceText != null)
			{
				totalPriceText.text = $"{_offer.TotalPrice:N0}";
			}
			UpdateInspectButtonState();
		}
	}

	public void UpdateInspectButtonState()
	{
		if (!(inspectObject == null))
		{
			inspectObject.SetActive(value: true);
		}
	}

	public void OnInspectButtonClicked()
	{
		if ((_getStockCountFunc?.Invoke(_offer.itemId) ?? 0) < 5)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_StocksellWarningLowStock"), isComputer: true);
			}
		}
		else
		{
			_onInspectCallback?.Invoke(_offer);
		}
	}
}
