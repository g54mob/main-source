using System.Collections.Generic;

public class ResearchPanelUIInteractable : UIInteractable
{
	private List<BuildableProperties> _unlockableBuildables = new List<BuildableProperties>();

	protected override void Start()
	{
		base.Start();
		GameEventDispatcher.AddListener(GameEventType.ResearchPointsUpdated, UpdateNotification);
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, UpdateNotification);
		GameEventDispatcher.AddListener(GameEventType.ResearchStarted, UpdateNotification);
		GameEventDispatcher.AddListener(GameEventType.ResearchCancelled, UpdateNotification);
		GameEventDispatcher.AddListener(GameEventType.ResearchFinished, UpdateNotification);
		UpdateNotification(null);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.ResearchPointsUpdated, UpdateNotification);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, UpdateNotification);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStarted, UpdateNotification);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchCancelled, UpdateNotification);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, UpdateNotification);
	}

	public override void Interact()
	{
		if (base.IsInteractable)
		{
			base.Interact();
		}
	}

	private void UpdateNotification(GameEvent gameEvent)
	{
	}
}
