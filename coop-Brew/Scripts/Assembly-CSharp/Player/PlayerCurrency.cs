using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Player
{
	public class PlayerCurrency : NetworkBehaviour, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CInitializeStartingMoney_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerCurrency _003C_003E4__this;

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
			public _003CInitializeStartingMoney_003Ed__12(int _003C_003E1__state)
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

		[Header("Currency Settings")]
		public float startingDollars;

		private NetworkVariable<float> currentDollars;

		private NetworkVariable<float> totalEarned;

		private InventoryManager inventoryManager;

		private bool isRestoredFromSave;

		public float TotalEarned => 0f;

		public string SaveableId => null;

		public event Action<float> OnDollarsChanged
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

		[IteratorStateMachine(typeof(_003CInitializeStartingMoney_003Ed__12))]
		private IEnumerator InitializeStartingMoney()
		{
			return null;
		}

		private void OnInventoryRestoreComplete()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void RecalculateFromInventory()
		{
		}

		private void OnDollarsValueChanged(float oldValue, float newValue)
		{
		}

		public float GetDollars()
		{
			return 0f;
		}

		public bool CanAfford(float amount)
		{
			return false;
		}

		public bool SpendDollars(float amount)
		{
			return false;
		}

		public void AddDollars(float amount)
		{
		}

		public bool ServerAddDollars(float amount)
		{
			return false;
		}

		[Rpc(SendTo.Server)]
		private void SpendDollarsRpc(float amount)
		{
		}

		[Rpc(SendTo.Server)]
		private void AddDollarsRpc(float amount)
		{
		}

		public bool AttemptPurchase(float cost)
		{
			return false;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_704178261(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2035738262(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
