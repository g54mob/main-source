using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Data;
using __Project__.Scripts.WallPaintSystem;

public class NetworkFurnitureBox : MonoBehaviour, IPunInstantiateMagicCallback
{
	[SerializeField]
	private FurnitureBoxData m_FurnitureBoxData;

	private PhotonView m_PhotonView;

	private FurnitureBox m_FurnitureBox;

	private Rigidbody m_Rigidbody;

	public bool IsNetworkOccupied;

	public int ViewId => 0;

	public PhotonView PhotonView => null;

	public FurnitureBox FurnitureBox => null;

	public Rigidbody Rigidbody => null;

	private void Start()
	{
	}

	private void OnSyncRequest(string UserId)
	{
	}

	private void OnDisable()
	{
	}

	public void PickUPFurnitureBox_Broadcast(PlayerInstance player)
	{
	}

	[PunRPC]
	public void PickUPFurnitureBox_RPC(string userID)
	{
	}

	public void AskAvailability()
	{
	}

	[PunRPC]
	public bool AvailabilityCallback_RPC(string userID)
	{
		return false;
	}

	[PunRPC]
	public void AvailabilityRejected_Response()
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	private void InteractWithIceCreamStand(IceCreamManager.StandBoxData iceCreamStandData, PlayerInstance player)
	{
	}

	private void InteractWithVending(VendingData data, PlayerInstance player)
	{
	}

	private void InteractWithFurnitureBoxDisplay(DisplayData data, PlayerInstance player)
	{
	}

	private void InteractWithFurnitureBoxRack(RackData data, PlayerInstance player)
	{
	}

	private void InteractWithFurnitureBoxScale(PlayerInstance player)
	{
	}

	private void InteractWithFurnitureBoxCheckout(PlayerInstance player)
	{
	}

	private void InteractWithFurnitureBoxFurniture(PlayerInstance player)
	{
	}

	private void InteractWithFurnitureBoxCategorySign(CategorySignData data, PlayerInstance player)
	{
	}

	private void InteractWithFurnitureBoxBucket(BucketData data, PlayerInstance player)
	{
	}
}
