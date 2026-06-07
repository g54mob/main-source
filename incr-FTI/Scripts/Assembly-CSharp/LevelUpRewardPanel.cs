using System;
using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpRewardPanel : MenuPanel
{
	public GameObject rewardItemPrefab;

	public TextMeshProUGUI levelUpLabel;

	public TextMeshProUGUI levelNumberLabel;

	public UIParticle levelUpParticles;

	public UIParticle levelUpNumberGlow;

	public LayoutGroup rewardLayoutGroup;

	public LabelButton actionButton;

	public Transform rewardBackground;

	[NonSerialized]
	public int startLevel;

	[NonSerialized]
	public int levelToDisplay;

	private bool hasInitialized;

	private readonly Dictionary<EntityId, double> rewards = new Dictionary<EntityId, double>();

	public List<RewardItem> rewardItems;

	private bool hasClaimedReward;

	public Ease crateEase;

	public CustomAnimation textRevealAnimation;

	public Tween levelUpTextPunchAnimation;

	public Tween levelUpNumberShrinkAnimation;

	public Tween levelUpNumberShake;

	public Tween levelUpNumberPunchAnimation;

	private Tween rewardBackgroundAnimation;

	protected override void Awake()
	{
		base.Awake();
		Initialize();
	}

	public void AddReward(EntityId id, double value)
	{
		if (rewards.TryGetValue(id, out var value2))
		{
			rewards[id] = value2 + value;
		}
		else
		{
			rewards[id] = value;
		}
	}

	public void Debug()
	{
		ResetRewards();
		levelToDisplay = 17;
		AddReward(EntityId.FromItem(ItemType.UtilityPrestigePoint), 5.0);
		AddReward(EntityId.FromItem(ItemType.YellowCoin), 2500.0);
		AddReward(EntityId.FromItem(ItemType.UtilityQuestCoin), 17.0);
		AddReward(EntityId.FromNaturalResource(NaturalResource.CottonPlant), 0.0);
		DisplayReward();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		UpdateActionLabel();
	}

	public override void Initialize()
	{
		if (!hasInitialized)
		{
			hasInitialized = true;
			actionButton.AddPointerClickTrigger(OnActionButtonPressed);
			textRevealAnimation = new CustomAnimation(0f, 1f, 0.5f, Ease.InQuad);
			base.Initialize();
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		foreach (RewardItem rewardItem in rewardItems)
		{
			if (rewardItem.gameObject.activeInHierarchy)
			{
				rewardItem.UpdateDynamicDisplay();
			}
		}
		textRevealAnimation.UpdateAnimation();
		levelUpLabel.maxVisibleCharacters = Mathf.CeilToInt(textRevealAnimation.EasedValue() * (float)levelUpLabel.text.Length);
		if (!hasClaimedReward)
		{
			CheckForManualOpenState();
		}
	}

	private void CheckForManualOpenState()
	{
		bool flag = false;
		foreach (RewardItem rewardItem in rewardItems)
		{
			if (rewardItem.gameObject.activeInHierarchy)
			{
				flag = true;
				if (!rewardItem.hasOpened)
				{
					return;
				}
			}
		}
		if (flag)
		{
			hasClaimedReward = true;
			UpdateActionLabel();
		}
	}

	public void ResetRewards()
	{
		hasClaimedReward = false;
		levelUpParticles.Clear();
		rewards.Clear();
		levelUpNumberGlow.Stop();
		levelUpNumberGlow.Clear();
		levelUpNumberGlow.enabled = false;
		levelNumberLabel.transform.localScale = Vector3.one;
		foreach (RewardItem rewardItem in rewardItems)
		{
			rewardItem.ResetAnimations();
			rewardItem.gameObject.SetActive(value: false);
		}
		UpdateActionLabel();
	}

	public void DisplayReward()
	{
		Show();
		SoundManager.PlayLevelUp();
		SoundManager.PlayBigImpact();
		levelUpLabel.text = "LevelUpExclamation".Localized();
		levelNumberLabel.text = TextDisplay.LocalizedNumber(startLevel);
		textRevealAnimation.Run();
		levelUpNumberGlow.enabled = true;
		levelUpNumberGlow.Play();
		rewardBackgroundAnimation?.Kill(complete: true);
		levelUpNumberShake?.Kill(complete: true);
		levelUpTextPunchAnimation?.Kill(complete: true);
		levelUpNumberPunchAnimation?.Kill(complete: true);
		levelUpNumberShrinkAnimation?.Kill();
		levelUpTextPunchAnimation = levelUpLabel.transform.DOPunchScale(new Vector3(0.25f, 0.25f, 0.25f), 0.5f, 0, 0.5f);
		levelUpNumberShrinkAnimation = levelNumberLabel.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.75f).SetEase(Ease.OutCubic).OnComplete(PlayLevelNumberPunch);
		levelUpNumberShake = levelNumberLabel.transform.DOShakePosition(0.75f, 10f, 40);
		rewardBackground.localScale = new Vector3(0f, 1f, 1f);
		rewardBackgroundAnimation = rewardBackground.DOScale(Vector3.one, 1f).SetEase(Ease.OutCubic);
		levelUpParticles.enabled = false;
		levelUpParticles.Clear();
		while (rewardItems.Count < rewards.Count)
		{
			RewardItem component = MenuManager.GetMenuObject(rewardItemPrefab, rewardLayoutGroup.transform).GetComponent<RewardItem>();
			component.Initialize();
			component.parentPanel = this;
			component.ResetAnimations();
			rewardItems.Add(component);
		}
		int num = 0;
		foreach (KeyValuePair<EntityId, double> reward in rewards)
		{
			RewardItem rewardItem = rewardItems[num];
			rewardItem.LoadReward(reward.Key, reward.Value);
			rewardItem.gameObject.SetActive(value: true);
			rewardItem.PrepareForNewAnimation();
			rewardItem.revealCountdown = (float)(num + 1) * 0.15f;
			num++;
		}
	}

	private void PlayLevelNumberPunch()
	{
		PlayNumberExplosion();
		levelNumberLabel.text = TextDisplay.LocalizedNumber(levelToDisplay);
		levelNumberLabel.transform.localScale = Vector3.one;
		levelUpNumberPunchAnimation = levelNumberLabel.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f, 0, 0.5f);
	}

	private void PlayNumberExplosion()
	{
		levelUpParticles.enabled = true;
		levelUpParticles.Play();
		SoundManager.PlayOpenLootBox();
	}

	public void OnBackgroundClick()
	{
		OnActionButtonPressed();
	}

	private void OnActionButtonPressed()
	{
		if (hasClaimedReward)
		{
			bool flag = false;
			foreach (RewardItem rewardItem in rewardItems)
			{
				if (rewardItem.gameObject.activeInHierarchy && rewardItem.IsShakeAnimationPlaying())
				{
					rewardItem.JumpToBurst();
					flag = true;
				}
			}
			if (flag)
			{
				SoundManager.PlayCoinRattle();
				SoundManager.PlayCrateBreak2();
				SoundManager.PlayRockSmash();
			}
			else
			{
				Hide();
			}
			return;
		}
		hasClaimedReward = true;
		UpdateActionLabel();
		SoundManager.PlayCrateBreak1();
		foreach (RewardItem rewardItem2 in rewardItems)
		{
			rewardItem2.Claim();
		}
	}

	private void UpdateActionLabel()
	{
		if (hasClaimedReward)
		{
			actionButton.buttonState = CustomButtonState.Default;
			if (LocalizationManager.IsEnglish())
			{
				actionButton.label.text = "Close";
			}
			else
			{
				actionButton.label.text = "OK".Localized();
			}
		}
		else
		{
			actionButton.buttonState = CustomButtonState.HighlightFlashing;
			actionButton.label.text = "ClaimAll".Localized();
		}
	}

	public override void Hide()
	{
		if (IsVisible() && GameManager.GameState == GameState.InGame)
		{
			SoundManager.PlayMenuClose();
		}
		base.Hide();
		bool complete = false;
		rewardBackgroundAnimation?.Kill(complete);
		levelUpNumberShake?.Kill(complete);
		levelUpTextPunchAnimation?.Kill(complete);
		levelUpNumberPunchAnimation?.Kill(complete);
		levelUpNumberShrinkAnimation?.Kill(complete);
		ResetRewards();
	}
}
