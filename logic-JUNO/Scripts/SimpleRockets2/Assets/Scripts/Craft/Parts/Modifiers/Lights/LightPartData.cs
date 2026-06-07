using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	[Serializable]
	[DesignerPartModifier("Light")]
	public class LightPartData : PartModifierData<LightPartScript>
	{
		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 21, Label = "Extension Distance", Order = 30, Tooltip = "The extension distance of the light (in meters).")]
		private float _extension;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 15, Tooltip = "Changes the overall size of the light.", TechTreeIdForMaxValue = "MaxSize.Light")]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Base", Order = 10, Tooltip = "Toggles the base on/off where the light is mounted to the attached surface.")]
		private bool _hideBase;

		[SerializeField]
		[DesignerPropertySlider(0f, 1.5f, 16, Label = "Intensity", Order = 60, Tooltip = "The intensity of the light.")]
		private float _intensity = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _powerConsumptionScale = 1f;

		[SerializeField]
		[DesignerPropertySlider(50f, 2000f, 40, Label = "Range", Order = 50, Tooltip = "The maximum range (in meters) of the light.")]
		private float _range = 250f;

		[SerializeField]
		[DesignerPropertySlider(-180f, 180f, 73, Label = "Rotation", Order = 20, Tooltip = "The rotation of the light (in degrees).")]
		private float _rotation;

		[SerializeField]
		[DesignerPropertySlider(5f, 175f, 35, Label = "Spotlight Angle", Order = 40, Tooltip = "The spot light angle in degrees.")]
		private float _spotLightAngle = 30f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Cast Shadows", Order = 70, Tooltip = "Toggles the shadow casting in the light. Without shadows the performance impact of lights is greatly reduced.")]
		private bool _castShadows = true;

		public bool CastShadows
		{
			get
			{
				return _castShadows;
			}
			set
			{
				_castShadows = value;
				LightData lightData = base.Script?.Light?.Data;
				if (lightData != null)
				{
					lightData.CastShadows = _castShadows;
				}
			}
		}

		public float Extension
		{
			get
			{
				return _extension;
			}
			set
			{
				_extension = value;
			}
		}

		public bool HideBase
		{
			get
			{
				return _hideBase;
			}
			set
			{
				_hideBase = value;
			}
		}

		public float Intensity
		{
			get
			{
				return _intensity * (0.5f + _scale * _scale);
			}
			set
			{
				_intensity = value;
				LightData lightData = base.Script?.Light?.Data;
				if (lightData != null)
				{
					lightData.Intensity = Brightness;
				}
			}
		}

		public override float MassDry => Mathf.Abs(Scale * Scale * Scale) * (Mathf.Abs(0.5f * Extension) + (HideBase ? 1f : 2f)) * (float)((base.Version < 2) ? 100 : 15) * 0.01f;

		public float PowerConsumption => (1f + (Range - 250f) / 2000f) * Intensity * _powerConsumptionScale;

		public override long Price => (long)(Mathf.Pow(PowerConsumption * 10f, 2f) + MassDry * 10f * 100f);

		public float Range
		{
			get
			{
				return _range;
			}
			set
			{
				_range = value;
				LightData lightData = base.Script?.Light?.Data;
				if (lightData != null)
				{
					lightData.Range = value;
				}
			}
		}

		public float Rotation
		{
			get
			{
				return _rotation;
			}
			set
			{
				_rotation = value;
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

		public override string ScaleCareerID => "MaxSize.Light";

		public float SpotLightAngle
		{
			get
			{
				return _spotLightAngle;
			}
			set
			{
				_spotLightAngle = value;
				LightData lightData = base.Script?.Light?.Data;
				if (lightData != null)
				{
					lightData.SpotLightAngle = value;
				}
			}
		}

		private float Brightness => Intensity * (1.25f - _spotLightAngle / 180f);

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPartMaterialsChanged(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LightPartData x)
				{
					x.Script.InitializeLightModifier();
				});
			});
			d.OnPartStyleChanged(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LightPartData x)
				{
					x.Script.OnPartStyleChanged();
				});
			});
			d.OnPropertyChanged(() => _rotation, delegate
			{
				UpdateThingsAndStuffs(d);
			});
			d.OnPropertyChanged(() => _extension, delegate
			{
				UpdateThingsAndStuffs(d);
			});
			d.OnPropertyChanged(() => _hideBase, delegate
			{
				UpdateThingsAndStuffs(d);
			});
			d.OnValueLabelRequested(() => _intensity, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			Action<Action<LightScript>> lightScript = delegate(Action<LightScript> action)
			{
				if (base.Script.Light != null)
				{
					action(base.Script.Light);
				}
			};
			d.OnActivated(delegate
			{
				lightScript(delegate(LightScript x)
				{
					lightScript(delegate(LightScript lightScript2)
					{
						lightScript2.Data.Intensity = Brightness;
					});
					x.SetDesignerPreviewState(preview: true);
				});
			});
			d.OnDeactivated(delegate
			{
				lightScript(delegate(LightScript x)
				{
					x.SetDesignerPreviewState(preview: false);
				});
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				lightScript(delegate(LightScript x)
				{
					x.Data.Intensity = Brightness;
				});
				UpdateThingsAndStuffs(d);
			});
			d.OnPropertyChanged(() => _range, delegate(float newValue, float oldValue)
			{
				lightScript(delegate(LightScript x)
				{
					x.Data.Range = newValue;
				});
				lightScript(delegate(LightScript x)
				{
					x.Data.Intensity = Brightness;
				});
				UpdateThingsAndStuffs(d);
			});
			d.OnPropertyChanged(() => _intensity, delegate
			{
				lightScript(delegate(LightScript x)
				{
					x.Data.Intensity = Brightness;
				});
				UpdateThingsAndStuffs(d);
			});
			d.OnPropertyChanged(() => _spotLightAngle, delegate(float newValue, float oldValue)
			{
				lightScript(delegate(LightScript x)
				{
					x.Data.SpotLightAngle = newValue;
				});
				lightScript(delegate(LightScript x)
				{
					x.Data.Intensity = Brightness;
				});
				UpdateThingsAndStuffs(d);
			});
			d.OnPropertyChanged(() => _castShadows, delegate
			{
				lightScript(delegate(LightScript x)
				{
					x.Data.CastShadows = _castShadows;
				});
				UpdateThingsAndStuffs(d);
			});
		}

		private void UpdateThingsAndStuffs(IDesignerPartPropertiesModifierInterface d)
		{
			d.Manager.RefreshUI();
			base.Script.InitializeLight(calculateMinimumExtension: true);
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
