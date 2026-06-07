using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[PartModifierTypeId("SubPartRotator")]
	public class SubPartRotatorData : PartModifierData<SubPartRotatorScript>
	{
		public enum AngleLerpType
		{
			Quaternion = 0,
			Euler = 1
		}

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _adjustableRate = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private AngleLerpType _angleLerp = AngleLerpType.Euler;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _currentEnabledPercent;

		[SerializeField]
		[Range(0f, 1f)]
		[PartModifierProperty(true, false)]
		private float _designerIconEnabledPercent;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _disabledRotation = Vector3.zero;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _enabledRotation = Vector3.zero;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _positionOffset = Vector3.zero;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _rotationRate = 0.1f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 41, Label = "Rotation Speed")]
		private float _rotationSpeed = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _selfGoverned = true;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Start Open")]
		private bool _startEnabled;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _startEnabledLabel = "Start Open";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _subPartPath = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _syncActivationGroup;

		public AngleLerpType AngleLerp => _angleLerp;

		public float CurrentEnabledPercent
		{
			get
			{
				return _currentEnabledPercent;
			}
			set
			{
				_currentEnabledPercent = value;
			}
		}

		public float DesignerIconEnabledPercent => _designerIconEnabledPercent;

		public Vector3 DisabledRotation
		{
			get
			{
				return _disabledRotation;
			}
			set
			{
				_disabledRotation = value;
			}
		}

		public Vector3 EnabledRotation
		{
			get
			{
				return _enabledRotation;
			}
			set
			{
				_enabledRotation = value;
			}
		}

		public Vector3 PositionOffset
		{
			get
			{
				return _positionOffset;
			}
			set
			{
				_positionOffset = value;
			}
		}

		public float RotationRate => _rotationRate * _rotationSpeed;

		public bool SelfGoverned => _selfGoverned;

		public bool StartEnabled
		{
			get
			{
				return _startEnabled;
			}
			set
			{
				_startEnabled = value;
			}
		}

		public string SubPartPath => _subPartPath;

		public bool SyncActivationGroup => _syncActivationGroup;

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnPropertyChanged(() => _startEnabled, delegate(bool newVal, bool oldVal)
			{
				base.Script.SetEnabledPercent(newVal ? 1f : 0f);
			});
			d.OnValueLabelRequested(() => _rotationSpeed, (float x) => Utilities.FormatPercentage(x));
			d.OnVisibilityRequested(() => _rotationSpeed, (bool x) => _adjustableRate);
			d.OnToggleButtonActivated(() => _startEnabled, delegate(IToggleButtonProperty x)
			{
				x.LabelValue = _startEnabledLabel;
			});
		}
	}
}
