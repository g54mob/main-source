using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(BoxCollider))]
	public class StandServiceTrigger : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private StandInventoryManager standInventory;

		[Header("Validation")]
		[Tooltip("How often (seconds) to validate players via Physics.OverlapBox")]
		[SerializeField]
		private float validationInterval;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private HashSet<ulong> _playersInRange;

		private Dictionary<ulong, InventoryManager> _playerInventories;

		private Dictionary<ulong, int> _playerColliderCounts;

		private float _nextValidationTime;

		public IReadOnlyCollection<ulong> PlayersInRange => null;

		public StandInventoryManager StandInventory => null;

		public static StandServiceTrigger LocalPlayerTrigger { get; private set; }

		public event Action OnPlayerPoolChanged
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

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private void RegisterPlayer(ulong clientId, InventoryManager inventory)
		{
		}

		private void UnregisterPlayer(ulong clientId)
		{
		}

		private void ValidatePlayersInRange()
		{
		}

		private void NotifyLocalPlayerEnteredStandArea()
		{
		}

		private void NotifyLocalPlayerExitedStandArea()
		{
		}

		private bool IsPlayerCharacter(Collider collider, NetworkObject networkObject)
		{
			return false;
		}

		public InventoryManager GetPlayerInventory(ulong clientId)
		{
			return null;
		}

		public IEnumerable<KeyValuePair<ulong, InventoryManager>> GetAllPlayerInventories()
		{
			return null;
		}

		private void HandleInventoryChanged()
		{
		}

		private void HandlePlayerInventoryChanged()
		{
		}

		public void ForcePoolRefresh()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
