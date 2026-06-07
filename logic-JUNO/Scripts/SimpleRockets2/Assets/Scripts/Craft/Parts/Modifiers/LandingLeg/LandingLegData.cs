using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	[Serializable]
	[DesignerPartModifier("Landing Leg")]
	public class LandingLegData : PartModifierData<LandingLegScript>
	{
		private const float Density = 155f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _baseScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _currentExtensionPosition = Vector3.zero;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _currentRotation = new Vector3(0f, 0f, 0f);

		[SerializeField]
		[DesignerPropertySlider(30f, 60f, 7, Label = "Deployed Angle", Order = 1, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways, Tooltip = "Changes the angle the leg will rotate to when activated.")]
		private float _deployedAngle = 45f;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private float _deployedExtensionY;

		[SerializeField]
		[DesignerPropertySlider(25f, 100f, 16, Label = "Deploy Speed", Order = 3, Tooltip = "Changes the speed at which the leg will deploy.")]
		private float _deploySpeed = 25f;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private float _extensionPercentage;

		[SerializeField]
		[DesignerPropertySlider(-45f, 45f, 91, Label = "Foot Pivot", Order = 2, Tooltip = "Changes the rotation of the foot.")]
		private float _footPivot;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _footPivotAvailable;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _landingLegType;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _massHeight = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _massRadius = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 0, Tooltip = "Changes the overall size of the part.", TechTreeIdForMaxValue = "MaxSize.LandingLeg")]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 11, Order = 3, Label = "Sound Volume", Tooltip = "Changes the volume of the sound made by this part.")]
		private float _soundVolume = 0.5f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Start Deployed", Order = 20, Tooltip = "Determines if the landing leg should start deployed or not.")]
		private bool _startDeployed;

		public float BaseScale => _baseScale;

		public Vector3 CurrentExtensionPosition
		{
			get
			{
				return _currentExtensionPosition;
			}
			set
			{
				_currentExtensionPosition = value;
			}
		}

		public Vector3 CurrentRotation
		{
			get
			{
				return _currentRotation;
			}
			set
			{
				_currentRotation = value;
			}
		}

		public float DeployedAngle
		{
			get
			{
				return _deployedAngle;
			}
			set
			{
				_deployedAngle = value;
			}
		}

		public float DeployedExtensionY => _deployedExtensionY;

		public float DeploySpeed => _deploySpeed;

		public float ExtensionPercentage
		{
			get
			{
				return _extensionPercentage;
			}
			set
			{
				_extensionPercentage = value;
			}
		}

		public int LandingLegType => _landingLegType;

		public float FootPivot
		{
			get
			{
				return _footPivot;
			}
			set
			{
				_footPivot = value;
			}
		}

		public override float MassDry => CalculateVolume() * 155f * 0.01f;

		public override long Price => (long)(100000f * CalculateVolume());

		public bool PropertiesOpen { get; set; }

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
				base.Script.UpdateScale();
			}
		}

		public override string ScaleCareerID => "MaxSize.LandingLeg";

		public float SoundVolume => _soundVolume;

		public bool StartDeployed
		{
			get
			{
				return _startDeployed;
			}
			set
			{
				_startDeployed = value;
			}
		}

		public float CalculateVolume()
		{
			float num = _massHeight * _scale * _baseScale;
			float num2 = _massRadius * _scale * _baseScale;
			return MathF.PI * (num2 * num2) * num;
		}

		public void UpdateScale()
		{
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, _scale, delegate(LandingLegData x, float y)
			{
				x.Scale = y;
			});
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.DesignerPartProperties.OnActivated(delegate
			{
				UpdateProperties(d);
			});
			d.OnVisibilityRequested(() => _footPivot, (bool x) => _footPivotAvailable);
			d.OnVisibilityRequested(() => _soundVolume, (bool x) => _landingLegType > 0);
			d.OnValueLabelRequested(() => _deployedAngle, (float x) => x + "°");
			d.OnValueLabelRequested(() => _footPivot, (float x) => x + "°");
			d.OnValueLabelRequested(() => _scale, (float x) => (int)(x * 100f + 0.5f) + "%");
			d.OnValueLabelRequested(() => _soundVolume, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _deployedAngle, delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: false, _deployedAngle, delegate(LandingLegData x, float y)
				{
					x.DeployedAngle = y;
				});
			});
			d.OnPropertyChanged(() => _footPivot, delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: false, _footPivot, delegate(LandingLegData x, float y)
				{
					x.FootPivot = y;
				});
			});
			d.OnPropertyChanged(() => _startDeployed, delegate(bool newVal, bool oldVal)
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LandingLegData x)
				{
					x.Script.SetStartDeployed(newVal);
				});
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				UpdateScale();
			});
			d.OnActivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LandingLegData x)
				{
					x.PropertiesOpen = true;
				});
			});
			d.OnDeactivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LandingLegData x)
				{
					x.PropertiesOpen = false;
				});
			});
		}

		private void UpdateProperties(IDesignerPartPropertiesModifierInterface d)
		{
			if (_landingLegType == 2)
			{
				d.GetSliderProperty(() => _deployedAngle).UpdateSliderSettings(100f, 150f, 11);
			}
			else if (_landingLegType == 3)
			{
				d.GetSliderProperty(() => _deployedAngle).UpdateSliderSettings(0f, 70f, 71);
			}
			else
			{
				d.GetSliderProperty(() => _deployedAngle).UpdateSliderSettings(30f, 60f, 7);
			}
		}
	}
}
