public class MapCameraModeToggle : UIInteractableToggle
{
	protected void OnEnable()
	{
		Awake();
		Toggle(FlotsamInputManager.ReturnCameraTownheartMovementInput());
	}

	public override void Toggle(bool toggled, bool sendEvent = false)
	{
		base.Toggle(toggled, sendEvent);
		FlotsamInputManager.ToggleCameraTownheartMovementInputToggle(toggled);
	}
}
