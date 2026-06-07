public class AnalogStickModule : Module
{
	public enum Commands
	{
		UpdateInputSource = 100
	}

	public class ValueChange_EventData : EventData
	{
		public double X;

		public double Y;

		public ValueChange_EventData()
		{
		}

		public ValueChange_EventData(float x, float y)
		{
		}
	}

	public InteractableJoystick interactableJoystick;

	private ModuleProperty xProperty;

	private ModuleProperty yProperty;

	private ModuleProperty inputSourceXProperty;

	private ModuleProperty inputSourceYProperty;

	protected override void OnSetupFinished()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateInputSources()
	{
	}
}
