using System;
using Photon.Pun;
using UnityEngine;

public class NetworkIceCreamStand : MonoBehaviour, IPunInstantiateMagicCallback
{
	[Serializable]
	public struct SyncState
	{
		public int[] ConeCounts;

		public int[] FlavourIds;

		public int[] RemainingFlavours;

		public bool IsActive;

		public int EmployeeId;
	}

	private PhotonView m_PhotonView;

	private IceCreamStand m_Stand;

	public PhotonView PhotonView => null;

	public IceCreamStand Stand => null;

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSyncState(string userId)
	{
	}

	private SyncState CreateSyncState()
	{
		return default(SyncState);
	}

	public void RequestSync_Others(SyncState syncState)
	{
	}

	[PunRPC]
	private void ApplySyncState_RPC(string jsonData)
	{
	}

	public void UpdateActive_Others(bool value)
	{
	}

	[PunRPC]
	private void UpdateActive_RPC(bool value)
	{
	}

	public void InteractStand_Request()
	{
	}

	[PunRPC]
	public void InteractStand_Response(string userId)
	{
	}

	public void InteractStand_Master()
	{
	}

	[PunRPC]
	public void InteractStand_Rejected()
	{
	}

	[PunRPC]
	public void InteractStand_Broadcast(string userId, IceCreamRequest request)
	{
	}

	[PunRPC]
	public void StartStandPlacingMode_Broadcast(string userId)
	{
	}

	[PunRPC]
	public void StartStandPlacingMode_RPC(string userId)
	{
	}

	public void StartStandPlacingMode_Request(string userId)
	{
	}

	public void ForceCompleteQueue_Master()
	{
	}

	[PunRPC]
	private void ForceCompleteQueue_RPC()
	{
	}

	public void AssignHelper_Broadcst(IceCreamHelper iceCreamHelper)
	{
	}

	[PunRPC]
	public void AddIceCreamHelper_RPC(int viewId)
	{
	}

	public void ToggleWarning_Others(bool value)
	{
	}

	[PunRPC]
	private void ToggleWarning_RPC(bool value)
	{
	}

	public void UpdateRequestTexture_Target(string userId, IceCreamRequest request)
	{
	}

	[PunRPC]
	private void UpdateRequestTexture_RPC(IceCreamRequest request)
	{
	}

	public void DiscardController_Broadcast()
	{
	}

	[PunRPC]
	private void DiscardController_RPC()
	{
	}

	public void ToggleEmployeeVisibility_Broadcast(bool value)
	{
	}

	[PunRPC]
	private void ToggleEmployeeVisibility_RPC(bool value)
	{
	}
}
