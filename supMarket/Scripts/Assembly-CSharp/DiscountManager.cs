using MyBox;
using UnityEngine;

public class DiscountManager : Singleton<DiscountManager>
{
	[Header("References")]
	public GameObject discountPanel;

	private RectTransform panelRect;

	private GameObject m_SpawnedPanel;

	private Pricing m_pricingData;

	public PricingItem CurrentPricingItem;

	public Pricing PricingData
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public GameObject SpawnedPanel => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void OpenPanel(RectTransform buttonRect)
	{
	}

	private void UpdatePanelPosition(RectTransform targetRect)
	{
	}

	public void SetDiscount(Pricing pricingData, int percentage)
	{
	}

	public void ClosePanel()
	{
	}

	private bool IsPointerOverUIObject(RectTransform rectTransform)
	{
		return false;
	}
}
