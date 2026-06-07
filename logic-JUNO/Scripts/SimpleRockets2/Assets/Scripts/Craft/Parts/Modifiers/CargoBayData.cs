using System;
using System.Collections.Generic;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Cargo Bay")]
	public class CargoBayData : PartModifierData<CargoBayScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _hasBase = true;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Hinge Style", Order = 0, Tooltip = "How the cargo bay doors open, affecting both the hinge positions and the angle.")]
		private string _hingeStyle = "Sideways";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _open;

		[SerializeField]
		[DesignerPropertySlider(0f, 150f, 31, Label = "Open Angle", Order = 1, Tooltip = "The angle the cargo bay doors will open up to when activated.")]
		private float _openAngle = 90f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Open Speed", Order = 3, Tooltip = "The speed at which the cargo bay doors will open when activated.")]
		private float _openSpeed = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 41, Label = "Secondary Angle", Order = 2, Tooltip = "A multiplier to change how much the secondary door opens.")]
		private float _secondaryDoorAngle = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 11, Order = 3, Label = "Sound Volume", Tooltip = "Changes the volume of the sound made by this part.")]
		private float _soundVolume = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Start Open", Order = 0, Tooltip = "Determines if the cargo bay doors should start out open or closed.")]
		private bool _startOpen;

		public bool HasBase => _hasBase;

		public string HingeStyle => _hingeStyle;

		public bool Open
		{
			get
			{
				return _open;
			}
			set
			{
				_open = value;
			}
		}

		public float OpenAngle
		{
			get
			{
				return _openAngle;
			}
			set
			{
				_openAngle = value;
			}
		}

		public float OpenAngleSecondary => _secondaryDoorAngle;

		public float OpenSpeed
		{
			get
			{
				return _openSpeed;
			}
			set
			{
				_openSpeed = value;
			}
		}

		public float SoundVolume => _soundVolume;

		public bool StartOpen
		{
			get
			{
				return _startOpen;
			}
			set
			{
				_startOpen = value;
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPropertyChanged(() => _startOpen, delegate
			{
				OnPropertyChangedInDesigner(updateDoorImmediately: false);
			});
			d.OnPropertyChanged(() => _openAngle, delegate
			{
				OnPropertyChangedInDesigner(updateDoorImmediately: true);
			});
			d.OnPropertyChanged(() => _secondaryDoorAngle, delegate
			{
				OnPropertyChangedInDesigner(updateDoorImmediately: true);
			});
			d.OnPropertyChanged(() => _openSpeed, delegate
			{
				OnPropertyChangedInDesigner(updateDoorImmediately: false);
			});
			d.OnPropertyChanged(() => _hingeStyle, delegate
			{
				OnPropertyChangedInDesigner(updateDoorImmediately: true);
				base.Script.UpdateRotators();
			});
			d.OnValueLabelRequested(() => _openSpeed, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _openAngle, (float x) => x + "°");
			d.OnValueLabelRequested(() => _secondaryDoorAngle, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _soundVolume, (float x) => $"{x * 100f:n0}%");
			d.OnSpinnerValuesRequested(() => _hingeStyle, HingeStyles);
			d.OnVisibilityRequested(() => _secondaryDoorAngle, (bool x) => base.Part.Styles[0].Style.Id != "CargoBay-4" && base.Part.Styles[0].Style.Id != "CargoBay-5");
		}

		private void HingeStyles(List<string> obj)
		{
			obj.Clear();
			obj.Add("Sideways");
			obj.Add("Clamshell");
			obj.Add("Sliding");
		}

		private void OnPropertyChangedInDesigner(bool updateDoorImmediately)
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(CargoBayData data)
			{
				data._open = _startOpen;
				data.Script.UpdateDoorsInDesigner(updateDoorImmediately);
			});
		}
	}
}
