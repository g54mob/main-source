using TMPro;
using UnityEngine;

public class DrifterOverviewTogglePollution : SceneBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _countText;

	private Community _playerCommunity;

	private void Start()
	{
		_playerCommunity = Community.PlayerCommunity;
		GameEventDispatcher.AddListener(GameEventType.PollutionUpdated, OnAgentPollutionUpdated);
		OnAgentPollutionUpdated();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.PollutionUpdated, OnAgentPollutionUpdated);
	}

	private void OnAgentPollutionUpdated(GameEvent gameEvent = null)
	{
		int num = 0;
		foreach (Agent agent in _playerCommunity.Agents)
		{
			if (0f < agent.Vitals.Pollution.Level)
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
