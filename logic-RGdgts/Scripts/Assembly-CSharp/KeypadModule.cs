using System.Collections.Generic;
using UnityEngine;

public class KeypadModule : Module
{
	private class Button
	{
		public int x;

		public int y;

		public InteractableButton interactable;

		public TurnableSpriteRendererAnimator symbolAnimator;

		public bool isPressed;

		public bool isDown;

		public bool isUp;
	}

	public enum Commands
	{
		UpdateInputSource = 100,
		UpdateHardware = 1000
	}

	public class Button_EventData : EventData
	{
		public double X;

		public double Y;

		public bool ButtonDown;

		public bool ButtonUp;

		public Button_EventData()
		{
		}

		public Button_EventData(int x, int y, bool buttonDown, bool buttonUp)
		{
		}
	}

	public Vector2Int buttonsCount;

	public HardwareSymbolAtlas symbolsAtlas;

	private Button[,] buttons;

	private ModuleProperty buttonsStateProperty;

	private ModuleProperty buttonsDownProperty;

	private ModuleProperty buttonsUpProperty;

	private ModuleProperty buttonsInputSourceProperty;

	private ModuleProperty hardwareSymbolsProperty;

	private bool hardwareChange;

	protected override void OnSetupFinished()
	{
	}

	public override void ApplyPermanentStorage(Storage storage, Storage permanentOnlyStorage = null)
	{
	}

	private void SetupStatesProperties()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	private bool GetButton(InteractableButton buttonObject, out Button button)
	{
		button = null;
		return false;
	}

	public void OnButtonDown(InteractableButton buttonObject)
	{
	}

	public void OnButtonUp(InteractableButton buttonObject)
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
