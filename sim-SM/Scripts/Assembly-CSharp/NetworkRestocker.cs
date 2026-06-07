using Photon.Pun;
using UnityEngine.AI;
using Workbench.Wolfsbane.Multiplayer;

public class NetworkRestocker : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
	private PhotonView m_PhotonView;

	private Restocker m_Restocker;

	private NetworkedAnimation m_NetworkedAnimation;

	private NavMeshAgent m_NavMeshAgent;

	public PhotonView PhotonView => null;

	public int ViewId => 0;

	public Restocker Restocker => null;

	public NetworkedAnimation NetworkedAnimation => null;

	public NavMeshAgent NavMeshAgent => null;

	private void Start()
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	private void OnSyncRequest(string userID)
	{
	}

	[PunRPC]
	public void SyncRestockerData_RPC(bool isCarrying, int currentBoxViewId, float boostAmount)
	{
	}

	public void PickupAnimation(bool value)
	{
	}

	public void DropBoxToGround_Broadcast(Box box)
	{
	}

	[PunRPC]
	public void DropBoxToGround_RPC(int boxViewId)
	{
	}

	public void PickupGround_Broadcast(Box box)
	{
	}

	[PunRPC]
	public void PickupGround_RPC(int boxPhotonViewId)
	{
	}

	public void PickupRack_Broadcast(RackSlot targetRackSlot, Box box)
	{
	}

	[PunRPC]
	public void PickupRack_RPC(int rackViewId, int rackSlotIndex, int boxViewId)
	{
	}

	public void PlaceBox_Broadcast(RackSlot targetRackSlot, Box box)
	{
	}

	[PunRPC]
	public void PlaceBox_RPC(int rackViewId, int rackSlotIndex, int boxViewId)
	{
	}

	public void PlaceProducts_Broadcast(DisplaySlot displaySlot, Box box, int productId)
	{
	}

	[PunRPC]
	public void PlaceProduct_RPC(int displayViewId, int displaySlotIndex, int boxViewId, int productId)
	{
	}

	public void Boost_Broadcast()
	{
	}

	[PunRPC]
	public void BoostRestocker_RPC()
	{
	}
}
