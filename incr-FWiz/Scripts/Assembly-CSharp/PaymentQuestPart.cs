using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class PaymentQuestPart : QuestPart
{
	public List<CostStack> Costs;

	public PaymentGroup Payment;

	public QuestPaymentInterface QuestPaymentInterface;

	public LocalizedString QuestPartTitle;

	public Sprite QuestPartIcon;

	public override void ActivateQuestPart()
	{
	}

	public override void ApplyFreshCompletedEffects()
	{
	}

	private void OnEnable()
	{
	}

	public PaymentGroup GetPayment()
	{
		return null;
	}

	private void OnDisable()
	{
	}
}
