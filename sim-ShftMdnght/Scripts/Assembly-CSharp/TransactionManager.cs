using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

public class TransactionManager : NetworkBehaviour
{
	public IDCard card;

	public Register registerScript;

	public GameObject idCard;

	public List<int> itemsToScan;

	public GameObject[] itemAtlas;

	public Transform[] itemPositions;

	public int amountOfItemsToScan;

	public int amountOfItemsScanned;

	public Interactable bell;

	public int revenue;

	public TextMeshProUGUI registerText;

	public StoreBrowseBehaviour curNpcScript;

	public List<GameObject> objectsToScan;

	public Sprite[] idPhotos;

	public Sprite[] signatures;

	public GameObject[] notIds;

	public GameObject initialInteractionCollider;

	public GameObject scanBTN;

	public bool canTransact = true;

	public bool alreadyTriggeredInitial;

	public static TransactionManager Instance { get; private set; }

	public void StartTransaction(string npcName, List<int> items, StoreBrowseBehaviour npcScript)
	{
		if (base.isServer)
		{
			StartTransactionRpc(npcName, items, npcScript);
		}
		else
		{
			StartTransactionCmd(npcName, items, npcScript);
		}
	}

	[Command(requiresAuthority = false)]
	public void StartTransactionCmd(string npcName, List<int> items, StoreBrowseBehaviour npcScript)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(npcName);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, items);
		writer.WriteNetworkBehaviour(npcScript);
		SendCommandInternal("System.Void TransactionManager::StartTransactionCmd(System.String,System.Collections.Generic.List`1<System.Int32>,StoreBrowseBehaviour)", -1465010327, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void StartTransactionRpc(string npcName, List<int> items, StoreBrowseBehaviour npcScript)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(npcName);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, items);
		writer.WriteNetworkBehaviour(npcScript);
		SendRPCInternal("System.Void TransactionManager::StartTransactionRpc(System.String,System.Collections.Generic.List`1<System.Int32>,StoreBrowseBehaviour)", 1874974486, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void TriggerInitialInteraction()
	{
		if (!Computer.Instance.npcAtCounter || alreadyTriggeredInitial)
		{
			return;
		}
		Computer.Instance.StopInteract();
		RestockShelf[] restockShelves = Shelves.Instance.restockShelves;
		foreach (RestockShelf restockShelf in restockShelves)
		{
			if ((bool)restockShelf)
			{
				restockShelf.StopInteract();
			}
		}
		IDCard[] array = Object.FindObjectsOfType<IDCard>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].StopInteract();
		}
		if (PlayerPrefs.GetInt("CheckIDHint") != 1)
		{
			Invoke("CheckIDHint", 32f);
			PlayerPrefs.SetInt("CheckIDHint", 1);
		}
		if (curNpcScript.dialogueInteractable.replaceInitialDialogueWithForced)
		{
			curNpcScript.dialogueInteractable.ForceTalkToPlayer();
		}
		else if (!curNpcScript.dialogueInteractable.dontDoInitialDialogue)
		{
			curNpcScript.dialogueInteractable.InitialDialogue(onlyClientSide: false);
		}
		ClientPlayer.Instance.inventoryMan.PauseUseItem();
		ClientPlayer.Instance.playerMan.Invoke("TurnPauseOff", 0.11f);
		ClientPlayer.Instance.playerMan.Invoke("TurnPauseOff", 0.2f);
		SetAlreadyTriggeredInitial(change: true);
	}

	[Command(requiresAuthority = false)]
	private void SetAlreadyTriggeredInitial(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendCommandInternal("System.Void TransactionManager::SetAlreadyTriggeredInitial(System.Boolean)", 481876238, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SetAlreadyTriggeredInitialRpc(bool change)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(change);
		SendRPCInternal("System.Void TransactionManager::SetAlreadyTriggeredInitialRpc(System.Boolean)", 50271093, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public IEnumerator SpawnItems()
	{
		yield return new WaitForSeconds(0.18f);
		for (int i = 0; i < itemsToScan.Count; i++)
		{
			GameObject item = Object.Instantiate(itemAtlas[itemsToScan[i]], itemPositions[i].position, Quaternion.identity);
			objectsToScan.Add(item);
			yield return new WaitForSeconds(0.18f);
		}
		foreach (GameObject item2 in objectsToScan)
		{
			NetworkServer.Spawn(item2);
		}
	}

	public void ItemScanned(int cost)
	{
		revenue += cost;
		amountOfItemsScanned++;
		if (amountOfItemsScanned == amountOfItemsToScan)
		{
			registerScript.canCompleteTransaction = true;
		}
		registerText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		registerText.text = "$" + revenue + ".00";
	}

	public void CompleteTransaction()
	{
		if (base.isServer)
		{
			CompleteTransactionRpc();
		}
		else
		{
			CompleteTransactionCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void CompleteTransactionCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TransactionManager::CompleteTransactionCmd()", -20391385, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CompleteTransactionRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TransactionManager::CompleteTransactionRpc()", 103477572, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void CancelTransaction()
	{
		if (base.isServer)
		{
			CancelTransactionRpc();
		}
		else
		{
			CancelTransactionCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void CancelTransactionCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TransactionManager::CancelTransactionCmd()", -1741254838, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CancelTransactionRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TransactionManager::CancelTransactionRpc()", 1302377277, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void TurnOffInteractionColliderRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TransactionManager::TurnOffInteractionColliderRpc()", -1737591551, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void SetIDValues(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return;
		}
		if (name == "Robber")
		{
			idCard.SetActive(value: false);
			return;
		}
		idCard.SetActive(value: true);
		string iDDatabaseText = JSONAccess.Instance.GetIDDatabaseText(name, "PHOTO ID");
		if (string.IsNullOrEmpty(iDDatabaseText))
		{
			Debug.LogWarning("PHOTO ID missing for '" + name + "'");
			return;
		}
		if (!int.TryParse(iDDatabaseText, out var result))
		{
			Debug.LogWarning("Invalid PHOTO ID '" + iDDatabaseText + "' for '" + name + "'");
			return;
		}
		if (result < 0)
		{
			int num = Mathf.Abs(result);
			if (num >= 0 && num < notIds.Length)
			{
				notIds[num].SetActive(value: true);
			}
			else
			{
				Debug.LogWarning($"Invalid notIds index {num} for '{name}'");
			}
			scanBTN.SetActive(value: false);
		}
		else
		{
			if (result >= idPhotos.Length || result >= signatures.Length)
			{
				Debug.LogWarning($"PHOTO ID out of range ({result}) for '{name}'");
				return;
			}
			card.icon.sprite = idPhotos[result];
			card.signature.sprite = signatures[result];
		}
		card.dbName = name;
		card.nameText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		card.nameText.text = JSONAccess.Instance.GetShowingName(name);
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void CheckIDHint()
	{
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_StartTransactionCmd__String__List_00601__StoreBrowseBehaviour(string npcName, List<int> items, StoreBrowseBehaviour npcScript)
	{
		StartTransactionRpc(npcName, items, npcScript);
	}

	protected static void InvokeUserCode_StartTransactionCmd__String__List_00601__StoreBrowseBehaviour(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command StartTransactionCmd called on client.");
		}
		else
		{
			((TransactionManager)obj).UserCode_StartTransactionCmd__String__List_00601__StoreBrowseBehaviour(reader.ReadString(), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader), reader.ReadNetworkBehaviour<StoreBrowseBehaviour>());
		}
	}

	protected void UserCode_StartTransactionRpc__String__List_00601__StoreBrowseBehaviour(string npcName, List<int> items, StoreBrowseBehaviour npcScript)
	{
		if (!DialogueTutorialManager.Instance.alreadyDone)
		{
			DialogueTutorialManager.Instance.canvas.SetActive(value: true);
		}
		itemsToScan = items.ToList();
		if (base.isServer)
		{
			foreach (GameObject item in objectsToScan)
			{
				if ((bool)item)
				{
					NetworkServer.Destroy(item);
				}
			}
			objectsToScan.Clear();
			StartCoroutine(SpawnItems());
		}
		amountOfItemsToScan = items.Count;
		Computer.Instance.npcAtCounter = true;
		Computer.Instance.dialogueScript = npcScript.dialogueInteractable;
		initialInteractionCollider.SetActive(value: true);
		GameObject[] array = notIds;
		foreach (GameObject gameObject in array)
		{
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: false);
			}
		}
		scanBTN.SetActive(value: true);
		curNpcScript = npcScript;
		registerText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		registerText.text = JSONAccess.Instance.GetMiscText("Diagetic Text", "SCAN ITEMS");
		revenue = 0;
		bell.interactSFX.Play();
		SetIDValues(npcName);
		StoreManager.Instance.SetExaminationsRemaining(5);
	}

	protected static void InvokeUserCode_StartTransactionRpc__String__List_00601__StoreBrowseBehaviour(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC StartTransactionRpc called on server.");
		}
		else
		{
			((TransactionManager)obj).UserCode_StartTransactionRpc__String__List_00601__StoreBrowseBehaviour(reader.ReadString(), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader), reader.ReadNetworkBehaviour<StoreBrowseBehaviour>());
		}
	}

	protected void UserCode_SetAlreadyTriggeredInitial__Boolean(bool change)
	{
		SetAlreadyTriggeredInitialRpc(change);
	}

	protected static void InvokeUserCode_SetAlreadyTriggeredInitial__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetAlreadyTriggeredInitial called on client.");
		}
		else
		{
			((TransactionManager)obj).UserCode_SetAlreadyTriggeredInitial__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_SetAlreadyTriggeredInitialRpc__Boolean(bool change)
	{
		alreadyTriggeredInitial = change;
	}

	protected static void InvokeUserCode_SetAlreadyTriggeredInitialRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetAlreadyTriggeredInitialRpc called on server.");
		}
		else
		{
			((TransactionManager)obj).UserCode_SetAlreadyTriggeredInitialRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CompleteTransactionCmd()
	{
		CompleteTransactionRpc();
	}

	protected static void InvokeUserCode_CompleteTransactionCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CompleteTransactionCmd called on client.");
		}
		else
		{
			((TransactionManager)obj).UserCode_CompleteTransactionCmd();
		}
	}

	protected void UserCode_CompleteTransactionRpc()
	{
		if (base.isServer)
		{
			ReviewsManager.Instance.Invoke("GetReview", Random.Range(5, 20));
			StoreManager.Instance.ChangeRevenue("Transaction", revenue);
		}
		card.StopInteract();
		DialogueTutorialManager.Instance.CompletedTransaction();
		SetAlreadyTriggeredInitial(change: false);
		curNpcScript.dialogueInteractable.mouthAnim.SetBool("Talking", value: false);
		curNpcScript.dialogueInteractable.ExitDialogue();
		curNpcScript.dialogueInteractable.ExitDialogue();
		curNpcScript.dialogueInteractable.ExitDialogue();
		curNpcScript.dialogueInteractable.ExitDialogue();
		curNpcScript.dialogueInteractable.ExitDialogue();
		SpeakingManager.Instance.CancelAllDialogue();
		Computer.Instance.npcAtCounter = false;
		CurrentDayManager.Instance.Invoke("CompleteOccurrence", 0.1f);
		registerText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		registerText.text = JSONAccess.Instance.GetMiscText("Diagetic Text", "SCAN ITEMS");
		idCard.SetActive(value: false);
		if (curNpcScript.isDoppelganger)
		{
			StoreManager.Instance.doppelsLetThru++;
			CurrentDayManager.Instance.HuntCaused();
		}
		curNpcScript.dialogueInteractable.faceNearestPlayer = false;
		amountOfItemsToScan = 1000;
		amountOfItemsScanned = 0;
		registerScript.canCompleteTransaction = false;
		curNpcScript.FinishTransaction();
	}

	protected static void InvokeUserCode_CompleteTransactionRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CompleteTransactionRpc called on server.");
		}
		else
		{
			((TransactionManager)obj).UserCode_CompleteTransactionRpc();
		}
	}

	protected void UserCode_CancelTransactionCmd()
	{
		CancelTransactionRpc();
	}

	protected static void InvokeUserCode_CancelTransactionCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CancelTransactionCmd called on client.");
		}
		else
		{
			((TransactionManager)obj).UserCode_CancelTransactionCmd();
		}
	}

	protected void UserCode_CancelTransactionRpc()
	{
		card.StopInteract();
		TurnOffInteractionColliderRpc();
		SetAlreadyTriggeredInitial(change: false);
		Computer.Instance.npcAtCounter = false;
		foreach (GameObject item in objectsToScan)
		{
			if (!(item == null))
			{
				item.GetComponent<ScanItem>().collectAnimator.enabled = true;
				Object.Destroy(item, 1.5f);
			}
		}
		registerText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		registerText.text = JSONAccess.Instance.GetMiscText("Diagetic Text", "SCAN ITEMS");
		idCard.SetActive(value: false);
		amountOfItemsToScan = 1000;
		amountOfItemsScanned = 0;
		registerScript.canCompleteTransaction = false;
	}

	protected static void InvokeUserCode_CancelTransactionRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CancelTransactionRpc called on server.");
		}
		else
		{
			((TransactionManager)obj).UserCode_CancelTransactionRpc();
		}
	}

	protected void UserCode_TurnOffInteractionColliderRpc()
	{
		initialInteractionCollider.SetActive(value: false);
	}

	protected static void InvokeUserCode_TurnOffInteractionColliderRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC TurnOffInteractionColliderRpc called on server.");
		}
		else
		{
			((TransactionManager)obj).UserCode_TurnOffInteractionColliderRpc();
		}
	}

	static TransactionManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TransactionManager), "System.Void TransactionManager::StartTransactionCmd(System.String,System.Collections.Generic.List`1<System.Int32>,StoreBrowseBehaviour)", InvokeUserCode_StartTransactionCmd__String__List_00601__StoreBrowseBehaviour, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TransactionManager), "System.Void TransactionManager::SetAlreadyTriggeredInitial(System.Boolean)", InvokeUserCode_SetAlreadyTriggeredInitial__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TransactionManager), "System.Void TransactionManager::CompleteTransactionCmd()", InvokeUserCode_CompleteTransactionCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TransactionManager), "System.Void TransactionManager::CancelTransactionCmd()", InvokeUserCode_CancelTransactionCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TransactionManager), "System.Void TransactionManager::StartTransactionRpc(System.String,System.Collections.Generic.List`1<System.Int32>,StoreBrowseBehaviour)", InvokeUserCode_StartTransactionRpc__String__List_00601__StoreBrowseBehaviour);
		RemoteProcedureCalls.RegisterRpc(typeof(TransactionManager), "System.Void TransactionManager::SetAlreadyTriggeredInitialRpc(System.Boolean)", InvokeUserCode_SetAlreadyTriggeredInitialRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(TransactionManager), "System.Void TransactionManager::CompleteTransactionRpc()", InvokeUserCode_CompleteTransactionRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(TransactionManager), "System.Void TransactionManager::CancelTransactionRpc()", InvokeUserCode_CancelTransactionRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(TransactionManager), "System.Void TransactionManager::TurnOffInteractionColliderRpc()", InvokeUserCode_TurnOffInteractionColliderRpc);
	}
}
