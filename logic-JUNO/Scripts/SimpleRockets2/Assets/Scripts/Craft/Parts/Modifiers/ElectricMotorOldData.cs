using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Electric Motor Old")]
	public class ElectricMotorOldData : PartModifierData<ElectricMotorOldScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _attachPointIndex;

		[SerializeField]
		[DesignerPropertySlider(0f, 3000f, 51, Order = 4, Label = "Brake Torque", Tooltip = "Changes the torque that the brake applies.", TechTreeIdForMaxValue = "ElectricMotor.Brake")]
		private float _brakeTorque;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _powerUsagePerTorque = 29f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2000f, 101, Order = 2, Label = "RPM", Tooltip = "Changes the target rotations per minute (RPM).", TechTreeIdForMaxValue = "ElectricMotor.RPM")]
		private float _rpm = 60f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 11, Order = 6, Label = "Sound Volume", Tooltip = "Changes the volume of the sound made by this part.")]
		private float _soundVolume = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 50f, 51, Order = 5, Label = "Static Resistance", Tooltip = "How much the motor resists free-spin.")]
		private float _staticResistance = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 3000f, 101, Order = 3, Tooltip = "Changes the torque that the motor applies.", TechTreeIdForMaxValue = "ElectricMotor.Torque")]
		private float _torque = 500f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Order = 1, Label = "Size", Tooltip = "Changes the overall size of the motor.", TechTreeIdForMaxValue = "MaxSize.ElectricMotor")]
		private float _scale = 1f;

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
				_brakeTorque = value;
			}
		}

		public float BrakeTorqueUnscaled => _brakeTorque;

		public override float MassDry
		{
			get
			{
				if (base.Version != 1)
				{
					return ((0.05f * _torque + _scale * _scale) * _scale * _scale - 10f) * 10f * 0.01f;
				}
				return 0f;
			}
		}

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

		public override long Price => (int)(Mathf.Pow(_torque * _scale, 1.3f) / Mathf.Pow(1.25f, _scale)) - 50000;

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
				return _staticResistance;
			}
			set
			{
				_staticResistance = value;
			}
		}

		public float Torque
		{
			get
			{
				return _torque * _scale;
			}
			set
			{
				_torque = value;
			}
		}

		public float TorqueUnscaled => _torque;

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
			d.OnValueLabelRequested(() => _soundVolume, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _staticResistance, (float x) => (x * 100f).ToString());
			d.OnValueLabelRequested(() => _torque, (float x) => (x * _scale).ToString());
			d.OnValueLabelRequested(() => _brakeTorque, (float x) => (x * _scale).ToString());
			d.OnPropertyChanged(() => _torque, delegate
			{
				d.Manager.RefreshUI();
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _scale, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateScale(repositionAttachedParts: true);
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
		}
	}
}
