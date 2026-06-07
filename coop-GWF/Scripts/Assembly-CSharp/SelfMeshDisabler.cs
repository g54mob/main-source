using Mirror;
using UnityEngine;

public class SelfMeshDisabler : MonoBehaviour
{
	private NetworkIdentity _networkIdentity;

	private void Start()
	{
		_networkIdentity = base.transform.root.GetComponent<NetworkIdentity>();
		if (IsLocalPlayer())
		{
			base.gameObject.layer = LayerMask.NameToLayer("SelfMeshPlayer");
		}
	}

	private bool IsLocalPlayer()
	{
		if (_networkIdentity != null)
		{
			return NetworkClient.localPlayer == _networkIdentity;
		}
		return false;
	}

	public void ToggleMesh(bool enabled)
	{
		if (IsLocalPlayer())
		{
			base.gameObject.layer = (enabled ? LayerMask.NameToLayer("Player") : LayerMask.NameToLayer("SelfMeshPlayer"));
		}
	}
}
