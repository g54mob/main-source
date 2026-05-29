using Photon.Pun;

public class NetworkPlayerAnimation : MonoBehaviourPun
{
	private PlayerInstance m_PlayerInstance;

	private PlayerInstance PlayerInstance => null;

	public void SetCleaningRigState_Broadcast(PlayerAnimation.CleaningState state)
	{
	}

	[PunRPC]
	public void SetCleaningRig_RPC(PlayerAnimation.CleaningState state)
	{
	}

	public void ToggleCarrying_Broadcast(bool value)
	{
	}

	[PunRPC]
	public void ToggleCarrying_RPC(bool value)
	{
	}
}
