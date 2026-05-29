using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkCrateInteraction : NetworkInteraction
{
	private new PlayerInstance m_PlayerInstance;

	private PhotonView m_PhotonView;

	private CrateInteraction m_CrateInteraction;

	public PhotonView PhotonView => null;

	public PlayerInstance PlayerInstance => null;

	public CrateInteraction CrateInteraction => null;

	protected override void Initialize()
	{
	}

	private void SyncCrateInteraction_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncCrateInteraction_RPC(int[] productViewIds, int[] productIds, bool isCrateEnabled)
	{
	}

	public void TakeProduct_Broadcast(Product product)
	{
	}

	[PunRPC]
	public void TakeProduct_RPC(int productViewId)
	{
	}

	public void SpreadSingleProduct_Broadcast()
	{
	}

	[PunRPC]
	public void SpreadSingleProduct_RPC()
	{
	}

	public void SpreadAllproduct_Broadcast()
	{
	}

	[PunRPC]
	public void SpreadAllproduct_RPC()
	{
	}

	public Product TakeProductFromDisplay_Broadcast(Product product, DisplaySlot displaySlot)
	{
		return null;
	}

	[PunRPC]
	public void TakeProductFromDisplay_RPC(int productID, int productViewId, int displayViewId, int displaySlotIndex)
	{
	}

	public Product TakeProductFromVending_Broadcast(Product product, VendingSlot vendingSlot)
	{
		return null;
	}

	[PunRPC]
	public void TakeProductFromVending_RPC(int productID, int productViewId, int vendingViewId, int vendingSlotIndex)
	{
	}

	public void AddProductToDisplay_Broadcast(Product product, int displayViewID, int displaySlotIndex)
	{
	}

	[PunRPC]
	public void AddProductToDisplay_RPC(int productID, Vector3 productPosition, Quaternion productRotation, int displayViewID, int displaySlotIndex)
	{
	}

	public void AddProductToVending_Broadcast(Product product, int vendingViewID, int vendingSlotIndex)
	{
	}

	[PunRPC]
	public void AddProductToVending_RPC(int productID, Vector3 productPosition, Quaternion productRotation, int vendingViewID, int vendingSlotIndex)
	{
	}

	public void DisableCrate_Broadcast()
	{
	}

	[PunRPC]
	public void DisableCrate_RPC()
	{
	}

	public void DisableFakeCrateProduct()
	{
	}

	public void EnableFakeCrateProduct()
	{
	}
}
