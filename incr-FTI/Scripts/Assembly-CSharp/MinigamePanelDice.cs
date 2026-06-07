using System.Collections.Generic;
using FullSerializer;
using TMPro;
using UnityEngine;

public class MinigamePanelDice : MinigamePanel
{
	public GameObject diceButtonPrefab;

	public GameObject diceRewardRowPrefab;

	private List<DiceButton> dice = new List<DiceButton>();

	private List<DiceRewardRow> diceRewardRows = new List<DiceRewardRow>();

	public Transform diceParent;

	public Transform rewardParent;

	public LabelButton rollButton;

	public LabelButton finishButton;

	public RewardSection scoreRewardSection;

	private Dictionary<int, int> diceCount = new Dictionary<int, int>();

	private Dictionary<int, int> matches = new Dictionary<int, int>();

	public TextMeshProUGUI instructionsLabel;

	private int maxNumOfAKind;

	private int numWildStars;

	private int highestMatchingFace;

	private int firstPair;

	private int firstTriple;

	private int secondPair;

	private int numDifferentFaces;

	private int scoreRowIndex;

	private int totalScore;

	private bool hasRolledAtLeastOnce;

	private bool isRolling;

	private int[] diceFaces = new int[5];

	private int debugNumRolls;

	private int debugNumMatch5;

	private int debugNumMatch4;

	private int debugNumMatch3;

	private int debugNumMatch2;

	private int debugNumFullHouse;

	private int debugNumStraights;

	private int debugNumMatch5Exclusive;

	private int debugNumMatch4Exclusive;

	private int debugNumMatch3Exclusive;

	private int debugNumMatch2Exclusive;

	private int debugNumFullHouseExclusive;

	private int debugNumStraightsExclusive;

	private const int numDice = 5;

	private const int MultiplierForJackpot = 20;

	private const int MultiplierForMatch5 = 10;

	private const int MultiplierForStraight = 8;

	private const int MultiplierForMatch4 = 6;

	private const int MultiplierForFullHouse = 5;

	private const int MultiplierForMatch3 = 4;

	private const int MultiplierForTwoPair = 3;

	private const int MultiplierForMatch2 = 2;

	private bool areStarsWild;

	public override void Initialize()
	{
		base.Initialize();
		scoreRewardSection.Initialize();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		scoreRewardSection.UpdateDynamicDisplay();
	}

	public override void ResetMinigame()
	{
		base.ResetMinigame();
		hasRolledAtLeastOnce = false;
		isRolling = false;
		foreach (DiceButton die in dice)
		{
			die.ResetState();
		}
		foreach (DiceRewardRow diceRewardRow in diceRewardRows)
		{
			diceRewardRow.gameObject.SetActive(value: false);
		}
	}

	protected override void LoadNewMinigame()
	{
		base.LoadNewMinigame();
		hasRolledAtLeastOnce = false;
		isRolling = false;
		rollButton.label.text = "Roll".Localized();
		foreach (DiceButton die in dice)
		{
			die.ResetState();
		}
		scoreRewardSection.SetValue(0f);
		foreach (DiceRewardRow diceRewardRow in diceRewardRows)
		{
			diceRewardRow.gameObject.SetActive(value: false);
		}
		UpdateButtonStates();
		UpdateInstructions();
		minigameState = MinigameState.Running;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		rollButton.label.text = "Roll".Localized();
		finishButton.label.text = "Finish".Localized();
		UpdateInstructions();
	}

	public override void CreateItems()
	{
		rollButton.AddPointerClickTrigger(OnRollPressed);
		finishButton.AddPointerClickTrigger(OnFinishPressed);
		int num = 5;
		for (int i = 0; i < num; i++)
		{
			CreateDie(i + 1);
		}
		levelStat = MenuPanel.gm.minigameDice;
		energyTracker = MenuPanel.gm.energyDice;
		scoreRewardSection.iconImage.sprite = IconManager.SpriteForItem(ItemType.UtilityDiceGamePoint);
		scoreRewardSection.iconImage.enabled = false;
		rewardEntities.AddItem(ItemType.YellowCoin, 10.0);
		rewardEntities.AddItem(ItemType.RedCoin, 6.0);
		rewardEntities.AddItem(ItemType.BlueCoin, 3.0);
		rewardEntities.AddItem(ItemType.PurpleCoin, 1.0);
		DebugDice();
		base.CreateItems();
	}

	private void OnRollPressed()
	{
		if (rollButton.buttonState == CustomButtonState.Invalid)
		{
			MenuManager.Instance.ShowMessage(rollButton.invalidReason);
		}
		else if (rollButton.buttonState != CustomButtonState.Disabled)
		{
			rollButton.buttonState = CustomButtonState.Disabled;
			foreach (DiceButton die in dice)
			{
				if (die.isTempLocked)
				{
					die.isLocked = true;
					die.isTempLocked = false;
					die.UpdateIconState();
				}
				if (!die.isLocked)
				{
					die.Roll();
					isRolling = true;
				}
			}
		}
		UpdateButtonStates();
		UpdateInstructions();
	}

	private void OnFinishPressed()
	{
		if (!finishButton.shouldIgnoreAction)
		{
			EndMinigame();
		}
	}

	private void CreateDie(int index)
	{
		DiceButton component = MenuManager.GetMenuObject(diceButtonPrefab, diceParent).GetComponent<DiceButton>();
		component.finalizeDelegate = OnSingleDieFinished;
		component.lockStateChangeDelegate = OnSingleDieLockStateChanged;
		component.diceIndex = index;
		dice.Add(component);
	}

	private bool IsRollComplete()
	{
		foreach (DiceButton die in dice)
		{
			if (die.isRolling)
			{
				return false;
			}
		}
		return true;
	}

	private void OnSingleDieLockStateChanged()
	{
		UpdateButtonStates();
	}

	public void OnSingleDieFinished(DiceButton sender)
	{
		sender.SetTempLock(next: true);
		if (IsRollComplete())
		{
			FinalizeRoll();
		}
	}

	public void FinalizeRoll()
	{
		isRolling = false;
		hasRolledAtLeastOnce = true;
		CalculateScore();
		if (CanPotentiallyReRoll())
		{
			rollButton.label.text = "Re-Roll".Localized();
		}
		UpdateButtonStates();
		UpdateInstructions();
	}

	private void EndMinigame()
	{
		minigameState = MinigameState.Success;
		foreach (DiceButton die in dice)
		{
			die.isMinigameOver = true;
			die.UpdateIconState();
		}
		UpdateButtonStates();
		UpdateInstructions();
		rewardAmount = (float)totalScore * CoinsPerPoint();
		float value = GameUtility.AsFloat(rewardAmount);
		if (MenuPanel.gm.gameState == GameState.InGame)
		{
			float amount = (float)totalScore * XPPerPoint();
			AnimateToExperience(scoreRewardSection.transform, levelStat.iconItem, amount);
			AnimateItemGain(scoreRewardSection.transform, value, 3);
			EarnReward(rewardAmount);
		}
		else
		{
			minigameFooter.rewardSection.SetValue(value);
		}
	}

	private bool CanPotentiallyReRoll()
	{
		if (!hasRolledAtLeastOnce)
		{
			return false;
		}
		return dice.Count - NumDiceFullyLocked() > 1;
	}

	private void UpdateInstructions()
	{
		if (isRolling)
		{
			instructionsLabel.enabled = false;
			return;
		}
		instructionsLabel.enabled = true;
		if (!hasRolledAtLeastOnce)
		{
			instructionsLabel.text = "DiceInstructionsInitialRoll".Localized();
		}
		else if (MustLockOneButton())
		{
			instructionsLabel.text = "DiceInstructionsMustKeepOne".Localized();
		}
		else if (CanPotentiallyReRoll())
		{
			instructionsLabel.text = "DiceInstructionsReRoll".Localized();
		}
		else if (minigameState == MinigameState.Success)
		{
			instructionsLabel.text = "DiceInstructionsComplete".Localized();
		}
		else
		{
			instructionsLabel.text = "DiceInstructionsComplete".Localized();
		}
	}

	private bool MustLockOneButton()
	{
		if (hasRolledAtLeastOnce)
		{
			return NumDiceTempLocked() == 0;
		}
		return false;
	}

	private void UpdateButtonStates()
	{
		rollButton.invalidReason = InvalidReason.None;
		if (isRolling)
		{
			rollButton.buttonState = CustomButtonState.Disabled;
		}
		else if (!hasRolledAtLeastOnce)
		{
			rollButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else if (minigameState == MinigameState.Success)
		{
			rollButton.buttonState = CustomButtonState.Disabled;
		}
		else if (MustLockOneButton())
		{
			rollButton.buttonState = CustomButtonState.Invalid;
			rollButton.invalidReason = InvalidReason.MustSelectDieToReroll;
		}
		else if (NumDiceUnlocked() == 0)
		{
			rollButton.buttonState = CustomButtonState.Disabled;
		}
		else
		{
			rollButton.buttonState = CustomButtonState.Default;
		}
		if (isRolling || !hasRolledAtLeastOnce || minigameState == MinigameState.Success)
		{
			finishButton.buttonState = CustomButtonState.Disabled;
		}
		else if (!CanPotentiallyReRoll())
		{
			finishButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			finishButton.buttonState = CustomButtonState.Default;
		}
	}

	private int NumDiceUnlocked()
	{
		int num = 0;
		foreach (DiceButton die in dice)
		{
			if (!die.isLocked && !die.isTempLocked)
			{
				num++;
			}
		}
		return num;
	}

	private int NumDiceFullyLocked()
	{
		int num = 0;
		foreach (DiceButton die in dice)
		{
			if (die.isLocked)
			{
				num++;
			}
		}
		return num;
	}

	private int NumDiceTempLocked()
	{
		int num = 0;
		foreach (DiceButton die in dice)
		{
			if (die.isTempLocked)
			{
				num++;
			}
		}
		return num;
	}

	private int ScoreForFullHouse(int large, int small)
	{
		return 15;
	}

	private int FaceValueForTwoPairs()
	{
		return FaceValue(firstPair) * 2 + FaceValue(secondPair) * 2;
	}

	private int ScoreForStraight(int numDice)
	{
		return numDice switch
		{
			3 => 5, 
			4 => 12, 
			5 => 25, 
			_ => 0, 
		};
	}

	private static int MultiplierForNumOfAKind(int faceValue, int numOfAKind)
	{
		switch (numOfAKind)
		{
		case 5:
			if (faceValue != 6)
			{
				return 10;
			}
			return 20;
		case 4:
			return 6;
		case 3:
			return 4;
		case 2:
			return 2;
		default:
			return 1;
		}
	}

	private static int FaceValueForMatch(int numFaces, int face, int stars)
	{
		return numFaces * FaceValue(face) + stars * FaceValue(6);
	}

	private void LoadScoringAttributesFromDiceFaces()
	{
		diceCount.Clear();
		matches.Clear();
		firstPair = 0;
		secondPair = 0;
		firstTriple = 0;
		maxNumOfAKind = 0;
		numWildStars = 0;
		highestMatchingFace = 0;
		numDifferentFaces = 0;
		for (int i = 0; i < 5; i++)
		{
			int key = diceFaces[i];
			diceCount.TryGetValue(key, out var value);
			diceCount[key] = value + 1;
		}
		foreach (KeyValuePair<int, int> item in diceCount)
		{
			int key2 = item.Key;
			int value2 = item.Value;
			if (key2 == 6 && areStarsWild)
			{
				numWildStars = item.Value;
				continue;
			}
			if (key2 != 6)
			{
				numDifferentFaces++;
			}
			if (value2 == 3)
			{
				firstTriple = key2;
			}
			if (value2 == 2)
			{
				if (firstPair == 0)
				{
					firstPair = key2;
				}
				else
				{
					secondPair = key2;
				}
			}
			if (value2 > maxNumOfAKind)
			{
				maxNumOfAKind = value2;
				highestMatchingFace = key2;
			}
		}
	}

	private bool IsMatch(int testMatch)
	{
		return maxNumOfAKind + numWildStars >= testMatch;
	}

	private bool IsFullHouse()
	{
		if (firstTriple > 0 && firstPair > 0)
		{
			return true;
		}
		if (firstTriple > 0 && numWildStars >= 1)
		{
			return true;
		}
		if (firstPair > 0 && secondPair > 0 && numWildStars >= 1)
		{
			return true;
		}
		if (firstPair > 0 && numWildStars >= 2)
		{
			return true;
		}
		return false;
	}

	private bool IsStraight()
	{
		return numDifferentFaces + numWildStars >= 5;
	}

	private void CalculateScore()
	{
		totalScore = 0;
		for (int i = 0; i < 5; i++)
		{
			diceFaces[i] = dice[i].rollResult;
		}
		LoadScoringAttributesFromDiceFaces();
		scoreRowIndex = 0;
		ShowFaceRewardRow();
		if (IsMatch(5))
		{
			DisplayMatch(5);
		}
		else if (IsMatch(4))
		{
			DisplayMatch(4);
		}
		else if (IsStraight())
		{
			DisplayStraight();
		}
		else if (IsFullHouse())
		{
			DisplayFullHouse();
		}
		else if (IsMatch(3))
		{
			DisplayMatch(3);
		}
		else if (firstPair > 0 && secondPair > 0)
		{
			DisplayTwoPair();
		}
		else if (IsMatch(2))
		{
			DisplayMatch(2);
		}
		else
		{
			int num = TotalFaceValue();
			totalScore += num;
		}
		for (int j = 0; j < diceRewardRows.Count; j++)
		{
			if (scoreRowIndex <= j)
			{
				diceRewardRows[j].gameObject.SetActive(value: false);
			}
		}
		scoreRewardSection.AnimateToValue(totalScore);
	}

	public static int FaceValue(int rollResult)
	{
		if (rollResult != 6)
		{
			return rollResult;
		}
		return 10;
	}

	private int TotalFaceValue()
	{
		int num = 0;
		foreach (DiceButton die in dice)
		{
			num += FaceValue(die.rollResult);
		}
		return num;
	}

	private int AddFacesWithMultiplier(int multiplier)
	{
		return TotalFaceValue() * multiplier;
	}

	protected override void CalcYield()
	{
		base.CalcYield();
		yieldBaselineUpgraded = (yieldBaseline *= MenuPanel.gm.MultiplierForGlobalUpgrade(UpgradeType.MinigameDiceYield));
	}

	private float XPPerPoint()
	{
		return 0.25f * GameManager.Instance.MultiplierForGlobalPerk(PerkType.MinigameXPGainSpeed);
	}

	private float CoinsPerPoint()
	{
		return yieldBaselineUpgraded * yieldMultiplier;
	}

	private bool HasStraight(int start, int end)
	{
		for (int i = start; i <= end; i++)
		{
			if (!diceCount.TryGetValue(i, out var value) || value == 0)
			{
				return false;
			}
		}
		return true;
	}

	private void ShowFaceRewardRow()
	{
		DiceRewardRow rewardRow = GetRewardRow();
		for (int i = 0; i < 5; i++)
		{
			rewardRow.SetDiceIndexToValue(i, dice[i].rollResult);
		}
		rewardRow.descriptionLabel.text = "FaceValues".Localized();
		rewardRow.scoreLabel.text = "= " + TextDisplay.LocalizedNumber(TotalFaceValue());
		rewardRow.SetValueTextVisibility(visibleState: true);
	}

	private void DisplayTwoPair()
	{
		int num = TotalFaceValue();
		int num2 = 3;
		int num3 = num * num2;
		totalScore += num3;
		DiceRewardRow rewardRow = GetRewardRow();
		rewardRow.SetDiceIndexToValue(0, firstPair);
		rewardRow.SetDiceIndexToValue(1, firstPair);
		rewardRow.SetDiceIndexToValue(2, secondPair);
		rewardRow.SetDiceIndexToValue(3, secondPair);
		rewardRow.HideDiceAtAndAboveIndex(4);
		rewardRow.descriptionLabel.text = "TwoPair".Localized();
		rewardRow.scoreLabel.text = $"{TextDisplay.Multiplier}{num2}";
		rewardRow.SetValueTextVisibility(visibleState: false);
	}

	private string StringForScoreCalculation(int faceValue, int multiplier)
	{
		return TextDisplay.LocalizedNumber(faceValue) + " " + TextDisplay.Multiplier + " " + TextDisplay.LocalizedNumber(multiplier) + " = " + TextDisplay.LocalizedNumber(faceValue * multiplier);
	}

	private string MultiplierString(int m)
	{
		return " = " + TextDisplay.Multiplier + TextDisplay.LocalizedNumber(m);
	}

	private void DisplayMatch(int match)
	{
		int num = TotalFaceValue();
		int num2 = MultiplierForNumOfAKind(highestMatchingFace, match);
		int num3 = num * num2;
		totalScore += num3;
		DiceRewardRow rewardRow = GetRewardRow();
		for (int i = 0; i < maxNumOfAKind; i++)
		{
			rewardRow.SetDiceIndexToValue(i, highestMatchingFace);
		}
		for (int j = 0; j < numWildStars; j++)
		{
			int index = j + maxNumOfAKind;
			rewardRow.SetDiceIndexToValue(index, 6);
		}
		rewardRow.descriptionLabel.text = TextDisplay.LabelForDiceMatch(highestMatchingFace, match);
		rewardRow.scoreLabel.text = $"{TextDisplay.Multiplier}{num2}";
		rewardRow.SetValueTextVisibility(visibleState: false);
		if (match < 5)
		{
			rewardRow.HideDiceAtAndAboveIndex(match);
		}
	}

	private void DisplayStraight()
	{
		DiceRewardRow rewardRow = GetRewardRow();
		for (int i = 1; i <= 5; i++)
		{
			int index = i - 1;
			if (diceCount.TryGetValue(i, out var value) && value > 0)
			{
				rewardRow.SetDiceIndexToValue(index, i);
			}
			else
			{
				rewardRow.SetDiceIndexToValue(index, 6);
			}
		}
		int num = TotalFaceValue();
		int num2 = 8;
		int num3 = num * num2;
		totalScore += num3;
		rewardRow.descriptionLabel.text = TextDisplay.LabelForStraight(5);
		rewardRow.scoreLabel.text = $"{TextDisplay.Multiplier}{num2}";
		rewardRow.SetValueTextVisibility(visibleState: false);
	}

	private void DisplayFullHouse()
	{
		DiceRewardRow rewardRow = GetRewardRow();
		int num = 0;
		for (int i = 1; i <= 6; i++)
		{
			if (diceCount.TryGetValue(i, out var value) && value > 0)
			{
				for (int j = 0; j < value; j++)
				{
					rewardRow.SetDiceIndexToValue(j + num, i);
				}
				num += value;
			}
		}
		int num2 = TotalFaceValue();
		int num3 = 5;
		int num4 = num2 * num3;
		totalScore += num4;
		rewardRow.descriptionLabel.text = "FullHouse".Localized();
		rewardRow.scoreLabel.text = $"{TextDisplay.Multiplier}{num3}";
		rewardRow.SetValueTextVisibility(visibleState: false);
	}

	private DiceRewardRow GetRewardRow()
	{
		DiceRewardRow diceRewardRow = null;
		if (scoreRowIndex < diceRewardRows.Count)
		{
			diceRewardRow = diceRewardRows[scoreRowIndex];
		}
		else
		{
			diceRewardRow = MenuManager.GetMenuObject(diceRewardRowPrefab, rewardParent).GetComponent<DiceRewardRow>();
			diceRewardRows.Add(diceRewardRow);
		}
		diceRewardRow.gameObject.SetActive(value: true);
		scoreRowIndex++;
		return diceRewardRow;
	}

	private void RecursivelyLoadDice(int diceIndex)
	{
		for (int i = 1; i <= 6; i++)
		{
			diceFaces[diceIndex] = i;
			if (diceIndex < 4)
			{
				RecursivelyLoadDice(diceIndex + 1);
			}
			else
			{
				LogDebugDice();
			}
		}
	}

	private int GetDiceCount(int faceValue)
	{
		if (diceCount.TryGetValue(faceValue, out var value))
		{
			return value;
		}
		return 0;
	}

	private void LogDebugDice()
	{
		_ = debugNumRolls;
		diceCount.Clear();
		LoadScoringAttributesFromDiceFaces();
		debugNumRolls++;
		if (IsMatch(5))
		{
			debugNumMatch5++;
			debugNumMatch5Exclusive++;
		}
		else if (IsMatch(4))
		{
			debugNumMatch4Exclusive++;
		}
		else if (IsFullHouse())
		{
			debugNumFullHouseExclusive++;
		}
		else if (IsMatch(3))
		{
			debugNumMatch3Exclusive++;
		}
		else if (IsMatch(2))
		{
			debugNumMatch2Exclusive++;
		}
		if (IsMatch(4))
		{
			debugNumMatch4++;
		}
		if (IsMatch(3))
		{
			debugNumMatch3++;
		}
		if (IsMatch(2))
		{
			debugNumMatch2++;
		}
		if (IsFullHouse())
		{
			debugNumFullHouse++;
		}
		if (IsStraight())
		{
			debugNumStraights++;
		}
	}

	private void DebugDice()
	{
		diceCount.Clear();
		matches.Clear();
		RecursivelyLoadDice(0);
	}

	public override fsData GetData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		StoreCommonData(dictionary);
		if (hasRolledAtLeastOnce)
		{
			dictionary["hasRolled"] = fsData.True;
		}
		List<fsData> list = new List<fsData>();
		foreach (DiceButton die in dice)
		{
			list.Add(DataFromDice(die));
		}
		dictionary["Items"] = new fsData(list);
		return new fsData(dictionary);
	}

	private fsData DataFromDice(DiceButton b)
	{
		return new fsData(new List<fsData>
		{
			new fsData(b.rollResult),
			new fsData(b.hasRolledAtLeastOnce),
			new fsData(b.isLocked),
			new fsData(b.isTempLocked)
		});
	}

	private void LoadDiceFromData(DiceButton b, List<fsData> propertyList)
	{
		if (propertyList.Count >= 4)
		{
			fsData data = propertyList[0];
			fsData data2 = propertyList[1];
			fsData data3 = propertyList[2];
			fsData data4 = propertyList[3];
			SaveFile.TryLoadInt(data, ref b.rollResult);
			SaveFile.TryLoadBool(data2, ref b.hasRolledAtLeastOnce);
			SaveFile.TryLoadBool(data3, ref b.isLocked);
			SaveFile.TryLoadBool(data4, ref b.isTempLocked);
		}
	}

	protected override void LoadFromDictionary(Dictionary<string, fsData> dataDict)
	{
		base.LoadFromDictionary(dataDict);
		hasRolledAtLeastOnce = dataDict.ContainsKey("hasRolled");
		if (!dataDict.TryGetValue("Items", out var value) || !value.TryAsList(out var result))
		{
			return;
		}
		for (int i = 0; i < result.Count; i++)
		{
			fsData data = result[i];
			if (i < dice.Count && data.TryAsList(out var result2))
			{
				DiceButton b = dice[i];
				LoadDiceFromData(b, result2);
			}
		}
	}

	protected override void PostProcessLoadedData()
	{
		if (hasRolledAtLeastOnce)
		{
			CalculateScore();
		}
		if (CanPotentiallyReRoll())
		{
			rollButton.label.text = "Re-Roll".Localized();
		}
		UpdateButtonStates();
		UpdateInstructions();
		foreach (DiceButton die in dice)
		{
			if (!hasRolledAtLeastOnce)
			{
				die.ResetState();
				continue;
			}
			die.isMinigameOver = minigameState == MinigameState.Failure || minigameState == MinigameState.Success;
			die.UpdateFaceState();
			die.UpdateIconState();
		}
		base.PostProcessLoadedData();
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}
}
