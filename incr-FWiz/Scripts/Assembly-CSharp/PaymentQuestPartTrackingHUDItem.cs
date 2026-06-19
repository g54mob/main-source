using UnityEngine;
using UnityEngine.UI;

public class PaymentQuestPartTrackingHUDItem : TrackingHUDItem
{
	[SerializeField]
	private Image _iconImage;

	[SerializeField]
	private StandingPaymentUI _standingPaymentUI;

	private PaymentQuestPart _currentQuest;

	private PaymentGroup _paymentGroup;

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

	public void OnEnd(UpgradeStation u)
	{
	}

	public void OnEnd()
	{
	}

	public override void OnWipe()
	{
	}
}
