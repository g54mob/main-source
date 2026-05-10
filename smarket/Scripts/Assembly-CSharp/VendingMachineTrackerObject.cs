using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineTrackerObject : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField m_ItemCountInput;

	[SerializeField]
	private TextMeshProUGUI m_TotalPriceText;

	private float m_TotalPrice;

	private ItemQuantity m_ProductQuantity;

	[SerializeField]
	private Image productImage;

	[SerializeField]
	private TextMeshProUGUI productNameTmp;

	[SerializeField]
	private TextMeshProUGUI productSlotTmp;

	private int m_ProductID;

	public void OnItemCountChangedByButtons(int amount)
	{
	}

	public void IncreaseItemCountGamepad()
	{
	}

	public void DecreaseItemCountGamepad()
	{
	}

	public void UpdateTotalPrice()
	{
	}

	public void AddToCart()
	{
	}

	public void Initialize(int productCount, int collectedSlotCount, ProductSO so)
	{
	}
}
