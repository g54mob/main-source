using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScalingCondition : DifficultyCondition
{
	[SerializeField]
	private List<float> stackValues;

	[SerializeField]
	public int currentStacks;

	[SerializeField]
	private float tonsPerStack;

	[SerializeField]
	private GameObject contentHolder;

	[SerializeField]
	private TextMeshProUGUI valueText;

	[SerializeField]
	private Sprite stackRegular;

	[SerializeField]
	private Sprite stackFilled;

	[SerializeField]
	private Sprite stackBlocked;

	[SerializeField]
	private TextMeshProUGUI weightText;

	[SerializeField]
	private GameObject lockedOverlay;

	[SerializeField]
	private LocationDifficultySO locationDifficultySO;

	[SerializeField]
	public List<TooltipTrigger> tooltips;

	[NonSerialized]
	public DifficultySelectorWindow difficultyWindow;

	private bool notEnoughSpace;

	private GameObject lastSelectedButton;

	[field: SerializeField]
	public ScalingDifficultyConditions condition { get; private set; }

	[field: SerializeField]
	public Button increaseButton { get; private set; }

	[field: SerializeField]
	public Button decreaseButton { get; private set; }

	private void Awake()
	{
		increaseButton.onClick.AddListener(IncreaseValue);
		decreaseButton.onClick.AddListener(DecreaseValue);
		weightText.text = tonsPerStack.ToString();
		if (isLocked)
		{
			GreyOut(greyOut: true);
			lockedOverlay.SetActive(value: true);
		}
		if (DifficultyManager.Instance.CurrentWeight == DifficultyManager.Instance.maxAllowedWeight)
		{
			GreyOut(greyOut: true);
			TurnOnButton(increaseButton, on: false);
		}
		if (currentStacks == 0)
		{
			TurnOnButton(decreaseButton, on: false);
		}
		else if (currentStacks == stackValues.Count - 1)
		{
			TurnOnButton(increaseButton, on: false);
		}
		difficultyWindow = MenuManager.Instance.GetMenu(MenuType.DifficultySelector).gameObject.GetComponent<DifficultySelectorWindow>();
		difficultyWindow.WeightUpdated += TrackWeightUpdate;
		foreach (TooltipTrigger tooltip in tooltips)
		{
			tooltip.PointerEntered += TooltipHandler;
		}
	}

	public void TooltipHandler(TooltipTrigger tooltip)
	{
		tooltip.displayOnlyTxt = difficultyWindow.conditionDescriptionTxt;
	}

	public override void UpdateLockState(bool locked)
	{
		base.UpdateLockState(locked);
		isLocked = locked;
		TurnOnButton(increaseButton, !locked);
		TurnOnButton(decreaseButton, !locked);
		if (!isLocked)
		{
			GreyOut(greyOut: false);
			lockedOverlay.SetActive(value: false);
		}
	}

	public void TrackWeightUpdate()
	{
		if (DifficultyManager.Instance.maxAllowedWeight - DifficultyManager.Instance.CurrentWeight < tonsPerStack || currentStacks == stackValues.Count - 1)
		{
			notEnoughSpace = true;
			GreyOut(greyOut: true);
			TurnOnButton(increaseButton, on: false);
		}
		else
		{
			notEnoughSpace = false;
		}
	}

	public void IncreaseValue()
	{
		if (currentStacks + 1 != stackValues.Count && !isLocked && !notEnoughSpace)
		{
			currentStacks = Mathf.Clamp(currentStacks + 1, 0, stackValues.Count - 1);
			contentHolder.transform.GetChild(currentStacks - 1).GetComponent<Image>().sprite = stackFilled;
			DifficultyManager.Instance.DifficultyUI.UpdateWeightBar(tonsPerStack);
			UpdateConditionValue();
			if (condition == ScalingDifficultyConditions.LocationDifficulty && GameManager.Instance.IsJourneyStarted)
			{
				ZoneManager.Instance.SetZone(ZoneManager.Instance.ZoneDefinitions[1]);
			}
			if (difficultyWindow != null)
			{
				difficultyWindow.SpawnJunk();
			}
			TurnOnButton(decreaseButton, on: true);
			if (currentStacks == stackValues.Count - 1)
			{
				TurnOnButton(increaseButton, on: false);
			}
			MenuManager.Instance.StartCoroutine(DebounceInput());
		}
	}

	public void DecreaseValue()
	{
		if (currentStacks - 1 < 0 || isLocked)
		{
			return;
		}
		foreach (ScalingCondition scalingCondition in DifficultyManager.Instance.DifficultyUI.scalingConditions)
		{
			if (!scalingCondition.isLocked)
			{
				scalingCondition.GreyOut(greyOut: false);
				TurnOnButton(scalingCondition.increaseButton, on: true);
			}
		}
		currentStacks = Mathf.Clamp(currentStacks - 1, 0, stackValues.Count - 1);
		contentHolder.transform.GetChild(currentStacks).GetComponent<Image>().sprite = stackRegular;
		DifficultyManager.Instance.DifficultyUI.UpdateWeightBar(0f - tonsPerStack);
		UpdateConditionValue();
		if (condition == ScalingDifficultyConditions.LocationDifficulty && GameManager.Instance.IsJourneyStarted)
		{
			ZoneManager.Instance.SetZone(ZoneManager.Instance.ZoneDefinitions[1]);
		}
		difficultyWindow.DespawnJunk();
		if (currentStacks == 0)
		{
			TurnOnButton(decreaseButton, on: false);
		}
		MenuManager.Instance.StartCoroutine(DebounceInput());
	}

	public void GreyOut(bool greyOut)
	{
		if (greyOut)
		{
			foreach (Transform item in contentHolder.transform)
			{
				Image component = item.gameObject.GetComponent<Image>();
				if (component.sprite == stackRegular)
				{
					component.sprite = stackBlocked;
				}
			}
			if (currentStacks == 0)
			{
				TurnOnButton(decreaseButton, on: false);
			}
			TurnOnButton(increaseButton, on: false);
			return;
		}
		foreach (Transform item2 in contentHolder.transform)
		{
			Image component2 = item2.gameObject.GetComponent<Image>();
			if (component2.sprite == stackBlocked)
			{
				component2.sprite = stackRegular;
			}
		}
	}

	public void UpdateConditionValue()
	{
		switch (condition)
		{
		case ScalingDifficultyConditions.EnemyHealth:
			UpdateEnemyHealth();
			break;
		case ScalingDifficultyConditions.EnemyDamage:
			UpdateEnemyDamage();
			break;
		case ScalingDifficultyConditions.LocationDifficulty:
			UpdateLocationDifficulty();
			break;
		case ScalingDifficultyConditions.ScrapGain:
			UpdateScrapGain();
			break;
		case ScalingDifficultyConditions.BrokenModuleHullDamage:
			UpdateModuleHullDamage();
			break;
		case ScalingDifficultyConditions.CoalDrainsFaster:
			UpdateCoalDrain();
			break;
		case ScalingDifficultyConditions.LessChoices:
			UpdateLessChoices();
			break;
		case ScalingDifficultyConditions.EnemyMixup:
			UpdateMixedWaves();
			break;
		}
	}

	public void UpdateEnemyHealth()
	{
		DifficultyManager.Instance.enemyHealthMultiplier = stackValues[currentStacks];
		valueText.text = "+" + DifficultyManager.Instance.enemyHealthMultiplier * 100f + "%";
	}

	public void UpdateEnemyDamage()
	{
		DifficultyManager.Instance.enemyDamageMultiplier = stackValues[currentStacks];
		valueText.text = "+" + DifficultyManager.Instance.enemyDamageMultiplier * 100f + "%";
	}

	public void UpdateLocationDifficulty()
	{
		switch (currentStacks)
		{
		case 0:
			DifficultyManager.Instance.ChangeLocationDifficulty(0f, 0f, 0f);
			valueText.text = "+" + currentStacks * 100 + "%";
			break;
		case 1:
			DifficultyManager.Instance.ChangeLocationDifficulty(locationDifficultySO.Difficulty1Modifiers["Easy"], locationDifficultySO.Difficulty1Modifiers["Medium"], locationDifficultySO.Difficulty1Modifiers["Hard"]);
			valueText.text = "+" + currentStacks * 100 + "%";
			break;
		case 2:
			DifficultyManager.Instance.ChangeLocationDifficulty(locationDifficultySO.Difficulty2Modifiers["Easy"], locationDifficultySO.Difficulty2Modifiers["Medium"], locationDifficultySO.Difficulty2Modifiers["Hard"]);
			valueText.text = "+" + currentStacks * 100 + "%";
			break;
		case 3:
			DifficultyManager.Instance.ChangeLocationDifficulty(locationDifficultySO.Difficulty3Modifiers["Easy"], locationDifficultySO.Difficulty3Modifiers["Medium"], locationDifficultySO.Difficulty3Modifiers["Hard"]);
			valueText.text = "+" + currentStacks * 100 + "%";
			break;
		}
	}

	public void UpdateScrapGain()
	{
		DifficultyManager.Instance.scrapGain = stackValues[currentStacks];
		valueText.text = DifficultyManager.Instance.scrapGain * 100f + "%";
	}

	public void UpdateModuleHullDamage()
	{
		DifficultyManager.Instance.brokenModuleHullDamage = stackValues[currentStacks];
		valueText.text = "+" + DifficultyManager.Instance.brokenModuleHullDamage * 100f + "%";
	}

	public void UpdateCoalDrain()
	{
		DifficultyManager.Instance.coalDrainPercent = stackValues[currentStacks];
		valueText.text = "+" + DifficultyManager.Instance.coalDrainPercent * 100f + "%";
	}

	public void UpdateLessChoices()
	{
		DifficultyManager.Instance.lessChoices = (int)stackValues[currentStacks];
		valueText.text = "-" + DifficultyManager.Instance.lessChoices;
	}

	private void UpdateMixedWaves()
	{
		if (stackValues[currentStacks] == 0f)
		{
			DifficultyManager.Instance.mixedWaves = false;
			valueText.text = "Off";
		}
		else
		{
			DifficultyManager.Instance.mixedWaves = true;
			valueText.text = "On";
		}
	}

	public void TurnOnButton(Button button, bool on)
	{
		if (!on)
		{
			button.interactable = false;
		}
		else
		{
			button.interactable = true;
		}
	}

	private IEnumerator DebounceInput()
	{
		lastSelectedButton = EventSystem.current.firstSelectedGameObject;
		EventSystem.current.SetSelectedGameObject(null);
		yield return new WaitForSecondsRealtime(0.01f);
		EventSystem.current.SetSelectedGameObject(lastSelectedButton.gameObject);
	}
}
