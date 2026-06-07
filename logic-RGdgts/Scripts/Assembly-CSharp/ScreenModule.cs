using UnityEngine;

public class ScreenModule : Module, IScreenModule
{
	public enum Commands
	{
		UpdateVideoChip = 1
	}

	public int width;

	public int height;

	public MeshRenderer screenRenderer;

	public InteractableProxy interactableProxy;

	private Mesh mesh;

	private Material material;

	private ModuleProperty videoChipProperty;

	private ModuleProperty offsetProperty;

	private ModuleProperty widthProperty;

	private ModuleProperty heightProperty;

	private VideoChipModule videoChip;

	private float touchStrength;

	private Vector2Int? touchPos;

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

	public void RebindVideoChip()
	{
	}

	protected override void ExecuteCommand(int commandId)
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

	public void Update()
	{
	}

	public void SetTouchCoord(Vector2Int? coord)
	{
	}
}
