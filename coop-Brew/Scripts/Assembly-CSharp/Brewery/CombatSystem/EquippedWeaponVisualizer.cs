using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.CombatSystem
{
	public class EquippedWeaponVisualizer : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private InventoryManager inventoryManager;

		[SerializeField]
		private SimpleCombatController combatController;

		[Tooltip("Right hand socket where weapon will be attached")]
		[SerializeField]
		private Transform rightHandSocket;

		[Header("Settings")]
		[Tooltip("If true, weapon appears instantly. If false, plays equip animation")]
		[SerializeField]
		private bool instantEquip;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private GameObject currentWeaponInstance;

		private WeaponItem currentWeaponData;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void OnDisable()
		{
		}

		private void HandleSlotChanged(int slotIndex)
		{
		}

		private void HandleInventorySlotChanged(int slotIndex, InventorySlot slot)
		{
		}

		private void HandleItemEquippedStateChanged(bool isEquipped)
		{
		}

		private void EquipWeapon(WeaponItem weapon)
		{
		}

		private void UnequipWeapon()
		{
		}

		private void SpawnWeaponServerSide(WeaponItem weapon)
		{
		}

		private void DespawnWeaponServerSide()
		{
		}

		[ServerRpc]
		private void RequestSpawnWeaponServerRpc(string weaponItemId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc]
		private void RequestDespawnWeaponServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void ShowWeaponClientRpc(string weaponItemId)
		{
		}

		[ClientRpc]
		private void HideWeaponClientRpc()
		{
		}

		private Transform FindRightHandSocket()
		{
			return null;
		}

		public Transform GetWeaponSocket()
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_704636570(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2201422921(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1964284243(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1454340854(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
