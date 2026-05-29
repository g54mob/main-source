using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class RuntimeTransformSyncSetup : MonoBehaviourPun
{
	public void SetupLiteFromAnyone(bool pos = true, bool rot = true, bool scl = true, int insertIndex = 0, bool makeMasterOwner = true)
	{
	}

	[PunRPC]
	private void RequestSetupFromMaster_RPC(bool pos, bool rot, bool scl, int insertIndex, bool makeMasterOwner)
	{
	}

	[PunRPC]
	private void SetupLite_RPC(bool pos, bool rot, bool scl, int insertIndex)
	{
	}

	private void MakeMasterOwner()
	{
	}
}
