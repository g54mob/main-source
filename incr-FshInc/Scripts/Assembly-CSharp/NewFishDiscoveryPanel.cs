using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class NewFishDiscoveryPanel : MonoBehaviour
{
	[Header("UI References")]
	public RectTransform fishImageRect;

	public Image fishImage;

	public CanvasGroup panelGroup;

	public TMP_Text fishNameText;

	public TMP_Text discoveryBannerText;

	public Image sunburstImage;

	public FishingManager fishingManager;

	[Header("Visuals")]
	public Material silhouetteMaterial;

	[Header("Global Timing")]
	[Tooltip("Multiply all durations by this value. 1.0 = exact time. 0.5 = twice as fast. 2.0 = half speed.")]
	public float globalSpeedMultiplier = 1f;

	[Header("1. Entry Animation")]
	public float moveDuration = 0.7f;

	public float fadeDuration = 0.5f;

	[Header("2. Reveal Sequence (Sync with SFX)")]
	[Tooltip("First wobble phase")]
	public float shake1Duration = 0.8f;

	[Tooltip("Second, more intense wobble phase")]
	public float shake2Duration = 0.6f;

	[Tooltip("The moment the fish scales up/pops")]
	public float popScaleDuration = 0.15f;

	[Header("3. Post-Reveal Settle")]
	[Tooltip("Time it takes for fish to bounce back to normal size")]
	public float settleScaleDuration = 0.8f;

	[Tooltip("Time for text to appear")]
	public float textRevealDuration = 0.5f;

	[Header("4. Exit Settings")]
	public float waitDuration = 2f;

	private CaughtFish currentFish;

	private bool canSkipReveal;

	private bool canSkipWait;

	private CaughtFish lastFish;

	private Sequence revealSequence;

	private Tween waitTween;

	private Tween sunburstTween;

	private Vector2 centerScreenPosition = Vector2.zero;

	private Vector2 offScreenPosition;

	public bool IsShowing { get; private set; }

	private void Start()
	{
		offScreenPosition = new Vector2(0f, (float)(-Screen.height) / 2f - fishImageRect.sizeDelta.y);
		fishImageRect.anchoredPosition = offScreenPosition;
		panelGroup.alpha = 0f;
		panelGroup.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			HandleSkipInput();
		}
	}

	private void HandleSkipInput()
	{
		if (canSkipReveal)
		{
			canSkipReveal = false;
			revealSequence.Kill();
			fishImage.transform.rotation = Quaternion.identity;
			fishImage.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
			OnRevealComplete();
		}
		else if (canSkipWait)
		{
			canSkipWait = false;
			waitTween.Kill();
			StartExitAnimation();
		}
	}

	public void ShowDiscovery(CaughtFish newFish)
	{
		SoundManager.PlaySound("FishDiscovered");
		lastFish = newFish;
		KillAllTweens();
		IsShowing = true;
		currentFish = newFish;
		panelGroup.gameObject.SetActive(value: true);
		fishImage.sprite = newFish.artwork;
		fishImage.material = silhouetteMaterial;
		fishNameText.text = "?????";
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.new.species");
		discoveryBannerText.text = localizedString.GetLocalizedString();
		Vector2 zero = Vector2.zero;
		Vector2 anchoredPosition = new Vector2(0f, (float)(-Screen.height) / 2f - fishImageRect.sizeDelta.y);
		fishImageRect.anchoredPosition = anchoredPosition;
		fishNameText.transform.localScale = Vector3.zero;
		fishImage.transform.localScale = Vector3.one;
		fishImage.transform.rotation = Quaternion.identity;
		sunburstTween = sunburstImage.transform.DORotate(new Vector3(0f, 0f, -360f), 10f * globalSpeedMultiplier, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
		Sequence sequence = DOTween.Sequence();
		sequence.Append(fishImageRect.DOAnchorPos(zero, moveDuration * globalSpeedMultiplier).SetEase(Ease.OutCubic));
		sequence.Join(panelGroup.DOFade(1f, fadeDuration * globalSpeedMultiplier));
		sequence.OnComplete(StartRevealAnimation);
	}

	private void StartRevealAnimation()
	{
		canSkipReveal = true;
		revealSequence = DOTween.Sequence();
		revealSequence.Append(fishImage.transform.DOShakeRotation(shake1Duration * globalSpeedMultiplier, new Vector3(0f, 0f, 8f), 15));
		revealSequence.Append(fishImage.transform.DOShakeRotation(shake2Duration * globalSpeedMultiplier, new Vector3(0f, 0f, 15f), 25));
		revealSequence.Append(fishImage.transform.DOScale(1.25f, popScaleDuration * globalSpeedMultiplier).SetEase(Ease.OutQuad));
		revealSequence.OnComplete(OnRevealComplete);
	}

	private void OnRevealComplete()
	{
		canSkipReveal = false;
		fishImage.material = null;
		fishNameText.text = currentFish.fish.LocalizedName;
		fishImage.transform.DOScale(1f, settleScaleDuration * globalSpeedMultiplier).SetEase(Ease.OutBounce);
		fishNameText.transform.DOScale(1f, textRevealDuration * globalSpeedMultiplier).SetEase(Ease.OutBack);
		StartWaitPeriod();
	}

	private void StartWaitPeriod()
	{
		canSkipWait = true;
		waitTween = DOVirtual.DelayedCall(waitDuration * globalSpeedMultiplier, StartExitAnimation, ignoreTimeScale: false);
	}

	private void StartExitAnimation()
	{
		canSkipWait = false;
		Vector2 endValue = new Vector2(0f, (float)(-Screen.height) / 2f - fishImageRect.sizeDelta.y);
		Sequence sequence = DOTween.Sequence();
		sequence.Append(panelGroup.DOFade(0f, fadeDuration * globalSpeedMultiplier));
		sequence.Append(fishImageRect.DOAnchorPos(endValue, moveDuration * globalSpeedMultiplier).SetEase(Ease.InCubic));
		sequence.OnComplete(delegate
		{
			panelGroup.gameObject.SetActive(value: false);
			KillAllTweens();
			IsShowing = false;
			_ = fishingManager != null;
		});
	}

	private void KillAllTweens()
	{
		revealSequence?.Kill();
		waitTween?.Kill();
		sunburstTween?.Kill();
		fishImageRect.DOKill();
		panelGroup.DOKill();
		fishImage.transform.DOKill();
		fishNameText.transform.DOKill();
	}
}
