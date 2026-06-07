using TMPro;

public class LCDModule : Module
{
	public enum Commands
	{
		UpdateVisuals = 1
	}

	public TurnableSpriteRenderer bgRenderer;

	public TextMeshPro textRenderer;

	public int rows;

	public int columns;

	private ModuleProperty textProperty;

	private ModuleProperty bgColorProperty;

	private ModuleProperty textColorProperty;

	protected override void OnSetupFinished()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateVisuals()
	{
	}
}
