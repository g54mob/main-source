using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CraftingSystem.Networking;
using InventorySystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace CraftingSystem
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class CraftingTableManager : NetworkBehaviour
	{
		private const ulong NoUserId = ulong.MaxValue;

		private const float ProgressSyncThreshold = 0.01f;

		[Header("Table Configuration")]
		[SerializeField]
		private CraftingTableType tableType;

		[SerializeField]
		private string tableName;

		[SerializeField]
		private CraftingTableConfiguration configuration;

		[SerializeField]
		private bool allowVehicleInventoryAccess;

		[SerializeField]
		private VehicleInventoryManager linkedVehicleInventory;

		[SerializeField]
		private Transform itemDisplayPoint;

		[Header("Capacity")]
		[SerializeField]
		[Min(1f)]
		private int inputSlots;

		[SerializeField]
		[Min(1f)]
		private int outputSlots;

		[Header("Animation")]
		[SerializeField]
		private Animator tableAnimator;

		[SerializeField]
		private ParticleSystem craftingEffect;

		private readonly NetworkVariable<FixedString4096Bytes> tableState;

		private readonly NetworkVariable<bool> isCrafting;

		private readonly NetworkVariable<float> craftingProgress;

		private readonly NetworkVariable<FixedString128Bytes> currentRecipeName;

		private readonly NetworkVariable<ulong> currentUser;

		private InventorySlot[] inputBuffer;

		private InventorySlot[] outputBuffer;

		private CraftingRecipe currentRecipe;

		private float craftTimer;

		private float craftDuration;

		private float lastSyncedProgress;

		private readonly List<CraftingRecipe> sharedRecipeCache;

		public CraftingTableType TableType => default(CraftingTableType);

		public string TableName => null;

		public bool IsInUse => false;

		public ulong CurrentUserId => 0uL;

		public CraftingRecipe CurrentRecipe => null;

		public IReadOnlyList<InventorySlot> InputSlots => null;

		public IReadOnlyList<InventorySlot> OutputSlots => null;

		public VehicleInventoryManager VehicleInventory => null;

		public bool IsCraftingActive => false;

		public float CurrentProgress => 0f;

		public bool CanAccessVehicleInventory => false;

		public event Action<int, InventorySlot> OnInputSlotChanged
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

		public event Action<int, InventorySlot> OnOutputSlotChanged
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

		public event Action<CraftingRecipe> OnRecipeChanged
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

		public event Action<float> OnCraftingProgressChanged
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

		public event Action<bool> OnCraftingStateChanged
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

		public event Action<CraftingTableState> OnTableStateReceived
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

		public event Action<ulong> OnCurrentUserChanged
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

		public void RequestCraft(CraftingRecipe recipe)
		{
		}

		public void RequestCancelCraft()
		{
		}

		public void RequestDepositFromInventory(int playerSlotIndex, int tableSlotIndex, int quantity)
		{
		}

		public void RequestWithdrawToInventory(int tableSlotIndex, int quantity)
		{
		}

		public void RequestCollectOutput(int outputSlotIndex, int quantity)
		{
		}

		public void RequestCollectAllOutputs()
		{
		}

		public void RequestReleaseSession()
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void Update()
		{
		}

		public IReadOnlyList<CraftingRecipe> GetAvailableRecipes()
		{
			return null;
		}

		public bool TryBeginSession(ulong clientId)
		{
			return false;
		}

		public void EndSession(ulong clientId)
		{
		}

		public bool TryStartCrafting(CraftingRecipe recipe, ulong requesterClientId)
		{
			return false;
		}

		public void CancelCrafting()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCraftServerRpc(string recipeName, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCancelCraftServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestTransferFromInventoryServerRpc(int playerSlotIndex, int tableSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawToInventoryServerRpc(int tableSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCollectOutputServerRpc(int outputSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCollectAllOutputsServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestReleaseTableServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void CompleteCrafting()
		{
		}

		private void ConsumeIngredients(CraftingRecipe recipe)
		{
		}

		private void ProduceOutputs(CraftingRecipe recipe)
		{
		}

		private bool InputMeetsRecipe(CraftingRecipe recipe)
		{
			return false;
		}

		private bool HasOutputCapacity(CraftingRecipe recipe)
		{
			return false;
		}

		private void InitializeFromConfiguration()
		{
		}

		private void EnsureBuffers()
		{
		}

		private void BroadcastState()
		{
		}

		private CraftingTableState BuildStateSnapshot()
		{
			return default(CraftingTableState);
		}

		private void ApplyNetworkState(CraftingTableState state)
		{
		}

		private void ApplySlotData(InventorySlot[] buffer, CraftingTableSlotData slotData, int index, Action<int, InventorySlot> callback)
		{
		}

		private void EnsureBufferSize(ref InventorySlot[] buffer, int length)
		{
		}

		private void HandleTableStateChanged(FixedString4096Bytes previous, FixedString4096Bytes current)
		{
		}

		private void HandleProgressChanged(float previous, float current)
		{
		}

		private void HandleIsCraftingChanged(bool previous, bool current)
		{
		}

		private void HandleRecipeNameChanged(FixedString128Bytes previous, FixedString128Bytes current)
		{
		}

		private void HandleCurrentUserChanged(ulong previous, ulong current)
		{
		}

		private void HandleClientDisconnected(ulong clientId)
		{
		}

		private InventoryManager ResolvePlayerInventory(ulong clientId)
		{
			return null;
		}

		private InventorySlot GetSlot(InventorySlot[] buffer, int index)
		{
			return null;
		}

		private int ResolveInputSlotForItem(Item item, int requestedSlot)
		{
			return 0;
		}

		private int AddItemToSlots(InventorySlot[] buffer, Item item, int quantity, int preferredSlot, Action<int, InventorySlot> callback)
		{
			return 0;
		}

		private int AddToSingleSlot(InventorySlot[] buffer, Item item, int quantity, int slotIndex, Action<int, InventorySlot> callback)
		{
			return 0;
		}

		private int RemoveFromSlot(InventorySlot[] buffer, int slotIndex, int quantity, Action<int, InventorySlot> callback)
		{
			return 0;
		}

		private void PlayCraftingVisuals()
		{
		}

		private void StopCraftingVisuals()
		{
		}

		[ClientRpc]
		private void NotifyBufferFullClientRpc(string stationName, string itemName, int lostAmount)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1932046590(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1381448706(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1496321266(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_240890374(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1239346904(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1627452207(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3701823388(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2255154324(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
