using TMPro;
using UnityEngine;

public class DrifterLevelCounter : AgentReferenceUIElement
{
	[SerializeField]
	private TMP_Text _text;

	protected override void Subscribe(Agent agent)
	{
		agent.Attributes.LevelIncreasedEvent.AddListener(UpdateLevel);
		UpdateLevel();
	}

	protected override void Unsubscribe(Agent agent)
	{
		agent.Attributes.LevelIncreasedEvent.RemoveListener(UpdateLevel);
	}

	private void UpdateLevel()
	{
		_text.text = _agent.Attributes.Level.ToString();
	}
}
