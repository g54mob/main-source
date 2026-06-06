using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BarUpgrade;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Bar.PhysicalServing
{
	[RequireComponent(typeof(BoxCollider))]
	public class BarServiceTrigger : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedPoolRefresh_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BarServiceTrigger _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayedPoolRefresh_003Ed__25(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}
		}

		[Header("References")]
		[Tooltip("The bar's inventory manager (for aggregating bar drinks)")]
		[SerializeField]
		private BarInventoryManager barInventory;

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

		private bool _localPlayerInTrigger;

		private BarUpgradeManager _barUpgradeManager;

		private float _nextValidationTime;

		public IReadOnlyCollection<ulong> PlayersInRange => null;

		public BarInventoryManager BarInventory => null;

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

		[IteratorStateMachine(typeof(_003CDelayedPoolRefresh_003Ed__25))]
		private IEnumerator DelayedPoolRefresh()
		{
			return null;
		}

		private void NotifyLocalPlayerEnteredBarArea()
		{
		}

		private void NotifyLocalPlayerExitedBarArea()
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

		private void HandleBarInventoryChanged()
		{
		}

		private void HandlePlayerInventoryChanged()
		{
		}

		private void HandleBarOwnershipChanged(bool isOwned)
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
