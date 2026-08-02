using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialTaskUI : MonoBehaviour
{
	public TextMeshProUGUI taskText;

	public TextMeshProUGUI progressText;

	public GameObject countContainer;

	public GameObject taskCompletedImage;

	public bool slideIsActive = true;

	private TutorialTask associatedTask;

	private CanvasGroup canvasGroup;

	public RectTransform rectTransform;

	private Sequence slideSequence;

	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
	}

	public void Setup(TutorialTask task)
	{
		associatedTask = task;
		taskText.text = task.taskText;
		if (countContainer != null)
		{
			countContainer.SetActive(task.maxProgress > 1);
		}
		if (taskCompletedImage != null)
		{
			taskCompletedImage.SetActive(task.isCompleted);
		}
		UpdateProgress();
	}

	public void UpdateProgress()
	{
		if (associatedTask != null)
		{
			progressText.text = $"{associatedTask.currentProgress}/{associatedTask.maxProgress}";
		}
	}

	public void RefreshText()
	{
		if (associatedTask != null)
		{
			taskText.text = associatedTask.taskText;
		}
	}

	public void SlideOutAndFade(float slideDistance, float duration, Action onComplete)
	{
		if (!slideIsActive)
		{
			if (taskCompletedImage != null)
			{
				taskCompletedImage.SetActive(value: true);
			}
			return;
		}
		Vector2 anchoredPosition = rectTransform.anchoredPosition;
		Vector2 endValue = new Vector2(anchoredPosition.x + slideDistance, anchoredPosition.y);
		slideSequence?.Kill();
		slideSequence = DOTween.Sequence();
		slideSequence.Append(rectTransform.DOAnchorPos(endValue, duration).SetEase(Ease.InQuart)).Join(canvasGroup.DOFade(0f, duration)).OnComplete(delegate
		{
			onComplete?.Invoke();
		});
	}

	private void OnDestroy()
	{
		slideSequence?.Kill();
	}
}
