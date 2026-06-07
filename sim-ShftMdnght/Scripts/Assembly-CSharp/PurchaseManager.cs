using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseManager : NetworkBehaviour
{
	public TextMeshProUGUI balanceText;

	public List<GameObject> purchaseQueue;

	public GameObject[] purchaseObjects;

	public Transform cartHolder;

	public PlayAudioArray purchaseSfx;

	public GameObject eodBus;

	public TextMeshProUGUI infoText;

	public TextMeshProUGUI refreshesText;

	public GameObject[] decorNodes;

	public GameObject[] storeUpgradeNodes;

	public GameObject[] weaponNodes;

	public GameObject crateNode;

	public Transform[] nodePositions;

	public List<Animator> existingNodes = new List<Animator>();

	public GameObject noMoreStoreUpgrades;

	public GameObject noMoreWeapons;

	public Button refreshBTN;

	private float timeBetweenRevealingCards;

	private int prevStoreUpgradeIndex = -1;

	private int prevWeaponIndex = -1;

	public GameObject shopTabBTN;

	public GameObject[] shopTabNotifs;

	public bool activated;

	public static PurchaseManager Instance { get; private set; }

	public void GenerateShopNodes()
	{
		if (base.isServer)
		{
			StartCoroutine(GenerateShopNodesCoroutine());
		}
	}

	public IEnumerator GenerateShopNodesCoroutine()
	{
		prevStoreUpgradeIndex = -1;
		prevWeaponIndex = -1;
		int num = Random.Range(0, decorNodes.Length);
		GameObject gameObject = Object.Instantiate(decorNodes[num], Vector3.zero, Quaternion.identity);
		existingNodes.Add(gameObject.GetComponent<Animator>());
		gameObject.GetComponentInChildren<PurchaseNode>().nodeIndex = num;
		NetworkServer.Spawn(gameObject);
		yield return new WaitForSeconds(timeBetweenRevealingCards);
		int num2 = Random.Range(0, decorNodes.Length);
		GameObject gameObject2 = Object.Instantiate(decorNodes[num2], Vector3.zero, Quaternion.identity);
		existingNodes.Add(gameObject2.GetComponent<Animator>());
		gameObject2.GetComponentInChildren<PurchaseNode>().nodeIndex = num2;
		NetworkServer.Spawn(gameObject2);
		yield return new WaitForSeconds(timeBetweenRevealingCards);
		GameObject gameObject3 = Object.Instantiate(crateNode, Vector3.zero, Quaternion.identity);
		existingNodes.Add(gameObject3.GetComponent<Animator>());
		NetworkServer.Spawn(gameObject3);
		yield return new WaitForSeconds(timeBetweenRevealingCards);
		int randomAvailableIndex = GetRandomAvailableIndex(storeUpgradeNodes.Length, "UPGRADES");
		if (randomAvailableIndex != -1)
		{
			GameObject gameObject4 = Object.Instantiate(storeUpgradeNodes[randomAvailableIndex], Vector3.zero, Quaternion.identity);
			existingNodes.Add(gameObject4.GetComponent<Animator>());
			gameObject4.GetComponentInChildren<PurchaseNode>().nodeIndex = randomAvailableIndex;
			NetworkServer.Spawn(gameObject4);
		}
		else
		{
			int num3 = Random.Range(0, decorNodes.Length);
			GameObject gameObject5 = Object.Instantiate(decorNodes[num3], Vector3.zero, Quaternion.identity);
			existingNodes.Add(gameObject5.GetComponent<Animator>());
			gameObject5.GetComponentInChildren<PurchaseNode>().nodeIndex = num3;
			NetworkServer.Spawn(gameObject5);
		}
		yield return new WaitForSeconds(timeBetweenRevealingCards);
		int randomAvailableIndex2 = GetRandomAvailableIndex(weaponNodes.Length, "WEAPONS");
		if (randomAvailableIndex2 != -1)
		{
			prevWeaponIndex = randomAvailableIndex2;
			GameObject gameObject6 = Object.Instantiate(weaponNodes[randomAvailableIndex2], Vector3.zero, Quaternion.identity);
			existingNodes.Add(gameObject6.GetComponent<Animator>());
			gameObject6.GetComponentInChildren<PurchaseNode>().nodeIndex = randomAvailableIndex2;
			NetworkServer.Spawn(gameObject6);
		}
		else
		{
			int num4 = Random.Range(0, decorNodes.Length);
			GameObject gameObject7 = Object.Instantiate(decorNodes[num4], Vector3.zero, Quaternion.identity);
			existingNodes.Add(gameObject7.GetComponent<Animator>());
			gameObject7.GetComponentInChildren<PurchaseNode>().nodeIndex = num4;
			NetworkServer.Spawn(gameObject7);
		}
		yield return new WaitForSeconds(timeBetweenRevealingCards);
		int randomAvailableIndex3 = GetRandomAvailableIndex(weaponNodes.Length, "WEAPONS");
		if (randomAvailableIndex3 != -1)
		{
			GameObject gameObject8 = Object.Instantiate(weaponNodes[randomAvailableIndex3], Vector3.zero, Quaternion.identity);
			existingNodes.Add(gameObject8.GetComponent<Animator>());
			gameObject8.GetComponentInChildren<PurchaseNode>().nodeIndex = randomAvailableIndex3;
			NetworkServer.Spawn(gameObject8);
		}
		else
		{
			int num5 = Random.Range(0, decorNodes.Length);
			GameObject gameObject9 = Object.Instantiate(decorNodes[num5], Vector3.zero, Quaternion.identity);
			existingNodes.Add(gameObject9.GetComponent<Animator>());
			gameObject9.GetComponentInChildren<PurchaseNode>().nodeIndex = num5;
			NetworkServer.Spawn(gameObject9);
		}
		yield return new WaitForSeconds(timeBetweenRevealingCards);
		timeBetweenRevealingCards = 0.07f;
		EnableRefreshBTN();
	}

	private int GetRandomAvailableIndex(int maxExclusive, string type)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < maxExclusive; i++)
		{
			if (!(type == "UPGRADES"))
			{
				if (type == "WEAPONS" && !SaveManager.Instance.weaponsPurchased.Contains(i) && i != prevWeaponIndex)
				{
					list.Add(i);
				}
			}
			else if (!SaveManager.Instance.storeUpgradesPurchased.Contains(i) && i != prevStoreUpgradeIndex)
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return -1;
		}
		int index = Random.Range(0, list.Count);
		return list[index];
	}

	public void AddRefreshes(int change)
	{
		if (base.isServer)
		{
			AddRefreshesRpc(change);
		}
		else
		{
			AddRefreshesCmd(change);
		}
	}

	[Command(requiresAuthority = false)]
	public void AddRefreshesCmd(int change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(change);
		SendCommandInternal("System.Void PurchaseManager::AddRefreshesCmd(System.Int32)", -291726710, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AddRefreshesRpc(int change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(change);
		SendRPCInternal("System.Void PurchaseManager::AddRefreshesRpc(System.Int32)", 2087528829, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SetRefreshesForAllClients(int refreshes)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(refreshes);
		SendRPCInternal("System.Void PurchaseManager::SetRefreshesForAllClients(System.Int32)", -1479922957, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void TryRefresh()
	{
		if (SaveManager.Instance.refreshes < 1)
		{
			StoreManager.Instance.SetAlert("No refreshes remaining!", "red");
			return;
		}
		if (eodBus.activeInHierarchy)
		{
			StoreManager.Instance.SetAlert("Can't refresh at end of day!", "red");
			return;
		}
		refreshBTN.interactable = false;
		AddRefreshes(-1);
		if (base.isServer)
		{
			RefreshRpc();
		}
		else
		{
			RefreshCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void RefreshCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PurchaseManager::RefreshCmd()", -1859019272, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RefreshRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PurchaseManager::RefreshRpc()", 806112415, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ActuallyDeleteAllNodes()
	{
		foreach (Animator existingNode in existingNodes)
		{
			if ((bool)existingNode)
			{
				NetworkServer.Destroy(existingNode.gameObject);
			}
		}
		Invoke("GenerateShopNodes", 0.1f);
	}

	[ClientRpc]
	private void EnableRefreshBTN()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PurchaseManager::EnableRefreshBTN()", -1975801641, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void HoverInfo(string item)
	{
		infoText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		infoText.text = JSONAccess.Instance.GetMiscText("Shop Info", item + " Info");
	}

	public void UnhoverInfo()
	{
		infoText.text = "";
	}

	public void LoadTotalBalance()
	{
		balanceText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		balanceText.text = "$" + SaveManager.Instance.money.ToString("0.00");
	}

	public void PurchaseItem(int index, float cost)
	{
		if (purchaseQueue.Count > 8)
		{
			StoreManager.Instance.SetAlert("Too many items already coming in the next delivery!", "red");
		}
		else if (eodBus.activeInHierarchy)
		{
			StoreManager.Instance.SetAlert("Can't purchase items at the end of the day.", "red");
		}
		else if (SaveManager.Instance.money <= cost - 0.01f)
		{
			StoreManager.Instance.SetAlert("Not enough funds.", "red");
		}
		else if (base.isServer)
		{
			PurchaseObjRpc(index, cost);
		}
		else
		{
			PurchaseObjCmd(index, cost);
		}
	}

	[Command(requiresAuthority = false)]
	public void PurchaseObjCmd(int index, float cost)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		writer.WriteFloat(cost);
		SendCommandInternal("System.Void PurchaseManager::PurchaseObjCmd(System.Int32,System.Single)", 594280267, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void PurchaseObjRpc(int index, float cost)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(index);
		writer.WriteFloat(cost);
		SendRPCInternal("System.Void PurchaseManager::PurchaseObjRpc(System.Int32,System.Single)", 1990551676, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ActivateShopTabInitial()
	{
		if (base.isServer)
		{
			ActivateShopTabInitialRpc();
		}
		else
		{
			ActivateShopTabInitialCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void ActivateShopTabInitialCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PurchaseManager::ActivateShopTabInitialCmd()", -644946703, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ActivateShopTabInitialRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PurchaseManager::ActivateShopTabInitialRpc()", 615765842, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ActivateShopTab()
	{
		if (base.isServer)
		{
			ActivateShopTabRpc();
		}
		else
		{
			ActivateShopTabCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void ActivateShopTabCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PurchaseManager::ActivateShopTabCmd()", -903838835, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ActivateShopTabRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PurchaseManager::ActivateShopTabRpc()", 759993982, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_AddRefreshesCmd__Int32(int change)
	{
		AddRefreshesRpc(change);
	}

	protected static void InvokeUserCode_AddRefreshesCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AddRefreshesCmd called on client.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_AddRefreshesCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_AddRefreshesRpc__Int32(int change)
	{
		if (base.isServer)
		{
			SaveManager.Instance.refreshes += change;
			SetRefreshesForAllClients(SaveManager.Instance.refreshes);
		}
	}

	protected static void InvokeUserCode_AddRefreshesRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AddRefreshesRpc called on server.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_AddRefreshesRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetRefreshesForAllClients__Int32(int refreshes)
	{
		SaveManager.Instance.refreshes = refreshes;
		refreshesText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		refreshesText.text = "x" + refreshes;
	}

	protected static void InvokeUserCode_SetRefreshesForAllClients__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetRefreshesForAllClients called on server.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_SetRefreshesForAllClients__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RefreshCmd()
	{
		RefreshRpc();
	}

	protected static void InvokeUserCode_RefreshCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RefreshCmd called on client.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_RefreshCmd();
		}
	}

	protected void UserCode_RefreshRpc()
	{
		refreshBTN.interactable = false;
		if (!base.isServer)
		{
			return;
		}
		foreach (Animator existingNode in existingNodes)
		{
			if ((bool)existingNode)
			{
				existingNode.SetBool("Disappear", value: true);
			}
		}
		Invoke("ActuallyDeleteAllNodes", 0.25f);
	}

	protected static void InvokeUserCode_RefreshRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RefreshRpc called on server.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_RefreshRpc();
		}
	}

	protected void UserCode_EnableRefreshBTN()
	{
		refreshBTN.interactable = true;
	}

	protected static void InvokeUserCode_EnableRefreshBTN(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EnableRefreshBTN called on server.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_EnableRefreshBTN();
		}
	}

	protected void UserCode_PurchaseObjCmd__Int32__Single(int index, float cost)
	{
		PurchaseObjRpc(index, cost);
	}

	protected static void InvokeUserCode_PurchaseObjCmd__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PurchaseObjCmd called on client.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_PurchaseObjCmd__Int32__Single(reader.ReadVarInt(), reader.ReadFloat());
		}
	}

	protected void UserCode_PurchaseObjRpc__Int32__Single(int index, float cost)
	{
		purchaseSfx.PlayAudio();
		SaveManager.Instance.money -= cost;
		switch (index)
		{
		case 0:
			purchaseQueue.Add(purchaseObjects[index]);
			purchaseQueue.Add(purchaseObjects[index]);
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 1:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 2:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 3:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 4:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 5:
			if (base.isServer)
			{
				SaveManager instance = SaveManager.Instance;
				instance.NetworkmaxInventorySpace = instance.maxInventorySpace + 1;
				InventoryManager[] array = Object.FindObjectsOfType<InventoryManager>(includeInactive: true);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetMaxInventorySlots(SaveManager.Instance.maxInventorySpace);
				}
			}
			StoreManager.Instance.SetAlert("Extra inventory slot acquired!", "green");
			LoadTotalBalance();
			return;
		case 6:
			if (base.isServer)
			{
				AddRefreshes(2);
			}
			LoadTotalBalance();
			return;
		case 7:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 8:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 9:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 10:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 11:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 12:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 13:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 14:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 15:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 16:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 17:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 18:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 19:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 20:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 21:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 22:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 23:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 24:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 25:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 26:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 27:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 28:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 29:
			purchaseQueue.Add(purchaseObjects[index]);
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 30:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 31:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 32:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 33:
			SaveManager.Instance.EnableSecurityScanners();
			LoadTotalBalance();
			return;
		case 34:
			SaveManager.Instance.EnableCeilingFans();
			LoadTotalBalance();
			return;
		case 35:
			SaveManager.Instance.EnableAisleSigns();
			LoadTotalBalance();
			return;
		case 36:
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		case 37:
			purchaseQueue.Add(purchaseObjects[index]);
			purchaseQueue.Add(purchaseObjects[index]);
			break;
		}
		CurrentDayManager.Instance.SpawnTruck();
		LoadTotalBalance();
	}

	protected static void InvokeUserCode_PurchaseObjRpc__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PurchaseObjRpc called on server.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_PurchaseObjRpc__Int32__Single(reader.ReadVarInt(), reader.ReadFloat());
		}
	}

	protected void UserCode_ActivateShopTabInitialCmd()
	{
		ActivateShopTabInitialRpc();
	}

	protected static void InvokeUserCode_ActivateShopTabInitialCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ActivateShopTabInitialCmd called on client.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_ActivateShopTabInitialCmd();
		}
	}

	protected void UserCode_ActivateShopTabInitialRpc()
	{
		if (CurrentDayManager.Instance.curDay > 2)
		{
			GameObject[] array = shopTabNotifs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
		}
		shopTabBTN.SetActive(value: true);
		activated = true;
	}

	protected static void InvokeUserCode_ActivateShopTabInitialRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActivateShopTabInitialRpc called on server.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_ActivateShopTabInitialRpc();
		}
	}

	protected void UserCode_ActivateShopTabCmd()
	{
		ActivateShopTabRpc();
	}

	protected static void InvokeUserCode_ActivateShopTabCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ActivateShopTabCmd called on client.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_ActivateShopTabCmd();
		}
	}

	protected void UserCode_ActivateShopTabRpc()
	{
		shopTabBTN.SetActive(value: true);
		activated = true;
	}

	protected static void InvokeUserCode_ActivateShopTabRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActivateShopTabRpc called on server.");
		}
		else
		{
			((PurchaseManager)obj).UserCode_ActivateShopTabRpc();
		}
	}

	static PurchaseManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PurchaseManager), "System.Void PurchaseManager::AddRefreshesCmd(System.Int32)", InvokeUserCode_AddRefreshesCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PurchaseManager), "System.Void PurchaseManager::RefreshCmd()", InvokeUserCode_RefreshCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PurchaseManager), "System.Void PurchaseManager::PurchaseObjCmd(System.Int32,System.Single)", InvokeUserCode_PurchaseObjCmd__Int32__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PurchaseManager), "System.Void PurchaseManager::ActivateShopTabInitialCmd()", InvokeUserCode_ActivateShopTabInitialCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PurchaseManager), "System.Void PurchaseManager::ActivateShopTabCmd()", InvokeUserCode_ActivateShopTabCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseManager), "System.Void PurchaseManager::AddRefreshesRpc(System.Int32)", InvokeUserCode_AddRefreshesRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseManager), "System.Void PurchaseManager::SetRefreshesForAllClients(System.Int32)", InvokeUserCode_SetRefreshesForAllClients__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseManager), "System.Void PurchaseManager::RefreshRpc()", InvokeUserCode_RefreshRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseManager), "System.Void PurchaseManager::EnableRefreshBTN()", InvokeUserCode_EnableRefreshBTN);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseManager), "System.Void PurchaseManager::PurchaseObjRpc(System.Int32,System.Single)", InvokeUserCode_PurchaseObjRpc__Int32__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseManager), "System.Void PurchaseManager::ActivateShopTabInitialRpc()", InvokeUserCode_ActivateShopTabInitialRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(PurchaseManager), "System.Void PurchaseManager::ActivateShopTabRpc()", InvokeUserCode_ActivateShopTabRpc);
	}
}
