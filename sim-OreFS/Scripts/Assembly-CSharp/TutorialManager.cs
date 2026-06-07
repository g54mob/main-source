using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Enviro;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class TutorialSaveData
	{
		public bool tutorialCompleted;
	}

	private static bool _loadedFromSave;

	[SyncVar(hook = "OnActiveTutorialTypeChanged")]
	private int _activeTutorialType;

	[SyncVar(hook = "OnCurrentStepChanged")]
	private int _currentStep;

	[SyncVar(hook = "OnCurrentSubStepChanged")]
	private int _currentSubStep;

	[SyncVar(hook = "OnTutorialActiveChanged")]
	private bool _isTutorialActive;

	[SyncVar(hook = "OnTutorialCompletedChanged")]
	private bool _isTutorialCompleted;

	[SyncVar]
	private string _tutorialLockedItemId = "";

	public readonly SyncDictionary<int, int> subStepProgress = new SyncDictionary<int, int>();

	public readonly SyncHashSet<int> completedSubSteps = new SyncHashSet<int>();

	private bool _isAdminCompleting;

	[Header("Tutorial Configurations")]
	public List<TutorialConfig> tutorialConfigs = new List<TutorialConfig>();

	[Header("UI References")]
	public TutorialStepUI stepUI;

	public TutorialInfoUI infoUI;

	[Header("Tutorial Notification")]
	public GameObject stepCompleteNotificationObject;

	public float stepCompleteNotificationDuration = 2f;

	[Header("Audio")]
	public AudioSource audioSource;

	public AudioClip subStepCompleteSound;

	public AudioClip stepCompleteSound;

	[Header("System References")]
	public TutorialUpdater tutorialUpdater;

	[Header("Events")]
	public UnityEvent onTutorialSpawned;

	public UnityEvent onTutorialCompleted;

	private Tutorial activeTutorial;

	private TutorialStepType lastShownStep = (TutorialStepType)(-1);

	private bool _localSetupComplete;

	private Coroutine _stepNotificationCoroutine;

	private Coroutine _showTutorialDelayedCoroutine;

	private int _lastSetupConfigType = -1;

	public Action<int, int> _Mirror_SyncVarHookDelegate__activeTutorialType;

	public Action<int, int> _Mirror_SyncVarHookDelegate__currentStep;

	public Action<int, int> _Mirror_SyncVarHookDelegate__currentSubStep;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate__isTutorialActive;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate__isTutorialCompleted;

	public static TutorialManager Instance { get; private set; }

	public bool IsTutorialFullyCompleted
	{
		get
		{
			if (_isTutorialCompleted)
			{
				return !_isTutorialActive;
			}
			return false;
		}
	}

	public TutorialStepType CurrentStep => (TutorialStepType)_currentStep;

	public TutorialSubStepType CurrentSubStep => (TutorialSubStepType)_currentSubStep;

	public bool IsTutorialRunning => _isTutorialActive;

	public string TutorialLockedItemId => _tutorialLockedItemId;

	public string SaveID => "tutorial-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(TutorialSaveData);

	public LoadMode LoadMode => LoadMode.Greedy;

	public int Network_activeTutorialType
	{
		get
		{
			return _activeTutorialType;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _activeTutorialType, 1uL, _Mirror_SyncVarHookDelegate__activeTutorialType);
		}
	}

	public int Network_currentStep
	{
		get
		{
			return _currentStep;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentStep, 2uL, _Mirror_SyncVarHookDelegate__currentStep);
		}
	}

	public int Network_currentSubStep
	{
		get
		{
			return _currentSubStep;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentSubStep, 4uL, _Mirror_SyncVarHookDelegate__currentSubStep);
		}
	}

	public bool Network_isTutorialActive
	{
		get
		{
			return _isTutorialActive;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isTutorialActive, 8uL, _Mirror_SyncVarHookDelegate__isTutorialActive);
		}
	}

	public bool Network_isTutorialCompleted
	{
		get
		{
			return _isTutorialCompleted;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isTutorialCompleted, 16uL, _Mirror_SyncVarHookDelegate__isTutorialCompleted);
		}
	}

	public string Network_tutorialLockedItemId
	{
		get
		{
			return _tutorialLockedItemId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _tutorialLockedItemId, 32uL, null);
		}
	}

	public event Action<TutorialConfigType> OnTutorialConfigCompleted;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
		if (Instance == this)
		{
			Instance = null;
			_loadedFromSave = false;
		}
		UnsubscribeFromDayNightEvents();
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (_loadedFromSave)
		{
			Debug.Log("[TutorialManager] Save'den yuklendi, tutorial atlaniyor.");
			Network_isTutorialCompleted = true;
			Network_isTutorialActive = false;
			if (tutorialUpdater != null)
			{
				tutorialUpdater.tutorialFinished = true;
				tutorialUpdater.EnableAllInteractables();
			}
			_loadedFromSave = false;
		}
		else
		{
			ResetAllTutorialProgress();
			ServerStartTutorial(TutorialConfigType.Welcome);
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		SubscribeToDayNightEvents();
		SyncHashSet<int> syncHashSet = completedSubSteps;
		syncHashSet.OnChange = (Action<SyncSet<int>.Operation, int>)Delegate.Combine(syncHashSet.OnChange, new Action<SyncSet<int>.Operation, int>(OnCompletedSubStepsChanged));
		SyncDictionary<int, int> syncDictionary = subStepProgress;
		syncDictionary.OnChange = (Action<SyncIDictionary<int, int>.Operation, int, int>)Delegate.Combine(syncDictionary.OnChange, new Action<SyncIDictionary<int, int>.Operation, int, int>(OnSubStepProgressChanged));
		if (infoUI != null)
		{
			infoUI.OnCloseRequested += HandleInfoUIClosed;
		}
	}

	public override void OnStopClient()
	{
		base.OnStopClient();
		SyncHashSet<int> syncHashSet = completedSubSteps;
		syncHashSet.OnChange = (Action<SyncSet<int>.Operation, int>)Delegate.Remove(syncHashSet.OnChange, new Action<SyncSet<int>.Operation, int>(OnCompletedSubStepsChanged));
		SyncDictionary<int, int> syncDictionary = subStepProgress;
		syncDictionary.OnChange = (Action<SyncIDictionary<int, int>.Operation, int, int>)Delegate.Remove(syncDictionary.OnChange, new Action<SyncIDictionary<int, int>.Operation, int, int>(OnSubStepProgressChanged));
		if (infoUI != null)
		{
			infoUI.OnCloseRequested -= HandleInfoUIClosed;
		}
	}

	public void StartTutorial(TutorialConfigType configType)
	{
		if (base.isServer)
		{
			ServerStartTutorial(configType);
		}
		else
		{
			CmdStartTutorial((int)configType);
		}
	}

	public void CompleteSubStep(TutorialConfigType configType, TutorialStepType stepType, TutorialSubStepType subStepType)
	{
		if (base.isServer)
		{
			ServerCompleteSubStep(configType, stepType, subStepType);
		}
		else
		{
			CmdCompleteSubStep((int)configType, (int)stepType, (int)subStepType);
		}
	}

	public bool TryCompleteSubStep(TutorialConfigType configType, TutorialStepType stepType, TutorialSubStepType subStepType)
	{
		if (GetActiveConfig() != configType)
		{
			return false;
		}
		if (IsSubStepCompleted(subStepType))
		{
			return false;
		}
		CompleteSubStep(configType, stepType, subStepType);
		return true;
	}

	public void AddSubStepProgress(TutorialConfigType configType, TutorialStepType stepType, TutorialSubStepType subStepType, int amount = 1)
	{
		if (base.isServer)
		{
			ServerAddSubStepProgress(configType, stepType, subStepType, amount);
		}
		else
		{
			CmdAddSubStepProgress((int)configType, (int)stepType, (int)subStepType, amount);
		}
	}

	public bool TryAddSubStepProgress(TutorialConfigType configType, TutorialStepType stepType, TutorialSubStepType subStepType, int amount = 1)
	{
		if (GetActiveConfig() != configType)
		{
			return false;
		}
		if (IsSubStepCompleted(subStepType))
		{
			return false;
		}
		AddSubStepProgress(configType, stepType, subStepType, amount);
		return true;
	}

	public int GetSubStepProgress(TutorialSubStepType subStepType)
	{
		if (!subStepProgress.ContainsKey((int)subStepType))
		{
			return 0;
		}
		return subStepProgress[(int)subStepType];
	}

	public void StopTutorial(TutorialConfigType configType)
	{
		if (base.isServer)
		{
			ServerStopTutorial();
		}
		else
		{
			CmdStopTutorial();
		}
	}

	public TutorialConfigType GetActiveConfig()
	{
		if (!_isTutorialActive)
		{
			return TutorialConfigType.None;
		}
		return (TutorialConfigType)_activeTutorialType;
	}

	public bool IsSubStepCompleted(TutorialSubStepType subStepType)
	{
		return completedSubSteps.Contains((int)subStepType);
	}

	public void TrySetTutorialLockedItem(string itemId)
	{
		if (!string.IsNullOrEmpty(itemId) && _isTutorialActive && string.IsNullOrEmpty(_tutorialLockedItemId))
		{
			if (base.isServer)
			{
				Network_tutorialLockedItemId = itemId;
				Debug.Log("[TutorialManager] Tutorial locked item belirlendi: " + itemId);
			}
			else
			{
				CmdSetTutorialLockedItem(itemId);
			}
		}
	}

	public bool CanDamageNodeDuringTutorial(string nodeItemId)
	{
		if (!_isTutorialActive)
		{
			return true;
		}
		if (string.IsNullOrEmpty(_tutorialLockedItemId))
		{
			return true;
		}
		return _tutorialLockedItemId == nodeItemId;
	}

	[Command(requiresAuthority = false)]
	private void CmdStartTutorial(int configType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdStartTutorial__Int32(configType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(configType);
		SendCommandInternal("System.Void TutorialManager::CmdStartTutorial(System.Int32)", 1391917417, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdCompleteSubStep(int configType, int stepType, int subStepType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdCompleteSubStep__Int32__Int32__Int32(configType, stepType, subStepType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(configType);
		writer.WriteVarInt(stepType);
		writer.WriteVarInt(subStepType);
		SendCommandInternal("System.Void TutorialManager::CmdCompleteSubStep(System.Int32,System.Int32,System.Int32)", -1137199040, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdAddSubStepProgress(int configType, int stepType, int subStepType, int amount)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddSubStepProgress__Int32__Int32__Int32__Int32(configType, stepType, subStepType, amount);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(configType);
		writer.WriteVarInt(stepType);
		writer.WriteVarInt(subStepType);
		writer.WriteVarInt(amount);
		SendCommandInternal("System.Void TutorialManager::CmdAddSubStepProgress(System.Int32,System.Int32,System.Int32,System.Int32)", -700148956, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdAdvanceFromInfoStep()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAdvanceFromInfoStep();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TutorialManager::CmdAdvanceFromInfoStep()", -47419878, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdStopTutorial()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdStopTutorial();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TutorialManager::CmdStopTutorial()", -146258170, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetTutorialLockedItem(string itemId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetTutorialLockedItem__String(itemId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		SendCommandInternal("System.Void TutorialManager::CmdSetTutorialLockedItem(System.String)", -1601383827, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerStartTutorial(TutorialConfigType configType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::ServerStartTutorial(TutorialConfigType)' called when server was not active");
			return;
		}
		TutorialConfig config = GetConfig(configType);
		if (config == null)
		{
			Debug.LogWarning($"[TutorialManager] Tutorial config bulunamadi: {configType}");
			return;
		}
		if (_isTutorialActive && _activeTutorialType != (int)configType)
		{
			ServerStopTutorial();
		}
		if (_isTutorialActive && _activeTutorialType == (int)configType)
		{
			Debug.LogWarning($"[TutorialManager] Tutorial zaten aktif: {configType}");
			return;
		}
		if (config.tutorialSteps == null || config.tutorialSteps.Count == 0)
		{
			Debug.LogWarning($"[TutorialManager] Tutorial config'te adim yok: {configType}");
			return;
		}
		TutorialStep tutorialStep = config.tutorialSteps[0];
		TutorialSubStep tutorialSubStep = null;
		if (!tutorialStep.isInfoStep && tutorialStep.subSteps != null && tutorialStep.subSteps.Count > 0)
		{
			tutorialSubStep = tutorialStep.subSteps[0];
		}
		subStepProgress.Clear();
		Network_activeTutorialType = (int)configType;
		Network_currentStep = (int)tutorialStep.stepType;
		Network_currentSubStep = (int)(tutorialSubStep?.subStepType ?? TutorialSubStepType.None);
		Network_isTutorialCompleted = false;
		Network_isTutorialActive = true;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			SetupLocalTutorial();
		}
		RpcOnTutorialStarted((int)configType, _currentStep, _currentSubStep);
		if (tutorialStep.isInfoStep && ShouldSkipCoopInfoStep(tutorialStep.stepType))
		{
			ServerAdvanceFromInfoStep();
		}
		SaveTutorialProgress();
		Debug.Log($"[TutorialManager] Tutorial baslatildi: {configType}");
	}

	[Server]
	private void ServerCompleteSubStep(TutorialConfigType configType, TutorialStepType stepType, TutorialSubStepType subStepType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::ServerCompleteSubStep(TutorialConfigType,TutorialStepType,TutorialSubStepType)' called when server was not active");
		}
		else if (_isTutorialActive && _activeTutorialType == (int)configType && !completedSubSteps.Contains((int)subStepType))
		{
			completedSubSteps.Add((int)subStepType);
			Debug.Log($"[TutorialManager] SubStep tamamlandi: {subStepType}");
			EnsureHostLocalSetup();
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				UpdateSubStepUILocal(subStepType);
				PlaySubStepCompleteSound();
			}
			if (tutorialUpdater != null)
			{
				tutorialUpdater.NotifyTriggerCompleted(subStepType);
			}
			ServerAdvanceProgress((int)subStepType);
			SaveTutorialProgress();
		}
	}

	[Server]
	private void ServerAddSubStepProgress(TutorialConfigType configType, TutorialStepType stepType, TutorialSubStepType subStepType, int amount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::ServerAddSubStepProgress(TutorialConfigType,TutorialStepType,TutorialSubStepType,System.Int32)' called when server was not active");
		}
		else if (_isTutorialActive && _activeTutorialType == (int)configType && !completedSubSteps.Contains((int)subStepType))
		{
			int num = (subStepProgress.ContainsKey((int)subStepType) ? subStepProgress[(int)subStepType] : 0);
			num += amount;
			subStepProgress[(int)subStepType] = num;
			EnsureHostLocalSetup();
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				UpdateSubStepProgressUILocal(subStepType, num);
			}
			RpcOnSubStepProgressChanged((int)subStepType, num);
			TutorialSubStep tutorialSubStep = FindSubStep(configType, stepType, subStepType);
			if (tutorialSubStep != null && num >= Mathf.Max(1, tutorialSubStep.targetCount))
			{
				ServerCompleteSubStep(configType, stepType, subStepType);
			}
			SaveTutorialProgress();
		}
	}

	[Server]
	private void ServerAdvanceProgress(int completedSubStep)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::ServerAdvanceProgress(System.Int32)' called when server was not active");
			return;
		}
		TutorialConfig config = GetConfig((TutorialConfigType)_activeTutorialType);
		if (config == null)
		{
			return;
		}
		if (AreAllStepsCompleted(config))
		{
			ServerCompleteTutorial();
			return;
		}
		TutorialStep tutorialStep = config.tutorialSteps.Find((TutorialStep s) => s.stepType == (TutorialStepType)_currentStep);
		if (tutorialStep != null && !tutorialStep.isInfoStep)
		{
			TutorialSubStep tutorialSubStep = tutorialStep.subSteps.FirstOrDefault((TutorialSubStep s) => !completedSubSteps.Contains((int)s.subStepType));
			if (tutorialSubStep != null)
			{
				Network_currentSubStep = (int)tutorialSubStep.subStepType;
				if (activeTutorial != null)
				{
					activeTutorial.currentSubStep = (TutorialSubStepType)_currentSubStep;
				}
				EnsureHostLocalSetup();
				if (NetworkServer.active && NetworkClient.isConnected)
				{
					ShowCurrentStepLocal();
					if (tutorialUpdater != null && !_isAdminCompleting)
					{
						tutorialUpdater.UpdateTutorials();
					}
				}
				RpcOnStepChanged(_currentStep, _currentSubStep);
				RpcUpdateTutorialTriggers(_currentSubStep, completedSubSteps.ToArray(), completedSubStep);
				return;
			}
		}
		bool flag = false;
		foreach (TutorialStep tutorialStep2 in config.tutorialSteps)
		{
			if (tutorialStep2.stepType == (TutorialStepType)_currentStep)
			{
				flag = true;
			}
			else
			{
				if (!flag)
				{
					continue;
				}
				if (tutorialStep2.isInfoStep)
				{
					int currentStep = _currentStep;
					Network_currentStep = (int)tutorialStep2.stepType;
					Network_currentSubStep = 0;
					if (activeTutorial != null)
					{
						activeTutorial.currentStep = (TutorialStepType)_currentStep;
						activeTutorial.currentSubStep = (TutorialSubStepType)_currentSubStep;
					}
					if (ShouldSkipCoopInfoStep(tutorialStep2.stepType))
					{
						ServerAdvanceFromInfoStep();
						break;
					}
					EnsureHostLocalSetup();
					if (NetworkServer.active && NetworkClient.isConnected)
					{
						if (currentStep != _currentStep)
						{
							StartStepNotification();
						}
						else
						{
							ShowCurrentStepLocal();
						}
						if (tutorialUpdater != null && !_isAdminCompleting)
						{
							tutorialUpdater.UpdateTutorials();
						}
					}
					RpcOnStepChanged(_currentStep, _currentSubStep);
					RpcUpdateTutorialTriggers(_currentSubStep, completedSubSteps.ToArray(), completedSubStep);
					break;
				}
				TutorialSubStep tutorialSubStep2 = tutorialStep2.subSteps.FirstOrDefault((TutorialSubStep s) => !completedSubSteps.Contains((int)s.subStepType));
				if (tutorialSubStep2 == null)
				{
					continue;
				}
				int currentStep2 = _currentStep;
				Network_currentStep = (int)tutorialStep2.stepType;
				Network_currentSubStep = (int)tutorialSubStep2.subStepType;
				if (activeTutorial != null)
				{
					activeTutorial.currentStep = (TutorialStepType)_currentStep;
					activeTutorial.currentSubStep = (TutorialSubStepType)_currentSubStep;
				}
				EnsureHostLocalSetup();
				if (NetworkServer.active && NetworkClient.isConnected)
				{
					if (currentStep2 != _currentStep)
					{
						StartStepNotification();
					}
					else
					{
						ShowCurrentStepLocal();
					}
					if (tutorialUpdater != null && !_isAdminCompleting)
					{
						tutorialUpdater.UpdateTutorials();
					}
				}
				RpcOnStepChanged(_currentStep, _currentSubStep);
				RpcUpdateTutorialTriggers(_currentSubStep, completedSubSteps.ToArray(), completedSubStep);
				break;
			}
		}
	}

	[Server]
	private bool ShouldSkipCoopInfoStep(TutorialStepType stepType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean TutorialManager::ShouldSkipCoopInfoStep(TutorialStepType)' called when server was not active");
			return default(bool);
		}
		if (stepType != TutorialStepType.CoopInfo)
		{
			return false;
		}
		if (SaveLoadGameManager.IsSinglePlayerMode)
		{
			Debug.Log("[TutorialManager] CoopInfo atlaniyor: SinglePlayer modu.");
			return true;
		}
		if (NetworkServer.connections.Count > 1)
		{
			Debug.Log($"[TutorialManager] CoopInfo atlaniyor: Odada {NetworkServer.connections.Count} oyuncu var.");
			return true;
		}
		Debug.Log("[TutorialManager] CoopInfo gosteriliyor: Multiplayer, sadece host odada.");
		return false;
	}

	[Server]
	private void ServerAdvanceFromInfoStep()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::ServerAdvanceFromInfoStep()' called when server was not active");
		}
		else
		{
			if (!_isTutorialActive)
			{
				return;
			}
			TutorialConfig config = GetConfig((TutorialConfigType)_activeTutorialType);
			if (config == null)
			{
				return;
			}
			TutorialStep tutorialStep = config.tutorialSteps.Find((TutorialStep s) => s.stepType == (TutorialStepType)_currentStep);
			if (tutorialStep == null || !tutorialStep.isInfoStep)
			{
				return;
			}
			RpcCloseInfoUI();
			bool flag = false;
			TutorialStep tutorialStep2 = null;
			foreach (TutorialStep tutorialStep3 in config.tutorialSteps)
			{
				if (tutorialStep3.stepType == (TutorialStepType)_currentStep)
				{
					flag = true;
				}
				else if (flag)
				{
					tutorialStep2 = tutorialStep3;
					break;
				}
			}
			if (tutorialStep2 == null)
			{
				ServerCompleteTutorial();
				return;
			}
			_ = _currentStep;
			Network_currentStep = (int)tutorialStep2.stepType;
			if (tutorialStep2.isInfoStep)
			{
				Network_currentSubStep = 0;
			}
			else
			{
				Network_currentSubStep = (int)(((tutorialStep2.subSteps != null && tutorialStep2.subSteps.Count > 0) ? tutorialStep2.subSteps[0] : null)?.subStepType ?? TutorialSubStepType.None);
			}
			if (activeTutorial != null)
			{
				activeTutorial.currentStep = (TutorialStepType)_currentStep;
				activeTutorial.currentSubStep = (TutorialSubStepType)_currentSubStep;
			}
			EnsureHostLocalSetup();
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				StartStepNotification();
			}
			RpcOnStepChanged(_currentStep, _currentSubStep);
			SaveTutorialProgress();
		}
	}

	[Server]
	private void ServerCompleteTutorial()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::ServerCompleteTutorial()' called when server was not active");
			return;
		}
		TutorialConfig config = GetConfig((TutorialConfigType)_activeTutorialType);
		TutorialConfigType activeTutorialType = (TutorialConfigType)_activeTutorialType;
		Network_isTutorialCompleted = true;
		Network_currentStep = 0;
		Network_currentSubStep = 0;
		int num;
		if (config != null)
		{
			num = ((config.nextTutorialConfig != null) ? 1 : 0);
			if (num != 0)
			{
				goto IL_0060;
			}
		}
		else
		{
			num = 0;
		}
		Network_isTutorialActive = false;
		goto IL_0060;
		IL_0060:
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			ClearTutorialUILocal();
			if (tutorialUpdater != null)
			{
				tutorialUpdater.CompleteTutorial(activeTutorialType);
				if (!_isAdminCompleting)
				{
					tutorialUpdater.UpdateTutorials();
				}
			}
			onTutorialCompleted?.Invoke();
			this.OnTutorialConfigCompleted?.Invoke(activeTutorialType);
		}
		RpcOnTutorialCompleted((int)activeTutorialType);
		SaveTutorialProgress();
		Debug.Log($"[TutorialManager] Tutorial tamamlandi: {activeTutorialType}");
		if (num != 0)
		{
			bool skipOpeningDelay = config.nextTutorialConfig.skipOpeningDelay;
			StartCoroutine(StartNextTutorialDelayed(config.nextTutorialConfig.configType, skipOpeningDelay));
		}
	}

	private IEnumerator StartNextTutorialDelayed(TutorialConfigType nextType, bool skipDelay)
	{
		if (!skipDelay)
		{
			yield return new WaitForSeconds(1f);
		}
		if (base.isServer)
		{
			ServerStartTutorial(nextType);
		}
	}

	[Server]
	private void ServerStopTutorial()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::ServerStopTutorial()' called when server was not active");
			return;
		}
		Network_isTutorialActive = false;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			ClearTutorialUILocal();
		}
		RpcOnTutorialStopped();
	}

	[ClientRpc]
	private void RpcOnTutorialStarted(int configType, int stepType, int subStepType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(configType);
		writer.WriteVarInt(stepType);
		writer.WriteVarInt(subStepType);
		SendRPCInternal("System.Void TutorialManager::RpcOnTutorialStarted(System.Int32,System.Int32,System.Int32)", 1562867388, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnSubStepProgressChanged(int subStepKey, int currentCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(subStepKey);
		writer.WriteVarInt(currentCount);
		SendRPCInternal("System.Void TutorialManager::RpcOnSubStepProgressChanged(System.Int32,System.Int32)", 1765096933, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnStepChanged(int stepType, int subStepType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(stepType);
		writer.WriteVarInt(subStepType);
		SendRPCInternal("System.Void TutorialManager::RpcOnStepChanged(System.Int32,System.Int32)", -1369463330, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnTutorialCompleted(int configType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(configType);
		SendRPCInternal("System.Void TutorialManager::RpcOnTutorialCompleted(System.Int32)", 743589182, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnTutorialStopped()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TutorialManager::RpcOnTutorialStopped()", 1946226123, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCloseInfoUI()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TutorialManager::RpcCloseInfoUI()", 1473236101, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUpdateTutorialTriggers(int currentSubStep, int[] completedSubStepsSnapshot, int completedSubStep)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(currentSubStep);
		GeneratedNetworkCode._Write_System_002EInt32_005B_005D(writer, completedSubStepsSnapshot);
		writer.WriteVarInt(completedSubStep);
		SendRPCInternal("System.Void TutorialManager::RpcUpdateTutorialTriggers(System.Int32,System.Int32[],System.Int32)", 272796914, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnActiveTutorialTypeChanged(int oldVal, int newVal)
	{
	}

	private void OnCurrentStepChanged(int oldVal, int newVal)
	{
	}

	private void OnCurrentSubStepChanged(int oldVal, int newVal)
	{
	}

	private void OnTutorialActiveChanged(bool oldVal, bool newVal)
	{
		Debug.Log(string.Format("[TutorialManager] OnTutorialActiveChanged: {0} -> {1}, isServer={2}, activeTutorial={3}", oldVal, newVal, base.isServer, (activeTutorial != null) ? "var" : "null"));
		if (newVal && activeTutorial == null && !base.isServer)
		{
			SetupLocalTutorial();
		}
		else if (!newVal && activeTutorial != null)
		{
			ClearTutorialUILocal();
		}
	}

	private void OnTutorialCompletedChanged(bool oldVal, bool newVal)
	{
	}

	private void OnCompletedSubStepsChanged(SyncSet<int>.Operation op, int item)
	{
		if (_localSetupComplete && (uint)op == 0u)
		{
			UpdateSubStepUILocal((TutorialSubStepType)item);
		}
	}

	private void OnSubStepProgressChanged(SyncIDictionary<int, int>.Operation op, int key, int item)
	{
		if (_localSetupComplete)
		{
			switch (op)
			{
			case SyncIDictionary<int, int>.Operation.OP_ADD:
				UpdateSubStepProgressUILocal((TutorialSubStepType)key, item);
				break;
			case SyncIDictionary<int, int>.Operation.OP_SET:
			{
				int currentCount = (subStepProgress.ContainsKey(key) ? subStepProgress[key] : item);
				UpdateSubStepProgressUILocal((TutorialSubStepType)key, currentCount);
				break;
			}
			}
		}
	}

	private void EnsureHostLocalSetup()
	{
		if (NetworkServer.active && NetworkClient.isConnected && activeTutorial == null && _isTutorialActive)
		{
			SetupLocalTutorial();
		}
	}

	private void SetupLocalTutorial(int overrideConfigType = -1, int overrideStep = -1, int overrideSubStep = -1)
	{
		int num = ((overrideConfigType >= 0) ? overrideConfigType : _activeTutorialType);
		int num2 = ((overrideStep >= 0) ? overrideStep : _currentStep);
		int num3 = ((overrideSubStep >= 0) ? overrideSubStep : _currentSubStep);
		if (activeTutorial != null && _localSetupComplete && _lastSetupConfigType == num)
		{
			if (num2 != (int)activeTutorial.currentStep || num3 != (int)activeTutorial.currentSubStep)
			{
				activeTutorial.currentStep = (TutorialStepType)num2;
				activeTutorial.currentSubStep = (TutorialSubStepType)num3;
				ShowCurrentStepLocal();
			}
			return;
		}
		TutorialConfig config = GetConfig((TutorialConfigType)num);
		if (config == null)
		{
			return;
		}
		_localSetupComplete = false;
		foreach (TutorialStep tutorialStep in config.tutorialSteps)
		{
			if (tutorialStep.isInfoStep || tutorialStep.subSteps == null)
			{
				continue;
			}
			foreach (TutorialSubStep subStep in tutorialStep.subSteps)
			{
				subStep.isCompleted = completedSubSteps.Contains((int)subStep.subStepType);
			}
		}
		activeTutorial = new Tutorial
		{
			currentConfigType = (TutorialConfigType)num,
			isActive = true,
			currentStep = (TutorialStepType)num2,
			currentSubStep = (TutorialSubStepType)num3,
			isCompleted = false,
			lastStep = (TutorialStepType)(-1),
			tutorialConfig = config
		};
		lastShownStep = (TutorialStepType)(-1);
		if (tutorialUpdater != null)
		{
			tutorialUpdater.tutorialFinished = false;
		}
		_localSetupComplete = true;
		_lastSetupConfigType = num;
		if (_showTutorialDelayedCoroutine != null)
		{
			StopCoroutine(_showTutorialDelayedCoroutine);
		}
		_showTutorialDelayedCoroutine = StartCoroutine(ShowTutorialDelayed());
	}

	private IEnumerator ShowTutorialDelayed()
	{
		bool flag = false;
		if (activeTutorial != null && activeTutorial.tutorialConfig != null)
		{
			flag = activeTutorial.tutorialConfig.skipOpeningDelay;
		}
		if (!flag)
		{
			yield return new WaitForSeconds(1f);
		}
		_showTutorialDelayedCoroutine = null;
		ShowCurrentStepLocal();
		CheckDayNightVisibility();
	}

	private void ShowCurrentStepLocal()
	{
		if (activeTutorial == null || activeTutorial.tutorialConfig == null)
		{
			Debug.LogWarning($"[TutorialManager] ShowCurrentStepLocal: activeTutorial null! _isTutorialActive={_isTutorialActive}");
			return;
		}
		foreach (TutorialStep tutorialStep2 in activeTutorial.tutorialConfig.tutorialSteps)
		{
			if (tutorialStep2.isInfoStep || tutorialStep2.subSteps == null)
			{
				continue;
			}
			foreach (TutorialSubStep subStep in tutorialStep2.subSteps)
			{
				subStep.isCompleted = completedSubSteps.Contains((int)subStep.subStepType);
			}
		}
		TutorialStep tutorialStep = activeTutorial.tutorialConfig.tutorialSteps.Find((TutorialStep s) => s.stepType == activeTutorial.currentStep);
		if (tutorialStep == null)
		{
			Debug.LogWarning($"[TutorialManager] ShowCurrentStepLocal: stepData null! currentStep={(TutorialStepType)_currentStep}, config={activeTutorial.currentConfigType}");
			return;
		}
		Debug.Log($"[TutorialManager] ShowCurrentStepLocal: step={tutorialStep.stepType}, isInfo={tutorialStep.isInfoStep}, lastShown={lastShownStep}");
		if (tutorialStep.isInfoStep)
		{
			if (stepUI != null)
			{
				stepUI.Hide();
			}
			if (stepUI != null)
			{
				stepUI.ClearSubStepInstances();
			}
			if (infoUI != null)
			{
				infoUI.Show(tutorialStep, base.isServer);
			}
			lastShownStep = activeTutorial.currentStep;
			return;
		}
		if (infoUI != null)
		{
			infoUI.Hide();
		}
		if (AreAllStepsCompleted(activeTutorial.tutorialConfig))
		{
			Debug.Log("[TutorialManager] ShowCurrentStepLocal: Tum stepler tamamlanmis, return.");
			return;
		}
		if (lastShownStep != activeTutorial.currentStep)
		{
			if (stepUI != null)
			{
				stepUI.DisplayStepHeader(tutorialStep);
			}
			if (audioSource != null && stepCompleteSound != null)
			{
				audioSource.PlayOneShot(stepCompleteSound);
			}
			onTutorialSpawned?.Invoke();
			if (stepUI != null)
			{
				stepUI.ClearSubStepInstances();
				stepUI.ClearSubSteps();
			}
		}
		if (tutorialUpdater != null && !_isAdminCompleting)
		{
			tutorialUpdater.UpdateTutorials();
		}
		if (stepUI != null)
		{
			stepUI.Show();
			stepUI.InitializeStep(tutorialStep, activeTutorial.currentConfigType);
		}
		if (stepUI != null && tutorialStep.subSteps != null)
		{
			stepUI.PopulateSubSteps(tutorialStep.subSteps, (TutorialSubStepType type) => completedSubSteps.Contains((int)type), (TutorialSubStepType type) => subStepProgress.ContainsKey((int)type) ? subStepProgress[(int)type] : 0, base.isServer);
		}
		lastShownStep = activeTutorial.currentStep;
	}

	private void HandleInfoUIClosed()
	{
		if (base.isServer)
		{
			ServerAdvanceFromInfoStep();
		}
		else
		{
			CmdAdvanceFromInfoStep();
		}
	}

	private void UpdateSubStepUILocal(TutorialSubStepType subStepType)
	{
		if (activeTutorial == null)
		{
			return;
		}
		if (stepUI != null)
		{
			TutorialSubStep tutorialSubStep = FindSubStepInActiveTutorial(subStepType);
			int targetCount = ((tutorialSubStep == null) ? 1 : Mathf.Max(1, tutorialSubStep.targetCount));
			stepUI.MarkSubStepCompleted(subStepType, targetCount);
		}
		if (!(activeTutorial.tutorialConfig != null))
		{
			return;
		}
		foreach (TutorialStep tutorialStep in activeTutorial.tutorialConfig.tutorialSteps)
		{
			if (tutorialStep.subSteps == null)
			{
				continue;
			}
			foreach (TutorialSubStep subStep in tutorialStep.subSteps)
			{
				if (subStep.subStepType == subStepType)
				{
					subStep.isCompleted = true;
				}
			}
		}
	}

	private void UpdateSubStepProgressUILocal(TutorialSubStepType subStepType, int currentCount)
	{
		if (activeTutorial != null && stepUI != null)
		{
			stepUI.UpdateSubStepProgress(subStepType, currentCount);
		}
	}

	private void PlaySubStepCompleteSound()
	{
		if (audioSource != null && subStepCompleteSound != null)
		{
			audioSource.PlayOneShot(subStepCompleteSound);
		}
	}

	private void StartStepNotification()
	{
		if (_stepNotificationCoroutine != null)
		{
			StopCoroutine(_stepNotificationCoroutine);
			_stepNotificationCoroutine = null;
			if (stepCompleteNotificationObject != null)
			{
				stepCompleteNotificationObject.SetActive(value: false);
			}
		}
		_stepNotificationCoroutine = StartCoroutine(ShowStepCompleteNotificationLocal());
	}

	private IEnumerator ShowStepCompleteNotificationLocal()
	{
		bool flag = false;
		if (activeTutorial != null && activeTutorial.tutorialConfig != null)
		{
			TutorialStep tutorialStep = activeTutorial.tutorialConfig.tutorialSteps.Find((TutorialStep s) => s.stepType == activeTutorial.currentStep);
			if (tutorialStep != null)
			{
				flag = tutorialStep.skipTransitionDelay;
			}
		}
		if (stepUI != null)
		{
			stepUI.Hide();
		}
		if (infoUI != null)
		{
			infoUI.Hide();
		}
		if (stepUI != null)
		{
			stepUI.ClearSubStepInstances();
		}
		if (!flag)
		{
			if (stepCompleteNotificationObject != null)
			{
				stepCompleteNotificationObject.SetActive(value: true);
				yield return new WaitForSeconds(stepCompleteNotificationDuration);
				stepCompleteNotificationObject.SetActive(value: false);
			}
			else
			{
				yield return new WaitForSeconds(stepCompleteNotificationDuration);
			}
		}
		_stepNotificationCoroutine = null;
		lastShownStep = (TutorialStepType)(-1);
		Debug.Log(string.Format("[TutorialManager] ShowStepCompleteNotificationLocal: Notification bitti, ShowCurrentStepLocal cagiriliyor. _currentStep={0}, activeTutorial={1}", (TutorialStepType)_currentStep, (activeTutorial != null) ? "var" : "null"));
		ShowCurrentStepLocal();
	}

	private void ClearTutorialUILocal()
	{
		_localSetupComplete = false;
		if (_showTutorialDelayedCoroutine != null)
		{
			StopCoroutine(_showTutorialDelayedCoroutine);
			_showTutorialDelayedCoroutine = null;
		}
		if (_stepNotificationCoroutine != null)
		{
			StopCoroutine(_stepNotificationCoroutine);
			_stepNotificationCoroutine = null;
		}
		if (stepCompleteNotificationObject != null)
		{
			stepCompleteNotificationObject.SetActive(value: false);
		}
		if (stepUI != null)
		{
			stepUI.Hide();
			stepUI.ClearSubStepInstances();
		}
		if (infoUI != null)
		{
			infoUI.Hide();
		}
		activeTutorial = null;
		lastShownStep = (TutorialStepType)(-1);
		_lastSetupConfigType = -1;
	}

	private void SubscribeToDayNightEvents()
	{
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStarted;
			DayNightManager.Instance.OnDayEnded += OnDayEnded;
			DayNightManager.Instance.OnNightTransitionCompleted += OnNightTransitionCompleted;
		}
	}

	private void UnsubscribeFromDayNightEvents()
	{
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
			DayNightManager.Instance.OnDayEnded -= OnDayEnded;
			DayNightManager.Instance.OnNightTransitionCompleted -= OnNightTransitionCompleted;
		}
	}

	private void OnDayStarted()
	{
		if (_isTutorialActive && activeTutorial != null)
		{
			lastShownStep = (TutorialStepType)(-1);
			ShowCurrentStepLocal();
		}
		if (base.isServer)
		{
			_ = DayNightManager.Instance == null;
		}
	}

	private void OnDayEnded()
	{
	}

	private void OnNightTransitionCompleted()
	{
		if (base.isServer && !(DayNightManager.Instance == null) && DayNightManager.Instance.CurrentGameDay == 1)
		{
			ServerStartTutorial(TutorialConfigType.EndDay);
		}
	}

	private void CheckDayNightVisibility()
	{
	}

	[Server]
	private void SaveTutorialProgress()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::SaveTutorialProgress()' called when server was not active");
			return;
		}
		TutorialConfigType activeTutorialType = (TutorialConfigType)_activeTutorialType;
		string text = activeTutorialType.ToString();
		PlayerPrefs.SetInt("Tutorial_" + text + "_Step", _currentStep);
		PlayerPrefs.SetInt("Tutorial_" + text + "_SubStep", _currentSubStep);
		PlayerPrefs.SetInt("Tutorial_" + text + "_Completed", _isTutorialCompleted ? 1 : 0);
		PlayerPrefs.SetInt("Tutorial_" + text + "_Active", _isTutorialActive ? 1 : 0);
		List<string> list = new List<string>();
		foreach (int completedSubStep in completedSubSteps)
		{
			list.Add(completedSubStep.ToString());
		}
		PlayerPrefs.SetString("Tutorial_" + text + "_CompletedSubSteps", string.Join(",", list));
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<int, int> item in subStepProgress)
		{
			list2.Add($"{item.Key}:{item.Value}");
		}
		PlayerPrefs.SetString("Tutorial_" + text + "_SubStepProgress", string.Join(",", list2));
		List<string> list3 = PlayerPrefs.GetString("TutorialKeys", "").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
		if (!list3.Contains(text))
		{
			list3.Add(text);
			PlayerPrefs.SetString("TutorialKeys", string.Join(",", list3));
		}
		PlayerPrefs.Save();
	}

	private void LoadTutorialProgress()
	{
		if (!base.isServer)
		{
			return;
		}
		string text = PlayerPrefs.GetString("TutorialKeys", "");
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		string[] array = text.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text2 in array)
		{
			string text3 = PlayerPrefs.GetString("Tutorial_" + text2 + "_CompletedSubSteps", "");
			if (!string.IsNullOrEmpty(text3))
			{
				string[] array2 = text3.Split(',');
				for (int j = 0; j < array2.Length; j++)
				{
					if (int.TryParse(array2[j].Trim(), out var result))
					{
						completedSubSteps.Add(result);
					}
				}
			}
			bool num = PlayerPrefs.GetInt("Tutorial_" + text2 + "_Active", 0) == 1;
			bool flag = PlayerPrefs.GetInt("Tutorial_" + text2 + "_Completed", 0) == 1;
			if (!num || flag || !Enum.TryParse<TutorialConfigType>(text2, out var result2) || GetConfig(result2) == null)
			{
				continue;
			}
			int num2 = PlayerPrefs.GetInt("Tutorial_" + text2 + "_Step", 0);
			int num3 = PlayerPrefs.GetInt("Tutorial_" + text2 + "_SubStep", 0);
			string text4 = PlayerPrefs.GetString("Tutorial_" + text2 + "_CompletedSubSteps", "");
			string text5 = PlayerPrefs.GetString("Tutorial_" + text2 + "_SubStepProgress", "");
			Network_activeTutorialType = (int)result2;
			Network_currentStep = num2;
			Network_currentSubStep = num3;
			Network_isTutorialActive = true;
			Network_isTutorialCompleted = false;
			completedSubSteps.Clear();
			if (!string.IsNullOrEmpty(text4))
			{
				string[] array2 = text4.Split(',');
				for (int j = 0; j < array2.Length; j++)
				{
					if (int.TryParse(array2[j].Trim(), out var result3))
					{
						completedSubSteps.Add(result3);
					}
				}
			}
			subStepProgress.Clear();
			if (!string.IsNullOrEmpty(text5))
			{
				string[] array2 = text5.Split(',');
				for (int j = 0; j < array2.Length; j++)
				{
					string[] array3 = array2[j].Split(':');
					if (array3.Length == 2 && int.TryParse(array3[0].Trim(), out var result4) && int.TryParse(array3[1].Trim(), out var result5))
					{
						subStepProgress[result4] = result5;
					}
				}
			}
			Debug.Log($"[TutorialManager] Tutorial yuklendi: {result2}, Step: {(TutorialStepType)num2}, SubStep: {(TutorialSubStepType)num3}");
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				SetupLocalTutorial();
			}
			break;
		}
	}

	public void ResetAllTutorialProgress()
	{
		if (!base.isServer)
		{
			return;
		}
		string text = PlayerPrefs.GetString("TutorialKeys", "");
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(',');
			foreach (string text2 in array)
			{
				if (!string.IsNullOrEmpty(text2))
				{
					PlayerPrefs.DeleteKey("Tutorial_" + text2 + "_Step");
					PlayerPrefs.DeleteKey("Tutorial_" + text2 + "_SubStep");
					PlayerPrefs.DeleteKey("Tutorial_" + text2 + "_Completed");
					PlayerPrefs.DeleteKey("Tutorial_" + text2 + "_Active");
					PlayerPrefs.DeleteKey("Tutorial_" + text2 + "_CompletedSubSteps");
					PlayerPrefs.DeleteKey("Tutorial_" + text2 + "_SubStepProgress");
				}
			}
		}
		PlayerPrefs.DeleteKey("TutorialKeys");
		PlayerPrefs.Save();
		completedSubSteps.Clear();
		subStepProgress.Clear();
		Network_tutorialLockedItemId = "";
		Network_isTutorialActive = false;
		Network_isTutorialCompleted = false;
		Network_activeTutorialType = 0;
		Network_currentStep = 0;
		Network_currentSubStep = 0;
		ClearTutorialUILocal();
		RpcOnTutorialStopped();
		Debug.Log("[TutorialManager] Tum tutorial ilerlemesi sifirlandi.");
	}

	private TutorialConfig GetConfig(TutorialConfigType configType)
	{
		return tutorialConfigs.Find((TutorialConfig c) => c.configType == configType);
	}

	private bool IsConfigCompleted(TutorialConfigType configType)
	{
		string text = configType.ToString();
		return PlayerPrefs.GetInt("Tutorial_" + text + "_Completed", 0) == 1;
	}

	private bool AreAllStepsCompleted(TutorialConfig config)
	{
		int num = -1;
		for (int i = 0; i < config.tutorialSteps.Count; i++)
		{
			if (config.tutorialSteps[i].stepType == (TutorialStepType)_currentStep)
			{
				num = i;
				break;
			}
		}
		for (int j = 0; j < config.tutorialSteps.Count; j++)
		{
			TutorialStep tutorialStep = config.tutorialSteps[j];
			if (tutorialStep.isInfoStep)
			{
				if (j >= num)
				{
					return false;
				}
			}
			else
			{
				if (tutorialStep.subSteps == null)
				{
					continue;
				}
				foreach (TutorialSubStep subStep in tutorialStep.subSteps)
				{
					if (!completedSubSteps.Contains((int)subStep.subStepType))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private TutorialSubStep FindSubStep(TutorialConfigType configType, TutorialStepType stepType, TutorialSubStepType subStepType)
	{
		TutorialConfig config = GetConfig(configType);
		if (config == null)
		{
			return null;
		}
		TutorialStep tutorialStep = config.tutorialSteps.Find((TutorialStep s) => s.stepType == stepType);
		if (tutorialStep == null || tutorialStep.subSteps == null)
		{
			return null;
		}
		return tutorialStep.subSteps.Find((TutorialSubStep s) => s.subStepType == subStepType);
	}

	private TutorialSubStep FindSubStepInActiveTutorial(TutorialSubStepType subStepType)
	{
		if (activeTutorial == null || activeTutorial.tutorialConfig == null)
		{
			return null;
		}
		foreach (TutorialStep tutorialStep in activeTutorial.tutorialConfig.tutorialSteps)
		{
			if (tutorialStep.subSteps != null)
			{
				TutorialSubStep tutorialSubStep = tutorialStep.subSteps.Find((TutorialSubStep s) => s.subStepType == subStepType);
				if (tutorialSubStep != null)
				{
					return tutorialSubStep;
				}
			}
		}
		return null;
	}

	[ContextMenu("Debug: Print Tutorial State")]
	private void DebugPrintState()
	{
		Debug.Log($"[TutorialManager] Active: {_isTutorialActive}, Type: {(TutorialConfigType)_activeTutorialType}, " + $"Step: {(TutorialStepType)_currentStep}, SubStep: {(TutorialSubStepType)_currentSubStep}, " + $"Completed: {_isTutorialCompleted}, CompletedSubSteps: {completedSubSteps.Count}, " + $"ProgressEntries: {subStepProgress.Count}");
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		TutorialSaveData tutorialSaveData = new TutorialSaveData
		{
			tutorialCompleted = (_isTutorialCompleted && !_isTutorialActive)
		};
		Debug.Log($"[TutorialManager] Save - Tutorial tamamlandi: {tutorialSaveData.tutorialCompleted}");
		return tutorialSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is TutorialSaveData tutorialSaveData))
		{
			Debug.LogWarning("[TutorialManager] Load basarisiz - gecersiz data");
			return Task.CompletedTask;
		}
		if (tutorialSaveData.tutorialCompleted)
		{
			if (!SaveLoadGameManager.IsLoadPendingOrInProgress)
			{
				Debug.Log("[TutorialManager] OnLoad - Yeni oyun modu, tamamlanmis tutorial verisi yok sayildi.");
				return Task.CompletedTask;
			}
			if (base.isServer)
			{
				Network_isTutorialCompleted = true;
				Network_isTutorialActive = false;
				ClearTutorialUILocal();
				if (tutorialUpdater != null)
				{
					tutorialUpdater.tutorialFinished = true;
					tutorialUpdater.EnableAllInteractables();
				}
				RpcOnTutorialStopped();
				Debug.Log("[TutorialManager] Load - Server aktif, tutorial dogrudan tamamlandi olarak ayarlandi.");
			}
			else
			{
				_loadedFromSave = true;
				Debug.Log("[TutorialManager] Load - _loadedFromSave flag set edildi, OnStartServer beklenecek.");
			}
		}
		return Task.CompletedTask;
	}

	private void OnEnable()
	{
		SaveLoadManager.Subscribe(this, 60);
		Debug.Log("[TutorialManager] SaveLoadManager'a subscribe olundu");
	}

	public TutorialConfig GetCurrentConfig()
	{
		if (!_isTutorialActive || activeTutorial == null)
		{
			return null;
		}
		return activeTutorial.tutorialConfig;
	}

	public TutorialStep GetCurrentStepData()
	{
		TutorialConfig currentConfig = GetCurrentConfig();
		if (currentConfig == null || currentConfig.tutorialSteps == null)
		{
			return null;
		}
		return currentConfig.tutorialSteps.Find((TutorialStep s) => s.stepType == (TutorialStepType)_currentStep);
	}

	public TutorialSubStep GetCurrentSubStepData()
	{
		TutorialStep currentStepData = GetCurrentStepData();
		if (currentStepData == null || currentStepData.subSteps == null || currentStepData.subSteps.Count == 0)
		{
			return null;
		}
		foreach (TutorialSubStep subStep in currentStepData.subSteps)
		{
			if (!subStep.isCompleted)
			{
				return subStep;
			}
		}
		return null;
	}

	[Server]
	public void AdminCompleteConfig(TutorialConfigType configType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::AdminCompleteConfig(TutorialConfigType)' called when server was not active");
			return;
		}
		TutorialConfig config = GetConfig(configType);
		if (config == null)
		{
			Debug.LogWarning($"[TutorialManager] Config bulunamadi: {configType}");
			return;
		}
		if (GetActiveConfig() != configType)
		{
			Debug.LogWarning($"[TutorialManager] AdminCompleteConfig: Tutorial {configType} aktif degil.");
			return;
		}
		bool isAdminCompleting = _isAdminCompleting;
		_isAdminCompleting = true;
		int num = 100;
		int num2 = 0;
		while (_isTutorialActive && _activeTutorialType == (int)configType && num2 < num)
		{
			num2++;
			TutorialStep tutorialStep = config.tutorialSteps.Find((TutorialStep s) => s.stepType == (TutorialStepType)_currentStep);
			if (tutorialStep == null)
			{
				break;
			}
			if (tutorialStep.isInfoStep)
			{
				ServerAdvanceFromInfoStep();
				continue;
			}
			bool flag = false;
			if (tutorialStep.subSteps != null)
			{
				foreach (TutorialSubStep subStep in tutorialStep.subSteps)
				{
					if (!completedSubSteps.Contains((int)subStep.subStepType))
					{
						int num3 = GetSubStepProgress(subStep.subStepType);
						int num4 = Mathf.Max(1, subStep.targetCount) - num3;
						if (num4 > 0)
						{
							ServerAddSubStepProgress(configType, tutorialStep.stepType, subStep.subStepType, num4);
						}
						else
						{
							ServerCompleteSubStep(configType, tutorialStep.stepType, subStep.subStepType);
						}
						flag = true;
					}
				}
			}
			if (!flag)
			{
				break;
			}
		}
		if (!isAdminCompleting)
		{
			_isAdminCompleting = false;
			if (tutorialUpdater != null)
			{
				tutorialUpdater.UpdateTutorials();
			}
		}
		Debug.Log($"[TutorialManager] AdminCompleteConfig tamamlandi: {configType}, iterasyon={num2}");
	}

	public void AdminResetTutorials()
	{
		if (!base.isServer)
		{
			Debug.LogWarning("[TutorialManager] AdminResetTutorials sadece server tarafindan cagrilabilir!");
			return;
		}
		completedSubSteps.Clear();
		subStepProgress.Clear();
		Network_tutorialLockedItemId = "";
		Network_isTutorialActive = false;
		Network_isTutorialCompleted = false;
		Network_activeTutorialType = 0;
		Network_currentStep = 0;
		Network_currentSubStep = 0;
		activeTutorial = null;
		ClearTutorialUILocal();
		RpcOnTutorialStopped();
		Debug.Log("[TutorialManager] Tutorial sistemi sifirlandi!");
	}

	public void AdminAdvanceFromInfoStep()
	{
		if (base.isServer)
		{
			ServerAdvanceFromInfoStep();
		}
		else
		{
			CmdAdvanceFromInfoStep();
		}
	}

	[Server]
	public void AdminCompleteAllTutorials()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TutorialManager::AdminCompleteAllTutorials()' called when server was not active");
			return;
		}
		_isAdminCompleting = true;
		int num = 200;
		int num2 = 0;
		if (!_isTutorialActive)
		{
			ServerStartTutorial(TutorialConfigType.Welcome);
		}
		while (_isTutorialActive && num2 < num)
		{
			num2++;
			TutorialConfigType activeTutorialType = (TutorialConfigType)_activeTutorialType;
			TutorialConfig config = GetConfig(activeTutorialType);
			if (config == null)
			{
				break;
			}
			AdminCompleteConfig(activeTutorialType);
			StopAllCoroutines();
			_showTutorialDelayedCoroutine = null;
			_stepNotificationCoroutine = null;
			if (!_isTutorialActive && config.nextTutorialConfig != null)
			{
				ServerStartTutorial(config.nextTutorialConfig.configType);
			}
		}
		_isAdminCompleting = false;
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.computerUI != null)
		{
			GameManager.Instance.UImanager.computerUI.CloseAllMasks();
		}
		if (tutorialUpdater != null)
		{
			tutorialUpdater.UpdateTutorials();
		}
		Debug.Log($"[TutorialManager] Tum tutorial'lar tamamlandi! (iterasyon={num2})");
	}

	public TutorialManager()
	{
		InitSyncObject(subStepProgress);
		InitSyncObject(completedSubSteps);
		_Mirror_SyncVarHookDelegate__activeTutorialType = OnActiveTutorialTypeChanged;
		_Mirror_SyncVarHookDelegate__currentStep = OnCurrentStepChanged;
		_Mirror_SyncVarHookDelegate__currentSubStep = OnCurrentSubStepChanged;
		_Mirror_SyncVarHookDelegate__isTutorialActive = OnTutorialActiveChanged;
		_Mirror_SyncVarHookDelegate__isTutorialCompleted = OnTutorialCompletedChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdStartTutorial__Int32(int configType)
	{
		ServerStartTutorial((TutorialConfigType)configType);
	}

	protected static void InvokeUserCode_CmdStartTutorial__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStartTutorial called on client.");
		}
		else
		{
			((TutorialManager)obj).UserCode_CmdStartTutorial__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdCompleteSubStep__Int32__Int32__Int32(int configType, int stepType, int subStepType)
	{
		TutorialConfig config = GetConfig((TutorialConfigType)configType);
		if (config == null)
		{
			return;
		}
		TutorialStep tutorialStep = config.tutorialSteps.Find((TutorialStep s) => s.stepType == (TutorialStepType)stepType);
		if (tutorialStep == null)
		{
			return;
		}
		TutorialSubStep tutorialSubStep = tutorialStep.subSteps.Find((TutorialSubStep s) => s.subStepType == (TutorialSubStepType)subStepType);
		if (tutorialSubStep != null)
		{
			if (!tutorialSubStep.canClientComplete)
			{
				Debug.LogWarning($"[TutorialManager] Client tried to complete a host-only substep: {(TutorialSubStepType)subStepType}");
			}
			else
			{
				ServerCompleteSubStep((TutorialConfigType)configType, (TutorialStepType)stepType, (TutorialSubStepType)subStepType);
			}
		}
	}

	protected static void InvokeUserCode_CmdCompleteSubStep__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCompleteSubStep called on client.");
		}
		else
		{
			((TutorialManager)obj).UserCode_CmdCompleteSubStep__Int32__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdAddSubStepProgress__Int32__Int32__Int32__Int32(int configType, int stepType, int subStepType, int amount)
	{
		TutorialConfig config = GetConfig((TutorialConfigType)configType);
		if (config == null)
		{
			return;
		}
		TutorialStep tutorialStep = config.tutorialSteps.Find((TutorialStep s) => s.stepType == (TutorialStepType)stepType);
		if (tutorialStep == null)
		{
			return;
		}
		TutorialSubStep tutorialSubStep = tutorialStep.subSteps.Find((TutorialSubStep s) => s.subStepType == (TutorialSubStepType)subStepType);
		if (tutorialSubStep != null)
		{
			if (!tutorialSubStep.canClientComplete)
			{
				Debug.LogWarning($"[TutorialManager] Client tried to add progress to a host-only substep: {(TutorialSubStepType)subStepType}");
			}
			else
			{
				ServerAddSubStepProgress((TutorialConfigType)configType, (TutorialStepType)stepType, (TutorialSubStepType)subStepType, amount);
			}
		}
	}

	protected static void InvokeUserCode_CmdAddSubStepProgress__Int32__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddSubStepProgress called on client.");
		}
		else
		{
			((TutorialManager)obj).UserCode_CmdAddSubStepProgress__Int32__Int32__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdAdvanceFromInfoStep()
	{
		ServerAdvanceFromInfoStep();
	}

	protected static void InvokeUserCode_CmdAdvanceFromInfoStep(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAdvanceFromInfoStep called on client.");
		}
		else
		{
			((TutorialManager)obj).UserCode_CmdAdvanceFromInfoStep();
		}
	}

	protected void UserCode_CmdStopTutorial()
	{
		ServerStopTutorial();
	}

	protected static void InvokeUserCode_CmdStopTutorial(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStopTutorial called on client.");
		}
		else
		{
			((TutorialManager)obj).UserCode_CmdStopTutorial();
		}
	}

	protected void UserCode_CmdSetTutorialLockedItem__String(string itemId)
	{
		if (_isTutorialActive && string.IsNullOrEmpty(_tutorialLockedItemId))
		{
			Network_tutorialLockedItemId = itemId;
			Debug.Log("[TutorialManager] Tutorial locked item belirlendi (client'tan): " + itemId);
		}
	}

	protected static void InvokeUserCode_CmdSetTutorialLockedItem__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetTutorialLockedItem called on client.");
		}
		else
		{
			((TutorialManager)obj).UserCode_CmdSetTutorialLockedItem__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcOnTutorialStarted__Int32__Int32__Int32(int configType, int stepType, int subStepType)
	{
		if (!base.isServer)
		{
			Debug.Log(string.Format("[TutorialManager] RpcOnTutorialStarted: config={0}, step={1}, activeTutorial={2}", (TutorialConfigType)configType, (TutorialStepType)stepType, (activeTutorial != null) ? "var" : "null"));
			SetupLocalTutorial(configType, stepType, subStepType);
		}
	}

	protected static void InvokeUserCode_RpcOnTutorialStarted__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnTutorialStarted called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_RpcOnTutorialStarted__Int32__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcOnSubStepProgressChanged__Int32__Int32(int subStepKey, int currentCount)
	{
		if (!base.isServer)
		{
			if (activeTutorial == null && _isTutorialActive)
			{
				SetupLocalTutorial();
			}
			UpdateSubStepProgressUILocal((TutorialSubStepType)subStepKey, currentCount);
		}
	}

	protected static void InvokeUserCode_RpcOnSubStepProgressChanged__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnSubStepProgressChanged called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_RpcOnSubStepProgressChanged__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcOnStepChanged__Int32__Int32(int stepType, int subStepType)
	{
		if (!base.isServer)
		{
			Debug.Log(string.Format("[TutorialManager] RpcOnStepChanged: stepType={0}, subStepType={1}, activeTutorial={2}, _isTutorialActive={3}", (TutorialStepType)stepType, (TutorialSubStepType)subStepType, (activeTutorial != null) ? "var" : "null", _isTutorialActive));
			if (activeTutorial == null && _isTutorialActive)
			{
				SetupLocalTutorial(-1, stepType, subStepType);
			}
			int num = (int)((activeTutorial != null) ? activeTutorial.currentStep : ((TutorialStepType)(-1)));
			if (activeTutorial != null)
			{
				activeTutorial.currentStep = (TutorialStepType)stepType;
				activeTutorial.currentSubStep = (TutorialSubStepType)subStepType;
			}
			Debug.Log($"[TutorialManager] RpcOnStepChanged: oldStep={(TutorialStepType)num}, newStep={(TutorialStepType)stepType}, same={num == stepType}");
			if (num != stepType)
			{
				StartStepNotification();
			}
			else
			{
				ShowCurrentStepLocal();
			}
		}
	}

	protected static void InvokeUserCode_RpcOnStepChanged__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnStepChanged called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_RpcOnStepChanged__Int32__Int32(reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcOnTutorialCompleted__Int32(int configType)
	{
		if (base.isServer)
		{
			return;
		}
		Debug.Log($"[TutorialManager] RpcOnTutorialCompleted: configType={(TutorialConfigType)configType}");
		ClearTutorialUILocal();
		if (tutorialUpdater != null)
		{
			tutorialUpdater.CompleteTutorial((TutorialConfigType)configType);
			if (!_isAdminCompleting)
			{
				tutorialUpdater.UpdateTutorials();
			}
		}
		onTutorialCompleted?.Invoke();
	}

	protected static void InvokeUserCode_RpcOnTutorialCompleted__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnTutorialCompleted called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_RpcOnTutorialCompleted__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcOnTutorialStopped()
	{
		if (!base.isServer)
		{
			ClearTutorialUILocal();
		}
	}

	protected static void InvokeUserCode_RpcOnTutorialStopped(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnTutorialStopped called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_RpcOnTutorialStopped();
		}
	}

	protected void UserCode_RpcCloseInfoUI()
	{
		if (!base.isServer && infoUI != null)
		{
			infoUI.Hide();
		}
	}

	protected static void InvokeUserCode_RpcCloseInfoUI(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCloseInfoUI called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_RpcCloseInfoUI();
		}
	}

	protected void UserCode_RpcUpdateTutorialTriggers__Int32__Int32_005B_005D__Int32(int currentSubStep, int[] completedSubStepsSnapshot, int completedSubStep)
	{
		if (base.isServer)
		{
			return;
		}
		if (completedSubStep >= 0)
		{
			if (activeTutorial == null && _isTutorialActive)
			{
				SetupLocalTutorial();
			}
			UpdateSubStepUILocal((TutorialSubStepType)completedSubStep);
			PlaySubStepCompleteSound();
			if (tutorialUpdater != null)
			{
				tutorialUpdater.NotifyTriggerCompleted((TutorialSubStepType)completedSubStep);
			}
		}
		if (tutorialUpdater != null)
		{
			tutorialUpdater.UpdateTutorials((TutorialSubStepType)currentSubStep, completedSubStepsSnapshot);
		}
	}

	protected static void InvokeUserCode_RpcUpdateTutorialTriggers__Int32__Int32_005B_005D__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateTutorialTriggers called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_RpcUpdateTutorialTriggers__Int32__Int32_005B_005D__Int32(reader.ReadVarInt(), GeneratedNetworkCode._Read_System_002EInt32_005B_005D(reader), reader.ReadVarInt());
		}
	}

	static TutorialManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialManager), "System.Void TutorialManager::CmdStartTutorial(System.Int32)", InvokeUserCode_CmdStartTutorial__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialManager), "System.Void TutorialManager::CmdCompleteSubStep(System.Int32,System.Int32,System.Int32)", InvokeUserCode_CmdCompleteSubStep__Int32__Int32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialManager), "System.Void TutorialManager::CmdAddSubStepProgress(System.Int32,System.Int32,System.Int32,System.Int32)", InvokeUserCode_CmdAddSubStepProgress__Int32__Int32__Int32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialManager), "System.Void TutorialManager::CmdAdvanceFromInfoStep()", InvokeUserCode_CmdAdvanceFromInfoStep, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialManager), "System.Void TutorialManager::CmdStopTutorial()", InvokeUserCode_CmdStopTutorial, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialManager), "System.Void TutorialManager::CmdSetTutorialLockedItem(System.String)", InvokeUserCode_CmdSetTutorialLockedItem__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::RpcOnTutorialStarted(System.Int32,System.Int32,System.Int32)", InvokeUserCode_RpcOnTutorialStarted__Int32__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::RpcOnSubStepProgressChanged(System.Int32,System.Int32)", InvokeUserCode_RpcOnSubStepProgressChanged__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::RpcOnStepChanged(System.Int32,System.Int32)", InvokeUserCode_RpcOnStepChanged__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::RpcOnTutorialCompleted(System.Int32)", InvokeUserCode_RpcOnTutorialCompleted__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::RpcOnTutorialStopped()", InvokeUserCode_RpcOnTutorialStopped);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::RpcCloseInfoUI()", InvokeUserCode_RpcCloseInfoUI);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::RpcUpdateTutorialTriggers(System.Int32,System.Int32[],System.Int32)", InvokeUserCode_RpcUpdateTutorialTriggers__Int32__Int32_005B_005D__Int32);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_activeTutorialType);
			writer.WriteVarInt(_currentStep);
			writer.WriteVarInt(_currentSubStep);
			writer.WriteBool(_isTutorialActive);
			writer.WriteBool(_isTutorialCompleted);
			writer.WriteString(_tutorialLockedItemId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_activeTutorialType);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_currentStep);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVarInt(_currentSubStep);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(_isTutorialActive);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteBool(_isTutorialCompleted);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteString(_tutorialLockedItemId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _activeTutorialType, _Mirror_SyncVarHookDelegate__activeTutorialType, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _currentStep, _Mirror_SyncVarHookDelegate__currentStep, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _currentSubStep, _Mirror_SyncVarHookDelegate__currentSubStep, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _isTutorialActive, _Mirror_SyncVarHookDelegate__isTutorialActive, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _isTutorialCompleted, _Mirror_SyncVarHookDelegate__isTutorialCompleted, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _tutorialLockedItemId, null, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _activeTutorialType, _Mirror_SyncVarHookDelegate__activeTutorialType, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentStep, _Mirror_SyncVarHookDelegate__currentStep, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentSubStep, _Mirror_SyncVarHookDelegate__currentSubStep, reader.ReadVarInt());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isTutorialActive, _Mirror_SyncVarHookDelegate__isTutorialActive, reader.ReadBool());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isTutorialCompleted, _Mirror_SyncVarHookDelegate__isTutorialCompleted, reader.ReadBool());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _tutorialLockedItemId, null, reader.ReadString());
		}
	}
}
