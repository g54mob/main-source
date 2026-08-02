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

public class ChemistryTableController : NetworkBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CProductionCoroutine_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChemistryTableController _003C_003E4__this;

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
		public _003CProductionCoroutine_003Ed__86(int _003C_003E1__state)
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
			ChemistryTableController chemistryTableController = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				float deltaTime = Time.deltaTime;
				chemistryTableController.NetworkremainingFuelTime = chemistryTableController.remainingFuelTime - deltaTime;
				chemistryTableController.NetworkcurrentProductionProgress = chemistryTableController.currentProductionProgress + deltaTime;
				if (chemistryTableController.currentProductionProgress >= chemistryTableController.totalProductionDuration)
				{
					chemistryTableController.ProduceItem();
					UnityEngine.Debug.Log($"[CHEMISTRY] Progress: {chemistryTableController.currentProductionProgress:F1}/{chemistryTableController.totalProductionDuration:F1}s | Fuel: {chemistryTableController.remainingFuelTime:F1}s");
					chemistryTableController.NetworkcurrentProductionProgress = 0f;
					if (chemistryTableController.remainingFuelTime <= 0f && chemistryTableController.fuelSlotItems.Count > 0)
					{
						chemistryTableController.ConsumeFuelFromStack();
					}
					CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(chemistryTableController.currentRecipeItemName);
					if (collectableItemFromName == null || !chemistryTableController.CheckRecipeMatch(collectableItemFromName))
					{
						UnityEngine.Debug.Log("[CHEMISTRY] Malzeme bitti veya recipe geçersiz, production durduruluyor.");
						goto IL_016f;
					}
				}
				if (chemistryTableController.remainingFuelTime <= 0f)
				{
					if (chemistryTableController.fuelSlotItems.Count <= 0)
					{
						UnityEngine.Debug.LogWarning("[CHEMISTRY] Fuel bitti! Progress korunuyor.");
						goto IL_016f;
					}
					chemistryTableController.ConsumeFuelFromStack();
				}
			}
			else
			{
				_003C_003E1__state = -1;
				chemistryTableController.NetworkisProcessing = true;
				UnityEngine.Debug.Log($"[CHEMISTRY] Production başladı: {chemistryTableController.currentRecipeItemName} - Duration: {chemistryTableController.totalProductionDuration}s - Fuel: {chemistryTableController.remainingFuelTime}s");
			}
			if (chemistryTableController.remainingFuelTime > 0f)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_016f;
			IL_016f:
			chemistryTableController.NetworkisProcessing = false;
			UnityEngine.Debug.Log($"[CHEMISTRY] Production bitti - Progress: {chemistryTableController.currentProductionProgress:F1}s korundu");
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

	[Header("Chemistry Table Settings")]
	public int inputSlotCount = 4;

	[Header("Visual Effects")]
	public GameObject smokeParticle;

	public GameObject fireParticle;

	[SyncVar]
	public float remainingFuelTime;

	[SyncVar]
	public float maxFuelTime;

	public readonly SyncList<string> fuelSlotItems = new SyncList<string>();

	public readonly SyncList<string> inputItems = new SyncList<string>();

	public readonly SyncList<int> inputItemCounts = new SyncList<int>();

	[SyncVar]
	public string outputItemName = "";

	[SyncVar]
	public int outputItemCount;

	[SyncVar(hook = "OnProcessingChanged")]
	public bool isProcessing;

	[SyncVar]
	public string currentRecipeItemName = "";

	[SyncVar]
	public float currentProductionProgress;

	[SyncVar]
	public float totalProductionDuration;

	private Coroutine productionCoroutine;

	private bool isNetworkReady;

	private readonly Queue<Action> pendingOperations = new Queue<Action>();

	private int lastInputHash;

	[SerializeField]
	private Transform interactionParent;

	private ChemistryTableUIManager chemistryTableUI;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString chemistryLocalized;

	private string saveKey;

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

	public float currentFuelTime => remainingFuelTime;

	public float currentCookTime => currentProductionProgress;

	public float maxCookTime => totalProductionDuration;

	public float NetworkremainingFuelTime
	{
		get
		{
			return remainingFuelTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref remainingFuelTime, 1uL, null);
		}
	}

	public float NetworkmaxFuelTime
	{
		get
		{
			return maxFuelTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref maxFuelTime, 2uL, null);
		}
	}

	public string NetworkoutputItemName
	{
		get
		{
			return outputItemName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref outputItemName, 4uL, null);
		}
	}

	public int NetworkoutputItemCount
	{
		get
		{
			return outputItemCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref outputItemCount, 8uL, null);
		}
	}

	public bool NetworkisProcessing
	{
		get
		{
			return isProcessing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isProcessing, 16uL, OnProcessingChanged);
		}
	}

	public string NetworkcurrentRecipeItemName
	{
		get
		{
			return currentRecipeItemName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentRecipeItemName, 32uL, null);
		}
	}

	public float NetworkcurrentProductionProgress
	{
		get
		{
			return currentProductionProgress;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentProductionProgress, 64uL, null);
		}
	}

	public float NetworktotalProductionDuration
	{
		get
		{
			return totalProductionDuration;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref totalProductionDuration, 128uL, null);
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		StartCoroutine(WaitForNetworkAndProcessPending());
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		isNetworkReady = true;
		InitializeSlots();
	}

	private void Start()
	{
		PropBase component = GetComponent<PropBase>();
		if (component != null)
		{
			if (string.IsNullOrEmpty(component.uniqueID))
			{
				component.SetID();
			}
			saveKey = "ChemistryTable_" + component.uniqueID;
		}
		else
		{
			saveKey = $"ChemistryTable_{base.gameObject.name}_{base.transform.position.x}_{base.transform.position.z}";
		}
		if (base.isServer)
		{
			isNetworkReady = true;
			InitializeSlots();
		}
		UpdateParticles();
		chemistryTableUI = ChemistryTableUIManager.Instance;
		StartCoroutine(WaitForNetworkReadyAndLoad());
	}

	private IEnumerator WaitForNetworkReadyAndLoad()
	{
		NetworkIdentity netIdentity = GetComponent<NetworkIdentity>();
		while (netIdentity == null || (netIdentity.netId == 0 && !NetworkServer.active))
		{
			yield return new WaitForSeconds(0.1f);
		}
		isNetworkReady = true;
		LoadChemistryTableState();
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveChemistryTableState);
			Singleton<ES3SaveManager>.Instance.OnPreLoad.AddListener(LoadChemistryTableState);
		}
	}

	private IEnumerator WaitForNetworkAndProcessPending()
	{
		NetworkIdentity netIdentity = GetComponent<NetworkIdentity>();
		while (netIdentity.netId == 0)
		{
			yield return new WaitForSeconds(0.1f);
		}
		isNetworkReady = true;
		UnityEngine.Debug.Log($"ChemistryTableController network hazır: {base.name} - NetID: {netIdentity.netId}");
		while (pendingOperations.Count > 0)
		{
			pendingOperations.Dequeue()();
		}
		UpdateParticles();
	}

	[Server]
	private void InitializeSlots()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::InitializeSlots()' called when server was not active");
			return;
		}
		inputItems.Clear();
		inputItemCounts.Clear();
		for (int i = 0; i < inputSlotCount; i++)
		{
			inputItems.Add("");
			inputItemCounts.Add(0);
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (IsActive)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(chemistryLocalized, "Chemistry"));
			if (Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) && !Singleton<MainUIManager>.Instance.isInGamePanelOpened)
			{
				Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(ChemistryTableUIManager.Instance);
				ChemistryTableUIManager.Instance.OpenChemistryTable(this);
			}
		}
	}

	public void StopInteract()
	{
		InteractionPanel.Instance.HidePanel();
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
		if (ChemistryTableUIManager.Instance == null)
		{
			return false;
		}
		return ChemistryTableUIManager.Instance.fuelItems.Exists((FuelData x) => x.item == item);
	}

	public bool HasFuel()
	{
		return remainingFuelTime > 0f;
	}

	public bool CanAddFuel()
	{
		return true;
	}

	public void TryAddFuel(string itemName, int count)
	{
		if (count <= 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			ProcessNetworkOperation(delegate
			{
				AddFuelInternal(itemName);
			});
		}
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

	[Command(requiresAuthority = false)]
	private void CmdAddFuel(string itemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		SendCommandInternal("System.Void ChemistryTableController::CmdAddFuel(System.String)", -1971150342, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddFuel(string itemName)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ServerAddFuel(System.String)' called when server was not active");
		}
		else
		{
			if (ChemistryTableUIManager.Instance == null)
			{
				return;
			}
			CollectableItemData fuelData = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(itemName);
			if (ChemistryTableUIManager.Instance.fuelItems.Find((FuelData x) => x.item == fuelData) != null)
			{
				fuelSlotItems.Add(itemName);
				UnityEngine.Debug.Log($"Fuel eklendi: {itemName} - Stack: {fuelSlotItems.Count}");
				if (!isProcessing && !string.IsNullOrEmpty(currentRecipeItemName))
				{
					TryResumeProduction();
				}
			}
		}
	}

	[Server]
	private void ConsumeFuelFromStack()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ConsumeFuelFromStack()' called when server was not active");
		}
		else if (fuelSlotItems.Count > 0 && !(ChemistryTableUIManager.Instance == null))
		{
			string text = fuelSlotItems[0];
			fuelSlotItems.RemoveAt(0);
			CollectableItemData fuelData = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
			FuelData fuelData2 = ChemistryTableUIManager.Instance.fuelItems.Find((FuelData x) => x.item == fuelData);
			if (fuelData2 != null)
			{
				NetworkremainingFuelTime = remainingFuelTime + fuelData2.burningTime;
				NetworkmaxFuelTime = remainingFuelTime;
				UnityEngine.Debug.Log($"Fuel tüketildi: {text} - Süre: {fuelData2.burningTime}s - Toplam: {remainingFuelTime}s");
			}
		}
	}

	public void TryRemoveFuel()
	{
		ProcessNetworkOperation(delegate
		{
			RemoveFuelInternal();
		});
	}

	private void RemoveFuelInternal()
	{
		if (base.isServer)
		{
			ServerRemoveFuel();
		}
		else
		{
			CmdRemoveFuel();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRemoveFuel()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ChemistryTableController::CmdRemoveFuel()", -1516224501, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerRemoveFuel()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ServerRemoveFuel()' called when server was not active");
			return;
		}
		if (fuelSlotItems.Count > 0)
		{
			fuelSlotItems.RemoveAt(fuelSlotItems.Count - 1);
		}
		if (fuelSlotItems.Count == 0 && remainingFuelTime <= 0f)
		{
			NetworkremainingFuelTime = 0f;
			NetworkmaxFuelTime = 0f;
		}
	}

	public CollectableItemData GetFuelItemData()
	{
		if (fuelSlotItems.Count > 0)
		{
			return NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(fuelSlotItems[0]);
		}
		return null;
	}

	public void TryAddInputItem(int slotIndex, string itemName, int count)
	{
		if (slotIndex >= 0 && slotIndex < inputSlotCount)
		{
			ProcessNetworkOperation(delegate
			{
				AddInputItemInternal(slotIndex, itemName, count);
			});
		}
	}

	private void AddInputItemInternal(int slotIndex, string itemName, int count)
	{
		if (base.isServer)
		{
			ServerAddInputItem(slotIndex, itemName, count);
		}
		else
		{
			CmdAddInputItem(slotIndex, itemName, count);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddInputItem(int slotIndex, string itemName, int count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(slotIndex);
		writer.WriteString(itemName);
		writer.WriteInt(count);
		SendCommandInternal("System.Void ChemistryTableController::CmdAddInputItem(System.Int32,System.String,System.Int32)", 18486269, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddInputItem(int slotIndex, string itemName, int count)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ServerAddInputItem(System.Int32,System.String,System.Int32)' called when server was not active");
		}
		else if (slotIndex >= 0 && slotIndex < inputItems.Count && !isProcessing)
		{
			inputItems[slotIndex] = itemName;
			inputItemCounts[slotIndex] = count;
			UnityEngine.Debug.Log($"Input slot {slotIndex}: {itemName} x{count}");
			UpdateInputHash();
		}
	}

	public void TryRemoveInputItem(int slotIndex)
	{
		if (slotIndex >= 0 && slotIndex < inputSlotCount)
		{
			ProcessNetworkOperation(delegate
			{
				RemoveInputItemInternal(slotIndex);
			});
		}
	}

	private void RemoveInputItemInternal(int slotIndex)
	{
		if (base.isServer)
		{
			ServerRemoveInputItem(slotIndex);
		}
		else
		{
			CmdRemoveInputItem(slotIndex);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRemoveInputItem(int slotIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(slotIndex);
		SendCommandInternal("System.Void ChemistryTableController::CmdRemoveInputItem(System.Int32)", 475015099, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerRemoveInputItem(int slotIndex)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ServerRemoveInputItem(System.Int32)' called when server was not active");
		}
		else if (slotIndex >= 0 && slotIndex < inputItems.Count && !isProcessing)
		{
			inputItems[slotIndex] = "";
			inputItemCounts[slotIndex] = 0;
			UpdateInputHash();
		}
	}

	public void TryReduceInputItemCount(int slotIndex, int newCount)
	{
		if (slotIndex >= 0 && slotIndex < inputSlotCount)
		{
			ProcessNetworkOperation(delegate
			{
				ReduceInputItemCountInternal(slotIndex, newCount);
			});
		}
	}

	private void ReduceInputItemCountInternal(int slotIndex, int newCount)
	{
		if (base.isServer)
		{
			ServerReduceInputItemCount(slotIndex, newCount);
		}
		else
		{
			CmdReduceInputItemCount(slotIndex, newCount);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdReduceInputItemCount(int slotIndex, int newCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(slotIndex);
		writer.WriteInt(newCount);
		SendCommandInternal("System.Void ChemistryTableController::CmdReduceInputItemCount(System.Int32,System.Int32)", 1861978877, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerReduceInputItemCount(int slotIndex, int newCount)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ServerReduceInputItemCount(System.Int32,System.Int32)' called when server was not active");
		}
		else
		{
			if (slotIndex < 0 || slotIndex >= inputItems.Count || newCount >= inputItemCounts[slotIndex])
			{
				return;
			}
			if (isProcessing)
			{
				int neededAmountForInputSlot = GetNeededAmountForInputSlot(slotIndex);
				if (newCount < neededAmountForInputSlot)
				{
					return;
				}
			}
			inputItemCounts[slotIndex] = newCount;
			if (newCount <= 0)
			{
				inputItems[slotIndex] = "";
				inputItemCounts[slotIndex] = 0;
			}
			UnityEngine.Debug.Log($"Input slot {slotIndex} count azaltıldı: {newCount}");
		}
	}

	public int GetNeededAmountForInputSlot(int slotIndex)
	{
		if (!isProcessing || string.IsNullOrEmpty(currentRecipeItemName))
		{
			return 0;
		}
		if (slotIndex < 0 || slotIndex >= inputItems.Count)
		{
			return 0;
		}
		string text = inputItems[slotIndex];
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(currentRecipeItemName);
		if (collectableItemFromName == null)
		{
			return inputItemCounts[slotIndex];
		}
		CollectableItemData collectableItemFromName2 = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
		int num = 0;
		foreach (CostData costDatum in collectableItemFromName.costData)
		{
			if (costDatum.item == collectableItemFromName2)
			{
				num = costDatum.cost;
				break;
			}
		}
		if (num == 0)
		{
			return 0;
		}
		int num2 = 0;
		for (int i = 0; i < inputItems.Count; i++)
		{
			if (i != slotIndex && !string.IsNullOrEmpty(inputItems[i]) && NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(inputItems[i]) == collectableItemFromName2)
			{
				num2 += inputItemCounts[i];
			}
		}
		return Mathf.Max(0, num - num2);
	}

	[Server]
	private void UpdateInputHash()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::UpdateInputHash()' called when server was not active");
			return;
		}
		int num = CalculateInputHash();
		if (num != lastInputHash && isProcessing)
		{
			UnityEngine.Debug.LogWarning("[CHEMISTRY] Input değişti! Production progress sıfırlanıyor.");
			ResetProduction();
		}
		lastInputHash = num;
	}

	private int CalculateInputHash()
	{
		int num = 0;
		for (int i = 0; i < inputItems.Count; i++)
		{
			if (!string.IsNullOrEmpty(inputItems[i]))
			{
				num ^= inputItems[i].GetHashCode() ^ (inputItemCounts[i] * 397);
			}
		}
		return num;
	}

	public bool HasOutput()
	{
		if (!string.IsNullOrEmpty(outputItemName))
		{
			return outputItemCount > 0;
		}
		return false;
	}

	public void TryTakeOutput()
	{
		ProcessNetworkOperation(delegate
		{
			TakeOutputInternal();
		});
	}

	private void TakeOutputInternal()
	{
		if (base.isServer)
		{
			ServerTakeOutput();
		}
		else
		{
			CmdTakeOutput();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTakeOutput()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ChemistryTableController::CmdTakeOutput()", 2005352601, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTakeOutput()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ServerTakeOutput()' called when server was not active");
		}
		else if (HasOutput())
		{
			NetworkoutputItemName = "";
			NetworkoutputItemCount = 0;
			UnityEngine.Debug.Log("Output alındı");
		}
	}

	public CollectableItemData GetOutputItemData()
	{
		if (HasOutput())
		{
			return NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(outputItemName);
		}
		return null;
	}

	public CollectableItemData GetValidRecipe()
	{
		if (ChemistryTableUIManager.Instance == null)
		{
			return null;
		}
		foreach (CraftSystemCategorizer receiptCategory in ChemistryTableUIManager.Instance.receiptCategories)
		{
			foreach (CollectableItemData itemData in receiptCategory.itemDatas)
			{
				if (CheckRecipeMatch(itemData))
				{
					return itemData;
				}
			}
		}
		return null;
	}

	private bool CheckRecipeMatch(CollectableItemData recipeData)
	{
		if (recipeData == null || recipeData.costData.Count == 0)
		{
			return false;
		}
		foreach (CostData costDatum in recipeData.costData)
		{
			int num = 0;
			for (int i = 0; i < inputItems.Count; i++)
			{
				if (!string.IsNullOrEmpty(inputItems[i]) && NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(inputItems[i]) == costDatum.item)
				{
					num += inputItemCounts[i];
				}
			}
			if (num < costDatum.cost)
			{
				return false;
			}
		}
		return true;
	}

	public bool CanStartCooking()
	{
		if (HasOutput())
		{
			return false;
		}
		if (!HasFuel() && fuelSlotItems.Count == 0)
		{
			return false;
		}
		if (isProcessing)
		{
			return false;
		}
		return GetValidRecipe() != null;
	}

	public void TryStartCooking()
	{
		ProcessNetworkOperation(delegate
		{
			StartCookingInternal();
		});
	}

	private void StartCookingInternal()
	{
		if (base.isServer)
		{
			ServerStartCooking();
		}
		else
		{
			CmdStartCooking();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdStartCooking()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ChemistryTableController::CmdStartCooking()", -760568567, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerStartCooking()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ServerStartCooking()' called when server was not active");
		}
		else
		{
			if (!CanStartCooking())
			{
				return;
			}
			CollectableItemData validRecipe = GetValidRecipe();
			if (validRecipe == null)
			{
				return;
			}
			if (remainingFuelTime <= 0f)
			{
				ConsumeFuelFromStack();
			}
			if (remainingFuelTime <= 0f)
			{
				UnityEngine.Debug.LogWarning("[CHEMISTRY] Fuel yok, pişirme başlatılamıyor!");
				return;
			}
			NetworkcurrentRecipeItemName = validRecipe.itemName;
			NetworktotalProductionDuration = validRecipe.productionDuration;
			NetworkcurrentProductionProgress = 0f;
			lastInputHash = CalculateInputHash();
			if (productionCoroutine != null)
			{
				StopCoroutine(productionCoroutine);
			}
			productionCoroutine = StartCoroutine(ProductionCoroutine());
		}
	}

	[Server]
	private void TryResumeProduction()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::TryResumeProduction()' called when server was not active");
		}
		else
		{
			if (isProcessing || string.IsNullOrEmpty(currentRecipeItemName) || (!HasFuel() && fuelSlotItems.Count == 0))
			{
				return;
			}
			if (remainingFuelTime <= 0f)
			{
				ConsumeFuelFromStack();
			}
			if (remainingFuelTime <= 0f)
			{
				return;
			}
			CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(currentRecipeItemName);
			if (collectableItemFromName == null || !CheckRecipeMatch(collectableItemFromName))
			{
				ResetProduction();
				return;
			}
			if (productionCoroutine != null)
			{
				StopCoroutine(productionCoroutine);
			}
			productionCoroutine = StartCoroutine(ProductionCoroutine());
		}
	}

	[IteratorStateMachine(typeof(_003CProductionCoroutine_003Ed__86))]
	[Server]
	private IEnumerator ProductionCoroutine()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator ChemistryTableController::ProductionCoroutine()' called when server was not active");
			return null;
		}
		return new _003CProductionCoroutine_003Ed__86(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	private void ProduceItem()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ProduceItem()' called when server was not active");
			return;
		}
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(currentRecipeItemName);
		if (collectableItemFromName == null)
		{
			return;
		}
		foreach (CostData costDatum in collectableItemFromName.costData)
		{
			int num = costDatum.cost;
			for (int i = 0; i < inputItems.Count; i++)
			{
				if (num <= 0)
				{
					break;
				}
				if (!string.IsNullOrEmpty(inputItems[i]) && NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(inputItems[i]) == costDatum.item)
				{
					int num2 = Mathf.Min(inputItemCounts[i], num);
					inputItemCounts[i] -= num2;
					num -= num2;
					if (inputItemCounts[i] <= 0)
					{
						inputItems[i] = "";
						inputItemCounts[i] = 0;
					}
				}
			}
		}
		int productionCount = collectableItemFromName.productionCount;
		if (string.IsNullOrEmpty(outputItemName))
		{
			NetworkoutputItemName = collectableItemFromName.itemName;
			NetworkoutputItemCount = productionCount;
		}
		else if (outputItemName == collectableItemFromName.itemName)
		{
			NetworkoutputItemCount = outputItemCount + productionCount;
		}
		UnityEngine.Debug.Log($"[CHEMISTRY] Ürün üretildi: {collectableItemFromName.itemName} x{productionCount} - Toplam output: {outputItemCount}");
		lastInputHash = CalculateInputHash();
	}

	[Server]
	private void ResetProduction()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ChemistryTableController::ResetProduction()' called when server was not active");
			return;
		}
		NetworkcurrentRecipeItemName = "";
		NetworkcurrentProductionProgress = 0f;
		NetworktotalProductionDuration = 0f;
		NetworkisProcessing = false;
		if (productionCoroutine != null)
		{
			StopCoroutine(productionCoroutine);
			productionCoroutine = null;
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

	private void UpdateParticles()
	{
		if (smokeParticle != null)
		{
			smokeParticle.SetActive(isProcessing);
		}
		if (fireParticle != null)
		{
			fireParticle.SetActive(isProcessing);
		}
	}

	private void OnProcessingChanged(bool oldValue, bool newValue)
	{
		UpdateParticles();
	}

	private void LoadChemistryTableState()
	{
		if (!base.isServer)
		{
			return;
		}
		ChemistryTableSaveData chemistryTableSaveData = Singleton<ES3SaveManager>.Instance.LoadData<ChemistryTableSaveData>(saveKey);
		if (chemistryTableSaveData != null)
		{
			UnityEngine.Debug.Log("[ChemistryTable] Loading state from save: " + saveKey);
			fuelSlotItems.Clear();
			foreach (string fuelSlotItem in chemistryTableSaveData.fuelSlotItems)
			{
				fuelSlotItems.Add(fuelSlotItem);
			}
			NetworkremainingFuelTime = chemistryTableSaveData.remainingFuelTime;
			NetworkmaxFuelTime = chemistryTableSaveData.maxFuelTime;
			for (int i = 0; i < chemistryTableSaveData.inputItems.Count && i < inputItems.Count; i++)
			{
				inputItems[i] = chemistryTableSaveData.inputItems[i];
				inputItemCounts[i] = chemistryTableSaveData.inputItemCounts[i];
			}
			NetworkoutputItemName = chemistryTableSaveData.outputItemName;
			NetworkoutputItemCount = chemistryTableSaveData.outputItemCount;
			NetworkcurrentRecipeItemName = chemistryTableSaveData.currentRecipeItemName;
			NetworkcurrentProductionProgress = chemistryTableSaveData.currentProductionProgress;
			NetworktotalProductionDuration = chemistryTableSaveData.totalProductionDuration;
			lastInputHash = CalculateInputHash();
			if (chemistryTableSaveData.isProcessing && remainingFuelTime > 0f && !string.IsNullOrEmpty(currentRecipeItemName))
			{
				UnityEngine.Debug.Log($"[ChemistryTable] Resuming production from save - Progress: {currentProductionProgress}/{totalProductionDuration}");
				TryResumeProduction();
			}
		}
		else
		{
			UnityEngine.Debug.Log("[ChemistryTable] No saved state found for " + saveKey);
		}
	}

	private void SaveChemistryTableState()
	{
		if (base.isServer)
		{
			ChemistryTableSaveData value = new ChemistryTableSaveData
			{
				fuelSlotItems = new List<string>(fuelSlotItems),
				remainingFuelTime = remainingFuelTime,
				maxFuelTime = maxFuelTime,
				inputItems = new List<string>(inputItems),
				inputItemCounts = new List<int>(inputItemCounts),
				outputItemName = outputItemName,
				outputItemCount = outputItemCount,
				currentRecipeItemName = currentRecipeItemName,
				currentProductionProgress = currentProductionProgress,
				totalProductionDuration = totalProductionDuration,
				isProcessing = isProcessing
			};
			Singleton<ES3SaveManager>.Instance.SaveData(saveKey, value);
			UnityEngine.Debug.Log("[ChemistryTable] State saved: " + saveKey);
		}
	}

	private void OnDestroy()
	{
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(SaveChemistryTableState);
			Singleton<ES3SaveManager>.Instance.OnPreLoad.RemoveListener(LoadChemistryTableState);
		}
		if (productionCoroutine != null && base.isServer)
		{
			StopCoroutine(productionCoroutine);
		}
	}

	public ChemistryTableController()
	{
		InitSyncObject(fuelSlotItems);
		InitSyncObject(inputItems);
		InitSyncObject(inputItemCounts);
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
			((ChemistryTableController)obj).UserCode_CmdAddFuel__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdRemoveFuel()
	{
		ServerRemoveFuel();
	}

	protected static void InvokeUserCode_CmdRemoveFuel(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRemoveFuel called on client.");
		}
		else
		{
			((ChemistryTableController)obj).UserCode_CmdRemoveFuel();
		}
	}

	protected void UserCode_CmdAddInputItem__Int32__String__Int32(int slotIndex, string itemName, int count)
	{
		ServerAddInputItem(slotIndex, itemName, count);
	}

	protected static void InvokeUserCode_CmdAddInputItem__Int32__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdAddInputItem called on client.");
		}
		else
		{
			((ChemistryTableController)obj).UserCode_CmdAddInputItem__Int32__String__Int32(reader.ReadInt(), reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdRemoveInputItem__Int32(int slotIndex)
	{
		ServerRemoveInputItem(slotIndex);
	}

	protected static void InvokeUserCode_CmdRemoveInputItem__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRemoveInputItem called on client.");
		}
		else
		{
			((ChemistryTableController)obj).UserCode_CmdRemoveInputItem__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdReduceInputItemCount__Int32__Int32(int slotIndex, int newCount)
	{
		ServerReduceInputItemCount(slotIndex, newCount);
	}

	protected static void InvokeUserCode_CmdReduceInputItemCount__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdReduceInputItemCount called on client.");
		}
		else
		{
			((ChemistryTableController)obj).UserCode_CmdReduceInputItemCount__Int32__Int32(reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdTakeOutput()
	{
		ServerTakeOutput();
	}

	protected static void InvokeUserCode_CmdTakeOutput(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTakeOutput called on client.");
		}
		else
		{
			((ChemistryTableController)obj).UserCode_CmdTakeOutput();
		}
	}

	protected void UserCode_CmdStartCooking()
	{
		ServerStartCooking();
	}

	protected static void InvokeUserCode_CmdStartCooking(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdStartCooking called on client.");
		}
		else
		{
			((ChemistryTableController)obj).UserCode_CmdStartCooking();
		}
	}

	static ChemistryTableController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ChemistryTableController), "System.Void ChemistryTableController::CmdAddFuel(System.String)", InvokeUserCode_CmdAddFuel__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChemistryTableController), "System.Void ChemistryTableController::CmdRemoveFuel()", InvokeUserCode_CmdRemoveFuel, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChemistryTableController), "System.Void ChemistryTableController::CmdAddInputItem(System.Int32,System.String,System.Int32)", InvokeUserCode_CmdAddInputItem__Int32__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChemistryTableController), "System.Void ChemistryTableController::CmdRemoveInputItem(System.Int32)", InvokeUserCode_CmdRemoveInputItem__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChemistryTableController), "System.Void ChemistryTableController::CmdReduceInputItemCount(System.Int32,System.Int32)", InvokeUserCode_CmdReduceInputItemCount__Int32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChemistryTableController), "System.Void ChemistryTableController::CmdTakeOutput()", InvokeUserCode_CmdTakeOutput, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChemistryTableController), "System.Void ChemistryTableController::CmdStartCooking()", InvokeUserCode_CmdStartCooking, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(remainingFuelTime);
			writer.WriteFloat(maxFuelTime);
			writer.WriteString(outputItemName);
			writer.WriteInt(outputItemCount);
			writer.WriteBool(isProcessing);
			writer.WriteString(currentRecipeItemName);
			writer.WriteFloat(currentProductionProgress);
			writer.WriteFloat(totalProductionDuration);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(remainingFuelTime);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(maxFuelTime);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteString(outputItemName);
		}
		if ((base.syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteInt(outputItemCount);
		}
		if ((base.syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteBool(isProcessing);
		}
		if ((base.syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteString(currentRecipeItemName);
		}
		if ((base.syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteFloat(currentProductionProgress);
		}
		if ((base.syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteFloat(totalProductionDuration);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref remainingFuelTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref maxFuelTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref outputItemName, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref outputItemCount, null, reader.ReadInt());
			GeneratedSyncVarDeserialize(ref isProcessing, OnProcessingChanged, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref currentRecipeItemName, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref currentProductionProgress, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref totalProductionDuration, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref remainingFuelTime, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref maxFuelTime, null, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref outputItemName, null, reader.ReadString());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref outputItemCount, null, reader.ReadInt());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isProcessing, OnProcessingChanged, reader.ReadBool());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentRecipeItemName, null, reader.ReadString());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentProductionProgress, null, reader.ReadFloat());
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref totalProductionDuration, null, reader.ReadFloat());
		}
	}
}
