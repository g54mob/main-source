using System.Linq;
using Assets.Scripts.Terrain.Rendering;
using ModApi.Planet;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class AtmosphereFlyoutScript : PlanetStudioFlyoutScript
	{
		public PlanetDataScript PlanetData => base.PlanetStudioUI.PlanetStudioScript?.CelestialBodyDesignerScript?.CurrentCelestialBody;

		private PlanetAtmosphereData AtmosphereData => PlanetData.AtmosphereData;

		protected override void RefreshUI()
		{
			base.RefreshUI();
			InspectorModel inspectorModel = new InspectorModel("Atmosphere", "Atmosphere");
			GroupModel atmosphere = new GroupModel("Atmosphere Physics");
			GroupModel groupModel = new GroupModel("Terrain & Atmosphere Visuals");
			AtmosphereShaderModel shaderModel = new AtmosphereShaderModel(PlanetData.SkyShaderData, PlanetData.TerrainShaderData, OnAtmosphereDataUpdated);
			ToggleModel hasAtmosphere = inspectorModel.AddAndBuild(new ToggleModel("Has Atmosphere", () => PlanetData.AtmosphereData.HasPhysicsAtmosphere, delegate(bool x)
			{
				atmosphere.Visible = x;
				PlanetData.AtmosphereData.HasPhysicsAtmosphere = x;
				PlanetData.SkyShaderEnabled = x;
				if (!x)
				{
					shaderModel.Target = AtmosphereShaderModel.TargetType.Terrain;
				}
			})).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "Toggles the atmosphere for the celestial body on and off.";
			}).Model;
			atmosphere.Visible = hasAtmosphere.Value;
			inspectorModel.Add(new NumericInputModel("Crush Altitude", () => AtmosphereData.CrushAltitude, delegate(double x)
			{
				AtmosphereData.CrushAltitude = x;
			})).Tooltip = "Altitude in meters used to destroy the player's craft if they get too close to the surface.";
			inspectorModel.AddGroup(atmosphere);
			inspectorModel.AddGroup(groupModel);
			AtmosphereData.GenerateInspectorModel(atmosphere, PlanetData);
			shaderModel.Target = ((!hasAtmosphere.Value) ? AtmosphereShaderModel.TargetType.Terrain : AtmosphereShaderModel.TargetType.Sky);
			SpinnerModel spinnerModel = new SpinnerModel(() => shaderModel.Target.ToString());
			spinnerModel.Tooltip = "Apply changes to just the sky or just the terrain or both at the same time.";
			groupModel.Add(spinnerModel);
			groupModel.AddAndBuild(new ColorModel("Noon Color", () => shaderModel.NoonColor, delegate(Color x)
			{
				shaderModel.NoonColor = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: true)).Build(delegate(ColorModel m)
			{
				m.DetermineVisibility = () => shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
			}).Model.Tooltip = "The color of direct sunlight.";
			groupModel.AddAndBuild(new ColorModel("Dusk Color", () => shaderModel.DuskColor, delegate(Color x)
			{
				shaderModel.DuskColor = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: true)).Build(delegate(ColorModel m)
			{
				m.DetermineVisibility = () => shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
			}).Model.Tooltip = "The color of tangent sunlight.";
			ColorModel colorModel = groupModel.Add(new ColorModel("Ambient Light Day", () => shaderModel.AmbientLightDay, delegate(Color x)
			{
				shaderModel.AmbientLightDay = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: true));
			ColorModel colorModel2 = groupModel.Add(new ColorModel("Ambient Light Night", () => shaderModel.AmbientLightNight, delegate(Color x)
			{
				shaderModel.AmbientLightNight = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: true));
			FloatInputModel floatInputModel = groupModel.Add(new FloatInputModel("Ambient Altitude Min", () => shaderModel.AmbientLightRangeMin, delegate(float x)
			{
				shaderModel.AmbientLightRangeMin = x;
			}));
			FloatInputModel floatInputModel2 = groupModel.Add(new FloatInputModel("Ambient Altitude Max", () => shaderModel.AmbientLightRangeMax, delegate(float x)
			{
				shaderModel.AmbientLightRangeMax = x;
			}));
			colorModel.Tooltip = "The ambient light during the day.";
			colorModel2.Tooltip = "The ambient light during the night.";
			floatInputModel.Tooltip = "At or below this altitude, ambient light is at its strongest.";
			floatInputModel2.Tooltip = "At or above this altitude, ambient light fades to nothing.";
			colorModel.DetermineVisibility = () => shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
			colorModel2.DetermineVisibility = () => shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
			floatInputModel.DetermineVisibility = () => shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
			floatInputModel2.DetermineVisibility = () => shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
			groupModel.AddAndBuild(new ColorModel("Wave Length", () => shaderModel.WaveLength, delegate(Color x)
			{
				shaderModel.WaveLength = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: true)).Build(delegate(ColorModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value;
			}).Build(delegate(ColorModel m)
			{
				m.Tooltip = "The wavelength of the light. Changing this can have drastic effects on atmospheric color.";
			});
			_ = groupModel.AddAndBuild(new SliderModel("Wave Length Magnitude", () => shaderModel.WaveLengthMag.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.WaveLengthMag = x;
			}, 0.1f, 2f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.WaveLengthMag);
			}).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value;
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "The magnitude of the wave length.";
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Sun Brightness", () => shaderModel.SunBrightness.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.SunBrightness = x;
			}, 0f, 100f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.SunBrightness);
			}).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value;
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "Increases or decreases the brightness of the sun.";
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Mie Scattering", () => shaderModel.MieScattering.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.MieScattering = x;
			}, 0f, 0.1f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(4, () => shaderModel.MieScattering);
			}).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value;
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "Mie scattering constant.";
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Rayleigh Scattering", () => shaderModel.RayleighScattering.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.RayleighScattering = x;
			}, 0f, 0.1f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(4, () => shaderModel.RayleighScattering);
			}).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value;
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "Rayleigh scattering constant.";
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Symmetry Scattering", () => shaderModel.SymmetryScattering.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.SymmetryScattering = x;
			}, -0.99f, 0.99f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(4, () => shaderModel.SymmetryScattering);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Affects the symmetry of the scattering.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => shaderModel.LerpIntensity && shaderModel.Target == AtmosphereShaderModel.TargetType.Sky;
				})
				.Model;
			_ = groupModel.AddAndBuild(new ToggleModel("Lerp Intensity", () => shaderModel.LerpIntensity, delegate(bool x)
			{
				shaderModel.LerpIntensity = x;
			}, "Change intensity based on current altitude, interpolating between a surface value and a space value.")).Build(delegate(ToggleModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value && shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
			}).Model;
			_ = groupModel.AddAndBuild(new SliderModel("Intensity", () => shaderModel.Intensity.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.Intensity = x;
			}, 0f, 20f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.Intensity);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Increases or decreases the intensity of the atmosphere.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => hasAtmosphere.Value && !shaderModel.LerpIntensity && shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Intensity from Space", () => shaderModel.IntensitySpace.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.IntensitySpace = x;
			}, 0f, 20f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.IntensitySpace);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Increases or decreases the intensity of the atmosphere when viewed from space.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => hasAtmosphere.Value && shaderModel.LerpIntensity && shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Intensity from Surface", () => shaderModel.IntensitySurface.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.IntensitySurface = x;
			}, 0f, 20f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.IntensitySurface);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Increases or decreases the intensity of the atmosphere when viewed the surface.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => hasAtmosphere.Value && shaderModel.LerpIntensity && shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Height Scale", () => shaderModel.AtmosSizeScale.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.AtmosSizeScale = x;
			}, 1f, 5f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.AtmosSizeScale);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Scales the visual height of the atmosphere.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => hasAtmosphere.Value;
				})
				.Model;
			_ = groupModel.AddAndBuild(new ToggleModel("Lerp Scale Depth", () => shaderModel.LerpScaleDepth == true, delegate(bool x)
			{
				shaderModel.LerpScaleDepth = x;
			})).Build(delegate(ToggleModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value;
			}).Build(delegate(ToggleModel m)
			{
				m.Tooltip = "Change scale depth based on current altitude, interpolating between a surface value and a space value.";
			})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Scale Depth", () => shaderModel.DensityScale.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.DensityScale = x;
			}, 0.002f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.DensityScale);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Increases or decreases the density of the atmosphere.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => hasAtmosphere.Value && shaderModel.LerpScaleDepth != true;
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Scale Depth from Space", () => shaderModel.DensityScaleSpace.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.DensityScaleSpace = x;
			}, 0.002f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.DensityScaleSpace);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Increases or decreases the density of the atmosphere when viewed from space.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => hasAtmosphere.Value && shaderModel.LerpScaleDepth == true;
				})
				.Model;
			_ = groupModel.AddAndBuild(new SliderModel("Scale Depth from Surface", () => shaderModel.DensityScaleSurface.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.DensityScaleSurface = x;
			}, 0.002f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.DensityScaleSurface);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Increases or decreases the density of the atmosphere when viewed from the surface.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => hasAtmosphere.Value && shaderModel.LerpScaleDepth == true;
				})
				.Model;
			groupModel.AddAndBuild(new SliderModel("Fresnel Bias", () => shaderModel.FresnelBias.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.FresnelBias = x;
			}, 0f, 0.5f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => $"{x:f2}";
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The fresnel bias used when lighting the terrain and water. This adjusts the strength of the reflected light off surfaces seen from a glancing angle. The default value is 0.";
			})
				.Build(delegate(SliderModel m)
				{
					m.DetermineVisibility = () => shaderModel.Target == AtmosphereShaderModel.TargetType.Terrain;
				});
			_ = groupModel.AddAndBuild(new SliderModel("Max Color Value", () => shaderModel.MaxColorValue.GetValueOrDefault(), delegate(float x)
			{
				shaderModel.MaxColorValue = x;
			}, 0.002f, 10f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => shaderModel.FormatSlider(2, () => shaderModel.MaxColorValue);
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Sets the maximum color values.  Use this to control the amount of bloom.";
			})
				.Model;
			_ = groupModel.AddAndBuild(new ToggleModel("Legacy Sky Shader", () => shaderModel.LegacySkyShader, delegate(bool x)
			{
				shaderModel.LegacySkyShader = x;
			}, "The sky shader was updated with some tweaks, notably to handle transparency differently.  This option allows existing planets to retain their original look.")).Build(delegate(ToggleModel m)
			{
				m.DetermineVisibility = () => hasAtmosphere.Value && shaderModel.Target == AtmosphereShaderModel.TargetType.Sky;
			}).Model;
			spinnerModel.NextClicked = delegate
			{
				if (hasAtmosphere.Value)
				{
					shaderModel.AdvanceTarget(1);
				}
			};
			spinnerModel.PrevClicked = delegate
			{
				if (hasAtmosphere.Value)
				{
					shaderModel.AdvanceTarget(-1);
				}
			};
			BuildFromModel(inspectorModel);
		}

		private void OnAtmosphereDataUpdated()
		{
			QuadSphereRenderer quadSphereRenderer = TerrainRendererManagerScript.Instance?.QuadSphereRenderers?.FirstOrDefault();
			if (quadSphereRenderer == null)
			{
				Debug.LogError("Unable to find the quad sphere renderer. Unable to update atmosphere data.");
				return;
			}
			quadSphereRenderer.PlanetData.ShaderDataSky.CopyFrom(PlanetData.SkyShaderData);
			quadSphereRenderer.PlanetData.ShaderDataTerrain.CopyFrom(PlanetData.TerrainShaderData);
			quadSphereRenderer.RefreshDataAndUpdateRenderer();
			ScaledSpaceRenderer scaledSpaceRenderer = (ScaledSpaceRenderer)TerrainRendererManagerScript.Instance.ScaledSpaceRenderers.FirstOrDefault((IScaledSpaceRenderer x) => x.Planet.PlanetNode.Name == PlanetData.Name);
			if (scaledSpaceRenderer == null)
			{
				Debug.LogError("Unable to find the scaled space renderer. Unable to update atmosphere data.");
				return;
			}
			scaledSpaceRenderer.PlanetData.ShaderDataSky.CopyFrom(PlanetData.SkyShaderData);
			scaledSpaceRenderer.PlanetData.ShaderDataTerrain.CopyFrom(PlanetData.TerrainShaderData);
			scaledSpaceRenderer.RefreshDataAndUpdateRenderer(currentPlanet: true);
		}
	}
}
