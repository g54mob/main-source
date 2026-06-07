using System.Collections.Generic;
using DG.Tweening;
using FullSerializer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePanelWood : MinigamePanel
{
	private float axeProgress;

	private int axeDirection;

	private float axeSpeed;

	public Image axeImage;

	public RectTransform axeTransform;

	public Image stumpImage;

	public RectTransform stumpTransform;

	public RectTransform greatRegionTransform;

	public RectTransform perfectRegionTransform;

	public RectTransform axeTarget;

	public LabelButton chopButton;

	public TextMeshProUGUI evaluationLabel;

	public TextMeshProUGUI roundRewardLabel;

	public TextMeshProUGUI multiplierTitleLabel;

	public TextMeshProUGUI multiplierValueLabel;

	public TextMeshProUGUI swingsTitleLabel;

	public TextMeshProUGUI swingsValueLabel;

	public TextMeshProUGUI hitsTitleLabel;

	public TextMeshProUGUI hitsValueLabel;

	public Image roundRewardIcon;

	public int numHits;

	public int numSwings;

	public float roundMultiplier;

	public float axeOriginY;

	private TextValueChangeAnimation roundRewardAnimation;

	private float stumpWidth;

	private float greatWidth;

	private float perfectWidth;

	public int roundNum;

	private const int maxRound = 5;

	private const float axeRange = 250f;

	private const float roundIntermission = 1f;

	public float roundDisplayCounter;

	private readonly List<MinigameEvaluation> roundResults = new List<MinigameEvaluation>();

	private bool isAxeMoving => axeDirection != 0;

	public override void CreateItems()
	{
		axeOriginY = axeTransform.position.y;
		roundRewardAnimation = new TextValueChangeAnimation(roundRewardLabel);
		chopButton.AddPointerDownTrigger(OnChopPressed);
		levelStat = MenuPanel.gm.minigameWood;
		energyTracker = MenuPanel.gm.energyWood;
		rewardEntities.AddItem(ItemType.Wood, 3.0);
		base.CreateItems();
	}

	protected override void LoadNewMinigame()
	{
		base.LoadNewMinigame();
		ResetEvaluation();
		chopButton.gameObject.SetActive(value: true);
		roundRewardIcon.sprite = IconManager.SpriteForItem(rewardItem);
		TryStartRound();
	}

	private void UpdateRoundStats()
	{
		TextDisplay.SetFraction(swingsValueLabel, numSwings, 5.0);
		TextDisplay.SetFraction(hitsValueLabel, numHits, 5.0);
		multiplierValueLabel.text = TextDisplay.Multiplier + TextDisplay.LocalizedNumber(roundMultiplier);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		multiplierTitleLabel.text = "Multiplier".Localized();
		swingsTitleLabel.text = "Swings".Localized();
		hitsTitleLabel.text = "Hits".Localized();
		chopButton.label.text = "Chop".Localized();
		UpdateChopButtonCaption();
	}

	private void UpdateChopButtonCaption()
	{
		chopButton.label.text = "Chop".Localized();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		roundRewardAnimation.UpdateAnimation();
		if (minigameState != MinigameState.Running)
		{
			return;
		}
		if (isAxeMoving)
		{
			axeProgress += TimeManager.MenuDelta * (float)axeDirection;
			if (axeProgress > 1f)
			{
				float num = axeProgress - 1f;
				axeProgress = 1f - num;
				axeDirection = -1;
			}
			else if (axeProgress < 0f)
			{
				axeProgress *= -1f;
				axeDirection = 1;
			}
			UpdateAxePosition();
		}
		else if (roundNum > 0)
		{
			roundDisplayCounter += TimeManager.MenuDelta;
			if (roundDisplayCounter >= 1f)
			{
				TryStartRound();
			}
		}
	}

	private void UpdateAxePosition()
	{
		float x = DOVirtual.EasedValue(-250f, 250f, axeProgress, Ease.InOutSine);
		axeTransform.SetPosX(x);
	}

	public override void ResetMinigame()
	{
		base.ResetMinigame();
		roundNum = 0;
		axeDirection = 0;
		chopButton.buttonState = CustomButtonState.Default;
		chopButton.gameObject.SetActive(value: false);
		roundDisplayCounter = 0f;
		roundResults.Clear();
		ResetEvaluation();
		numHits = 0;
		axeImage.enabled = false;
		numSwings = 0;
		rewardAmount = 0.0;
		UpdateAxePosition();
		UpdateChopButtonCaption();
		UpdateRoundStats();
	}

	private void ResetEvaluation()
	{
		evaluationLabel.enabled = false;
		roundRewardLabel.enabled = false;
		roundRewardIcon.enabled = false;
		roundRewardAnimation?.DisplayValue(0.0);
	}

	private void OnChopPressed()
	{
		if (chopButton.shouldIgnoreAction)
		{
			return;
		}
		if (axeDirection == 0)
		{
			TryStartRound();
			return;
		}
		axeDirection = 0;
		float x = axeTransform.anchoredPosition.x;
		float x2 = stumpTransform.anchoredPosition.x;
		float num = Mathf.Abs(x - x2);
		_ = stumpWidth;
		_ = stumpWidth;
		if (num < perfectWidth * 0.5f)
		{
			ApplyEvaluation(MinigameEvaluation.Perfect);
		}
		else if (num < greatWidth * 0.5f)
		{
			ApplyEvaluation(MinigameEvaluation.Great);
		}
		else if (num < stumpWidth * 0.5f)
		{
			ApplyEvaluation(MinigameEvaluation.Good);
		}
		else
		{
			ApplyEvaluation(MinigameEvaluation.Miss);
		}
		chopButton.buttonState = CustomButtonState.Disabled;
		axeTransform.DOMove(axeTarget.position, 0.1f);
		if (roundNum >= 5)
		{
			DeclareVictory();
		}
	}

	protected override void CalcReward()
	{
		base.CalcReward();
	}

	private void ApplyEvaluation(MinigameEvaluation e)
	{
		evaluationLabel.text = TextDisplay.LabelForEvaluation(e);
		evaluationLabel.enabled = true;
		float num;
		float duration;
		float num2;
		switch (e)
		{
		case MinigameEvaluation.Perfect:
			evaluationLabel.color = Color.magenta;
			num = 1f;
			duration = 0.7f;
			num2 = 10f;
			break;
		case MinigameEvaluation.Great:
			evaluationLabel.color = Color.green;
			num = 0.6f;
			duration = 0.5f;
			num2 = 5f;
			break;
		case MinigameEvaluation.Good:
			evaluationLabel.color = Color.blue;
			num = 0.4f;
			duration = 0.4f;
			num2 = 2f;
			break;
		default:
			evaluationLabel.color = Color.white;
			num = 0.1f;
			duration = 0.7f;
			num2 = 0f;
			break;
		}
		if (num2 > 0f)
		{
			num2 *= GameManager.Instance.MultiplierForGlobalPerk(PerkType.MinigameXPGainSpeed);
			AnimateToExperience(stumpTransform, levelStat.iconItem, num2);
		}
		evaluationLabel.transform.DOPunchRotation(Vector3.one, 1f);
		evaluationLabel.transform.DOPunchScale(new Vector3(num, num, 0f), duration, 0, 0f);
		roundRewardLabel.enabled = true;
		roundRewardIcon.enabled = true;
		roundResults.Add(e);
		float num3 = RewardForEvaluation(e) * roundMultiplier;
		if (num3 > 0f)
		{
			rewardAmount += num3;
			roundRewardAnimation.AnimateToValue(num3);
			EarnReward(num3);
			AnimateItemGain(stumpTransform, num3);
		}
		else
		{
			DisplayFinalCompletionState();
		}
		numSwings++;
		if (e != MinigameEvaluation.Miss)
		{
			numHits++;
		}
		UpdateRoundStats();
	}

	protected override void CalcYield()
	{
		base.CalcYield();
		yieldBaselineUpgraded = yieldBaseline * MenuPanel.gm.MultiplierForGlobalUpgrade(UpgradeType.MinigameWoodYield);
	}

	private float RewardForEvaluation(MinigameEvaluation e)
	{
		return e switch
		{
			MinigameEvaluation.Perfect => yieldBaselineUpgraded * 4f * yieldMultiplier, 
			MinigameEvaluation.Great => yieldBaselineUpgraded * 2f * yieldMultiplier, 
			MinigameEvaluation.Good => yieldBaselineUpgraded * yieldMultiplier, 
			_ => 0f, 
		};
	}

	private void CalcRoundMetadata()
	{
		roundMultiplier = 1f + (float)numHits * 0.2f;
		UpdateRoundStats();
		axeImage.enabled = true;
		axeSpeed = 1f + (float)numHits * 0.2f;
		SetStumpWidth(140f - (float)numHits * 10f);
		if (Random.Range(0f, 1f) <= 0.5f)
		{
			axeDirection = -1;
			axeProgress = 0.34f;
		}
		else
		{
			axeDirection = 1;
			axeProgress = 0.67f;
		}
		UpdateAxePosition();
	}

	public void TryStartRound()
	{
		axeTransform.SetPosY(axeOriginY);
		roundDisplayCounter = 0f;
		roundNum++;
		UpdateChopButtonCaption();
		if (roundNum > 5)
		{
			DeclareVictory();
			axeImage.enabled = false;
		}
		else
		{
			CalcRoundMetadata();
			ResetEvaluation();
			chopButton.buttonState = CustomButtonState.Default;
		}
	}

	private void SetStumpWidth(float w)
	{
		stumpWidth = w;
		greatWidth = stumpWidth * 0.33f;
		perfectWidth = greatWidth * 0.33f;
		stumpTransform.SetWidth(stumpWidth);
		greatRegionTransform.SetWidth(greatWidth);
		perfectRegionTransform.SetWidth(perfectWidth);
	}

	protected override void DeclareVictory()
	{
		base.DeclareVictory();
		chopButton.gameObject.SetActive(value: false);
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}

	public override fsData GetData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		StoreCommonData(dictionary);
		dictionary["count"] = new fsData(roundNum);
		dictionary["attempts"] = new fsData(numSwings);
		dictionary["hits"] = new fsData(numHits);
		return new fsData(dictionary);
	}

	protected override void LoadFromDictionary(Dictionary<string, fsData> dataDictionary)
	{
		base.LoadFromDictionary(dataDictionary);
		SaveFile.TryLoadIntOut(dataDictionary, "count", out roundNum);
		SaveFile.TryLoadIntOut(dataDictionary, "attempts", out numSwings);
		SaveFile.TryLoadIntOut(dataDictionary, "hits", out numHits);
	}

	protected override void PostProcessLoadedData()
	{
		base.PostProcessLoadedData();
		chopButton.gameObject.SetActive(minigameState == MinigameState.Running);
		CalcRoundMetadata();
		ResetEvaluation();
		chopButton.buttonState = CustomButtonState.Default;
		if (minigameState == MinigameState.Running)
		{
			axeDirection = 1;
		}
		minigameFooter.rewardSection.SetValue(GameUtility.AsFloat(rewardAmount));
	}
}
