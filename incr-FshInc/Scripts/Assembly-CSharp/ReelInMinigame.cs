using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ReelInMinigame : MonoBehaviour
{
	[Serializable]
	public class HeatParticleConfig
	{
		[Range(0f, 1f)]
		public float startThreshold = 0.2f;

		[Range(0f, 1f)]
		public float maxIntensityThreshold = 1f;

		public float minEmission = 5f;

		public float maxEmission = 20f;
	}

	public float dpsForMaxHeat = 10000f;

	[Header("UI References")]
	public CanvasGroup mainCanvasGroup;

	public Image progressBar;

	public Image timerBar;

	public TMP_Text targetText;

	public TMP_Text currentClicksText;

	[Header("Animations")]
	public RectTransform panelRectTransform;

	public Image panelBackgroundImage;

	[Header("Dynamic Bounciness")]
	[Tooltip("The DPS % at which the bounciness reaches its maximum intensity.")]
	public float maxDpsForMaxBounce = 40f;

	[Header("Bounce Intensity Settings")]
	public float minPunchScale = 0.05f;

	public float maxPunchScale = 0.15f;

	[Header("Bounce Speed Settings")]
	public float slowPunchDuration = 0.15f;

	public float fastPunchDuration = 0.08f;

	public float jiggleAmount = 0.02f;

	private float currentDpsPercent;

	[Header("Crit Effect")]
	public GameObject critTextPrefab;

	public float critPunchScaleAmount = 0.1f;

	public float critSpawnHorizontalOffset = 150f;

	[Header("Passive Click VFX")]
	public GameObject passiveClickVFXPrefab;

	[Header("Passive Click VFX")]
	public GameObject normalClickVFXPrefab;

	private int clicksNeeded;

	private float currentClicks;

	private int playerClickCount;

	private float timeLimit = 3f;

	private FishingManager fishingManager;

	private Vector3 initialScale;

	private Color initialPanelColor;

	private bool isMinigameEnding;

	private Coroutine minigameTimerCoroutine;

	private Coroutine passiveClickCoroutine;

	private Vector3 critSpawnWorldPosition;

	private Vector2 initialPanelPosition;

	private bool hasGameStarted;

	private float initialBarHeight;

	private float barWidth;

	public MMF_Player critPlayer;

	public SuperTextMesh dpsText;

	private Queue<KeyValuePair<float, float>> progressHistory = new Queue<KeyValuePair<float, float>>();

	private float currentRawDps;

	private float lastDpsUpdateTime;

	[Header("Heat Feedbacks (On Click)")]
	public MMF_Player feedbackWarm;

	public MMF_Player feedbackHot;

	public MMF_Player feedbackOverload;

	private float dpsUpdateRate = 0.1f;

	[Header("Heat Particles - Steam")]
	public ParticleSystem steamParticles;

	public HeatParticleConfig steamConfig = new HeatParticleConfig
	{
		startThreshold = 0.15f,
		maxIntensityThreshold = 0.5f,
		minEmission = 2f,
		maxEmission = 15f
	};

	[Header("Heat Particles - Smoke")]
	public ParticleSystem smokeParticles;

	public HeatParticleConfig smokeConfig = new HeatParticleConfig
	{
		startThreshold = 0.4f,
		maxIntensityThreshold = 1f,
		minEmission = 5f,
		maxEmission = 30f
	};

	[Header("UI Fire Settings")]
	public CanvasGroup fireCanvasGroup;

	[Range(0f, 1f)]
	public float fireStartThreshold = 0.6f;

	[Range(0f, 1f)]
	public float fireMaxThreshold = 0.9f;

	public float fireFadeSpeed = 5f;

	[Header("Fire Burst Settings")]
	[Range(0f, 1f)]
	public float burstHeatThreshold = 0.9f;

	[Range(0f, 1f)]
	public float burstChancePerFrame = 0.05f;

	public int burstMinCount = 10;

	public int burstMaxCount = 20;

	public SuperTextMesh tutorialHintText;

	public Material fireMaterial;

	[Header("Fire Dynamics")]
	[Tooltip("Drag your 2 Fire RectTransforms here")]
	public List<RectTransform> fireRects;

	[Tooltip("How much to rotate (Z-axis) at max heat. Positive = Outward, Negative = Inward")]
	public float maxFireRotationAngle = 25f;

	private List<Quaternion> initialFireRotations = new List<Quaternion>();

	[Header("Input Control")]
	[Tooltip("Hold-to-reel is disabled by default. Unlocked via the enable_hold_to_reel skill.")]
	public bool allowHoldToClick;

	[Tooltip("Clicks per second for the accessibility auto-reel setting. Separate from the hold-to-reel skill rate.")]
	public float autoReelClicksPerSecond = 5f;

	[Tooltip("Minimum time (in seconds) between manual clicks. Prevents external auto-clickers from spamming too fast. (e.g. 0.05 = max 20 clicks/sec)")]
	public float minManualClickInterval = 0.05f;

	private float _holdClickTimer;

	private float _lastManualClickTime;

	private Coroutine autoReelCoroutine;

	private bool hasDismissedTutorial;

	private float _minigameTimer;

	private float totalDurationElapsed;

	private bool hasNotifiedMaxTime;

	private float maxReelInTimeLimit = 6f;

	public static ReelInMinigame Instance { get; private set; }

	public float CompletionClicks => currentClicks;

	public int RequiredClicks => clicksNeeded;

	public bool IsActive
	{
		get
		{
			if (hasGameStarted)
			{
				return !isMinigameEnding;
			}
			return false;
		}
	}

	public static bool IsAutoReelEnabled => PlayerPrefs.GetInt("Setting_AutoReel", 0) == 1;

	public static event Action<bool> OnReelInComplete;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		if (panelRectTransform != null)
		{
			initialScale = panelRectTransform.localScale;
		}
		if (panelBackgroundImage != null)
		{
			initialPanelColor = panelBackgroundImage.color;
		}
		if (progressBar != null)
		{
			initialBarHeight = progressBar.rectTransform.sizeDelta.y;
			barWidth = progressBar.rectTransform.sizeDelta.x;
		}
		if (fireRects == null)
		{
			return;
		}
		foreach (RectTransform fireRect in fireRects)
		{
			if (fireRect != null)
			{
				initialFireRotations.Add(fireRect.localRotation);
			}
		}
	}

	private void Start()
	{
		PlayerManager instance = PlayerManager.Instance;
		instance.onDayEnd = (Action)Delegate.Combine(instance.onDayEnd, new Action(DayEnded));
	}

	private void DayEnded()
	{
		Debug.Log("Day Ended");
		if (mainCanvasGroup.alpha < 0.5f)
		{
			isMinigameEnding = false;
			currentClicks = 0f;
		}
		else
		{
			StartCoroutine(EndMinigameAnimation(success: false));
		}
	}

	private void OnDestroy()
	{
		if (PlayerManager.Instance != null)
		{
			PlayerManager instance = PlayerManager.Instance;
			instance.onDayEnd = (Action)Delegate.Remove(instance.onDayEnd, new Action(DayEnded));
		}
	}

	private IEnumerator OnShowAnimation()
	{
		yield return null;
		if (panelRectTransform != null)
		{
			float num = Screen.height;
			Vector2 anchoredPosition = new Vector2(initialPanelPosition.x, 0f - num);
			panelRectTransform.anchoredPosition = anchoredPosition;
			panelRectTransform.DOAnchorPos(initialPanelPosition, 0.5f).SetEase(Ease.OutBack);
		}
	}

	private IEnumerator OnHideAnimation()
	{
		yield return null;
		if (panelRectTransform != null)
		{
			float num = Screen.height;
			Vector2 vector = new Vector2(initialPanelPosition.x, 0f - num);
			panelRectTransform.anchoredPosition = vector;
			panelRectTransform.DOAnchorPos(vector, 0.5f).SetEase(Ease.InBack).WaitForCompletion();
			panelRectTransform.anchoredPosition = initialPanelPosition;
		}
	}

	public IEnumerator StartMinigame(CaughtFish fishToCatch, FishingManager manager, Vector3 spawnWorldPos, bool isPerfectCatch = false)
	{
		if (PlayerManager.Instance.dayEnded)
		{
			if (manager != null)
			{
				manager.OnReelInResult(success: false);
			}
			yield break;
		}
		Debug.Log("Crit Chance: " + PlayerStats.Instance.CritClickChance + " | Crit Mult: " + PlayerStats.Instance.CritClickMultiplier);
		progressBar.color = Color.green;
		SoundManager.PlaySound("ReelScream");
		fishingManager = manager;
		isMinigameEnding = false;
		critSpawnWorldPosition = spawnWorldPos;
		clicksNeeded = Mathf.CeilToInt((float)fishToCatch.baseClicks * PlayerStats.Instance.ClicksRequiredMultiplier);
		currentClicks = 0f;
		playerClickCount = 0;
		totalDurationElapsed = 0f;
		hasNotifiedMaxTime = false;
		maxReelInTimeLimit = PlayerStats.Instance.baseReelInTimeLimit + 3f;
		timeLimit = Mathf.Min(PlayerStats.Instance.ReelInTimeLimit, maxReelInTimeLimit);
		if (isPerfectCatch && PlayerStats.Instance.PerfectStartProgressBonus > 0f)
		{
			Debug.Log($"Perfect catch! Starting with {currentClicks = (float)clicksNeeded * PlayerStats.Instance.PerfectStartProgressBonus} clicks ({PlayerStats.Instance.PerfectStartProgressBonus * 100f}% bonus)");
		}
		_minigameTimer = 0f;
		if (isPerfectCatch && PlayerStats.Instance.PerfectCatchTimeRefund > 0f)
		{
			_minigameTimer = 0f - PlayerStats.Instance.PerfectCatchTimeRefund;
			if (timeLimit - _minigameTimer > maxReelInTimeLimit)
			{
				_minigameTimer = timeLimit - maxReelInTimeLimit;
			}
			if (timerBar != null)
			{
				timerBar.color = Color.cyan;
			}
			Debug.Log($"Perfect catch! Applying {PlayerStats.Instance.PerfectCatchTimeRefund}s time refund.");
		}
		else if (timerBar != null)
		{
			timerBar.color = Color.green;
		}
		if (progressBar != null)
		{
			progressBar.rectTransform.sizeDelta = new Vector2(barWidth, 0f);
		}
		timerBar.transform.localScale = new Vector3(timerBar.transform.localScale.x, 1f, timerBar.transform.localScale.z);
		timerBar.DOKill(complete: true);
		timerBar.color = Color.green;
		if (panelRectTransform != null)
		{
			panelRectTransform.localScale = initialScale;
		}
		if (panelBackgroundImage != null)
		{
			panelBackgroundImage.color = initialPanelColor;
		}
		targetText.text = CurrencyFormatter.FormatMoney(clicksNeeded);
		currentClicksText.text = CurrencyFormatter.FormatMoney(Math.Round(currentClicks));
		if (dpsText != null)
		{
			dpsText.text = "";
			dpsText.gameObject.SetActive(value: false);
		}
		progressHistory.Clear();
		ResetEffects();
		ToggleVisibility(visible: true);
		if (tutorialHintText != null)
		{
			hasDismissedTutorial = false;
			tutorialHintText.gameObject.SetActive(value: true);
			LocalizedString localizedString = (IsAutoReelEnabled ? new LocalizedString("Skills", "#ui.hud.reel.hint.auto") : ((!(PlayerStats.Instance != null) || !PlayerStats.Instance.IsHoldToReelEnabled) ? new LocalizedString("Skills", "#ui.hud.reel.hint") : new LocalizedString("Skills", "#ui.hud.reel.hint.hold")));
			tutorialHintText.text = localizedString.GetLocalizedString();
			tutorialHintText.DOKill();
			tutorialHintText.transform.localScale = Vector3.one;
			Color color = tutorialHintText.color;
			color.a = 0f;
			tutorialHintText.color = color;
			DOTween.To(() => tutorialHintText.color, delegate(Color x)
			{
				tutorialHintText.color = x;
			}, new Color(color.r, color.g, color.b, 1f), 0.5f);
			tutorialHintText.transform.DOScale(1.1f, 0.6f).SetLoops(-1, LoopType.Yoyo);
		}
		else
		{
			hasDismissedTutorial = true;
		}
		yield return OnShowAnimation();
		yield return new WaitForSeconds(0.4f);
		hasGameStarted = true;
		UpdateProgressBar();
		StopAllCoroutines();
		minigameTimerCoroutine = StartCoroutine(MinigameTimer());
		if (PlayerStats.Instance.PassiveClicks > 0)
		{
			Debug.Log($"Starting passive clicks: {PlayerStats.Instance.PassiveClicks} clicks, {PlayerStats.Instance.PassiveClickStrength} strength, {PlayerStats.Instance.PassiveClickSpeed} speed");
			passiveClickCoroutine = StartCoroutine(PassiveClickRoutine());
		}
		if (IsAutoReelEnabled)
		{
			autoReelCoroutine = StartCoroutine(AutoReelRoutine());
		}
	}

	public void OnClick()
	{
		if (!hasDismissedTutorial && tutorialHintText != null)
		{
			hasDismissedTutorial = true;
			tutorialHintText.DOKill();
			Color color = tutorialHintText.color;
			DOTween.To(() => tutorialHintText.color, delegate(Color x)
			{
				tutorialHintText.color = x;
			}, new Color(color.r, color.g, color.b, 0f), 0.3f).OnComplete(delegate
			{
				tutorialHintText.gameObject.SetActive(value: false);
			});
		}
		if (CameraController.Instance != null)
		{
			CameraController.Instance.TriggerShake();
			CameraController.Instance.IncrementalZoomIn();
			CameraController.Instance.TriggerVisualPulse();
		}
		SoundManager.PlaySound("reel_progress");
		if (CameraController.Instance != null && CameraController.Instance.enableVisualEffects && passiveClickVFXPrefab != null && panelRectTransform != null)
		{
			Vector3 position = new Vector3(UnityEngine.Random.Range(panelRectTransform.rect.xMin, panelRectTransform.rect.xMax), UnityEngine.Random.Range(panelRectTransform.rect.yMin, panelRectTransform.rect.yMax), 0f);
			UnityEngine.Object.Instantiate(normalClickVFXPrefab, panelRectTransform.transform.TransformPoint(position), Quaternion.identity, panelRectTransform.transform);
		}
		float num = Mathf.Clamp01(currentRawDps / dpsForMaxHeat);
		float num2 = Mathf.Lerp(minPunchScale, maxPunchScale, num);
		float duration = Mathf.Lerp(slowPunchDuration, fastPunchDuration, num);
		playerClickCount++;
		float num3 = PlayerStats.Instance.ReelInClickPower;
		if (UnityEngine.Random.value <= PlayerStats.Instance.CritClickChance * 0.01f)
		{
			num3 *= PlayerStats.Instance.CritClickMultiplier;
			AchievementManager.Instance?.NotifyCriticalClick();
			critPlayer.PlayFeedbacks(base.transform.position);
			SoundManager.PlaySound("CritHit");
			if (critTextPrefab != null)
			{
				LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.crit");
				float num4 = ((UnityEngine.Random.value > 0.5f) ? 1f : (-1f));
				Vector3 worldPosition = new Vector3(critSpawnWorldPosition.x + critSpawnHorizontalOffset * num4, critSpawnWorldPosition.y, critSpawnWorldPosition.z);
				NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), worldPosition, Color.yellow);
			}
			if (PlayerStats.Instance.TimePerCrit > 0f && totalDurationElapsed < PlayerStats.Instance.MaxReelInDuration)
			{
				_minigameTimer -= PlayerStats.Instance.TimePerCrit;
				if (timeLimit - _minigameTimer > maxReelInTimeLimit)
				{
					_minigameTimer = timeLimit - maxReelInTimeLimit;
				}
				if (_minigameTimer < 0f - PlayerStats.Instance.PerfectCatchTimeRefund)
				{
					_minigameTimer = 0f - PlayerStats.Instance.PerfectCatchTimeRefund;
				}
				if (timerBar != null)
				{
					timerBar.DOKill(complete: true);
					timerBar.color = Color.cyan;
				}
			}
			StartCoroutine(ClickPunch(num2 * 2f, duration));
		}
		else
		{
			StartCoroutine(ClickPunch(num2, duration));
		}
		if (num > 0.9f)
		{
			feedbackOverload?.PlayFeedbacks();
		}
		if (num > 0.6f)
		{
			feedbackHot?.PlayFeedbacks();
		}
		if (num > 0.3f)
		{
			feedbackWarm?.PlayFeedbacks();
		}
		currentClicks += num3;
		currentClicksText.text = CurrencyFormatter.FormatMoney(Math.Round(currentClicks));
		if (currentClicks >= (float)clicksNeeded)
		{
			isMinigameEnding = true;
			if (minigameTimerCoroutine != null)
			{
				StopCoroutine(minigameTimerCoroutine);
			}
			if (passiveClickCoroutine != null)
			{
				StopCoroutine(passiveClickCoroutine);
			}
			if (autoReelCoroutine != null)
			{
				StopCoroutine(autoReelCoroutine);
			}
			StartCoroutine(EndMinigameAnimation(success: true));
		}
		RecordProgress(num3);
	}

	private void Update()
	{
		if (Time.timeScale == 0f || isMinigameEnding)
		{
			return;
		}
		if (hasGameStarted)
		{
			totalDurationElapsed += Time.deltaTime;
			if (totalDurationElapsed > PlayerStats.Instance.MaxReelInDuration)
			{
				if (!hasNotifiedMaxTime)
				{
					hasNotifiedMaxTime = true;
					NotificationManager.Instance?.ShowNotification("Max time reached!", critSpawnWorldPosition, Color.red);
					SoundManager.PlaySound("FishCatchNegative");
				}
				float num = 0.05f;
				float num2 = (float)clicksNeeded * num * Time.deltaTime;
				currentClicks = Mathf.Max(0f, currentClicks - num2);
				currentClicksText.text = CurrencyFormatter.FormatMoney(Math.Round(currentClicks));
				if (progressBar != null)
				{
					progressBar.color = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time * 3f, 1f));
				}
			}
			else if (progressBar != null && progressBar.color != Color.green && !isMinigameEnding)
			{
				progressBar.color = Color.green;
			}
			CalculateRawDPS();
			UpdateHeatVisuals();
			UpdateDPSDisplay();
			if (!IsAutoReelEnabled)
			{
				if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
				{
					if (Time.time >= _lastManualClickTime + minManualClickInterval)
					{
						PerformInputClick();
					}
					if (PlayerStats.Instance.HoldClickRate > 0f)
					{
						_holdClickTimer = 1f / PlayerStats.Instance.HoldClickRate;
					}
					else
					{
						_holdClickTimer = 0.2f;
					}
				}
				else if (PlayerStats.Instance.IsHoldToReelEnabled && (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)))
				{
					_holdClickTimer -= Time.deltaTime;
					if (_holdClickTimer <= 0f)
					{
						PerformInputClick();
						if (PlayerStats.Instance.HoldClickRate > 0f)
						{
							_holdClickTimer = 1f / PlayerStats.Instance.HoldClickRate;
						}
						else
						{
							_holdClickTimer = 0.2f;
						}
					}
				}
				else
				{
					_holdClickTimer = 0f;
				}
			}
		}
		UpdateProgressBar();
	}

	private void PerformInputClick()
	{
		OnClick();
		_lastManualClickTime = Time.time;
	}

	private void UpdateProgressBar()
	{
		float num = Mathf.Clamp01(currentClicks / (float)clicksNeeded);
		if (progressBar != null)
		{
			float y = initialBarHeight * num;
			progressBar.rectTransform.sizeDelta = new Vector2(barWidth, y);
		}
	}

	private IEnumerator MinigameTimer()
	{
		Vector3 baseScale = timerBar.transform.localScale;
		while (_minigameTimer < timeLimit)
		{
			float num = Mathf.Max(0f, _minigameTimer) / timeLimit;
			if (CameraController.Instance != null)
			{
				CameraController.Instance.UpdateTensionVignette(num);
			}
			float num2 = Mathf.Clamp01(1f - num);
			timerBar.transform.localScale = new Vector3(baseScale.x, num2, baseScale.z);
			if (_minigameTimer < 0f)
			{
				timerBar.color = Color.cyan;
			}
			else if (num2 > 0.6f)
			{
				timerBar.color = Color.Lerp(Color.yellow, Color.green, (num2 - 0.6f) / 0.4f);
			}
			else if (num2 > 0.3f)
			{
				timerBar.color = Color.Lerp(new Color(1f, 0.5f, 0f), Color.yellow, (num2 - 0.3f) / 0.3f);
			}
			else
			{
				timerBar.color = Color.Lerp(Color.red, new Color(1f, 0.5f, 0f), num2 / 0.3f);
			}
			_minigameTimer += Time.deltaTime;
			yield return null;
		}
		timerBar.transform.localScale = new Vector3(baseScale.x, 0f, baseScale.z);
		isMinigameEnding = true;
		if (passiveClickCoroutine != null)
		{
			StopCoroutine(passiveClickCoroutine);
		}
		StartCoroutine(EndMinigameAnimation(success: false));
	}

	private IEnumerator ClickPunch(float amount, float duration)
	{
		if (CameraController.Instance != null)
		{
			_ = CameraController.Instance.enableScreenShake;
		}
		float pitch = 0.85f + currentClicks / (float)clicksNeeded * 0.3f;
		float volume = currentClicks / (float)clicksNeeded * 0.13f + 0.02f;
		SoundManager.PlaySound("BassClick", volume, pitch);
		float timer = 0f;
		Vector3 punchScale = initialScale * (1f - amount);
		while (timer < duration)
		{
			panelRectTransform.localScale = Vector3.Lerp(initialScale, punchScale, Mathf.PingPong(timer * 2f / duration, 1f));
			timer += Time.deltaTime;
			yield return null;
		}
		panelRectTransform.localScale = initialScale;
	}

	private IEnumerator EndMinigameAnimation(bool success)
	{
		NotificationManager.Instance?.ClearQueue();
		if (tutorialHintText != null)
		{
			tutorialHintText.DOKill();
			tutorialHintText.gameObject.SetActive(value: false);
		}
		if (success)
		{
			if (playerClickCount <= 1)
			{
				AchievementManager.Instance?.NotifyOneShotCatch();
			}
			if (timeLimit - _minigameTimer <= 0.075f)
			{
				SteamAchievementManager.Instance?.NotifyCloseCall();
			}
			SoundManager.PlaySound("FishCatchSplash");
			SoundManager.PlaySound("FishCatchPositive");
			float y = initialBarHeight;
			progressBar.rectTransform.sizeDelta = new Vector2(barWidth, y);
			progressBar.color = Color.green;
			progressBar.DOColor(Color.yellow, 0.1f).SetLoops(4, LoopType.Yoyo);
			yield return new WaitForSeconds(0.4f);
			SoundManager.PlaySound("AddFishToInventory");
		}
		else
		{
			SoundManager.PlaySound("FishCatchNegative");
			progressBar.color = Color.red;
			progressBar.DOColor(Color.yellow, 0.1f).SetLoops(4, LoopType.Yoyo);
			yield return new WaitForSeconds(0.4f);
		}
		yield return new WaitForSeconds(0.3f);
		yield return OnHideAnimation();
		yield return new WaitForSeconds(0.6f);
		if (dpsText != null)
		{
			dpsText.text = "";
			dpsText.gameObject.SetActive(value: false);
		}
		ReelInMinigame.OnReelInComplete?.Invoke(success);
		fishingManager.OnReelInResult(success);
		ToggleVisibility(visible: false);
		hasGameStarted = false;
	}

	public void ToggleVisibility(bool visible)
	{
		if (mainCanvasGroup != null)
		{
			mainCanvasGroup.alpha = (visible ? 1f : 0.01f);
			mainCanvasGroup.interactable = visible;
			mainCanvasGroup.blocksRaycasts = visible;
			if (!visible)
			{
				ResetEffects();
				StopParticle(smokeParticles);
				StopParticle(steamParticles);
			}
		}
	}

	private IEnumerator PassiveClickRoutine()
	{
		while (!isMinigameEnding && !isMinigameEnding)
		{
			for (int i = 0; i < PlayerStats.Instance.PassiveClicks; i++)
			{
				if (isMinigameEnding)
				{
					break;
				}
				PerformPassiveClick();
				if (PlayerStats.Instance.PassiveClicks > 1)
				{
					yield return new WaitForSeconds(0.05f);
				}
			}
			float seconds = ((PlayerStats.Instance.PassiveClickSpeed > 0f) ? (1f / PlayerStats.Instance.PassiveClickSpeed) : 1f);
			yield return new WaitForSeconds(seconds);
		}
	}

	private IEnumerator AutoReelRoutine()
	{
		while (!isMinigameEnding)
		{
			float seconds = 1f / autoReelClicksPerSecond;
			yield return new WaitForSeconds(seconds);
			if (!isMinigameEnding)
			{
				OnClick();
			}
		}
	}

	private void PerformPassiveClick()
	{
		if (passiveClickVFXPrefab != null && panelRectTransform != null)
		{
			Vector3 position = new Vector3(UnityEngine.Random.Range(panelRectTransform.rect.xMin, panelRectTransform.rect.xMax), UnityEngine.Random.Range(panelRectTransform.rect.yMin, panelRectTransform.rect.yMax), 0f);
			UnityEngine.Object.Instantiate(passiveClickVFXPrefab, panelRectTransform.transform.TransformPoint(position), Quaternion.identity, panelRectTransform.transform);
		}
		int num = PlayerStats.Instance.PassiveClickStrength;
		if (CameraController.Instance != null)
		{
			CameraController.Instance.TriggerShake();
		}
		float t = Mathf.Clamp01(currentDpsPercent / maxDpsForMaxBounce);
		float num2 = Mathf.Lerp(minPunchScale, maxPunchScale, t);
		float num3 = Mathf.Lerp(slowPunchDuration, fastPunchDuration, t);
		if (UnityEngine.Random.value <= PlayerStats.Instance.CritClickChance * 0.01f)
		{
			num = Mathf.CeilToInt((float)num * PlayerStats.Instance.CritClickMultiplier);
			AchievementManager.Instance?.NotifyCriticalClick();
			if (critTextPrefab != null)
			{
				LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.auto.crit");
				float num4 = ((UnityEngine.Random.value > 0.5f) ? 1f : (-1f));
				Vector3 worldPosition = new Vector3(critSpawnWorldPosition.x + critSpawnHorizontalOffset * num4, critSpawnWorldPosition.y, critSpawnWorldPosition.z);
				NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), worldPosition, Color.cyan);
			}
			if (PlayerStats.Instance.TimePerCrit > 0f && totalDurationElapsed < PlayerStats.Instance.MaxReelInDuration)
			{
				_minigameTimer -= PlayerStats.Instance.TimePerCrit;
				if (timeLimit - _minigameTimer > maxReelInTimeLimit)
				{
					_minigameTimer = timeLimit - maxReelInTimeLimit;
				}
				if (_minigameTimer < 0f - PlayerStats.Instance.PerfectCatchTimeRefund)
				{
					_minigameTimer = 0f - PlayerStats.Instance.PerfectCatchTimeRefund;
				}
				if (timerBar != null)
				{
					timerBar.DOKill(complete: true);
					timerBar.color = Color.cyan;
				}
			}
			StartCoroutine(ClickPunch(num2 * 0.8f, num3));
		}
		else
		{
			StartCoroutine(ClickPunch(num2 * 0.5f, num3 * 0.5f));
		}
		currentClicks += num;
		currentClicksText.text = CurrencyFormatter.FormatMoney(Math.Round(currentClicks));
		RecordProgress(num);
		if (currentClicks >= (float)clicksNeeded)
		{
			isMinigameEnding = true;
			if (minigameTimerCoroutine != null)
			{
				StopCoroutine(minigameTimerCoroutine);
			}
			if (passiveClickCoroutine != null)
			{
				StopCoroutine(passiveClickCoroutine);
			}
			if (autoReelCoroutine != null)
			{
				StopCoroutine(autoReelCoroutine);
			}
			StartCoroutine(EndMinigameAnimation(success: true));
		}
	}

	private void RecordProgress(float amount)
	{
		progressHistory.Enqueue(new KeyValuePair<float, float>(Time.time, amount));
	}

	private void CalculateRawDPS()
	{
		float time = Time.time;
		while (progressHistory.Count > 0 && progressHistory.Peek().Key < time - 1f)
		{
			progressHistory.Dequeue();
		}
		float num = 0f;
		foreach (KeyValuePair<float, float> item in progressHistory)
		{
			num += item.Value;
		}
		currentRawDps = num;
	}

	private void UpdateDPSDisplay()
	{
		if (!hasDismissedTutorial)
		{
			return;
		}
		float time = Time.time;
		if (dpsText != null && time - lastDpsUpdateTime > dpsUpdateRate)
		{
			if (!dpsText.gameObject.activeSelf)
			{
				dpsText.gameObject.SetActive(value: true);
			}
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.unit.per_sec");
			dpsText.text = $"{currentRawDps:F0} {localizedString.GetLocalizedString()}";
			lastDpsUpdateTime = time;
		}
	}

	private void UpdateHeatVisuals()
	{
		float num = Mathf.Clamp01(currentRawDps / dpsForMaxHeat);
		ApplyEmissionRate(steamParticles, steamConfig, num);
		ApplyEmissionRate(smokeParticles, smokeConfig, num);
		if (fireCanvasGroup != null)
		{
			float b = 0f;
			if (num > fireStartThreshold)
			{
				float num2 = fireMaxThreshold - fireStartThreshold;
				b = ((!(num2 > 0f)) ? 1f : Mathf.Clamp01((num - fireStartThreshold) / num2));
			}
			fireCanvasGroup.alpha = Mathf.Lerp(fireCanvasGroup.alpha, b, Time.deltaTime * fireFadeSpeed);
		}
		if (fireMaterial != null && num > fireStartThreshold)
		{
			float value = Mathf.Lerp(1f, 3f, num);
			fireMaterial.SetFloat("_Speed", value);
		}
		if (fireRects != null)
		{
			float num3 = 0f;
			if (num > fireStartThreshold)
			{
				float t = 0f;
				float num4 = fireMaxThreshold - fireStartThreshold;
				if (num4 > 0f)
				{
					t = Mathf.Clamp01((num - fireStartThreshold) / num4);
				}
				num3 = Mathf.Lerp(0f, maxFireRotationAngle, t);
			}
			for (int i = 0; i < fireRects.Count; i++)
			{
				if (fireRects[i] != null && i < initialFireRotations.Count)
				{
					float num5 = ((fireRects[i].localScale.x < 0f) ? (-1f) : 1f);
					fireRects[i].localRotation = initialFireRotations[i] * Quaternion.Euler(0f, 0f, num3 * num5);
				}
			}
		}
		if (fireMaterial != null && num > fireStartThreshold)
		{
			float value2 = Mathf.Lerp(1f, 3f, num);
			fireMaterial.SetFloat("_Speed", value2);
		}
	}

	private void ApplyEmissionRate(ParticleSystem ps, HeatParticleConfig config, float currentHeat)
	{
		if (ps == null)
		{
			return;
		}
		if (currentHeat < config.startThreshold)
		{
			if (ps.isPlaying)
			{
				ps.Stop();
			}
			return;
		}
		if (!ps.isPlaying)
		{
			ps.Play();
		}
		float num = config.maxIntensityThreshold - config.startThreshold;
		float num2 = 0f;
		num2 = ((!(num > 0f)) ? 1f : Mathf.Clamp01((currentHeat - config.startThreshold) / num));
		ParticleSystem.EmissionModule emission = ps.emission;
		emission.rateOverTime = Mathf.Lerp(config.minEmission, config.maxEmission, num2);
	}

	private void ResetEffects()
	{
		currentRawDps = 0f;
		StopParticle(steamParticles);
		StopParticle(smokeParticles);
		if (fireCanvasGroup != null)
		{
			fireCanvasGroup.alpha = 0f;
		}
		if (fireRects == null)
		{
			return;
		}
		for (int i = 0; i < fireRects.Count; i++)
		{
			if (fireRects[i] != null && i < initialFireRotations.Count)
			{
				fireRects[i].localRotation = initialFireRotations[i];
			}
		}
	}

	private void StopParticle(ParticleSystem ps)
	{
		if (!(ps == null))
		{
			ps.Stop();
			ParticleSystem.EmissionModule emission = ps.emission;
			emission.rateOverTime = 0f;
		}
	}

	private void ToggleParticle(ParticleSystem ps, bool shouldBeOn)
	{
		if (!(ps == null))
		{
			if (shouldBeOn && !ps.isPlaying)
			{
				ps.Play();
			}
			else if (!shouldBeOn && ps.isPlaying)
			{
				ps.Stop();
			}
		}
	}
}
