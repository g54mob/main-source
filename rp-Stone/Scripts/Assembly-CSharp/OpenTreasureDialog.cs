using System;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreasureDialog : ScrollBG
{
	private enum TreasureState
	{
		WaitingToOpen = 0,
		InitialDelay = 1,
		Opening = 2,
		RewardPopUpDelay = 3,
		RewardPopsUp = 4,
		RewardNameAndCount = 5,
		DelayBeforeAutoSkip = 6,
		WaitingForPress = 7
	}

	public int treasurePosX = 1;

	public int treasurePosY = 1;

	public int rewardX;

	public int rewardStartY = 1;

	public int rewardEndY = -3;

	public float rewardIconMoveLerp = 0.25f;

	public int anyKeyTicDelay = 20;

	public int anyKeyBlinkPeriod = 6;

	public AsciiAnimation openTreasureAnimationHumble;

	public AsciiAnimation openTreasureAnimationCommon;

	public AsciiAnimation openTreasureAnimationGiant;

	public AsciiAnimation openTreasureAnimationRare;

	public AsciiAnimation openTreasureAnimationEpic;

	public AsciiAnimation openTreasureAnimationBone;

	public AsciiAnimation openTreasureAnimationLost;

	public AsciiAnimation openTreasureAnimationKi;

	public AsciiAnimation openTreasureAnimationGold;

	public AsciiAnimation openTreasureAnimationSkullnata;

	public AsciiAnimation openTreasureAnimationEmerald;

	public AsciiAnimation openTreasureAnimationSapphire;

	public AsciiAnimation openTreasureAnimationRuby;

	public AsciiAnimation openTreasureAnimationPrismatic;

	public AsciiParticleEmitter fireworksEmitter;

	public AsciiAnimation openTreasureHalloweenHumble;

	public AsciiAnimation openTreasureHalloweenCommon;

	public AsciiAnimation openTreasureHalloweenGiant;

	public AsciiAnimation openTreasureHalloweenRare;

	public AsciiAnimation openTreasureHalloweenEpic;

	public AsciiAnimation openTreasureWinterHumble;

	public AsciiAnimation openTreasureWinterCommon;

	public AsciiAnimation openTreasureWinterGiant;

	public AsciiAnimation openTreasureWinterRare;

	public AsciiAnimation openTreasureWinterEpic;

	public AsciiAnimation openTreasureSpringHumble;

	public AsciiAnimation openTreasureSpringCommon;

	public AsciiAnimation openTreasureSpringGiant;

	public AsciiAnimation openTreasureSpringRare;

	public AsciiAnimation openTreasureSpringEpic;

	public AsciiAnimation openTreasureSummerHumble;

	public AsciiAnimation openTreasureSummerCommon;

	public AsciiAnimation openTreasureSummerGiant;

	public AsciiAnimation openTreasureSummerRare;

	public AsciiAnimation openTreasureSummerEpic;

	public AsciiAnimation openTreasurePoison;

	public AsciiAnimation openTreasureVigor;

	public AsciiAnimation openTreasureAether;

	public AsciiAnimation openTreasureFire;

	public AsciiAnimation openTreasureIce;

	public AsciiString title;

	private string _title;

	private string _subtitle;

	public AsciiString amountLabel;

	public AsciiString anyKeyLabel;

	public AsciiString lostCountBefore;

	public AsciiString lostCountAfter;

	public AsciiString signature;

	public AsciiString doubleKiLabel;

	public DialogButton stopButton;

	public DialogButton skipButton;

	public AsciiString skipCostLabel;

	private int skipCost;

	private AsciiSprite rewardIcon;

	private float f_rewardY;

	private int rewardY;

	private AsciiSprite shinyIcon;

	private TreasureState currentTreasureState;

	private int treasureStateElapsedTics;

	private int rewardIndex;

	private List<TreasureItem.Reward> rewardsToAdd;

	private AsciiAnimation openTreasureAnimation;

	private bool drawTreasureAfterItems;

	private Color initialTitleColor;

	private bool hasSkipped;

	private bool autoSkip;

	private ItemData.Rarity.Type currentRarity;

	private int currentRarityBonus;

	private bool currentIsCrystals;

	private bool currentIsShiny;

	private bool currentIsLostItem;

	private bool currentIsCosmetic;

	private bool hasPlayedLostSFX;

	private bool skipBuffered;

	private Sfx commonSfx;

	private float penaltyTime;

	private float lastTimeCheckedAutoClick;

	private int displayedAmount;

	private int targetAmount;

	private bool isDoubleKi;

	public TreasureItem treasure { get; private set; }

	public event Action OnStopOpenAll;

	public event Action OnSkipAll;

	public event Action OnComplete;

	public void Setup(TreasureItem treasure, bool autoSkip = false)
	{
		this.treasure = treasure;
		rewardIndex = -1;
		hasSkipped = false;
		this.autoSkip = autoSkip;
		rewardsToAdd = new List<TreasureItem.Reward>();
		openTreasureAnimation = GetTreasureAnimation();
		if (treasure.isSigned)
		{
			signature.SetValue(treasure.signature);
		}
		else
		{
			signature.Clear();
		}
		SetTreasureState(TreasureState.WaitingToOpen);
		if (!(skipButton != null))
		{
			return;
		}
		int count = Inventory.Singleton.GetTreasures().Count;
		if (autoSkip && count >= AdsWrapper.MIN_TREASURES_FOR_FAST_FORWARD)
		{
			skipButton.enabled = true;
			skipCost = count * AdsWrapper.PRICE_PER_TREASURE_FAST_FORWARD;
			skipCostLabel.SetValue("@" + Utils.FormatNumber(skipCost));
			skipCostLabel.color = ColorConstants.white;
			if (InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi) < skipCost)
			{
				skipCostLabel.color = ColorConstants.darkGrey;
			}
		}
		else
		{
			skipButton.enabled = false;
		}
		skipCostLabel.PositionX = skipButton.PositionX + skipButton.label.PositionX;
		skipCostLabel.PositionY = skipButton.PositionY + skipButton.label.PositionY + 1;
	}

	private AsciiAnimation GetTreasureAnimation()
	{
		if (treasure.type == TreasureItem.Type.Gold)
		{
			return openTreasureAnimationGold;
		}
		if (treasure.type == TreasureItem.Type.Skullnata)
		{
			return openTreasureAnimationSkullnata;
		}
		if (treasure.type == TreasureItem.Type.Emerald)
		{
			return openTreasureAnimationEmerald;
		}
		if (treasure.type == TreasureItem.Type.Sapphire)
		{
			return openTreasureAnimationSapphire;
		}
		if (treasure.type == TreasureItem.Type.Ruby)
		{
			return openTreasureAnimationRuby;
		}
		if (treasure.type == TreasureItem.Type.Prismatic)
		{
			return openTreasureAnimationPrismatic;
		}
		if (treasure.type == TreasureItem.Type.Element)
		{
			if (treasure.element == ItemData.Element.Poison)
			{
				return openTreasurePoison;
			}
			if (treasure.element == ItemData.Element.Vigor)
			{
				return openTreasureVigor;
			}
			if (treasure.element == ItemData.Element.AEther)
			{
				return openTreasureAether;
			}
			if (treasure.element == ItemData.Element.Fire)
			{
				return openTreasureFire;
			}
			if (treasure.element == ItemData.Element.Ice)
			{
				return openTreasureIce;
			}
		}
		if (treasure.type == TreasureItem.Type.Lost)
		{
			return openTreasureAnimationLost;
		}
		if (treasure.type == TreasureItem.Type.Ki)
		{
			return openTreasureAnimationKi;
		}
		if (EventController.singleton.CanPlayerSeeEvents() && Inventory.Singleton.HasItemById("moon_stone"))
		{
			if (EventController.singleton.IsEventActiveAndStarted("halloween"))
			{
				drawTreasureAfterItems = false;
				if (treasure.type == TreasureItem.Type.Humble)
				{
					return openTreasureHalloweenHumble;
				}
				if (treasure.type == TreasureItem.Type.Giant)
				{
					return openTreasureHalloweenGiant;
				}
				if (treasure.type == TreasureItem.Type.Rare)
				{
					return openTreasureHalloweenRare;
				}
				if (treasure.type == TreasureItem.Type.Epic)
				{
					return openTreasureHalloweenEpic;
				}
				if (treasure.type == TreasureItem.Type.Bone)
				{
					return openTreasureAnimationBone;
				}
				return openTreasureHalloweenCommon;
			}
			if (EventController.singleton.IsEventActiveAndStarted("winter"))
			{
				drawTreasureAfterItems = false;
				if (treasure.type == TreasureItem.Type.Humble)
				{
					return openTreasureWinterHumble;
				}
				if (treasure.type == TreasureItem.Type.Giant)
				{
					return openTreasureWinterGiant;
				}
				if (treasure.type == TreasureItem.Type.Rare)
				{
					return openTreasureWinterRare;
				}
				if (treasure.type == TreasureItem.Type.Epic)
				{
					return openTreasureWinterEpic;
				}
				if (treasure.type == TreasureItem.Type.Bone)
				{
					return openTreasureAnimationBone;
				}
				return openTreasureWinterCommon;
			}
			if (EventController.singleton.IsEventActiveAndStarted("spring"))
			{
				drawTreasureAfterItems = false;
				if (treasure.type == TreasureItem.Type.Humble)
				{
					return openTreasureSpringHumble;
				}
				if (treasure.type == TreasureItem.Type.Giant)
				{
					return openTreasureSpringGiant;
				}
				if (treasure.type == TreasureItem.Type.Rare)
				{
					return openTreasureSpringRare;
				}
				if (treasure.type == TreasureItem.Type.Epic)
				{
					return openTreasureSpringEpic;
				}
				if (treasure.type == TreasureItem.Type.Bone)
				{
					return openTreasureAnimationBone;
				}
				return openTreasureSpringCommon;
			}
			if (EventController.singleton.IsEventActiveAndStarted("summer"))
			{
				drawTreasureAfterItems = false;
				if (treasure.type == TreasureItem.Type.Humble)
				{
					return openTreasureSummerHumble;
				}
				if (treasure.type == TreasureItem.Type.Giant)
				{
					return openTreasureSummerGiant;
				}
				if (treasure.type == TreasureItem.Type.Rare)
				{
					return openTreasureSummerRare;
				}
				if (treasure.type == TreasureItem.Type.Epic)
				{
					return openTreasureSummerEpic;
				}
				if (treasure.type == TreasureItem.Type.Bone)
				{
					return openTreasureAnimationBone;
				}
				return openTreasureSummerCommon;
			}
		}
		drawTreasureAfterItems = true;
		AsciiAnimation asciiAnimation = openTreasureAnimationCommon;
		if (treasure.type == TreasureItem.Type.Humble)
		{
			asciiAnimation = openTreasureAnimationHumble;
		}
		else if (treasure.type == TreasureItem.Type.Giant)
		{
			asciiAnimation = openTreasureAnimationGiant;
		}
		else if (treasure.type == TreasureItem.Type.Rare)
		{
			asciiAnimation = openTreasureAnimationRare;
		}
		else if (treasure.type == TreasureItem.Type.Epic)
		{
			asciiAnimation = openTreasureAnimationEpic;
		}
		else if (treasure.type == TreasureItem.Type.Bone)
		{
			asciiAnimation = openTreasureAnimationBone;
		}
		ItemData.Rarity.Type type = TreasureItem.FindBestRarityInItems(treasure.itemsInTreasure);
		asciiAnimation.Sprite.colorOverride = ItemData.Rarity.GetColorForRarity(type);
		return asciiAnimation;
	}

	public void Show()
	{
		SfxController.singleton.Play("treasure_close");
		SetState(State.In);
	}

	public void Hide()
	{
		SetState(State.Out);
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		switch (newState)
		{
		case State.Idle:
			SetTreasureState(TreasureState.InitialDelay);
			break;
		case State.Out:
			SfxController.singleton.Play("treasure_close");
			break;
		}
	}

	private void SetTreasureState(TreasureState newState)
	{
		switch (newState)
		{
		case TreasureState.WaitingToOpen:
			openTreasureAnimation.Stop();
			openTreasureAnimation.Sprite.SetFrameIndex(0);
			break;
		case TreasureState.Opening:
			if (treasure.type != TreasureItem.Type.Skullnata)
			{
				openTreasureAnimation.Play();
				if (treasure.type == TreasureItem.Type.Emerald || treasure.type == TreasureItem.Type.Sapphire || treasure.type == TreasureItem.Type.Ruby)
				{
					SfxController.singleton.Play("metal_drop", ignoreDuplicateSfxInSameFrame: true, 1.47f);
				}
				else
				{
					SfxController.singleton.Play("treasure_open", ignoreDuplicateSfxInSameFrame: true, 0.35f);
				}
			}
			break;
		case TreasureState.RewardPopsUp:
			SfxController.singleton.Play("treasure_item_pop");
			break;
		case TreasureState.RewardPopUpDelay:
			if (treasure.type == TreasureItem.Type.Skullnata)
			{
				openTreasureAnimation.Stop();
				openTreasureAnimation.Play();
				SfxController.singleton.Play("treasure_drop");
			}
			break;
		}
		currentTreasureState = newState;
		treasureStateElapsedTics = 0;
		skipBuffered = false;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		UpdateAutoClickPrevention();
		if (autoSkip)
		{
			stopButton.UpdateTic();
			if (skipButton != null && skipButton.enabled)
			{
				skipButton.UpdateTic();
			}
		}
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		treasureStateElapsedTics++;
		if ((autoSkip || (InputToSkip() && EnsureNotAutoClicking())) && IsSkippableState(currentTreasureState))
		{
			if (!autoSkip && (currentTreasureState == TreasureState.WaitingToOpen || currentTreasureState == TreasureState.InitialDelay))
			{
				SetTreasureState(TreasureState.Opening);
				return;
			}
			Skip();
			JumpAmountLabelToFinalValue();
			return;
		}
		if (currentTreasureState == TreasureState.InitialDelay && treasureStateElapsedTics >= 10)
		{
			SetTreasureState(TreasureState.Opening);
		}
		else if (currentTreasureState == TreasureState.Opening && (treasure.type == TreasureItem.Type.Emerald || treasure.type == TreasureItem.Type.Sapphire || treasure.type == TreasureItem.Type.Ruby))
		{
			if (treasureStateElapsedTics >= 60)
			{
				NextReward();
			}
		}
		else if (currentTreasureState == TreasureState.Opening && treasureStateElapsedTics >= 20)
		{
			NextReward();
		}
		else if (currentTreasureState == TreasureState.RewardPopUpDelay)
		{
			if (currentIsLostItem && treasureStateElapsedTics == 10)
			{
				hasPlayedLostSFX = true;
				PlaySoundForceVolume("treasure_item_lost");
			}
			else if (treasureStateElapsedTics >= 20)
			{
				SetTreasureState(TreasureState.RewardPopsUp);
			}
		}
		else if (currentTreasureState == TreasureState.RewardPopsUp && treasureStateElapsedTics >= 15)
		{
			SetTreasureState(TreasureState.RewardNameAndCount);
		}
		else if (currentTreasureState == TreasureState.RewardNameAndCount && treasureStateElapsedTics >= 10)
		{
			SetTreasureState(TreasureState.WaitingForPress);
		}
		else if (currentTreasureState == TreasureState.DelayBeforeAutoSkip && treasureStateElapsedTics >= 8)
		{
			NextReward();
		}
		else if (currentTreasureState == TreasureState.RewardNameAndCount || currentTreasureState == TreasureState.WaitingForPress)
		{
			UpdateAmountLabel();
		}
		if (currentTreasureState < TreasureState.RewardPopsUp || rewardY == rewardEndY)
		{
			return;
		}
		f_rewardY = Mathf.Lerp(f_rewardY, rewardEndY, rewardIconMoveLerp);
		rewardY = Mathf.RoundToInt(f_rewardY);
		if (rewardY != rewardEndY)
		{
			return;
		}
		EmitFireworks();
		if (commonSfx != null)
		{
			commonSfx.Stop();
		}
		if (currentIsLostItem)
		{
			if (!hasPlayedLostSFX)
			{
				PlaySoundForceVolume("treasure_item_lost");
			}
		}
		else if (currentRarity == ItemData.Rarity.Type.Common)
		{
			commonSfx = SfxController.singleton.Play("treasure_item_show");
		}
		else if (currentRarity == ItemData.Rarity.Type.Uncommon)
		{
			SfxController.singleton.Play("treasure_item_cyan");
		}
		else if (currentRarity == ItemData.Rarity.Type.Rare)
		{
			SfxController.singleton.Play("treasure_item_yellow");
		}
		else if (currentRarity == ItemData.Rarity.Type.Heroic)
		{
			SfxController.singleton.Play("treasure_item_green");
		}
		else if (currentRarity == ItemData.Rarity.Type.Epic)
		{
			SfxController.singleton.Play("treasure_item_blue");
		}
		else if (currentRarity == ItemData.Rarity.Type.Legendary)
		{
			SfxController.singleton.Play("treasure_item_red");
		}
		else if (currentRarity == ItemData.Rarity.Type.Transcendent)
		{
			SfxController.singleton.Play("treasure_item_rainbow");
		}
	}

	private void PlaySoundForceVolume(string soundId)
	{
		SfxController.singleton.Play(soundId);
	}

	private bool InputToSkip()
	{
		if (skipBuffered)
		{
			skipBuffered = false;
			return true;
		}
		return AsciiMouse.singleton.up0;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			skipBuffered = true;
		}
	}

	private bool IsSkippableState(TreasureState whichState)
	{
		if ((currentIsCrystals || currentIsShiny || currentIsLostItem || !IsSkippableRarity()) && (whichState == TreasureState.InitialDelay || whichState == TreasureState.RewardPopUpDelay || whichState == TreasureState.RewardPopsUp))
		{
			return false;
		}
		if (whichState != TreasureState.InitialDelay && whichState != TreasureState.RewardPopUpDelay && whichState != TreasureState.RewardPopsUp)
		{
			return whichState == TreasureState.WaitingForPress;
		}
		return true;
	}

	private bool IsSkippableRarity()
	{
		if (currentRarity != ItemData.Rarity.Type.Common)
		{
			return currentRarityBonus <= Inventory.Singleton.GetBestRarityBonus();
		}
		return true;
	}

	private void UpdateAutoClickPrevention()
	{
		penaltyTime -= 0.033333f;
		if (penaltyTime < 0f)
		{
			penaltyTime = 0f;
		}
	}

	private bool EnsureNotAutoClicking()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		float num = realtimeSinceStartup - lastTimeCheckedAutoClick;
		lastTimeCheckedAutoClick = realtimeSinceStartup;
		if (num < 0.4f)
		{
			penaltyTime += 0.5f;
		}
		if (penaltyTime > 1.5f)
		{
			penaltyTime = 1.5f;
		}
		if (penaltyTime > 0.2f && !IsSkippableState(currentTreasureState))
		{
			return false;
		}
		return true;
	}

	private void NextReward()
	{
		rewardIndex++;
		hasSkipped = false;
		if (rewardIndex >= treasure.itemsInTreasure.Length)
		{
			SetTreasureState(TreasureState.WaitingForPress);
			return;
		}
		TreasureItem.Reward reward = treasure.MakeRewardAt(rewardIndex);
		rewardsToAdd.Add(reward);
		if (reward.isKiCrystal)
		{
			currentIsCrystals = true;
			currentRarity = ItemData.Rarity.Type.Transcendent;
		}
		else
		{
			currentIsCrystals = false;
			currentRarity = reward.item.GetRarityType();
		}
		currentRarityBonus = reward.item.GetRarityBonus();
		isDoubleKi = reward.isDoubleKi;
		currentIsShiny = reward.item.isShiny;
		currentIsLostItem = reward.item.isLost;
		currentIsCosmetic = reward.item is Cosmetic;
		hasPlayedLostSFX = false;
		if (currentIsLostItem)
		{
			Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId(reward.item.id);
			if (firstItemWithId != null)
			{
				int lostCount = firstItemWithId.lostCount;
				int nextLostCountGoal = firstItemWithId.GetNextLostCountGoal();
				lostCountBefore.SetValue("[" + lostCount + "/" + nextLostCountGoal + "]");
				lostCount++;
				lostCountAfter.SetValue("[" + lostCount + "/" + nextLostCountGoal + "]");
			}
			else
			{
				lostCountBefore.Clear();
				lostCountAfter.Clear();
			}
		}
		if (currentIsCosmetic)
		{
			Cosmetic cosmetic = reward.item as Cosmetic;
			if (cosmetic != null && cosmetic.IsFinalCollectionItem())
			{
				currentRarity = ItemData.Rarity.Type.Transcendent;
			}
		}
		string text = reward.item.GetName();
		if (reward.item.level >= 1 && reward.item.showLevelInTitle && !reward.item.isLost)
		{
			string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(reward.item);
			text = starRatingStringForItem + " " + text + " " + starRatingStringForItem;
		}
		string[] array = Utils.BreakIntoLines(text, Width - 2);
		if (array.Length >= 2)
		{
			_title = array[0];
			_subtitle = array[1];
		}
		else
		{
			title.SetValue(text);
			_subtitle = null;
		}
		title.color = initialTitleColor * reward.item.GetLabelColor();
		rewardIcon = reward.item.GetIcon();
		SetupAmountLabel(reward.count);
		f_rewardY = rewardStartY;
		rewardY = rewardStartY;
		SetTreasureState(TreasureState.RewardPopUpDelay);
	}

	private void SetupAmountLabel(int amount)
	{
		amountLabel.Clear();
		displayedAmount = 0;
		targetAmount = amount;
	}

	private void UpdateAmountLabel()
	{
		if (displayedAmount < targetAmount && (targetAmount > 9 || displayedAmount <= 0 || treasureStateElapsedTics % 3 >= 2))
		{
			int a = targetAmount / 10;
			a = Mathf.Max(a, 1);
			displayedAmount += a;
			displayedAmount = Mathf.Min(targetAmount, displayedAmount);
			amountLabel.SetValue("x" + displayedAmount);
		}
	}

	private void JumpAmountLabelToFinalValue()
	{
		displayedAmount = targetAmount;
		amountLabel.SetValue("x" + displayedAmount);
	}

	private void Skip()
	{
		hasSkipped = true;
		if (currentTreasureState == TreasureState.InitialDelay || currentTreasureState == TreasureState.Opening)
		{
			openTreasureAnimation.Sprite.SetFrameIndex(openTreasureAnimation.Sprite.FrameCount - 1);
			openTreasureAnimation.Stop();
			NextReward();
			SetTreasureState(TreasureState.DelayBeforeAutoSkip);
		}
		else if (currentTreasureState == TreasureState.RewardPopUpDelay || currentTreasureState == TreasureState.RewardPopsUp || currentTreasureState == TreasureState.RewardNameAndCount)
		{
			SetTreasureState(TreasureState.DelayBeforeAutoSkip);
		}
		else if (currentTreasureState == TreasureState.DelayBeforeAutoSkip)
		{
			if (rewardIndex + 1 < treasure.itemsInTreasure.Length)
			{
				NextReward();
				SetTreasureState(TreasureState.DelayBeforeAutoSkip);
			}
			else
			{
				CompleteTransactionAndHide();
			}
		}
		else if (currentTreasureState == TreasureState.WaitingForPress && (!currentIsLostItem || treasureStateElapsedTics >= 35))
		{
			if (rewardIndex + 1 < treasure.itemsInTreasure.Length)
			{
				SfxController.singleton.Play("click");
				NextReward();
			}
			else
			{
				CompleteTransactionAndHide();
			}
		}
	}

	private void CompleteTransactionAndHide()
	{
		treasure.GrantRewards(rewardsToAdd);
		commonSfx = null;
		Hide();
		this.OnComplete?.Invoke();
	}

	private void EmitFireworks()
	{
		Transform obj = fireworksEmitter.transform;
		Vector3 position = obj.position;
		position.x = (float)(openTreasureAnimation.Sprite.lastDrawX + openTreasureAnimation.Sprite.pivotX) + 0.5f;
		position.y = (float)(openTreasureAnimation.Sprite.lastDrawY + openTreasureAnimation.Sprite.pivotY) - 3.5f;
		obj.position = position;
		fireworksEmitter.Emit();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (scaleX >= 0.1f)
		{
			if (scaleX < 0.95f)
			{
				int num = (int)((float)Width * scaleX);
				int num2 = offsetX + PositionX + (Width - num) / 2;
				AsciiRenderProcedural.Clip c = new AsciiRenderProcedural.Clip
				{
					left = num2,
					right = num2
				};
				r.PushClip(c);
			}
			if (!drawTreasureAfterItems && openTreasureAnimation != null)
			{
				openTreasureAnimation.Sprite.Draw(r, offsetX + treasurePosX, offsetY + treasurePosY);
			}
			if (currentTreasureState == TreasureState.RewardPopsUp || currentTreasureState == TreasureState.RewardNameAndCount || currentTreasureState == TreasureState.DelayBeforeAutoSkip || currentTreasureState == TreasureState.WaitingForPress)
			{
				if (currentIsLostItem && currentTreasureState != TreasureState.RewardPopsUp)
				{
					IconLoader.Singleton.lostItemLaurels.Draw(r, offsetX + rewardX, offsetY + rewardY);
				}
				if (treasure.type == TreasureItem.Type.Skullnata)
				{
					offsetY--;
				}
				if (rewardIcon != null)
				{
					rewardIcon.Draw(r, offsetX + rewardX, offsetY + rewardY);
				}
				if (treasure.type == TreasureItem.Type.Skullnata)
				{
					offsetY++;
				}
				if (currentIsShiny)
				{
					if (shinyIcon == null)
					{
						shinyIcon = IconLoader.Singleton.GetSharedIcon("Relics/Shiny/shiny_icon");
					}
					if (shinyIcon != null)
					{
						shinyIcon.Draw(r, offsetX + rewardX, offsetY + rewardY);
					}
				}
			}
			signature.Draw(r, offsetX, offsetY);
			if (currentTreasureState == TreasureState.RewardNameAndCount || currentTreasureState == TreasureState.DelayBeforeAutoSkip || currentTreasureState == TreasureState.WaitingForPress || hasSkipped)
			{
				if (_subtitle == null)
				{
					title.Draw(r, offsetX, offsetY);
				}
				else
				{
					title.SetValue(_title);
					title.Draw(r, offsetX, offsetY - 1);
					title.SetValue(_subtitle);
					title.Draw(r, offsetX, offsetY);
				}
				if (treasure.type == TreasureItem.Type.Skullnata)
				{
					offsetY--;
				}
				if (!currentIsShiny && !currentIsLostItem && !currentIsCosmetic)
				{
					amountLabel.Draw(r, offsetX, offsetY);
					if (isDoubleKi)
					{
						doubleKiLabel.Draw(r, offsetX + amountLabel.Length, offsetY);
					}
				}
				if (currentIsLostItem && lostCountBefore.Length > 0)
				{
					if (currentTreasureState < TreasureState.WaitingForPress || treasureStateElapsedTics < 13)
					{
						lostCountBefore.Draw(r, offsetX, offsetY);
					}
					else
					{
						int num3 = treasureStateElapsedTics - 13;
						if (num3 <= 22)
						{
							float value = (float)(num3 - 5) / 17f;
							value = Mathf.Clamp01(value);
							Color colorOverride = Color.Lerp(ColorConstants.white, ColorConstants.lightGrey, value);
							Color backgroundColor = Color.Lerp(ColorConstants.white * 0.99f, ColorConstants.black, value);
							lostCountAfter.backgroundColor = backgroundColor;
							lostCountAfter.Draw(r, offsetX, offsetY, colorOverride);
						}
						else
						{
							lostCountAfter.Draw(r, offsetX, offsetY);
						}
					}
				}
				if (treasure.type == TreasureItem.Type.Skullnata)
				{
					offsetY++;
				}
			}
			if (drawTreasureAfterItems && openTreasureAnimation != null)
			{
				openTreasureAnimation.Sprite.Draw(r, offsetX + treasurePosX, offsetY + treasurePosY);
			}
			if (currentTreasureState == TreasureState.WaitingForPress && treasureStateElapsedTics >= anyKeyTicDelay && (treasureStateElapsedTics - anyKeyTicDelay) % anyKeyBlinkPeriod < anyKeyBlinkPeriod / 2)
			{
				anyKeyLabel.Draw(r, offsetX, offsetY);
			}
			if (scaleX < 0.95f)
			{
				r.PopClip();
			}
		}
		if (autoSkip && (!AsciiMouse.singleton.IsHidden() || SubscriptionController.singleton.HasSubscription(SubscriptionController.EVENTS_SUBSCRIPTION_ID)))
		{
			stopButton.Draw(r, r.width, r.height);
			if (skipButton != null && skipButton.enabled)
			{
				int offsetX2 = (r.width - skipButton.Width) / 2;
				int offsetY2 = r.height - skipButton.Height;
				skipButton.Draw(r, offsetX2, offsetY2);
				skipCostLabel.Draw(r, offsetX2, offsetY2);
			}
		}
	}

	private void HandleStopButtonPressed(DialogButton btn)
	{
		autoSkip = false;
		if (this.OnStopOpenAll != null)
		{
			this.OnStopOpenAll();
		}
	}

	private void HandleSkipButtonPressed(DialogButton btn)
	{
		if (InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi) >= skipCost)
		{
			InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Xi, skipCost);
			skipButton.enabled = false;
			if (this.OnSkipAll != null)
			{
				this.OnSkipAll();
			}
		}
	}

	private void HandleParticleEmitted(AsciiParticle[] particles)
	{
		if (currentRarity == ItemData.Rarity.Type.Transcendent)
		{
			for (int i = 0; i < particles.Length; i++)
			{
				AsciiParticle asciiParticle = particles[i];
				if ((bool)asciiParticle && asciiParticle.colorProgression.Length != 0)
				{
					Color a = Color.HSVToRGB(Mathf.Repeat((float)i / 7f, 1f), 1f, 1f);
					asciiParticle.colorProgression[0] = Color.Lerp(a, Color.white, 0.6f);
				}
			}
			return;
		}
		Color colorForRarity = ItemData.Rarity.GetColorForRarity(currentRarity);
		foreach (AsciiParticle asciiParticle2 in particles)
		{
			if (asciiParticle2.colorProgression.Length != 0)
			{
				asciiParticle2.colorProgression[0] = colorForRarity;
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		openTreasureAnimationHumble.Sprite.Load();
		openTreasureAnimationCommon.Sprite.Load();
		openTreasureAnimationGiant.Sprite.Load();
		openTreasureAnimationRare.Sprite.Load();
		openTreasureAnimationEpic.Sprite.Load();
		openTreasureAnimationBone.Sprite.Load();
		openTreasureAnimationLost.Sprite.Load();
		initialTitleColor = title.color;
		stopButton.OnPressed += HandleStopButtonPressed;
		if (skipButton != null)
		{
			skipButton.OnPressed += HandleSkipButtonPressed;
		}
		fireworksEmitter.OnParticlesEmitted += HandleParticleEmitted;
	}
}
