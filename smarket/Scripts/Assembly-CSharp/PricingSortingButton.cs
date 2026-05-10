using UnityEngine;

public class PricingSortingButton : MonoBehaviour
{
	[SerializeField]
	private GameObject m_CurrentCostUpArrow;

	[SerializeField]
	private GameObject m_CurrentCostDownArrow;

	public PricingSortingType pricingSortingType;

	private PricingSortingState m_pricingSortingState;

	[SerializeField]
	private PricingProductViewer m_productViewer;

	private void Start()
	{
	}

	public void ArrowReset()
	{
	}

	public void OnSortButton()
	{
	}
}
