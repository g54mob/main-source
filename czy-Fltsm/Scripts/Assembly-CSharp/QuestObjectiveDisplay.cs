using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjectiveDisplay : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _objectiveText;

	[SerializeField]
	private Toggle _objectiveCompleteToggle;

	[SerializeField]
	private QuestTimerHandler _questTimerHandler;

	public void InitializeDisplay(IQuestObjective objective, QuestObjectives objectives)
	{
		UpdateDisplay(objective);
		if (objective.DaysTimeLimit > 0)
		{
			_questTimerHandler.SetActive(active: true, objectives.GetRemainingDaysCount(objective));
		}
		else
		{
			_questTimerHandler.SetActive(active: false);
		}
	}

	public void UpdateDisplay(IQuestObjective objective)
	{
		_objectiveText.text = objective.ToString();
		_objectiveCompleteToggle.isOn = objective.IsCompleted();
	}
}
