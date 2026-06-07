using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AudioSystem;
using BrewGame.SaveSystem.Integration;
using Brewery.Buffs;
using Brewery.Items;
using Brewery.Skills;
using InteractionSystem;
using InventorySystem;
using PlacementSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stations
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public abstract class BaseBreweryStation : NetworkBehaviour, IInteractable, ISaveable
	{
		[Header("Station Settings")]
		[SerializeField]
		private string stationName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private float processingTimeSeconds;

		[Header("Persistence")]
		[Tooltip("Unique ID for save/load. Auto-generated if empty. DO NOT change after first save!")]
		[SerializeField]
		private string uniqueStationId;

		private readonly NetworkVariable<StationState> stationState;

		private readonly NetworkVariable<float> processingProgress;

		private readonly NetworkVariable<ulong> currentUserId;

		public const ulong NO_USER = ulong.MaxValue;

		protected NetworkList<StationSlotData> inputSlots;

		protected NetworkList<StationSlotData> outputSlots;

		private float processingTimer;

		private float employeeSpeedMultiplier;

		private ulong processingOperatorId;

		protected StationUpgradeManager upgradeManager;

		protected PlacedObject placedObject;

		protected ulong ProcessingOperatorId => 0uL;

		public string StationName => null;

		public string UniqueStationId => null;

		public StationState State => default(StationState);

		public float Progress => 0f;

		public int InputSlotCount => 0;

		public NetworkList<StationSlotData> InputSlotData => null;

		public NetworkList<StationSlotData> OutputSlotData => null;

		protected StationUpgradeManager UpgradeManager => null;

		protected float ProcessingTimeSeconds => 0f;

		public float BaseProcessingTime => 0f;

		public ulong CurrentUserId => 0uL;

		public bool IsAvailable => false;

		public bool HasOutput => false;

		public virtual string SaveableId => null;

		public int SavePriority => 0;

		public event Action<BaseBreweryStation> OnStationStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<BaseBreweryStation> OnSlotsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public override void OnDestroy()
		{
		}

		protected virtual void Update()
		{
		}

		public bool IsUserClient(ulong clientId)
		{
			return false;
		}

		protected void SetStationStateInternal(StationState newState)
		{
		}

		protected void SetProcessingProgressInternal(float value)
		{
		}

		protected void NotifySlotsChangedInternal()
		{
		}

		public void ClaimStation(ulong clientId)
		{
		}

		public void ReleaseStation(ulong clientId)
		{
		}

		public void ForceReleaseStation()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ClaimStationServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ReleaseStationServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		protected virtual void AdvanceProcessingTimer(float seconds)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void AdvanceProcessingTimerServerRpc(float seconds, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		protected virtual SkillType? GetMinigameTimeSkill()
		{
			return null;
		}

		protected virtual BuffType? GetMinigameTimeBuff()
		{
			return null;
		}

		protected virtual void OnProcessingStarted(ulong operatorClientId)
		{
		}

		public void NotifySlotsChangedExternal()
		{
		}

		public void SetStationStateExternal(StationState newState)
		{
		}

		public void SetProcessingProgressExternal(float value)
		{
		}

		public int ServerLoadInput(int slotIndex, string itemId, int quantity)
		{
			return 0;
		}

		public void ServerStartProcessing(ulong employeeId = 0uL)
		{
		}

		public void ServerStartProcessing(ulong employeeId, float speedMultiplier)
		{
		}

		public bool ServerCollectOutput(out string outItemId, out int outQuantity)
		{
			outItemId = null;
			outQuantity = default(int);
			return false;
		}

		protected virtual bool CanAcceptMoreOutput()
		{
			return false;
		}

		private void EnsureSlotList(NetworkList<StationSlotData> list, int count)
		{
		}

		protected void NotifyStateChanged()
		{
		}

		private void HandleStateChanged(StationState previous, StationState current)
		{
		}

		private void HandleProgressChanged(float previous, float current)
		{
		}

		private void HandleSlotsChanged(NetworkListEvent<StationSlotData> changeEvent)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestLoadInputServerRpc(int slotIndex, int desiredQuantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestReturnInputServerRpc(int slotIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void StartProcessingServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void CollectOutputServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void CompleteProcessingInternal()
		{
		}

		protected void SetOutput(string itemId, int quantity)
		{
		}

		protected void ClearInputSlots()
		{
		}

		protected StationSlotData GetInputSlot(int index)
		{
			return default(StationSlotData);
		}

		protected abstract int GetInputSlotCount();

		protected abstract int GetOutputSlotCount();

		protected abstract bool ValidateInputs();

		protected abstract void ConsumeInputs();

		protected abstract void GenerateOutput();

		protected abstract string GetInputItemId(int slotIndex);

		protected abstract int GetInputSlotCapacity(int slotIndex);

		protected abstract bool IsValidInputItem(int slotIndex, Item item);

		protected abstract string GetOutputItemId();

		protected abstract int GetOutputQuantity();

		protected abstract string GetSlotDisplayName(int slotIndex);

		protected virtual string GetQuestStationId()
		{
			return null;
		}

		protected virtual StationSoundType? GetManualProcessingSoundType()
		{
			return null;
		}

		protected virtual bool CanAcceptInventoryItem(int slotIndex, InventoryManager sourceInventory, int sourceSlotIndex, InventorySlot sourceSlot)
		{
			return false;
		}

		protected virtual void OnBeforeInventoryItemRemovedForInput(int slotIndex, InventoryManager sourceInventory, int sourceSlotIndex, Item item, int quantity)
		{
		}

		protected virtual void OnInputReturned(int slotIndex, InventoryManager inventory, Item item, int quantityReturned, int addedSlotIndex, string itemId)
		{
		}

		protected virtual void OnOutputCollected(InventoryManager collector, Item item, int quantity, int slotIndex)
		{
		}

		public virtual void CompleteCurrentStepForSleep()
		{
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		protected virtual bool IsUIShowingForLocalPlayer()
		{
			return false;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public virtual void Interact(ulong clientId)
		{
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public bool ShouldRemainFocused(ulong clientId)
		{
			return false;
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		public string GetSlotLabel(int slotIndex)
		{
			return null;
		}

		public string GetInputItemIdentifier(int slotIndex)
		{
			return null;
		}

		public StationSlotData GetOutputSlot()
		{
			return default(StationSlotData);
		}

		public bool InputsReady()
		{
			return false;
		}

		protected virtual bool ValidateInputsClient()
		{
			return false;
		}

		public virtual int GetInputRequirement(int slotIndex)
		{
			return 0;
		}

		private Dictionary<int, int> CaptureItemQuantities(InventoryManager inventory, Item item)
		{
			return null;
		}

		private int FindNewItemSlot(InventoryManager inventory, Item item, Dictionary<int, int> before)
		{
			return 0;
		}

		private string GetStableStationId()
		{
			return null;
		}

		private string GetHierarchyPath(Transform t)
		{
			return null;
		}

		private int GetDeterministicHashCode(string str)
		{
			return 0;
		}

		public virtual Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public virtual void RestoreState(Dictionary<string, object> state)
		{
		}

		protected virtual List<Dictionary<string, object>> CaptureOutputBarrelMetadata()
		{
			return null;
		}

		protected virtual void RestoreOutputBarrelMetadata(List<object> metadataList)
		{
		}

		protected Dictionary<string, object> SerializeBarrelMetadata(BarrelMetadata meta, int index)
		{
			return null;
		}

		protected BarrelMetadata DeserializeBarrelMetadata(Dictionary<string, object> data)
		{
			return default(BarrelMetadata);
		}

		protected Dictionary<string, object> ConvertToStringObjectDict(object obj)
		{
			return null;
		}

		private void GenerateRuntimeUniqueId()
		{
		}

		private void EnsureUniqueId()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4156513612(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1457371296(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3310436276(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_338826285(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2727586210(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1728823821(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1408371240(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
