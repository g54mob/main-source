using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class EndOfGamePanel : MonoBehaviour
{
	[Header("Buttons")]
	public Button returnToMenuButton;

	public Button continueJourneyButton;

	[Header("Title")]
	public SuperTextMesh titleText;

	public SuperTextMesh subtitleText;

	[Header("Stats (bullet points)")]
	public SuperTextMesh timeStat;

	public SuperTextMesh fishStat;

	public SuperTextMesh skillsStat;

	[Header("Closing Paragraph")]
	public SuperTextMesh closingText;

	[Header("Main UI to Fade Out")]
	public CanvasGroup mainUICanvasGroup;

	private CanvasGroup panelCanvasGroup;

	private RectTransform panelRect;

	private Canvas _hiddenMainUICanvas;

	private const string TotalSkillsKey = "TotalSkillsPurchased";

	public static bool IsVisible { get; private set; }

	private void Awake()
	{
		panelCanvasGroup = GetComponent<CanvasGroup>();
		panelRect = GetComponent<RectTransform>();
	}

	private void Start()
	{
		if (returnToMenuButton != null)
		{
			returnToMenuButton.onClick.AddListener(delegate
			{
				IsVisible = false;
				if (PlayerManager.Instance != null)
				{
					PlayerManager.Instance.ReturnToMenu();
				}
			});
		}
		if (continueJourneyButton != null)
		{
			continueJourneyButton.onClick.AddListener(delegate
			{
				IsVisible = false;
				AnimateOut();
			});
		}
	}

	public void ShowEndOfGamePanel()
	{
		Transform parent = base.transform;
		while (parent.parent != null)
		{
			if (!parent.parent.gameObject.activeSelf)
			{
				parent.parent.gameObject.SetActive(value: true);
			}
			parent = parent.parent;
		}
		base.gameObject.SetActive(value: true);
		IsVisible = true;
		if (panelCanvasGroup == null)
		{
			panelCanvasGroup = GetComponent<CanvasGroup>();
		}
		if (panelRect == null)
		{
			panelRect = GetComponent<RectTransform>();
		}
		if (FishingManager.Instance != null)
		{
			FishingManager.Instance.enabled = false;
		}
		UpdateStats();
		FishTrackerHUD fishTrackerHUD = UnityEngine.Object.FindObjectOfType<FishTrackerHUD>();
		if (fishTrackerHUD != null)
		{
			fishTrackerHUD.ForceHide();
		}
		if (mainUICanvasGroup == null)
		{
			_hiddenMainUICanvas = FindMainUICanvas();
			if (_hiddenMainUICanvas != null)
			{
				mainUICanvasGroup = _hiddenMainUICanvas.GetComponent<CanvasGroup>();
				if (mainUICanvasGroup == null)
				{
					mainUICanvasGroup = _hiddenMainUICanvas.gameObject.AddComponent<CanvasGroup>();
				}
			}
			else
			{
				Debug.LogWarning("[EndOfGamePanel] Could not find main UI canvas to fade. Tag your main canvas 'MainUI'.");
			}
		}
		if (panelCanvasGroup != null)
		{
			panelCanvasGroup.alpha = 0f;
			panelCanvasGroup.interactable = false;
			panelCanvasGroup.blocksRaycasts = false;
		}
		SetAlpha(titleText, 0f);
		SetAlpha(subtitleText, 0f);
		SetAlpha(closingText, 0f);
		SetAlpha(timeStat, 0f);
		SetAlpha(fishStat, 0f);
		SetAlpha(skillsStat, 0f);
		SetScale(timeStat, 0.75f);
		SetScale(fishStat, 0.75f);
		SetScale(skillsStat, 0.75f);
		Vector2 anchoredPosition = panelRect.anchoredPosition;
		panelRect.anchoredPosition = anchoredPosition + new Vector2(0f, -50f);
		Sequence sequence = DOTween.Sequence().SetUpdate(isIndependentUpdate: true);
		if (mainUICanvasGroup != null)
		{
			sequence.Insert(0f, mainUICanvasGroup.DOFade(0f, 0.3f).SetEase(Ease.OutCubic));
		}
		if (panelCanvasGroup != null)
		{
			sequence.Insert(0.15f, panelCanvasGroup.DOFade(1f, 0.35f).SetEase(Ease.OutCubic));
			sequence.Insert(0.15f, panelRect.DOAnchorPos(anchoredPosition, 0.4f).SetEase(Ease.OutCubic));
		}
		FadeIn(titleText, sequence, 0.45f, 0.25f);
		FadeIn(subtitleText, sequence, 0.65f, 0.2f);
		PopIn(timeStat, sequence, 0.9f);
		PopIn(fishStat, sequence, 1.1f);
		PopIn(skillsStat, sequence, 1.3f);
		FadeIn(closingText, sequence, 1.6f, 0.35f);
		sequence.OnComplete(delegate
		{
			if (panelCanvasGroup != null)
			{
				panelCanvasGroup.interactable = true;
				panelCanvasGroup.blocksRaycasts = true;
			}
		});
	}

	private void FadeIn(SuperTextMesh element, Sequence seq, float atTime, float duration)
	{
		if (!(element == null))
		{
			CanvasGroup orAddCG = GetOrAddCG(element);
			seq.Insert(atTime, orAddCG.DOFade(1f, duration).SetEase(Ease.OutCubic));
		}
	}

	private void PopIn(SuperTextMesh element, Sequence seq, float atTime)
	{
		if (!(element == null))
		{
			CanvasGroup orAddCG = GetOrAddCG(element);
			seq.Insert(atTime, orAddCG.DOFade(1f, 0.15f));
			seq.Insert(atTime, element.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack));
		}
	}

	private void SetAlpha(SuperTextMesh element, float alpha)
	{
		if (!(element == null))
		{
			GetOrAddCG(element).alpha = alpha;
		}
	}

	private void SetScale(SuperTextMesh element, float scale)
	{
		if (!(element == null))
		{
			element.transform.localScale = new Vector3(scale, scale, 1f);
		}
	}

	private CanvasGroup GetOrAddCG(SuperTextMesh element)
	{
		CanvasGroup canvasGroup = element.GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = element.gameObject.AddComponent<CanvasGroup>();
		}
		return canvasGroup;
	}

	public void UpdateStats()
	{
		float totalSeconds = 0f;
		if (GameManager.Instance != null)
		{
			totalSeconds = GameManager.Instance.totalPlayTime;
		}
		if (timeStat != null)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.endofdemo.time.text");
			string text = ((localizedString != null && !localizedString.IsEmpty) ? localizedString.GetLocalizedString() : "Time To Complete: ");
			timeStat.text = text + FormatTime(totalSeconds);
		}
		int num = 0;
		if (FishLogManager.Instance != null)
		{
			num = FishLogManager.Instance.TotalGlobalFishCaught;
		}
		if (fishStat != null)
		{
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.endofdemo.fishcaught.text");
			string arg = ((localizedString2 != null && !localizedString2.IsEmpty) ? localizedString2.GetLocalizedString() : "Fish Caught: ");
			fishStat.text = $"{arg}{num:N0}";
		}
		int num2 = PlayerPrefs.GetInt("TotalSkillsPurchased", 0);
		if (skillsStat != null)
		{
			LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.endofdemo.skills.text");
			string arg2 = ((localizedString3 != null && !localizedString3.IsEmpty) ? localizedString3.GetLocalizedString() : "Skills Bought:");
			skillsStat.text = $"{arg2} {num2}";
		}
	}

	private void AnimateOut()
	{
		Sequence sequence = DOTween.Sequence().SetUpdate(isIndependentUpdate: true);
		if (panelCanvasGroup != null)
		{
			sequence.Append(panelCanvasGroup.DOFade(0f, 0.4f).SetEase(Ease.InCubic));
		}
		sequence.Join(panelRect.DOAnchorPos(panelRect.anchoredPosition + new Vector2(0f, -40f), 0.4f).SetEase(Ease.InCubic));
		sequence.OnComplete(delegate
		{
			base.gameObject.SetActive(value: false);
			CanvasGroup component = mainUICanvasGroup;
			if (component == null && _hiddenMainUICanvas != null)
			{
				component = _hiddenMainUICanvas.GetComponent<CanvasGroup>();
			}
			if (component != null)
			{
				component.DOFade(1f, 0.4f).SetUpdate(isIndependentUpdate: true);
			}
			_hiddenMainUICanvas = null;
			mainUICanvasGroup = null;
			if (FishingManager.Instance != null)
			{
				FishingManager.Instance.enabled = true;
			}
		});
	}

	private string FormatTime(float totalSeconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
		if (timeSpan.TotalHours >= 1.0)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.endofdemo.timeformat.hours");
			if (localizedString != null && !localizedString.IsEmpty)
			{
				return localizedString.GetLocalizedString(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			}
			return $"{timeSpan.Hours:D1}h {timeSpan.Minutes:D2}m {timeSpan.Seconds:D2}s";
		}
		LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.endofdemo.timeformat.short");
		if (localizedString2 != null && !localizedString2.IsEmpty)
		{
			return localizedString2.GetLocalizedString(timeSpan.Minutes, timeSpan.Seconds);
		}
		return $"{timeSpan.Minutes:D2}m {timeSpan.Seconds:D2}s";
	}

	private Canvas FindMainUICanvas()
	{
		Canvas componentInParent = GetComponentInParent<Canvas>();
		GameObject gameObject = GameObject.FindGameObjectWithTag("MainUI");
		if (gameObject != null)
		{
			Canvas component = gameObject.GetComponent<Canvas>();
			if (component != null && component != componentInParent)
			{
				return component;
			}
		}
		string[] array = new string[5] { "HUD", "Canvas", "MainCanvas", "FishingCanvas", "FishingUI" };
		for (int i = 0; i < array.Length; i++)
		{
			GameObject gameObject2 = GameObject.Find(array[i]);
			if (gameObject2 != null)
			{
				Canvas component2 = gameObject2.GetComponent<Canvas>();
				if (component2 != null && component2 != componentInParent)
				{
					return component2;
				}
			}
		}
		Canvas[] array2 = UnityEngine.Object.FindObjectsOfType<Canvas>();
		foreach (Canvas canvas in array2)
		{
			if (canvas != componentInParent && canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				return canvas;
			}
		}
		return null;
	}

	private void OnDisable()
	{
		DOTween.Kill(panelRect);
		if (panelCanvasGroup != null)
		{
			DOTween.Kill(panelCanvasGroup);
		}
	}

	[ContextMenu("Test Show End Of Game")]
	private void TestShow()
	{
		ShowEndOfGamePanel();
	}
}
