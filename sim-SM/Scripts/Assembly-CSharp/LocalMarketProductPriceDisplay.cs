using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class LocalMarketProductPriceDisplay : MonoBehaviour
{
	private PurchasableProduct m_Product;

	[SerializeField]
	private Renderer m_IconDisplay;

	[SerializeField]
	private TMP_Text m_NameText;

	[SerializeField]
	private TMP_Text m_ActualPrice;

	[SerializeField]
	private TMP_Text m_DiscountedPrice;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLanguageChanged(Locale obj)
	{
	}

	private void Start()
	{
	}

	private void SetConstantVisuals()
	{
	}

	private void UpdateName()
	{
	}

	private void OnCostsChanged(List<int> obj)
	{
	}

	public void UpdateDisplay()
	{
	}
}
