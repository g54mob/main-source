using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class FurnitureSalesItem : SalesUIElement
{
	[Header("Sales Item")]
	[SerializeField]
	private Image m_ProductIcon;

	private FurnituresViewer m_ShelvesViewer;

	[SerializeField]
	private int m_ProductId;

	public string ProductName => null;

	public int ProductId
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void Setup(int productID, FurnituresViewer shelvesViewer)
	{
	}

	public void ReSetup(int productID)
	{
	}

	protected override void UpdateLocalizeText(Locale _ = null)
	{
	}

	public void AddToCart()
	{
	}
}
