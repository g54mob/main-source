using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Digger.Modules.Core.Sources;
using Digger.Modules.Runtime.Sources;
using Enviro;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using I2.Loc;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-20)]
public class SaveLoadGameManager : MonoBehaviour
{
	[Header("Debug")]
	[SerializeField]
	private bool debugLogs = true;

	[Header("Save Cooldown")]
	[Tooltip("Sahne yuklendikten sonra save yapilmadan once beklenecek sure (saniye)")]
	[SerializeField]
	private float initialSaveCooldown = 3f;

	[Header("Events")]
	public UnityEvent onNewGame;

	[Header("Save Slot Variables")]
	[Tooltip("GameCreator GlobalNameVariables - Save slot değişkenini içeren asset")]
	[SerializeField]
	private GlobalNameVariables saveSlotVariables;

	[Tooltip("Save slot değişkeninin adı (int olarak okunacak)")]
	[SerializeField]
	private string saveSlotVariableName = "SaveSlot";

	public UnityEvent onSave;

	public UnityEvent onLoad;

	public static bool isLoadMode;

	private bool canSave;

	private static bool shouldLoadOnStart = false;

	private static bool shouldNewGameOnStart = false;

	private static bool _isLoadingInProgress = false;

	private static int _pendingLoadOperations = 0;

	private static bool isSinglePlayerMode = true;

	private const float LOADING_HIDE_DELAY = 1f;

	private Coroutine _hideLoadingCoroutine;

	private static List<string> _activeReasons = new List<string>();

	private static HashSet<Rigidbody> _kinematicRigidbodies = new HashSet<Rigidbody>();

	public static SaveLoadGameManager Instance { get; private set; }

	public bool CanSaveNow
	{
		get
		{
			if (!NetworkServer.active)
			{
				return false;
			}
			if (!canSave)
			{
				return false;
			}
			bool num = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
			bool flag = TutorialManager.Instance != null && !TutorialManager.Instance.IsTutorialFullyCompleted;
			if (num && flag)
			{
				return false;
			}
			if (Singleton<SaveLoadManager>.Instance != null && Singleton<SaveLoadManager>.Instance.IsSaving)
			{
				return false;
			}
			return true;
		}
	}

	public static bool IsLoadingFromSave => _isLoadingInProgress;

	public static bool IsLoadPendingOrInProgress
	{
		get
		{
			if (!shouldLoadOnStart && !_isLoadingInProgress)
			{
				return _pendingLoadOperations > 0;
			}
			return true;
		}
	}

	public static bool IsSinglePlayerMode => isSinglePlayerMode;

	public static bool HasPendingOperations => _pendingLoadOperations > 0;

	public static void SetSinglePlayerMode()
	{
		isSinglePlayerMode = true;
		Debug.Log("[SaveLoadGameManager] SinglePlayer modu ayarlandi");
	}

	public static void SetMultiplayerMode()
	{
		isSinglePlayerMode = false;
		Debug.Log("[SaveLoadGameManager] Multiplayer modu ayarlandi");
	}

	public static void RequestNewGameOnStart()
	{
		shouldNewGameOnStart = true;
		isLoadMode = false;
		Debug.Log("[SaveLoadGameManager] New game istegi alindi, sahne yuklenince onNewGame tetiklenecek.");
	}

	public static void RequestLoadOnStart()
	{
		shouldLoadOnStart = true;
		isLoadMode = true;
		Debug.Log("[SaveLoadGameManager] Load istegi alindi, sahne yuklenince load yapilacak.");
	}

	public static void ClearLoadRequest()
	{
		shouldLoadOnStart = false;
		shouldNewGameOnStart = false;
		_isLoadingInProgress = false;
		ResetPendingOperations();
		Debug.Log("[SaveLoadGameManager] Load istegi ve tüm loading state'leri temizlendi.");
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		_isLoadingInProgress = false;
		_pendingLoadOperations = 0;
	}

	private void Start()
	{
		StartCoroutine(SubscribeToDayStart());
		StartCoroutine(EnableSaveAfterCooldown());
		if (shouldNewGameOnStart)
		{
			shouldNewGameOnStart = false;
			StartNewGame();
		}
		if (shouldLoadOnStart)
		{
			shouldLoadOnStart = false;
			_isLoadingInProgress = true;
			ResetPendingOperations();
			RegisterPendingLoadOperation();
			LoadGame();
		}
	}

	public static void NotifyLoadComplete()
	{
		_isLoadingInProgress = false;
		Debug.Log("[SaveLoadGameManager] Load işlemi tamamlandı.");
	}

	public static void RegisterPendingLoadOperation()
	{
		RegisterPendingLoadOperation(null);
	}

	public static void RegisterPendingLoadOperation(string reasonKey)
	{
		_pendingLoadOperations++;
		if (!string.IsNullOrEmpty(reasonKey))
		{
			_activeReasons.Add(reasonKey);
			BroadcastCurrentReason();
		}
		Debug.Log(string.Format("[SaveLoadGameManager] Pending operation registered: {0} (reason: {1})\n{2}", _pendingLoadOperations, reasonKey ?? "none", StackTraceUtility.ExtractStackTrace()));
		if (Instance != null && Instance._hideLoadingCoroutine != null)
		{
			Instance.StopCoroutine(Instance._hideLoadingCoroutine);
			Instance._hideLoadingCoroutine = null;
			Debug.Log("[SaveLoadGameManager] Pending hide iptal edildi, yeni operasyon var.");
		}
	}

	public static void CompletePendingLoadOperation()
	{
		CompletePendingLoadOperation(null);
	}

	public static void CompletePendingLoadOperation(string reasonKey)
	{
		_pendingLoadOperations--;
		if (!string.IsNullOrEmpty(reasonKey))
		{
			_activeReasons.Remove(reasonKey);
			if (_activeReasons.Count > 0)
			{
				BroadcastCurrentReason();
			}
		}
		Debug.Log(string.Format("[SaveLoadGameManager] Pending operation completed: {0} (reason: {1})", _pendingLoadOperations, reasonKey ?? "none"));
		if (_pendingLoadOperations > 0)
		{
			return;
		}
		_pendingLoadOperations = 0;
		_activeReasons.Clear();
		if (Instance != null)
		{
			if (Instance._hideLoadingCoroutine != null)
			{
				Instance.StopCoroutine(Instance._hideLoadingCoroutine);
			}
			Instance._hideLoadingCoroutine = Instance.StartCoroutine(Instance.DelayedHideLoading());
		}
	}

	private static void BroadcastCurrentReason()
	{
		if (_activeReasons.Count != 0)
		{
			string text = _activeReasons[_activeReasons.Count - 1];
			string text2 = LocalizationManager.GetTranslation(text);
			if (string.IsNullOrEmpty(text2))
			{
				text2 = text;
			}
			if (NetworkServer.active && NetworkLoadingSync.Instance != null)
			{
				NetworkLoadingSync.Instance.ServerUpdateReason(text2);
			}
			else
			{
				LoadingManagerUI.UpdateReason(text2);
			}
		}
	}

	private IEnumerator DelayedHideLoading()
	{
		Debug.Log($"[SaveLoadGameManager] {1f} saniye bekleniyor...");
		yield return new WaitForSecondsRealtime(1f);
		if (_pendingLoadOperations <= 0)
		{
			NotifyLoadComplete();
			if (NetworkServer.active && NetworkLoadingSync.Instance != null)
			{
				NetworkLoadingSync.Instance.ServerHideAll();
				Debug.Log("[SaveLoadGameManager] Loading UI kapatıldı (HideAll).");
			}
		}
		else
		{
			Debug.Log($"[SaveLoadGameManager] Yeni pending operations var ({_pendingLoadOperations}), loading açık kalıyor.");
		}
		_hideLoadingCoroutine = null;
	}

	public static void ResetPendingOperations()
	{
		_pendingLoadOperations = 0;
		_activeReasons.Clear();
		if (Instance != null && Instance._hideLoadingCoroutine != null)
		{
			Instance.StopCoroutine(Instance._hideLoadingCoroutine);
			Instance._hideLoadingCoroutine = null;
		}
		Debug.Log("[SaveLoadGameManager] Pending operations sıfırlandı.");
	}

	public static void RegisterKinematicForLoad(Rigidbody rb)
	{
		if (!(rb == null))
		{
			rb.isKinematic = true;
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			_kinematicRigidbodies.Add(rb);
			Debug.Log("[SaveLoadGameManager] Kinematic registered: " + rb.gameObject.name);
		}
	}

	public static void ReleaseAllKinematics()
	{
		int count = _kinematicRigidbodies.Count;
		foreach (Rigidbody kinematicRigidbody in _kinematicRigidbodies)
		{
			if (kinematicRigidbody != null)
			{
				kinematicRigidbody.isKinematic = false;
			}
		}
		_kinematicRigidbodies.Clear();
		if (count > 0)
		{
			Debug.Log($"[SaveLoadGameManager] {count} Rigidbody kinematic = false yapıldı.");
		}
	}

	public static void UnregisterKinematic(Rigidbody rb)
	{
		if (rb != null)
		{
			_kinematicRigidbodies.Remove(rb);
		}
	}

	private IEnumerator EnableSaveAfterCooldown()
	{
		canSave = false;
		if (debugLogs)
		{
			Debug.Log($"[SaveLoadGameManager] Save cooldown basladi ({initialSaveCooldown}s)");
		}
		yield return new WaitForSeconds(initialSaveCooldown);
		canSave = true;
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] Save cooldown bitti, save artik yapilabilir.");
		}
		if (PauseMenuManager.Instance != null)
		{
			PauseMenuManager.Instance.RefreshSaveButtonState();
		}
	}

	private IEnumerator SubscribeToDayStart()
	{
		while (DayNightManager.Instance == null)
		{
			yield return null;
		}
		DayNightManager.Instance.OnDayStarted += OnDayStarted;
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] DayNightManager eventine subscribe olundu.");
		}
		while (TutorialManager.Instance == null)
		{
			yield return null;
		}
		TutorialManager.Instance.OnTutorialConfigCompleted += OnTutorialConfigCompleted;
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] TutorialManager eventine subscribe olundu.");
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
			_isLoadingInProgress = false;
			_pendingLoadOperations = 0;
			_activeReasons.Clear();
		}
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
		}
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.OnTutorialConfigCompleted -= OnTutorialConfigCompleted;
		}
		if (Singleton<SaveLoadManager>.Instance != null)
		{
			Singleton<SaveLoadManager>.Instance.EventAfterSave -= OnAfterSave;
		}
	}

	private void OnDayStarted()
	{
		if (NetworkServer.active)
		{
			StartCoroutine(DelayedDayStartSave());
			if (debugLogs)
			{
				Debug.Log("[SaveLoadGameManager] Gun baslangici otomatik kayit yapildi.");
			}
		}
	}

	private IEnumerator DelayedDayStartSave()
	{
		yield return new WaitForSeconds(1f);
		SaveGame();
	}

	private async void OnTutorialConfigCompleted(TutorialConfigType configType)
	{
		if (NetworkServer.active && configType == TutorialConfigType.Day2)
		{
			await SaveGame();
			if (PauseMenuManager.Instance != null)
			{
				PauseMenuManager.Instance.RefreshSaveButtonState();
			}
			if (debugLogs)
			{
				Debug.Log("[SaveLoadGameManager] Day2 tutorial tamamlandi, otomatik kayit yapildi.");
			}
		}
	}

	public async Task SaveGame()
	{
		if (!NetworkServer.active)
		{
			if (debugLogs)
			{
				Debug.LogWarning("[SaveLoadGameManager] SaveGame sadece host tarafindan calistirilabilir.");
			}
			return;
		}
		if (DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1)
		{
			if (debugLogs)
			{
				Debug.LogWarning("[SaveLoadGameManager] Gun 1, kayit atlaniyor.");
			}
			return;
		}
		if (TutorialManager.Instance != null && !TutorialManager.Instance.IsTutorialFullyCompleted)
		{
			if (debugLogs)
			{
				Debug.LogWarning("[SaveLoadGameManager] Tutorial aktif, kayit atlaniyor.");
			}
			return;
		}
		if (!canSave)
		{
			if (debugLogs)
			{
				Debug.LogWarning("[SaveLoadGameManager] Save cooldown aktif, kayit atlaniyor.");
			}
			return;
		}
		if (Singleton<SaveLoadManager>.Instance == null)
		{
			Debug.LogError("[SaveLoadGameManager] SaveLoadManager.Instance bulunamadi!");
			return;
		}
		if (Singleton<SaveLoadManager>.Instance.IsSaving)
		{
			if (debugLogs)
			{
				Debug.LogWarning("[SaveLoadGameManager] Zaten bir kayit islemi devam ediyor.");
			}
			return;
		}
		ShowSavingPanelOnAllClients();
		await Task.Yield();
		PersistDiggerData();
		Singleton<SaveLoadManager>.Instance.EventAfterSave -= OnAfterSave;
		Singleton<SaveLoadManager>.Instance.EventAfterSave += OnAfterSave;
		onSave?.Invoke();
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] Oyun kaydediliyor...");
		}
	}

	private void OnAfterSave(int slot)
	{
		Singleton<SaveLoadManager>.Instance.EventAfterSave -= OnAfterSave;
		StartCoroutine(DelayedHideSavingPanel());
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] Oyun kaydedildi.");
		}
	}

	private IEnumerator DelayedHideSavingPanel()
	{
		yield return new WaitForSecondsRealtime(2f);
		HideSavingPanelOnAllClients();
	}

	private void ShowSavingPanelOnAllClients()
	{
		if (NetworkServer.active && NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerShowSavingPanel();
		}
		else if (PauseMenuManager.Instance != null)
		{
			PauseMenuManager.Instance.ShowSavingPanel();
		}
		if (SteamAppChecker.Instance != null && SteamAppChecker.Instance.IsDemo && FactoryManager.Instance != null && FactoryManager.Instance.Level >= 3)
		{
			GameManager.Instance.UImanager.dayEndPanel.EndDemoAndKickAllPlayers();
		}
	}

	private void HideSavingPanelOnAllClients()
	{
		if (NetworkServer.active && NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerHideSavingPanel();
		}
		else if (PauseMenuManager.Instance != null)
		{
			PauseMenuManager.Instance.HideSavingPanel();
		}
	}

	public void ResetSaveCooldown()
	{
		StopCoroutine("EnableSaveAfterCooldown");
		StartCoroutine(EnableSaveAfterCooldown());
	}

	public void LoadGame()
	{
		StartCoroutine(LoadGameCoroutine());
	}

	private IEnumerator LoadGameCoroutine()
	{
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] DayNightManager bekleniyor...");
		}
		float timeout = 10f;
		float elapsed = 0f;
		while (DayNightManager.Instance == null && elapsed < timeout)
		{
			elapsed += Time.deltaTime;
			yield return null;
		}
		if (DayNightManager.Instance == null)
		{
			Debug.LogWarning("[SaveLoadGameManager] DayNightManager bulunamadi, load iptal edildi.");
			yield break;
		}
		yield return new WaitForSeconds(0.3f);
		onLoad?.Invoke();
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] Load event'i cagirildi.");
		}
		yield return new WaitForSeconds(0.5f);
		CompletePendingLoadOperation();
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] Master pending operation tamamlandı.");
		}
	}

	public static bool HasSaveData()
	{
		if (Singleton<SaveLoadManager>.Instance == null)
		{
			return false;
		}
		return Singleton<SaveLoadManager>.Instance.HasSave();
	}

	public static bool HasSaveDataAt(int slot)
	{
		if (Singleton<SaveLoadManager>.Instance == null)
		{
			return false;
		}
		return Singleton<SaveLoadManager>.Instance.HasSaveAt(slot);
	}

	public async void StartNewGame()
	{
		int cachedSlot = GetCurrentSaveSlot();
		if (Singleton<SaveLoadManager>.Instance != null)
		{
			await Singleton<SaveLoadManager>.Instance.Restart(0);
			if (debugLogs)
			{
				Debug.Log("[SaveLoadGameManager] Save verileri sifirlandi (sahne yuklemeden).");
			}
		}
		if (saveSlotVariables != null && !string.IsNullOrEmpty(saveSlotVariableName))
		{
			Singleton<GlobalNameVariablesManager>.Instance.Set(saveSlotVariables, saveSlotVariableName, cachedSlot);
			if (debugLogs)
			{
				Debug.Log($"[SaveLoadGameManager] SaveSlot geri yazıldı: {cachedSlot}");
			}
		}
		onNewGame?.Invoke();
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] Yeni oyun basladi, onNewGame event'i cagirildi.");
		}
	}

	public int GetCurrentSaveSlot()
	{
		if (saveSlotVariables == null || string.IsNullOrEmpty(saveSlotVariableName))
		{
			if (debugLogs)
			{
				Debug.LogWarning("[SaveLoadGameManager] saveSlotVariables tanımlanmamış - varsayılan slot 1");
			}
			return 1;
		}
		try
		{
			if (!Singleton<GlobalNameVariablesManager>.Instance.Exists(saveSlotVariables, saveSlotVariableName))
			{
				if (debugLogs)
				{
					Debug.LogWarning("[SaveLoadGameManager] '" + saveSlotVariableName + "' değişkeni bulunamadı - varsayılan slot 1");
				}
				return 1;
			}
			int num = Convert.ToInt32(Singleton<GlobalNameVariablesManager>.Instance.Get(saveSlotVariables, saveSlotVariableName));
			if (debugLogs)
			{
				Debug.Log($"[SaveLoadGameManager] GlobalNameVariables'dan slot okundu: {num}");
			}
			return (num <= 0) ? 1 : num;
		}
		catch (Exception ex)
		{
			Debug.LogError("[SaveLoadGameManager] Slot değişkeni okunamadı: " + ex.Message);
			return 1;
		}
	}

	private void PersistDiggerData()
	{
		DiggerMasterRuntime diggerMasterRuntime = UnityEngine.Object.FindFirstObjectByType<DiggerMasterRuntime>();
		if (diggerMasterRuntime == null)
		{
			return;
		}
		if (diggerMasterRuntime.IsRunningAsync)
		{
			Debug.LogWarning("[SaveLoadGameManager] Digger async işlem devam ediyor, persist ertelendi.");
			return;
		}
		if (DiggerSlotInitializer.NeedsCleanPersistOnSave)
		{
			diggerMasterRuntime.DeleteAllPersistedData();
			DiggerSlotInitializer.NeedsCleanPersistOnSave = false;
			DiggerSystem.SkipPersistedDataOnRead = false;
			Debug.Log("[SaveLoadGameManager] Clean persist: eski Digger dosyaları silindi.");
		}
		int num = 0;
		DiggerSystem[] array = UnityEngine.Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
		foreach (DiggerSystem diggerSystem in array)
		{
			VoxelChunk[] componentsInChildren = diggerSystem.GetComponentsInChildren<VoxelChunk>();
			foreach (VoxelChunk voxelChunk in componentsInChildren)
			{
				if (voxelChunk.HasAlteredVoxels())
				{
					diggerSystem.EnsureChunkWillBePersisted(voxelChunk);
					num++;
				}
			}
		}
		if (debugLogs)
		{
			Debug.Log($"[SaveLoadGameManager] Persist öncesi {num} altered chunk işaretlendi.");
		}
		diggerMasterRuntime.PersistAll();
		if (debugLogs)
		{
			Debug.Log("[SaveLoadGameManager] Digger terrain verisi persist edildi.");
		}
	}

	[ContextMenu("Manuel Kaydet")]
	private void ContextMenuSaveGame()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("[SaveLoadGameManager] Kayit sadece Play modunda calisir.");
		}
		else
		{
			SaveGame();
		}
	}

	[ContextMenu("Save Durumunu Kontrol Et")]
	private void ContextMenuCheckHasSave()
	{
		bool flag = HasSaveData();
		Debug.Log("[SaveLoadGameManager] Save durumu: " + (flag ? "MEVCUT" : "YOK"));
	}

	[ContextMenu("Yeni Oyun Baslat")]
	private void ContextMenuNewGame()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("[SaveLoadGameManager] Yeni oyun sadece Play modunda calisir.");
		}
		else
		{
			StartNewGame();
		}
	}
}
