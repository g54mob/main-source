using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButtonUI : MonoBehaviour, ISavedProgressReader, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Button activeButton;

	[SerializeField]
	private Transform info;

	[SerializeField]
	private TextMeshProUGUI infoCount;

	[SerializeField]
	private Transform scaleTransform;

	[SerializeField]
	private List<ParticleSystem> particleSystems;

	private Image activeButtonImage;

	private CanvasGroup activeButtonCanvasGroup;

	private CanvasGroup infoCanvasGroup;

	private float levelScore;

	private int newScore;

	private int currentScore;

	public int countFPS = 30;

	public float duration = 1f;

	private float frameRate;

	private bool hasActivated;

	private Sequence activationAnimation;

	private Tween loopingAnimation;

	private Sequence infoAnimation;

	private Sequence infoFadeAnimation;

	private float infoPosY;

	public static NextLevelButtonUI Instance { get; private set; }

	public event EventHandler OnNextLevelButton;

	public event EventHandler OnButtonClickForTutorial;

	public event EventHandler OnNextLevelButtonActivation;

	private void Awake()
	{
		Instance = this;
		activeButtonImage = activeButton.GetComponent<Image>();
		activeButtonCanvasGroup = activeButton.GetComponent<CanvasGroup>();
		infoCanvasGroup = info.GetComponent<CanvasGroup>();
		infoPosY = info.localPosition.y;
		frameRate = duration * (float)countFPS;
	}

	private void Start()
	{
		activeButton.onClick.AddListener(OnNextLevelButtonAction);
		InputManager instance = InputManager.Instance;
		instance.OnNextRoom = (Action)Delegate.Combine(instance.OnNextRoom, new Action(OnNextLevelButtonAction));
		TotalScoreCalculator.Instance.OnTotalScoreChanged += TotalScoreCalculator_OnTotalScoreChanged;
		DialogueManager.Instance.OnLastDialogueFinish += DialogueManager_OnLastDialogueFinish;
		levelScore = CollectionManager.Instance.GetScoreMax();
	}

	private void OnEnable()
	{
		if (!hasActivated)
		{
			return;
		}
		foreach (ParticleSystem particleSystem in particleSystems)
		{
			particleSystem.Play();
		}
	}

	private void DialogueManager_OnLastDialogueFinish(object sender, EventArgs e)
	{
		OnNextLevelButtonAction();
	}

	private void TotalScoreCalculator_OnTotalScoreChanged(object sender, EventArgs e)
	{
		newScore = TotalScoreCalculator.Instance.GetTotalScore();
		StartCoroutine(UpdateButtonFill());
	}

	private void OnNextLevelButtonAction()
	{
		if (InputManager.Instance.gamePause || !base.isActiveAndEnabled)
		{
			return;
		}
		if (hasActivated)
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.DialogsStart[SceneManager.GetActiveScene().name + 2])
			{
				this.OnButtonClickForTutorial?.Invoke(this, EventArgs.Empty);
				DialogueManager.Instance.ShowNextDialogueWithID(2);
			}
			else
			{
				this.OnNextLevelButton?.Invoke(this, EventArgs.Empty);
			}
		}
		else
		{
			infoAnimation.Kill();
			infoFadeAnimation.Kill();
			InfoAnimation();
		}
	}

	public void ForcedNextLevel()
	{
		if (!InputManager.Instance.gamePause && base.isActiveAndEnabled)
		{
			this.OnNextLevelButton?.Invoke(this, EventArgs.Empty);
		}
	}

	private void UpdateButtonImage(float fillAmount)
	{
		if (levelScore != 0f && !hasActivated)
		{
			activeButtonImage.fillAmount = fillAmount / levelScore;
		}
		if (fillAmount >= levelScore && !hasActivated)
		{
			hasActivated = true;
			this.OnNextLevelButtonActivation?.Invoke(this, EventArgs.Empty);
			LevelScoreReached();
		}
	}

	private IEnumerator UpdateButtonFill()
	{
		WaitForSeconds Wait = new WaitForSeconds(1f / (float)countFPS);
		int scoreDelta = newScore - currentScore;
		int stepAmount = ((scoreDelta < 0) ? Mathf.FloorToInt((float)scoreDelta / frameRate) : Mathf.CeilToInt((float)scoreDelta / frameRate));
		while (currentScore != newScore)
		{
			currentScore += stepAmount;
			if (Mathf.Sign(scoreDelta) * (float)(newScore - currentScore) <= 0f)
			{
				currentScore = newScore;
			}
			UpdateButtonImage(currentScore);
			yield return Wait;
		}
	}

	private void UnactivateButton()
	{
		if (activeButtonCanvasGroup != null)
		{
			activeButtonCanvasGroup.alpha = 0.6f;
		}
		hasActivated = false;
		StopButtonAnimation();
	}

	private void StopButtonAnimation()
	{
		activationAnimation.Kill();
		loopingAnimation.Kill();
		scaleTransform.DOScale(1f, 0.1f);
	}

	private void LevelScoreReached()
	{
		activationAnimation = DOTween.Sequence();
		activationAnimation.Append(scaleTransform.DOScale(0.1f, 0.1f).SetEase(Ease.InOutSine)).Append(activeButtonCanvasGroup.DOFade(1f, 0.01f)).AppendCallback(delegate
		{
			SoundManager.Instance.OnDing();
		})
			.Append(scaleTransform.DOScale(1.2f, 0.5f).SetEase(Ease.OutExpo))
			.Append(scaleTransform.DOScale(0.9f, 0.1f).SetEase(Ease.InOutSine))
			.Append(scaleTransform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
			.AppendCallback(StartLoopingAnimation)
			.Play();
		foreach (ParticleSystem particleSystem in particleSystems)
		{
			particleSystem.Play();
		}
	}

	private void StartLoopingAnimation()
	{
		loopingAnimation = scaleTransform.DOScale(0.9f, 1.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		loopingAnimation.Play();
	}

	private void InfoAnimation()
	{
		infoCount.text = currentScore + " / " + levelScore;
		infoAnimation = DOTween.Sequence();
		infoFadeAnimation = DOTween.Sequence();
		info.gameObject.SetActive(value: true);
		infoCanvasGroup.alpha = 0f;
		info.localPosition = new Vector3(info.localPosition.x, infoPosY, info.localPosition.z);
		infoFadeAnimation.Append(infoCanvasGroup.DOFade(1f, 1f)).Append(infoCanvasGroup.DOFade(0f, 3f).SetEase(Ease.InCubic)).AppendCallback(delegate
		{
			info.gameObject.SetActive(value: false);
		})
			.Play();
		infoAnimation.Append(info.DOLocalMoveY(infoPosY + 20f, 4f).SetEase(Ease.OutExpo)).Play();
	}

	public void LoadProgress(PlayerProgress progress)
	{
		if (!progress.CreativeMode)
		{
			currentScore = progress.Score;
			if ((float)currentScore >= levelScore)
			{
				hasActivated = true;
			}
			else
			{
				UnactivateButton();
			}
			UpdateButtonImage(currentScore);
		}
	}

	private void OnDestroy()
	{
		InputManager instance = InputManager.Instance;
		instance.OnNextRoom = (Action)Delegate.Remove(instance.OnNextRoom, new Action(OnNextLevelButtonAction));
		TotalScoreCalculator.Instance.OnTotalScoreChanged -= TotalScoreCalculator_OnTotalScoreChanged;
		DialogueManager.Instance.OnLastDialogueFinish -= DialogueManager_OnLastDialogueFinish;
		activeButton.onClick.RemoveAllListeners();
		infoAnimation.Kill();
		infoFadeAnimation.Kill();
		activationAnimation.Kill();
		loopingAnimation.Kill();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (hasActivated)
		{
			StopButtonAnimation();
			scaleTransform.DOScale(1.15f, 0.35f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (hasActivated)
		{
			StopButtonAnimation();
			scaleTransform.DOComplete();
			scaleTransform.DOScale(1f, 0.01f);
			StartLoopingAnimation();
		}
	}
}
