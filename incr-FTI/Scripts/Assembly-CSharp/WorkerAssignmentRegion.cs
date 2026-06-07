using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorkerAssignmentRegion : MonoBehaviour
{
	public delegate void WorkerAssignmentDelegate(float nextValue);

	public delegate void InvalidButtonDelegate(InvalidReason reason);

	public TextMeshProUGUI currentCountLabel;

	public TextMeshProUGUI decreaseLabel;

	public TextMeshProUGUI increaseLabel;

	public MenuButton decreaseButton;

	public MenuButton increaseButton;

	public MenuButton automaticAssignButton;

	public TextMeshProUGUI increaseText;

	public Image iconImage;

	public Image automaticAssignmentImage;

	public Image automaticAssignmentHighlight;

	public LayoutElement layoutElement;

	[NonSerialized]
	public bool allowsRepeatAssignment;

	private float available;

	public WorkerAssignmentDelegate onManuallyChanged;

	public InvalidButtonDelegate invalidButtonDelegate;

	public UnityAction onRepeatChanged;

	public bool debug;

	[NonSerialized]
	public int delta;

	public float maxCapacity;

	private float displayedCount = -2.1474836E+09f;

	private IncrementDisplayManager incrementDisplayManager;

	private StateManager linkedState;

	private BuildingState linkedBuildingState;

	[NonSerialized]
	public TextFlashAnimation textFlashAnimation;

	private PunchAnimation assignmentPunch;

	public bool disableControls;

	public InvalidReason overrideInvalidReason;

	public float currentCount
	{
		get
		{
			if (linkedState == null)
			{
				return 0f;
			}
			return linkedState.numWorkersAssigned;
		}
	}

	public void Initialize()
	{
		increaseButton.isImageButton = true;
		decreaseButton.isImageButton = true;
		increaseButton.InitializeButton();
		decreaseButton.InitializeButton();
		decreaseButton.AddPointerDownTrigger(OnDecreasePressed);
		increaseButton.AddPointerDownTrigger(OnIncreasePressed);
		increaseButton.animateSize = true;
		decreaseButton.animateSize = true;
		decreaseButton.AddRightClickTrigger(OnDecreaseRightClicked);
		increaseButton.AddRightClickTrigger(OnIncreaseRightClicked);
		automaticAssignButton.AddPointerClickTrigger(OnAutomaticAssignClicked);
		SetAutomaticAssignmentAvailable(nextState: false);
		automaticAssignButton.buttonState = CustomButtonState.Background;
		automaticAssignButton.isTooltipDelayed = false;
		incrementDisplayManager = new IncrementDisplayManager(increaseLabel, decreaseLabel);
		incrementDisplayManager.hideLabelWhenDefault = true;
		textFlashAnimation = new TextFlashAnimation(currentCountLabel);
		assignmentPunch = new PunchAnimation();
	}

	public void LinkStateManager(StateManager sm)
	{
		linkedState = sm;
		disableControls = false;
		linkedBuildingState = sm.producingBuilding;
		if (sm.producingBuilding != null)
		{
			allowsRepeatAssignment = true;
		}
		if (sm is ResearchState researchState)
		{
			maxCapacity = researchState.CurrentMaxWorkers();
		}
		else
		{
			maxCapacity = float.MaxValue;
		}
		assignmentPunch.StopAndReset();
		textFlashAnimation.StopAndReset();
		displayedCount = float.MinValue;
	}

	private int ActiveIncrementValue()
	{
		if (UserInput.activeGlobalIncrement == 0)
		{
			return 1;
		}
		if (false)
		{
			if (currentCount < 500f)
			{
				return UserInput.activeGlobalIncrement;
			}
			float num = currentCount / (float)UserInput.activeGlobalIncrement;
			if (num >= 1000f)
			{
				return UserInput.activeGlobalIncrement * 100;
			}
			if (num >= 100f)
			{
				return UserInput.activeGlobalIncrement * 10;
			}
		}
		return UserInput.activeGlobalIncrement;
	}

	public void UpdateDynamicDisplay()
	{
		UpdateButtonAvailability();
		delta = ActiveIncrementValue();
		incrementDisplayManager.UpdateDynamicDisplay(delta);
		assignmentPunch?.UpdateAnimation();
		textFlashAnimation?.UpdateAnimation();
		if (assignmentPunch != null && assignmentPunch.isRunning)
		{
			float num = assignmentPunch.EasedValue();
			currentCountLabel.transform.localScale = new Vector3(num, num, num);
		}
		else
		{
			currentCountLabel.transform.localScale = Vector3.one;
		}
	}

	public void TryModify(int dir)
	{
		if (dir == 1)
		{
			OnIncreasePressed();
		}
		if (dir == -1)
		{
			OnDecreasePressed();
		}
	}

	public void OnDecreaseRightClicked()
	{
		if (decreaseButton.invalidReason != InvalidReason.None)
		{
			invalidButtonDelegate?.Invoke(increaseButton.invalidReason);
			return;
		}
		assignmentPunch.Run();
		onManuallyChanged?.Invoke(0f);
		UpdateButtonAvailability();
	}

	public void OnDecreasePressed()
	{
		if (decreaseButton.invalidReason != InvalidReason.None)
		{
			invalidButtonDelegate?.Invoke(increaseButton.invalidReason);
			return;
		}
		assignmentPunch.Run();
		float num = currentCount;
		num = ((!((float)delta > num)) ? (num - (float)delta) : 0f);
		onManuallyChanged?.Invoke(num);
		UpdateButtonAvailability();
	}

	public void OnAutomaticAssignClicked()
	{
		if (allowsRepeatAssignment)
		{
			onRepeatChanged?.Invoke();
		}
	}

	public void SetAutomaticAssignmentAvailable(bool nextState)
	{
		automaticAssignButton.gameObject.SetActive(nextState);
	}

	private bool TryBorrowCapacityFromOtherRecipe()
	{
		int num = 0;
		double num2 = double.MinValue;
		StateManager stateManager = null;
		foreach (StateManager dependentState in linkedBuildingState.dependentStates)
		{
			if (dependentState == linkedState || !dependentState.appliedAutoAssign || dependentState.numWorkersAssigned <= 1f)
			{
				continue;
			}
			if (num != 0)
			{
				int appliedPriority = (int)dependentState.appliedPriority;
				if (appliedPriority > num)
				{
					continue;
				}
				if (appliedPriority < num)
				{
					num = appliedPriority;
					num2 = double.MinValue;
				}
			}
			double num3 = ((dependentState.primaryOutput != null) ? dependentState.primaryOutput.state.lastFrameSurplus : ((!(dependentState is SellState sellState)) ? dependentState.actualRecipeUnits : ((double)sellState.fulfillmentRatio)));
			if (!(num3 < num2))
			{
				num2 = num3;
				stateManager = dependentState;
			}
		}
		if (stateManager != null)
		{
			stateManager.numWorkersAssigned -= 1f;
			return true;
		}
		return false;
	}

	public void OnIncreasePressed()
	{
		float num = 0f;
		if (increaseButton.invalidReason == InvalidReason.NotEnoughBuildings)
		{
			foreach (StateManager dependentState in linkedBuildingState.dependentStates)
			{
				if (dependentState != linkedState && dependentState.appliedAutoAssign && !(dependentState.numWorkersAssigned <= 1f))
				{
					num += dependentState.numWorkersAssigned - 1f;
				}
			}
		}
		if (increaseButton.invalidReason != InvalidReason.None && num <= 0f)
		{
			invalidButtonDelegate?.Invoke(increaseButton.invalidReason);
			return;
		}
		assignmentPunch.Run();
		float currentMax = GetCurrentMax();
		if (num > 0f)
		{
			float num2 = delta;
			if (num2 > num)
			{
				num2 = num;
			}
			if (currentCount + num2 > maxCapacity)
			{
				num2 = maxCapacity - currentCount;
			}
			int num3 = 0;
			for (int i = 0; (float)i < num2; i++)
			{
				if (!TryBorrowCapacityFromOtherRecipe())
				{
					break;
				}
				num3++;
			}
			onManuallyChanged?.Invoke(currentCount + (float)num3);
		}
		else
		{
			float num4 = currentCount;
			num4 = ((!(num4 + (float)delta > currentMax)) ? (num4 + (float)delta) : currentMax);
			onManuallyChanged?.Invoke(num4);
		}
		UpdateButtonAvailability();
	}

	private float GetCurrentMax()
	{
		float num = currentCount + available;
		if (maxCapacity < num)
		{
			return maxCapacity;
		}
		return num;
	}

	public void OnIncreaseRightClicked()
	{
		if (increaseButton.invalidReason != InvalidReason.None)
		{
			invalidButtonDelegate?.Invoke(increaseButton.invalidReason);
			return;
		}
		assignmentPunch.Run();
		float currentMax = GetCurrentMax();
		onManuallyChanged?.Invoke(currentMax);
		UpdateButtonAvailability();
	}

	public void UpdateButtonAvailability()
	{
		if (disableControls)
		{
			decreaseButton.invalidReason = InvalidReason.ResearchAlreadyCompleted;
			decreaseButton.buttonState = CustomButtonState.Disabled;
		}
		else if (currentCount > 0f)
		{
			decreaseButton.invalidReason = InvalidReason.None;
			decreaseButton.buttonState = CustomButtonState.Default;
		}
		else
		{
			decreaseButton.invalidReason = InvalidReason.AlreadyAtZeroWorkers;
			decreaseButton.buttonState = CustomButtonState.Disabled;
		}
		InvalidReason invalidReason = InvalidReason.None;
		available = float.MaxValue;
		if (linkedBuildingState != null)
		{
			available = GameUtility.AsFloat(linkedBuildingState.numAvailable);
			if (available <= 0f)
			{
				invalidReason = InvalidReason.NotEnoughBuildings;
			}
		}
		if (overrideInvalidReason != InvalidReason.None)
		{
			invalidReason = overrideInvalidReason;
		}
		if (disableControls)
		{
			invalidReason = InvalidReason.ResearchAlreadyCompleted;
		}
		if (currentCount >= maxCapacity)
		{
			invalidReason = InvalidReason.MaxProductionCapacity;
		}
		increaseButton.invalidReason = invalidReason;
		if (invalidReason != InvalidReason.None || available <= 0f)
		{
			if (invalidReason == InvalidReason.NoExports)
			{
				increaseButton.buttonState = CustomButtonState.Invalid;
			}
			else
			{
				increaseButton.buttonState = CustomButtonState.Disabled;
			}
		}
		else if (MenuManager.Instance.isHighlightingWorkerAssignment)
		{
			increaseButton.buttonState = CustomButtonState.HighlightFlashing;
		}
		else
		{
			increaseButton.buttonState = CustomButtonState.Default;
		}
		if (linkedState != null && GameUtility.NotEquals(displayedCount, currentCount))
		{
			if (maxCapacity < float.MaxValue)
			{
				TextDisplay.SetFraction(currentCountLabel, currentCount, maxCapacity);
			}
			else
			{
				TextDisplay.SetNumber(currentCountLabel, currentCount);
			}
			displayedCount = currentCount;
		}
		if (!textFlashAnimation.isRunning)
		{
			currentCountLabel.color = (GameUtility.IsNearlyZero(currentCount) ? Color.gray : Color.white);
		}
		if (MenuManager.applyVisibilityChangesImmediately)
		{
			AnimateInstant();
		}
	}

	public void AnimateInstant()
	{
		increaseButton.AnimateInstant();
		decreaseButton.AnimateInstant();
		automaticAssignButton.AnimateInstant();
	}
}
