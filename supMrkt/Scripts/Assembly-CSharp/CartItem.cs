using UnityEngine;
using UnityEngine.UI;

public class CartItem : SalesUIElement
{
	private MarketShoppingCart m_ShoppingCart;

	[SerializeField]
	private Image m_ItemVisual;

	public int ProductID => 0;

	public ItemQuantity SalesItem => null;

	private void Start()
	{
	}

	public void Setup(ItemQuantity salesItemData, MarketShoppingCart shoppingCart, SalesType salesType)
	{
	}

	public void Setup(ItemQuantity salesItemData, MarketShoppingCart shoppingCart, SalesType salesType, Sprite itemTexture)
	{
	}

	public void Setup(ItemQuantity salesItemData, MarketShoppingCart shoppingCart, SalesType salesType, Color itemColor)
	{
	}

	public new void OnItemCountChangedByButtons(int amount)
	{
	}

	public void OnItemCountChangedByButtonsNetwork(int amount)
	{
	}

	public void SetItemCountNetwork(int amount)
	{
	}

	public void OnItemCountChangedSingle(string input)
	{
	}

	public override void OnItemCountChangedByInput(string input)
	{
	}

	public void RemoveProductFromCart()
	{
	}

	public void UpdateUnitPrice()
	{
	}
}
