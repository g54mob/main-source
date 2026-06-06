using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogObjective : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _titleField;

	[SerializeField]
	private Image _check;

	public void Initialize(IQuestObjective objective)
	{
		_titleField.text = objective.ToString();
		_check.gameObject.SetActive(objective.IsCompleted());
	}
}
