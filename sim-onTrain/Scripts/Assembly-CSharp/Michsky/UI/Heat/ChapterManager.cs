using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	public class ChapterManager : MonoBehaviour
	{
		[Serializable]
		public class ChapterChangeCallback : UnityEvent<int>
		{
		}

		public enum ChapterState
		{
			Locked = 0,
			Unlocked = 1,
			Completed = 2,
			Current = 3
		}

		[Serializable]
		public class ChapterItem
		{
			public string chapterID;

			public string title;

			public Sprite background;

			[TextArea]
			public string description;

			public ChapterState defaultState;

			[Header("Localization")]
			public string titleKey = "TitleKey";

			public string descriptionKey = "DescriptionKey";

			[Header("Events")]
			public UnityEvent onContinue;

			public UnityEvent onPlay;

			public UnityEvent onReplay;
		}

		public List<ChapterItem> chapters = new List<ChapterItem>();

		private List<ChapterIdentifier> identifiers = new List<ChapterIdentifier>();

		public int currentChapterIndex;

		[SerializeField]
		private GameObject chapterPreset;

		[SerializeField]
		private Transform chapterParent;

		[SerializeField]
		private ButtonManager previousButton;

		[SerializeField]
		private ButtonManager nextButton;

		[SerializeField]
		private Image progressFill;

		[SerializeField]
		private bool showLockedChapters = true;

		[SerializeField]
		private bool setPanelAuto = true;

		[SerializeField]
		private bool checkChapterData = true;

		[SerializeField]
		private bool useLocalization = true;

		[SerializeField]
		[Range(0.5f, 10f)]
		private float barCurveSpeed = 2f;

		[SerializeField]
		private AnimationCurve barCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[SerializeField]
		[Range(0.75f, 2f)]
		private float animationSpeed = 1f;

		[SerializeField]
		private bool backgroundStretch = true;

		[SerializeField]
		[Range(0f, 100f)]
		private float maxStretch = 75f;

		[SerializeField]
		[Range(0.02f, 0.5f)]
		private float stretchCurveSpeed = 0.1f;

		[SerializeField]
		private AnimationCurve stretchCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public ChapterChangeCallback onChapterPanelChanged = new ChapterChangeCallback();

		[HideInInspector]
		public RectTransform currentBackgroundRect;

		private LocalizedObject localizedObject;

		private string animSpeedKey = "AnimSpeed";

		private void Awake()
		{
			InitializeChapters();
		}

		private void OnEnable()
		{
			OpenCurrentPanel();
		}

		private void OnDisable()
		{
			if (backgroundStretch)
			{
				StopCoroutine("StretchPhaseOne");
				StopCoroutine("StretchPhaseTwo");
			}
		}

		public void DoStretch()
		{
			if (backgroundStretch && !(currentBackgroundRect == null) && base.gameObject.activeInHierarchy)
			{
				float num = 1f + maxStretch / 960f;
				currentBackgroundRect.localScale = new Vector3(num, num, num);
				currentBackgroundRect.offsetMin = new Vector2(0f, 0f);
				currentBackgroundRect.offsetMax = new Vector2(0f, 0f);
				StopCoroutine("StretchPhaseOne");
				StopCoroutine("StretchPhaseTwo");
				StartCoroutine("StretchPhaseOne");
			}
		}

		public void InitializeChapters()
		{
			if (useLocalization)
			{
				localizedObject = base.gameObject.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
			}
			identifiers.Clear();
			foreach (Transform item in chapterParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < chapters.Count; i++)
			{
				int index = i;
				GameObject obj = UnityEngine.Object.Instantiate(chapterPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(chapterParent, worldPositionStays: false);
				obj.gameObject.name = chapters[i].chapterID;
				ChapterIdentifier component = obj.GetComponent<ChapterIdentifier>();
				component.chapterManager = this;
				identifiers.Add(component);
				component.backgroundImage.sprite = chapters[i].background;
				component.UpdateBackgroundRect();
				if (!useLocalization || string.IsNullOrEmpty(chapters[i].titleKey))
				{
					component.titleObject.text = chapters[i].title;
				}
				else
				{
					LocalizedObject component2 = component.titleObject.GetComponent<LocalizedObject>();
					if (component2 != null)
					{
						component2.tableIndex = localizedObject.tableIndex;
						component2.localizationKey = chapters[i].titleKey;
						component2.UpdateItem();
					}
				}
				if (!useLocalization || string.IsNullOrEmpty(chapters[i].descriptionKey))
				{
					component.descriptionObject.text = chapters[i].description;
				}
				else
				{
					LocalizedObject component3 = component.descriptionObject.GetComponent<LocalizedObject>();
					if (component3 != null)
					{
						component3.tableIndex = localizedObject.tableIndex;
						component3.localizationKey = chapters[i].descriptionKey;
						component3.UpdateItem();
					}
				}
				component.continueButton.onClick.RemoveAllListeners();
				component.continueButton.onClick.AddListener(chapters[index].onContinue.Invoke);
				component.playButton.onClick.RemoveAllListeners();
				component.playButton.onClick.AddListener(chapters[index].onPlay.Invoke);
				component.replayButton.onClick.RemoveAllListeners();
				component.replayButton.onClick.AddListener(chapters[index].onReplay.Invoke);
				if (checkChapterData)
				{
					if (!PlayerPrefs.HasKey("ChapterState_" + chapters[i].chapterID))
					{
						if (chapters[i].defaultState == ChapterState.Unlocked)
						{
							component.SetUnlocked();
						}
						else if (chapters[i].defaultState == ChapterState.Locked)
						{
							component.SetLocked();
						}
						else if (chapters[i].defaultState == ChapterState.Completed)
						{
							component.SetCompleted();
						}
						else
						{
							component.SetCurrent();
						}
					}
					else if (PlayerPrefs.HasKey("ChapterState_" + chapters[i].chapterID) && PlayerPrefs.GetString("ChapterState_" + chapters[i].chapterID) == "unlocked")
					{
						component.SetUnlocked();
					}
					else if (PlayerPrefs.HasKey("ChapterState_" + chapters[i].chapterID) && PlayerPrefs.GetString("ChapterState_" + chapters[i].chapterID) == "current")
					{
						component.SetCurrent();
					}
					else if (PlayerPrefs.HasKey("ChapterState_" + chapters[i].chapterID) && PlayerPrefs.GetString("ChapterState_" + chapters[i].chapterID) == "completed")
					{
						component.SetCompleted();
					}
					else
					{
						component.SetLocked();
					}
				}
				else if (chapters[i].defaultState == ChapterState.Unlocked)
				{
					component.SetUnlocked();
				}
				else if (chapters[i].defaultState == ChapterState.Locked)
				{
					component.SetLocked();
				}
				else if (chapters[i].defaultState == ChapterState.Completed)
				{
					component.SetCompleted();
				}
				else
				{
					component.SetCurrent();
				}
				obj.SetActive(value: false);
				if (setPanelAuto && component.isCurrent)
				{
					currentChapterIndex = i;
				}
			}
			identifiers[currentChapterIndex].gameObject.SetActive(value: true);
			previousButton.onClick.RemoveAllListeners();
			previousButton.onClick.AddListener(PrevChapter);
			nextButton.onClick.RemoveAllListeners();
			nextButton.onClick.AddListener(NextChapter);
			UpdateButtonState();
			if (progressFill != null)
			{
				progressFill.fillAmount = 1f / (float)chapters.Count * (float)(currentChapterIndex + 1);
			}
		}

		public void NextChapter()
		{
			if (currentChapterIndex + 1 <= identifiers.Count - 1 && (showLockedChapters || !identifiers[currentChapterIndex + 1].isLocked))
			{
				identifiers[currentChapterIndex].animator.enabled = true;
				identifiers[currentChapterIndex].animator.SetFloat(animSpeedKey, animationSpeed);
				identifiers[currentChapterIndex].animator.Play("Next Out");
				currentChapterIndex++;
				identifiers[currentChapterIndex].gameObject.SetActive(value: true);
				identifiers[currentChapterIndex].animator.enabled = true;
				identifiers[currentChapterIndex].animator.SetFloat(animSpeedKey, animationSpeed);
				identifiers[currentChapterIndex].animator.Play("Next In");
				identifiers[currentChapterIndex].UpdateBackgroundRect();
				UpdateButtonState();
				StopCoroutine("DisablePanels");
				StartCoroutine("DisablePanels");
			}
		}

		public void PrevChapter()
		{
			if (currentChapterIndex > 0 && (showLockedChapters || !identifiers[currentChapterIndex - 1].isLocked))
			{
				identifiers[currentChapterIndex].animator.enabled = true;
				identifiers[currentChapterIndex].animator.SetFloat(animSpeedKey, animationSpeed);
				identifiers[currentChapterIndex].animator.Play("Prev Out");
				currentChapterIndex--;
				identifiers[currentChapterIndex].gameObject.SetActive(value: true);
				identifiers[currentChapterIndex].animator.enabled = true;
				identifiers[currentChapterIndex].animator.SetFloat(animSpeedKey, animationSpeed);
				identifiers[currentChapterIndex].animator.Play("Prev In");
				identifiers[currentChapterIndex].UpdateBackgroundRect();
				UpdateButtonState();
				StopCoroutine("DisablePanels");
				StartCoroutine("DisablePanels");
			}
		}

		private void OpenCurrentPanel()
		{
			if (!(identifiers[currentChapterIndex] == null))
			{
				identifiers[currentChapterIndex].gameObject.SetActive(value: true);
				identifiers[currentChapterIndex].animator.enabled = true;
				identifiers[currentChapterIndex].animator.SetFloat(animSpeedKey, animationSpeed);
				identifiers[currentChapterIndex].animator.Play("Start");
				identifiers[currentChapterIndex].UpdateBackgroundRect();
			}
		}

		private void UpdateButtonState()
		{
			if (currentChapterIndex >= identifiers.Count - 1 && nextButton != null)
			{
				nextButton.isInteractable = false;
				nextButton.UpdateUI();
			}
			else if (nextButton != null)
			{
				nextButton.isInteractable = true;
				nextButton.UpdateUI();
			}
			if (currentChapterIndex < 1 && previousButton != null)
			{
				previousButton.isInteractable = false;
				previousButton.UpdateUI();
			}
			else if (previousButton != null)
			{
				previousButton.isInteractable = true;
				previousButton.UpdateUI();
			}
			if (!showLockedChapters && currentChapterIndex <= identifiers.Count - 1 && identifiers[currentChapterIndex + 1].isLocked)
			{
				nextButton.isInteractable = false;
				nextButton.UpdateUI();
			}
			if (progressFill != null && base.gameObject.activeInHierarchy)
			{
				StopCoroutine("PlayProgressFill");
				StartCoroutine("PlayProgressFill");
			}
			onChapterPanelChanged.Invoke(currentChapterIndex);
		}

		public static void SetLocked(string chapterID)
		{
			PlayerPrefs.SetString("ChapterState_" + chapterID, "locked");
		}

		public static void SetUnlocked(string chapterID)
		{
			PlayerPrefs.SetString("ChapterState_" + chapterID, "unlocked");
		}

		public static void SetCurrent(string chapterID)
		{
			PlayerPrefs.SetString("ChapterState_" + chapterID, "current");
		}

		public static void SetCompleted(string chapterID)
		{
			PlayerPrefs.SetString("ChapterState_" + chapterID, "completed");
		}

		private IEnumerator StretchPhaseOne()
		{
			float elapsedTime = 0f;
			Vector2 startPos = currentBackgroundRect.offsetMin;
			Vector2 endPos = new Vector2(0f - maxStretch, 0f);
			while (currentBackgroundRect.offsetMin.x > 0f - maxStretch + 0.1f)
			{
				elapsedTime += Time.unscaledDeltaTime;
				currentBackgroundRect.offsetMin = Vector2.Lerp(startPos, endPos, stretchCurve.Evaluate(elapsedTime * stretchCurveSpeed));
				currentBackgroundRect.offsetMax = Vector2.Lerp(startPos, endPos, stretchCurve.Evaluate(elapsedTime * stretchCurveSpeed));
				yield return null;
			}
			StartCoroutine("StretchPhaseTwo");
		}

		private IEnumerator StretchPhaseTwo()
		{
			float elapsedTime = 0f;
			Vector2 startPos = currentBackgroundRect.offsetMin;
			Vector2 endPos = new Vector2(maxStretch, 0f);
			while (currentBackgroundRect.offsetMin.x < maxStretch - 0.1f)
			{
				elapsedTime += Time.unscaledDeltaTime;
				currentBackgroundRect.offsetMin = Vector2.Lerp(startPos, endPos, stretchCurve.Evaluate(elapsedTime * stretchCurveSpeed));
				currentBackgroundRect.offsetMax = Vector2.Lerp(startPos, endPos, stretchCurve.Evaluate(elapsedTime * stretchCurveSpeed));
				yield return null;
			}
			StartCoroutine("StretchPhaseOne");
		}

		private IEnumerator DisablePanels()
		{
			yield return new WaitForSecondsRealtime(0.5f);
			for (int i = 0; i < identifiers.Count; i++)
			{
				identifiers[i].animator.enabled = false;
				if (i != currentChapterIndex)
				{
					identifiers[i].gameObject.SetActive(value: false);
				}
			}
		}

		private IEnumerator PlayProgressFill()
		{
			float startingPoint = progressFill.fillAmount;
			float num = 1f / (float)chapters.Count;
			float toBeFilled = num * (float)(currentChapterIndex + 1);
			float elapsedTime = 0f;
			while (progressFill.fillAmount.ToString("F2") != toBeFilled.ToString("F2"))
			{
				elapsedTime += Time.unscaledDeltaTime;
				progressFill.fillAmount = Mathf.Lerp(startingPoint, toBeFilled, barCurve.Evaluate(elapsedTime * barCurveSpeed));
				yield return null;
			}
			progressFill.fillAmount = toBeFilled;
		}
	}
}
