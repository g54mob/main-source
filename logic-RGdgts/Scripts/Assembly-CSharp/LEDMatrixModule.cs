using UnityEngine;

public class LEDMatrixModule : Module
{
	public enum Commands
	{
		UpdateVisuals = 1
	}

	public SpriteRenderer ledLightRenderer;

	public int ledsWidth;

	public int ledsHeight;

	public int lightGroupWidth;

	public float lightIntensity;

	private Material ledLightMaterial;

	private Texture2D statusTexture;

	private ModuleProperty statesProperty;

	private ModuleProperty colorsProperty;

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

	private void SetupStatesProperties()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateVisuals()
	{
	}
}
