using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Bar;
using Brewery.NPC.Simple;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	[RequireComponent(typeof(NetworkObject))]
	public class AutomaticServingSystem : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CServeNPCWithDelay_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AutomaticServingSystem _003C_003E4__this;

			public ulong npcId;

			public int drinkSlotIndex;

			private ulong _003CsystemId_003E5__2;

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
			public _003CServeNPCWithDelay_003Ed__18(int _003C_003E1__state)
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
		[SerializeField]
		private BarServingManager servingManager;

		[SerializeField]
		private BarInventoryManager barInventory;

		[SerializeField]
		private EmployeeManager employeeManager;

		[Header("Serving Settings")]
		[Tooltip("Time between checking for NPCs to serve (don't spam every frame)")]
		[SerializeField]
		private float servingCheckInterval;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private float nextServingCheck;

		private HashSet<ulong> npcBeingServed;

		public static AutomaticServingSystem Instance { get; private set; }

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private bool IsAnyEmployeeWorking()
		{
			return false;
		}

		private void ProcessServingQueue()
		{
		}

		private int FindBestDrinkForNPC(NPCServingData npcData)
		{
			return 0;
		}

		private bool WouldNPCRefuseDrink(SimpleNPCController npc, Item item)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CServeNPCWithDelay_003Ed__18))]
		private IEnumerator ServeNPCWithDelay(ulong npcId, int drinkSlotIndex)
		{
			return null;
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
