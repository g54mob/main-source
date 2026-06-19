using UnityEngine;

public class QuestPaymentInterface : MonoBehaviour
{
	[HideInInspector]
	public PaymentQuestPart QuestPart;

	public PaymentCollector PaymentCollector;

	public StandingPaymentUI StandingPaymentUI;

	public Transform QuestUITransform;

	private void OnEnable()
	{
	}

	public void Show(PaymentQuestPart questPart)
	{
	}

	public void Clear()
	{
	}

	public void OnFulfill()
	{
	}
}
