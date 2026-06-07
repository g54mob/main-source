using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_ItemPrice : MonoBehaviour
{
	[SerializeField]
	private GameObject node_Content;

	[SerializeField]
	private Image image_Gem;

	[SerializeField]
	private TMP_Text text_Free;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private TMP_Text text_DiscountedCost;

	private UI_Obj_ShopCard connectedCard;

	private int currentCost;

	private bool isDiscounted;

	public UI_Obj_ShopCard ConnectedCard => null;

	public void SetConnectedCard(UI_Obj_ShopCard card)
	{
	}

	public void SetPrice(int value, bool isDiscount = false, int discountedValue = 0)
	{
	}

	public void UpdateBuyable(int playerGem)
	{
	}

	public void Toggle(bool isOn)
	{
	}
}
