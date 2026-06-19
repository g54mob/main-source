using System;
using System.Collections.Generic;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.Events;

public class HoldingIndicatorViewAdvanced : UIView
{
	public enum LetterAnimationStyle
	{
		SimpleJump = 0,
		Bounce = 1,
		Elastic = 2,
		Wave = 3,
		SpinJump = 4,
		SquashStretch = 5,
		Pop = 6,
		Wiggle = 7,
		Rainbow = 8,
		Random = 9
	}

	[Header("Letters")]
	[SerializeField]
	private RectTransform[] letterObjects;

	[Header("Sliced Element")]
	[SerializeField]
	private RectTransform slicedElement;

	[SerializeField]
	private RectTransform background;

	[Header("Padding")]
	[SerializeField]
	private float leftPadding = 20f;

	[SerializeField]
	private float rightPadding = 20f;

	[SerializeField]
	private float topPadding = 10f;

	[SerializeField]
	private float bottomPadding = 10f;

	[Header("Progress Animation")]
	[SerializeField]
	private float progressDuration = 0.5f;

	[SerializeField]
	private Ease progressEase = Ease.OutCubic;

	[Header("Letter Animation Style")]
	[SerializeField]
	private LetterAnimationStyle animationStyle;

	[Header("Simple Jump Settings")]
	[SerializeField]
	private float jumpHeight = 30f;

	[SerializeField]
	private float jumpDuration = 0.3f;

	[SerializeField]
	private Ease jumpUpEase = Ease.OutQuad;

	[SerializeField]
	private Ease jumpDownEase = Ease.InQuad;

	[SerializeField]
	private bool useScale = true;

	[SerializeField]
	private float scaleAmount = 1.2f;

	[SerializeField]
	private float scaleDuration = 0.15f;

	[SerializeField]
	private Ease scaleEase = Ease.OutBack;

	[SerializeField]
	private bool useRotation = true;

	[SerializeField]
	private float rotationAmount = 5f;

	[SerializeField]
	private float rotationDuration = 0.2f;

	[SerializeField]
	private AnimationCurve customJumpCurve;

	[Header("Bounce Style")]
	[SerializeField]
	private float bounceHeight = 30f;

	[SerializeField]
	private float bounceDuration = 0.4f;

	[Header("Elastic Style")]
	[SerializeField]
	private float elasticHeight = 40f;

	[SerializeField]
	private float elasticDuration = 0.6f;

	[Header("Wave Style")]
	[SerializeField]
	private float waveAmplitude = 25f;

	[SerializeField]
	private float waveDuration = 0.5f;

	[Header("Spin Jump Style")]
	[SerializeField]
	private float spinHeight = 35f;

	[SerializeField]
	private float spinAmount = 360f;

	[SerializeField]
	private float spinDuration = 0.5f;

	[Header("Squash Stretch Style")]
	[SerializeField]
	private float squashStretchDuration = 0.4f;

	[Header("Pop Style")]
	[SerializeField]
	private float popScale = 1.5f;

	[SerializeField]
	private float popDuration = 0.3f;

	[Header("Wiggle Style")]
	[SerializeField]
	private float wiggleAngle = 15f;

	[SerializeField]
	private float wiggleDuration = 0.4f;

	[Header("Rainbow Style")]
	[SerializeField]
	private Color[] rainbowColors;

	[SerializeField]
	private float rainbowDuration = 0.6f;

	[Header("Advanced Options")]
	[SerializeField]
	private bool randomizeAnimations;

	[SerializeField]
	private float delayBetweenLetters = 0.05f;

	[Header("Events")]
	[SerializeField]
	private UnityEvent<float> onProgressChanged;

	[SerializeField]
	private UnityEvent onLetterTriggered;

	[SerializeField]
	private UnityEvent onComplete;

	private HoldingIndicatorViewModel viewModel;

	private float maxWidth;

	private Dictionary<int, bool> triggeredLetters = new Dictionary<int, bool>();

	private Tween currentProgressTween;

	private bool wasComplete;

	private float currentVisualProgress = 1f;

	public HoldingIndicatorViewModel ViewModel => viewModel;

	protected override void Start()
	{
		base.Start();
		maxWidth = slicedElement.sizeDelta.x;
		for (int i = 0; i < letterObjects.Length; i++)
		{
			triggeredLetters[i] = false;
		}
		SetProgressImmediate(0f);
		viewModel = new HoldingIndicatorViewModel();
		SetupBindings();
	}

	private void SetupBindings()
	{
		BindingSet<HoldingIndicatorViewAdvanced, HoldingIndicatorViewModel> bindingSet = this.CreateBindingSet<HoldingIndicatorViewAdvanced, HoldingIndicatorViewModel>();
		this.SetDataContext(viewModel);
		bindingSet.Bind(this).For((HoldingIndicatorViewAdvanced v) => v.Visibility).To((HoldingIndicatorViewModel vm) => vm.Enabled)
			.OneWay();
		bindingSet.Build();
		viewModel.Progress.ValueChanged += OnProgressChanged;
	}

	private void SetupSlicedElementPosition()
	{
		Vector2 anchoredPosition = slicedElement.anchoredPosition;
		anchoredPosition.x = leftPadding;
		anchoredPosition.y = 0f - topPadding;
		slicedElement.anchoredPosition = anchoredPosition;
	}

	private void OnProgressChanged(object sender, EventArgs e)
	{
		if (viewModel != null)
		{
			float num = 1f - Mathf.Clamp01(viewModel.Progress);
			AnimateProgress(num);
			onProgressChanged?.Invoke(num);
			if (num >= 1f && !wasComplete)
			{
				wasComplete = true;
				onComplete?.Invoke();
			}
			else if (num < 1f && wasComplete)
			{
				wasComplete = false;
			}
		}
	}

	private void AnimateProgress(float targetProgress)
	{
		currentProgressTween?.Kill();
		currentProgressTween = DOTween.To(() => currentVisualProgress, delegate(float p)
		{
			currentVisualProgress = p;
			ApplyProgress(p);
		}, targetProgress, progressDuration).SetEase(progressEase);
	}

	private void ApplyProgress(float progress)
	{
		float num = maxWidth * progress;
		Vector2 sizeDelta = slicedElement.sizeDelta;
		sizeDelta.x = num;
		slicedElement.sizeDelta = sizeDelta;
		CheckLetterTriggers(num);
	}

	private void SetProgressImmediate(float progress)
	{
		currentVisualProgress = progress;
		ApplyProgress(progress);
	}

	private void SetSlicedWidth(float width)
	{
		Vector2 sizeDelta = slicedElement.sizeDelta;
		sizeDelta.x = width;
		slicedElement.sizeDelta = sizeDelta;
		CheckLetterTriggers(width);
	}

	private void CheckLetterTriggers(float currentWidth)
	{
		if (letterObjects == null || letterObjects.Length == 0)
		{
			return;
		}
		Vector3[] array = new Vector3[4];
		slicedElement.GetWorldCorners(array);
		float x = array[2].x;
		for (int i = 0; i < letterObjects.Length; i++)
		{
			if (!(letterObjects[i] == null))
			{
				Vector3[] array2 = new Vector3[4];
				letterObjects[i].GetWorldCorners(array2);
				float num = (array2[0].x + array2[2].x) / 2f;
				if (x >= num && !triggeredLetters[i])
				{
					triggeredLetters[i] = true;
					AnimateLetter(letterObjects[i], i);
					onLetterTriggered?.Invoke();
				}
				else if (x < num && triggeredLetters[i])
				{
					triggeredLetters[i] = false;
				}
			}
		}
	}

	private void AnimateLetter(RectTransform letter, int index)
	{
		if (!(letter == null))
		{
			LetterAnimationStyle letterAnimationStyle = animationStyle;
			if (animationStyle == LetterAnimationStyle.Random || randomizeAnimations)
			{
				letterAnimationStyle = (LetterAnimationStyle)UnityEngine.Random.Range(0, 9);
			}
			Sequence sequence = null;
			switch (letterAnimationStyle)
			{
			case LetterAnimationStyle.SimpleJump:
				sequence = CreateSimpleJumpAnimation(letter);
				break;
			case LetterAnimationStyle.Bounce:
				sequence = LetterAnimationStyles.CreateBounceAnimation(letter, bounceHeight, bounceDuration);
				break;
			case LetterAnimationStyle.Elastic:
				sequence = LetterAnimationStyles.CreateElasticAnimation(letter, elasticHeight, elasticDuration);
				break;
			case LetterAnimationStyle.Wave:
				sequence = LetterAnimationStyles.CreateWaveAnimation(letter, waveAmplitude, waveDuration);
				break;
			case LetterAnimationStyle.SpinJump:
				sequence = LetterAnimationStyles.CreateSpinJumpAnimation(letter, spinHeight, spinAmount, spinDuration);
				break;
			case LetterAnimationStyle.SquashStretch:
				sequence = LetterAnimationStyles.CreateSquashStretchAnimation(letter, squashStretchDuration);
				break;
			case LetterAnimationStyle.Pop:
				sequence = LetterAnimationStyles.CreatePopAnimation(letter, popScale, popDuration);
				break;
			case LetterAnimationStyle.Wiggle:
				sequence = LetterAnimationStyles.CreateWiggleAnimation(letter, wiggleAngle, wiggleDuration);
				break;
			case LetterAnimationStyle.Rainbow:
				sequence = LetterAnimationStyles.CreateRainbowJumpAnimation(letter, jumpHeight, rainbowDuration, rainbowColors);
				break;
			}
			sequence?.Play();
		}
	}

	private Sequence CreateSimpleJumpAnimation(RectTransform letter)
	{
		Vector2 anchoredPosition = letter.anchoredPosition;
		Vector3 localScale = letter.localScale;
		Vector3 localEulerAngles = letter.localEulerAngles;
		Sequence sequence = DOTween.Sequence();
		if (customJumpCurve != null && customJumpCurve.keys.Length != 0)
		{
			sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + jumpHeight, jumpDuration / 2f).SetEase(customJumpCurve));
		}
		else
		{
			sequence.Append(letter.DOAnchorPosY(anchoredPosition.y + jumpHeight, jumpDuration / 2f).SetEase(jumpUpEase));
		}
		sequence.Append(letter.DOAnchorPosY(anchoredPosition.y, jumpDuration / 2f).SetEase(jumpDownEase));
		if (useScale)
		{
			Sequence sequence2 = DOTween.Sequence();
			sequence2.Append(letter.DOScale(localScale * scaleAmount, scaleDuration).SetEase(scaleEase));
			sequence2.Append(letter.DOScale(localScale, scaleDuration).SetEase(scaleEase));
			sequence.Insert(0f, sequence2);
		}
		if (useRotation)
		{
			float num = UnityEngine.Random.Range(0f - rotationAmount, rotationAmount);
			Sequence sequence3 = DOTween.Sequence();
			sequence3.Append(letter.DORotate(new Vector3(localEulerAngles.x, localEulerAngles.y, localEulerAngles.z + num), rotationDuration));
			sequence3.Append(letter.DORotate(localEulerAngles, rotationDuration));
			sequence.Insert(0f, sequence3);
		}
		return sequence;
	}

	public void ResetProgress()
	{
		currentProgressTween?.Kill();
		SetProgressImmediate(1f);
		for (int i = 0; i < letterObjects.Length; i++)
		{
			triggeredLetters[i] = false;
			if (letterObjects[i] != null)
			{
				letterObjects[i].DOKill();
				letterObjects[i].localScale = Vector3.one;
				letterObjects[i].localEulerAngles = Vector3.zero;
			}
		}
		wasComplete = false;
	}

	public void SetAnimationStyle(LetterAnimationStyle style)
	{
		animationStyle = style;
	}

	private new void OnDestroy()
	{
		currentProgressTween?.Kill();
		if (letterObjects == null)
		{
			return;
		}
		RectTransform[] array = letterObjects;
		foreach (RectTransform rectTransform in array)
		{
			if (rectTransform != null)
			{
				rectTransform.DOKill();
			}
		}
	}
}
