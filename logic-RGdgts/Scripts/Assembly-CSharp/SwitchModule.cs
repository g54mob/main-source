using System.Collections.Generic;
using UnityEngine;

public class SwitchModule : Module
{
	public enum Commands
	{
		UpdateInteractable = 1,
		UpdateHardware = 2,
		UpdateInputSource = 100
	}

	public class StateChanged_EventData : EventData
	{
		public bool State;

		public StateChanged_EventData()
		{
		}

		public StateChanged_EventData(bool state)
		{
		}
	}

	public InteractableSwitch interactableSwitch;

	public HardwareSymbolAtlas symbolsAtlas;

	public TurnableSpriteRenderer symbolRenderer;

	public Vector2Int symbolRendererOffsetWhenOff;

	public Vector2Int symbolRendererOffsetWhenOn;

	private TurnableSpriteRendererAnimator symbolAnimator;

	private ModuleProperty stateProperty;

	private ModuleProperty hardwareSymbolProperty;

	private ModuleProperty inputSourceProperty;

	private bool hardwareChange;

	public override void AllocResources()
	{
	}

	protected override void OnSetupFinished()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public override void RunCommand(int commandId)
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateInputSources()
	{
	}

	public override void SetRotation(int rotationI)
	{
	}

	protected override void UpdateVisuals()
	{
	}

	public void OnInteractableTurnOn()
	{
	}

	public void OnInteractableTurnOff()
	{
	}

	private void RefreshSymbolOffset()
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
