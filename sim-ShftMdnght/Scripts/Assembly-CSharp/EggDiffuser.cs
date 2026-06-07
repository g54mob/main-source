using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class EggDiffuser : NetworkBehaviour
{
	public GameObject funnelCover;

	public Outline outline;

	public GameObject pulverizeVfx;

	public AudioSource[] pulverizeSfx;

	public GameObject dropTooltip;

	public GameObject purchaseTooltip;

	public void TryTurnOnOutline()
	{
		outline.enabled = true;
	}

	public void TurnOffOutline()
	{
		outline.enabled = false;
	}

	public void Egg(GameObject egg)
	{
		if (base.isServer)
		{
			EggRpc(egg);
		}
		else
		{
			EggCmd(egg);
		}
	}

	[Command(requiresAuthority = false)]
	public void EggCmd(GameObject egg)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(egg);
		SendCommandInternal("System.Void EggDiffuser::EggCmd(UnityEngine.GameObject)", 1191229303, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void EggRpc(GameObject egg)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(egg);
		SendRPCInternal("System.Void EggDiffuser::EggRpc(UnityEngine.GameObject)", 1369690424, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void PurchaseHint()
	{
		purchaseTooltip.SetActive(value: true);
		StoreManager.Instance.AddHint("Now purchase a trap from the wall.");
		StoreManager.Instance.NextHint();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_EggCmd__GameObject(GameObject egg)
	{
		EggRpc(egg);
	}

	protected static void InvokeUserCode_EggCmd__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command EggCmd called on client.");
		}
		else
		{
			((EggDiffuser)obj).UserCode_EggCmd__GameObject(reader.ReadGameObject());
		}
	}

	protected void UserCode_EggRpc__GameObject(GameObject egg)
	{
		if (PlayerPrefs.GetInt("PurchasedSomething") != 1)
		{
			Invoke("PurchaseHint", 1f);
		}
		dropTooltip.SetActive(value: false);
		PlayerPrefs.SetInt("Pulverized", 1);
		AudioSource[] array = pulverizeSfx;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
		pulverizeVfx.SetActive(value: false);
		pulverizeVfx.SetActive(value: true);
		Object.Destroy(egg);
		Invoke("FinishEgg", 1f);
		if (!ClientPlayer.Instance.isServer || ClientPlayer.Instance.inventoryMan.hasThrownIntoPulverizerBefore)
		{
			return;
		}
		foreach (PlayerManager playerMan in StoreManager.Instance.playerMans)
		{
			playerMan.inventoryMan.Pulverized();
		}
	}

	protected static void InvokeUserCode_EggRpc__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EggRpc called on server.");
		}
		else
		{
			((EggDiffuser)obj).UserCode_EggRpc__GameObject(reader.ReadGameObject());
		}
	}

	static EggDiffuser()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(EggDiffuser), "System.Void EggDiffuser::EggCmd(UnityEngine.GameObject)", InvokeUserCode_EggCmd__GameObject, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(EggDiffuser), "System.Void EggDiffuser::EggRpc(UnityEngine.GameObject)", InvokeUserCode_EggRpc__GameObject);
	}
}
