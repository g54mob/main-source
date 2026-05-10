using Photon.Pun;
using UnityEngine;

public class PlayerSkinNetwork : MonoBehaviourPun
{
	[SerializeField]
	private PlayerSkinController m_SkinController;

	public void SetSkinIndex_Broadcast(int index)
	{
	}

	[PunRPC]
	public void SetSkinIndex_RPC(int index)
	{
	}
}
