using System;
using DG.Tweening;
using NewGameplayScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewPlantButtonUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Button newPlantButton;

	[SerializeField]
	private Transform info;

	[SerializeField]
	private TextMeshProUGUI infoCount;

	[SerializeField]
	private TextMeshProUGUI infoCountText;

	[SerializeField]
	private TextMeshProUGUI infoNoPlantsText;

	[SerializeField]
	private Transform notify;

	[SerializeField]
	private Transform scaleTransform;

	[SerializeField]
	private ParticleSystem particles;

	private CanvasGroup newPlantButtonCanvasGroup;

	private CanvasGroup infoCanvasGroup;

	private TextMeshProUGUI notifyText;

	public int notifiesCount = 1;

	private Sequence activationAnimation;

	private Tween loopingAnimation;

	private Sequence infoAnimation;

	private Sequence infoFadeAnimation;

	private float infoPosY;

	private bool IsFirstClick = true;

	private bool isActive;

	public event EventHandler OnSpawn;

	public event EventHandler OnFirstClick;

	private void Awake()
	{
		newPlantButtonCanvasGroup = newPlantButton.GetComponent<CanvasGroup>();
		infoCanvasGroup = info.GetComponent<CanvasGroup>();
		infoPosY = info.localPosition.y;
		notifyText = notify.GetComponentInChildren<TextMeshProUGUI>();
		isActive = true;
	}

	private void Start()
	{
		ChooseNextPlantWindowUI.Instance.OnExit += ChooseNextPlantWindowUI_OnExit;
		ProgressManager instance = ProgressManager.Instance;
		instance.UpdateButtonCount = (Action<int>)Delegate.Combine(instance.UpdateButtonCount, new Action<int>(ProgressManager_UpdateButtonCount));
		newPlantButton.onClick.AddListener(SpawnNewPlant);
		InputManager instance2 = InputManager.Instance;
		instance2.OnNewPlant = (Action)Delegate.Combine(instance2.OnNewPlant, new Action(SpawnNewPlant));
		NewScoreUI instance3 = NewScoreUI.Instance;
		instance3.OnMaxScoreReached = (Action<bool>)Delegate.Combine(instance3.OnMaxScoreReached, new Action<bool>(NewScoreUI_OnMaxScoreReached));
	}

	private void OnDestroy()
	{
		ChooseNextPlantWindowUI.Instance.OnExit -= ChooseNextPlantWindowUI_OnExit;
		ProgressManager instance = ProgressManager.Instance;
		instance.UpdateButtonCount = (Action<int>)Delegate.Remove(instance.UpdateButtonCount, new Action<int>(ProgressManager_UpdateButtonCount));
		newPlantButton.onClick.RemoveAllListeners();
		InputManager instance2 = InputManager.Instance;
		instance2.OnNewPlant = (Action)Delegate.Remove(instance2.OnNewPlant, new Action(SpawnNewPlant));
		NewScoreUI instance3 = NewScoreUI.Instance;
		instance3.OnMaxScoreReached = (Action<bool>)Delegate.Remove(instance3.OnMaxScoreReached, new Action<bool>(NewScoreUI_OnMaxScoreReached));
		infoAnimation.Kill();
		infoFadeAnimation.Kill();
		activationAnimation.Kill();
		loopingAnimation.Kill();
	}

	private void ProgressManager_UpdateButtonCount(int newCount)
	{
		notifiesCount = newCount;
		CheckNotifyVisibility();
	}

	private void ChooseNextPlantWindowUI_OnExit(object sender, EventArgs e)
	{
		CheckVisibility();
	}

	private void NewScoreUI_OnMaxScoreReached(bool levelScoreReached)
	{
		Show();
	}

	private void SpawnNewPlant()
	{
		if (MovementSystem.Instance.IsMoving() || InputManager.Instance.gamePause)
		{
			return;
		}
		if (isActive)
		{
			if (IsFirstClick)
			{
				IsFirstClick = false;
				this.OnFirstClick?.Invoke(this, EventArgs.Empty);
			}
			this.OnSpawn?.Invoke(this, EventArgs.Empty);
			ProgressManager.Instance.MinusPlantButtonCounter();
			StopLoopingAnimation();
			scaleTransform.DOScale(Vector3.one, 0.1f);
			if (notifiesCount <= 0)
			{
				Hide();
			}
			CheckNotifyVisibility();
		}
		else
		{
			infoAnimation.Kill();
			infoFadeAnimation.Kill();
			InfoAnimation();
		}
	}

	public void Show()
	{
		ProgressManager.Instance.IsSpawnButtonVisible = true;
		newPlantButtonCanvasGroup.alpha = 1f;
		isActive = true;
		ActivateButton();
		CheckNotifyVisibility();
	}

	public void Hide()
	{
		ProgressManager.Instance.IsSpawnButtonVisible = false;
		newPlantButtonCanvasGroup.alpha = 0f;
		isActive = false;
		StopLoopingAnimation();
		scaleTransform.DOScale(Vector3.one, 0.1f);
	}

	public void ActivateButton()
	{
		if (!InputManager.Instance.gamePause)
		{
			activationAnimation = DOTween.Sequence();
			activationAnimation.Append(scaleTransform.DOScale(0.1f, 0.1f).SetEase(Ease.InOutSine)).AppendCallback(delegate
			{
				particles.Play();
			}).AppendCallback(delegate
			{
				SoundManager.Instance.OnDing();
			})
				.Append(scaleTransform.DOScale(1.2f, 0.5f).SetEase(Ease.OutExpo))
				.Append(scaleTransform.DOScale(0.9f, 0.1f).SetEase(Ease.InOutSine))
				.Append(scaleTransform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
				.AppendCallback(StartLoopingAnimation)
				.Play();
		}
	}

	private void InfoAnimation()
	{
		if (ProgressManager.Instance.IsAllPlantsSpawned())
		{
			infoCount.gameObject.SetActive(value: false);
			infoCountText.gameObject.SetActive(value: false);
			infoNoPlantsText.gameObject.SetActive(value: true);
		}
		else
		{
			infoCount.gameObject.SetActive(value: true);
			infoCountText.gameObject.SetActive(value: true);
			infoNoPlantsText.gameObject.SetActive(value: false);
			infoCount.text = NewScoreUI.Instance.GetCurrentScore() + " / " + NewScoreUI.Instance.GetCurrentMaxScore();
		}
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

	private void CheckNotifyVisibility()
	{
		notify.gameObject.SetActive(notifiesCount >= 2);
		UpdateNotifyText();
	}

	private void UpdateNotifyText()
	{
		notifyText.text = notifiesCount.ToString();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (isActive)
		{
			StopLoopingAnimation();
			scaleTransform.DOScale(1.4f, 0.3f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (isActive)
		{
			scaleTransform.DOScale(Vector3.one, 0.1f).OnComplete(delegate
			{
				StartLoopingAnimation();
			});
		}
	}

	private void StopLoopingAnimation()
	{
		loopingAnimation.Kill();
	}

	private void StartLoopingAnimation()
	{
		loopingAnimation = scaleTransform.DOScale(1.2f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
			.Play();
	}

	public void CheckVisibility()
	{
		if (notifiesCount <= 0)
		{
			Hide();
		}
		else
		{
			Show();
		}
	}
}
