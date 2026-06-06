using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Calendar
{
	[DefaultExecutionOrder(-400)]
	[RequireComponent(typeof(NetworkObject))]
	public class CalendarManager : NetworkBehaviour, ISaveable
	{
		public enum DesyncReason
		{
			None = 0,
			HashMismatch = 1,
			UnknownEventIds = 2,
			ConfigMismatch = 3,
			ConfigMissing = 4
		}

		[CompilerGenerated]
		private sealed class _003CPickEventsForDay_003Ed__51 : IEnumerable<CalendarEventInstance>, IEnumerable, IEnumerator<CalendarEventInstance>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CalendarEventInstance _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CalendarManager _003C_003E4__this;

			private int dayIndex;

			public int _003C_003E3__dayIndex;

			private List<CalendarEventDefinition>.Enumerator _003C_003E7__wrap1;

			CalendarEventInstance IEnumerator<CalendarEventInstance>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(CalendarEventInstance);
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
			public _003CPickEventsForDay_003Ed__51(int _003C_003E1__state)
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
			IEnumerator<CalendarEventInstance> IEnumerable<CalendarEventInstance>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[Header("Configuration")]
		[SerializeField]
		private CalendarScheduleConfig m_Schedule;

		[SerializeField]
		private CatalystTradeLimitConfig m_LimitConfig;

		[SerializeField]
		private CalendarUITheme m_Theme;

		[Header("Debug")]
		[SerializeField]
		private bool m_VerboseLogging;

		private readonly NetworkVariable<int> _currentDayIndex;

		private readonly NetworkVariable<uint> _todayHash;

		private readonly NetworkVariable<int> _scheduleConfigHash;

		private NetworkList<CalendarEventInstance> _activeEventsToday;

		private NetworkList<CalendarEventInstance> _upcomingEvents;

		private DayModifierSet _today;

		private int _lastPolledDayIndex;

		private bool _inNullMode;

		private DesyncReason _nullModeReason;

		private readonly Dictionary<string, CalendarEventDefinition> _eventIndex;

		private bool _eventIndexLoaded;

		private bool _hashRetryArmed;

		private int _hashRetryDayIndex;

		public static CalendarManager Instance { get; private set; }

		public CalendarScheduleConfig Schedule => null;

		public CatalystTradeLimitConfig Limits => null;

		public CalendarUITheme Theme => null;

		public DayModifierSet Today => null;

		public int CurrentDayIndex => 0;

		public bool IsInNullMode => false;

		public DesyncReason NullModeReason => default(DesyncReason);

		public IReadOnlyList<CalendarEventInstance> UpcomingEvents => null;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<DayModifierSet> OnDayChangedCalendar
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

		public event Action OnCalendarRestored
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

		public event Action<DesyncReason, string[]> OnCalendarDesyncDetected
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

		private int ComputeCalendarDayIndex()
		{
			return 0;
		}

		private void InitialiseTodayServer()
		{
		}

		private void AdvanceToDayServer(int day, bool clearFirst = false)
		{
		}

		[IteratorStateMachine(typeof(_003CPickEventsForDay_003Ed__51))]
		private IEnumerable<CalendarEventInstance> PickEventsForDay(int dayIndex)
		{
			return null;
		}

		private static bool IsEventUsefulUnderExclusivity(CalendarEventDefinition def, HashSet<FactionType> allowedFactions)
		{
			return false;
		}

		private static CalendarEventInstance ToInstance(CalendarEventDefinition ev, int startDay)
		{
			return default(CalendarEventInstance);
		}

		private CalendarEventDefinition WeightedPick(CalendarScheduleConfig.PooledEvent[] pool, int seed)
		{
			return null;
		}

		private CalendarEventDefinition PickRandomTrendEvent(System.Random rng)
		{
			return null;
		}

		private static int Mod7(int v)
		{
			return 0;
		}

		private void RecompileLocal()
		{
		}

		private void OnActiveEventsChangedClient(NetworkListEvent<CalendarEventInstance> change)
		{
		}

		private void OnTodayHashChangedClient(uint prev, uint curr)
		{
		}

		private void OnCurrentDayIndexChanged(int prev, int curr)
		{
		}

		private void OnHashMismatchDetected(List<string> missingIds)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCalendarSnapshotServerRpc(ServerRpcParams p = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void ForceSyncCalendarClientRpc(CalendarEventInstance[] events, uint expectedHash, int scheduleHash, ClientRpcParams _)
		{
		}

		private void EnterNullMode(DesyncReason reason, string[] failingEventIds)
		{
		}

		public CalendarPricingContribution GetCalendarContribution(BrewTag tags, BaseType baseType, FactionType? faction, string[] catalystIds)
		{
			return default(CalendarPricingContribution);
		}

		public bool IsFactionAllowedToday(FactionType faction)
		{
			return false;
		}

		public float GetCatalystCostMult(string catalystId)
		{
			return 0f;
		}

		public float GetCatalystLimitMult(string catalystId)
		{
			return 0f;
		}

		public int GetCatalystDailyLimit(string catalystId)
		{
			return 0;
		}

		public bool IsTradeDisabledToday(string tradeOfferGuid)
		{
			return false;
		}

		public CalendarEventDefinition GetEventDefinition(string eventId)
		{
			return null;
		}

		private void LoadEventIndex()
		{
		}

		private int ComputeScheduleConfigHash()
		{
			return 0;
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

		private static void __rpc_handler_706952752(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_477542344(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
