using System.Collections.Generic;
using System.Linq;
using ModApi.Planet;
using ModApi.Planet.Modifiers.Material;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class WaterFlyoutScript : PlanetStudioFlyoutScript
	{
		private List<IGroupModel> _modelSubgroups;

		public CelestialBodyDesignerScript Designer => PlanetStudioScript.Instance.CelestialBodyDesignerScript;

		public PlanetDataScript PlanetData => Designer.CurrentCelestialBody;

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			InspectorModel inspectorModel = new InspectorModel("Water", "Water");
			inspectorModel.AddAndBuild(new ToggleModel("Has Water", () => PlanetData.HasWater, OnHasWaterChanged)).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "Toggles water on/off for the celestial body.";
			});
			inspectorModel.AddAndBuild(new FloatInputModel("Sea Level", () => PlanetData.SeaLevel, delegate(float x)
			{
				PlanetData.SeaLevel = x;
			})).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The sea level of the planet, relative to the planet radius.";
			});
			_modelSubgroups = PlanetData.TerrainData.WaterConfigDefault.BuildInspectorModel(isPlanetDefaultConfig: true, inspectorModel).ToList();
			if (PlanetData.HasWater)
			{
				WaterMaterialModifier waterMaterialModifier = PlanetData.TerrainData.GetWaterMaterialModifier();
				if (waterMaterialModifier == null)
				{
					waterMaterialModifier = PlanetData.TerrainData.CreateWaterMaterialModifier();
					SetTilingConfigDefaults(waterMaterialModifier.TilingConfiguration);
				}
				DistanceBlendedTexturesConfiguration tilingCfg = waterMaterialModifier.TilingConfiguration;
				GroupModel groupModel = new GroupModel("Advanced Tiling Configuration");
				inspectorModel.AddGroup(groupModel);
				groupModel.Collapsed = true;
				groupModel.Add(new TextButtonModel("Reset Tiling", delegate
				{
					OnRegenerateTilingClicked(tilingCfg);
				})).Tooltip = "Regenerates the tiling numbers in the table below.";
				TableRowModel headerRow = new TableRowModel();
				SpacerModel uvStartLevelSpacer = new SpacerModel(10);
				groupModel.AddAndBuild(new SliderModel("Scaled UV Start Level", () => tilingCfg.ScaledUvStartLevel, delegate(float x)
				{
					tilingCfg.ScaledUvStartLevel = (int)x;
				}, 1f, 19f, wholeNumbers: true)).Build(delegate(SliderModel x)
				{
					x.ValueFormatter = (float v) => ((int)v).ToString();
				}).Build(delegate(SliderModel x)
				{
					x.ValueChangedByUserInput += delegate(ItemModel sliderModel, string name, bool finished)
					{
						uvStartLevelSpacer.ItemElement.GameObject.GetComponent<RectTransform>().SetSiblingIndex(headerRow.ItemElement.GameObject.GetComponent<RectTransform>().GetSiblingIndex() + (int)((SliderModel)sliderModel).Value + 1);
					};
				})
					.Build(delegate(SliderModel x)
					{
						x.Tooltip = "The tiling level at which textures switch from using the regular UVs to using the scaled UVs. Texture mapping uses two different sets of UVs. The scaled UVs are used closer to the surface and the non-scaled UVs are used further away from the surface. The tiling level for non-scaled UVs represents how many times the texture is repeated over each of the six faces of the planet. The tiling level for scaled UVs is muliplied by the scaled UV size to represent how many times the texture is repeated.";
					});
				groupModel.Add(headerRow);
				headerRow.Add(new LabelModel("Tiling", ElementAlignment.Center)).Tooltip = "The amount of tiling to apply to textures at this level. Lower levels are shown closer to the ground so more tiling is needed.";
				headerRow.Add(new LabelModel("Strength", ElementAlignment.Center)).Tooltip = "The strength of the texture at this level.";
				headerRow.Add(new LabelModel("Wave Speed", ElementAlignment.Center)).Tooltip = "The movement speed of the texture at this level.";
				headerRow.Add(new LabelModel("Specular Scale", ElementAlignment.Center)).Tooltip = "The scalar applied to the specularity at this level.";
				for (int num = 0; num < tilingCfg.Levels.Length; num++)
				{
					if (tilingCfg.ScaledUvStartLevel == num)
					{
						groupModel.Add(uvStartLevelSpacer);
					}
					TableRowModel tableRowModel = new TableRowModel();
					groupModel.Add(tableRowModel);
					DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel level = tilingCfg.Levels[num];
					tableRowModel.AddAndBuild(new NumericInputModel(string.Empty, () => level.Tiling, delegate(double x)
					{
						UpdateTiling(level, (int)x, level.Strength, level.Data1, level.Data2);
					}, 0.0)).Build(delegate(NumericInputModel x)
					{
						x.Tooltip = "The texture tiling level for the water's normal map textures. The texture tiling changes as the camera gets closer to the surface. Each entry in this table from bottom to top represents the camera getting closer to the surface, with the top entry being the closest. Somewhere in the middle, based off the terrain splatmap's setting, the UV scale changes and thus the tiling levels specified here need to change as well to compenstate.";
					});
					tableRowModel.AddAndBuild(new FloatInputModel(string.Empty, () => level.Strength, delegate(float x)
					{
						UpdateTiling(level, level.Tiling, x, level.Data1, level.Data2);
					}, 0f)).Build(delegate(FloatInputModel x)
					{
						x.Tooltip = "The strength of the water's normal map textures, typically between 0 and 1. The strength can change as the camera gets closer to the surface. Each entry in this table from bottom to top represents the camera getting closer to the surface, with the top entry being the closest.";
					});
					tableRowModel.AddAndBuild(new FloatInputModel(string.Empty, () => level.Data1, delegate(float x)
					{
						UpdateTiling(level, level.Tiling, level.Strength, x, level.Data2);
					}, 0f)).Build(delegate(FloatInputModel x)
					{
						x.Tooltip = "The speed of the water's normal map textures (not the actual waves). The speed can change as the camera gets closer to the surface. Each entry in this table from bottom to top represents the camera getting closer to the surface, with the top entry being the closest.";
					});
					tableRowModel.AddAndBuild(new FloatInputModel(string.Empty, () => level.Data2, delegate(float x)
					{
						UpdateTiling(level, level.Tiling, level.Strength, level.Data1, x);
					}, 0f)).Build(delegate(FloatInputModel x)
					{
						x.Tooltip = "The specularity scale of the water, typically between 0 and 1. The specularity scale can change as the camera gets closer to the surface. Each entry in this table from bottom to top represents the camera getting closer to the surface, with the top entry being the closest.";
					});
				}
				groupModel.Add(new SpacerModel(15, drawImage: false));
				groupModel.AddAndBuild(new FloatInputModel("Distance Adjustment", () => tilingCfg.DistanceAdjustment, delegate(float x)
				{
					tilingCfg.DistanceAdjustment = x;
				})).Build(delegate(FloatInputModel x)
				{
					x.Tooltip = "The distance adjustment value that is added to the distance which determines the tiling level. This adjustment is applied after the distance scalar is applied. \n\nExample: If the first tiling level lasts until about 100 meters and this adjustment value is -500, then the first tiling level will last until about 600 meters.";
				});
				groupModel.AddAndBuild(new FloatInputModel("Distance Scalar", () => tilingCfg.DistanceScalar, delegate(float x)
				{
					tilingCfg.DistanceScalar = x;
				}, 0f)).Build(delegate(FloatInputModel x)
				{
					x.Tooltip = "The distance scalar used to adjust the distance at which the tiling levels begin. Doubling this value will cause tiling levels to begin twice as early as normal.";
				});
				_modelSubgroups.Add(groupModel);
			}
			BuildFromModel(inspectorModel);
			OnHasWaterChanged(PlanetData.HasWater);
		}

		private void OnHasWaterChanged(bool hasWater)
		{
			PlanetData.HasWater = hasWater;
			if (hasWater && PlanetData.TerrainData.GetWaterMaterialModifier() == null)
			{
				RefreshUI();
				return;
			}
			foreach (IGroupModel modelSubgroup in _modelSubgroups)
			{
				modelSubgroup.Visible = hasWater;
			}
		}

		private void OnRegenerateTilingClicked(DistanceBlendedTexturesConfiguration tilingCfg)
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "This will reset all tiling levels in the table below.";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				RegenerateTiling(tilingCfg);
			};
		}

		private void RegenerateTiling(DistanceBlendedTexturesConfiguration tilingCfg)
		{
			SetTilingConfigDefaults(tilingCfg);
			RefreshUI();
			UpdateViewerTilingConfiguration();
		}

		private void SetTilingConfigDefaults(DistanceBlendedTexturesConfiguration tilingCfg)
		{
			int num = 0;
			tilingCfg.DistanceAdjustment = 10f;
			tilingCfg.DistanceScalar = 1f;
			tilingCfg.ScaledUvStartLevel = 11;
			tilingCfg.Levels[num++].Update(2048, 1f, 0.02f, 0.95f);
			tilingCfg.Levels[num++].Update(1024, 1f, 0.02f, 0.95f);
			tilingCfg.Levels[num++].Update(512, 1f, 0.02f, 0.95f);
			tilingCfg.Levels[num++].Update(256, 1f, 0.02f, 0.95f);
			tilingCfg.Levels[num++].Update(128, 1f, 0.02f, 0.95f);
			tilingCfg.Levels[num++].Update(64, 1f, 0.02f, 0.95f);
			tilingCfg.Levels[num++].Update(32, 1f, 0.01f, 0.95f);
			tilingCfg.Levels[num++].Update(16, 1f, 0.01f, 0.925f);
			tilingCfg.Levels[num++].Update(8, 1f, 0.01f, 0.9f);
			tilingCfg.Levels[num++].Update(4, 0.9f, 0.01f, 0.85f);
			tilingCfg.Levels[num++].Update(2, 0.75f, 0.01f, 0.8f);
			tilingCfg.Levels[num++].Update(256, 0.65f, 0.005f, 0.8f);
			tilingCfg.Levels[num++].Update(256, 0.5f, 0.005f, 0.8f);
			tilingCfg.Levels[num++].Update(128, 0.25f, 0.005f, 0.7f);
			tilingCfg.Levels[num++].Update(128, 0.1f, 0.005f, 0.6f);
			tilingCfg.Levels[num++].Update(64, 0.05f, 0.005f, 0.6f);
			tilingCfg.Levels[num++].Update(64, 0.01f, 0.005f, 0.6f);
			tilingCfg.Levels[num++].Update(32, 0.01f, 0.005f, 0.6f);
			tilingCfg.Levels[num++].Update(16, 0.01f, 0.005f, 0.5f);
			tilingCfg.Levels[num++].Update(8, 0.01f, 0.005f, 0.5f);
			double num2 = PlanetData.Radius / 1274200.0;
			DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel[] levels = tilingCfg.Levels;
			foreach (DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel distanceBlendedTextureLevel in levels)
			{
				distanceBlendedTextureLevel.Tiling = Mathf.Max(1, Mathf.RoundToInt((float)((double)distanceBlendedTextureLevel.Tiling * num2)));
			}
		}

		private void UpdateTiling(DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel level, int tiling, float strength, float data1, float data2)
		{
			level.Tiling = tiling;
			level.Strength = strength;
			level.Data1 = data1;
			level.Data2 = data2;
			UpdateViewerTilingConfiguration();
		}

		private void UpdateViewerTilingConfiguration()
		{
			WaterMaterialModifier waterMaterialModifier = Designer.CelestialBodyViewer?.PlanetScript?.QuadSphere?.TerrainGenerator?.WaterMaterialModifier;
			if (waterMaterialModifier == null)
			{
				Debug.LogError("Unable to find the " + typeof(WaterMaterialModifier).FullName + " water material modifier. Unable to update the tiling configuration.");
				return;
			}
			WaterMaterialModifier waterMaterialModifier2 = PlanetData.TerrainData.GetWaterMaterialModifier();
			waterMaterialModifier.UpdateTilingConfiguration(waterMaterialModifier2.TilingConfiguration);
		}
	}
}
