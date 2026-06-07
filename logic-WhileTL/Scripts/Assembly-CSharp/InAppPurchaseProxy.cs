using Unity.Components.Events;
using UnityEngine;

public class InAppPurchaseProxy : ActiveComponent
{
	public static InAppPurchaseProxy Instance;

	public const string PACK_ID = "com.nival.wtlm.unlock";

	public WeakEvent PurchaseStarted = new WeakEvent();

	public WeakEvent<int> PurchaseEnded = new WeakEvent<int>();

	public WeakEvent PurchaseTimeout = new WeakEvent();

	private IIAP IAP;

	private bool _isInProgressBuy;

	private bool _isInProgressCheckPrice;

	private float _lastTimeStartedBuy;

	private float _lastTimeStartedCheckPrice;

	private bool _timeoutedCheckPrice;

	private const float _timeoutBuy = 15f;

	private float _timeoutCheckPrice = 15f;

	private void TryInterruptByTimeoutBuy()
	{
		SetInProgress(value: false);
		PurchaseTimeout.Invoke();
	}

	private void SetInProgress(bool value)
	{
	}

	public void OnPurchaseOk(string sku)
	{
		Logic.AddPack(sku);
		PurchaseEnded.Invoke(1);
		SetInProgress(value: false);
	}

	public void OnPurchaseFailed(string sku)
	{
		PurchaseEnded.Invoke(0);
		SetInProgress(value: false);
	}

	public void OnPurchaseNotPossible(string sku)
	{
		PurchaseEnded.Invoke(-1);
		SetInProgress(value: false);
	}

	public void Awake()
	{
		Object.Destroy(base.gameObject);
	}

	private void RetryInit()
	{
		if (IAP != null && !IAP.IsInited())
		{
			IAP.Init(this);
			Invoke("RetryInit", 5f);
		}
	}

	public string GetPackPrice()
	{
		if (!_isInProgressCheckPrice)
		{
			_lastTimeStartedCheckPrice = Time.time;
			_isInProgressCheckPrice = true;
			_timeoutedCheckPrice = false;
		}
		if (IAP != null)
		{
			string priceString = IAP.GetPriceString("com.nival.wtlm.unlock");
			if (priceString != "LOADING")
			{
				_isInProgressCheckPrice = false;
				_timeoutedCheckPrice = false;
			}
			if (_timeoutedCheckPrice)
			{
				return "TIMEOUT";
			}
			return priceString;
		}
		return "LOADING";
	}

	public void BuyPack()
	{
		if (!_isInProgressBuy)
		{
			PurchaseStarted.Invoke();
			if (Debug.isDebugBuild)
			{
				OnPurchaseOk("com.nival.wtlm.unlock");
			}
			else if (IAP != null)
			{
				SetInProgress(value: true);
				IAP.Buy("com.nival.wtlm.unlock");
				Invoke("TryInterruptByTimeout", 15f);
			}
		}
	}

	private void TryInterruptByTimeoutCheckPrice()
	{
		_timeoutedCheckPrice = true;
	}

	private void FixedUpdate()
	{
		if (_isInProgressBuy && Time.time - _lastTimeStartedBuy > 15f)
		{
			TryInterruptByTimeoutBuy();
		}
		if (_isInProgressCheckPrice && Time.time - _lastTimeStartedCheckPrice > _timeoutCheckPrice)
		{
			TryInterruptByTimeoutCheckPrice();
		}
	}

	public void Restore()
	{
		if (IAP != null)
		{
			IAP.Restore();
		}
	}
}
