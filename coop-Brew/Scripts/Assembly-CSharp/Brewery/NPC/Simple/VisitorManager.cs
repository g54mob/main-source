using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Map;
using Brewery.NPC.Data;
using Property;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	[RequireComponent(typeof(NetworkObject))]
	public class VisitorManager : NetworkBehaviour, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CDeferredHouseOccupantRestoration_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisitorManager _003C_003E4__this;

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
			public _003CDeferredHouseOccupantRestoration_003Ed__67(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSubscribeToPropertyManagerEvents_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisitorManager _003C_003E4__this;

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
			public _003CSubscribeToPropertyManagerEvents_003Ed__24(int _003C_003E1__state)
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

		private static VisitorManager _instance;

		[Header("Visitor Configuration")]
		[Tooltip("Visitor NPC profiles. Spawn during visitor window.")]
		[SerializeField]
		private NPCProfile[] visitorProfiles;

		[Tooltip("Spawn points around town where visitors can appear. Each visitor spawns at a random point.")]
		[SerializeField]
		private Transform[] visitorSpawnPoints;

		[Header("Visitor System")]
		[Tooltip("Configuration for daily visitor spawns (time window, count)")]
		[SerializeField]
		private VisitorScheduleConfig visitorScheduleConfig;

		[Header("Map Icon")]
		[Tooltip("Map icon definition for visitor NPCs. Assign a MapIconDefinition asset.")]
		[SerializeField]
		private MapIconDefinition visitorMapIconDefinition;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private List<SimpleNPCController> activeVisitors;

		private HashSet<string> housedVisitorNpcIds;

		private bool visitorsSpawnedToday;

		private int lastCheckedHour;

		private bool initialSpawnCooldown;

		private Dictionary<string, HaggleState> haggleStates;

		private HashSet<string> permanentlyRefusedNpcIds;

		private bool houseOccupantsRestored;

		public static VisitorManager Instance => null;

		public bool HouseOccupantsRestored => false;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action OnHouseOccupantsRestored
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

		private void Start()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CSubscribeToPropertyManagerEvents_003Ed__24))]
		private IEnumerator SubscribeToPropertyManagerEvents()
		{
			return null;
		}

		private void HandleHouseRentedToVisitor(string houseId, string visitorNpcId)
		{
		}

		public override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void CheckVisitorTiming(int currentHour)
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void SpawnDailyVisitors()
		{
		}

		private Transform GetRandomSpawnPoint()
		{
			return null;
		}

		private void SpawnVisitorNPCAtPosition(NPCProfile profile, Vector3 spawnPosition, Quaternion spawnRotation)
		{
		}

		[ClientRpc]
		private void SetupVisitorMapPresenceClientRpc(ulong visitorNetworkObjectId, string npcId)
		{
		}

		public void RelayOpenHouseRentUI(ulong targetClientId, ulong visitorNetworkObjectId, string npcId)
		{
		}

		[ClientRpc]
		private void OpenHouseRentUIClientRpc(ulong visitorNetworkObjectId, string npcId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void DespawnNonHousedVisitors()
		{
		}

		public void ConvertVisitorToResident(string visitorNpcId, string houseId)
		{
		}

		public List<SimpleNPCController> GetActiveVisitors()
		{
			return null;
		}

		public int GetHousedVisitorCount()
		{
			return 0;
		}

		public bool IsVisitorHoused(string npcId)
		{
			return false;
		}

		public Vector3 GetRandomVisitorSpawnPoint()
		{
			return default(Vector3);
		}

		public NPCProfile[] GetVisitorProfiles()
		{
			return null;
		}

		public NPCProfile GetVisitorProfileById(string npcId)
		{
			return null;
		}

		public void RestoreHouseOccupantsFromSaveData()
		{
		}

		public int SpawnAllVisitorsForTesting(Vector3 fallbackPosition, Quaternion fallbackRotation)
		{
			return 0;
		}

		public bool SpawnSingleVisitorForTesting(Vector3 position)
		{
			return false;
		}

		private void SpawnAsLocalNPCForTesting(NPCProfile profile, House house)
		{
		}

		private void SpawnAsLocalNPCForTestingNoHouse(NPCProfile profile, Vector3 spawnPosition, Quaternion spawnRotation)
		{
		}

		public HaggleState GetOrCreateHaggleState(string npcId)
		{
			return null;
		}

		public float GetEffectiveMaxPriceMultiplier(NPCProfile profile)
		{
			return 0f;
		}

		public float CalculateWillingness(NPCProfile profile, int basePrice, int offerPrice)
		{
			return 0f;
		}

		public bool WillAcceptOffer(NPCProfile profile, int basePrice, int offerPrice)
		{
			return false;
		}

		public bool RecordOfferRefusal(NPCProfile profile)
		{
			return false;
		}

		public bool HasPermanentlyRefused(string npcId)
		{
			return false;
		}

		public int GetRefusalCount(string npcId)
		{
			return 0;
		}

		public void ClearHaggleState(string npcId)
		{
		}

		public bool HasPendingReturn(string npcId)
		{
			return false;
		}

		public float GetTimeUntilReturn(string npcId)
		{
			return 0f;
		}

		private float GetCurrentGameHour()
		{
			return 0f;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void RestoreStringHashSet(object obj, HashSet<string> target)
		{
		}

		[IteratorStateMachine(typeof(_003CDeferredHouseOccupantRestoration_003Ed__67))]
		private IEnumerator DeferredHouseOccupantRestoration()
		{
			return null;
		}

		private void SignalHouseOccupantsRestored()
		{
		}

		public string GetDebugSummary()
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3364784290(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1453842911(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
