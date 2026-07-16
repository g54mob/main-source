using TMPro;
using UnityEngine;

public class ProductPricingSizeSlot : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelSize;

	[SerializeField]
	private TMP_Text labelPrice;

	public void UpdatePrice(int size, float price)
	{
		labelSize.text = Product.GetLocalizedSize(size).ToString();
		labelPrice.text = price.ToString();
		base.name = "SubBody " + labelSize.text;
	}
}
