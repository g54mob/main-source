using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class NetworkNPCTransformView : MonoBehaviourPunCallbacks
{
	private NavMeshAgent m_NavmeshAgent;

	private PhotonView m_PhotonView;

	private NPC m_NPC;

	public PhotonView PhotonView => null;

	public NavMeshAgent NavmeshAgent => null;

	public NPC NPC => null;

	private new void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSyncRequest(string userID)
	{
	}

	private void Start()
	{
	}

	private void SyncNPC_Broadcast()
	{
	}

	[PunRPC]
	private void SyncNPC_RPC(Vector3 currentPos, Vector3 targetPos)
	{
	}

	public void MoveToDestination_Broadcast(Vector3 currentPosition, Vector3 target)
	{
	}

	[PunRPC]
	public void MoveToDestination_RPC(Vector3 currentMasterPosition, Vector3 target)
	{
	}
}
