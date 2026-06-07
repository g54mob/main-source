using Photon.Pun;
using UnityEngine;

public class NetworkOven : MonoBehaviour
{
	private PhotonView m_PhotonView;

	private Oven m_Oven;

	public PhotonView PhotonView => null;

	public Oven Oven => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OvenState_Broadcast(string newPlayerUserID)
	{
	}

	[PunRPC]
	private void OvenState_RPC(float bakeTime, bool isDoorOpen)
	{
	}

	public void OpenCloseOvenDoor_Broadcast(bool isOpen)
	{
	}

	[PunRPC]
	public void OpenCloseOvenDoor_RPC(bool isOpen)
	{
	}

	public void Bake_Request()
	{
	}

	[PunRPC]
	private void Bake_Request_RPC(string requestingPlayerUserID)
	{
	}

	[PunRPC]
	private void BakeReject_RPC(int response)
	{
	}

	public void Bake_Broadcast()
	{
	}

	[PunRPC]
	private void Bake_RPC()
	{
	}

	public void AnimateBakeButton_Broadcast()
	{
	}

	[PunRPC]
	private void AnimateBakeButton_RPC()
	{
	}

	public void FinishBake_Broadcast()
	{
	}

	[PunRPC]
	private void FinishBake_RPC()
	{
	}
}
