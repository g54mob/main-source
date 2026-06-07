using Extensions;
using Mirror;
using UnityEngine;

public class MoneyPipe : NetworkBehaviour
{
	[SerializeField]
	private Transform pipeSuckTransform;

	[Server]
	public void ServerStartSucking()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MoneyPipe::ServerStartSucking()' called when server was not active");
			return;
		}
		foreach (DebtBag debtBag in NetworkSingleton<WinSceneManager>.Instance.debtBags)
		{
			debtBag.ServerSuckToPipe(pipeSuckTransform.position, pipeSuckTransform.up);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
