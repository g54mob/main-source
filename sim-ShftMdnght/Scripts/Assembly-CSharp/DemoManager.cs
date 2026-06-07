using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class DemoManager : NetworkBehaviour
{
	public Transform npcSpawnPoint;

	public Transform carSpawnPoint;

	public float[] extraTimeBetweenEvents;

	public UnityEvent[] events;

	public int eventIndex;

	public GameObject storeStats;

	public GameObject truckHolder;

	public GameObject phoneRingingSfx;

	public GameObject eodBus;

	public Transform startPos;

	public GameObject playerDoppelganger;

	public Transform playerDoppelgangerSpawnpoint;

	public Transform[] playerDoppelgangerSpawnpoints;

	public GameObject flickeringLightsEvent;

	public GameObject answerThePhoneCanvas;

	public GameObject rat;

	private void Start()
	{
		storeStats.SetActive(value: true);
		if (base.isServer)
		{
			CancelInvoke("StartNextEvent");
			Invoke("StartNextEvent", 0.5f);
		}
	}

	public void StartNextEvent()
	{
		if (base.isServer)
		{
			Invoke("ActuallyBeginEvent", extraTimeBetweenEvents[eventIndex]);
		}
	}

	private void ActuallyBeginEvent()
	{
		events[eventIndex].Invoke();
		IncreaseEventIndex();
	}

	[ClientRpc]
	private void IncreaseEventIndex()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::IncreaseEventIndex()", 770579645, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnPlayerDoppelganger()
	{
		if (base.isServer)
		{
			NetworkServer.Spawn(Object.Instantiate(playerDoppelganger, playerDoppelgangerSpawnpoint.position, Quaternion.identity));
			Invoke("StartNextEvent", 0.5f);
		}
	}

	public void SpawnPlayerDoppelgangers()
	{
		Invoke("StartNextEvent", 0.5f);
		if (base.isServer)
		{
			for (int i = 0; i < 10; i++)
			{
				NetworkServer.Spawn(Object.Instantiate(playerDoppelganger, playerDoppelgangerSpawnpoints[i].position, Quaternion.identity));
			}
		}
	}

	public void SpawnPurchasesTruck()
	{
		if (PurchaseManager.Instance.purchaseQueue.Count > 0)
		{
			SpawnPurchasesTruckRpc();
		}
		else
		{
			Invoke("StartNextEvent", 0.5f);
		}
	}

	[ClientRpc]
	private void SpawnPurchasesTruckRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::SpawnPurchasesTruckRpc()", -29969586, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SaveEvent()
	{
		if (ClientPlayer.Instance.isServer)
		{
			SaveManager.Instance.Save();
			CancelInvoke("StartNextEvent");
			Invoke("StartNextEvent", 0.5f);
		}
	}

	public void SpawnNPC(GameObject npc_)
	{
		NetworkServer.Spawn(Object.Instantiate(npc_, npcSpawnPoint.position, Quaternion.identity));
	}

	public void SpawnCar(GameObject npc_)
	{
		NetworkServer.Spawn(Object.Instantiate(npc_, carSpawnPoint.position, Quaternion.identity));
	}

	public void SpawnThief(GameObject npc_)
	{
		CancelInvoke("StartNextEvent");
		Invoke("StartNextEvent", Random.Range(7, 12));
		NetworkServer.Spawn(Object.Instantiate(npc_, npcSpawnPoint.position, Quaternion.identity));
	}

	public void EODBus()
	{
		if (base.isServer)
		{
			EODBusRpc();
		}
		else
		{
			EODBusCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void EODBusCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DemoManager::EODBusCmd()", -1522281661, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EODBusRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::EODBusRpc()", -620637008, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void FlickeringLightsEvent()
	{
		if (base.isServer)
		{
			FlickeringLightsEventRpc();
		}
		else
		{
			FlickeringLightsEventCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void FlickeringLightsEventCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DemoManager::FlickeringLightsEventCmd()", -1562470484, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void FlickeringLightsEventRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::FlickeringLightsEventRpc()", -782385725, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void RespawnEveryone()
	{
		if (base.isServer)
		{
			RespawnEveryoneRpc();
		}
		else
		{
			RespawnEveryoneCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void RespawnEveryoneCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DemoManager::RespawnEveryoneCmd()", 1273237334, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RespawnEveryoneRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::RespawnEveryoneRpc()", 1361248073, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnTruck()
	{
		SpawnTruckRpc();
	}

	[ClientRpc]
	private void SpawnTruckRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::SpawnTruckRpc()", -1346614500, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnChasingNathan()
	{
		SpawnChasingNathanRpc();
	}

	[ClientRpc]
	private void SpawnChasingNathanRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::SpawnChasingNathanRpc()", 1858308688, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnRatInfestation()
	{
		SpawnRatsRpc();
	}

	[ClientRpc]
	private void SpawnRatsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DemoManager::SpawnRatsRpc()", 243764311, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnRats(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			float time = (float)i * 10f + Random.Range(0f, 5f);
			Invoke("SpawnRat", time);
		}
		CancelInvoke("StartNextEvent");
		Invoke("StartNextEvent", 1f);
	}

	private void SpawnRat()
	{
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_IncreaseEventIndex()
	{
		eventIndex++;
	}

	protected static void InvokeUserCode_IncreaseEventIndex(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC IncreaseEventIndex called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_IncreaseEventIndex();
		}
	}

	protected void UserCode_SpawnPurchasesTruckRpc()
	{
		truckHolder.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnPurchasesTruckRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnPurchasesTruckRpc called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_SpawnPurchasesTruckRpc();
		}
	}

	protected void UserCode_EODBusCmd()
	{
		EODBusRpc();
	}

	protected static void InvokeUserCode_EODBusCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command EODBusCmd called on client.");
		}
		else
		{
			((DemoManager)obj).UserCode_EODBusCmd();
		}
	}

	protected void UserCode_EODBusRpc()
	{
		eodBus.SetActive(value: true);
	}

	protected static void InvokeUserCode_EODBusRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EODBusRpc called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_EODBusRpc();
		}
	}

	protected void UserCode_FlickeringLightsEventCmd()
	{
		FlickeringLightsEventRpc();
	}

	protected static void InvokeUserCode_FlickeringLightsEventCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command FlickeringLightsEventCmd called on client.");
		}
		else
		{
			((DemoManager)obj).UserCode_FlickeringLightsEventCmd();
		}
	}

	protected void UserCode_FlickeringLightsEventRpc()
	{
		flickeringLightsEvent.SetActive(value: true);
	}

	protected static void InvokeUserCode_FlickeringLightsEventRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC FlickeringLightsEventRpc called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_FlickeringLightsEventRpc();
		}
	}

	protected void UserCode_RespawnEveryoneCmd()
	{
		RespawnEveryoneRpc();
	}

	protected static void InvokeUserCode_RespawnEveryoneCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RespawnEveryoneCmd called on client.");
		}
		else
		{
			((DemoManager)obj).UserCode_RespawnEveryoneCmd();
		}
	}

	protected void UserCode_RespawnEveryoneRpc()
	{
		ClientPlayer.Instance.transform.position = startPos.position;
		ClientPlayer.Instance.transform.rotation = startPos.rotation;
		ClientPlayer.Instance.playerMan.Respawn();
	}

	protected static void InvokeUserCode_RespawnEveryoneRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RespawnEveryoneRpc called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_RespawnEveryoneRpc();
		}
	}

	protected void UserCode_SpawnTruckRpc()
	{
		truckHolder.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnTruckRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnTruckRpc called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_SpawnTruckRpc();
		}
	}

	protected void UserCode_SpawnChasingNathanRpc()
	{
		answerThePhoneCanvas.SetActive(value: true);
		Telephone.Instance.whosCalling = "CarBrokenDown";
		phoneRingingSfx.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnChasingNathanRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnChasingNathanRpc called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_SpawnChasingNathanRpc();
		}
	}

	protected void UserCode_SpawnRatsRpc()
	{
		answerThePhoneCanvas.SetActive(value: true);
		Telephone.Instance.whosCalling = "RatInfestation";
		phoneRingingSfx.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnRatsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnRatsRpc called on server.");
		}
		else
		{
			((DemoManager)obj).UserCode_SpawnRatsRpc();
		}
	}

	static DemoManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DemoManager), "System.Void DemoManager::EODBusCmd()", InvokeUserCode_EODBusCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DemoManager), "System.Void DemoManager::FlickeringLightsEventCmd()", InvokeUserCode_FlickeringLightsEventCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DemoManager), "System.Void DemoManager::RespawnEveryoneCmd()", InvokeUserCode_RespawnEveryoneCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::IncreaseEventIndex()", InvokeUserCode_IncreaseEventIndex);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::SpawnPurchasesTruckRpc()", InvokeUserCode_SpawnPurchasesTruckRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::EODBusRpc()", InvokeUserCode_EODBusRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::FlickeringLightsEventRpc()", InvokeUserCode_FlickeringLightsEventRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::RespawnEveryoneRpc()", InvokeUserCode_RespawnEveryoneRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::SpawnTruckRpc()", InvokeUserCode_SpawnTruckRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::SpawnChasingNathanRpc()", InvokeUserCode_SpawnChasingNathanRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DemoManager), "System.Void DemoManager::SpawnRatsRpc()", InvokeUserCode_SpawnRatsRpc);
	}
}
