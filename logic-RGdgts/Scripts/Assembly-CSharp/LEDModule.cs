using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LEDModule : Module
{
	public enum Commands
	{
		UpdateVisuals = 1
	}

	public SpriteRenderer ledLightRenderer;

	public Light2D ledLight;

	private Material ledLightMaterial;

	private ModuleProperty stateProperty;

	private ModuleProperty colorProperty;

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

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
