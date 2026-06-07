using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : NetworkBehaviour
{
	public GameObject[] dayObjs;

	public int[] setEventsOnEachDay;

	public UnityEvent[] eventAtlas;

	public RandomEvent[] randomOccurringEvents;

	public GameObject phoneRingingSfx;

	public GameObject eodBus;

	public Transform startPos;

	public GameObject playerDoppelganger;

	public Transform playerDoppelgangerSpawnpoint;

	public Transform[] playerDoppelgangerSpawnpoints;

	public GameObject flickeringLightsEvent;

	public GameObject truckHolder;

	public GameObject rat;

	public static EventManager Instance { get; private set; }

	private void SetEventSeed()
	{
		if (SaveManager.Instance.seed == 0)
		{
			SaveManager.Instance.seed = UnityEngine.Random.Range(1, 99999);
		}
		int curDay = SaveManager.Instance.curDay;
		System.Random random = new System.Random(SaveManager.Instance.seed);
		HashSet<string> usedOneTimeIds = new HashSet<string>();
		int? lastEventIndex = null;
		SaveManager.Instance.seedForEvents.Clear();
		for (int i = 0; i < 50; i++)
		{
			if (setEventsOnEachDay[i] != -1)
			{
				SaveManager.Instance.seedForEvents.Add(setEventsOnEachDay[i]);
				lastEventIndex = ((setEventsOnEachDay[i] == -1) ? ((int?)null) : new int?(setEventsOnEachDay[i]));
				continue;
			}
			if ((SaveManager.Instance.seedForEvents.Count <= 0 || SaveManager.Instance.seedForEvents[SaveManager.Instance.seedForEvents.Count - 1] != -1) && random.NextDouble() < 0.0)
			{
				SaveManager.Instance.seedForEvents.Add(-1);
				lastEventIndex = null;
				continue;
			}
			int day = curDay + i;
			List<RandomEvent> source = randomOccurringEvents.Where((RandomEvent e) => e != null && e.onlyOccurAfterThisDay < day && day < e.onlyOccurBeforeThisDay).ToList();
			source = source.Where((RandomEvent e) => !e.oneTimeEvent || !usedOneTimeIds.Contains(e.id)).ToList();
			if (source.Count == 0)
			{
				Debug.Log($"Day {day}: NoEvent (no eligible after day-window/one-time checks)");
				SaveManager.Instance.seedForEvents.Add(-1);
				lastEventIndex = null;
				continue;
			}
			List<RandomEvent> list = source.Where((RandomEvent e) => !lastEventIndex.HasValue || e.eventIndex != lastEventIndex.Value).ToList();
			if (list.Count == 0)
			{
				Debug.Log($"Day {day}: NoEvent (would repeat last event)");
				SaveManager.Instance.seedForEvents.Add(-1);
				lastEventIndex = null;
				continue;
			}
			int index = random.Next(list.Count);
			RandomEvent randomEvent = list[index];
			if (randomEvent.oneTimeEvent && !string.IsNullOrEmpty(randomEvent.id))
			{
				usedOneTimeIds.Add(randomEvent.id);
			}
			SaveManager.Instance.seedForEvents.Add(randomEvent.eventIndex);
			lastEventIndex = randomEvent.eventIndex;
		}
	}

	public void SpawnPlayerDoppelganger()
	{
		if (base.isServer)
		{
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 1f);
			NetworkServer.Spawn(UnityEngine.Object.Instantiate(playerDoppelganger, playerDoppelgangerSpawnpoint.position, Quaternion.identity));
		}
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
		SendCommandInternal("System.Void EventManager::EODBusCmd()", -2116121140, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void EODBusRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EventManager::EODBusRpc()", 472837347, writer, 0, includeOwner: true);
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
		SendCommandInternal("System.Void EventManager::FlickeringLightsEventCmd()", -729416855, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void FlickeringLightsEventRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EventManager::FlickeringLightsEventRpc()", 1655071226, writer, 0, includeOwner: true);
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
		SendRPCInternal("System.Void EventManager::SpawnTruckRpc()", -1744784601, writer, 0, includeOwner: true);
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
		SendRPCInternal("System.Void EventManager::SpawnChasingNathanRpc()", 1491078271, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnForestLimbs()
	{
		SpawnForestLimbsRpc();
	}

	[ClientRpc]
	private void SpawnForestLimbsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EventManager::SpawnForestLimbsRpc()", -2064310024, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SpawnNight1TruckRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EventManager::SpawnNight1TruckRpc()", 289456078, writer, 0, includeOwner: true);
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
		SendRPCInternal("System.Void EventManager::SpawnRatsRpc()", -592237834, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnRoachInfestation()
	{
		SpawnRoachRpc();
	}

	[ClientRpc]
	private void SpawnRoachRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void EventManager::SpawnRoachRpc()", -1960213275, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnRats(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			float time = (float)i * 10f + UnityEngine.Random.Range(0f, 5f);
			Invoke("SpawnRat", time);
		}
		CurrentDayManager.Instance.Invoke("CompleteOccurrence", 50f);
	}

	public void SpawnRat()
	{
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(rat, playerDoppelgangerSpawnpoint.position, Quaternion.identity));
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		if (PlayerPrefs.GetInt("EventSeedSet" + PlayerPrefs.GetInt("CurSaveSlot", 0), 0) != 1)
		{
			SetEventSeed();
		}
	}

	public override bool Weaved()
	{
		return true;
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
			((EventManager)obj).UserCode_EODBusCmd();
		}
	}

	protected void UserCode_EODBusRpc()
	{
		eodBus.SetActive(value: true);
		StoreManager.Instance.NewObjective("Objectives", "EOD Bus");
	}

	protected static void InvokeUserCode_EODBusRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EODBusRpc called on server.");
		}
		else
		{
			((EventManager)obj).UserCode_EODBusRpc();
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
			((EventManager)obj).UserCode_FlickeringLightsEventCmd();
		}
	}

	protected void UserCode_FlickeringLightsEventRpc()
	{
		StoreManager.Instance.NewObjective("Objectives", "Store Generator Tampered");
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
			((EventManager)obj).UserCode_FlickeringLightsEventRpc();
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
			((EventManager)obj).UserCode_SpawnTruckRpc();
		}
	}

	protected void UserCode_SpawnChasingNathanRpc()
	{
		StoreManager.Instance.NewObjective("Objectives", "Answer the Phone");
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
			((EventManager)obj).UserCode_SpawnChasingNathanRpc();
		}
	}

	protected void UserCode_SpawnForestLimbsRpc()
	{
		StoreManager.Instance.NewObjective("Objectives", "Answer the Phone");
		Telephone.Instance.whosCalling = "ForestLimbs";
		phoneRingingSfx.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnForestLimbsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnForestLimbsRpc called on server.");
		}
		else
		{
			((EventManager)obj).UserCode_SpawnForestLimbsRpc();
		}
	}

	protected void UserCode_SpawnNight1TruckRpc()
	{
		CurrentDayManager.Instance.SpawnTruck();
	}

	protected static void InvokeUserCode_SpawnNight1TruckRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnNight1TruckRpc called on server.");
		}
		else
		{
			((EventManager)obj).UserCode_SpawnNight1TruckRpc();
		}
	}

	protected void UserCode_SpawnRatsRpc()
	{
		StoreManager.Instance.NewObjective("Objectives", "Answer the Phone");
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
			((EventManager)obj).UserCode_SpawnRatsRpc();
		}
	}

	protected void UserCode_SpawnRoachRpc()
	{
		StoreManager.Instance.NewObjective("Objectives", "Answer the Phone");
		Telephone.Instance.whosCalling = "RoachInfestation";
		phoneRingingSfx.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnRoachRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnRoachRpc called on server.");
		}
		else
		{
			((EventManager)obj).UserCode_SpawnRoachRpc();
		}
	}

	static EventManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(EventManager), "System.Void EventManager::EODBusCmd()", InvokeUserCode_EODBusCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(EventManager), "System.Void EventManager::FlickeringLightsEventCmd()", InvokeUserCode_FlickeringLightsEventCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::EODBusRpc()", InvokeUserCode_EODBusRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::FlickeringLightsEventRpc()", InvokeUserCode_FlickeringLightsEventRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::SpawnTruckRpc()", InvokeUserCode_SpawnTruckRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::SpawnChasingNathanRpc()", InvokeUserCode_SpawnChasingNathanRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::SpawnForestLimbsRpc()", InvokeUserCode_SpawnForestLimbsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::SpawnNight1TruckRpc()", InvokeUserCode_SpawnNight1TruckRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::SpawnRatsRpc()", InvokeUserCode_SpawnRatsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(EventManager), "System.Void EventManager::SpawnRoachRpc()", InvokeUserCode_SpawnRoachRpc);
	}
}
