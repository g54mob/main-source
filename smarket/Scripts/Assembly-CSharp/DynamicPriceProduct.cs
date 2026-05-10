using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DynamicPriceProduct : MonoBehaviour
{
	[SerializeField]
	private TMP_Text m_ProductName;

	[SerializeField]
	private Image m_IndicatorIcon;

	[Space]
	[SerializeField]
	private Sprite m_IncreasedPriceIcon;

	[SerializeField]
	private Sprite m_DecreasedPriceIcon;

	[SerializeField]
	private Color m_IncreasedPriceColor;

	[SerializeField]
	private Color m_DecreasedPriceColor;

	public float FontSize => 0f;

	public void Setup(string productName, bool increased)
	{
	}
}
