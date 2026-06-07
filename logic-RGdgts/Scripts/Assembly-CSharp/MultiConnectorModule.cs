using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MultiConnectorModule : Module
{
	public enum Commands
	{
		ProcessPowerButtonPress = 1
	}

	public SpriteRenderer powerButtonLedLightRenderer;

	public Light2D powerButtonLedLight;

	private Material powerButtonLedLightMaterial;

	private bool isPowerButtonPressed;

	private ModuleProperty powerButtonStateProperty;

	public Color powerButtonLedColor => default(Color);

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
