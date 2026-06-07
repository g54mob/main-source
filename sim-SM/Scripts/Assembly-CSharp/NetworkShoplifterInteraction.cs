using Photon.Pun;
using __Project__.Scripts.Interaction;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkShoplifterInteraction : NetworkInteraction
{
	private ShoplifterInteraction _shoplifterInteraction;

	public ShoplifterInteraction ShoplifterInteraction => null;

	protected override void Initialize()
	{
	}

	private void SyncBaseballBatState_Broadcast(string newPlayerUserID)
	{
	}

	[PunRPC]
	public void SyncBaseballBatState_RPC()
	{
	}

	public void CustomerRunAway_BroadCast(int viewID)
	{
	}

	[PunRPC]
	public void CustomerRunAway_RPC(int viewID)
	{
	}

	public void PlayHitSfx_Broadcast(int viewID)
	{
	}

	[PunRPC]
	public void PlayHitSfx_RPC(int viewId)
	{
	}

	public void DisableBat_Broadcast()
	{
	}

	[PunRPC]
	public void DisableBat_RPC()
	{
	}
}
