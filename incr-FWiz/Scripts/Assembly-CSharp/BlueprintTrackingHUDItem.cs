using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class BlueprintTrackingHUDItem : TrackingHUDItem
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private StandingPaymentUI _standingPaymentUI;

	[SerializeField]
	private LocalizeStringEvent _titleEvent;

	private UnlockShopPurchaseAttempt _currentShopAttempt;

	private PaymentGroup _paymentGroup;

	[SerializeField]
	private BuildingTooltipTrigger _tooltipTrigger;

	public override void OnInitiate()
	{
	}

	public void EvaluateProgress()
	{
	}

	public override bool CanHandle(object obj)
	{
		return false;
	}

	public override void Handle(object obj)
	{
	}

	public void OnEnd()
	{
	}

	public override void OnWipe()
	{
	}
}
