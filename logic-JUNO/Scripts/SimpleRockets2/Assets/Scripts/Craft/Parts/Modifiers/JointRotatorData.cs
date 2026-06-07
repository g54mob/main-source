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
	[DesignerPartModifier("Rotator")]
	public class JointRotatorData : PartModifierData<JointRotatorScript>
	{
		public enum BaseMode
		{
			Normal = 0,
			Extended = 1,
			None = 2
		}

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _allowFreeSpin = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _angle;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _attachPointIndex;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Base Style", Tooltip = "Changes the visual style of the base plate. Purely for cosmetic purposes.")]
		private BaseMode _baseMode;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Tooltip = "Changes the overall size of the joint.", TechTreeIdForMaxValue = "MaxSize.JointRotator")]
		private float _scale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _damperMultiplier = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _consumptionMultiplier;

		private float _lastRange = 90f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _maxRange = 180;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxSpeed = 270f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _minRange;

		[SerializeField]
		[DesignerPropertySlider(0f, 180f, 37, Tooltip = "Changes the range of rotation.")]
		private float _range = 90f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 11, Label = "Sound Volume", Tooltip = "Changes the volume of the sound made by this part.")]
		private float _soundVolume;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 11, Tooltip = "Changes the speed at which the part rotates.")]
		private float _speed = 0.5f;

		public override long Price => (long)(200f * base.Mass * Mathf.Lerp(0.1f, 1f, _speed));

		public override float MassDry
		{
			get
			{
				float num = Scale * (_baseMode.Equals(BaseMode.Extended) ? 1.5f : (_baseMode.Equals(BaseMode.Normal) ? 1.25f : 1f));
				if (base.Version != 1)
				{
					return 50f * num * num * num * 0.01f;
				}
				return 0.5f;
			}
		}

		public bool AllowFreeSpin
		{
			get
			{
				return _allowFreeSpin;
			}
			set
			{
				_allowFreeSpin = value;
			}
		}

		public float Angle
		{
			get
			{
				return _angle;
			}
			set
			{
				_angle = value;
			}
		}

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

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
				base.Script.UpdateScale(repositionAttachedParts: true);
			}
		}

		public override string ScaleCareerID => "MaxSize.JointRotator";

		public float DamperMultiplier
		{
			get
			{
				return _damperMultiplier;
			}
			set
			{
				_damperMultiplier = value;
			}
		}

		public float MaxSpeed
		{
			get
			{
				return _maxSpeed;
			}
			set
			{
				_maxSpeed = value;
			}
		}

		public BaseMode MeshBaseMode => _baseMode;

		public float Range
		{
			get
			{
				return _range;
			}
			set
			{
				_range = value;
			}
		}

		public float SoundVolume => _soundVolume;

		public float Speed
		{
			get
			{
				return _speed;
			}
			set
			{
				_speed = value;
			}
		}

		public float ConsumptionMultiplier => _consumptionMultiplier;

		public void Initialize()
		{
			UpdateInput(null);
		}

		public void UpdateAttachPoint()
		{
			if (AttachPointIndex < base.Part.AttachPoints.Count)
			{
				AttachPoint attachPoint = base.Part.AttachPoints[AttachPointIndex];
				attachPoint.Position = new Vector3(0f, 0.1f * _scale, 0f);
				if (base.Part.PartScript != null && attachPoint.AttachPointScript != null)
				{
					attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
				}
			}
		}

		protected override string GetDefaultInputId()
		{
			return "Rotator";
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _range, (float x) => (!(x < 0.0001f) || !AllowFreeSpin) ? (x + "°") : "Free Spin");
			d.OnPropertyChanged(() => _range, delegate(float newVal, float oldVal)
			{
				if (newVal < 0.0001f)
				{
					_speed = 0f;
				}
				_lastRange = newVal;
				UpdateInput(d);
			});
			d.OnValueLabelRequested(() => _speed, (float x) => (!(_range < 0.0001f) || !AllowFreeSpin) ? ((!(x < 0.0001f)) ? Utilities.FormatPercentage(x) : "Floppy") : "Disabled");
			d.OnPropertyChanged(() => _speed, delegate
			{
				if (_range < 0.0001f)
				{
					_speed = 0f;
				}
				UpdateInput(d);
			});
			d.OnPropertyChanged(() => _baseMode, delegate(BaseMode newVal, BaseMode oldVal)
			{
				base.Script.SetBaseMeshesActiveByMode(newVal);
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _scale, delegate
			{
				base.Script.UpdateScale(repositionAttachedParts: true);
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnSliderActivated(() => _range, delegate(ISliderProperty x)
			{
				x.UpdateSliderSettings(_minRange, _maxRange, (_maxRange - _minRange) / 5 + 1);
			});
			d.OnValueLabelRequested(() => _soundVolume, (float x) => $"{x * 100f:n0}%");
		}

		private void UpdateInput(IDesignerPartPropertiesModifierInterface d)
		{
			base.Script.VisibilityAngle(_speed > 0.0001f && _range > 0.0001f);
			d?.Manager.Flyout.RefreshUI();
		}
	}
}
