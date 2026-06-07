using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class NetworkVehicleSpecterMode : MonoBehaviour
{
	[SerializeField]
	private CinemachineVirtualCamera m_VirtualCamera;

	[SerializeField]
	private List<Transform> m_Seats;

	private Rigidbody m_Rb;

	private PhotonView m_PhotonView;

	private NetworkVehicle m_NetworkVehicle;

	public int PassangerCount;

	public PhotonView PhotonView => null;

	private void Start()
	{
	}

	public PlayerInstance GetInstanceFromSeat(int seatIndex)
	{
		return null;
	}

	public int GetFreeSeat()
	{
		return 0;
	}

	public void EnterSpecterMode_Broadcast()
	{
	}

	[PunRPC]
	public void EnterSpecterMode_RPC(string userID)
	{
	}

	public void ExitSpecterMode_Broadcast()
	{
	}

	[PunRPC]
	public void ExitSpecterMode_RPC(string userID)
	{
	}
}
