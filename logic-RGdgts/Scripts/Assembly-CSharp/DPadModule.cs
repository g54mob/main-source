public class DPadModule : Module
{
	public enum Commands
	{
		UpdateInputSource = 100
	}

	public class DPadValueChange_EventData : EventData
	{
		public double X;

		public double Y;

		public DPadValueChange_EventData()
		{
		}

		public DPadValueChange_EventData(int x, int y)
		{
		}
	}

	public InteractableDPad interactableDPad;

	private ModuleProperty xProperty;

	private ModuleProperty yProperty;

	private ModuleProperty inputSourceXProperty;

	private ModuleProperty inputSourceYProperty;

	protected override void OnSetupFinished()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateInputSources()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}
}
