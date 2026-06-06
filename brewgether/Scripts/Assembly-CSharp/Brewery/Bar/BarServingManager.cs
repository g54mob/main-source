using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Calendar;
using Brewery.Core;
using Brewery.Items;
using Brewery.NPC.Simple;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Bar
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class BarServingManager : NetworkBehaviour
	{
		public struct PriceCalculationBreakdown
		{
			public int originalBaseValue;

			public int baseValueSkillBonus;

			public int effectiveBaseValue;

			public string factionName;

			public float factionSellBonusPercent;

			public float factionSellBonusMultiplier;

			public string baseTypeName;

			public float factionBaseTypeMultiplier;

			public float baseTypeMultiplier;

			public Dictionary<string, TagMultiplierBreakdown> tagBreakdowns;

			public float combinedTagMultiplier;

			public float barMood;

			public float tipPercent;

			public float tipMultiplier;

			public float tipAmount;

			public float rawPrice;

			public float priceBeforeTips;

			public float finalPrice;

			public CalendarPricingContribution calendarContribution;

			public string[] calendarActiveEventIds;
		}

		public struct TagMultiplierBreakdown
		{
			public string tagName;

			public float factionBaseMultiplier;

			public float effectiveBaseMultiplier;

			public string catalystName;

			public float catalystSkillBonus;

			public float finalMultiplier;
		}

		[CompilerGenerated]
		private sealed class _003CGetIndividualTags_003Ed__50 : IEnumerable<BrewTag>, IEnumerable, IEnumerator<BrewTag>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private BrewTag _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private BrewTag combinedTags;

			public BrewTag _003C_003E3__combinedTags;

			private IEnumerator _003C_003E7__wrap1;

			BrewTag IEnumerator<BrewTag>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(BrewTag);
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
			public _003CGetIndividualTags_003Ed__50(int _003C_003E1__state)
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
			IEnumerator<BrewTag> IEnumerable<BrewTag>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetNPCsWaitingForDrinks_003Ed__63 : IEnumerable<ulong>, IEnumerable, IEnumerator<ulong>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ulong _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public BarServingManager _003C_003E4__this;

			private Dictionary<ulong, NPCServingEntry>.Enumerator _003C_003E7__wrap1;

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
			public _003CGetNPCsWaitingForDrinks_003Ed__63(int _003C_003E1__state)
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

		public const ulong AUTOMATED_SYSTEM_ID = 18446744073709551614uL;

		[Header("References")]
		[SerializeField]
		private BarInventoryManager barInventory;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly Dictionary<ulong, NPCServingEntry> registeredNPCs;

		private NetworkVariable<ulong> servingLockClientId;

		private int totalSalesCount;

		public int TotalSalesCount => 0;

		public int RegisteredNPCCount => 0;

		public event Action<NPCServingSnapshot> OnServingQueueUpdated
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

		public event Action<ulong> OnLockAcquired
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

		public event Action OnLockReleased
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

		public event Action<ulong> OnLockDenied
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

		public event Action<SaleCompletedData> OnSaleCompleted
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

		public override void OnDestroy()
		{
		}

		public void RegisterNPC(ulong npcNetworkId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RegisterNPCServerRpc(ulong npcNetworkId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void UnregisterNPC(ulong npcNetworkId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void UnregisterNPCServerRpc(ulong npcNetworkId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void AssignDrinkToNPCServerRpc(int barSlotIndex, ulong npcNetworkId, ulong requestingClientId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RemoveDrinkFromNPCServerRpc(ulong npcNetworkId, ulong requestingClientId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void SellDrinkToNPCServerRpc(ulong npcNetworkId, ulong requestingClientId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private bool TryRemoveDrinkFromBar(int slotIndex)
		{
			return false;
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestServingLockServerRpc(ulong clientId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ReleaseServingLockServerRpc(ulong clientId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public bool HasLock(ulong clientId)
		{
			return false;
		}

		public bool IsLockAvailable()
		{
			return false;
		}

		private BrewTag GetBeverageTags(BeverageItem beverage)
		{
			return default(BrewTag);
		}

		public float CalculatePrice(Item item, SimpleNPCController npc)
		{
			return 0f;
		}

		public string GetPriceBreakdown(Item item, SimpleNPCController npc)
		{
			return null;
		}

		public float CalculatePriceWithSkills(Item item, SimpleNPCController npc, ulong clientId, BeerDataSnapshot? snapshot = null)
		{
			return 0f;
		}

		public PriceCalculationBreakdown CalculatePriceWithBreakdown(Item item, SimpleNPCController npc, ulong clientId, BeerDataSnapshot? snapshot = null)
		{
			return default(PriceCalculationBreakdown);
		}

		public string GetDetailedPriceBreakdown(Item item, SimpleNPCController npc, ulong clientId)
		{
			return null;
		}

		private List<string> GetCatalystsFromBeverage(BeverageItem beverage, BeerDataSnapshot? snapshot = null)
		{
			return null;
		}

		private string FormatCatalystIdToName(string catalystId)
		{
			return null;
		}

		private bool CatalystHasTag(string catalystName, BrewTag tag)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetIndividualTags_003Ed__50))]
		private IEnumerable<BrewTag> GetIndividualTags(BrewTag combinedTags)
		{
			return null;
		}

		private bool WouldNPCRefuseDrink(SimpleNPCController npc, Item item)
		{
			return false;
		}

		private SaleCompletedData CalculateSaleBreakdown(Item item, SimpleNPCController npc, string drinkName, float finalPrice, ulong clientId, BeerDataSnapshot? snapshot = null)
		{
			return default(SaleCompletedData);
		}

		private void BroadcastQueueUpdate()
		{
		}

		[ClientRpc]
		private void UpdateServingQueueClientRpc(NPCServingSnapshot snapshot)
		{
		}

		[ClientRpc]
		private void NotifyLockAcquiredClientRpc(ulong clientId)
		{
		}

		[ClientRpc]
		private void NotifyLockDeniedClientRpc(ulong clientId, ulong holderId)
		{
		}

		[ClientRpc]
		private void NotifyLockReleasedClientRpc()
		{
		}

		[ClientRpc]
		private void NotifySaleCompleteClientRpc(SaleCompletedData saleData, ulong sellerClientId)
		{
		}

		[ClientRpc]
		private void NotifyActionDeniedClientRpc(ulong clientId, string message)
		{
		}

		public NPCServingSnapshot GetCurrentQueueSnapshot()
		{
			return default(NPCServingSnapshot);
		}

		public SimpleNPCController GetNPCController(ulong npcNetworkId)
		{
			return null;
		}

		public IEnumerable<ulong> GetRegisteredNPCIds()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetNPCsWaitingForDrinks_003Ed__63))]
		public IEnumerable<ulong> GetNPCsWaitingForDrinks()
		{
			return null;
		}

		public void LogPhysicalServingTransaction(Item item, SimpleNPCController npc, ulong sellerClientId, BeerDataSnapshot? metadata = null, float actualPrice = -1f)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_537042671(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1220878441(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2968875237(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3381723544(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3697073569(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3139916291(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_957518989(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3393132301(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3371186469(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3949852610(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1788597075(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_150737003(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1098036496(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
