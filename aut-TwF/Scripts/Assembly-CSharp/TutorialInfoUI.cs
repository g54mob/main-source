using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInfoUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI mainText;

	[SerializeField]
	private TextMeshProUGUI secondaryText;

	[SerializeField]
	private TextMeshProUGUI objectiveText;

	[SerializeField]
	private Image questImage;

	[SerializeField]
	private GameObject objectiveSeparationLine;

	[SerializeField]
	private Button nextButton;

	[SerializeField]
	private bool playStartAnimation;

	[SerializeField]
	private AudioClip startAnimationSound;

	private TutorialGameManager tutorialGameManager;

	private AutoTransformRebuild autoTransformRebuild;

	private bool executeLateUpdate;

	private Coroutine startAnimationCoroutine;

	private Tween startAnimationTween;

	private void Awake()
	{
		autoTransformRebuild = GetComponent<AutoTransformRebuild>();
	}

	private void Start()
	{
		tutorialGameManager = LTFunctionLibrary.GetLTGameManager() as TutorialGameManager;
		if (playStartAnimation)
		{
			this.StartCoroutineCheckingVar(StartAnimationCoroutine(), ref startAnimationCoroutine);
		}
	}

	private void OnEnable()
	{
		executeLateUpdate = true;
	}

	private void LateUpdate()
	{
		if (!executeLateUpdate)
		{
			return;
		}
		executeLateUpdate = false;
		tutorialGameManager.onTutorialQuestUpdated += OnTutorialQuestUpdated;
		tutorialGameManager.onTutorialQuestStarted += OnTutorialQuestStarted;
		tutorialGameManager.onTutorialQuestCompleted += OnTutorialQuestCompleted;
		if ((bool)tutorialGameManager.GetCurrentQuest())
		{
			OnTutorialQuestStarted();
			if (tutorialGameManager.GetCurrentQuest().IsComplete())
			{
				OnTutorialQuestCompleted();
			}
		}
	}

	private void OnDisable()
	{
		tutorialGameManager.onTutorialQuestUpdated -= OnTutorialQuestUpdated;
		tutorialGameManager.onTutorialQuestStarted -= OnTutorialQuestStarted;
		tutorialGameManager.onTutorialQuestCompleted -= OnTutorialQuestCompleted;
		if (startAnimationCoroutine != null)
		{
			this.StopCoroutineCheckingVar(ref startAnimationCoroutine);
			startAnimationTween.Complete(withCallbacks: false);
		}
	}

	private void OnTutorialQuestUpdated()
	{
		UpdateObjectiveText();
		autoTransformRebuild.RebuildTransform();
	}

	private void OnTutorialQuestStarted()
	{
		UpdateMainText();
		UpdateSecondaryText();
		UpdateObjectiveText();
		UpdateQuestImage();
		nextButton.gameObject.SetActive(value: false);
		autoTransformRebuild.RebuildTransform();
	}

	private void OnTutorialQuestCompleted()
	{
		UpdateObjectiveText();
		if (!tutorialGameManager.IsLastQuest())
		{
			nextButton.gameObject.SetActive(value: true);
		}
		autoTransformRebuild.RebuildTransform();
	}

	private void UpdateMainText()
	{
		mainText.text = tutorialGameManager.GetCurrentQuest().MainQuestText;
	}

	private void UpdateSecondaryText()
	{
		if (tutorialGameManager.GetCurrentQuest().SecondaryQuestText.Trim().Length > 0)
		{
			secondaryText.gameObject.SetActive(value: true);
			secondaryText.text = tutorialGameManager.GetCurrentQuest().SecondaryQuestText;
		}
		else
		{
			secondaryText.gameObject.SetActive(value: false);
		}
	}

	private void UpdateObjectiveText()
	{
		if (tutorialGameManager.GetCurrentQuest().GetObjectiveText().Length > 0)
		{
			objectiveSeparationLine.gameObject.SetActive(value: true);
			objectiveText.gameObject.SetActive(value: true);
			objectiveText.text = tutorialGameManager.GetCurrentQuest().GetObjectiveText();
		}
		else
		{
			objectiveText.gameObject.SetActive(value: false);
			objectiveSeparationLine.gameObject.SetActive(value: false);
		}
	}

	private void UpdateQuestImage()
	{
		if ((bool)tutorialGameManager.GetCurrentQuest().QuestSprite)
		{
			questImage.gameObject.SetActive(value: true);
			questImage.sprite = tutorialGameManager.GetCurrentQuest().QuestSprite;
		}
		else
		{
			questImage.gameObject.SetActive(value: false);
		}
	}

	public void OnNextButtonPressed()
	{
		tutorialGameManager.StartNextQuest();
	}

	private IEnumerator StartAnimationCoroutine()
	{
		RectTransform rectTransform = base.transform as RectTransform;
		float delay = 2f;
		float duration = 1f;
		Vector2 anchoredPosition = rectTransform.anchoredPosition;
		rectTransform.anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y + 500f);
		startAnimationTween = rectTransform.DOAnchorPos(anchoredPosition, duration).SetEase(Ease.OutSine).SetDelay(delay)
			.OnStart(delegate
			{
				AudioSystem.Instance.PlaySound2D(startAnimationSound, AudioSystem.EAudioMixerGroup.SFX);
			})
			.OnComplete(delegate
			{
				startAnimationCoroutine = null;
			});
		yield return null;
	}
}
