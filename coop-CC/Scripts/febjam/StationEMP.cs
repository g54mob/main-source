using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class StationEMP : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float radius;

	[Server]
	public void ServerPrevented(Vector3 preventPosition)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StationEMP::ServerPrevented(UnityEngine.Vector3)' called when server was not active");
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
