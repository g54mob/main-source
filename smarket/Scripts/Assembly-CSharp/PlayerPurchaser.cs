using Photon.Pun;
using UnityEngine;

public class PlayerPurchaser : MonoBehaviour, IPurchaser
{
	public float Money => 0f;

	public void Spend(float cost)
	{
	}

	private void ApplyTransaction(float cost)
	{
	}

	[PunRPC]
	public void RequestPurhcase_RPC(float cost)
	{
	}
}
