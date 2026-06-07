using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LEDButtonModule : Module
{
	public enum Commands
	{
		UpdateVisuals = 1,
		UpdateInputSource = 100,
		UpdateHardware = 1000
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

	public HardwareSymbolAtlas symbolsAtlas;

	public SpriteRenderer symbolRenderer;

	public SpriteRenderer symbolLightRenderer;

	public Light2D ledLight;

	public SpriteRenderer ledLightRenderer;

	private TurnableSpriteRendererAnimator[] symbolAnimators;

	private Material ledLightMaterial;

	private Material symbolLightMaterial;

	private bool isButtonPressed;

	private bool isButtonDown;

	private bool isButtonUp;

	private ModuleProperty buttonStateProperty;

	private ModuleProperty buttonDownProperty;

	private ModuleProperty buttonUpProperty;

	private ModuleProperty ledStateProperty;

	private ModuleProperty ledColorProperty;

	private ModuleProperty inputSourceProperty;

	private ModuleProperty hardwareSymbolProperty;

	private bool hardwareChange;

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

	protected override void UpdateInputSources()
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

	public override Dictionary<int, string> GetDynamicDataSelectionValues(int propertyId)
	{
		return null;
	}

	public override string GetDynamicDataSelectionName(int propertyId, Data.Selection selection)
	{
		return null;
	}

	public override bool IsHardwarePropertySupported(int propertyId)
	{
		return false;
	}
}
