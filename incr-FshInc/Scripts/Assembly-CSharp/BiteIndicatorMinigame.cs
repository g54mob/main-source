using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class BiteIndicatorMinigame : MonoBehaviour
{
	[Header("UI References")]
	public RectTransform indicatorPanel;

	public RectTransform greenZone;

	public Image greenZoneFeedbackImage;

	public RectTransform timingLine;

	public Image backgroundImage;

	public SuperTextMesh autoHookText;

	[Header("Timing Configuration")]
	[Tooltip("Defines the 'Close' window as a percentage of the total reaction time. E.g., 0.15 is +/- 15% around the perfect zone.")]
	[Range(0.01f, 0.5f)]
	public float closeWindowMargin = 0.15f;

	private bool isMinigameActive;

	private bool isPerfectCatch;

	private float minigameStartTime;

	private float reactionTimeLimit;

	private Vector3 initialLinePosition;

	private FishingManager fishingManager;

	private Vector2 initialPanelPosition;

	private Color originalGreenZoneColor = Color.white;

	public static BiteIndicatorMinigame Instance { get; private set; }

	public bool IsMinigameActive => isMinigameActive;

	public float MinigameStartTime => minigameStartTime;

	public float ReactionTimeLimit => reactionTimeLimit;

	public static event Action<bool, bool> OnBiteIndicatorComplete;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		if (timingLine != null)
		{
			initialLinePosition = timingLine.anchoredPosition;
		}
		if (indicatorPanel != null)
		{
			initialPanelPosition = indicatorPanel.anchoredPosition;
		}
		if (!(greenZoneFeedbackImage != null))
		{
			return;
		}
		if (greenZoneFeedbackImage.material != null)
		{
			Material material = new Material(greenZoneFeedbackImage.material);
			greenZoneFeedbackImage.material = material;
			if (material.HasProperty("_Color"))
			{
				originalGreenZoneColor = material.GetColor("_Color");
			}
			else
			{
				Debug.LogWarning("[BiteIndicator] GreenZoneFeedbackImage material does NOT have a _Color property. Check shader graph!");
			}
		}
		else
		{
			Debug.LogWarning("[BiteIndicator] GreenZoneFeedbackImage lacks a Material.");
		}
	}

	private IEnumerator SlideInAnimation()
	{
		yield return null;
		if (timingLine != null && indicatorPanel != null)
		{
			float width = indicatorPanel.rect.width;
			timingLine.anchoredPosition = new Vector2((0f - width) / 2f, initialLinePosition.y);
		}
		if (indicatorPanel != null)
		{
			float num = Screen.height;
			Vector2 anchoredPosition = new Vector2(initialPanelPosition.x, 0f - num);
			indicatorPanel.anchoredPosition = anchoredPosition;
			indicatorPanel.DOAnchorPos(initialPanelPosition, 0.5f).SetEase(Ease.OutBack);
		}
	}

	private IEnumerator SlideOutAnimation()
	{
		yield return null;
		if (indicatorPanel != null)
		{
			float num = Screen.height;
			DOTweenModuleUI.DOAnchorPos(endValue: new Vector2(initialPanelPosition.x, 0f - num), target: indicatorPanel, duration: 0.5f).SetEase(Ease.InBack).WaitForCompletion();
			indicatorPanel.anchoredPosition = initialPanelPosition;
		}
	}

	public IEnumerator StartMinigame(FishingManager manager, float reactionTime, bool autoHooked = false)
	{
		autoHookText.gameObject.SetActive(value: false);
		if (isMinigameActive)
		{
			StopMinigame();
		}
		if (PlayerManager.Instance.dayEnded)
		{
			if (manager != null)
			{
				manager.OnBiteIndicatorResult(playerClicked: false, perfectTiming: false);
			}
			yield break;
		}
		fishingManager = manager;
		reactionTimeLimit = reactionTime;
		isMinigameActive = false;
		isPerfectCatch = false;
		base.gameObject.SetActive(value: true);
		if (greenZoneFeedbackImage != null && greenZoneFeedbackImage.material != null)
		{
			greenZoneFeedbackImage.material.SetColor("_Color", originalGreenZoneColor);
			greenZoneFeedbackImage.SetMaterialDirty();
		}
		SetUpGreenZone();
		yield return SlideInAnimation();
		if (autoHooked)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.auto.hooked");
			autoHookText.gameObject.SetActive(value: true);
			autoHookText.text = "<drawAnim=Fade><d=1.0><w=onceWDelay>" + localizedString.GetLocalizedString() + "</w>";
			autoHookText.Read();
			DOVirtual.Float(0f, 0.5f, 0.15f, delegate(float v)
			{
				SetProgressBar(v);
			}).SetEase(Ease.InOutSine);
			yield return new WaitForSeconds(0.2f);
		}
		yield return new WaitForSeconds(0.4f);
		minigameStartTime = Time.time;
		isMinigameActive = true;
		if (autoHooked)
		{
			EndMinigame(playerClicked: false, BiteTimingResult.Perfect);
			SoundManager.PlaySound("SetHook");
		}
	}

	private void SetUpGreenZone()
	{
		if (!(greenZone == null))
		{
			_ = PlayerStats.Instance.ReactionTime;
			_ = PlayerStats.Instance.PerfectCatchTimeWindow;
			_ = 0f;
			float greenZoneProportion = GetGreenZoneProportion();
			float x = 0.5f - greenZoneProportion / 2f;
			float x2 = 0.5f + greenZoneProportion / 2f;
			greenZone.anchorMin = new Vector2(x, 0f);
			greenZone.anchorMax = new Vector2(x2, 1f);
			greenZone.offsetMin = Vector2.zero;
			greenZone.offsetMax = Vector2.zero;
		}
	}

	private float GetGreenZoneProportion()
	{
		return Mathf.Clamp(((PlayerStats.Instance != null) ? PlayerStats.Instance.PerfectCatchTimeWindow : 0.1f) / reactionTimeLimit, 0.05f, 0.5f);
	}

	private void SetProgressBar(float progress)
	{
		if (indicatorPanel != null)
		{
			float width = indicatorPanel.rect.width;
			float a = (0f - width) / 2f;
			float b = width / 2f;
			float x = Mathf.Lerp(a, b, progress);
			timingLine.anchoredPosition = new Vector2(x, initialLinePosition.y);
		}
	}

	private void Update()
	{
		if (Time.timeScale != 0f && isMinigameActive)
		{
			float num = (Time.time - minigameStartTime) / reactionTimeLimit;
			if (timingLine != null && indicatorPanel != null)
			{
				float width = indicatorPanel.rect.width;
				float a = (0f - width) / 2f;
				float b = width / 2f;
				float x = Mathf.Lerp(a, b, num);
				timingLine.anchoredPosition = new Vector2(x, initialLinePosition.y);
			}
			if (num >= 1f)
			{
				EndMinigame(playerClicked: false, BiteTimingResult.Missed);
			}
			else if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
			{
				SimulateClick();
			}
		}
	}

	public void SimulateClick()
	{
		if (isMinigameActive)
		{
			float num = (Time.time - minigameStartTime) / reactionTimeLimit;
			float num2 = GetGreenZoneProportion() / 2f;
			float num3 = 0.5f - num2;
			float num4 = 0.5f + num2;
			float num5 = num2 + closeWindowMargin;
			float num6 = 0.5f - num5;
			float num7 = 0.5f + num5;
			BiteTimingResult biteTimingResult = ((!(num >= num3) || !(num <= num4)) ? ((num >= num6 && num <= num7) ? BiteTimingResult.Close : ((!(num < num6)) ? BiteTimingResult.Late : BiteTimingResult.Early)) : BiteTimingResult.Perfect);
			Debug.Log($"[Bot] SimulateClick progress={num:F3}, zone={num3:F3}-{num4:F3}, result={biteTimingResult}");
			SoundManager.PlaySound("SetHook");
			EndMinigame(playerClicked: true, biteTimingResult);
		}
	}

	private void EndMinigame(bool playerClicked, BiteTimingResult result)
	{
		isMinigameActive = false;
		isPerfectCatch = result == BiteTimingResult.Perfect;
		StopAllCoroutines();
		StartCoroutine(ShowFeedbackAndProceed(playerClicked, result));
	}

	private IEnumerator ShowFeedbackAndProceed(bool playerClicked, BiteTimingResult result)
	{
		Color color = Color.red;
		string text = "";
		bool wasSuccessful = false;
		bool wasPerfect = false;
		new LocalizedString("Skills", "#ui.notif.perfect");
		Color greenZoneFlashColor = Color.red * 1.5f;
		int loops = 3;
		switch (result)
		{
		case BiteTimingResult.Perfect:
		{
			LocalizedString localizedString5 = new LocalizedString("Skills", "#ui.notif.perfect");
			color = Color.green;
			text = localizedString5.GetLocalizedString();
			wasSuccessful = true;
			wasPerfect = true;
			greenZoneFlashColor = Color.green * 1.5f;
			loops = 5;
			SoundManager.PlaySound("PerfectCatch");
			break;
		}
		case BiteTimingResult.Close:
		{
			LocalizedString localizedString4 = new LocalizedString("Skills", "#ui.notif.almost");
			color = Color.yellow;
			text = localizedString4.GetLocalizedString();
			wasSuccessful = true;
			greenZoneFlashColor = Color.yellow * 1.5f;
			break;
		}
		case BiteTimingResult.Early:
		{
			LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.notif.too.early");
			color = new Color(1f, 0.5f, 0f);
			text = localizedString3.GetLocalizedString();
			wasSuccessful = true;
			greenZoneFlashColor = new Color(1f, 0.5f, 0f) * 1.5f;
			break;
		}
		case BiteTimingResult.Late:
		{
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.notif.late");
			color = new Color(1f, 0.5f, 0f);
			text = localizedString2.GetLocalizedString();
			wasSuccessful = true;
			greenZoneFlashColor = new Color(1f, 0.5f, 0f) * 1.5f;
			break;
		}
		case BiteTimingResult.Missed:
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.too.slow");
			color = Color.red;
			text = localizedString.GetLocalizedString();
			wasSuccessful = false;
			greenZoneFlashColor = Color.red * 1.5f;
			break;
		}
		}
		if (autoHookText != null)
		{
			autoHookText.color = color;
			autoHookText.gameObject.SetActive(value: true);
			autoHookText.text = "<drawAnim=Fade><d=1.0><w=onceWDelay>" + text + "</w>";
			autoHookText.Read();
		}
		if (backgroundImage != null)
		{
			backgroundImage.DOColor(color, 0.1f).SetLoops(2, LoopType.Yoyo);
		}
		if (greenZoneFeedbackImage != null && greenZoneFeedbackImage.material != null)
		{
			Material mat = greenZoneFeedbackImage.material;
			mat.DOKill();
			mat.SetColor("_Color", originalGreenZoneColor);
			greenZoneFeedbackImage.SetMaterialDirty();
			DOVirtual.Float(0f, 1f, 0.1f, delegate(float v)
			{
				if (mat != null)
				{
					mat.SetColor("_Color", Color.LerpUnclamped(originalGreenZoneColor, greenZoneFlashColor, v));
					if (greenZoneFeedbackImage != null)
					{
						greenZoneFeedbackImage.SetMaterialDirty();
					}
				}
			}).SetLoops(loops, LoopType.Yoyo).SetTarget(mat)
				.OnComplete(delegate
				{
					if (mat != null)
					{
						mat.SetColor("_Color", greenZoneFlashColor);
						if (greenZoneFeedbackImage != null)
						{
							greenZoneFeedbackImage.SetMaterialDirty();
						}
					}
				});
		}
		if (!string.IsNullOrEmpty(text) && NotificationManager.Instance != null)
		{
			NotificationManager.Instance.ShowNotification(text, base.transform.position, color);
		}
		yield return new WaitForSeconds(0.3f);
		yield return SlideOutAnimation();
		yield return new WaitForSeconds(0.7f);
		base.gameObject.SetActive(value: false);
		BiteIndicatorMinigame.OnBiteIndicatorComplete?.Invoke(wasSuccessful, wasPerfect);
		if (fishingManager != null)
		{
			fishingManager.OnBiteIndicatorResult(wasSuccessful, wasPerfect);
		}
	}

	public void StopMinigame()
	{
		if (isMinigameActive)
		{
			isMinigameActive = false;
			StopAllCoroutines();
			base.gameObject.SetActive(value: false);
		}
	}
}
