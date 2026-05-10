using Photon.Pun;

public class NetworkMarketShoppingCart : MonoBehaviourPunCallbacks
{
	private PhotonView m_PhotonView;

	private MarketShoppingCart m_MarketShoppingCart;

	public PhotonView PhotonView => null;

	public MarketShoppingCart MarketShoppingCart => null;

	private void Start()
	{
	}

	private void SyncMarketShoppingCartState_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncMarketShoppingCartState_RPC(string cartDataJson)
	{
	}

	public void AskSync_Broadcast()
	{
	}

	[PunRPC]
	public void AskSync_RPC(string newPlayerUserId)
	{
	}

	public void TryAddProduct_Request(ItemQuantity salesItem, SalesType salesType)
	{
	}

	[PunRPC]
	public void TryAddProduct_RPC(int[] _productIDs, int[] _productCounts, int _salesTyp)
	{
	}

	[PunRPC]
	public void TryAddProductFailed_RPC()
	{
	}

	public void AddProduct_Broadcast(ItemQuantity salesItem, SalesType salesType)
	{
	}

	[PunRPC]
	public void AddProduct_RPC(int[] _productIDs, int[] _productCounts, float[] _productPrices, int _salesTyp)
	{
	}

	public void RemoveProductFromCart_Request(ItemQuantity productData, SalesType salesType)
	{
	}

	[PunRPC]
	public void RemoveProductFromCart_Response(int[] _productIDs, int[] _productCounts, int _salesTyp)
	{
	}

	public void RemoveProductFromCart_Broadcast(ItemQuantity productData, SalesType salesType)
	{
	}

	[PunRPC]
	public void RemoveProductsFromCart_RPC(int[] _productIDs, int[] _productCounts, int _salesTyp)
	{
	}

	public void OnItemCountChanged_Broadcast(int amount, int carItemIndex)
	{
	}

	[PunRPC]
	public void OnItemCountChanged_RPC(int amount, int carItemIndex)
	{
	}

	public void OnItemCountChangedWithID_Broadcast(int amount, int cartItemId)
	{
	}

	[PunRPC]
	public void OnItemCountChangedWithID_RPC(int amount, int cartItemId)
	{
	}

	public void Purchase_Request(bool fromTablet)
	{
	}

	[PunRPC]
	public void Purchase_Response(bool fromTablet)
	{
	}

	public void Purchase_Broadcast(bool fromTablet)
	{
	}

	[PunRPC]
	public void Purchase_RPC(bool fromTablet)
	{
	}
}
