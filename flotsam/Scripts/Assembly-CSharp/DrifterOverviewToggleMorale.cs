using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrifterOverviewToggleMorale : SceneBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _countText;

	private Community _playerCommunity;

	private bool _update;

	private void Start()
	{
		_playerCommunity = Community.PlayerCommunity;
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnUpdate);
		GameEventDispatcher.AddListener(GameEventType.AgentRemovedFromPlayerCommunity, OnUpdate);
		GameEventDispatcher.AddListener(GameEventType.AgentMoraleUpdate, OnUpdate);
		UpdateIconAndCount();
	}

	private void LateUpdate()
	{
		if (_update)
		{
			UpdateIconAndCount();
			_update = false;
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.AgentMoraleUpdate, OnUpdate);
	}

	private void OnUpdate(GameEvent gameEvent = null)
	{
		_update = true;
	}

	private void UpdateIconAndCount()
	{
		_countText.text = _playerCommunity.Agents.Count.ToString();
		if (_playerCommunity.TryReturnCommunityMoraleCategory(out var communityMorale))
		{
			_icon.sprite = communityMorale.Icon;
		}
	}
}
