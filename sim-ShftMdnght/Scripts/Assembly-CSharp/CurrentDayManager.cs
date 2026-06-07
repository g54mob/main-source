using System;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class CurrentDayManager : NetworkBehaviour
{
	public StoreManager storeMan;

	public EndlessGenerationManager customerGenManager;

	public EventManager eventMan;

	public SaveManager saveMan;

	public List<string> listOfOccurrences = new List<string> { "NPC", "NPC", "NPC", "NPC", "NPC", "NPC" };

	public int todaysEvent;

	public List<Npc> todaysNpcs;

	public int npcIndex;

	public int curOccurrence;

	public int occurrencesCompleted;

	public GameObject[] presetDayObjs;

	public GameObject[] randomOccurringDayObjs;

	public GameObject day1Obj;

	public GameObject[] objsToTurnOffDay1;

	public GameObject[] objsToTurnOffAfterDay1;

	public GameObject truckHolder;

	public bool startedDay;

	public int curDay;

	public GameObject[] objsToTurnOnBeforeCars;

	public GameObject[] objsToTurnOnAfterCars;

	public GameObject[] allCars;

	public Interactable gasPump;

	private bool alreadySetUpDay;

	public GameObject[] thieves;

	private GameObject todaysDayObjNpc;

	private GameObject todaysDayObjCar;

	public UnityEvent notDay1Events;

	public static CurrentDayManager Instance { get; private set; }

	public void Start_()
	{
		Invoke("SetUpDay", 1f);
	}

	public void SetUpDay()
	{
		if (!base.isServer)
		{
			return;
		}
		curDay = saveMan.curDay;
		UpdateCurDayAndOccurrence(curDay, curOccurrence);
		todaysNpcs = customerGenManager.GenerateNight();
		if (curDay == 3)
		{
			TurnOnAfterCarObjs();
			if (!alreadySetUpDay)
			{
				listOfOccurrences.Insert(0, "CAR");
				listOfOccurrences.Insert(4, "CAR");
			}
		}
		else if (curDay > 5)
		{
			TurnOnAfterCarObjs();
			if (!alreadySetUpDay)
			{
				int num = UnityEngine.Random.Range(0, 3);
				for (int i = 0; i < num; i++)
				{
					listOfOccurrences.Insert(UnityEngine.Random.Range(0, 2) * 2, "CAR");
				}
			}
		}
		else
		{
			TurnOnBeforeCarObjs();
		}
		if (curDay > 2)
		{
			GameObject[] shopTabNotifs = PurchaseManager.Instance.shopTabNotifs;
			for (int j = 0; j < shopTabNotifs.Length; j++)
			{
				shopTabNotifs[j].SetActive(value: false);
			}
		}
		if (!alreadySetUpDay)
		{
			PurchaseManager.Instance.AddRefreshes(1);
			todaysEvent = saveMan.seedForEvents[curDay];
			if (todaysEvent != -1)
			{
				listOfOccurrences.Insert(UnityEngine.Random.Range(2, listOfOccurrences.Count - 2), "EVENT");
			}
			listOfOccurrences.Add("END DAY");
		}
		if (curDay == 1)
		{
			TurnOffDay1Objs();
			alreadySetUpDay = true;
			return;
		}
		TurnOffNotDay1Objs();
		NetworkServer.Destroy(day1Obj);
		if (presetDayObjs.Length > curDay && (bool)presetDayObjs[curDay] && !alreadySetUpDay)
		{
			StoreManager.Instance.todayWasSetDayObj = true;
			GameObject obj = UnityEngine.Object.Instantiate(presetDayObjs[curDay], Vector3.zero, Quaternion.identity);
			DayObjectManager component = obj.GetComponent<DayObjectManager>();
			if ((bool)component)
			{
				if (component.spawnsNpc)
				{
					listOfOccurrences.Insert(UnityEngine.Random.Range(component.minIndexToSpawn, component.maxIndexToSpawn), "DAY OBJ NPC");
					todaysDayObjNpc = component.npcToSpawn;
				}
				if (component.spawnsCar)
				{
					listOfOccurrences.Insert(UnityEngine.Random.Range(component.minIndexToSpawn, component.maxIndexToSpawn), "DAY OBJ CAR");
					todaysDayObjCar = component.carToSpawn;
				}
			}
			NetworkServer.Spawn(obj);
			alreadySetUpDay = true;
			return;
		}
		int num2 = randomOccurringDayObjs.Length;
		System.Random random = new System.Random(SaveManager.Instance.seed);
		List<int> list = new List<int>();
		for (int k = 0; k < num2; k++)
		{
			if (!SaveManager.Instance.dayObjsSpawnedBefore.Contains(k))
			{
				list.Add(k);
			}
		}
		if (list.Count == 0)
		{
			alreadySetUpDay = true;
			return;
		}
		int num3 = list[random.Next(list.Count)];
		EODReportValues.Instance.todaysDayObjIndex = num3;
		if (alreadySetUpDay)
		{
			return;
		}
		GameObject obj2 = UnityEngine.Object.Instantiate(randomOccurringDayObjs[num3], Vector3.zero, Quaternion.identity);
		DayObjectManager component2 = obj2.GetComponent<DayObjectManager>();
		if ((bool)component2)
		{
			if (component2.spawnsNpc)
			{
				listOfOccurrences.Insert(UnityEngine.Random.Range(component2.minIndexToSpawn, component2.maxIndexToSpawn), "DAY OBJ NPC");
				todaysDayObjNpc = component2.npcToSpawn;
			}
			if (component2.spawnsCar)
			{
				listOfOccurrences.Insert(UnityEngine.Random.Range(component2.minIndexToSpawn, component2.maxIndexToSpawn), "DAY OBJ CAR");
				todaysDayObjCar = component2.carToSpawn;
			}
		}
		NetworkServer.Spawn(obj2);
		alreadySetUpDay = true;
	}

	[ClientRpc]
	private void TurnOffDay1Objs()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CurrentDayManager::TurnOffDay1Objs()", 801910600, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TurnOffNotDay1Objs()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CurrentDayManager::TurnOffNotDay1Objs()", -414944959, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TurnOnBeforeCarObjs()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CurrentDayManager::TurnOnBeforeCarObjs()", -462448596, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TurnOnAfterCarObjs()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CurrentDayManager::TurnOnAfterCarObjs()", 1611077411, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void UpdateCurDayAndOccurrence(int day, int occurrence)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(day);
		writer.WriteVarInt(occurrence);
		SendRPCInternal("System.Void CurrentDayManager::UpdateCurDayAndOccurrence(System.Int32,System.Int32)", 1432003532, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PlayNextOccurence()
	{
		if (!base.isServer)
		{
			return;
		}
		if (!startedDay)
		{
			if (curDay == 6)
			{
				Invoke("SpawnThief", UnityEngine.Random.Range(9, 20));
			}
			Computer.Instance.TurnOnComputer();
			startedDay = true;
		}
		if (curDay >= 3)
		{
			int num = UnityEngine.Random.Range(0, 10);
			if (num >= 9)
			{
				for (int i = 0; i < 2; i++)
				{
					EventManager.Instance.Invoke("SpawnRat", i);
				}
			}
			else if (num >= 7)
			{
				EventManager.Instance.SpawnRat();
			}
			if (curDay >= 6 && curOccurrence < listOfOccurrences.Count - 3 && UnityEngine.Random.Range(0, 10) >= 8)
			{
				Invoke("SpawnThief", UnityEngine.Random.Range(9, 20));
			}
		}
		switch (curDay)
		{
		case 1:
			switch (curOccurrence)
			{
			case 2:
				DumpsterMonster.Instance.SetPosition(2);
				break;
			case 4:
				DumpsterMonster.Instance.SetPosition(3);
				break;
			case 5:
				DumpsterMonster.Instance.SetPosition(4);
				break;
			}
			break;
		case 2:
			switch (curOccurrence)
			{
			case 0:
				DumpsterMonster.Instance.SetPosition(4);
				break;
			case 2:
				DumpsterMonster.Instance.SetPosition(5);
				break;
			case 3:
				DumpsterMonster.Instance.SetPosition(6);
				break;
			case 5:
				DumpsterMonster.Instance.SetPosition(7);
				break;
			}
			break;
		case 3:
			if (curOccurrence == 0)
			{
				DumpsterMonster.Instance.SetPosition(8);
			}
			break;
		}
		switch (listOfOccurrences[curOccurrence])
		{
		case "NPC":
		{
			float num2 = todaysNpcs[npcIndex].extraTimeBeforeSpawn;
			if (num2 == 0f)
			{
				num2 += (float)UnityEngine.Random.Range(0, 2);
			}
			Invoke("ActuallySpawnNPC", num2);
			break;
		}
		case "CAR":
			SpawnCar();
			break;
		case "DAY OBJ NPC":
			NetworkServer.Spawn(UnityEngine.Object.Instantiate(todaysDayObjNpc, storeMan.npcSpawnPoint.position, Quaternion.identity));
			break;
		case "DAY OBJ CAR":
			NetworkServer.Spawn(UnityEngine.Object.Instantiate(todaysDayObjCar, storeMan.carSpawnPoint.position, Quaternion.identity));
			break;
		case "EVENT":
			Invoke("ActuallyDoEvent", 5f);
			break;
		case "HUNT":
			Invoke("ActuallyDoHunt", 5f);
			break;
		case "END DAY":
			eventMan.EODBus();
			break;
		}
		curOccurrence++;
		UpdateCurDayAndOccurrence(curDay, curOccurrence);
	}

	private void ActuallySpawnNPC()
	{
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(todaysNpcs[npcIndex].prefab, storeMan.npcSpawnPoint.position, Quaternion.identity));
		npcIndex++;
	}

	private void ActuallyDoEvent()
	{
		eventMan.eventAtlas[todaysEvent].Invoke();
	}

	private void ActuallyDoHunt()
	{
		storeMan.CheckForHunt();
	}

	public void SpawnCar()
	{
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(allCars[PlayerPrefs.GetInt("CurCarIndex", 0)], storeMan.carSpawnPoint.position, Quaternion.identity));
		PlayerPrefs.SetInt("CurCarIndex", PlayerPrefs.GetInt("CurCarIndex", 0) + 1);
		if (PlayerPrefs.GetInt("CurCarIndex", 0) == 5)
		{
			PlayerPrefs.SetInt("CurCarIndex", 0);
		}
	}

	public void CompleteOccurrence()
	{
		if (base.isServer)
		{
			Debug.Log(Environment.StackTrace);
			occurrencesCompleted++;
			if (occurrencesCompleted >= curOccurrence)
			{
				Invoke("PlayNextOccurence", 0.1f);
			}
		}
	}

	public void HuntCaused()
	{
		listOfOccurrences.Insert(listOfOccurrences.Count - 1, "HUNT");
	}

	private void Awake()
	{
		Instance = this;
	}

	public void SpawnThief()
	{
		int num = UnityEngine.Random.Range(0, thieves.Length);
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(thieves[num], storeMan.npcSpawnPoint.position, Quaternion.identity));
	}

	[ClientRpc]
	public void SpawnTruck()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void CurrentDayManager::SpawnTruck()", -1673158139, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TurnOffDay1Objs()
	{
		GameObject[] array = objsToTurnOffDay1;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}

	protected static void InvokeUserCode_TurnOffDay1Objs(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TurnOffDay1Objs called on server.");
		}
		else
		{
			((CurrentDayManager)obj).UserCode_TurnOffDay1Objs();
		}
	}

	protected void UserCode_TurnOffNotDay1Objs()
	{
		notDay1Events.Invoke();
		TransactionManager.Instance.canTransact = true;
		GameObject[] array = objsToTurnOffAfterDay1;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}

	protected static void InvokeUserCode_TurnOffNotDay1Objs(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TurnOffNotDay1Objs called on server.");
		}
		else
		{
			((CurrentDayManager)obj).UserCode_TurnOffNotDay1Objs();
		}
	}

	protected void UserCode_TurnOnBeforeCarObjs()
	{
		GameObject[] array = objsToTurnOnBeforeCars;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
	}

	protected static void InvokeUserCode_TurnOnBeforeCarObjs(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TurnOnBeforeCarObjs called on server.");
		}
		else
		{
			((CurrentDayManager)obj).UserCode_TurnOnBeforeCarObjs();
		}
	}

	protected void UserCode_TurnOnAfterCarObjs()
	{
		gasPump.ChangeInteractableStatus(change: true);
		GameObject[] array = objsToTurnOnAfterCars;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
	}

	protected static void InvokeUserCode_TurnOnAfterCarObjs(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TurnOnAfterCarObjs called on server.");
		}
		else
		{
			((CurrentDayManager)obj).UserCode_TurnOnAfterCarObjs();
		}
	}

	protected void UserCode_UpdateCurDayAndOccurrence__Int32__Int32(int day, int occurrence)
	{
		curDay = day;
		curOccurrence = occurrence;
	}

	protected static void InvokeUserCode_UpdateCurDayAndOccurrence__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateCurDayAndOccurrence called on server.");
		}
		else
		{
			((CurrentDayManager)obj).UserCode_UpdateCurDayAndOccurrence__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_SpawnTruck()
	{
		truckHolder.SetActive(value: true);
	}

	protected static void InvokeUserCode_SpawnTruck(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnTruck called on server.");
		}
		else
		{
			((CurrentDayManager)obj).UserCode_SpawnTruck();
		}
	}

	static CurrentDayManager()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(CurrentDayManager), "System.Void CurrentDayManager::TurnOffDay1Objs()", InvokeUserCode_TurnOffDay1Objs);
		RemoteProcedureCalls.RegisterRpc(typeof(CurrentDayManager), "System.Void CurrentDayManager::TurnOffNotDay1Objs()", InvokeUserCode_TurnOffNotDay1Objs);
		RemoteProcedureCalls.RegisterRpc(typeof(CurrentDayManager), "System.Void CurrentDayManager::TurnOnBeforeCarObjs()", InvokeUserCode_TurnOnBeforeCarObjs);
		RemoteProcedureCalls.RegisterRpc(typeof(CurrentDayManager), "System.Void CurrentDayManager::TurnOnAfterCarObjs()", InvokeUserCode_TurnOnAfterCarObjs);
		RemoteProcedureCalls.RegisterRpc(typeof(CurrentDayManager), "System.Void CurrentDayManager::UpdateCurDayAndOccurrence(System.Int32,System.Int32)", InvokeUserCode_UpdateCurDayAndOccurrence__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(CurrentDayManager), "System.Void CurrentDayManager::SpawnTruck()", InvokeUserCode_SpawnTruck);
	}
}
