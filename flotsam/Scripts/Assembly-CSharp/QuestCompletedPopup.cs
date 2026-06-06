using TMPro;
using UnityEngine;

public class QuestCompletedPopup : SceneBehaviour
{
	[SerializeField]
	private TMP_Text _questTitleLabel;

	private void OnDisable()
	{
		base.gameObject.SetActive(value: false);
	}

	public void Activate(Quest quest)
	{
		base.gameObject.SetActive(value: true);
		_questTitleLabel.gameObject.SetActive(value: false);
		_questTitleLabel.SetText(quest.Properties.QuestTitle);
	}
}
