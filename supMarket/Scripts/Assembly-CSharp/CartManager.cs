using Photon.Pun;
using UnityEngine;

public class CartManager : NoktaSingletonPunCallbacks<CartManager>
{
	public MarketShoppingCart MarketShoppingCart;

	[SerializeField]
	private CartData m_CartData;

	public CartData CartData
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnSyncRequest(string userId)
	{
	}

	[PunRPC]
	public void SyncCartData_RPC(string json)
	{
	}

	public void Initialize()
	{
	}

	public void AddCart(ItemQuantity salesItem, SalesType salesType)
	{
	}

	public void ReduceCart(ItemQuantity salesItem, SalesType salesType)
	{
	}
}
