using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class UnlockShopPaymentUI : MonoBehaviour
{
	[SerializeField]
	private Image _iconImage;

	[SerializeField]
	private LocalizeStringEvent _localizedStringEvent;

	[SerializeField]
	private StandingPaymentUI _paymentUI;

	public void Set(UnlockShopPurchaseAttempt shopPurchaseAttempt)
	{
	}

	public void Hide()
	{
	}

	public void Clear()
	{
	}
}
