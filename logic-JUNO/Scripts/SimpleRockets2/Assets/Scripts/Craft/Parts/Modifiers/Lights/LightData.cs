using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	[Serializable]
	[DesignerPartModifier("Light")]
	public class LightData : PartModifierData<LightScript>
	{
		public enum LightModifierType
		{
			Spot = 0,
			Point = 1
		}

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Cast Shadows", Order = 70, Tooltip = "Toggles the shadow casting in the light. Without shadows the performance impact of lights is greatly reduced.")]
		private bool _castShadows = true;

		[SerializeField]
		[DesignerPropertyColorSliders(ShowAlpha = false, Order = 80, Tooltip = "The color of the light.")]
		private Color _color = Color.white;

		[SerializeField]
		[DesignerPropertySlider(0f, 5f, 51, Label = "Intensity", Order = 50, Tooltip = "The intensity of the light.")]
		private float _intensity = 1f;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Type", Order = 10, Tooltip = "The type the light. Spot lights are configured with a light angle. Point lights are omni-directional.")]
		private LightModifierType _lightType;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "", "Square1" }, Label = "Mask", ValidateManualInput = false, Order = 20, Tooltip = "The mask used to render the spotlight.")]
		private string _mask;

		[SerializeField]
		[DesignerPropertySpinner(-100f, 100f, 0.1f, Label = "Offset X", Order = 70, Tooltip = "The offset (in meters) on the X-axis relative to the center of the part at which the light is positioned.")]
		private float _offsetX;

		[SerializeField]
		[DesignerPropertySpinner(-100f, 100f, 0.1f, Label = "Offset Y", Order = 71, Tooltip = "The offset (in meters) on the Y-axis relative to the center of the part at which the light is positioned.")]
		private float _offsetY;

		[SerializeField]
		[DesignerPropertySpinner(-100f, 100f, 0.1f, Label = "Offset Z", Order = 72, Tooltip = "The offset (in meters) on the Z-axis relative to the center of the part at which the light is positioned.")]
		private float _offsetZ;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Part Glow", Order = 90, Tooltip = "If enabled, the part materials will become emissive based on light intensity when the light is enabled.")]
		private bool _partGlow = true;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Part Glow Self Shadow Casting", Order = 100, Tooltip = "If enabled, the part will continue to cast shadows when the light is enabled.")]
		private bool _partGlowSelfShadowCasting = true;

		[SerializeField]
		[DesignerPropertySlider(50f, 2000f, 40, Label = "Range", Order = 40, Tooltip = "The maximum range (in meters) of the light.")]
		private float _range = 250f;

		[SerializeField]
		[DesignerPropertySpinner(-180f, 180f, 5f, Label = "Rotation X", Order = 60, Tooltip = "The rotation of the light on the X-axis.")]
		private float _rotationX;

		[SerializeField]
		[DesignerPropertySpinner(-180f, 180f, 5f, Label = "Rotation Y", Order = 61, Tooltip = "The rotation of the light on the Y-axis.")]
		private float _rotationY;

		[SerializeField]
		[DesignerPropertySpinner(-180f, 180f, 5f, Label = "Rotation Z", Order = 62, Tooltip = "The rotation of the light on the Z-axis.")]
		private float _rotationZ;

		[SerializeField]
		[DesignerPropertySlider(5f, 175f, 35, Label = "Spotlight Angle", Order = 30, Tooltip = "The spot light angle in degrees.")]
		private float _spotLightAngle = 30f;

		public bool CastShadows
		{
			get
			{
				return _castShadows;
			}
			set
			{
				_castShadows = value;
				base.Script.SetDirty();
			}
		}

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
				base.Script.SetDirty();
			}
		}

		public float Intensity
		{
			get
			{
				return _intensity;
			}
			set
			{
				_intensity = value;
				base.Script.SetDirty();
			}
		}

		public LightModifierType LightType
		{
			get
			{
				return _lightType;
			}
			set
			{
				_lightType = value;
				base.Script.SetDirty();
			}
		}

		public string Mask
		{
			get
			{
				return _mask;
			}
			set
			{
				_mask = value;
				base.Script.SetDirty();
			}
		}

		public Vector3 Offset
		{
			get
			{
				return new Vector3(_offsetX, _offsetY, _offsetZ);
			}
			set
			{
				_offsetX = value.x;
				_offsetY = value.y;
				_offsetZ = value.z;
				base.Script.SetDirty();
			}
		}

		public bool PartGlow
		{
			get
			{
				return _partGlow;
			}
			set
			{
				_partGlow = value;
				base.Script.SetDirty();
			}
		}

		public bool PartGlowSelfShadowCasting
		{
			get
			{
				return _partGlowSelfShadowCasting;
			}
			set
			{
				_partGlowSelfShadowCasting = value;
				base.Script.SetDirty();
			}
		}

		public float Range
		{
			get
			{
				return _range;
			}
			set
			{
				_range = value;
				base.Script.SetDirty();
			}
		}

		public Vector3 Rotation
		{
			get
			{
				return new Vector3(_rotationX, _rotationY, _rotationZ);
			}
			set
			{
				_rotationX = value.x;
				_rotationY = value.y;
				_rotationZ = value.z;
				base.Script.SetDirty();
			}
		}

		public float SpotLightAngle
		{
			get
			{
				return _spotLightAngle;
			}
			set
			{
				_spotLightAngle = value;
				base.Script.SetDirty();
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnActivated(delegate
			{
				base.Script.SetDesignerPreviewState(preview: true);
			});
			d.OnDeactivated(delegate
			{
				base.Script.SetDesignerPreviewState(preview: false);
			});
			d.OnValueLabelRequested(() => _intensity, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _partGlow, delegate
			{
				base.Script.OnPartGlowChanged();
			});
			d.OnPropertyChanged(() => _partGlowSelfShadowCasting, delegate
			{
				base.Script.OnPartGlowChanged();
			});
			d.OnAnyPropertyChanged(delegate
			{
				base.Script.InitializeLight();
			});
			d.OnVisibilityRequested(() => _spotLightAngle, (bool x) => _lightType == LightModifierType.Spot);
			d.OnVisibilityRequested(() => _mask, (bool x) => _lightType == LightModifierType.Spot);
			d.OnValueLabelRequested(() => _mask, delegate(string x)
			{
				if (string.IsNullOrWhiteSpace(x))
				{
					return "Default";
				}
				return (x == "Square1") ? "Square" : x;
			});
		}
	}
}
