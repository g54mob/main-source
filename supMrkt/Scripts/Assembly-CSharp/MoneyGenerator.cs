using UnityEngine;

public class MoneyGenerator : NoktaSingleton<MoneyGenerator>
{
	private readonly Vector3 m_PositionOffset;

	private readonly Vector3 m_RotationOffset;

	[SerializeField]
	private MoneyPack m_CustomerPaymentPrefab;

	[SerializeField]
	private GameObject m_CustomerCreditCard;

	[SerializeField]
	private Money[] m_MoneyPrefabs;

	public GameObject SpawnCustomerPayment(Transform rightHand, float value)
	{
		return null;
	}

	public Money SpawnMoney(float value, Transform parent)
	{
		return null;
	}

	public GameObject SpawnCreditCard(Transform rightHand)
	{
		return null;
	}
}
