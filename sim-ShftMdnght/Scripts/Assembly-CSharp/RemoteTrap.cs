using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class RemoteTrap : NetworkBehaviour
{
	public UnityEvent pressEvent;

	public GameObject instantiateObj;

	private bool alreadyPressed;

	public void Press()
	{
		if (base.isServer)
		{
			PressRpc();
		}
		else
		{
			PressCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void PressCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void RemoteTrap::PressCmd()", -2068194337, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void PressRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void RemoteTrap::PressRpc()", 1014695052, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Explosion(float explosionRadius)
	{
		ClientPlayer.Instance.playerMan.camShake.intensity = 0.6f;
		Hittable[] array = Object.FindObjectsOfType<Hittable>();
		foreach (Hittable hittable in array)
		{
			if (Vector3.Distance(hittable.transform.position, base.transform.position) < explosionRadius)
			{
				hittable.Hit(1200f, base.transform.position, alwaysTriggerDamageReaction: true);
			}
		}
		if (Vector3.Distance(ClientPlayer.Instance.transform.position, base.transform.position) < explosionRadius - 3.5f)
		{
			ClientPlayer.Instance.playerMan.TakeDamage(100f, significantAnim: true);
		}
		else if (Vector3.Distance(ClientPlayer.Instance.transform.position, base.transform.position) < explosionRadius)
		{
			ClientPlayer.Instance.playerMan.TakeDamage(45f, significantAnim: true);
		}
	}

	public void DestroyAfterTime(float time)
	{
		Object.Destroy(base.gameObject, time);
	}

	public void InstantiateObj()
	{
		Object.Instantiate(instantiateObj, base.transform.position, Quaternion.identity);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_PressCmd()
	{
		PressRpc();
	}

	protected static void InvokeUserCode_PressCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PressCmd called on client.");
		}
		else
		{
			((RemoteTrap)obj).UserCode_PressCmd();
		}
	}

	protected void UserCode_PressRpc()
	{
		if (!alreadyPressed)
		{
			pressEvent.Invoke();
			alreadyPressed = true;
		}
	}

	protected static void InvokeUserCode_PressRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PressRpc called on server.");
		}
		else
		{
			((RemoteTrap)obj).UserCode_PressRpc();
		}
	}

	static RemoteTrap()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(RemoteTrap), "System.Void RemoteTrap::PressCmd()", InvokeUserCode_PressCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(RemoteTrap), "System.Void RemoteTrap::PressRpc()", InvokeUserCode_PressRpc);
	}
}
