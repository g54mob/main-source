using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Data;
using Brewery.NPC.Simple;
using Unity.Netcode;
using UnityEngine;

namespace Property
{
	[RequireComponent(typeof(NetworkObject))]
	public class NPCSpawner : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSpawnAllResidentNPCs_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCSpawner _003C_003E4__this;

			private int _003CspawnedCount_003E5__2;

			private List<House>.Enumerator _003C_003E7__wrap2;

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
			public _003CSpawnAllResidentNPCs_003Ed__17(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
			{
			}

			private void _003C_003Em__Finally3()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitForHouseOccupantsRestored_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCSpawner _003C_003E4__this;

			private Action _003ConRestored_003E5__2;

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
			public _003CWaitForHouseOccupantsRestored_003Ed__18(int _003C_003E1__state)
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

		private static NPCSpawner _instance;

		[Header("Spawn Configuration")]
		[Tooltip("Delay between spawning each NPC (reduces NavMesh load)")]
		[SerializeField]
		private float spawnDelay;

		[Tooltip("Initial delay before spawning starts")]
		[SerializeField]
		private float initialDelay;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Testing")]
		[Tooltip("TESTING ONLY: Force all spawned NPCs to go directly to the bar")]
		[SerializeField]
		private bool forceAllNPCsToBar;

		private List<House> clerkHouses;

		private List<House> localHouses;

		private List<House> forSaleHouses;

		private House playerHouse;

		private Dictionary<string, SimpleNPCController> spawnedNPCs;

		private bool hasSpawned;

		public static NPCSpawner Instance => null;

		private void Awake()
		{
		}

		public new void OnDestroy()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void CacheHouses()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnAllResidentNPCs_003Ed__17))]
		private IEnumerator SpawnAllResidentNPCs()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitForHouseOccupantsRestored_003Ed__18))]
		private IEnumerator WaitForHouseOccupantsRestored()
		{
			return null;
		}

		private void SpawnNPCAtHouse(House house)
		{
		}

		public SimpleNPCController SpawnNPCAtHouse(House house, NPCProfile profile)
		{
			return null;
		}

		public void RegisterExistingNPCAsResident(SimpleNPCController controller, NPCProfile profile)
		{
		}

		public List<House> GetClerkHouses()
		{
			return null;
		}

		public List<House> GetLocalHouses()
		{
			return null;
		}

		public List<House> GetForSaleHouses()
		{
			return null;
		}

		public House GetPlayerHouse()
		{
			return null;
		}

		public List<House> GetAvailableForSaleHouses()
		{
			return null;
		}

		public SimpleNPCController GetSpawnedNPC(string npcId)
		{
			return null;
		}

		public bool IsNPCSpawned(string npcId)
		{
			return false;
		}

		public void RespawnResurrectedNPC(string npcId, Vector3 spawnPosition)
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
