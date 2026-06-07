public class KnobModule : Module
{
	public enum Commands
	{
		UpdateInteractable = 1
	}

	public class ValueChange_EventData : EventData
	{
		public double Value;

		public double DeltaValue;

		public ValueChange_EventData()
		{
		}

		public ValueChange_EventData(float value, float deltaValue)
		{
		}
	}

	public InteractableKnob interactableKnob;

	private ModuleProperty valueProperty;

	private ModuleProperty isMovingProperty;

	private ModuleProperty deltaValueProperty;

	private ModuleProperty modeProperty;

	private float deltaValue;

	protected override void OnSetupFinished()
	{
	}

	private float PropertyValueFromInteractable(float value)
	{
		return 0f;
	}

	private float InteractableValueFromProperty(float value)
	{
		return 0f;
	}

	private void Update()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateVisuals()
	{
	}
}
