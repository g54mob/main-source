using System;
using UnityEngine;

public class Tweener : MonoBehaviour
{
	private RectTransform rt;

	private LTDescr currentTween;

	private CanvasGroup canvasGroup;

	private LTDescr currentAlphaTween;

	private Coroutine delayedFadeCoroutine;

	[Header("Position ")]
	[SerializeField]
	private Vector3 startPos;

	[SerializeField]
	private Vector3 endPos;

	[SerializeField]
	private float duration;

	[Header("Alpha Settings")]
	[SerializeField]
	private float startAlpha = 1f;

	[SerializeField]
	private float endAlpha;

	[SerializeField]
	private float fadeDuration;

	[SerializeField]
	private UnitAudioController audioController;

	[SerializeField]
	private int audioClipChannelIndex;

	private bool isAudioClipPlaying;

	public float Duration => duration;

	public float FadeDuration
	{
		get
		{
			return fadeDuration;
		}
		set
		{
			fadeDuration = value;
		}
	}

	public event Action OnMoveToEnd;

	public event Action OnMoveToStart;

	public event Action OnFadeToEnd;

	public event Action OnFadeToStart;

	private void Awake()
	{
		rt = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void Move(bool isToEndPos)
	{
		if (currentTween != null)
		{
			LeanTween.cancel(currentTween.id);
		}
		if (!isAudioClipPlaying && audioController != null)
		{
			audioController.PlayOnChannel(audioClipChannelIndex);
			isAudioClipPlaying = true;
		}
		if (isToEndPos)
		{
			currentTween = LeanTween.move(rt, endPos, duration).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(useUnScaledTime: true)
				.setOnComplete((Action)delegate
				{
					EndReached();
					currentTween = null;
				});
		}
		else
		{
			currentTween = LeanTween.move(rt, startPos, duration).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(useUnScaledTime: true)
				.setOnComplete((Action)delegate
				{
					StartReached();
					currentTween = null;
				});
		}
	}

	public void Fade(bool isToEndAlpha)
	{
		if (canvasGroup == null)
		{
			return;
		}
		if (currentAlphaTween != null)
		{
			LeanTween.cancel(currentAlphaTween.id);
		}
		float to = (isToEndAlpha ? endAlpha : startAlpha);
		currentAlphaTween = LeanTween.alphaCanvas(canvasGroup, to, fadeDuration).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(useUnScaledTime: true)
			.setOnComplete((Action)delegate
			{
				if (isToEndAlpha)
				{
					this.OnFadeToEnd?.Invoke();
				}
				else
				{
					this.OnFadeToStart?.Invoke();
				}
				currentAlphaTween = null;
			});
	}

	public void Reset()
	{
		if (currentTween != null)
		{
			LeanTween.cancel(currentTween.id);
			currentTween = null;
		}
		rt.anchoredPosition = new Vector2(startPos.x, startPos.y);
	}

	public void ResetAlpha()
	{
		if (currentAlphaTween != null)
		{
			LeanTween.cancel(currentAlphaTween.id);
			currentAlphaTween = null;
		}
		canvasGroup.alpha = startAlpha;
	}

	public void ResetAll()
	{
		Reset();
		ResetAlpha();
	}

	private void EndReached()
	{
		if (audioController != null)
		{
			audioController.StopChannel(audioClipChannelIndex);
		}
		isAudioClipPlaying = false;
		this.OnMoveToEnd?.Invoke();
	}

	private void StartReached()
	{
		if (audioController != null)
		{
			audioController.StopChannel(audioClipChannelIndex);
		}
		isAudioClipPlaying = false;
		this.OnMoveToStart?.Invoke();
	}
}
