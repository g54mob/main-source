using System;
using UnityEngine;

public class SliderModule : Module
{
	public enum Commands
	{
		UpdateInteractable = 1
	}

	public class ValueChange_EventData : EventData
	{
		public double Value;

		public ValueChange_EventData()
		{
		}

		public ValueChange_EventData(float value)
		{
		}
	}

	[Serializable]
	public struct RotationPreset
	{
		public Vector2Int origin;

		public int length;

		public int knobWidth;
	}

	private ModuleProperty valueProperty;

	private ModuleProperty isMovingProperty;

	public InteractableSlider interactableSlider;

	public RotationPreset[] rotationPresets;

	public override void SetRotation(int rotationI)
	{
	}

	protected override void OnSetupFinished()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	protected override void UpdateVisuals()
	{
	}
}
