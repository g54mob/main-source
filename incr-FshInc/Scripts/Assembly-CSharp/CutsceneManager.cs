using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
	[Header("Scene References")]
	[Tooltip("Set automatically at runtime by ZoneCutsceneRegistrar on the zone prefab. You do NOT need to assign this manually.")]
	[SerializeField]
	private PlayableDirector director;

	[Header("Day-Based Cutscenes")]
	[Tooltip("Cutscenes keyed to a specific global day number (GameManager.CurrentDay). Leave empty if you only use zone-visit cutscenes.")]
	public DayCutsceneEntry[] dayCutscenes;

	[Header("Zone Visit Cutscenes")]
	[Tooltip("Cutscenes keyed to a specific zone + how many times the player has visited it. ZoneData.expeditionCount is used as the visit counter.")]
	public ZoneVisitEntry[] zoneVisitCutscenes;

	[Header("Skip Settings")]
	[Tooltip("Key the player can press to skip a skippable Timeline.")]
	public KeyCode skipKey = KeyCode.Space;

	private bool _waitingForDialogue;

	private bool _skipRequested;

	private CutsceneEntry _currentEntry;

	private const string PrefsKeyPrefix = "CutsceneSeen_Day_";

	private Canvas _mainUICanvas;

	private GameObject _cinematicBarsCanvas;

	public static CutsceneManager Instance { get; private set; }

	public bool IsCutsceneActive { get; private set; }

	public bool IsBlockingFishing
	{
		get
		{
			if (IsCutsceneActive)
			{
				return _currentEntry?.blockFishing ?? false;
			}
			return false;
		}
	}

	public static event Action OnCutsceneEnd;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Debug.Log("[CutsceneManager] ✅ Instance created. Ready.");
	}

	private void Update()
	{
		if (IsCutsceneActive && Input.GetKeyDown(skipKey))
		{
			_skipRequested = true;
		}
	}

	public void TryPlayCutsceneForDay(int dayNumber)
	{
		if (dayCutscenes == null || dayCutscenes.Length == 0)
		{
			Debug.Log($"[CutsceneManager] No day-based cutscenes configured. (Day {dayNumber})");
			return;
		}
		DayCutsceneEntry dayCutsceneEntry = null;
		DayCutsceneEntry[] array = dayCutscenes;
		foreach (DayCutsceneEntry dayCutsceneEntry2 in array)
		{
			if (dayCutsceneEntry2.dayNumber == dayNumber)
			{
				dayCutsceneEntry = dayCutsceneEntry2;
				break;
			}
		}
		if (dayCutsceneEntry == null)
		{
			Debug.Log($"[CutsceneManager] No cutscene registered for day {dayNumber}. (Total entries: {dayCutscenes.Length})");
			return;
		}
		if (dayCutsceneEntry.sequence != null && dayCutsceneEntry.sequence.Length != 0 && dayCutsceneEntry.sequence[0].playOnce)
		{
			string key = "CutsceneSeen_Day_Day_" + dayNumber;
			if (PlayerPrefs.GetInt(key, 0) == 1)
			{
				Debug.Log($"[CutsceneManager] Day {dayNumber} cutscene already seen.");
				return;
			}
			PlayerPrefs.SetInt(key, 1);
			PlayerPrefs.Save();
		}
		Debug.Log($"[CutsceneManager] ▶ Day {dayNumber} cutscene sequence. Entries: {dayCutsceneEntry.sequence.Length}");
		PlayCutscene(dayCutsceneEntry.sequence);
	}

	public void NotifyZoneLoaded(ZoneData zoneData)
	{
		if (zoneData == null)
		{
			return;
		}
		string key = "ZoneExpeditions_" + zoneData.zoneName;
		zoneData.expeditionCount = PlayerPrefs.GetInt(key, 0) + 1;
		PlayerPrefs.SetInt(key, zoneData.expeditionCount);
		PlayerPrefs.Save();
		int expeditionCount = zoneData.expeditionCount;
		Debug.Log($"[CutsceneManager] Zone '{zoneData.zoneName}' — visit #{expeditionCount}.");
		if (zoneVisitCutscenes == null)
		{
			return;
		}
		ZoneVisitEntry[] array = zoneVisitCutscenes;
		foreach (ZoneVisitEntry zoneVisitEntry in array)
		{
			if (!(zoneVisitEntry.zone == zoneData) || zoneVisitEntry.visitNumber != expeditionCount || zoneVisitEntry.sequence == null || zoneVisitEntry.sequence.Length == 0)
			{
				continue;
			}
			if (zoneVisitEntry.sequence[0].playOnce)
			{
				string key2 = $"CutsceneSeen_Zone_{zoneData.zoneName}_Visit{expeditionCount}";
				if (PlayerPrefs.GetInt(key2, 0) == 1)
				{
					Debug.Log($"[CutsceneManager] Zone '{zoneData.zoneName}' visit #{expeditionCount} cutscene already seen. Skipping.");
					break;
				}
				PlayerPrefs.SetInt(key2, 1);
				PlayerPrefs.Save();
			}
			Debug.Log($"[CutsceneManager] ▶ Zone visit cutscene for '{zoneData.zoneName}' visit #{expeditionCount}. Entries: {zoneVisitEntry.sequence.Length}");
			PlayCutscene(zoneVisitEntry.sequence);
			break;
		}
	}

	public void ResetZoneVisitCount(ZoneData zoneData)
	{
		if (zoneData == null)
		{
			return;
		}
		zoneData.expeditionCount = 0;
		PlayerPrefs.DeleteKey("ZoneExpeditions_" + zoneData.zoneName);
		if (zoneVisitCutscenes != null)
		{
			ZoneVisitEntry[] array = zoneVisitCutscenes;
			foreach (ZoneVisitEntry zoneVisitEntry in array)
			{
				if (zoneVisitEntry.zone == zoneData)
				{
					PlayerPrefs.DeleteKey($"CutsceneSeen_Zone_{zoneData.zoneName}_Visit{zoneVisitEntry.visitNumber}");
				}
			}
		}
		PlayerPrefs.Save();
		Debug.Log("[CutsceneManager] Reset visit count + seen-flags for zone '" + zoneData.zoneName + "'.");
	}

	public void SetDirector(PlayableDirector d)
	{
		director = d;
	}

	public void PlayCutscene(params CutsceneEntry[] sequence)
	{
		if (sequence != null && sequence.Length != 0)
		{
			IsCutsceneActive = true;
			StartCoroutine(PlayCutsceneRoutine(sequence));
		}
	}

	public void ResetCutscene(int dayNumber)
	{
		PlayerPrefs.DeleteKey("CutsceneSeen_Day_" + dayNumber);
		PlayerPrefs.Save();
		Debug.Log($"[CutsceneManager] Reset seen-flag for day {dayNumber}.");
	}

	[ContextMenu("Testing/Reset All Day Cutscenes")]
	private void Debug_ResetAllDayCutscenes()
	{
		if (dayCutscenes == null || dayCutscenes.Length == 0)
		{
			Debug.LogWarning("[CutsceneManager] No day cutscenes configured.");
			return;
		}
		DayCutsceneEntry[] array = dayCutscenes;
		foreach (DayCutsceneEntry dayCutsceneEntry in array)
		{
			PlayerPrefs.DeleteKey("CutsceneSeen_Day_Day_" + dayCutsceneEntry.dayNumber);
			Debug.Log($"[CutsceneManager] ✅ Reset day cutscene flag: Day {dayCutsceneEntry.dayNumber}");
		}
		PlayerPrefs.Save();
		Debug.Log("[CutsceneManager] All day cutscene flags cleared.");
	}

	[ContextMenu("Testing/Reset All Zone Cutscenes")]
	private void Debug_ResetAllZoneCutscenes()
	{
		if (zoneVisitCutscenes == null || zoneVisitCutscenes.Length == 0)
		{
			Debug.LogWarning("[CutsceneManager] No zone visit cutscenes configured.");
			return;
		}
		ZoneVisitEntry[] array = zoneVisitCutscenes;
		foreach (ZoneVisitEntry zoneVisitEntry in array)
		{
			if (!(zoneVisitEntry.zone == null))
			{
				string key = $"CutsceneSeen_Zone_{zoneVisitEntry.zone.zoneName}_Visit{zoneVisitEntry.visitNumber}";
				string key2 = "ZoneExpeditions_" + zoneVisitEntry.zone.zoneName;
				PlayerPrefs.DeleteKey(key);
				PlayerPrefs.DeleteKey(key2);
				zoneVisitEntry.zone.expeditionCount = 0;
				Debug.Log($"[CutsceneManager] ✅ Reset zone cutscene: '{zoneVisitEntry.zone.zoneName}' visit #{zoneVisitEntry.visitNumber}");
			}
		}
		PlayerPrefs.Save();
		Debug.Log("[CutsceneManager] All zone cutscene flags + visit counts cleared.");
	}

	[ContextMenu("Testing/Reset Everything")]
	private void Debug_ResetEverything()
	{
		Debug_ResetAllDayCutscenes();
		Debug_ResetAllZoneCutscenes();
		Debug.Log("[CutsceneManager] ✅ Full reset complete. All cutscenes will play again.");
	}

	[ContextMenu("Testing/Replay Last Zone Cutscene")]
	private void Debug_ReplayLastZoneCutscene()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("[CutsceneManager] Must be in Play mode to replay.");
			return;
		}
		if (IsCutsceneActive)
		{
			Debug.LogWarning("[CutsceneManager] A cutscene is already playing.");
			return;
		}
		ZoneData zoneData = ((GameManager.Instance != null) ? GameManager.Instance.currentZone : null);
		if (zoneData == null)
		{
			Debug.LogWarning("[CutsceneManager] No current zone found.");
			return;
		}
		ResetZoneVisitCount(zoneData);
		ZoneVisitEntry[] array = zoneVisitCutscenes;
		foreach (ZoneVisitEntry zoneVisitEntry in array)
		{
			if (zoneVisitEntry.zone == zoneData && zoneVisitEntry.sequence != null && zoneVisitEntry.sequence.Length != 0)
			{
				Debug.Log("[CutsceneManager] ▶ Replaying cutscene for '" + zoneData.zoneName + "'");
				PlayCutscene(zoneVisitEntry.sequence);
				return;
			}
		}
		Debug.LogWarning("[CutsceneManager] No cutscene found for zone '" + zoneData.zoneName + "'.");
	}

	private IEnumerator PlayCutsceneRoutine(CutsceneEntry[] sequence)
	{
		Debug.Log($"[CutsceneManager] Starting sequence of {sequence.Length} entries.");
		for (int i = 0; i < sequence.Length; i++)
		{
			CutsceneEntry entry = sequence[i];
			if (entry == null)
			{
				continue;
			}
			_currentEntry = entry;
			Debug.Log(string.Format("[CutsceneManager] --- Sequence Phase {0} START --- (Timeline: {1}, Dialogue: {2}, BlockFishing: {3})", i, (entry.timelineAsset != null) ? entry.timelineAsset.name : "None", (entry.preDialogue != null || entry.postDialogue != null) ? "Yes" : "No", entry.blockFishing));
			HideCinematicBars();
			if (entry.hideUI)
			{
				_mainUICanvas = FindMainUICanvas();
				if (_mainUICanvas != null)
				{
					_mainUICanvas.gameObject.SetActive(value: false);
				}
			}
			if (entry.preDialogue != null && DialogueManager.Instance != null)
			{
				yield return StartCoroutine(PlayDialogueAndWait(entry.preDialogue));
			}
			if (entry.timelineAsset != null && director == null)
			{
				Debug.LogWarning("[CutsceneManager] No PlayableDirector registered. Make sure your zone prefab has a ZoneCutsceneRegistrar component.");
			}
			if (entry.timelineAsset != null && director != null)
			{
				if (entry.showCinematicBars)
				{
					ShowCinematicBars();
				}
				_skipRequested = false;
				director.Stop();
				director.playableAsset = entry.timelineAsset;
				director.time = 0.0;
				director.initialTime = 0.0;
				director.extrapolationMode = DirectorWrapMode.Hold;
				director.Play();
				int safetyTimeout = 10;
				while (director != null && director.state != PlayState.Playing && safetyTimeout > 0)
				{
					yield return null;
					safetyTimeout--;
				}
				if (director != null && director.state == PlayState.Playing)
				{
					Debug.Log($"[CutsceneManager] Phase {i} Timeline PLAYING: {entry.timelineAsset.name} | Duration: {director.duration:F2}s");
					while (director != null && director.state == PlayState.Playing && director.time < director.duration)
					{
						if (entry.skippable && _skipRequested)
						{
							Debug.Log($"[CutsceneManager] Phase {i} SKIP requested.");
							director.time = director.duration;
							director.Evaluate();
							director.Stop();
							break;
						}
						yield return null;
					}
				}
				else
				{
					Debug.LogWarning(string.Format("[CutsceneManager] Phase {0} Timeline failed to start Playing within timeout. State: {1}", i, (director != null) ? director.state.ToString() : "NULL"));
				}
				string arg = ((director == null) ? "Director destroyed" : ((director.state != PlayState.Playing) ? "State changed" : ((director.time >= director.duration) ? "Reached duration" : "Loop broken")));
				Debug.Log(string.Format("[CutsceneManager] Phase {0} Timeline EXIT: {1} | FinalTime: {2}", i, arg, (director != null) ? director.time.ToString("F2") : "N/A"));
				_skipRequested = false;
				if (entry.showCinematicBars)
				{
					HideCinematicBars();
					yield return new WaitForSeconds(0.6f);
				}
			}
			if (entry.postDialogue != null && DialogueManager.Instance != null)
			{
				yield return StartCoroutine(PlayDialogueAndWait(entry.postDialogue));
			}
			if (entry.hideUI && _mainUICanvas != null)
			{
				_mainUICanvas.gameObject.SetActive(value: true);
				_mainUICanvas = null;
			}
			Debug.Log($"[CutsceneManager] --- Sequence Phase {i} END ---");
		}
		bool flag = sequence.Length == 0 || sequence[^1].stopDirectorOnComplete;
		if (director != null && flag)
		{
			director.Stop();
		}
		IsCutsceneActive = false;
		_currentEntry = null;
		CutsceneManager.OnCutsceneEnd?.Invoke();
		Debug.Log("[CutsceneManager] Cutscene sequence complete.");
	}

	private IEnumerator PlayDialogueAndWait(DialogueSequenceSO sequence)
	{
		_waitingForDialogue = true;
		DialogueManager.OnDialogueEnd += OnDialogueFinished;
		DialogueManager.Instance.ShowDialogue(sequence);
		yield return new WaitUntil(() => !_waitingForDialogue);
		DialogueManager.OnDialogueEnd -= OnDialogueFinished;
	}

	private void OnDialogueFinished()
	{
		_waitingForDialogue = false;
	}

	private Canvas FindMainUICanvas()
	{
		GameObject gameObject = GameObject.FindGameObjectWithTag("MainUI");
		if (gameObject != null)
		{
			return gameObject.GetComponent<Canvas>();
		}
		GameObject gameObject2 = GameObject.Find("HUD") ?? GameObject.Find("Canvas") ?? GameObject.Find("MainCanvas");
		if (gameObject2 != null)
		{
			return gameObject2.GetComponent<Canvas>();
		}
		Canvas[] array = UnityEngine.Object.FindObjectsOfType<Canvas>();
		foreach (Canvas canvas in array)
		{
			if (canvas.gameObject != _cinematicBarsCanvas && canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				return canvas;
			}
		}
		return null;
	}

	public void ShowCinematicBars()
	{
		if (!(_cinematicBarsCanvas != null))
		{
			_cinematicBarsCanvas = new GameObject("CinematicBars_Canvas");
			Canvas canvas = _cinematicBarsCanvas.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.sortingOrder = 32700;
			CanvasScaler canvasScaler = _cinematicBarsCanvas.AddComponent<CanvasScaler>();
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.referenceResolution = new Vector2(1920f, 1080f);
			_cinematicBarsCanvas.AddComponent<GraphicRaycaster>();
			float y = 150f;
			float duration = 0.5f;
			GameObject obj = new GameObject("TopBar");
			obj.transform.SetParent(_cinematicBarsCanvas.transform, worldPositionStays: false);
			obj.AddComponent<Image>().color = Color.black;
			RectTransform component = obj.GetComponent<RectTransform>();
			component.anchorMin = new Vector2(0f, 1f);
			component.anchorMax = new Vector2(1f, 1f);
			component.pivot = new Vector2(0.5f, 1f);
			component.anchoredPosition = Vector2.zero;
			component.sizeDelta = new Vector2(0f, 0f);
			component.DOSizeDelta(new Vector2(0f, y), duration).SetEase(Ease.OutCubic);
			GameObject obj2 = new GameObject("BottomBar");
			obj2.transform.SetParent(_cinematicBarsCanvas.transform, worldPositionStays: false);
			obj2.AddComponent<Image>().color = Color.black;
			RectTransform component2 = obj2.GetComponent<RectTransform>();
			component2.anchorMin = new Vector2(0f, 0f);
			component2.anchorMax = new Vector2(1f, 0f);
			component2.pivot = new Vector2(0.5f, 0f);
			component2.anchoredPosition = Vector2.zero;
			component2.sizeDelta = new Vector2(0f, 0f);
			component2.DOSizeDelta(new Vector2(0f, y), duration).SetEase(Ease.OutCubic);
		}
	}

	public void HideCinematicBars()
	{
		if (_cinematicBarsCanvas != null)
		{
			float num = 0.5f;
			RectTransform rectTransform = _cinematicBarsCanvas.transform.Find("TopBar")?.GetComponent<RectTransform>();
			RectTransform rectTransform2 = _cinematicBarsCanvas.transform.Find("BottomBar")?.GetComponent<RectTransform>();
			if (rectTransform != null)
			{
				rectTransform.DOSizeDelta(new Vector2(0f, 0f), num).SetEase(Ease.InCubic);
			}
			if (rectTransform2 != null)
			{
				rectTransform2.DOSizeDelta(new Vector2(0f, 0f), num).SetEase(Ease.InCubic);
			}
			UnityEngine.Object.Destroy(_cinematicBarsCanvas, num + 0.1f);
			_cinematicBarsCanvas = null;
		}
	}
}
