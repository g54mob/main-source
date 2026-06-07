using System.Collections.Generic;
using UnityEngine;

public class PriceChangeNotification : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup m_NotificationWindow;

	[SerializeField]
	private DynamicPriceProduct m_FirstProduct;

	[SerializeField]
	private Transform m_Content;

	[Header("Animation")]
	[SerializeField]
	private float m_FadeInDuration;

	[SerializeField]
	private float m_WindowLifetime;

	[SerializeField]
	private float m_FadeOutDuration;

	private PriceManager m_PriceManager;

	private List<DynamicPriceProduct> m_DynamicPriceProducts;

	private void Start()
	{
	}

	private void ShowNotification(List<int> products)
	{
	}

	private void ClearPreviousProducts()
	{
	}

	private void OnPriceManagerDisabled()
	{
	}
}
