using UnityEngine;

public class LandmarkActionSalvageUINew : LandmarkActionUI
{
	[SerializeField]
	private ChildBehaviourCache<LandmarkActionSalvageCategoryToggle> _toggleCache;

	[SerializeField]
	private ProjectMalfunctionPanel _projectMalfunctionPanel;

	private LandmarkActionSalvage _action;

	private ILandmarkActionStates _state;

	public void Initialize(LandmarkActionSalvage action)
	{
		base.Initialize(action);
		OnDisable();
		_action = action;
		_action.UpdatedEvent.AddListener(OnActionUpdated);
		_state = action.State;
		InitializeCategoryPanels();
		OnActionUpdated(action);
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAddedToCommunity);
	}

	private void InitializeCategoryPanels()
	{
		_toggleCache.Reset();
		foreach (LandmarkActionSalvage.Category category in _action.Categories)
		{
			if (!category.RequiresAssignmentType && !category.RequiresBuildable)
			{
				_toggleCache.Get().Initialize(_action, category);
			}
		}
		_toggleCache.Trim();
	}

	protected override void OnDisable()
	{
		if (_action != null)
		{
			_action.UpdatedEvent.RemoveListener(OnActionUpdated);
			_action = null;
		}
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAddedToCommunity);
	}

	private void OnAgentAddedToCommunity(GameEvent gameEvent)
	{
		InitializeCategoryPanels();
	}

	private void OnActionUpdated(ILandmarkAction landmarkAction)
	{
		if (_landmarkAction == landmarkAction)
		{
			if (_state != landmarkAction.State)
			{
				_state = landmarkAction.State;
				if (_state == ILandmarkActionStates.Active)
				{
					_projectMalfunctionPanel.Initialize(landmarkAction.Project);
				}
				else
				{
					_projectMalfunctionPanel.Uninitialize();
				}
			}
		}
		else
		{
			landmarkAction.UpdatedEvent.RemoveListener(OnActionUpdated);
		}
	}

	public override bool IsLandmarkActionUI(LandmarkAction landmarkAction)
	{
		return landmarkAction is LandmarkActionSalvage;
	}
}
