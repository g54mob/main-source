using UnityEngine;
using UnityEngine.UI;

public class CommunityMorale : SceneBehaviour
{
	[SerializeField]
	private Image _icon;

	private bool _updateState;

	private void Start()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentMoraleUpdate, AgentMoraleUpdate);
		UpdateState();
	}

	private void LateUpdate()
	{
		if (_updateState)
		{
			UpdateState();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentMoraleUpdate, AgentMoraleUpdate);
	}

	private void AgentMoraleUpdate(GameEvent gameEvent)
	{
		_updateState = true;
	}

	private void UpdateState()
	{
		if (Community.PlayerCommunity.TryReturnCommunityMoraleCategory(out var communityMorale))
		{
			_icon.sprite = communityMorale.Icon;
		}
	}
}
