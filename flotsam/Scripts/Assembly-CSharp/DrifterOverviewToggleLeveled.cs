using TMPro;
using UnityEngine;

public class DrifterOverviewToggleLeveled : SceneBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _countText;

	private Community _playerCommunity;

	private void Start()
	{
		_playerCommunity = Community.PlayerCommunity;
		GameEventDispatcher.AddListener(GameEventType.AgentExperienceGained, OnAgentLevelGained);
		OnAgentLevelGained();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentExperienceGained, OnAgentLevelGained);
	}

	private void OnAgentLevelGained(GameEvent gameEvent = null)
	{
		int num = 0;
		foreach (Agent agent in _playerCommunity.Agents)
		{
			if (0 < agent.Attributes.SpendablePoints)
			{
				num++;
			}
		}
		if (num == 0)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.SetActive(value: true);
		_countText.text = num.ToString();
	}
}
