using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Gyroscope", PanelOrder = 2000)]
	public class GyroscopeData : PartModifierData<GyroscopeScript>
	{
		[SerializeField]
		[Tooltip("Electrical consumption in kilowatts")]
		[PartModifierProperty(true, false)]
		private float _electricalConsumption = 0.3f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _mass;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxAcceleration;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _power = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 51, Label = "Power", Tooltip = "Increase the power of the gyroscope at the cost of higher electricity usage.")]
		private float _powerScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _spoolupRatio = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _utilization = -1f;

		public float ElectricalConsumption => _electricalConsumption;

		public override float MassDry => _mass;

		public float MaxAcceleration => _maxAcceleration;

		public float Power => _power * _powerScale;

		public override long Price => Mathf.CeilToInt(((_utilization < 0f) ? 100f : 150f) * ((_powerScale <= 1f) ? 1f : (_powerScale * _powerScale)) * _mass * 100f);

		public float SpoolUpRatio => _spoolupRatio;

		public float Utilization
		{
			get
			{
				return _utilization;
			}
			set
			{
				_utilization = value;
			}
		}

		public void SetBasePowerAndMass(float power, float mass)
		{
			_power = power;
			_mass = mass;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _powerScale, (float x) => GetPowerLabel());
		}

		private string GetPowerLabel()
		{
			return $"{Power:n0} / {Utilities.FormatPercentage(_powerScale)}";
		}
	}
}
