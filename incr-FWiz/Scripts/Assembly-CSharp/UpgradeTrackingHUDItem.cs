using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class UpgradeTrackingHUDItem : TrackingHUDItem
{
	[SerializeField]
	private Image _upgradeIcon;

	[SerializeField]
	private StandingPaymentUI _standingPaymentUI;

	[SerializeField]
	private LocalizeStringEvent _titleEvent;

	[SerializeField]
	private TextMeshProUGUI _levelText;

	[SerializeField]
	private LocalizedString _levelLocalizedString;

	private UpgradeAttempt _currentUpgradeAttempt;

	private PaymentGroup _paymentGroup;

	[SerializeField]
	private UpgradeTooltipTrigger _tooltipTrigger;

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

	private void OnLevelStringChanged(string value)
	{
	}

	public override void OnWipe()
	{
	}
}
