using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Propulsion;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	[Serializable]
	[DesignerPartModifier("Engine")]
	public class EngineData : PartModifierData<EngineScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _electricalConsumption;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _fuelConsumption;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 1f, 20, Label = "Max Thrust", Tooltip = "Allows increasing the maximum thrust of the engine at the cost of higher fuel consumption.")]
		private float _fuelConsumptionScale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Tooltip = "Defines the scale of the engine.", TechTreeIdForMaxValue = "MaxSize.Engine")]
		private float _scale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _fuelType = "LOX/RP1";

		[SerializeField]
		[DesignerPropertySlider(0f, 1.5f, 31, Label = "Gimbal Range", Tooltip = "The maximum allowable range that the engine can rotate to assist in controlling the craft's attitude. Setting to zero will disable gimbaling.")]
		private float _gimbalRange = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxGimbalAngle;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxTorque = 5f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _seaLevelEfficiency = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _supportsWarpBurn;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thrust;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _vacuumEfficiency;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColorInner = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _exhaustColorOutter = "Default";

		public Color ExhaustColorInner
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColorInner, out var color))
				{
					return color;
				}
				if (!ColorUtility.TryParseHtmlString("#2776F0", out var color2))
				{
					return color2;
				}
				return color2;
			}
		}

		public Color ExhaustColorOutter
		{
			get
			{
				if (ColorUtility.TryParseHtmlString(_exhaustColorOutter, out var color))
				{
					return color;
				}
				if (!ColorUtility.TryParseHtmlString("#0013FF", out var color2))
				{
					return color2;
				}
				return color2;
			}
		}

		public float ElectricalConsumption => _electricalConsumption * _fuelConsumptionScale * Scale;

		public float FuelConsumption => _fuelConsumption * _fuelConsumptionScale * Scale;

		public FuelType FuelType { get; private set; }

		public float GimbalRange
		{
			get
			{
				return _gimbalRange;
			}
			set
			{
				_gimbalRange = value;
			}
		}

		public float MaxGimbalAngle => _maxGimbalAngle;

		public float MaxTorque => _maxTorque;

		public float SeaLevelEfficiency => _seaLevelEfficiency;

		public bool SupportsWarpBurn => _supportsWarpBurn;

		public float Thrust => _thrust * _fuelConsumptionScale * Scale * 0.01f;

		public override float Scale
		{
			get
			{
				if (!(base.Part.PartType.Id != "IonEngine1"))
				{
					return _scale;
				}
				return 1f;
			}
			set
			{
				_scale = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.Engine";

		public float VacuumEfficiency => _vacuumEfficiency;

		public override long Price
		{
			get
			{
				if (!(base.Part.PartType.Id != "IonEngine1"))
				{
					return (long)(500000f * Scale);
				}
				return 0L;
			}
		}

		public override float MassDry
		{
			get
			{
				if (!(base.Part.PartType.Id != "IonEngine1"))
				{
					return ((base.Version == 1) ? 50f : (300f * Scale)) * 0.01f;
				}
				return 0f;
			}
		}

		public float GetIsp(float fuelDensity, float thrustEfficiency)
		{
			float num = FuelConsumption * fuelDensity;
			return Thrust * thrustEfficiency * 100f / (num * 9.81f);
		}

		public void SetBaseFuelConsumption(float consumption)
		{
			_fuelConsumption = consumption;
		}

		public void SetBaseThrust(float thrust)
		{
			_thrust = thrust;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnValueLabelRequested(() => _gimbalRange, (float x) => $"{x * 100f:n0}%");
			d.OnValueLabelRequested(() => _fuelConsumptionScale, (float x) => $"{x * 100f:n0}%");
			d.OnPropertyChanged(() => _fuelConsumptionScale, delegate
			{
				OnFuelConsumptionChanged();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateScale();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnVisibilityRequested(() => _gimbalRange, (bool x) => MaxGimbalAngle > 0f);
			d.OnVisibilityRequested(() => _scale, (bool x) => base.Part.PartType.Id == "IonEngine1");
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnActivated(delegate
			{
				base.Script.PreviewExhaust = true;
			});
			d.OnDeactivated(delegate
			{
				if (!base.Part.IsDestroyed)
				{
					base.Script.PreviewExhaust = false;
				}
			});
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			FuelType = Game.Instance.PropulsionData.GetFuelType(_fuelType);
		}

		private void OnFuelConsumptionChanged()
		{
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
