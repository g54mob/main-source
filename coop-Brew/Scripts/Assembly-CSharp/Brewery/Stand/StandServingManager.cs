using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Core;
using Brewery.Items;
using Brewery.NPC.Simple;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(NetworkObject))]
	public class StandServingManager : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CGetNPCsWaitingForDrinks_003Ed__27 : IEnumerable<ulong>, IEnumerable, IEnumerator<ulong>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ulong _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public StandServingManager _003C_003E4__this;

			private Dictionary<ulong, StandServingEntry>.Enumerator _003C_003E7__wrap1;

			ulong IEnumerator<ulong>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0uL;
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
			public _003CGetNPCsWaitingForDrinks_003Ed__27(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ulong> IEnumerable<ulong>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[Header("References")]
		[SerializeField]
		private StandLocation standLocation;

		[SerializeField]
		private StandInventoryManager inventoryManager;

		[Header("Pricing")]
		[Tooltip("Base price multiplier for stand (1.0 = normal, increased by upgrades)")]
		[SerializeField]
		private float standPriceMultiplier;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly Dictionary<ulong, StandServingEntry> _registeredNPCs;

		private NetworkVariable<int> _cumulativeSaleCount;

		private float _nextStaleCheckTime;

		private const float STALE_CHECK_INTERVAL = 5f;

		private readonly List<ulong> _staleIds;

		public int RegisteredNPCCount => 0;

		public int CumulativeSaleCount => 0;

		public event Action OnServingQueueUpdated
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

		public event Action<StandSaleData> OnSaleCompleted
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

		private void OnCumulativeSaleCountChanged(int previousValue, int newValue)
		{
		}

		private void Update()
		{
		}

		private void PruneStaleEntries()
		{
		}

		public void RegisterNPC(ulong npcNetworkId)
		{
		}

		public void UnregisterNPC(ulong npcNetworkId)
		{
		}

		public IEnumerable<ulong> GetAllRegisteredNPCIds()
		{
			return null;
		}

		public SimpleNPCController GetNPCController(ulong npcNetworkId)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetNPCsWaitingForDrinks_003Ed__27))]
		public IEnumerable<ulong> GetNPCsWaitingForDrinks()
		{
			return null;
		}

		public float CalculatePrice(Item item, SimpleNPCController npc)
		{
			return 0f;
		}

		public bool WouldNPCRefuseDrink(SimpleNPCController npc, Item item)
		{
			return false;
		}

		public void LogPhysicalServingTransaction(Item item, SimpleNPCController npc, ulong sellerClientId, BeerDataSnapshot? metadata, float actualPrice = -1f)
		{
		}

		public void RecordSale()
		{
		}

		public void SetPriceMultiplier(float multiplier)
		{
		}

		private BrewTag GetBeverageTags(BeverageItem beverage)
		{
			return default(BrewTag);
		}

		private SimpleNPCController FindNPCControllerInScene(ulong npcNetworkId)
		{
			return null;
		}

		[ClientRpc]
		private void NotifyStandSaleProgressClientRpc(int cumulativeCount)
		{
		}

		[ClientRpc]
		private void NotifyStandSaleClientRpc(string drinkName, float price, string npcName, ulong targetClientId)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1815448313(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3601763866(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
