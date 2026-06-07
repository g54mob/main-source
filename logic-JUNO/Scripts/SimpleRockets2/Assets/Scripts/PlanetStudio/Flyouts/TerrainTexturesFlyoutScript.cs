using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.CelestialData;
using ModApi.Planet;
using ModApi.Planet.Modifiers.Material;
using ModApi.PlanetStudio;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class TerrainTexturesFlyoutScript : PlanetStudioFlyoutScript, ITextureSelector
	{
		private CelestialDatabase _db;

		private CelestialBodyDesignerScript _designer;

		private TerrainDetailSplatmap _splatmap;

		public PlanetDataScript PlanetData => base.PlanetStudioUI.PlanetStudioScript?.CelestialBodyDesignerScript?.CurrentCelestialBody;

		public void SelectTexture(TextureModel model, Action<string> onComplete)
		{
			base.PlanetStudioUI.CreateTexturePicker(null, delegate(SupportFileData s, string p)
			{
				model.Label = s.FriendlyName;
				onComplete(p);
			});
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_db = Game.Instance.CelestialDatabase;
			_designer = base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript;
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			InspectorModel inspectorModel = new InspectorModel("Terrain Textures", "Terrain Textures");
			List<TerrainDetailSplatmap> list = PlanetData?.TerrainData.GetModifiers<TerrainDetailSplatmap>();
			if (list != null && list.Count == 1)
			{
				_splatmap = list[0];
				BuildSplatmapModel(inspectorModel, _splatmap);
			}
			else if (list != null && list.Count > 1)
			{
				inspectorModel.Add(new LabelModel("Planet has multiple splatmaps, which is not currently supported for editing."));
			}
			else
			{
				inspectorModel.Add(new LabelModel("Planet does not support terrain textures"));
			}
			BuildFromModel(inspectorModel);
		}

		private void BuildSplatmapModel(InspectorModel model, TerrainDetailSplatmap splatmap)
		{
			int num = 1;
			foreach (TerrainDetailSplatmap.SplatTextures.SplatTexture texture in splatmap.DistanceBlendedTextures.Textures)
			{
				GroupModel groupModel = new GroupModel($"TEXTURE {num++}");
				model.AddGroup(groupModel);
				CelestialFileDesignerInfo celestialFileDesignerInfo = _designer.SupportFiles.Where((CelestialFileDesignerInfo x) => x.Id == texture.Path).FirstOrDefault();
				string label = string.Empty;
				if (celestialFileDesignerInfo != null)
				{
					label = _db.GetSupportFile(celestialFileDesignerInfo.File.Id).FriendlyName;
				}
				string textureFullPath = celestialFileDesignerInfo?.File.Path.FullPath;
				groupModel.AddAndBuild(new TextureModel(label, this, () => textureFullPath, delegate(string fullPath)
				{
					textureFullPath = fullPath;
					texture.Path = _designer.GetOrCreateSupportFileReference(fullPath);
				})).Build(delegate(TextureModel x)
				{
					x.Tooltip = "One of the terrain textures used by the celestial body. There can be up to 8 terrain textures used by a single celstial body. Textures must first be added here and then they may be selected on the Biomes flyout to choose where they are actually used on the body's surface. These are used as detail textures, brightening and darkening the base color of the surface. As such, only a single channel (red) from the texture is used. Red channel values above 0.5 (out of 0 to 1) will brighten the terrain color and values below will darken it.";
				});
				groupModel.AddAndBuild(new ToggleModel("Convert to Grayscale", () => texture.ConvertToGrayscale, delegate(bool x)
				{
					texture.ConvertToGrayscale = x;
				})).Build(delegate(ToggleModel x)
				{
					x.Tooltip = "Convert the texture to grayscale prior to sampling the red channel for the detail texture value used at runtime.";
				});
				groupModel.AddAndBuild(new SliderModel("Color Adjustment", () => texture.ColorAdjustment, delegate(float x)
				{
					texture.ColorAdjustment = x;
				}, -0.5f, 0.5f)).Build(delegate(SliderModel x)
				{
					x.Tooltip = "The constant value to add or subtract from every pixel value. Ideally, every texture should have an average color of 0.5 (from 0 to 1). If the average color is lower or higher, the texture can greatly impact the average brightness of the terrain where that texture is used. This setting is useful for adjusting that average color if the source texture is too bright or dim.";
				});
				groupModel.AddAndBuild(new SliderModel("Color Strength", () => texture.ColorStrength, delegate(float x)
				{
					texture.ColorStrength = x;
				}, 0f, 2.5f)).Build(delegate(SliderModel x)
				{
					x.Tooltip = "The detail textures brighten or darken the terrain when they are above or below the 0.5 color value (from 0 to 1). This setting acts as a multiplier to the difference of the pixel value from 0.5. This effectively magnifies the details of the texture.";
				});
			}
			GroupModel groupModel2 = new GroupModel("Add / Remove Terrain Textures");
			model.AddGroup(groupModel2);
			IconButtonRowModel iconButtonRowModel = new IconButtonRowModel();
			groupModel2.Add(iconButtonRowModel);
			IconButtonModel iconButtonModel = new IconButtonModel("Ui/Sprites/Common/IconAdd", delegate
			{
				OnAddTextureClicked();
			}, "Add a new terrain texture to this celestial body.");
			iconButtonModel.Style = ButtonModel.ButtonStyle.Primary;
			iconButtonModel.DetermineVisibility = () => splatmap.DistanceBlendedTextures.Textures.Count < 8;
			iconButtonRowModel.Add(iconButtonModel);
			IconButtonModel iconButtonModel2 = new IconButtonModel("Ui/Sprites/MapView/IconTrash", delegate
			{
				OnRemoveTextureClicked();
			}, "Removes the last texture from this celestial body.");
			iconButtonModel2.Style = ButtonModel.ButtonStyle.Warning;
			iconButtonModel2.DetermineVisibility = () => splatmap.DistanceBlendedTextures.Textures.Count > 0;
			iconButtonRowModel.Add(iconButtonModel2);
			DistanceBlendedTexturesConfiguration tilingCfg = splatmap.DistanceBlendedTextures.TilingConfiguration;
			GroupModel groupModel3 = new GroupModel("Advanced Tiling Configuration");
			TableRowModel headerRow = new TableRowModel();
			model.AddGroup(groupModel3);
			groupModel3.Collapsed = true;
			groupModel3.Add(new TextButtonModel("Reset Tiling", delegate
			{
				OnRegenerateTilingClicked(tilingCfg);
			})).Tooltip = "Regenerates the tiling numbers in the table below.";
			groupModel3.AddAndBuild(new SliderModel("Scaled UV Size Per Face", () => PlanetData.TerrainData.UVSizeExponent, delegate(float x)
			{
				PlanetData.TerrainData.UVSizeExponent = (int)x;
			}, 1f, 16f, wholeNumbers: true)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => Mathf.Pow(2f, v).ToString();
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The base UV scale for the celestial body when the camera is closer to the surface. This is a shared setting that impacts both the terrain and water. Texture mapping uses two different sets of UVs. The scaled UVs are used closer to the surface and the non-scaled UVs are used further away from the surface. The tiling level for non-scaled UVs represents how many times the texture is repeated over each of the six faces of the planet. The tiling level for scaled UVs is muliplied by this scaled UV size to represent how many times the texture is repeated. If this is set to 256 and the tiling level is set to 2 for a particular scaled UV level, then the actual texture tiling for that level would be 512.";
			});
			SpacerModel uvStartLevelSpacer = new SpacerModel(10);
			groupModel3.AddAndBuild(new SliderModel("Scaled UV Start Level", () => tilingCfg.ScaledUvStartLevel, delegate(float x)
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
			groupModel3.Add(headerRow);
			headerRow.Add(new LabelModel("Tiling", ElementAlignment.Center)).Tooltip = "The amount of tiling to apply to textures at this level. Lower levels are shown closer to the ground so more tiling is needed.";
			headerRow.Add(new LabelModel("Strength", ElementAlignment.Center)).Tooltip = "The strength of the texture at this level (typically from 0 to 1).";
			headerRow.Add(new SpacerModel(15, drawImage: false));
			for (int num2 = 0; num2 < splatmap.DistanceBlendedTextures.TilingConfiguration.Levels.Length; num2++)
			{
				if (num2 == tilingCfg.ScaledUvStartLevel)
				{
					groupModel3.Add(uvStartLevelSpacer);
				}
				TableRowModel tableRowModel = new TableRowModel();
				groupModel3.Add(tableRowModel);
				DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel level = tilingCfg.Levels[num2];
				tableRowModel.Add(new NumericInputModel(string.Empty, () => level.Tiling, delegate(double x)
				{
					UpdateTiling(level, (int)x, level.Strength);
				}, 0.0));
				tableRowModel.Add(new FloatInputModel(string.Empty, () => level.Strength, delegate(float x)
				{
					UpdateTiling(level, level.Tiling, x);
				}, 0f));
				tableRowModel.Add(new SpacerModel(15, drawImage: false));
			}
			groupModel3.Add(new SpacerModel(15, drawImage: false));
			groupModel3.AddAndBuild(new FloatInputModel("Distance Adjustment", () => tilingCfg.DistanceAdjustment, delegate(float x)
			{
				tilingCfg.DistanceAdjustment = x;
			})).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The distance adjustment value that is added to the distance which determines the tiling level. This adjustment is applied after the distance scalar is applied. \n\nExample: If the first tiling level lasts until about 100 meters and this adjustment value is -500, then the first tiling level will last until about 600 meters.";
			});
			groupModel3.AddAndBuild(new FloatInputModel("Distance Scalar", () => tilingCfg.DistanceScalar, delegate(float x)
			{
				tilingCfg.DistanceScalar = x;
			}, 0f)).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The distance scalar used to adjust the distance at which the tiling levels begin. Doubling this value will cause tiling levels to begin twice as early as normal.";
			});
		}

		private void OnAddTextureClicked()
		{
			base.PlanetStudioUI.CreateTexturePicker(null, delegate(SupportFileData s, string p)
			{
				_splatmap.DistanceBlendedTextures.Textures.Add(new TerrainDetailSplatmap.SplatTextures.SplatTexture
				{
					Path = _designer.GetOrCreateSupportFileReference(p),
					ColorAdjustment = 0f,
					ColorStrength = 1f,
					ConvertToGrayscale = false
				});
				base.PlanetStudioUI.CreateUndoStep(null, "Added Terrain Texture");
				RefreshUI();
			});
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

		private void OnRemoveTextureClicked()
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Please confirm that you want to remove the last terrain texture from this celestial body.";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				int num = _splatmap.DistanceBlendedTextures.Textures.Count - 1;
				if (num >= 0)
				{
					_splatmap.DistanceBlendedTextures.Textures.RemoveAt(num);
					base.PlanetStudioUI.CreateUndoStep(null, "Removed Terrain Texture");
					RefreshUI();
				}
			};
		}

		private void RegenerateTiling(DistanceBlendedTexturesConfiguration tilingCfg)
		{
			tilingCfg.ScaledUvStartLevel = 12;
			tilingCfg.DistanceAdjustment = 0f;
			tilingCfg.DistanceScalar = 1f;
			int num = 0;
			tilingCfg.Levels[num++].Tiling = 1600;
			tilingCfg.Levels[num++].Tiling = 1200;
			tilingCfg.Levels[num++].Tiling = 800;
			tilingCfg.Levels[num++].Tiling = 500;
			tilingCfg.Levels[num++].Tiling = 300;
			tilingCfg.Levels[num++].Tiling = 120;
			tilingCfg.Levels[num++].Tiling = 60;
			tilingCfg.Levels[num++].Tiling = 30;
			tilingCfg.Levels[num++].Tiling = 16;
			tilingCfg.Levels[num++].Tiling = 8;
			tilingCfg.Levels[num++].Tiling = 4;
			tilingCfg.Levels[num++].Tiling = 2;
			tilingCfg.Levels[num++].Tiling = 280;
			tilingCfg.Levels[num++].Tiling = 160;
			tilingCfg.Levels[num++].Tiling = 20;
			tilingCfg.Levels[num++].Tiling = 12;
			tilingCfg.Levels[num++].Tiling = 6;
			tilingCfg.Levels[num++].Tiling = 0;
			double num2 = PlanetData.Radius / 678000.0;
			DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel[] levels = tilingCfg.Levels;
			foreach (DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel distanceBlendedTextureLevel in levels)
			{
				distanceBlendedTextureLevel.Tiling = Mathf.Max(1, Mathf.RoundToInt((float)((double)distanceBlendedTextureLevel.Tiling * num2)));
			}
			RefreshUI();
			UpdateViewerTilingConfiguration();
		}

		private void UpdateTiling(DistanceBlendedTexturesConfiguration.DistanceBlendedTextureLevel level, int tiling, float strength)
		{
			level.Tiling = tiling;
			level.Strength = strength;
			UpdateViewerTilingConfiguration();
		}

		private void UpdateViewerTilingConfiguration()
		{
			TerrainDetailSplatmap terrainDetailSplatmap = _designer.CelestialBodyViewer?.PlanetScript?.QuadSphere?.TerrainGenerator?.TerrainMaterialModifier as TerrainDetailSplatmap;
			if (terrainDetailSplatmap == null)
			{
				Debug.LogError("Unable to find the " + typeof(TerrainDetailSplatmap).FullName + " terrain material modifier. Unable to update the tiling configuration.");
			}
			else
			{
				terrainDetailSplatmap.UpdateTilingConfiguration(_splatmap.DistanceBlendedTextures.TilingConfiguration);
			}
		}
	}
}
