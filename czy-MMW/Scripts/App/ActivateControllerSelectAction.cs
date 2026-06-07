using Factory;

public class ActivateControllerSelectAction : PlayerAction
{
	[Dependency]
	private SwitchHardwareCapabilities _hardwareCapabilities;

	public override bool IsInterruptible => true;

	public override void OnActionBegin(float timestamp)
	{
		base.OnActionBegin(timestamp);
		_hardwareCapabilities.ActivateControllerSelect();
	}

	public override void Tick(float frameTime)
	{
		OnActionComplete();
	}
}
