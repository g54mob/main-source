using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PowerButtonModule : Module
{
	public enum Commands
	{
		ProcessButtonPress = 1
	}

	public SpriteRenderer ledLightRenderer;

	public Light2D ledLight;

	private Material ledLightMaterial;

	private bool isPressed;

	private ModuleProperty buttonStateProperty;

	public Color ledColor => default(Color);

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

	protected override void OnSetupFinished()
	{
	}

	public override void OnTurnOn()
	{
	}

	public override void OnTurnOff()
	{
	}

	public override void OnMultitoolConnect()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateVisuals()
	{
	}

	public void OnInteractionDown()
	{
	}

	public void OnInteractionUp()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public override void OnPostTickUpdate()
	{
	}
}
