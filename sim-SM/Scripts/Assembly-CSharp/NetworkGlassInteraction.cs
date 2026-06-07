using Photon.Pun;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkGlassInteraction : NetworkInteraction
{
	private GlassInteraction _glassInteraction;

	public GlassInteraction GlassInteraction => null;

	protected override void Initialize()
	{
	}

	private void SyncSpongeState_Broadcast(string newPlayerUserID)
	{
	}

	[PunRPC]
	public void SyncSpongeBatState_RPC()
	{
	}

	public void DisableSponge_Broadcast()
	{
	}

	[PunRPC]
	public void DisableSponge_RPC()
	{
	}
}
