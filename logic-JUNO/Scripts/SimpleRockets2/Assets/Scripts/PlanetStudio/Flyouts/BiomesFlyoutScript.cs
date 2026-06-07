using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using ModApi.CelestialData;
using ModApi.Common;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Planet.CustomData;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.Material;
using ModApi.Planet.Modifiers.VertexData.Biomes;
using ModApi.PlanetStudio;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class BiomesFlyoutScript : PlanetStudioFlyoutScript, ITextureSelector
	{
		public class BiomeModel
		{
			private AltitudeBasedSubBiomes _altitudeBasedSubBiomes;

			private SingleSubBiome _singleSubBiome;

			private SingleValueBasedSubBiomes _singleValueBasedSubBiomes;

			public AltitudeBasedSubBiomes AltitudeBasedBiomesModifier => _altitudeBasedSubBiomes;

			public PlanetBiome Biome { get; }

			public bool CanAddSubBiomes { get; private set; }

			public bool IsAltitudeBased { get; }

			public string Name { get; }

			public SingleValueBasedSubBiomes SingleValueBasedBiomesModifier => _singleValueBasedSubBiomes;

			public List<SubBiomeModel> SubBiomes { get; } = new List<SubBiomeModel>();

			public BiomeModel(AltitudeBasedSubBiomes altitudeBasedSubBiomes)
			{
				_altitudeBasedSubBiomes = altitudeBasedSubBiomes;
				IsAltitudeBased = true;
				Biome = altitudeBasedSubBiomes.Biome;
				Name = altitudeBasedSubBiomes.Biome.Name;
				CanAddSubBiomes = true;
				if (altitudeBasedSubBiomes.SubBiomes != null)
				{
					AltitudeBasedSubBiomes.AltitudeRange[] subBiomes = altitudeBasedSubBiomes.SubBiomes;
					for (int i = 0; i < subBiomes.Length; i++)
					{
						SubBiomeModel item = new SubBiomeModel(subBiomes[i]);
						SubBiomes.Add(item);
					}
				}
				RefreshSubBiomes();
			}

			public BiomeModel(SingleValueBasedSubBiomes singleValueBasedSubBiomes)
			{
				_singleValueBasedSubBiomes = singleValueBasedSubBiomes;
				Biome = singleValueBasedSubBiomes.Biome;
				Name = singleValueBasedSubBiomes.Biome.Name;
				CanAddSubBiomes = true;
				if (singleValueBasedSubBiomes.SubBiomes != null)
				{
					SingleValueBasedSubBiomes.ValueRange[] subBiomes = singleValueBasedSubBiomes.SubBiomes;
					for (int i = 0; i < subBiomes.Length; i++)
					{
						SubBiomeModel item = new SubBiomeModel(subBiomes[i]);
						SubBiomes.Add(item);
					}
				}
				RefreshSubBiomes();
			}

			public BiomeModel(SingleSubBiome singleSubBiome)
			{
				_singleSubBiome = singleSubBiome;
				Biome = singleSubBiome.Biome;
				Name = singleSubBiome.Biome.Name;
				SubBiomeModel item = new SubBiomeModel(singleSubBiome.SubBiome);
				SubBiomes.Add(item);
				CanAddSubBiomes = false;
				RefreshSubBiomes();
			}

			public void ApplySubBiomes()
			{
				SubBiomeModel previous = null;
				foreach (SubBiomeModel subBiome in SubBiomes)
				{
					subBiome.Apply(previous);
					previous = subBiome;
				}
				RefreshSubtitles();
			}

			public void RefreshSubtitles()
			{
				foreach (SubBiomeModel subBiome in SubBiomes)
				{
					subBiome.UpdateGroupSubtitle();
				}
			}

			public void SwapSubBiomes(int subBiomeIndex, int swapIndex)
			{
				MinMaxValue minMax = SubBiomes[subBiomeIndex].MinMax;
				SubBiomes[subBiomeIndex].MinMax = SubBiomes[swapIndex].MinMax;
				SubBiomes[swapIndex].MinMax = minMax;
				if (SingleValueBasedBiomesModifier != null)
				{
					SingleValueBasedSubBiomes.ValueRange valueRange = SingleValueBasedBiomesModifier.SubBiomes[subBiomeIndex];
					SingleValueBasedBiomesModifier.SubBiomes[subBiomeIndex] = SingleValueBasedBiomesModifier.SubBiomes[swapIndex];
					SingleValueBasedBiomesModifier.SubBiomes[swapIndex] = valueRange;
				}
				else if (AltitudeBasedBiomesModifier != null)
				{
					AltitudeBasedSubBiomes.AltitudeRange altitudeRange = AltitudeBasedBiomesModifier.SubBiomes[subBiomeIndex];
					AltitudeBasedBiomesModifier.SubBiomes[subBiomeIndex] = AltitudeBasedBiomesModifier.SubBiomes[swapIndex];
					AltitudeBasedBiomesModifier.SubBiomes[swapIndex] = altitudeRange;
				}
			}

			private void RefreshSubBiomes()
			{
				SubBiomeModel subBiomeModel = null;
				foreach (SubBiomeModel subBiome in SubBiomes)
				{
					if (subBiomeModel != null)
					{
						_ = subBiomeModel.MinMax;
						_ = subBiomeModel.MinMax;
						subBiome.BlendOverlap = Mathf.InverseLerp(subBiomeModel.MinMax.MaxValue, subBiomeModel.MinMax.MinValue, subBiome.MinMax.MinValue);
						subBiome.Size = subBiome.MinMax.MaxValue - subBiomeModel.MinMax.MaxValue;
					}
					else
					{
						subBiome.BlendOverlap = 0f;
						subBiome.Size = subBiome.MinMax.MaxValue - subBiome.MinMax.MinValue;
					}
					subBiomeModel = subBiome;
				}
			}
		}

		public class SubBiomeModel
		{
			private bool _editFlatStyle;

			private SubBiomeData _singleSubBiome;

			private AltitudeBasedSubBiomes.AltitudeRange _subBiomeAltitude;

			private SingleValueBasedSubBiomes.ValueRange _subBiomeValue;

			public float AngleEnd
			{
				get
				{
					return SubBiomeData.SlopeRange.MaxValue;
				}
				set
				{
					MinMaxValue slopeRange = SubBiomeData.SlopeRange;
					slopeRange.MaxValue = Mathf.Clamp01(value);
					slopeRange.MinValue = Mathf.Clamp(slopeRange.MinValue, 0f, slopeRange.MaxValue);
					SubBiomeData.SlopeRange = slopeRange;
				}
			}

			public float AngleStart
			{
				get
				{
					return SubBiomeData.SlopeRange.MinValue;
				}
				set
				{
					MinMaxValue slopeRange = SubBiomeData.SlopeRange;
					slopeRange.MinValue = Mathf.Clamp01(value);
					slopeRange.MaxValue = Mathf.Clamp(slopeRange.MaxValue, slopeRange.MinValue, 1f);
					SubBiomeData.SlopeRange = slopeRange;
				}
			}

			public float BlendOverlap { get; set; }

			public SubBiomeTerrainData Data { get; private set; }

			public bool EditFlatStyle
			{
				get
				{
					return _editFlatStyle;
				}
				set
				{
					_editFlatStyle = value;
					if (_editFlatStyle)
					{
						Data = SubBiomeData.PrimaryData;
					}
					else
					{
						Data = SubBiomeData.SlopeData;
					}
				}
			}

			public string EndText { get; set; }

			public GroupModel GroupModel { get; set; }

			public MinMaxValue MinMax
			{
				get
				{
					if (_subBiomeAltitude == null)
					{
						if (_subBiomeValue == null)
						{
							return new MinMaxValue(0f, 0f);
						}
						return _subBiomeValue.Range;
					}
					return _subBiomeAltitude.Altitude;
				}
				set
				{
					if (_subBiomeValue != null)
					{
						_subBiomeValue.Range = value;
					}
					else if (_subBiomeAltitude != null)
					{
						_subBiomeAltitude.Altitude = value;
					}
				}
			}

			public string Name
			{
				get
				{
					return SubBiomeData.Name;
				}
				set
				{
					SubBiomeData.Name = value;
					GroupModel.Name = (string.IsNullOrWhiteSpace(value) ? "Sub Biome" : value);
				}
			}

			public float Size { get; set; }

			public float Start { get; set; }

			public SubBiomeData SubBiomeData
			{
				get
				{
					if (_subBiomeAltitude != null)
					{
						return _subBiomeAltitude.SubBiome;
					}
					if (_subBiomeValue != null)
					{
						return _subBiomeValue.SubBiome;
					}
					return _singleSubBiome;
				}
			}

			public SubBiomeModel(AltitudeBasedSubBiomes.AltitudeRange subBiome)
			{
				_subBiomeAltitude = subBiome;
				Start = subBiome.Altitude.MinValue;
				EditFlatStyle = true;
			}

			public SubBiomeModel(SingleValueBasedSubBiomes.ValueRange subBiome)
			{
				_subBiomeValue = subBiome;
				Start = subBiome.Range.MinValue;
				EditFlatStyle = true;
			}

			public SubBiomeModel(SubBiomeData singleSubBiome)
			{
				_singleSubBiome = singleSubBiome;
				Start = 0f;
				EditFlatStyle = true;
			}

			public void Apply(SubBiomeModel previous)
			{
				if (previous != null)
				{
					MinMaxValue minMax = MinMax;
					float num = previous.MinMax.MaxValue - previous.MinMax.MinValue;
					minMax.MinValue = ClampMinMaxValue(previous.MinMax.MaxValue - Mathf.Clamp01(BlendOverlap) * num);
					minMax.MaxValue = ClampMinMaxValue(previous.MinMax.MaxValue + Size);
					MinMax = minMax;
				}
				else
				{
					MinMaxValue minMax2 = MinMax;
					minMax2.MinValue = ClampMinMaxValue(Start);
					minMax2.MaxValue = ClampMinMaxValue(minMax2.MinValue + Size);
					MinMax = minMax2;
				}
			}

			public string FormatSizeString(float size)
			{
				if (_subBiomeAltitude != null)
				{
					return $"{size:n0}m";
				}
				return $"{size:n2}";
			}

			public void UpdateGroupSubtitle()
			{
				if (_subBiomeValue != null)
				{
					GroupModel.Subtitle = $"{MinMax.MinValue:n3} to {MinMax.MaxValue:n3}";
				}
				else if (_subBiomeAltitude != null)
				{
					GroupModel.Subtitle = Units.GetDistanceString(MinMax.MinValue) + " to " + Units.GetDistanceString(MinMax.MaxValue);
				}
				else
				{
					GroupModel.Subtitle = string.Empty;
				}
			}

			private float ClampMinMaxValue(float value)
			{
				float min;
				float max;
				if (_subBiomeAltitude != null)
				{
					min = -100000f;
					max = 100000f;
				}
				else
				{
					min = -1f;
					max = 1f;
				}
				return Mathf.Clamp(value, min, max);
			}
		}

		private class TerrainTexture
		{
			public string FullPath { get; set; }

			public int Index { get; set; }

			public string Name { get; set; }
		}

		private int _biomeIndex;

		private List<BiomeModel> _biomes;

		private CelestialDatabase _db;

		private CelestialBodyDesignerScript _designer;

		private TerrainDetailSplatmap _splatmap;

		private List<TerrainTexture> _terrainTextures = new List<TerrainTexture>();

		public PlanetDataScript PlanetData => base.PlanetStudioUI.PlanetStudioScript?.CelestialBodyDesignerScript?.CurrentCelestialBody;

		private BiomeModel Biome => _biomes[_biomeIndex];

		public void SelectTexture(TextureModel model, Action<string> onComplete)
		{
			List<CelestialFile> list = new List<CelestialFile>();
			foreach (TerrainTexture terrainTexture in _terrainTextures)
			{
				CelestialFile file = _db.GetFile(CelestialFilePath.FromFullPath(terrainTexture.FullPath));
				list.Add(file);
			}
			TexturePickerLibrary texturePickerLibrary = new TexturePickerLibrary(list, "Terrain Textures");
			base.PlanetStudioUI.CreateTexturePicker(texturePickerLibrary, delegate(SupportFileData s, string p)
			{
				model.Label = s.FriendlyName;
				onComplete(p);
			});
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_db = ModApi.Common.Game.Instance.CelestialDatabase;
			_designer = base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript;
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			InspectorModel inspectorModel = new InspectorModel("Biomes", "Biomes");
			_biomes = new List<BiomeModel>();
			foreach (PlanetBiome biome in PlanetData.TerrainData.Biomes)
			{
				foreach (PlanetModifier modifier in biome.Modifiers)
				{
					AltitudeBasedSubBiomes component = modifier.GetComponent<AltitudeBasedSubBiomes>();
					if (component != null)
					{
						_biomes.Add(new BiomeModel(component));
						continue;
					}
					SingleValueBasedSubBiomes component2 = modifier.GetComponent<SingleValueBasedSubBiomes>();
					if (component2 != null)
					{
						_biomes.Add(new BiomeModel(component2));
						continue;
					}
					SingleSubBiome component3 = modifier.GetComponent<SingleSubBiome>();
					if (component3 != null)
					{
						Debug.Log("Single Sub Biome: " + component3?.Biome?.Name);
						_biomes.Add(new BiomeModel(component3));
					}
				}
			}
			if (_biomes.Count > 0)
			{
				GetTerrainTextures();
				ClampBiomeIndex();
				SpinnerModel spinnerModel = new SpinnerModel(() => Biome?.Name);
				spinnerModel.NextClicked = delegate
				{
					AdvanceBiome(1);
				};
				spinnerModel.PrevClicked = delegate
				{
					AdvanceBiome(-1);
				};
				spinnerModel.Tooltip = "The selected biome to edit.";
				inspectorModel.Add(spinnerModel);
				GroupModel groupModel = inspectorModel.AddGroup(new GroupModel("Edit Biomes"));
				groupModel.Collapsed = true;
				TableRowModel tableRowModel = new TableRowModel();
				tableRowModel.Add(new TextButtonModel("Add", OnAddBiomeClicked)).Tooltip = "Adds a new biome.";
				tableRowModel.Add(new TextButtonModel("Rename", OnRenameBiomeClicked)).Tooltip = "Renames this biome.";
				tableRowModel.Add(new TextButtonModel("Delete", OnDeleteBiomeClicked)).Tooltip = "Deletes this biome. Proceed with caution as this will likely mess up the biome assignments.";
				groupModel.Add(tableRowModel);
				int index = 0;
				foreach (SubBiomeModel subBiome in Biome.SubBiomes)
				{
					string value = subBiome.Name;
					if (string.IsNullOrWhiteSpace(value))
					{
						value = $"Sub Biome {index + 1}";
					}
					GroupModel groupModel2 = new GroupModel(value);
					inspectorModel.AddGroup(groupModel2);
					groupModel2.Collapsed = true;
					subBiome.GroupModel = groupModel2;
					groupModel2.AddAndBuild(new TextInputModel("Name", () => subBiome.Name, delegate(string x)
					{
						subBiome.Name = x;
					})).Build(delegate(TextInputModel x)
					{
						x.Tooltip = "The name of the sub-biome (optional).";
					});
					if (Biome.CanAddSubBiomes)
					{
						if (index == 0)
						{
							groupModel2.AddAndBuild(new FloatInputModel(Biome.IsAltitudeBased ? "Start Altitude" : "Start Value", () => subBiome.Start, delegate(float x)
							{
								subBiome.Start = x;
								Biome.ApplySubBiomes();
							})).Build(delegate(FloatInputModel x)
							{
								x.Tooltip = "The " + (Biome.IsAltitudeBased ? "altitude, in meters," : "input value") + " at which the sub-biome begins.";
							});
						}
						else
						{
							groupModel2.AddAndBuild(new SliderModel("Blend Overlap", () => subBiome.BlendOverlap, delegate(float x)
							{
								subBiome.BlendOverlap = x;
								Biome.ApplySubBiomes();
							})).Build(delegate(SliderModel x)
							{
								x.Tooltip = "The percentage of the previous sub-biome's " + (Biome.IsAltitudeBased ? "altitude" : "input value") + " range of which this sub-biome overlaps. If this is set to 0%, there will be no overlap between this sub-biome and the previous one (not recommended). If this is set to 50%, then this sub-biome will begin half way through the previous sub-biome's range, smoothly blending toward 100% where the previous sub-biome ends.";
							});
						}
						groupModel2.AddAndBuild(new FloatInputModel(Biome.IsAltitudeBased ? "Altitude Range" : "Value Range", () => subBiome.Size, delegate(float x)
						{
							subBiome.Size = x;
							Biome.ApplySubBiomes();
						}, 0f)).Build(delegate(FloatInputModel x)
						{
							x.Tooltip = "The " + (Biome.IsAltitudeBased ? "altitude range, in meters," : "value range") + " that this sub-biome covers, starting at the " + (Biome.IsAltitudeBased ? "start altitude" : "start value") + ((index == 0) ? string.Empty : " based on the blend range with the previous biome") + ".";
						});
					}
					TableRowModel tableRowModel2 = new TableRowModel();
					TextButtonModel editFlatStyleButon = new TextButtonModel("Flat Style", null);
					TextButtonModel editSlopeStyleButon = new TextButtonModel("Slope Style", null);
					editFlatStyleButon.Tooltip = "Select this to edit the sub-biome style and settings used when the slope of the terrain falls below the 'Flat End Angle'.";
					editSlopeStyleButon.Tooltip = "Select this to edit the sub-biome style and settings used when the slope of the terrain falls above the 'Slope Start Angle'.";
					editFlatStyleButon.UpdateAction = delegate
					{
						editFlatStyleButon.Style = (subBiome.EditFlatStyle ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
					};
					editSlopeStyleButon.UpdateAction = delegate
					{
						editSlopeStyleButon.Style = ((!subBiome.EditFlatStyle) ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
					};
					tableRowModel2.Add(editFlatStyleButon);
					tableRowModel2.Add(editSlopeStyleButon);
					groupModel2.Add(tableRowModel2);
					groupModel2.AddAndBuild(new SliderModel("Slope Start Angle", () => subBiome.AngleStart, delegate(float x)
					{
						subBiome.AngleStart = x;
					}, 0f, 0.5f)).Build(delegate(SliderModel x)
					{
						x.ValueFormatter = (float s) => $"{Mathf.Acos(1f - s) * 57.29578f:n2}°";
					}).Build(delegate(SliderModel x)
					{
						x.DetermineVisibility = () => !subBiome.EditFlatStyle;
					})
						.Build(delegate(SliderModel x)
						{
							x.Tooltip = "The angle at which the slope style begins. It is blended with the flat style up to Flat End Angle.";
						});
					groupModel2.AddAndBuild(new SliderModel("Flat End Angle", () => subBiome.AngleEnd, delegate(float x)
					{
						subBiome.AngleEnd = x;
					}, 0f, 0.5f)).Build(delegate(SliderModel x)
					{
						x.ValueFormatter = (float s) => $"{Mathf.Acos(1f - s) * 57.29578f:n2}°";
					}).Build(delegate(SliderModel x)
					{
						x.DetermineVisibility = () => subBiome.EditFlatStyle;
					})
						.Build(delegate(SliderModel x)
						{
							x.Tooltip = "The angle at which this flat style ends and the slope style is fully shown. The styles are blended at angles between the Slope Start Angle and this angle.";
						});
					groupModel2.AddAndBuild(new ColorModel("Color", () => subBiome.Data.Color, delegate(Color x)
					{
						subBiome.Data.Color = x;
					}, allowTransparency: false, callbackOnPreviewColorChange: false, allowHDR: true)).Build(delegate(ColorModel x)
					{
						x.Tooltip = "The base color of the terrain for this sub-biome style.";
					});
					TextureModel textureModel = new TextureModel(string.Empty, this, () => GetTerrainTexture(subBiome.Data.TextureIndex)?.FullPath, delegate(string s)
					{
						OnTextureChanged(subBiome.Data, s);
					});
					textureModel.Tooltip = "The detail texture used on the terrain surface for this sub-biome style. Only textures that have been added to the celestial body via the Terrain Textures flyout may be used here.";
					groupModel2.Add(textureModel);
					groupModel2.AddAndBuild(new SliderModel("Metallicness", () => subBiome.Data.Metallicness, delegate(float x)
					{
						subBiome.Data.Metallicness = x;
					})).Build(delegate(SliderModel x)
					{
						x.Tooltip = "The metallicness of the terrain for this sub-biome style. This affects the lighting on the terrain.";
					});
					groupModel2.AddAndBuild(new SliderModel("Smoothness", () => subBiome.Data.Smoothness, delegate(float x)
					{
						subBiome.Data.Smoothness = x;
					})).Build(delegate(SliderModel x)
					{
						x.Tooltip = "The smoothness of the terrain for this sub-biome style. This affects the lighting on the terrain.";
					});
					groupModel2.AddAndBuild(new SliderModel("Emissiveness", () => subBiome.Data.Emissiveness, delegate(float x)
					{
						subBiome.Data.Emissiveness = x;
					})).Build(delegate(SliderModel x)
					{
						x.Tooltip = "The emissiveness of the terrain for this sub-biome style. The more emissive a surface is, the less it is affected by light.";
					});
					groupModel2.AddAndBuild(new SliderModel("Tire Track Strength", () => subBiome.Data.TireTrackStrength, delegate(float x)
					{
						subBiome.Data.TireTrackStrength = x;
					})).Build(delegate(SliderModel x)
					{
						x.Tooltip = "The strength of tire tracks left by craft tires in this sub-biome style.";
					});
					CustomSubBiomeTerrainData[] array = subBiome.Data.CustomData?.Where((CustomSubBiomeTerrainData x) => x.ShowInPlanetStudio).ToArray() ?? new CustomSubBiomeTerrainData[0];
					int num;
					if (array.Length != 0)
					{
						groupModel2.AddAndBuild(new LabelModel("Mod Data"));
						CustomSubBiomeTerrainData[] array2 = array;
						for (num = 0; num < array2.Length; num++)
						{
							(array2[num] as ICustomObjectInspectorModel)?.CreateModel(groupModel2, null);
						}
					}
					Action updateStyleValues = delegate
					{
						TerrainTexture terrainTexture = GetTerrainTexture(subBiome.Data.TextureIndex);
						textureModel.Label = terrainTexture?.Name;
					};
					editFlatStyleButon.Action = delegate
					{
						subBiome.EditFlatStyle = true;
						updateStyleValues();
					};
					editSlopeStyleButon.Action = delegate
					{
						subBiome.EditFlatStyle = false;
						updateStyleValues();
					};
					updateStyleValues();
					groupModel2.Add(new SpacerModel());
					if (Biome.CanAddSubBiomes)
					{
						int subBiomeIndex = index;
						IconButtonRowModel iconButtonRowModel = groupModel2.Add(new IconButtonRowModel());
						iconButtonRowModel.Add(new IconButtonModel("Ui/Sprites/Common/IconAdd", delegate
						{
							OnAddSubBiomeClicked(subBiomeIndex);
						}, "Adds a new sub-biome after this sub-biome."));
						iconButtonRowModel.Add(new IconButtonModel("Ui/Sprites/Menu/IconButtonTrash", delegate
						{
							OnDeleteSubBiomeClicked(subBiomeIndex);
						}, "Remove this sub-biome."));
						iconButtonRowModel.Add(new IconButtonModel("Ui/Sprites/Common/IconMoveUp", delegate
						{
							OnMoveSubBiomeClicked(subBiomeIndex, -1);
						}, "Move this sub-biome up."));
						iconButtonRowModel.Add(new IconButtonModel("Ui/Sprites/Common/IconMoveDown", delegate
						{
							OnMoveSubBiomeClicked(subBiomeIndex, 1);
						}, "Move this sub-biome down."));
					}
					num = index;
					index = num + 1;
				}
				Biome.RefreshSubtitles();
				if (PlanetData.HasWater)
				{
					inspectorModel.AddGroup((GroupModel)Biome.Biome.WaterConfig.BuildInspectorModel(isPlanetDefaultConfig: false)[0]);
				}
			}
			else
			{
				inspectorModel.Add(new LabelModel("No biomes available"));
			}
			BuildFromModel(inspectorModel);
		}

		private static string NormalizePath(string fullPath)
		{
			return Path.GetFullPath(fullPath);
		}

		private void AddBiome(string biomeName)
		{
			XElement xElement = new XElement("Biome", new XAttribute("name", biomeName), new XAttribute("hierarchy", "Biomes/" + biomeName), new XElement("WaterConfig", new XAttribute("useDefaultConfig", "true")), new XElement("Modifiers", new XElement("Modifier", new XAttribute("enabled", "true"), new XAttribute("pass", "height"))));
			XElement xElement2 = xElement.Element("Modifiers").Element("Modifier");
			if (Biome.IsAltitudeBased)
			{
				xElement2.SetAttributeValue("type", "VertexData.Biomes.AltitudeBasedSubBiomes");
				xElement2.SetAttributeValue("name", "AltitudeBasedSubBiomes");
				xElement2.SetAttributeValue("hierarchy", "AltitudeBasedSubBiomes");
				xElement2.Add(new XElement("SubBiome", new XAttribute("altitude", "-1000,1000")));
			}
			else
			{
				xElement2.SetAttributeValue("type", "VertexData.Biomes.SingleValueBasedSubBiomes");
				xElement2.SetAttributeValue("name", "SingleValueBasedSubBiomes");
				xElement2.SetAttributeValue("hierarchy", "SingleValueBasedSubBiomes");
				xElement2.SetAttributeValue("dataIndexInput", "0");
				xElement2.Add(new XElement("SubBiome", new XAttribute("range", "-1,1")));
				xElement2.AddBeforeSelf(new XElement("Modifier", new XAttribute("type", "VertexData.GetConstant"), new XAttribute("enabled", "true"), new XAttribute("name", "Get Constant"), new XAttribute("pass", "height"), new XAttribute("dataIndexOutput", "0"), new XAttribute("value", "0")));
			}
			PlanetBiome planetBiome = PlanetBiome.CreateFromXml(xElement, PlanetData.TerrainData);
			_biomeIndex++;
			_biomeIndex = PlanetData.TerrainData.Biomes.Count;
			planetBiome.gameObject.transform.SetSiblingIndex(_biomeIndex);
			if (_biomeIndex >= PlanetData.TerrainData.Biomes.Count)
			{
				PlanetData.TerrainData.Biomes.Add(planetBiome);
			}
			else
			{
				PlanetData.TerrainData.Biomes.Insert(_biomeIndex, planetBiome);
			}
			foreach (IBiomeListModifiedHandler item in PlanetData.TerrainData.Modifiers.OfType<IBiomeListModifiedHandler>())
			{
				item.OnBiomeAdded(_biomeIndex);
			}
			foreach (PlanetBiome biome in PlanetData.TerrainData.Biomes)
			{
				foreach (IBiomeListModifiedHandler item2 in biome.Modifiers.OfType<IBiomeListModifiedHandler>())
				{
					item2.OnBiomeAdded(_biomeIndex);
				}
			}
			RefreshUI();
		}

		private void AdvanceBiome(int direction)
		{
			_biomeIndex += direction;
			ClampBiomeIndex();
			RefreshUI();
		}

		private void ClampBiomeIndex()
		{
			if (_biomeIndex >= _biomes.Count)
			{
				_biomeIndex = 0;
			}
			else if (_biomeIndex < 0)
			{
				_biomeIndex = _biomes.Count - 1;
			}
		}

		private void CreateUndo(string ignoreKey, string description)
		{
			base.PlanetStudioUI.CreateUndoStep(ignoreKey, description);
			base.PlanetStudioUI.MarkDirty();
		}

		private void DeleteBiome()
		{
			int num = PlanetData.TerrainData.Biomes.IndexOf(Biome.Biome);
			if (num < 0)
			{
				throw new Exception("Unable to find index of biome to be removed.");
			}
			PlanetData.TerrainData.Biomes.RemoveAt(num);
			UnityEngine.Object.DestroyImmediate(Biome.Biome.gameObject);
			foreach (IBiomeListModifiedHandler item in PlanetData.TerrainData.Modifiers.OfType<IBiomeListModifiedHandler>())
			{
				item.OnBiomeDeleted(num);
			}
			foreach (PlanetBiome biome in PlanetData.TerrainData.Biomes)
			{
				foreach (IBiomeListModifiedHandler item2 in biome.Modifiers.OfType<IBiomeListModifiedHandler>())
				{
					item2.OnBiomeDeleted(num);
				}
			}
			RefreshUI();
		}

		private TerrainTexture GetTerrainTexture(int index)
		{
			if (index >= 0 && index < _terrainTextures.Count)
			{
				return _terrainTextures[index];
			}
			return null;
		}

		private void GetTerrainTextures()
		{
			_terrainTextures.Clear();
			List<TerrainDetailSplatmap> list = PlanetData?.TerrainData.GetModifiers<TerrainDetailSplatmap>();
			if (list == null || list.Count != 1)
			{
				return;
			}
			_splatmap = list[0];
			int num = 0;
			foreach (TerrainDetailSplatmap.SplatTextures.SplatTexture texture in _splatmap.DistanceBlendedTextures.Textures)
			{
				CelestialFileDesignerInfo celestialFileDesignerInfo = _designer.SupportFiles.Where((CelestialFileDesignerInfo x) => x.Id == texture.Path).FirstOrDefault();
				SupportFileData supportFile = _db.GetSupportFile(celestialFileDesignerInfo.File.Id);
				TerrainTexture terrainTexture = new TerrainTexture();
				terrainTexture.Name = supportFile.FriendlyName;
				terrainTexture.FullPath = NormalizePath(celestialFileDesignerInfo.File.Path.FullPath);
				terrainTexture.Index = num++;
				_terrainTextures.Add(terrainTexture);
			}
		}

		private void OnAddBiomeClicked(TextButtonModel button)
		{
			InputDialogScript inputDialogScript = ModApi.Common.Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.InputText = "Biome Name";
			inputDialogScript.MessageText = "Enter a name for the biome.";
			inputDialogScript.Modal = true;
			inputDialogScript.OkayButtonText = "CREATE BIOME";
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				d.Close();
				AddBiome(d.InputText);
				CreateUndo("Biome.Add", "Added Biome");
			};
		}

		private void OnAddSubBiomeClicked(int index)
		{
			int index2 = index + 1;
			if (Biome.AltitudeBasedBiomesModifier != null)
			{
				Biome.AltitudeBasedBiomesModifier.InsertSubBiome(index2);
			}
			else
			{
				if (!(Biome.SingleValueBasedBiomesModifier != null))
				{
					throw new Exception("Unexpected biome type");
				}
				Biome.SingleValueBasedBiomesModifier.InsertSubBiome(index2);
			}
			CreateUndo("SubBiome.Add", "Added Sub-Biome");
			RefreshUI();
		}

		private void OnDeleteBiomeClicked(TextButtonModel button)
		{
			if (PlanetData.TerrainData.Biomes.Count <= 1)
			{
				ModApi.Common.Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Unable to delete the last biome. A celestial body requires at least one biome.";
				return;
			}
			MessageDialogScript messageDialogScript = ModApi.Common.Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Delete biome '" + Biome.Name + "'?" + Environment.NewLine + "Proceed with caution. This will likely mess up the biome assignments. Biomes are assigned in the 'Biome' pass on the terrain generation flyout. Some other aspects of terrain generations could be messed up as well.";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayButtonText = "DELETE BIOME";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				DeleteBiome();
				CreateUndo("Biome.Delete", "Deleted Biome");
			};
		}

		private void OnDeleteSubBiomeClicked(int index)
		{
			if (Biome.AltitudeBasedBiomesModifier != null)
			{
				Biome.AltitudeBasedBiomesModifier.DeleteSubBiome(index);
			}
			else
			{
				if (!(Biome.SingleValueBasedBiomesModifier != null))
				{
					throw new Exception("Unexpected biome type");
				}
				Biome.SingleValueBasedBiomesModifier.DeleteSubBiome(index);
			}
			CreateUndo("SubBiome.Delete", "Deleted Sub-Biome");
			RefreshUI();
		}

		private void OnMoveSubBiomeClicked(int subBiomeIndex, int direction)
		{
			int num = subBiomeIndex + direction;
			if (num >= 0 && num < Biome.SubBiomes.Count)
			{
				Biome.SwapSubBiomes(subBiomeIndex, num);
				CreateUndo("SubBiome.Move", "Moved Sub-Biome");
				RefreshUI();
			}
		}

		private void OnRemoveTextureClicked()
		{
			MessageDialogScript messageDialogScript = ModApi.Common.Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Please confirm that you want to remove the last terrain texture from this celestial body.";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				int num = _splatmap.DistanceBlendedTextures.Textures.Count - 1;
				if (num >= 0)
				{
					_splatmap.DistanceBlendedTextures.Textures.RemoveAt(num);
					RefreshUI();
				}
			};
		}

		private void OnRenameBiomeClicked(TextButtonModel button)
		{
			InputDialogScript inputDialogScript = ModApi.Common.Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.InputText = Biome.Name;
			inputDialogScript.MessageText = "Enter a new name for the biome.";
			inputDialogScript.Modal = true;
			inputDialogScript.OkayButtonText = "RENAME BIOME";
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				d.Close();
				RenameBiome(d.InputText);
			};
		}

		private void OnTextureChanged(SubBiomeTerrainData data, string path)
		{
			NormalizePath(path);
			for (int i = 0; i < _terrainTextures.Count; i++)
			{
				if (_terrainTextures[i].FullPath == path)
				{
					data.TextureIndex = i;
				}
			}
		}

		private void RenameBiome(string name)
		{
			Biome.Biome.Name = name;
			Biome.Biome.name = name;
			RefreshUI();
		}
	}
}
