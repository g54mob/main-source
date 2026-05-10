using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

public class OrderTimeDisplay : MonoBehaviour
{
	private const float k_YellowWarningDuration = 240f;

	private const float k_RedWarningDuration = 120f;

	private float m_DayEndTime;

	private OrderListData m_Order;

	[SerializeField]
	private TMP_Text m_Text;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedString;

	private object[] m_StringArgs;

	[Header("State Colors")]
	[SerializeField]
	private Color m_DefaultStateColor;

	[SerializeField]
	private Color m_YellowStateColor;

	[SerializeField]
	private Color m_RedStateColor;

	public void SetOrderData(OrderListData order)
	{
	}

	private void Update()
	{
	}

	private void ApplyColor(float timeDiff)
	{
	}
}
