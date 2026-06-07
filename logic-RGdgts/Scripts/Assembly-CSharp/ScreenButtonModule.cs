using UnityEngine;

public class ScreenButtonModule : Module, IScreenModule
{
	public enum Commands
	{
		UpdateVideoChip = 1,
		UpdateInputSource = 100
	}

	public class Button_EventData : EventData
	{
		public bool ButtonDown;

		public bool ButtonUp;

		public Button_EventData()
		{
		}

		public Button_EventData(bool buttonDown, bool buttonUp)
		{
		}
	}

	public InteractableButton interactableButton;

	public int width;

	public int height;

	public MeshRenderer screenRenderer;

	private Mesh mesh;

	private Material material;

	private bool isButtonPressed;

	private bool isButtonDown;

	private bool isButtonUp;

	private ModuleProperty videoChipProperty;

	private ModuleProperty buttonStateProperty;

	private ModuleProperty buttonDownProperty;

	private ModuleProperty buttonUpProperty;

	private ModuleProperty inputSourceProperty;

	private ModuleProperty offsetProperty;

	private ModuleProperty widthProperty;

	private ModuleProperty heightProperty;

	private VideoChipModule videoChip;

	private float originalBrightness;

	public Vector2Int GetSize()
	{
		return default(Vector2Int);
	}

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

	protected override void OnSetupFinished()
	{
	}

	public override void ApplyPermanentStorage(Storage storage, Storage permanentOnlyStorage = null)
	{
	}

	private void SetupSizeProperties()
	{
	}

	public override void SetRenderingMode(RenderingMode renderingMode, bool force = false)
	{
	}

	public override void OnTurnOn()
	{
	}

	public void OnInteractionDown()
	{
	}

	public void OnInteractionUp()
	{
	}

	public void RebindVideoChip()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateInputSources()
	{
	}

	public override void OnGadgetDeserialized()
	{
	}

	private void UpdateVideoChip()
	{
	}

	protected override void OnSolder()
	{
	}

	protected override void OnUnsolder()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected override void UpdateVisuals()
	{
	}

	public Vector2Int GetOrigin()
	{
		return default(Vector2Int);
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public void SetTouchCoord(Vector2Int? coord)
	{
	}
}
