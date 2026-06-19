using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalListItem : MonoBehaviour
{
	public GameObject checkMark;

	public GameObject unclaimedMark;

	public Image checkBoxImage;

	public Color colorClaimed;

	public Color colorUnclaimed;

	public Color colorIncomplete;

	public TextMeshProUGUI goalNameText;

	public CoreButtonUnityGUI goalButtonRef;

	private CursorUpdateArea updateAreaRef;

	private ColorBlock selectedBlock;

	private ColorBlock deselectedBlock;

	private int goalIndex = -1;

	private string goalID;

	private GoalsGUIManager goalsGUIRef;

	public void SetGoalsGUIRef(GoalsGUIManager newRef, CursorUpdateArea areaRef)
	{
		goalsGUIRef = newRef;
		updateAreaRef = areaRef;
	}

	public void OnCursorStay()
	{
		updateAreaRef.ReportCursorOverContent();
	}

	public void SetGoalName(string nameText)
	{
		goalNameText.text = nameText;
	}

	public void SetGoalIndexAndID(int index, string newID)
	{
		goalID = newID;
		goalIndex = index;
		checkMark.SetActive(value: false);
		unclaimedMark.SetActive(value: false);
		checkBoxImage.color = colorIncomplete;
		deselectedBlock = goalButtonRef.colors;
		switch (GoalsController.GetStatusForID(goalID))
		{
		case GoalStatus.CLAIMED:
			checkMark.SetActive(value: true);
			checkBoxImage.color = colorClaimed;
			deselectedBlock.normalColor = colorClaimed;
			deselectedBlock.pressedColor = colorClaimed;
			deselectedBlock.selectedColor = colorClaimed;
			goalButtonRef.colors = deselectedBlock;
			break;
		case GoalStatus.UNCLAIMED:
			unclaimedMark.SetActive(value: true);
			checkBoxImage.color = colorUnclaimed;
			break;
		}
		selectedBlock = default(ColorBlock);
		selectedBlock.colorMultiplier = 1f;
		selectedBlock.normalColor = colorUnclaimed;
		selectedBlock.pressedColor = colorUnclaimed;
		selectedBlock.selectedColor = colorUnclaimed;
		selectedBlock.disabledColor = colorUnclaimed;
		selectedBlock.highlightedColor = colorUnclaimed;
	}

	public void OnGoalSelected()
	{
		goalsGUIRef.SelectGoal(goalIndex);
		goalButtonRef.colors = selectedBlock;
	}

	public void OnGoalDeselected()
	{
		goalButtonRef.colors = deselectedBlock;
	}
}
