using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkFurnitureBoxInteraction : NetworkInteraction
{
	private FurnitureBoxInteraction FurnitureBoxInteraction;

	protected override void Initialize()
	{
	}

	private void SyncBoxState_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncFurnitureBoxState_RPC(string newPlayerUserId, string senderUserId, int boxViewId)
	{
	}

	public void ThrowBoxInstant_Broadcast()
	{
	}

	public void ThrowBox_Broadcast()
	{
	}

	[PunRPC]
	public void ThrowFurnitureBox_RPC()
	{
	}

	public void DropFurnitureBox_Broadcast()
	{
	}

	[PunRPC]
	public void DropFurnitureBox_RPC(string userID, Vector3 playSoundPosition)
	{
	}

	public void OpenFurnitureBox_Broadcast()
	{
	}

	public void OpenFurnitureBoxRequest()
	{
	}

	[PunRPC]
	public void OpenFurnitureBoxRequest_RPC()
	{
	}

	public void ThrowIntoTrashBin_Broadcast()
	{
	}

	[PunRPC]
	public void FurnitureBoxThrowIntoTrashBin_RPC(string userID)
	{
	}

	public void SellFurnitureBox_Broadcast()
	{
	}

	[PunRPC]
	public void SellFurnitureBox_RPC()
	{
	}

	public void SyncVendingMachineData_Broadcast(Player sender, int vendingMachineViewID)
	{
	}

	[PunRPC]
	public void SyncVendingMachineData_RPC(Player sender, int vendingMachineViewID)
	{
	}

	[PunRPC]
	public void SyncVendingMachineData(int vendingMachineViewID, string json)
	{
	}
}
