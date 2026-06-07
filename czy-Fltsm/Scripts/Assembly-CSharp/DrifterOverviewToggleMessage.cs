using TMPro;
using UnityEngine;

public class DrifterOverviewToggleMessage : SceneBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _countText;

	private Community _playerCommunity;

	private bool _updateState;

	private void Start()
	{
		_playerCommunity = Community.PlayerCommunity;
		GameEventDispatcher.AddListener(GameEventType.AgentMessageUpdated, OnAgentMessageUpdated);
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentMessageUpdated);
		OnAgentMessageUpdated();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentMessageUpdated, OnAgentMessageUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentMessageUpdated);
	}

	private void OnAgentMessageUpdated(GameEvent gameEvent = null)
	{
		int num = 0;
		foreach (Agent agent in _playerCommunity.Agents)
		{
			if (agent.ReturnHasMessageQueued())
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
