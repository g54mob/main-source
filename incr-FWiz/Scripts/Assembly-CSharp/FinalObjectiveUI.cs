using UnityEngine;

public class FinalObjectiveUI : MonoBehaviour
{
	[SerializeField]
	private StandingPaymentUI _paymentUI;

	public UIFadeInOnEnable FadeInOnEnable;

	public Vector2 PositionOffset;

	public void Initiate(PaymentGroup paymentGroup, Vector2 position)
	{
	}

	public void Hide()
	{
	}
}
