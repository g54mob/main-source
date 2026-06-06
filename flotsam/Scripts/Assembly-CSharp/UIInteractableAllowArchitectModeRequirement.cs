public class UIInteractableAllowArchitectModeRequirement : UIInteractableRequirementBase
{
	private void OnEnable()
	{
		OnUIBlockersUpdated();
		GameEventDispatcher.AddListener(GameEventType.UIBlockersUpdated, OnUIBlockersUpdated);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.UIBlockersUpdated, OnUIBlockersUpdated);
	}

	public override bool ReturnIsMet()
	{
		return UIManager.AllowArchitectMode;
	}

	private void OnUIBlockersUpdated(GameEvent gameEvent = null)
	{
		if (base.IsMet != UIManager.AllowArchitectMode)
		{
			base.IsMet = UIManager.AllowArchitectMode;
		}
	}
}
