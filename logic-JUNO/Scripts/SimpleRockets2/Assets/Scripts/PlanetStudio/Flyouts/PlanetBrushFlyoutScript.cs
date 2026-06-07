using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.PlanetStudio.Brush.Brushes;
using Assets.Scripts.PlanetStudio.Brush.Events;
using Assets.Scripts.PlanetStudio.Brush.Interfaces;
using Assets.Scripts.PlanetStudio.Brush.Undo;
using Assets.Scripts.PlanetStudio.Tools;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using ModApi.CelestialData;
using ModApi.Common.SimpleTypes;
using ModApi.Planet;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.PlanetStudio;
using ModApi.PlanetStudio.Events;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class PlanetBrushFlyoutScript : PlanetStudioFlyoutScript
	{
		public const int DefaultCubemapSize = 256;

		public const int DefaultMaxUndoStepsPerMap = 50;

		private List<IBrushCubemapModifier> _allMapModifiers;

		private ToggleModel _applyNoise;

		private float _brushBlurStrength;

		private SliderModel _brushBlurStrengthSlider;

		private List<PlanetBrush> _brushes;

		private float _brushHardness;

		private SliderModel _brushHardnessSlider;

		private float _brushRadius;

		private SliderModel _brushRadiusSlider;

		private SpinnerModel _brushSpinner;

		private float _brushStrength;

		private SliderModel _brushStrengthSlider;

		private BrushTool _brushTool;

		private byte _brushValue;

		private ColorModel _brushValueColor;

		private SliderModel _brushValueSlider;

		private IconButtonRowModel _buttonRowUndoRedo;

		private TextButtonModel _createCubemapButton;

		private CelestialFile _cubemapFile;

		private PlanetBrush _currentBrush;

		private IBrushCubemapModifier _currentMapModifier;

		private CelestialBodyDesignerScript _designer;

		private TextButtonModel _discardCubemapChangesButton;

		private TextButtonModel _editCubemapButton;

		private Gradient _gradient;

		private GradientModel _gradientModel;

		private GroupModel _groupModelEditMap;

		private GroupModel _groupModelFooter;

		private GroupModel _groupModelMain;

		private GroupModel _groupModelNoise;

		private GroupModel _groupModelNoMaps;

		private bool _hasChanges;

		private TextButtonModel _loadCubemapButton;

		private SpinnerModel _mapSpinner;

		private SliderModel _noiseOctaveSkipCount;

		private SliderModel _noiseStrength;

		private IconButtonModel _redoButton;

		private TextButtonModel _removeCubemapButton;

		private TextButtonModel _saveCubemapButton;

		private bool _showMap;

		private ToggleModel _toggleMap;

		private IconButtonModel _undoButton;

		private PlanetStudioBrushUndoSystem _undoSystem;

		private Dictionary<string, PlanetStudioBrushUndoSystem> _undoSystems;

		public string CurrentMapId => _currentMapModifier?.MapId;

		public bool EditingCubemap { get; private set; }

		protected override void OnCelestialBodyViewRefreshed()
		{
			base.OnCelestialBodyViewRefreshed();
			if (base.Flyout.IsOpen)
			{
				OnShowMapChanged(value: false);
				ClearOverrideTexture();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ClearOverrideTexture();
			UnloadUndoSystems();
			if (_designer != null)
			{
				_designer.CelestialBodyUnloading -= OnCelestialBodyUnloading;
				_designer.CelestialBodyViewRefreshing -= OnCelestialBodyViewRefreshing;
			}
			if (_brushTool != null)
			{
				_brushTool.BrushStrokeCompleted -= OnBrushStrokeCompleted;
			}
		}

		protected override void OnFlyoutClosed()
		{
			base.OnFlyoutClosed();
			_designer.ActiveTool = null;
			_designer.CelestialBodyViewer.OnBrushPanelClosed();
			ClearOverrideTexture();
			if (_hasChanges)
			{
				_designer.ViewCelestialBody(cleanGeneratedData: false, false);
			}
		}

		protected override void OnFlyoutOpened()
		{
			base.OnFlyoutOpened();
			_brushTool.Brush = _currentBrush ?? (_currentBrush = _brushes.First());
			_designer.CelestialBodyViewer.OnBrushPanelOpened();
			_showMap = true;
			_hasChanges = false;
			Gradient gradient = _gradient;
			UpdateMapModifiers();
			UpdateUI();
			OnBrushChanged();
			if (EditingCubemap)
			{
				_designer.ActiveTool = _brushTool;
				if (gradient != null)
				{
					_gradient = gradient;
					LoadGradient();
				}
				_undoSystem.Undo();
				_undoSystem.ClearRedoSteps();
			}
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_designer = planetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript;
			_designer.CelestialBodyUnloading += OnCelestialBodyUnloading;
			_designer.CelestialBodyViewRefreshing += OnCelestialBodyViewRefreshing;
			_brushTool = new BrushTool(_designer);
			_brushTool.BrushStrokeCompleted += OnBrushStrokeCompleted;
			_undoSystems = new Dictionary<string, PlanetStudioBrushUndoSystem>();
			_brushes = new List<PlanetBrush>();
			_brushes.Add(new StandardBrush());
			_brushes.Add(new AdditiveBrush(1f));
			_brushes.Add(new AdditiveBrush(-1f));
			_brushes.Add(new SmoothingBrush());
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			InspectorModel inspectorModel = new InspectorModel("Brush", "Brush");
			inspectorModel.AddGroup(_groupModelMain = new GroupModel(null));
			inspectorModel.AddGroup(_groupModelNoise = new GroupModel(null));
			inspectorModel.AddGroup(_groupModelEditMap = new GroupModel(null));
			inspectorModel.AddGroup(_groupModelFooter = new GroupModel(null));
			inspectorModel.AddGroup(_groupModelNoMaps = new GroupModel(null));
			_groupModelNoMaps.Add(new LabelModel("This celestial body does not support custom maps.", ElementAlignment.TopCenter));
			_mapSpinner = new SpinnerModel(() => _currentMapModifier?.MapDisplayName ?? "None");
			SpinnerModel mapSpinner = _mapSpinner;
			mapSpinner.PrevClicked = (Action<SpinnerModel>)Delegate.Combine(mapSpinner.PrevClicked, new Action<SpinnerModel>(OnMapSpinnerPreviousClicked));
			SpinnerModel mapSpinner2 = _mapSpinner;
			mapSpinner2.NextClicked = (Action<SpinnerModel>)Delegate.Combine(mapSpinner2.NextClicked, new Action<SpinnerModel>(OnMapSpinnerNextClicked));
			_mapSpinner.Tooltip = "Select the planet map to edit. Planet maps allow you to manually paint certain details directly onto the celestial body's surface.";
			_groupModelMain.Add(_mapSpinner);
			_loadCubemapButton = new TextButtonModel("Load Map", OnLoadCubemapButtonClicked);
			_loadCubemapButton.Tooltip = "Load an existing planet cubemap.";
			_groupModelMain.Add(_loadCubemapButton);
			_createCubemapButton = new TextButtonModel("Create New Map", OnCreateCubemapButtonClicked);
			_createCubemapButton.Tooltip = "Create a new cubemap for the currently selected planet map.";
			_groupModelMain.Add(_createCubemapButton);
			_editCubemapButton = new TextButtonModel("Edit Map", OnEditCubemapButtonClicked);
			_editCubemapButton.Tooltip = "Edit the cubemap for the currently selected planet map.";
			_groupModelMain.Add(_editCubemapButton);
			_removeCubemapButton = new TextButtonModel("Remove Map", OnRemoveCubemapButtonClicked);
			_removeCubemapButton.Tooltip = "Remove the cubemap from the currently selected planet map.";
			_groupModelMain.Add(_removeCubemapButton);
			_groupModelNoise.Add(new SpacerModel(15, drawImage: false));
			_applyNoise = new ToggleModel("Apply Noise", () => _currentMapModifier?.ApplyNoise ?? false, delegate(bool x)
			{
				_currentMapModifier.ApplyNoise = x;
			}, "If enabled, noise will be generated and combined with the result of the cubemap. This can help provide higher frequency noise that can't be generated by the cubemap itself.");
			_groupModelNoise.Add(_applyNoise);
			_noiseStrength = new SliderModel("Noise Strength", () => (float)(_currentMapModifier?.NoiseStrength ?? 0.0), delegate(float x)
			{
				_currentMapModifier.NoiseStrength = x;
			}, 0f, 2f);
			_noiseStrength.Tooltip = "The strength of the noise that will be combined with the cubemap data.";
			_groupModelNoise.Add(_noiseStrength);
			_noiseOctaveSkipCount = new SliderModel("Noise Octaves To Skip", () => _currentMapModifier?.NoiseOctaveSkipCount ?? 0, delegate(float x)
			{
				_currentMapModifier.NoiseOctaveSkipCount = (int)x;
			}, 0f, 20f, wholeNumbers: true);
			_noiseOctaveSkipCount.ValueFormatter = (float x) => ((int)x).ToString();
			_noiseOctaveSkipCount.Tooltip = "The number of octaves of noise to skip when combining noise with a planet map. The first few octaves of noise are typically the strongest and its usually best to skip these when combining a map with noise. If the stronger octaves are not skipped, they can have a great impact on the final result, possibly clobbering the look of the custom map. Including the later octaves could be very helpful sometimes to provide the finer details that the resolution of the planet map just can't handle.";
			_groupModelNoise.Add(_noiseOctaveSkipCount);
			_discardCubemapChangesButton = new TextButtonModel("Discard Changes", OnDiscardChangeButtonClicked);
			_discardCubemapChangesButton.Tooltip = "Discard all changes to the planet map since the last time it was saved.";
			_groupModelEditMap.Add(_discardCubemapChangesButton);
			_saveCubemapButton = new TextButtonModel("Save Changes", OnSaveCubemapButtonClicked);
			_saveCubemapButton.Tooltip = "Save changes to the planet map. This writes changes to the file immediately and does not require re-saving the celestial body. Care must be taken as this can affect multiple celestial bodies or multiple copies of this celestial body if they are all sharing the same file.";
			_groupModelEditMap.Add(_saveCubemapButton);
			_groupModelEditMap.Add(new SpacerModel(15, drawImage: false));
			_gradientModel = new GradientModel("Visualization", () => _gradient, delegate(Gradient x)
			{
				OnGradientChanged(x);
			}, hasAlpha: false);
			_gradientModel.Tooltip = "This is the color gradient used to represent the values of the planet map. Ultimately, the planet map is like a single channel texture. What the map does depends entirely on the specific planet map for the current celestial body. Some maps may represent continents, or biomes, or mountains or anything else. Some color gradients for specific modifiers are better than simple grayscale at representing the result they are achieving. This gradient has no real impact on the data in the map itself, it is simply a tool for visualizing the data.";
			_groupModelEditMap.Add(_gradientModel);
			_groupModelEditMap.Add(new SpacerModel(15, drawImage: false));
			_groupModelEditMap.Add(new LabelModel("Brush"));
			_brushSpinner = new SpinnerModel(() => _currentBrush?.Name ?? string.Empty);
			_brushSpinner.PrevClicked = delegate
			{
				OnBrushPreviousClicked();
			};
			_brushSpinner.NextClicked = delegate
			{
				OnBrushNextClicked();
			};
			_brushSpinner.Tooltip = "Cycle between the various brushes used to paint changes onto the planet cubemap.";
			_groupModelEditMap.Add(_brushSpinner);
			_brushRadiusSlider = new SliderModel("Radius", () => _brushRadius, delegate(float x)
			{
				UpdateBrushRadius(x);
			}, 0.01f);
			_brushRadiusSlider.Tooltip = "The radius of the brush ";
			_groupModelEditMap.Add(_brushRadiusSlider);
			UpdateBrushRadius(0.5f);
			_brushStrength = 0.5f;
			_brushStrengthSlider = new SliderModel("Strength", () => _brushStrength, delegate(float x)
			{
				UpdateBrushSettings(delegate
				{
					_brushStrength = x;
				});
			}, 0.01f);
			_brushStrengthSlider.Tooltip = "The strength of the brush's effect.";
			_groupModelEditMap.Add(_brushStrengthSlider);
			_brushHardness = 0.5f;
			_brushHardnessSlider = new SliderModel("Hardness", () => _brushHardness, delegate(float x)
			{
				UpdateBrushSettings(delegate
				{
					_brushHardness = x;
				});
			});
			_brushHardnessSlider.ValueFormatter = (float x) => $"{x * 100f:F0}%";
			_brushHardnessSlider.Tooltip = "The hardness of the brush. Reducing this causes the brush's effect to start fading out closer to the center of the brush.";
			_groupModelEditMap.Add(_brushHardnessSlider);
			_brushBlurStrength = 2f;
			_brushBlurStrengthSlider = new SliderModel("Strength", () => _brushBlurStrength, delegate(float x)
			{
				UpdateBrushSettings(delegate
				{
					_brushBlurStrength = x;
				});
			}, 0f, 5f, wholeNumbers: true);
			_brushBlurStrengthSlider.ValueFormatter = (float x) => $"{x + 1f:F0}";
			_brushBlurStrengthSlider.Tooltip = "The strength of the blur effect produced by the brush.";
			_groupModelEditMap.Add(_brushBlurStrengthSlider);
			_brushValueColor = new ColorModel("Value", () => _gradient?.Evaluate((float)(int)_brushValue / 255f) ?? default(Color), null, allowTransparency: false, callbackOnPreviewColorChange: true);
			_brushValueColor.Enabled = false;
			_brushValueColor.Tooltip = "The grayscale color value to be applied at the brush strokes. While the data itself is grayscale, the color gradient above is used to represent that grayscale data.";
			_groupModelEditMap.Add(_brushValueColor);
			_brushValue = 128;
			_brushValueSlider = new SliderModel(null, () => (int)_brushValue, delegate(float x)
			{
				OnBrushValueChanged(x);
			}, 0f, 255f, wholeNumbers: true);
			_brushValueSlider.ValueFormatter = (float x) => $"{x}";
			_brushValueSlider.Tooltip = "The grayscale color value to be applied at the brush strokes. While the data itself is grayscale, the color gradient above is used to represent that grayscale data.";
			_groupModelEditMap.Add(_brushValueSlider);
			_undoButton = new IconButtonModel("Ui/Sprites/Design/IconButtonUndo", delegate
			{
				_undoSystem.Undo();
			}, "Undo");
			_redoButton = new IconButtonModel("Ui/Sprites/Design/IconButtonRedo", delegate
			{
				_undoSystem.Redo();
			}, "Redo");
			_buttonRowUndoRedo = new IconButtonRowModel();
			_buttonRowUndoRedo.Add(_undoButton);
			_buttonRowUndoRedo.Add(_redoButton);
			_groupModelEditMap.Add(_buttonRowUndoRedo);
			_groupModelFooter.Add(new SpacerModel(15, drawImage: false));
			_toggleMap = new ToggleModel("Show Map", () => _showMap, OnShowMapChanged);
			_toggleMap.Tooltip = "Toggles the display of the map on and off.";
			_groupModelFooter.Add(_toggleMap);
			UpdateBrushSettings();
			BuildFromModel(inspectorModel);
		}

		protected override void Update()
		{
			base.Update();
			UpdateUI();
		}

		private static Gradient GetDefaultGradient()
		{
			Gradient gradient = new Gradient();
			gradient.SetKeys(new GradientColorKey[2]
			{
				new GradientColorKey(Color.black, 0f),
				new GradientColorKey(Color.white, 1f)
			}, new GradientAlphaKey[2]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			});
			return gradient;
		}

		private void ClearOverrideTexture()
		{
			PlanetBrushTextureOverride.MapId = null;
			PlanetBrushTextureOverride.GetTexture = null;
		}

		private void CreateNewCubemap(string filePath, bool empty)
		{
			try
			{
				byte[] array = null;
				if (empty)
				{
					Texture2D texture2D = new Texture2D(1536, 256, TextureFormat.ARGB32, mipChain: false, linear: true);
					ColorARGB32 value = new ColorARGB32(127, 127, 127, byte.MaxValue);
					NativeArray<ColorARGB32> rawTextureData = texture2D.GetRawTextureData<ColorARGB32>();
					int length = rawTextureData.Length;
					for (int i = 0; i < length; i++)
					{
						rawTextureData[i] = value;
					}
					array = texture2D.EncodeToPNG();
					UnityEngine.Object.Destroy(texture2D);
				}
				else
				{
					array = _currentMapModifier.GenerateMap(256);
				}
				File.WriteAllBytes(filePath, array);
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				CelestialFilePath celestialFilePath = CelestialFilePath.FromFullPath(filePath);
				celestialDatabase.AddOrUpdateFile(celestialFilePath, refreshDatabase: true);
				CelestialFile file = celestialDatabase.GetFile(celestialFilePath);
				LoadCubemap(file, addFileReference: true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Game.Instance.UserInterface.CreateErrorDialog("An error occurred creating a new map: " + ex.Message);
			}
		}

		private void DeleteGeneratedDataMap()
		{
			string mapId = _currentMapModifier.MapId;
			string filePath = _designer.CurrentCelestialBody.GeneratedData.GetFilePath(mapId);
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			if (Game.InPlanetStudioScene)
			{
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				filePath = celestialDatabase.GetGeneratedData(celestialDatabase.SpecialFiles.PlanetStudioCelestialBody.Id).GetFilePath(mapId);
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				}
			}
		}

		private Texture2D GetOverrideTexture()
		{
			if (!base.Flyout.IsOpen)
			{
				return null;
			}
			return _designer.CelestialBodyViewer.BrushSphere.SaveCubemap();
		}

		private void LoadCubemap(CelestialFile file, bool addFileReference)
		{
			try
			{
				_cubemapFile = file;
				if (addFileReference)
				{
					string currentMapId = CurrentMapId;
					_designer.RemoveSupportFile(currentMapId);
					_designer.AddSupportFile(_cubemapFile, currentMapId);
					_hasChanges = true;
				}
				LoadCubemap();
				LoadGradient();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Game.Instance.UserInterface.CreateErrorDialog("An error occurred loading the map: " + ex.Message);
			}
		}

		private void LoadCubemap()
		{
			Texture2D texture2D = _cubemapFile.LoadTexture(mipmaps: false, linear: true, markNonReadable: false);
			if (texture2D != null)
			{
				_designer.CelestialBodyViewer.BrushSphere.UpdateFaceTextures(texture2D);
				UnityEngine.Object.Destroy(texture2D);
			}
			_undoSystem.CreateUndoStep(_cubemapFile);
		}

		private void LoadGradient()
		{
			_gradientModel.UpdatePreview = true;
			_designer.CelestialBodyViewer.BrushSphere.UpdateGradient(_gradient);
		}

		private void OnBrushChanged()
		{
			_brushTool.Brush = _currentBrush;
			UpdateBrushSettings();
		}

		private void OnBrushNextClicked()
		{
			int num = _brushes.IndexOf(_currentBrush) + 1;
			if (num == _brushes.Count)
			{
				num = 0;
			}
			_currentBrush = _brushes[num];
			OnBrushChanged();
		}

		private void OnBrushPreviousClicked()
		{
			int num = _brushes.IndexOf(_currentBrush) - 1;
			if (num < 0)
			{
				num = _brushes.Count - 1;
			}
			_currentBrush = _brushes[num];
			OnBrushChanged();
		}

		private void OnBrushStrokeCompleted(object sender, BrushStrokeCompletedEventArgs e)
		{
			_undoSystem.CreateUndoStep(e.TextureIndices);
		}

		private void OnBrushValueChanged(float value)
		{
			_brushValue = (byte)value;
			_brushValueColor.SetValueFromUserInput(_brushValueColor.Value, "Value");
			UpdateBrushSettings();
		}

		private void OnCelestialBodyUnloading(object sender, CelestialBodyUnloadingEventArgs e)
		{
			if (!e.ReloadingDueToManualXmlChange)
			{
				UnloadUndoSystems();
				EditingCubemap = false;
			}
		}

		private void OnCelestialBodyViewRefreshing(object sender, CelestialBodyViewRefreshedEventArgs e)
		{
			if (EditingCubemap)
			{
				PlanetBrushTextureOverride.MapId = _currentMapModifier?.MapId;
				PlanetBrushTextureOverride.GetTexture = GetOverrideTexture;
			}
		}

		private void OnCreateCubemapButtonClicked(TextButtonModel model)
		{
			IUserInterface ui = Game.Instance.UserInterface;
			MessageDialogScript messageDialogScript = ui.CreateMessageDialog(MessageDialogType.ThreeButtons);
			messageDialogScript.MessageText = "Create a new map for '" + _currentMapModifier?.MapDisplayName + "'? The map can be initialized with its default generated content or it can be initialized as an empty map.";
			messageDialogScript.OkayButtonText = "Default Map";
			messageDialogScript.MiddleButtonText = "Empty Map";
			messageDialogScript.CancelButtonText = "Cancel";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				CreateNewMapInteractive(d, string.Empty, empty: false);
			};
			messageDialogScript.MiddleClicked += delegate(MessageDialogScript d)
			{
				CreateNewMapInteractive(d, string.Empty, empty: true);
			};
			void CreateNewMapInteractive(DialogScript dialog, string fileName, bool empty)
			{
				dialog?.Close();
				InputDialogScript nameDialog = ui.CreateInputDialog();
				nameDialog.MessageText = "Enter the map file name.";
				nameDialog.InputPlaceholderText = "Map Name";
				nameDialog.InputText = fileName;
				nameDialog.InvalidCharacters.AddRange(Path.GetInvalidFileNameChars());
				nameDialog.OkayButtonText = "Create";
				nameDialog.OkayClicked += delegate(InputDialogScript nd)
				{
					nd.Close();
					if (string.IsNullOrWhiteSpace(nameDialog.InputText))
					{
						ui.CreateErrorDialog("A valid file name is required.").OkayClicked += delegate(MessageDialogScript d)
						{
							CreateNewMapInteractive(d, nameDialog.InputText, empty);
						};
					}
					else
					{
						string path = Path.Combine(Game.Instance.CelestialDatabase.Paths.UserData.SupportFiles, nameDialog.InputText + ".png");
						if (File.Exists(path))
						{
							MessageDialogScript messageDialogScript2 = ui.CreateMessageDialog(MessageDialogType.OkayCancel);
							messageDialogScript2.MessageText = "A file already exists with that name. Do you wish to overwrite it?";
							messageDialogScript2.OkayButtonText = "OVERWRITE";
							messageDialogScript2.UseDangerButtonStyle = true;
							messageDialogScript2.CancelClicked += delegate(MessageDialogScript od)
							{
								CreateNewMapInteractive(od, nameDialog.InputText, empty);
							};
							messageDialogScript2.OkayClicked += delegate(MessageDialogScript od)
							{
								od.Close();
								CreateNewCubemap(path, empty);
							};
						}
						else
						{
							CreateNewCubemap(path, empty);
						}
					}
				};
			}
		}

		private void OnDiscardChangeButtonClicked(TextButtonModel obj)
		{
			_gradient = _currentMapModifier.MapColorGradient ?? GetDefaultGradient();
			LoadCubemap();
			LoadGradient();
			OnEditCubemapEnd();
		}

		private void OnEditCubemapButtonClicked(TextButtonModel obj)
		{
			OnEditCubemapStart();
		}

		private void OnEditCubemapEnd()
		{
			EditingCubemap = false;
			_designer.ActiveTool = null;
			UpdateUI();
		}

		private void OnEditCubemapStart()
		{
			EditingCubemap = true;
			if (_showMap)
			{
				_designer.ActiveTool = _brushTool;
			}
			UpdateUI();
		}

		private void OnGradientChanged(Gradient gradient)
		{
			_gradient = gradient;
			if (_currentMapModifier != null)
			{
				LoadGradient();
			}
		}

		private void OnLoadCubemapButtonClicked(TextButtonModel model)
		{
			TexturePickerLibrary texturePickerLibrary = new TexturePickerLibrary(_designer.CurrentCelestialBody?.FileData, TexturePickerLibrary.FilterCubemap);
			base.PlanetStudioUI.CreateTexturePicker(texturePickerLibrary, delegate(SupportFileData file, string path)
			{
				CelestialFile file2 = Game.Instance.CelestialDatabase.GetFile(file.FileId);
				LoadCubemap(file2, addFileReference: true);
			});
		}

		private void OnMapModifierChanged()
		{
			if (_currentMapModifier == null)
			{
				UnloadCubemap();
				return;
			}
			string currentMapId = CurrentMapId;
			if (!_undoSystems.TryGetValue(currentMapId, out _undoSystem))
			{
				_undoSystem = new PlanetStudioBrushUndoSystem(_designer.CelestialBodyViewer.BrushSphere, 50);
				_undoSystems.Add(currentMapId, _undoSystem);
			}
			CelestialFile supportFile = _designer.GetSupportFile(currentMapId);
			SupportFileData supportFileData = ((supportFile == null) ? null : Game.Instance.CelestialDatabase.GetSupportFile(supportFile.Id));
			if (supportFileData != null)
			{
				SupportFileDataTextureInfo textureInfo = supportFileData.TextureInfo;
				if (textureInfo == null || textureInfo.Height * 6 != textureInfo.Width)
				{
					Game.Instance.UserInterface.CreateErrorDialog("Map file '" + supportFile.Path.RelativePath + "' is not a valid cubemap texture. The file must be a cubemap texture in horizontal layout, with the width being six times the height.");
					supportFileData = null;
				}
			}
			VertexDataNoise vertexDataNoise = _currentMapModifier as VertexDataNoise;
			bool canSkipOctaves = _currentMapModifier.CanSkipOctaves;
			_noiseOctaveSkipCount.MaxValue = ((vertexDataNoise != null && canSkipOctaves) ? (vertexDataNoise.Octaves - 1) : 20);
			_gradient = _currentMapModifier.MapColorGradient ?? GetDefaultGradient();
			if (supportFileData == null)
			{
				UnloadCubemap();
			}
			else
			{
				LoadCubemap(supportFile, addFileReference: false);
			}
		}

		private void OnMapSpinnerNextClicked(SpinnerModel model)
		{
			try
			{
				if (_currentMapModifier == null)
				{
					_currentMapModifier = _allMapModifiers.FirstOrDefault();
				}
				else
				{
					int num = _allMapModifiers.IndexOf(_currentMapModifier) + 1;
					if (num >= _allMapModifiers.Count)
					{
						_currentMapModifier = _allMapModifiers.FirstOrDefault();
					}
					else
					{
						_currentMapModifier = _allMapModifiers[num];
					}
				}
				OnMapModifierChanged();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Game.Instance.UserInterface.CreateErrorDialog("An error occurred selecting and loading the next map: " + ex.Message);
			}
		}

		private void OnMapSpinnerPreviousClicked(SpinnerModel model)
		{
			try
			{
				if (_currentMapModifier == null)
				{
					_currentMapModifier = _allMapModifiers.LastOrDefault();
				}
				else
				{
					int num = _allMapModifiers.IndexOf(_currentMapModifier) - 1;
					if (num < 0)
					{
						_currentMapModifier = _allMapModifiers.LastOrDefault();
					}
					else
					{
						_currentMapModifier = _allMapModifiers[num];
					}
				}
				OnMapModifierChanged();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Game.Instance.UserInterface.CreateErrorDialog("An error occurred selecting and loading the previous map: " + ex.Message);
			}
		}

		private void OnRemoveCubemapButtonClicked(TextButtonModel model)
		{
			_designer.RemoveSupportFile(_currentMapModifier.MapId);
			UnloadCubemap();
			_hasChanges = true;
		}

		private void OnSaveCubemapButtonClicked(TextButtonModel model)
		{
			try
			{
				_hasChanges = true;
				byte[] bytes = _designer.CelestialBodyViewer.BrushSphere.SaveCubemap().EncodeToPNG();
				File.WriteAllBytes(_cubemapFile.Path.FullPath, bytes);
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				celestialDatabase.AddOrUpdateFile(_cubemapFile.Path, refreshDatabase: true);
				DeleteGeneratedDataMap();
				_currentMapModifier.MapColorGradient = _gradient;
				CelestialFile file = celestialDatabase.GetFile(_cubemapFile.Path);
				LoadCubemap(file, addFileReference: true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Game.Instance.UserInterface.CreateErrorDialog("An error occurred saving the map: " + ex.Message);
			}
			OnEditCubemapEnd();
		}

		private void OnShowMapChanged(bool value)
		{
			_showMap = value;
			if (value)
			{
				_designer.CelestialBodyViewer.ShowBrushSphere();
				if (EditingCubemap)
				{
					_designer.ActiveTool = _brushTool;
				}
			}
			else
			{
				_designer.CelestialBodyViewer.HideBrushSphere();
				_designer.ActiveTool = null;
			}
		}

		private void UnloadCubemap()
		{
			_cubemapFile = null;
			_designer.CelestialBodyViewer.BrushSphere.UpdateFaceTextures(null);
			_designer.CelestialBodyViewer.BrushSphere.UpdateGradient(null);
		}

		private void UnloadUndoSystems()
		{
			if (_undoSystems != null)
			{
				_undoSystems.Clear();
				GC.Collect();
			}
		}

		private void UpdateBrushRadius(float x)
		{
			_brushRadius = x;
			_brushTool.Radius = x * 0.25f;
		}

		private void UpdateBrushSettings(Action updateAction = null)
		{
			updateAction?.Invoke();
			PlanetBrush currentBrush = _currentBrush;
			if (currentBrush is IBrushStrength brushStrength)
			{
				brushStrength.Strength = _brushStrengthSlider.Value;
			}
			if (currentBrush is IBrushValue brushValue)
			{
				brushValue.Value = (byte)_brushValueSlider.Value;
			}
			if (currentBrush is IBrushHardness brushHardness)
			{
				brushHardness.Hardness = _brushHardnessSlider.Value;
			}
			if (currentBrush is IBrushBlurStrength brushBlurStrength)
			{
				brushBlurStrength.BlurStrength = (int)_brushBlurStrengthSlider.Value;
			}
		}

		private void UpdateMapModifiers()
		{
			PlanetTerrainDataScript terrainData = _designer.CurrentCelestialBody.TerrainData;
			_allMapModifiers = (from m in terrainData.Modifiers.OfType<IBrushCubemapModifier>()
				where m.MapId != null
				select m).ToList();
			_allMapModifiers.AddRange(terrainData.Biomes.SelectMany((PlanetBiome b) => from m in b.Modifiers.OfType<IBrushCubemapModifier>()
				where m.MapId != null
				select m));
			if (_currentMapModifier == null || !_allMapModifiers.Contains(_currentMapModifier))
			{
				_currentMapModifier = _allMapModifiers.FirstOrDefault();
			}
			OnMapModifierChanged();
			_mapSpinner.PrevButtonVisible = _allMapModifiers.Count > 1;
			_mapSpinner.NextButtonVisible = _allMapModifiers.Count > 1;
		}

		private void UpdateUI()
		{
			bool flag = _cubemapFile != null;
			bool flag2 = _allMapModifiers.Count > 0;
			_groupModelMain.Visible = flag2;
			_groupModelEditMap.Visible = EditingCubemap;
			_groupModelNoMaps.Visible = !flag2;
			_groupModelFooter.Visible = flag2;
			_mapSpinner.NextButtonVisible = !EditingCubemap && _allMapModifiers.Count > 1;
			_mapSpinner.PrevButtonVisible = !EditingCubemap && _allMapModifiers.Count > 1;
			_loadCubemapButton.Visible = !flag;
			_createCubemapButton.Visible = !flag;
			_editCubemapButton.Visible = flag && !EditingCubemap;
			_removeCubemapButton.Visible = flag && !EditingCubemap;
			bool flag3 = _currentMapModifier != null && _currentMapModifier.CanApplyNoise && flag && !EditingCubemap;
			_groupModelNoise.Visible = flag3;
			if (flag3)
			{
				bool value = _applyNoise.Value;
				_noiseStrength.Visible = value;
				_noiseOctaveSkipCount.Visible = _currentMapModifier.CanSkipOctaves && value;
			}
			_brushSpinner.Visible = true;
			_brushRadiusSlider.Visible = true;
			_brushValueColor.Visible = _currentBrush is IBrushValue;
			_brushValueSlider.Visible = _currentBrush is IBrushValue;
			_brushStrengthSlider.Visible = _currentBrush is IBrushStrength;
			_brushHardnessSlider.Visible = _currentBrush is IBrushHardness;
			_brushBlurStrengthSlider.Visible = _currentBrush is IBrushBlurStrength;
			_undoButton.Enabled = _undoSystem?.CanUndo ?? false;
			_redoButton.Enabled = _undoSystem?.CanRedo ?? false;
		}
	}
}
