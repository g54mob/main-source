using Brewery.Buffs;
using Brewery.Controls3D;
using Brewery.Skills;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stations
{
	public class CornGrindingStation2 : BaseBreweryStation
	{
		[Header("Tablet")]
		[Tooltip("The 3D tablet child attached to this station")]
		[SerializeField]
		private CornGrindingTablet3D tablet;

		private const int CornPerBatch = 10;

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

		protected override string GetQuestStationId()
		{
			return null;
		}

		protected override SkillType? GetMinigameTimeSkill()
		{
			return null;
		}

		protected override BuffType? GetMinigameTimeBuff()
		{
			return null;
		}

		public override int GetInputRequirement(int slotIndex)
		{
			return 0;
		}

		protected override void OnOutputCollected(InventoryManager collector, Item item, int quantity, int slotIndex)
		{
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

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1105917333(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
