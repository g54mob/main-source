using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class FurnaceController : NetworkBehaviour, IInteractable
{
	[Serializable]
	public class FurnaceSaveData
	{
		public List<string> fuelQueue;

		public List<string> oreQueue;

		public List<string> completedQueue;
	}

	[CompilerGenerated]
	private sealed class _003CProcessCoroutine_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FurnaceController _003C_003E4__this;

		private UpgradeableCollectableItems _003CupgradeInfo_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CProcessCoroutine_003Ed__72(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			FurnaceController furnaceController = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				furnaceController.NetworkcurrentTime = furnaceController.currentTime - 1f;
				goto IL_00db;
			}
			_003C_003E1__state = -1;
			furnaceController.NetworkisProcessing = true;
			goto IL_0150;
			IL_00db:
			if (furnaceController.currentTime > 0f)
			{
				_003C_003E2__current = new WaitForSeconds(1f);
				_003C_003E1__state = 1;
				return true;
			}
			furnaceController.fuelQueue.RemoveAt(0);
			furnaceController.oreQueue.RemoveAt(0);
			for (int i = 0; i < _003CupgradeInfo_003E5__2.upgradedCount; i++)
			{
				furnaceController.completedQueue.Add(_003CupgradeInfo_003E5__2.upgradedItem.itemName);
			}
			_003CupgradeInfo_003E5__2 = null;
			goto IL_0150;
			IL_0150:
			if (furnaceController.fuelQueue.Count > 0 && furnaceController.oreQueue.Count > 0)
			{
				string text = furnaceController.oreQueue[0];
				CollectableItemData oreData = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
				_003CupgradeInfo_003E5__2 = furnaceController.upgradeableCollectableItems.Find((UpgradeableCollectableItems x) => x.mainItem == oreData);
				if (_003CupgradeInfo_003E5__2 != null)
				{
					furnaceController.NetworkmaxTime = _003CupgradeInfo_003E5__2.upgradeTime;
					furnaceController.NetworkcurrentTime = furnaceController.maxTime;
					TaskEventManager.OnMeltOreTaskCompleted.Invoke(oreData, 1);
					goto IL_00db;
				}
				UnityEngine.Debug.LogWarning("UpgradeInfo bulunamadı: " + text);
			}
			furnaceController.NetworkisProcessing = false;
			furnaceController.NetworkcurrentTime = 0f;
			furnaceController.NetworkmaxTime = 0f;
			UnityEngine.Debug.Log($"[FURNACE] İşlem bitti! Fuel: {furnaceController.fuelQueue.Count} | Ore: {furnaceController.oreQueue.Count} | Completed: {furnaceController.completedQueue.Count}");
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private bool isActive = true;

	private bool isInteracting;

	private TSPlayerController player;

	public GameObject fireParticle;

	[Header("Audio")]
	[SerializeField]
	private AudioSource burningAudioSource;

	[Header("Fuel System")]
	public List<FuelData> fuelItems = new List<FuelData>();

	public List<Transform> fuelPoints = new List<Transform>();

	public int maxFuelAmount = 32;

	[Header("Ore System")]
	public List<UpgradeableCollectableItems> upgradeableCollectableItems = new List<UpgradeableCollectableItems>();

	public List<Transform> inputPoints = new List<Transform>();

	[Header("Output System")]
	public List<Transform> outputPoints = new List<Transform>();

	public readonly SyncList<string> fuelQueue = new SyncList<string>();

	public readonly SyncList<string> oreQueue = new SyncList<string>();

	public readonly SyncList<string> completedQueue = new SyncList<string>();

	[SyncVar(hook = "OnProcessingChanged")]
	public bool isProcessing;

	[SyncVar]
	public float currentTime;

	[SyncVar]
	public float maxTime;

	private Coroutine processCoroutine;

	private bool isNetworkReady;

	private Queue<Action> pendingOperations = new Queue<Action>();

	[SerializeField]
	private Transform interactionParent;

	private bool isShowingInteraction;

	[SerializeField]
	private bool useSphereCast;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString addFuelLocalized;

	[SerializeField]
	private LocalizedString addOreLocalized;

	[SerializeField]
	private LocalizedString collectLocalized;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	public bool UseSphereCast => useSphereCast;

	public string completedItemName
	{
		get
		{
			if (completedQueue.Count <= 0)
			{
				return "";
			}
			return completedQueue[0];
		}
	}

	public int completedItemCount => completedQueue.Count;

	public bool NetworkisProcessing
	{
		get
		{
			return isProcessing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isProcessing, 1uL, OnProcessingChanged);
		}
	}

	public float NetworkcurrentTime
	{
		get
		{
			return currentTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentTime, 2uL, null);
		}
	}

	public float NetworkmaxTime
	{
		get
		{
			return maxTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref maxTime, 4uL, null);
		}
	}

	private void Awake()
	{
		if (fireParticle != null)
		{
			fireParticle.SetActive(value: false);
		}
		if (burningAudioSource != null)
		{
			burningAudioSource.loop = true;
			burningAudioSource.playOnAwake = false;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		fuelQueue.Callback += OnFuelQueueUpdated;
		oreQueue.Callback += OnOreQueueUpdated;
		completedQueue.Callback += OnCompletedQueueUpdated;
		StartCoroutine(WaitForNetworkAndProcessPending());
		StartCoroutine(InitializeVisuals());
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		UnityEngine.Debug.LogWarning($"[FURNACE] ⚠\ufe0f OnStartServer ÇAĞRILDI! Time: {Time.time:F2}s - ÖNCE: fuel={fuelQueue.Count}, ore={oreQueue.Count}, completed={completedQueue.Count}");
		UnityEngine.Debug.LogWarning("[FURNACE] ⚠\ufe0f StackTrace:\n" + StackTraceUtility.ExtractStackTrace());
		fuelQueue.Clear();
		oreQueue.Clear();
		completedQueue.Clear();
		NetworkisProcessing = false;
		NetworkcurrentTime = 0f;
		NetworkmaxTime = 0f;
		UnityEngine.Debug.LogWarning($"[FURNACE] ⚠\ufe0f OnStartServer SONRA: fuel={fuelQueue.Count}, ore={oreQueue.Count}, completed={completedQueue.Count}");
		isNetworkReady = true;
	}

	private void Start()
	{
		if (base.isServer)
		{
			isNetworkReady = true;
		}
		UpdateParticles();
	}

	private IEnumerator WaitForNetworkAndProcessPending()
	{
		NetworkIdentity netIdentity = GetComponent<NetworkIdentity>();
		while (netIdentity.netId == 0)
		{
			yield return new WaitForSeconds(0.1f);
		}
		isNetworkReady = true;
		UnityEngine.Debug.Log($"FurnaceController network hazır: {base.name} - NetID: {netIdentity.netId}");
		while (pendingOperations.Count > 0)
		{
			pendingOperations.Dequeue()();
		}
		UpdateParticles();
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (!isInteracting)
		{
			player = playerInventory.GetComponent<TSPlayerController>();
			isInteracting = true;
		}
		List<InteractionData> list = new List<InteractionData>();
		KeyCode addFuelKey = Singleton<UserPrefencesManager>.Instance.keyData.AddFuelKey;
		KeyCode interactKey = Singleton<UserPrefencesManager>.Instance.keyData.InteractKey;
		string localizedString = GetLocalizedString(addFuelLocalized, "Add Fuel");
		string localizedString2 = GetLocalizedString(addOreLocalized, "Add Ore");
		string oreInteractionText = GetOreInteractionText(localizedString2);
		bool flag = fuelQueue.Count < maxFuelAmount;
		CollectableItemData collectableItemData = null;
		if (flag)
		{
			for (int i = 0; i < fuelItems.Count; i++)
			{
				if (playerInventory.GetTotalItemCount(fuelItems[i].item) > 0)
				{
					collectableItemData = fuelItems[i].item;
					break;
				}
			}
		}
		bool num = collectableItemData != null && flag;
		list.Add(new InteractionData(messageColor: num ? ((Color?)null) : new Color?(InteractionPanel.Instance.negativeColor), keyCode: addFuelKey, message: $"{localizedString} ({fuelQueue.Count}/{maxFuelAmount})"));
		if (num && Input.GetKeyDown(addFuelKey))
		{
			TryAddFuel(collectableItemData.itemName, 1);
			playerInventory.AddItemInventory(collectableItemData, -1);
			InteractionPanel.Instance.HideAllInteractions();
		}
		bool num2 = completedQueue.Count > 0;
		CollectableItemData collectableItemData2 = (num2 ? null : GetUpgradeableItemInInventory(playerInventory));
		if (num2)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (string item in completedQueue)
			{
				if (dictionary.ContainsKey(item))
				{
					dictionary[item]++;
				}
				else
				{
					dictionary[item] = 1;
				}
			}
			List<string> list2 = new List<string>();
			foreach (KeyValuePair<string, int> item2 in dictionary)
			{
				CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(item2.Key);
				string arg = ((collectableItemFromName != null) ? collectableItemFromName.GetLocalizedDisplayName() : item2.Key);
				list2.Add($"({arg}) x{item2.Value}");
			}
			string message = GetLocalizedString(collectLocalized, "Collect") + " " + string.Join(" ", list2);
			list.Add(new InteractionData(interactKey, message));
			if (Input.GetKeyDown(interactKey))
			{
				CollectFirstCompletedItem(playerInventory);
				InteractionPanel.Instance.HideAllInteractions();
			}
		}
		else if (collectableItemData2 != null)
		{
			if (CanAddUpgradeableItem(collectableItemData2, 1))
			{
				list.Add(new InteractionData(interactKey, oreInteractionText));
				if (Input.GetKeyDown(interactKey))
				{
					TryAddUpgradeableItem(collectableItemData2.itemName, 1);
					playerInventory.AddItemInventory(collectableItemData2, -1);
					InteractionPanel.Instance.HideAllInteractions();
				}
			}
			else
			{
				string cannotAddReason = GetCannotAddReason(collectableItemData2);
				Color negativeColor = InteractionPanel.Instance.negativeColor;
				list.Add(new InteractionData(interactKey, cannotAddReason, hasHoldAction: false, 1f, null, null, null, negativeColor));
			}
		}
		else
		{
			Color negativeColor2 = InteractionPanel.Instance.negativeColor;
			list.Add(new InteractionData(interactKey, oreInteractionText, hasHoldAction: false, 1f, null, null, null, negativeColor2));
		}
		InteractionPanel.Instance.ShowMultipleInteractionOnOverlay(base.transform, playerInventory.transform, list);
		if (!isShowingInteraction)
		{
			ShowInteract(playerInventory.transform);
			isShowingInteraction = true;
		}
	}

	public void StopInteract()
	{
		isInteracting = false;
		isShowingInteraction = false;
		HideInteract();
		InteractionPanel.Instance.HideAllInteractions();
		if (player != null)
		{
			player.GetComponent<Interactor>().lastInteractable = null;
		}
	}

	private void OnDestroy()
	{
		if (isShowingInteraction && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	private void OnDisable()
	{
		if (isShowingInteraction)
		{
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.HideInteraction();
			}
			isShowingInteraction = false;
		}
	}

	private void ShowInteract(Transform playerTransform)
	{
	}

	private void Dismantle(Transform playerTransform)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		Grabber component2 = playerTransform.GetComponent<Grabber>();
		TSPlayerController component3 = playerTransform.GetComponent<TSPlayerController>();
		if (component != null && component2 != null && component3 != null)
		{
			component.Dismantle(component2, component3);
		}
	}

	private void HideInteract()
	{
		isShowingInteraction = false;
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	private void Remove(PlayerInventory player)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		if (component != null)
		{
			component.Remove(player);
		}
	}

	private string GetLocalizedString(LocalizedString localizedString, string fallback)
	{
		if (localizedString != null && !localizedString.IsEmpty)
		{
			string localizedString2 = localizedString.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString2))
			{
				return localizedString2;
			}
		}
		return fallback;
	}

	public bool IsFuelItem(CollectableItemData item)
	{
		return fuelItems.Exists((FuelData x) => x.item == item);
	}

	public bool IsUpgradeableItem(CollectableItemData item)
	{
		return upgradeableCollectableItems.Exists((UpgradeableCollectableItems x) => x.mainItem == item);
	}

	public bool HasCompletedItems()
	{
		return completedQueue.Count > 0;
	}

	public CollectableItemData GetUpgradeableItemInInventory(PlayerInventory playerInventory)
	{
		if (playerInventory == null)
		{
			return null;
		}
		for (int i = 0; i < upgradeableCollectableItems.Count; i++)
		{
			CollectableItemData mainItem = upgradeableCollectableItems[i].mainItem;
			if (mainItem != null && playerInventory.GetTotalItemCount(mainItem) > 0)
			{
				return mainItem;
			}
		}
		return null;
	}

	public bool CanAddFuel(CollectableItemData fuelData, int count)
	{
		if (!IsFuelItem(fuelData))
		{
			return false;
		}
		return fuelQueue.Count + count <= maxFuelAmount;
	}

	public bool CanAddUpgradeableItem(CollectableItemData upgradeableData, int count)
	{
		if (!IsUpgradeableItem(upgradeableData))
		{
			return false;
		}
		int maxOreSlots = GetMaxOreSlots();
		if (maxOreSlots <= 0)
		{
			return false;
		}
		int usedOreSlots = GetUsedOreSlots();
		return maxOreSlots - usedOreSlots >= count;
	}

	public string GetCannotAddReason(CollectableItemData item)
	{
		if (IsUpgradeableItem(item))
		{
			int maxOreSlots = GetMaxOreSlots();
			int usedOreSlots = GetUsedOreSlots();
			string oreSlotCounterText = GetOreSlotCounterText();
			if (usedOreSlots >= maxOreSlots)
			{
				if (completedQueue.Count > 0)
				{
					return "Collect completed items first " + oreSlotCounterText;
				}
				return "Furnace is full " + oreSlotCounterText;
			}
		}
		else if (IsFuelItem(item) && fuelQueue.Count >= maxFuelAmount)
		{
			return "Fuel capacity full";
		}
		return "";
	}

	private int GetMaxOreSlots()
	{
		return Mathf.Min(inputPoints.Count, outputPoints.Count);
	}

	private int GetUsedOreSlots()
	{
		return oreQueue.Count + completedQueue.Count;
	}

	private string GetOreSlotCounterText()
	{
		int num = Mathf.Max(0, GetMaxOreSlots());
		int num2 = Mathf.Clamp(GetUsedOreSlots(), 0, num);
		return $"({num2}/{num})";
	}

	private string GetOreInteractionText(string addOreText)
	{
		return addOreText + " " + GetOreSlotCounterText();
	}

	public void TryAddFuel(string itemName, int count)
	{
		UnityEngine.Debug.Log($"TryAddFuel: {itemName} x{count} - IsServer: {base.isServer} - NetworkReady: {isNetworkReady}");
		for (int i = 0; i < count; i++)
		{
			string capturedItemName = itemName;
			ProcessNetworkOperation(delegate
			{
				AddFuelInternal(capturedItemName);
			});
		}
	}

	public void TryAddUpgradeableItem(string itemName, int count)
	{
		UnityEngine.Debug.Log($"TryAddUpgradeableItem: {itemName} x{count} - IsServer: {base.isServer} - NetworkReady: {isNetworkReady}");
		for (int i = 0; i < count; i++)
		{
			string capturedItemName = itemName;
			ProcessNetworkOperation(delegate
			{
				AddOreInternal(capturedItemName);
			});
		}
	}

	public void TryTakeCompletedItem(int count)
	{
		UnityEngine.Debug.Log($"TryTakeCompletedItem: x{count} - IsServer: {base.isServer} - NetworkReady: {isNetworkReady}");
		int num = Mathf.Min(count, completedQueue.Count);
		for (int i = 0; i < num; i++)
		{
			ProcessNetworkOperation(delegate
			{
				TakeCompletedInternal();
			});
		}
	}

	private void ProcessNetworkOperation(Action operation)
	{
		if (base.isServer)
		{
			operation();
			return;
		}
		if (isNetworkReady)
		{
			operation();
			return;
		}
		pendingOperations.Enqueue(operation);
		UnityEngine.Debug.Log($"İşlem kuyruğa eklendi. Kuyrukta bekleyen: {pendingOperations.Count}");
	}

	private void AddFuelInternal(string itemName)
	{
		if (base.isServer)
		{
			ServerAddFuel(itemName);
		}
		else
		{
			CmdAddFuel(itemName);
		}
	}

	private void AddOreInternal(string itemName)
	{
		if (base.isServer)
		{
			ServerAddOre(itemName);
		}
		else
		{
			CmdAddOre(itemName);
		}
	}

	private void TakeCompletedInternal()
	{
		if (base.isServer)
		{
			ServerTakeCompleted();
		}
		else
		{
			CmdTakeCompleted();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddFuel(string itemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		SendCommandInternal("System.Void FurnaceController::CmdAddFuel(System.String)", 928465908, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdAddOre(string itemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		SendCommandInternal("System.Void FurnaceController::CmdAddOre(System.String)", -1035505002, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdTakeCompleted()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void FurnaceController::CmdTakeCompleted()", 649950619, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddFuel(string itemName)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void FurnaceController::ServerAddFuel(System.String)' called when server was not active");
			return;
		}
		fuelQueue.Add(itemName);
		CheckProcessing();
	}

	[Server]
	private void ServerAddOre(string itemName)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void FurnaceController::ServerAddOre(System.String)' called when server was not active");
			return;
		}
		oreQueue.Add(itemName);
		CheckProcessing();
	}

	[Server]
	private void ServerTakeCompleted()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void FurnaceController::ServerTakeCompleted()' called when server was not active");
			return;
		}
		UnityEngine.Debug.Log($"ServerTakeCompleted çağrıldı - Completed count: {completedQueue.Count}");
		if (completedQueue.Count > 0)
		{
			string arg = completedQueue[0];
			completedQueue.RemoveAt(0);
			UnityEngine.Debug.Log($"Completed item silindi: {arg} - Kalan: {completedQueue.Count}");
			CheckProcessing();
		}
		else
		{
			UnityEngine.Debug.LogWarning("ServerTakeCompleted çağrıldı ama completed queue boş!");
		}
	}

	[IteratorStateMachine(typeof(_003CProcessCoroutine_003Ed__72))]
	[Server]
	private IEnumerator ProcessCoroutine()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator FurnaceController::ProcessCoroutine()' called when server was not active");
			return null;
		}
		return new _003CProcessCoroutine_003Ed__72(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	private void CheckProcessing()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void FurnaceController::CheckProcessing()' called when server was not active");
		}
		else if (fuelQueue.Count > 0 && oreQueue.Count > 0 && !isProcessing)
		{
			StartProcessing();
		}
	}

	[Server]
	private void StartProcessing()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void FurnaceController::StartProcessing()' called when server was not active");
			return;
		}
		if (processCoroutine != null)
		{
			StopCoroutine(processCoroutine);
		}
		processCoroutine = StartCoroutine(ProcessCoroutine());
	}

	public CollectableItemData GetCompletedItemData()
	{
		if (completedQueue.Count > 0)
		{
			return NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(completedQueue[0]);
		}
		return null;
	}

	public int GetCompletedItemCount()
	{
		return completedQueue.Count;
	}

	private void UpdateParticles()
	{
		if (fireParticle != null)
		{
			fireParticle.SetActive(isProcessing);
		}
		if (burningAudioSource != null)
		{
			if (isProcessing && !burningAudioSource.isPlaying)
			{
				burningAudioSource.Play();
			}
			else if (!isProcessing && burningAudioSource.isPlaying)
			{
				burningAudioSource.Stop();
			}
		}
	}

	private void OnProcessingChanged(bool oldValue, bool newValue)
	{
		UpdateParticles();
	}

	private IEnumerator InitializeVisuals()
	{
		yield return new WaitForEndOfFrame();
		while (!isNetworkReady)
		{
			yield return new WaitForSeconds(0.1f);
		}
		UpdateAllFuelVisuals();
		UpdateAllInputVisuals();
		UpdateAllOutputVisuals();
	}

	private void OnFuelQueueUpdated(SyncList<string>.Operation op, int index, string oldItem, string newItem)
	{
		UpdateAllFuelVisuals();
		UpdateParticles();
	}

	private void OnOreQueueUpdated(SyncList<string>.Operation op, int index, string oldItem, string newItem)
	{
		UpdateAllInputVisuals();
	}

	private void OnCompletedQueueUpdated(SyncList<string>.Operation op, int index, string oldItem, string newItem)
	{
		UpdateAllOutputVisuals();
	}

	private void UpdateAllFuelVisuals()
	{
		for (int i = 0; i < fuelPoints.Count; i++)
		{
			ClearFuelVisual(i);
		}
		int num = Mathf.Min(fuelQueue.Count, fuelPoints.Count);
		for (int j = 0; j < num; j++)
		{
			UpdateFuelVisual(j, fuelQueue[j]);
		}
	}

	private void UpdateFuelVisual(int index, string fuelItemName)
	{
		if (index >= fuelPoints.Count || fuelPoints[index] == null || string.IsNullOrEmpty(fuelItemName))
		{
			return;
		}
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(fuelItemName);
		if (collectableItemFromName == null)
		{
			return;
		}
		ObjectDataEqualityChecker[] componentsInChildren = fuelPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		foreach (ObjectDataEqualityChecker objectDataEqualityChecker in componentsInChildren)
		{
			if (objectDataEqualityChecker.IsEqual(collectableItemFromName))
			{
				objectDataEqualityChecker.OpenObject();
				break;
			}
		}
	}

	private void ClearFuelVisual(int index)
	{
		if (index < fuelPoints.Count && !(fuelPoints[index] == null))
		{
			ObjectDataEqualityChecker[] componentsInChildren = fuelPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].CloseObject();
			}
		}
	}

	private void UpdateAllInputVisuals()
	{
		for (int i = 0; i < inputPoints.Count; i++)
		{
			ClearInputVisual(i);
		}
		int num = Mathf.Min(oreQueue.Count, inputPoints.Count);
		for (int j = 0; j < num; j++)
		{
			UpdateInputVisual(j, oreQueue[j]);
		}
	}

	private void UpdateInputVisual(int index, string oreItemName)
	{
		if (index >= inputPoints.Count || inputPoints[index] == null || string.IsNullOrEmpty(oreItemName))
		{
			return;
		}
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(oreItemName);
		if (collectableItemFromName == null)
		{
			return;
		}
		ObjectDataEqualityChecker[] componentsInChildren = inputPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		foreach (ObjectDataEqualityChecker objectDataEqualityChecker in componentsInChildren)
		{
			if (objectDataEqualityChecker.IsEqual(collectableItemFromName))
			{
				objectDataEqualityChecker.OpenObject();
				break;
			}
		}
	}

	private void ClearInputVisual(int index)
	{
		if (index < inputPoints.Count && !(inputPoints[index] == null))
		{
			ObjectDataEqualityChecker[] componentsInChildren = inputPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].CloseObject();
			}
		}
	}

	private void UpdateAllOutputVisuals()
	{
		for (int i = 0; i < outputPoints.Count; i++)
		{
			ClearOutputVisual(i);
		}
		int num = Mathf.Min(completedQueue.Count, outputPoints.Count);
		for (int j = 0; j < num; j++)
		{
			UpdateOutputVisual(j, completedQueue[j]);
		}
	}

	private void UpdateOutputVisual(int index, string itemName)
	{
		if (index >= outputPoints.Count || outputPoints[index] == null || string.IsNullOrEmpty(itemName))
		{
			return;
		}
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(itemName);
		if (collectableItemFromName == null)
		{
			return;
		}
		ObjectDataEqualityChecker[] componentsInChildren = outputPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		foreach (ObjectDataEqualityChecker objectDataEqualityChecker in componentsInChildren)
		{
			if (objectDataEqualityChecker.IsEqual(collectableItemFromName))
			{
				objectDataEqualityChecker.OpenObject();
				break;
			}
		}
	}

	private void ClearOutputVisual(int index)
	{
		if (index < outputPoints.Count && !(outputPoints[index] == null))
		{
			ObjectDataEqualityChecker[] componentsInChildren = outputPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].CloseObject();
			}
		}
	}

	private void CollectFirstCompletedItem(PlayerInventory playerInventory)
	{
		if (completedQueue.Count == 0)
		{
			return;
		}
		string itemName = completedQueue[0];
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(itemName);
		if (collectableItemFromName == null)
		{
			return;
		}
		if (playerInventory.GetAvailableSpaceForItem(collectableItemFromName) >= 1)
		{
			playerInventory.AddItemInventory(collectableItemFromName, 1);
		}
		else
		{
			DropCompletedItemToGround(playerInventory, collectableItemFromName, 1);
			if (Singleton<UserMessagePanel>.Instance != null)
			{
				Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
			}
		}
		TaskEventManager.OnCollectIngotTaskCompleted.Invoke(collectableItemFromName, 1);
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.TakeItemGeneralSound);
		}
		TryTakeCompletedItem(1);
	}

	private void DropCompletedItemToGround(PlayerInventory playerInventory, CollectableItemData item, int amount)
	{
		Transform transform = playerInventory.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.position + transform.forward;
		Vector3 spawnForward = transform.position + transform.forward * 2f;
		if (item.hasDurability)
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(item.itemName, amount, spawnPoint, spawnForward, item.startDurability);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(item.itemName, amount, spawnPoint, spawnForward);
		}
	}

	public string SaveState()
	{
		return JsonUtility.ToJson(new FurnaceSaveData
		{
			fuelQueue = new List<string>(fuelQueue),
			oreQueue = new List<string>(oreQueue),
			completedQueue = new List<string>(completedQueue)
		});
	}

	public void LoadState(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			UnityEngine.Debug.LogWarning("[FURNACE] \ud83d\udcc2 No save data to load (data is empty)");
			return;
		}
		try
		{
			FurnaceSaveData furnaceSaveData = JsonUtility.FromJson<FurnaceSaveData>(data);
			if (furnaceSaveData != null && base.isServer)
			{
				if (furnaceSaveData.fuelQueue != null)
				{
					foreach (string item in furnaceSaveData.fuelQueue)
					{
						fuelQueue.Add(item);
					}
				}
				if (furnaceSaveData.oreQueue != null)
				{
					foreach (string item2 in furnaceSaveData.oreQueue)
					{
						oreQueue.Add(item2);
					}
				}
				if (furnaceSaveData.completedQueue != null)
				{
					foreach (string item3 in furnaceSaveData.completedQueue)
					{
						completedQueue.Add(item3);
					}
				}
				CheckProcessing();
			}
			else if (!base.isServer)
			{
				UnityEngine.Debug.LogWarning("[FURNACE] \ud83d\udcc2 Client olduğu için yükleme yapılmadı!");
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("[FURNACE] Failed to load save data: " + ex.Message);
		}
	}

	public FurnaceController()
	{
		InitSyncObject(fuelQueue);
		InitSyncObject(oreQueue);
		InitSyncObject(completedQueue);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddFuel__String(string itemName)
	{
		ServerAddFuel(itemName);
	}

	protected static void InvokeUserCode_CmdAddFuel__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdAddFuel called on client.");
		}
		else
		{
			((FurnaceController)obj).UserCode_CmdAddFuel__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdAddOre__String(string itemName)
	{
		ServerAddOre(itemName);
	}

	protected static void InvokeUserCode_CmdAddOre__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdAddOre called on client.");
		}
		else
		{
			((FurnaceController)obj).UserCode_CmdAddOre__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdTakeCompleted()
	{
		ServerTakeCompleted();
	}

	protected static void InvokeUserCode_CmdTakeCompleted(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTakeCompleted called on client.");
		}
		else
		{
			((FurnaceController)obj).UserCode_CmdTakeCompleted();
		}
	}

	static FurnaceController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(FurnaceController), "System.Void FurnaceController::CmdAddFuel(System.String)", InvokeUserCode_CmdAddFuel__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(FurnaceController), "System.Void FurnaceController::CmdAddOre(System.String)", InvokeUserCode_CmdAddOre__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(FurnaceController), "System.Void FurnaceController::CmdTakeCompleted()", InvokeUserCode_CmdTakeCompleted, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isProcessing);
			writer.WriteFloat(currentTime);
			writer.WriteFloat(maxTime);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isProcessing);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(currentTime);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteFloat(maxTime);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isProcessing, OnProcessingChanged, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref currentTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref maxTime, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isProcessing, OnProcessingChanged, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentTime, null, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref maxTime, null, reader.ReadFloat());
		}
	}
}
