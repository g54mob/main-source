using TMPro;
using UnityEngine;

public class DrifterSpendablePointsWarning : AgentReferenceUIElement
{
	[SerializeField]
	private GameObject _levelUpWarning;

	[Tooltip("Amount of spendable points that have to be available before the warning shows.")]
	[SerializeField]
	private int _pointRequirement = 1;

	[SerializeField]
	private TextMeshProUGUI _pointField;

	protected override void Subscribe(Agent agent)
	{
		agent.Attributes.AvailableSpendingPointsUpdatedEvent.AddListener(UpdateLevel);
		UpdateLevel();
	}

	protected override void Unsubscribe(Agent agent)
	{
		agent.Attributes.AvailableSpendingPointsUpdatedEvent.RemoveListener(UpdateLevel);
	}

	private void UpdateLevel()
	{
		if (_agent.Attributes.SpendablePoints >= _pointRequirement)
		{
			if ((bool)_pointField)
			{
				_pointField.gameObject.SetActive(value: true);
				_pointField.text = _agent.Attributes.SpendablePoints.ToString();
			}
			_levelUpWarning.gameObject.SetActive(value: true);
		}
		else
		{
			if ((bool)_pointField)
			{
				_pointField.gameObject.SetActive(value: false);
			}
			_levelUpWarning.gameObject.SetActive(value: false);
		}
	}
}
