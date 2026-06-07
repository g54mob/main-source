using System;
using Coffee.UIExtensions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MenuButton
{
	public Image chestImage;

	public Image rewardIcon;

	public UIParticle beamGlowParticles;

	public UIParticle crateExplosionParticles;

	public UIParticle rewardItemParticles;

	public TextMeshProUGUI countLabel;

	public RectTransform rewardImageRegion;

	[NonSerialized]
	private TextValueChangeAnimation textValueChangeAnimation;

	private double targetValue;

	[NonSerialized]
	public float revealCountdown;

	private float burstOpenCountdown;

	private Tween crateFadeAnimation;

	private Tween rewardScaleAnimation;

	private Tween bounceAnimation;

	private Sequence bounceSequence;

	private Sequence crateDropSequence;

	private Sequence crateShakeSequence;

	private const float crateShakeDuration = 1f;

	public LevelUpRewardPanel parentPanel;

	[NonSerialized]
	public bool hasOpened;

	private bool isManualClick;

	private EntityId rewardEntity;

	public void Initialize()
	{
		textValueChangeAnimation = new TextValueChangeAnimation(countLabel);
		textValueChangeAnimation.useRounded = true;
		animateSize = true;
		AddPointerClickTrigger(ManuallyClaim);
		highlightTextDelegate = GetHighlightText;
	}

	private string GetHighlightText()
	{
		if (!hasOpened)
		{
			return null;
		}
		string text = TextDisplay.LabelForEntity(rewardEntity);
		if (LocalizationManager.IsEnglish() && rewardEntity.TryAsItem(out var i))
		{
			switch (i)
			{
			case ItemType.UtilityPrestigePoint:
				text += TextDisplay.NewLine;
				text += "Used to purchase town perks";
				break;
			case ItemType.UtilityLand:
				text += TextDisplay.NewLine;
				text += "Required for building placement";
				break;
			case ItemType.UtilityQuestCoin:
				text += TextDisplay.NewLine;
				text += "Used to purchase global perks";
				break;
			case ItemType.YellowCoin:
			case ItemType.RedCoin:
			case ItemType.BlueCoin:
			case ItemType.PurpleCoin:
				text += TextDisplay.NewLine;
				text += "Used for research, buildings, and upgrades";
				break;
			}
		}
		return text;
	}

	public void UpdateDynamicDisplay()
	{
		if (revealCountdown > 0f)
		{
			revealCountdown -= TimeManager.MenuDelta;
			if (revealCountdown <= 0f)
			{
				BeginDrop();
			}
		}
		if (revealCountdown <= 0f)
		{
			textValueChangeAnimation.UpdateAnimation();
		}
	}

	public void LoadReward(EntityId id, double amount)
	{
		if (null != IconManager.Instance)
		{
			rewardIcon.sprite = IconManager.SpriteForEntity(id);
		}
		rewardIcon.enabled = false;
		chestImage.enabled = true;
		targetValue = amount;
		countLabel.enabled = false;
		isManualClick = false;
		rewardEntity = id;
		tooltipEntity = EntityId.None;
		base.buttonState = CustomButtonState.BlueFlashing;
	}

	public void PrepareForNewAnimation()
	{
		beamGlowParticles.enabled = false;
		crateExplosionParticles.enabled = false;
		rewardItemParticles.enabled = false;
		textValueChangeAnimation.DisplayValue(0.0);
		if (targetValue > 10.0)
		{
			textValueChangeAnimation.SetSpeed(0.5f);
		}
		else
		{
			textValueChangeAnimation.SetSpeed(1f);
		}
		textValueChangeAnimation.SetEase(Ease.OutQuad);
		chestImage.color = Color.clear;
	}

	private void BeginDrop()
	{
		float y = 100f;
		chestImage.color = Color.white;
		Transform transform = chestImage.transform;
		transform.transform.localPosition = new Vector3(0f, y, 0f);
		crateDropSequence = DOTween.Sequence();
		crateDropSequence.Append(transform.DOLocalMoveY(0f, 1f)).SetEase(Ease.OutQuint);
		SoundManager.PlayCrateThud();
	}

	private void OnCrateLanded()
	{
		SoundManager.PlayCrateThud();
	}

	private void ManuallyClaim()
	{
		if (!hasOpened)
		{
			isManualClick = true;
			SoundManager.PlayCrateBreak1();
			Claim();
		}
	}

	public void Claim()
	{
		if (!hasOpened)
		{
			chestImage.color = Color.white;
			revealCountdown = 0f;
			crateDropSequence?.Complete(withCallbacks: true);
			BeginShake();
		}
	}

	private void BeginShake()
	{
		base.buttonState = CustomButtonState.Default;
		hasOpened = true;
		float num = UnityEngine.Random.Range(0.75f, 2f);
		if (isManualClick)
		{
			num = 0.5f;
		}
		Transform target = chestImage.transform;
		crateShakeSequence = DOTween.Sequence();
		crateShakeSequence.Append(target.DOShakePosition(0.25f * num, 1f, 25, 90f, snapping: false, fadeOut: false, ShakeRandomnessMode.Harmonic));
		crateShakeSequence.Append(target.DOShakePosition(0.25f * num, 2.5f, 30, 90f, snapping: false, fadeOut: false, ShakeRandomnessMode.Harmonic));
		crateShakeSequence.Append(target.DOShakePosition(0.5f * num, 5f, 35, 90f, snapping: false, fadeOut: false, ShakeRandomnessMode.Harmonic));
		crateShakeSequence.OnComplete(BurstOpen);
	}

	public bool IsShakeAnimationPlaying()
	{
		return crateShakeSequence != null;
	}

	public void JumpToBurst()
	{
		BurstOpen(playSounds: false);
	}

	private void BurstOpen()
	{
		BurstOpen(playSounds: true);
	}

	private void BurstOpen(bool playSounds)
	{
		crateShakeSequence?.Kill();
		crateShakeSequence = null;
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		rewardIcon.enabled = true;
		tooltipEntity = rewardEntity;
		beamGlowParticles.enabled = true;
		crateExplosionParticles.enabled = true;
		rewardItemParticles.enabled = true;
		beamGlowParticles.Play();
		crateExplosionParticles.Play();
		rewardItemParticles.Play();
		rewardImageRegion.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		rewardScaleAnimation = rewardImageRegion.DOScale(Vector3.one, 0.5f);
		crateFadeAnimation = chestImage.DOFade(0f, 0.5f);
		if (playSounds)
		{
			SoundManager.PlayCrateBreak2();
			SoundManager.PlayRockSmash();
			if (rewardEntity.TryAsItem(out var i) && (i == ItemType.YellowCoin || i == ItemType.RedCoin || i == ItemType.BlueCoin || i == ItemType.PurpleCoin))
			{
				SoundManager.PlayCoinRattle();
			}
			else
			{
				SoundManager.PlayOpenLootBox();
			}
		}
		countLabel.enabled = true;
		textValueChangeAnimation.DisplayValue(0.0);
		textValueChangeAnimation.AnimateToValue(targetValue);
		RectTransform rectTransform = rewardImageRegion;
		rectTransform.localPosition = Vector3.zero;
		Sequence s = DOTween.Sequence();
		s.Append(rectTransform.DOLocalMoveY(35f, 0.3f).SetEase(Ease.OutQuad));
		s.Append(rectTransform.DOLocalMoveY(0f, 0.3f).SetEase(Ease.InQuad));
		s.Append(rectTransform.DOLocalMoveY(20f, 0.2f).SetEase(Ease.OutQuad));
		s.Append(rectTransform.DOLocalMoveY(0f, 0.2f).SetEase(Ease.InQuad));
		s.Append(rectTransform.DOLocalMoveY(6f, 0.1f).SetEase(Ease.OutQuad));
		s.Append(rectTransform.DOLocalMoveY(0f, 0.1f).SetEase(Ease.InQuad));
	}

	public void ResetAnimations()
	{
		bool complete = false;
		isManualClick = false;
		hasOpened = false;
		tooltipEntity = EntityId.None;
		crateFadeAnimation?.Kill(complete);
		chestImage.color = Color.clear;
		crateDropSequence?.Kill(complete);
		rewardScaleAnimation?.Kill(complete);
		crateShakeSequence?.Kill(complete);
		bounceAnimation?.Kill(complete);
		bounceSequence?.Kill(complete);
		crateFadeAnimation?.Kill(complete);
		beamGlowParticles.Stop();
		beamGlowParticles.Clear();
		crateExplosionParticles.Stop();
		crateExplosionParticles.Clear();
		rewardItemParticles.Stop();
		rewardItemParticles.Clear();
	}
}
