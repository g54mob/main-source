using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace Enviro
{
	[AddComponentMenu("Enviro 3/Integrations/Day Night Manager")]
	[RequireComponent(typeof(NetworkIdentity))]
	public class DayNightManager : NetworkBehaviour, IGameSave
	{
		[Serializable]
		public class DayNightSaveData
		{
			public int currentGameDay;

			public float timeOfDay;

			public int enviroDays;

			public int enviroMonths;

			public int enviroYears;

			public bool tutorialTimeStopTriggered;

			public bool isSimulating;
		}

		public static DayNightManager Instance;

		[Header("Time Settings")]
		[Tooltip("Sabah baslangic saati (ornek: 6 = 06:00)")]
		[Range(0f, 24f)]
		public int morningStartHour = 6;

		[Tooltip("Aksam bitis saati - bu saatten sonra zaman durur (ornek: 24 = 23:00 Enviro kompanzasyonuyla)")]
		[Range(0f, 24f)]
		public int eveningEndHour = 24;

		[Header("Light Settings")]
		[Tooltip("Isiklarin acilacagi saat (ornek: 18 = 18:00)")]
		[Range(0f, 24f)]
		public int lightsOnHour = 18;

		[Tooltip("Isiklarin kapanacagi saat (ornek: 7 = 07:00)")]
		[Range(0f, 24f)]
		public int lightsOffHour = 7;

		[Header("Alarm Settings")]
		public AudioSource alarmAudioSource;

		public AudioClip alarmClip;

		[Header("Tutorial Settings")]
		[Tooltip("Ilk gunde zamanin duracagi saat (tutorial icin)")]
		[Range(0f, 24f)]
		public int tutorialStopHour = 8;

		[Tooltip("Gece gecis suresi (saniye)")]
		public float nightTransitionDuration = 5f;

		private bool _tutorialTimeStopTriggered;

		private bool _isNightTransitionActive;

		private float _originalSimulationSpeed;

		private Coroutine _nightTransitionCoroutine;

		[SyncVar]
		public int _currentGameDay = 1;

		private bool wasSimulating = true;

		private bool wasLightsOn;

		public float CurrentTimeOfDay
		{
			get
			{
				if (EnviroManager.instance == null || EnviroManager.instance.Time == null)
				{
					return 0f;
				}
				return EnviroManager.instance.Time.GetTimeOfDay();
			}
		}

		public int CurrentHour
		{
			get
			{
				if (EnviroManager.instance == null || EnviroManager.instance.Time == null)
				{
					return 0;
				}
				return EnviroManager.instance.Time.hours;
			}
		}

		public bool IsSimulating
		{
			get
			{
				if (EnviroManager.instance == null || EnviroManager.instance.Time == null)
				{
					return false;
				}
				return EnviroManager.instance.Time.Settings.simulate;
			}
		}

		public bool IsDaytime
		{
			get
			{
				float currentTimeOfDay = CurrentTimeOfDay;
				if (currentTimeOfDay >= (float)morningStartHour)
				{
					return currentTimeOfDay < (float)(eveningEndHour - 1);
				}
				return false;
			}
		}

		public bool IsNighttime
		{
			get
			{
				float currentTimeOfDay = CurrentTimeOfDay;
				if (!(currentTimeOfDay >= (float)eveningEndHour))
				{
					return currentTimeOfDay < (float)morningStartHour;
				}
				return true;
			}
		}

		public bool ShouldLightsBeOn
		{
			get
			{
				float currentTimeOfDay = CurrentTimeOfDay;
				int num = lightsOnHour - 1;
				int num2 = lightsOffHour;
				if (num > num2)
				{
					if (!(currentTimeOfDay >= (float)num))
					{
						return currentTimeOfDay < (float)num2;
					}
					return true;
				}
				if (currentTimeOfDay >= (float)num)
				{
					return currentTimeOfDay < (float)num2;
				}
				return false;
			}
		}

		public int CurrentGameDay => _currentGameDay;

		public float HoursUntilDayEnd
		{
			get
			{
				float currentTimeOfDay = CurrentTimeOfDay;
				int num = eveningEndHour - 1;
				if (currentTimeOfDay >= (float)num)
				{
					return 0f;
				}
				return (float)num - currentTimeOfDay;
			}
		}

		public bool IsTutorialTimeStopTriggered => _tutorialTimeStopTriggered;

		public bool IsNightTransitionActive => _isNightTransitionActive;

		public string SaveID => "day-night-manager";

		public bool IsShared => false;

		public Type SaveType => typeof(DayNightSaveData);

		public LoadMode LoadMode => LoadMode.Greedy;

		public int Network_currentGameDay
		{
			get
			{
				return _currentGameDay;
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter(value, ref _currentGameDay, 1uL, null);
			}
		}

		public event Action OnNightTransitionCompleted;

		public event Action<int> OnHourChanged;

		public event Action OnDayStarted;

		public event Action OnDayEnded;

		public event Action<bool> OnSimulationStateChanged;

		public event Action<bool> OnLightsStateChanged;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void Start()
		{
			if (GameManager.Instance != null)
			{
				GameManager.Instance.dayNightManager = this;
			}
			if (EnviroManager.instance != null)
			{
				EnviroManager.instance.OnHourPassed += OnEnviroHourPassed;
			}
			if (base.isServer)
			{
				if (EnviroManager.instance != null && EnviroManager.instance.Time != null)
				{
					EnviroManager.instance.Time.SetTimeOfDay(morningStartHour);
				}
				UpdateSimulationState();
			}
		}

		private void OnDestroy()
		{
			if (EnviroManager.instance != null)
			{
				EnviroManager.instance.OnHourPassed -= OnEnviroHourPassed;
			}
		}

		private void OnEnviroHourPassed()
		{
			int currentHour = CurrentHour;
			this.OnHourChanged?.Invoke(currentHour);
			if (base.isServer)
			{
				CheckTutorialTimeStop(currentHour);
			}
			UpdateSimulationState();
			UpdateLightsState();
		}

		private void CheckTutorialTimeStop(int currentHour)
		{
			if (_currentGameDay == 1 && !_tutorialTimeStopTriggered && !_isNightTransitionActive && currentHour >= tutorialStopHour - 1)
			{
				_tutorialTimeStopTriggered = true;
				if (EnviroManager.instance != null && EnviroManager.instance.Time != null)
				{
					EnviroManager.instance.Time.Settings.simulate = false;
					RpcSetSimulationState(simulate: false);
				}
			}
		}

		private void UpdateLightsState()
		{
			bool shouldLightsBeOn = ShouldLightsBeOn;
			if (wasLightsOn != shouldLightsBeOn)
			{
				wasLightsOn = shouldLightsBeOn;
				this.OnLightsStateChanged?.Invoke(shouldLightsBeOn);
			}
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			if (!base.isServer)
			{
				CmdRequestTimeSync();
			}
		}

		[Command(requiresAuthority = false)]
		private void CmdRequestTimeSync(NetworkConnectionToClient sender = null)
		{
			if (base.isServer && base.isClient)
			{
				UserCode_CmdRequestTimeSync__NetworkConnectionToClient(sender);
				return;
			}
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendCommandInternal("System.Void Enviro.DayNightManager::CmdRequestTimeSync(Mirror.NetworkConnectionToClient)", 1592418723, writer, 0, requiresAuthority: false);
			NetworkWriterPool.Return(writer);
		}

		[TargetRpc]
		private void TargetSyncTime(NetworkConnectionToClient target, float timeOfDay, bool isSimulating, int days, int months, int years)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteFloat(timeOfDay);
			writer.WriteBool(isSimulating);
			writer.WriteVarInt(days);
			writer.WriteVarInt(months);
			writer.WriteVarInt(years);
			SendTargetRPCInternal(target, "System.Void Enviro.DayNightManager::TargetSyncTime(Mirror.NetworkConnectionToClient,System.Single,System.Boolean,System.Int32,System.Int32,System.Int32)", 954910932, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcSetSimulationState(bool simulate)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteBool(simulate);
			SendRPCInternal("System.Void Enviro.DayNightManager::RpcSetSimulationState(System.Boolean)", -2106757771, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcCloseDayEndPanel()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendRPCInternal("System.Void Enviro.DayNightManager::RpcCloseDayEndPanel()", 260489567, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcPlayAlarm()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendRPCInternal("System.Void Enviro.DayNightManager::RpcPlayAlarm()", -1661649951, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcSyncTimeToAll(float timeOfDay, bool isSimulating, int days, int months, int years)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteFloat(timeOfDay);
			writer.WriteBool(isSimulating);
			writer.WriteVarInt(days);
			writer.WriteVarInt(months);
			writer.WriteVarInt(years);
			SendRPCInternal("System.Void Enviro.DayNightManager::RpcSyncTimeToAll(System.Single,System.Boolean,System.Int32,System.Int32,System.Int32)", -999027819, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		private void UpdateSimulationState()
		{
			if (EnviroManager.instance == null || EnviroManager.instance.Time == null)
			{
				return;
			}
			if (_currentGameDay == 1 && _tutorialTimeStopTriggered && !_isNightTransitionActive)
			{
				if (EnviroManager.instance.Time.Settings.simulate)
				{
					EnviroManager.instance.Time.Settings.simulate = false;
				}
				return;
			}
			float timeOfDay = EnviroManager.instance.Time.GetTimeOfDay();
			bool flag = timeOfDay >= (float)morningStartHour && timeOfDay < (float)(eveningEndHour - 1);
			if (EnviroManager.instance.Time.Settings.simulate == flag)
			{
				return;
			}
			EnviroManager.instance.Time.Settings.simulate = flag;
			if (wasSimulating != flag)
			{
				wasSimulating = flag;
				this.OnSimulationStateChanged?.Invoke(flag);
				if (flag)
				{
					this.OnDayStarted?.Invoke();
				}
				else
				{
					this.OnDayEnded?.Invoke();
				}
			}
		}

		public bool CanPerformAction(float requiredStartHour, float requiredEndHour)
		{
			float currentTimeOfDay = CurrentTimeOfDay;
			if (currentTimeOfDay >= requiredStartHour)
			{
				return currentTimeOfDay < requiredEndHour;
			}
			return false;
		}

		public bool HasEnoughTimeForAction(float estimatedDurationHours)
		{
			float currentTimeOfDay = CurrentTimeOfDay;
			return (float)(eveningEndHour - 1) - currentTimeOfDay >= estimatedDurationHours;
		}

		public string GetTimeString()
		{
			if (EnviroManager.instance == null || EnviroManager.instance.Time == null)
			{
				return "00:00";
			}
			return EnviroManager.instance.Time.GetTimeString();
		}

		public void SetMorningStartHour(int hour)
		{
			if (base.isServer)
			{
				morningStartHour = Mathf.Clamp(hour, 0, 24);
				UpdateSimulationState();
			}
		}

		public void SetEveningEndHour(int hour)
		{
			if (base.isServer)
			{
				eveningEndHour = Mathf.Clamp(hour, 0, 24);
				UpdateSimulationState();
			}
		}

		public void SetTime(float timeOfDay)
		{
			if (base.isServer && !(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
			{
				EnviroManager.instance.Time.SetTimeOfDay(timeOfDay);
				UpdateSimulationState();
				UpdateLightsState();
			}
		}

		public void SetTimeAndSync(float timeOfDay)
		{
			if (base.isServer && !(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
			{
				EnviroManager.instance.Time.SetTimeOfDay(timeOfDay);
				UpdateSimulationState();
				UpdateLightsState();
				RpcSyncTimeToAll(timeOfDay, EnviroManager.instance.Time.Settings.simulate, EnviroManager.instance.Time.days, EnviroManager.instance.Time.months, EnviroManager.instance.Time.years);
			}
		}

		public void StartNewDay()
		{
			if (base.isServer && !(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
			{
				Network_currentGameDay = _currentGameDay + 1;
				EnviroManager.instance.Time.days++;
				EnviroManager.instance.Time.SetTimeOfDay(morningStartHour);
				UpdateSimulationState();
				UpdateLightsState();
				RpcSyncTimeToAll(morningStartHour, EnviroManager.instance.Time.Settings.simulate, EnviroManager.instance.Time.days, EnviroManager.instance.Time.months, EnviroManager.instance.Time.years);
				RpcCloseDayEndPanel();
				RpcPlayAlarm();
				this.OnDayStarted?.Invoke();
			}
		}

		[ContextMenu("Test - Trigger Night Transition")]
		public void TriggerTutorialNightTransition()
		{
			if (base.isServer && !_isNightTransitionActive)
			{
				if (!_tutorialTimeStopTriggered)
				{
					_tutorialTimeStopTriggered = true;
				}
				if (_nightTransitionCoroutine != null)
				{
					StopCoroutine(_nightTransitionCoroutine);
				}
				_nightTransitionCoroutine = StartCoroutine(NightTransitionCoroutine());
			}
		}

		private IEnumerator NightTransitionCoroutine()
		{
			if (!(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
			{
				_isNightTransitionActive = true;
				_originalSimulationSpeed = EnviroManager.instance.Time.Settings.cycleLengthInMinutes;
				float currentTimeOfDay = CurrentTimeOfDay;
				float targetTime = eveningEndHour - 1;
				if (currentTimeOfDay >= targetTime)
				{
					_isNightTransitionActive = false;
					yield break;
				}
				float num = targetTime - currentTimeOfDay;
				float a = nightTransitionDuration / 60f * 24f / num;
				a = Mathf.Max(a, 0.1f);
				EnviroManager.instance.Time.Settings.cycleLengthInMinutes = a;
				EnviroManager.instance.Time.Settings.simulate = true;
				RpcSetFastTransition(a, simulate: true);
				yield return new WaitForSeconds(nightTransitionDuration);
				EnviroManager.instance.Time.SetTimeOfDay(targetTime);
				EnviroManager.instance.Time.Settings.cycleLengthInMinutes = _originalSimulationSpeed;
				RpcSetFastTransition(_originalSimulationSpeed, simulate: false);
				UpdateSimulationState();
				RpcSyncTimeToAll(targetTime, EnviroManager.instance.Time.Settings.simulate, EnviroManager.instance.Time.days, EnviroManager.instance.Time.months, EnviroManager.instance.Time.years);
				_isNightTransitionActive = false;
				_nightTransitionCoroutine = null;
				this.OnDayEnded?.Invoke();
				Debug.Log("OnNightTransitionCompleted: 0");
				this.OnNightTransitionCompleted?.Invoke();
			}
		}

		[ClientRpc]
		private void RpcSetFastTransition(float cycleLength, bool simulate)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteFloat(cycleLength);
			writer.WriteBool(simulate);
			SendRPCInternal("System.Void Enviro.DayNightManager::RpcSetFastTransition(System.Single,System.Boolean)", 2143062459, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		public object GetSaveData(bool includeNonSavable)
		{
			if (!base.isServer)
			{
				return null;
			}
			DayNightSaveData dayNightSaveData = new DayNightSaveData
			{
				currentGameDay = _currentGameDay,
				timeOfDay = CurrentTimeOfDay,
				tutorialTimeStopTriggered = _tutorialTimeStopTriggered,
				isSimulating = IsSimulating
			};
			if (EnviroManager.instance != null && EnviroManager.instance.Time != null)
			{
				dayNightSaveData.enviroDays = EnviroManager.instance.Time.days;
				dayNightSaveData.enviroMonths = EnviroManager.instance.Time.months;
				dayNightSaveData.enviroYears = EnviroManager.instance.Time.years;
			}
			Debug.Log($"[DayNightManager] Save - Gun: {dayNightSaveData.currentGameDay}, Saat: {dayNightSaveData.timeOfDay:F2}");
			return dayNightSaveData;
		}

		public Task OnLoad(object value)
		{
			if (!(value is DayNightSaveData dayNightSaveData))
			{
				Debug.LogWarning("[DayNightManager] Load basarisiz - gecersiz data");
				return Task.CompletedTask;
			}
			if (!base.isServer)
			{
				Debug.Log("[DayNightManager] Client - load atlaniyor, server sync yapacak");
				return Task.CompletedTask;
			}
			Network_currentGameDay = dayNightSaveData.currentGameDay;
			_tutorialTimeStopTriggered = dayNightSaveData.tutorialTimeStopTriggered;
			if (EnviroManager.instance != null && EnviroManager.instance.Time != null)
			{
				EnviroManager.instance.Time.days = dayNightSaveData.enviroDays;
				EnviroManager.instance.Time.months = dayNightSaveData.enviroMonths;
				EnviroManager.instance.Time.years = dayNightSaveData.enviroYears;
				EnviroManager.instance.Time.SetTimeOfDay(dayNightSaveData.timeOfDay);
				EnviroManager.instance.Time.Settings.simulate = dayNightSaveData.isSimulating;
			}
			UpdateLightsState();
			wasSimulating = dayNightSaveData.isSimulating;
			wasLightsOn = ShouldLightsBeOn;
			RpcSyncTimeToAll(dayNightSaveData.timeOfDay, dayNightSaveData.isSimulating, dayNightSaveData.enviroDays, dayNightSaveData.enviroMonths, dayNightSaveData.enviroYears);
			if (IsNighttime)
			{
				this.OnDayEnded?.Invoke();
			}
			Debug.Log($"[DayNightManager] Load - Gun: {_currentGameDay}, Saat: {dayNightSaveData.timeOfDay:F2}, Simulate: {dayNightSaveData.isSimulating}");
			return Task.CompletedTask;
		}

		private void OnEnable()
		{
			SaveLoadManager.Subscribe(this, 50);
			Debug.Log("[DayNightManager] SaveLoadManager'a subscribe olundu");
		}

		private void OnDisable()
		{
			SaveLoadManager.Unsubscribe(this);
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdRequestTimeSync__NetworkConnectionToClient(NetworkConnectionToClient sender)
		{
			if (!(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
			{
				float timeOfDay = EnviroManager.instance.Time.GetTimeOfDay();
				bool simulate = EnviroManager.instance.Time.Settings.simulate;
				int days = EnviroManager.instance.Time.days;
				int months = EnviroManager.instance.Time.months;
				int years = EnviroManager.instance.Time.years;
				TargetSyncTime(sender, timeOfDay, simulate, days, months, years);
			}
		}

		protected static void InvokeUserCode_CmdRequestTimeSync__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdRequestTimeSync called on client.");
			}
			else
			{
				((DayNightManager)obj).UserCode_CmdRequestTimeSync__NetworkConnectionToClient(senderConnection);
			}
		}

		protected void UserCode_TargetSyncTime__NetworkConnectionToClient__Single__Boolean__Int32__Int32__Int32(NetworkConnectionToClient target, float timeOfDay, bool isSimulating, int days, int months, int years)
		{
			if (!(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
			{
				EnviroManager.instance.Time.SetTimeOfDay(timeOfDay);
				EnviroManager.instance.Time.Settings.simulate = isSimulating;
				EnviroManager.instance.Time.days = days;
				EnviroManager.instance.Time.months = months;
				EnviroManager.instance.Time.years = years;
			}
		}

		protected static void InvokeUserCode_TargetSyncTime__NetworkConnectionToClient__Single__Boolean__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("TargetRPC TargetSyncTime called on server.");
			}
			else
			{
				((DayNightManager)obj).UserCode_TargetSyncTime__NetworkConnectionToClient__Single__Boolean__Int32__Int32__Int32(null, reader.ReadFloat(), reader.ReadBool(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt());
			}
		}

		protected void UserCode_RpcSetSimulationState__Boolean(bool simulate)
		{
			if (!base.isServer && EnviroManager.instance != null && EnviroManager.instance.Time != null)
			{
				EnviroManager.instance.Time.Settings.simulate = simulate;
			}
		}

		protected static void InvokeUserCode_RpcSetSimulationState__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcSetSimulationState called on server.");
			}
			else
			{
				((DayNightManager)obj).UserCode_RpcSetSimulationState__Boolean(reader.ReadBool());
			}
		}

		protected void UserCode_RpcCloseDayEndPanel()
		{
			if (!base.isServer && !(GameManager.Instance == null))
			{
				DayEndPanel dayEndPanel = GameManager.Instance.UImanager.dayEndPanel;
				if (dayEndPanel != null)
				{
					dayEndPanel.Close();
				}
			}
		}

		protected static void InvokeUserCode_RpcCloseDayEndPanel(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcCloseDayEndPanel called on server.");
			}
			else
			{
				((DayNightManager)obj).UserCode_RpcCloseDayEndPanel();
			}
		}

		protected void UserCode_RpcPlayAlarm()
		{
			if (alarmAudioSource != null && alarmClip != null)
			{
				alarmAudioSource.PlayOneShot(alarmClip);
			}
		}

		protected static void InvokeUserCode_RpcPlayAlarm(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcPlayAlarm called on server.");
			}
			else
			{
				((DayNightManager)obj).UserCode_RpcPlayAlarm();
			}
		}

		protected void UserCode_RpcSyncTimeToAll__Single__Boolean__Int32__Int32__Int32(float timeOfDay, bool isSimulating, int days, int months, int years)
		{
			if (!base.isServer && !(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
			{
				EnviroManager.instance.Time.SetTimeOfDay(timeOfDay);
				EnviroManager.instance.Time.Settings.simulate = isSimulating;
				EnviroManager.instance.Time.days = days;
				EnviroManager.instance.Time.months = months;
				EnviroManager.instance.Time.years = years;
			}
		}

		protected static void InvokeUserCode_RpcSyncTimeToAll__Single__Boolean__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcSyncTimeToAll called on server.");
			}
			else
			{
				((DayNightManager)obj).UserCode_RpcSyncTimeToAll__Single__Boolean__Int32__Int32__Int32(reader.ReadFloat(), reader.ReadBool(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt());
			}
		}

		protected void UserCode_RpcSetFastTransition__Single__Boolean(float cycleLength, bool simulate)
		{
			if (!base.isServer && EnviroManager.instance != null && EnviroManager.instance.Time != null)
			{
				EnviroManager.instance.Time.Settings.cycleLengthInMinutes = cycleLength;
				EnviroManager.instance.Time.Settings.simulate = simulate;
			}
		}

		protected static void InvokeUserCode_RpcSetFastTransition__Single__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcSetFastTransition called on server.");
			}
			else
			{
				((DayNightManager)obj).UserCode_RpcSetFastTransition__Single__Boolean(reader.ReadFloat(), reader.ReadBool());
			}
		}

		static DayNightManager()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(DayNightManager), "System.Void Enviro.DayNightManager::CmdRequestTimeSync(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestTimeSync__NetworkConnectionToClient, requiresAuthority: false);
			RemoteProcedureCalls.RegisterRpc(typeof(DayNightManager), "System.Void Enviro.DayNightManager::RpcSetSimulationState(System.Boolean)", InvokeUserCode_RpcSetSimulationState__Boolean);
			RemoteProcedureCalls.RegisterRpc(typeof(DayNightManager), "System.Void Enviro.DayNightManager::RpcCloseDayEndPanel()", InvokeUserCode_RpcCloseDayEndPanel);
			RemoteProcedureCalls.RegisterRpc(typeof(DayNightManager), "System.Void Enviro.DayNightManager::RpcPlayAlarm()", InvokeUserCode_RpcPlayAlarm);
			RemoteProcedureCalls.RegisterRpc(typeof(DayNightManager), "System.Void Enviro.DayNightManager::RpcSyncTimeToAll(System.Single,System.Boolean,System.Int32,System.Int32,System.Int32)", InvokeUserCode_RpcSyncTimeToAll__Single__Boolean__Int32__Int32__Int32);
			RemoteProcedureCalls.RegisterRpc(typeof(DayNightManager), "System.Void Enviro.DayNightManager::RpcSetFastTransition(System.Single,System.Boolean)", InvokeUserCode_RpcSetFastTransition__Single__Boolean);
			RemoteProcedureCalls.RegisterRpc(typeof(DayNightManager), "System.Void Enviro.DayNightManager::TargetSyncTime(Mirror.NetworkConnectionToClient,System.Single,System.Boolean,System.Int32,System.Int32,System.Int32)", InvokeUserCode_TargetSyncTime__NetworkConnectionToClient__Single__Boolean__Int32__Int32__Int32);
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			base.SerializeSyncVars(writer, forceAll);
			if (forceAll)
			{
				writer.WriteVarInt(_currentGameDay);
				return;
			}
			writer.WriteVarULong(syncVarDirtyBits);
			if ((syncVarDirtyBits & 1L) != 0L)
			{
				writer.WriteVarInt(_currentGameDay);
			}
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
			base.DeserializeSyncVars(reader, initialState);
			if (initialState)
			{
				GeneratedSyncVarDeserialize(ref _currentGameDay, null, reader.ReadVarInt());
				return;
			}
			long num = (long)reader.ReadVarULong();
			if ((num & 1L) != 0L)
			{
				GeneratedSyncVarDeserialize(ref _currentGameDay, null, reader.ReadVarInt());
			}
		}
	}
}
