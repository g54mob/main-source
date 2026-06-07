using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.GameTime
{
	public class TimeManager : NetworkSingleton<TimeManager>, IBaseSaveable, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CTickLoop_003Ed__104 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TimeManager _003C_003E4__this;

			private float _003ClastWaitExcess_003E5__2;

			private float _003CtimeToWait_003E5__3;

			private float _003CtimeOnWaitStart_003E5__4;

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
			public _003CTickLoop_003Ed__104(int _003C_003E1__state)
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
		private sealed class _003CTimeLoop_003Ed__105 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TimeManager _003C_003E4__this;

			private float _003CtimeToWait_003E5__2;

			private float _003CtimeOnWaitStart_003E5__3;

			private float _003Ci_003E5__4;

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
			public _003CTimeLoop_003Ed__105(int _003C_003E1__state)
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

		private const float DefaultCycleDuration = 24f;

		public const float TickDuration = 0.5f;

		public const int EndOfDay = 400;

		public const int WakeTime = 700;

		private static float CycleDuration;

		[SerializeField]
		private EDay _defaultDay;

		private float _lastMinWaitExcess;

		private bool _stopMinPassWait;

		private float _secondsOnCurrentMinute;

		public ActionList onMinutePass;

		public ActionList onUncappedMinutePass;

		public ActionList onTick;

		public Action onTimeChanged;

		public Action<int> onTimeSkip;

		public Action onTimeSet;

		public Action onHourPass;

		public Action onDayPass;

		public Action onWeekPass;

		public Action onUpdate;

		public Action onFixedUpdate;

		public Action onSleepStart;

		public Action onSleepEnd;

		private TimeLoader loader;

		private bool NetworkInitialize___EarlyScheduleOne_002EGameTime_002ETimeManagerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EGameTime_002ETimeManagerAssembly_002DCSharp_002Edll_Excuted;

		public static float MinuteDuration => 0f;

		[field: SerializeField]
		public int DefaultTime { get; private set; }

		public int CurrentTime { get; private set; }

		public EDay CurrentDay => default(EDay);

		public int ElapsedDays { get; private set; }

		public bool IsEndOfDay => false;

		public bool IsNight => false;

		public float NormalizedTimeOfDay => 0f;

		public int DayIndex => 0;

		public bool IsSleepInProgress { get; private set; }

		public float Playtime { get; private set; }

		public bool HostSleepDone { get; private set; }

		public float TimeSpeedMultiplier { get; private set; }

		public int DailyMinSum { get; private set; }

		private float _minuteStaggerTime => 0f;

		private float _tickStaggerTime => 0f;

		public string SaveFolderName => null;

		public string SaveFileName => null;

		public Loader Loader => null;

		public bool ShouldSaveUnderFolder => false;

		public List<string> LocalExtraFiles { get; set; }

		public List<string> LocalExtraFolders { get; set; }

		public bool HasChanged { get; set; }

		public int LoadOrder { get; }

		public override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public virtual void InitializeSaveable()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		private void Clean()
		{
		}

		[ObserversRpc(RunLocally = true, ExcludeServer = true)]
		[TargetRpc]
		private void SetTimeData_Client(NetworkConnection conn, int elapsedDays, int time, uint serverTick)
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		[IteratorStateMachine(typeof(_003CTickLoop_003Ed__104))]
		private IEnumerator TickLoop()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTimeLoop_003Ed__105))]
		private IEnumerator TimeLoop()
		{
			return null;
		}

		private bool ShouldMinutePass()
		{
			return false;
		}

		private void PassMinute()
		{
		}

		[ObserversRpc(RunLocally = true, ExcludeServer = true)]
		private void PassMinute_Client(int oldTime)
		{
		}

		public void SetTimeAndSync(int time)
		{
		}

		private void SetTime(int time)
		{
		}

		public bool IsCurrentTimeWithinRange(int min, int max)
		{
			return false;
		}

		public bool IsCurrentDateWithinRange(GameDateTime start, GameDateTime end)
		{
			return false;
		}

		public GameDateTime GetDateTime()
		{
			return default(GameDateTime);
		}

		public int GetTotalMinSum()
		{
			return 0;
		}

		public void SetTimeSpeedMultiplier(float multiplier)
		{
		}

		public void SetCycleDuration(float time)
		{
		}

		private void CheckSleepStart()
		{
		}

		[ObserversRpc(RunLocally = true)]
		public void StartSleep()
		{
		}

		[ObserversRpc(RunLocally = true)]
		public void SetHostSleepDone(bool done)
		{
		}

		private void SkipForwardToTime(int newTime)
		{
		}

		[ObserversRpc(RunLocally = true)]
		private void OnTimeSkip_Client(int oldTime, int newTime)
		{
		}

		public static bool IsGivenTimeWithinRange(int givenTime, int min, int max)
		{
			return false;
		}

		public static bool IsValid24HourTime(string input)
		{
			return false;
		}

		public static string Get12HourTime(float _time, bool appendDesignator = true)
		{
			return null;
		}

		public static int Get24HourTimeFromMinSum(int minSum)
		{
			return 0;
		}

		public static int GetMinSumFrom24HourTime(int _time)
		{
			return 0;
		}

		public static string GetMinutesToDisplayTime(int minutes)
		{
			return null;
		}

		public static int AddMinutesTo24HourTime(int time, int minsToAdd)
		{
			return 0;
		}

		public virtual string GetSaveString()
		{
			return null;
		}

		public void Load(TimeData timeData)
		{
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Observers_SetTimeData_Client_1794730778(NetworkConnection conn, int elapsedDays, int time, uint serverTick)
		{
		}

		private void RpcLogic___SetTimeData_Client_1794730778(NetworkConnection conn, int elapsedDays, int time, uint serverTick)
		{
		}

		private void RpcReader___Observers_SetTimeData_Client_1794730778(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_SetTimeData_Client_1794730778(NetworkConnection conn, int elapsedDays, int time, uint serverTick)
		{
		}

		private void RpcReader___Target_SetTimeData_Client_1794730778(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_PassMinute_Client_3316948804(int oldTime)
		{
		}

		private void RpcLogic___PassMinute_Client_3316948804(int oldTime)
		{
		}

		private void RpcReader___Observers_PassMinute_Client_3316948804(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_StartSleep_2166136261()
		{
		}

		public void RpcLogic___StartSleep_2166136261()
		{
		}

		private void RpcReader___Observers_StartSleep_2166136261(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_SetHostSleepDone_1140765316(bool done)
		{
		}

		public void RpcLogic___SetHostSleepDone_1140765316(bool done)
		{
		}

		private void RpcReader___Observers_SetHostSleepDone_1140765316(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_OnTimeSkip_Client_1692629761(int oldTime, int newTime)
		{
		}

		private void RpcLogic___OnTimeSkip_Client_1692629761(int oldTime, int newTime)
		{
		}

		private void RpcReader___Observers_OnTimeSkip_Client_1692629761(PooledReader PooledReader0, Channel channel)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EGameTime_002ETimeManager_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
