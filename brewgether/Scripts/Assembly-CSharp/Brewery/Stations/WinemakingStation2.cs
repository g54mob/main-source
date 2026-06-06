using Brewery.Controls3D;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stations
{
	public class WinemakingStation2 : BaseBreweryStation
	{
		[Header("Tablet")]
		[Tooltip("The 3D tablet child attached to this station")]
		[SerializeField]
		private WinemakingTablet3D tablet;

		private const int SlotBarrel = 0;

		private const int SlotYeast = 1;

		private const int RequiredSlotCount = 2;

		private const int SlotYeastNutrient = 2;

		private const int SlotRiceHulls = 3;

		private const int SlotDefoamer = 4;

		[Header("Bonus")]
		[SerializeField]
		private int baseBottleCount;

		private readonly NetworkVariable<byte> batchBonusFlags;

		private readonly NetworkVariable<int> batchSkillBonus;

		private readonly NetworkVariable<int> batchBoosterSkillBonus;

		private readonly NetworkVariable<int> blendBonusBottles;

		private readonly NetworkVariable<int> buffMinigameBonusBottles;

		private bool operatorHasMinigameBuff;

		public byte BatchBonusFlags => 0;

		public int BatchSkillBonus => 0;

		public int BatchBoosterSkillBonus => 0;

		public int BlendBonusBottles => 0;

		public int BuffMinigameBonusBottles => 0;

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void HandleBonusFlagsChanged(byte previous, byte current)
		{
		}

		private void HandleSkillBonusChanged(int previous, int current)
		{
		}

		private void HandleBoosterSkillBonusChanged(int previous, int current)
		{
		}

		private void HandleBlendBonusChanged(int previous, int current)
		{
		}

		private void HandleBuffMinigameBonusChanged(int previous, int current)
		{
		}

		protected override void OnProcessingStarted(ulong operatorClientId)
		{
		}

		protected override int GetInputSlotCount()
		{
			return 0;
		}

		protected override int GetOutputSlotCount()
		{
			return 0;
		}

		protected override bool ValidateInputs()
		{
			return false;
		}

		protected override void ConsumeInputs()
		{
		}

		protected override void GenerateOutput()
		{
		}

		protected override string GetInputItemId(int slotIndex)
		{
			return null;
		}

		protected override int GetInputSlotCapacity(int slotIndex)
		{
			return 0;
		}

		protected override bool IsValidInputItem(int slotIndex, Item item)
		{
			return false;
		}

		protected override bool CanAcceptInventoryItem(int slotIndex, InventoryManager sourceInventory, int sourceSlotIndex, InventorySlot sourceSlot)
		{
			return false;
		}

		protected override string GetOutputItemId()
		{
			return null;
		}

		protected override int GetOutputQuantity()
		{
			return 0;
		}

		protected override string GetSlotDisplayName(int slotIndex)
		{
			return null;
		}

		public override void Interact(ulong clientId)
		{
		}

		[ClientRpc]
		private void ShowUIClientRpc(ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		protected override bool IsUIShowingForLocalPlayer()
		{
			return false;
		}

		protected override void OnOutputCollected(InventoryManager collector, Item item, int quantity, int slotIndex)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void SetMinigameBonusServerRpc(int minigameIndex)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void AddBlendBonusServerRpc()
		{
		}

		public static int CountSetBits(byte value)
		{
			return 0;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3368510310(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3562619708(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1701281193(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
