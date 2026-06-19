public class ClickableGravityMachine : ClickableObject
{
	public GravityMachine mainMachineRef;

	protected override void OnClickInternal()
	{
		base.OnClickInternal();
		mainMachineRef.OnClick();
	}
}
