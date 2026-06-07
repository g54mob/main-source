using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Electric Motor")]
	public class ElectricMotorData : PartModifierData<ElectricMotorScript>
	{
		private const float MaxRpm = 10000f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _attachPointIndex;

		[SerializeField]
		[DesignerPropertySlider(0f, 3000f, 51, Order = 5, Label = "Brake Torque", Tooltip = "Changes the torque that the brake applies.", TechTreeIdForMaxValue = "ElectricMotor.Brake")]
		private float _brakeTorque;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _powerUsagePerTorque = 29f;

		[SerializeField]
		[DesignerPropertySlider(0f, 10000f, 101, Order = 3, Label = "RPM Clamp", Tooltip = "Sets a clamp for the RPM, so if the engine has an excess of torque it doesn't rip itself appart.", TechTreeIdForMaxValue = "ElectricMotor.RPM")]
		private float _rpm = 60f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Order = 1, Label = "Size", Tooltip = "Changes the overall size of the motor.", TechTreeIdForMaxValue = "MaxSize.ElectricMotor")]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 11, Order = 7, Label = "Sound Volume", Tooltip = "Changes the volume of the sound made by this part.")]
		private float _soundVolume = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 50f, 51, Order = 6, Label = "Static Resistance", Tooltip = "How much the motor resists free-spin.")]
		private float _staticResistance = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Throttle Governor", Order = 2, Tooltip = "If enabled, the motor's throttle input will act as an RPM selector, and throttle will be adjusted to maintain the desired RPM (and as long as the motor is sufficiently powerful).")]
		private bool _throttleGovernorEnabled = true;

		[SerializeField]
		[DesignerPropertySlider(0f, 3000f, 101, Order = 4, Tooltip = "Changes the torque that the motor applies.", TechTreeIdForMaxValue = "ElectricMotor.Torque")]
		private float _torque = 500f;

		public int AttachPointIndex
		{
			get
			{
				return _attachPointIndex;
			}
			set
			{
				_attachPointIndex = value;
			}
		}

		public float BrakeTorque
		{
			get
			{
				return _brakeTorque * _scale;
			}
			set
			{
				_brakeTorque = value / _scale;
			}
		}

		public float BrakeTorqueUnscaled => _brakeTorque;

		public override float MassDry => _scale * _scale * _scale * Mathf.Max(0f, _scale * _scale + _torque * 0.01f + 100f) * 0.01f;

		public float PowerUsagePerTorque
		{
			get
			{
				return _powerUsagePerTorque;
			}
			set
			{
				_powerUsagePerTorque = value;
			}
		}

		public override long Price => (int)(Mathf.Pow((1000f + _torque) * _scale, 1.3f) / Mathf.Pow(1.25f, _scale));

		public float Rpm
		{
			get
			{
				return _rpm;
			}
			set
			{
				_rpm = value;
			}
		}

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.ElectricMotor";

		public float SoundVolume => _soundVolume;

		public float StaticResistance
		{
			get
			{
				return _staticResistance * _scale * _scale;
			}
			set
			{
				_staticResistance = value;
			}
		}

		public bool ThrottleGovernorEnabled
		{
			get
			{
				return _throttleGovernorEnabled;
			}
			set
			{
				_throttleGovernorEnabled = value;
			}
		}

		public float Torque
		{
			get
			{
				return _torque * _scale * _scale * _scale * 15f;
			}
			set
			{
				_torque = value / (_scale * _scale * _scale * 5f);
			}
		}

		public float TorqueUnscaled
		{
			get
			{
				return _torque;
			}
			set
			{
				_torque = value;
			}
		}

		public void UpdateAttachPoint()
		{
			if (AttachPointIndex < base.Part.AttachPoints.Count)
			{
				AttachPoint attachPoint = base.Part.AttachPoints[AttachPointIndex];
				attachPoint.Position = new Vector3(0f, 0.4397f + 0.8f * (_scale - 1f), 0f);
				if (base.Part.PartScript != null && attachPoint.AttachPointScript != null)
				{
					attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
				}
			}
		}

		protected override string GetDefaultInputId()
		{
			return "Motor";
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _staticResistance, (float x) => Units.GetTorqueString(StaticResistance));
			d.OnValueLabelRequested(() => _torque, (float x) => Units.GetTorqueString(Torque));
			d.OnValueLabelRequested(() => _brakeTorque, (float x) => Units.GetTorqueString(BrakeTorque));
			d.OnValueLabelRequested(() => _rpm, (float x) => ((int)x).ToString());
			d.OnValueLabelRequested(() => _soundVolume, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _throttleGovernorEnabled, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			});
			d.OnPropertyChanged(() => _torque, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				base.Script.UpdateScale(repositionAttachedParts: true);
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyChanged(() => _rpm, delegate
			{
				d.Manager.RefreshUI();
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			});
		}
	}
}
