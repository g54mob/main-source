using System;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Activator")]
	public class InputBasedActivatorData : PartModifierData<InputBasedActivatorScript>
	{
		public enum ActivatorType
		{
			Activate = 0,
			ActivateOnly = 1,
			Deactivate = 2,
			DeactivateOnly = 3,
			Toggle = 4
		}

		public enum ActivatorUpdateMethod
		{
			OneTime = 0,
			OnChange = 1,
			Continuous = 2
		}

		[SerializeField]
		[DesignerPropertySpinner(Label = "Type", Order = 40, TextFormat = DesignerPropertySpinnerTextFormat.Auto)]
		private ActivatorType _activationType;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _currentState;

		[SerializeField]
		[DesignerPropertySpinner(-1f, 1f, 0.05f, Label = "Input Max", Order = 30)]
		private float _rangeEnd = 1f;

		[SerializeField]
		[DesignerPropertySpinner(-1f, 1f, 0.05f, Label = "Input Min", Order = 20)]
		private float _rangeStart = 1f;

		[SerializeField]
		[DesignerPropertySpinner(-7, 10, 1, Label = "Target", Order = 10)]
		private int _target;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Update Method", Order = 50, TextFormat = DesignerPropertySpinnerTextFormat.Auto)]
		private ActivatorUpdateMethod _updateMethod;

		public int ActivationTarget => _target;

		public ActivatorType ActivationType => _activationType;

		public bool CurrentState
		{
			get
			{
				return _currentState;
			}
			set
			{
				_currentState = value;
			}
		}

		public float RangeEnd => _rangeEnd;

		public float RangeStart => _rangeStart;

		public ActivatorUpdateMethod UpdateMethod => _updateMethod;

		protected override string GetDefaultInputId()
		{
			return "Activator";
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnValueLabelRequested(() => _target, GetTargetLabel);
		}

		private string GetTargetLabel(int target)
		{
			return target switch
			{
				0 => "Activate Part", 
				-1 => "Activate Stage", 
				-2 => "Lock Heading", 
				-3 => "Lock Prograde", 
				-4 => "Lock Retrograde", 
				-5 => "Lock Target", 
				-6 => "Lock Burn Node", 
				-7 => "Explode", 
				_ => "AG " + target, 
			};
		}
	}
}
