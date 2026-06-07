using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.State;
using Assets.Scripts.Terrain;
using ModApi;
using ModApi.CelestialData;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Planet;
using ModApi.PlanetStudio;
using ModApi.PlanetStudio.Events;
using ModApi.Scenes.Parameters;
using ModApi.State;
using ModApi.Ui.Inspector;
using UnityEngine;
using UnityEngine.Profiling;

namespace Assets.Scripts.PlanetStudio.UI.Inspector
{
	public class CelestialBodyDesignerInspectorScript : MonoBehaviour
	{
		private IconButtonModel _buttonRebuild;

		private Version _celestialBodyVersionNumber;

		private CelestialBodyDesignerScript _designer;

		private bool _editingLatLon;

		private int _fpsFrameCount;

		private Queue<(int frameCount, double seconds)> _fpsQueue;

		private Stopwatch _fpsStopwatch;

		private TextModel _fpsText;

		private GroupModel _groupPerformance;

		private GroupModel _groupPosition;

		private IInspectorPanel _inspectorPanel;

		private LabelModel _labelChanges;

		private NumericInputModel _latitudeInput;

		private double _latitudeTarget;

		private TextModel _latitudeText;

		private NumericInputModel _longitudeInput;

		private double _longitudeTarget;

		private TextModel _longitudeText;

		private TextModel _mainLabel;

		private TextModel _memoryAllocated;

		private TextModel _memoryMonoHeap;

		private TextModel _memoryMonoUsed;

		private TextModel _memoryReserved;

		private TextModel _memoryUnused;

		private TextModel[] _quadsLoadedPerLevel;

		private QuadSphereStats _quadSphereStats;

		private bool _scaledSpacePendingChanges;

		private bool _showQuadsLoadedPerLevel;

		private IconButtonModel _snapToGroundButton;

		private CelestialBodyViewerScript _viewer;

		protected double Latitude
		{
			get
			{
				if (!_viewer.MovementScript.IsAnimating)
				{
					return _viewer.Latitude;
				}
				return _latitudeTarget;
			}
			set
			{
				OnLatLonUpdated(_latitudeTarget = value, Longitude);
			}
		}

		protected double Longitude
		{
			get
			{
				if (!_viewer.MovementScript.IsAnimating)
				{
					return _viewer.Longitude;
				}
				return _longitudeTarget;
			}
			set
			{
				OnLatLonUpdated(Latitude, _longitudeTarget = value);
			}
		}

		public static CelestialBodyDesignerInspectorScript Create(CelestialBodyDesignerScript designer)
		{
			GameObject obj = new GameObject("CelestialBodyDesignerInspector");
			obj.transform.SetParent(designer.transform, worldPositionStays: false);
			CelestialBodyDesignerInspectorScript celestialBodyDesignerInspectorScript = obj.AddComponent<CelestialBodyDesignerInspectorScript>();
			celestialBodyDesignerInspectorScript._designer = designer;
			designer.CelestialBodyModified += celestialBodyDesignerInspectorScript.OnCelestialBodyModified;
			designer.CelestialBodyViewRefreshed += celestialBodyDesignerInspectorScript.OnCelestialBodyViewRefreshed;
			return celestialBodyDesignerInspectorScript;
		}

		protected virtual void Start()
		{
			_viewer = _designer.CelestialBodyViewer;
			_designer.UI.EditModeChanged += OnEditModeChanged;
			_quadSphereStats = new QuadSphereStats();
			InspectorModel inspectorModel = new InspectorModel("CelestialBodyDesigner", "Celestial Body");
			_mainLabel = inspectorModel.Add(new TextModel(string.Empty));
			IconButtonRowModel iconButtonRowModel = inspectorModel.Add(new IconButtonRowModel());
			iconButtonRowModel.Add(_buttonRebuild = new IconButtonModel("Ui/Sprites/PlanetStudio/IconRebuildPlanet", OnBuildButtonClicked, "Rebuilds the celestial body based on the current configuration."));
			iconButtonRowModel.Add(new IconButtonModel("Ui/Sprites/PlanetStudio/IconCameraRecenter", OnRecenterCameraButtonClicked, "Recenters the camera."));
			iconButtonRowModel.Add(new IconButtonModel("Ui/Sprites/Design/IconButtonPlay", OnSelectLaunchLocation, "Launches a craft on this planet."));
			string label = Game.Instance.Settings.UserPrefs.GetString("PlanetStudio.LaunchCraftId") ?? "Select Craft";
			inspectorModel.Add(new TextButtonModel(label, OnSelectCraft)).Style = ButtonModel.ButtonStyle.Primary;
			_labelChanges = inspectorModel.Add(new LabelModel("Rebuild is required.", ElementAlignment.Center));
			_labelChanges.Visible = false;
			inspectorModel.AddGroup(_groupPosition = new GroupModel("Position"));
			_groupPosition.Add(new TextModel("AGL", () => Units.GetDistanceString((float)_viewer.AltitudeGroundLevel), null, "Altitude above ground level"));
			_groupPosition.Add(new TextModel("ASL", () => Units.GetDistanceString((float)_viewer.AltitudeSeaLevel), null, "Altitude above sea level"));
			_groupPosition.Add(_latitudeText = new TextModel("Latitude", () => _viewer.Latitude.ToString("F4"), null, "Latitude of the camera"));
			_groupPosition.Add(_longitudeText = new TextModel("Longitude", () => _viewer.Longitude.ToString("F4"), null, "Longitude of the camera"));
			_groupPosition.Add(_latitudeInput = new NumericInputModel("Latitude", () => Latitude, delegate(double lat)
			{
				Latitude = lat;
			}, -90.0, 90.0, (double x) => x.ToString("F4")));
			_groupPosition.Add(_longitudeInput = new NumericInputModel("Longitude", () => Longitude, delegate(double lon)
			{
				Longitude = lon;
			}, -180.0, 180.0, (double x) => x.ToString("F4")));
			IconButtonRowModel iconButtonRowModel2 = _groupPosition.Add(new IconButtonRowModel());
			iconButtonRowModel2.Add(new IconButtonModel("Ui/Sprites/PlanetStudio/IconEdit", delegate
			{
				_editingLatLon = !_editingLatLon;
			}, "Allows manual input of latitude and longitude."));
			iconButtonRowModel2.Add(new IconButtonModel("Ui/Sprites/PlanetStudio/IconCopy", OnCopyPositionButtonClicked, "Copies the exact latitude and longitude of the current camera position to the clipboard."));
			iconButtonRowModel2.Add(_snapToGroundButton = new IconButtonModel("Ui/Sprites/PlanetStudio/IconSnapToGround", OnSnapToGroundButtonClicked, "Snaps the camera to the ground."));
			GroupModel groupModel = inspectorModel.AddGroup(new GroupModel("Miscellaneous"));
			groupModel.Add(new ToggleModel("Scaled Space", () => _viewer.QuadSphereScaledSpaceTransitionEnabled, delegate(bool x)
			{
				_viewer.QuadSphereScaledSpaceTransitionEnabled = x;
				if (x && _scaledSpacePendingChanges)
				{
					Rebuild(cleanGeneratedData: true);
				}
			}, "Toggles the display of the scaled space cubemap at distances greater than the quad sphere activation distance."));
			groupModel.Add(new ToggleModel("Underwater Visuals", () => _viewer.UnderwaterEffectsEnabled, delegate(bool x)
			{
				_viewer.UnderwaterEffectsEnabled = x;
			}, "Toggles the display of underwater visuals. Disabling this can be useful when working on underwater terrain."));
			groupModel.AddAndBuild(new FloatInputModel("Camera \nMove Speed", () => _viewer.MovementScript.SpeedMultiplier, delegate(float x)
			{
				_viewer.MovementScript.SpeedMultiplier = x;
			}, 0f, null, (float x) => x.ToString("0.###"))).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "Adjusts the speed multiplier for the camera.";
			});
			groupModel.AddAndBuild(new FloatInputModel("Camera \nRotate Speed", () => _viewer.MovementScript.SpeedMultiplierRotations, delegate(float x)
			{
				_viewer.MovementScript.SpeedMultiplierRotations = x;
			}, 0f, null, (float x) => x.ToString("0.###"))).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "Adjusts the speed multiplier of the rotational movements for the camera and/or celestial body.";
			});
			groupModel.Collapsed = false;
			GroupModel groupModel2 = inspectorModel.AddGroup(new GroupModel("Equirectangular Map"));
			IEquirectangularMapView map = PlanetStudioScript.Instance.PlanetStudioUI.EquirectangularMapView;
			groupModel2.Add(new ToggleModel("Enabled", () => map.Enabled, delegate(bool x)
			{
				map.Enabled = x;
			}, "Enable the display of the equirectangular map."));
			groupModel2.AddAndBuild(new SliderModel("Size", () => map.Scale, delegate(float x)
			{
				map.Scale = x;
			}, 0.1f, 2.5f)).Build(delegate(SliderModel x)
			{
				x.DetermineVisibility = () => map.Enabled;
			});
			groupModel2.AddAndBuild(new SliderModel("Brightness", () => _designer.CurrentCelestialBody?.EquirectangularMapBrightness ?? 0f, delegate(float x)
			{
				_designer.CurrentCelestialBody.EquirectangularMapBrightness = x;
			}, 0f, 2.5f)).Build(delegate(SliderModel x)
			{
				x.DetermineVisibility = () => map.Enabled;
			});
			groupModel2.AddAndBuild(new SliderModel("Shading", () => _designer.CurrentCelestialBody?.EquirectangularMapLight ?? 0f, delegate(float x)
			{
				_designer.CurrentCelestialBody.EquirectangularMapLight = x;
			}, 0f, 5f)).Build(delegate(SliderModel x)
			{
				x.DetermineVisibility = () => map.Enabled;
			});
			groupModel2.AddAndBuild(new TextButtonModel("Refresh", delegate
			{
				map.Refresh();
			})).Build(delegate(TextButtonModel x)
			{
				x.DetermineVisibility = () => map.Enabled;
			});
			groupModel2.Collapsed = true;
			inspectorModel.AddGroup(_groupPerformance = new GroupModel("Performance"));
			_groupPerformance.Add(new LabelModel("Quad Stats"));
			_groupPerformance.Add(new TextModel("Quads Created", () => _quadSphereStats.QuadsCreated.ToString(), null, "The total number of quads created."));
			_groupPerformance.Add(new TextModel("Quads Loaded", () => _quadSphereStats.QuadsLoaded.ToString(), null, "The total number of quads currently loaded."));
			_quadsLoadedPerLevel = new TextModel[21];
			for (int num = 0; num < _quadsLoadedPerLevel.Length; num++)
			{
				_groupPerformance.Add(_quadsLoadedPerLevel[num] = new TextModel("   Level " + num));
			}
			_groupPerformance.Add(new TextModel("Quads Drawn", () => _quadSphereStats.QuadsDrawn.ToString(), null, "The total number of quads currently being drawn."));
			_groupPerformance.Add(new TextModel("Quad Build Time (Min)", () => _quadSphereStats.QuadGenerationTimeMin.ToString("0.00") + "ms", null, "The minimum time in milliseconds that it took to create a quad."));
			_groupPerformance.Add(new TextModel("Quad Build Time (Max)", () => _quadSphereStats.QuadGenerationTimeMax.ToString("0.00") + "ms", null, "The maximum time in milliseconds that it took to create a quad."));
			_groupPerformance.Add(new TextModel("Quad Build Time (Avg)", () => _quadSphereStats.QuadGenerationTimeAverage.ToString("0.00") + "ms", null, "The average time in milliseconds that it took to create a quad."));
			_groupPerformance.Collapsed = true;
			IconButtonRowModel iconButtonRowModel3 = _groupPerformance.Add(new IconButtonRowModel());
			iconButtonRowModel3.Add(new IconButtonModel("Ui/Sprites/PlanetStudio/IconTrash", delegate
			{
				(_viewer?.PlanetScript?.QuadSphere as QuadSphereScript)?.ResetStats();
			}, "Resets the quad generation stats."));
			iconButtonRowModel3.Add(new IconButtonModel("Ui/Sprites/PlanetStudio/IconNoisePass", delegate
			{
				_showQuadsLoadedPerLevel = !_showQuadsLoadedPerLevel;
			}, "Toggles the display of loaded quads, breaking it down by subdivision level or only showing the total."));
			_groupPerformance.Add(_fpsText = new TextModel("FPS", null, null, "The current frames rendered per second"));
			_groupPerformance.Add(new LabelModel("Memory"));
			_groupPerformance.Add(_memoryMonoHeap = new TextModel("Mono Heap", null, null, "The size of the reserved space for managed-memory. This will grow when the total allocated managed-memory exceeds the currently reserved amount."));
			_groupPerformance.Add(_memoryMonoUsed = new TextModel("Mono Used", null, null, "The allocated managed-memory for live objects and non-collected objects."));
			_groupPerformance.Add(_memoryAllocated = new TextModel("Total Allocated", null, null, "The total memory allocated by the internal allocators in Unity. Unity reserves large pools of memory from the system. This shows the amount of used memory in those pools."));
			_groupPerformance.Add(_memoryReserved = new TextModel("Total Reserved", null, null, "The total memory Unity has reserved for current and future allocations. If the reserved memory is fully used, Unity will allocate more memory from the system as required."));
			_groupPerformance.Add(_memoryUnused = new TextModel("Total Unused", null, null, "Unity allocates memory in pools for usage when unity needs to allocate memory. This shows the amount of unused memory in these pools."));
			InspectorPanelCreationInfo creationInfo = new InspectorPanelCreationInfo
			{
				CanClose = false,
				CanPin = false,
				StartPosition = InspectorPanelCreationInfo.InspectorStartPosition.UpperRight,
				StartOffset = new Vector2(-10f, -10f)
			};
			_inspectorPanel = Game.Instance.UserInterface.CreateInspectorPanel(inspectorModel, creationInfo);
			_inspectorPanel.Visible = _designer.UI.EditMode == PlanetStudioEditMode.CelestialBody;
		}

		protected virtual void Update()
		{
			PlanetDataScript currentCelestialBody = _designer.CurrentCelestialBody;
			if (currentCelestialBody == null)
			{
				return;
			}
			_mainLabel.Label = currentCelestialBody.Name;
			if (_celestialBodyVersionNumber != currentCelestialBody.Version)
			{
				_celestialBodyVersionNumber = currentCelestialBody.Version;
				_mainLabel.Value = _celestialBodyVersionNumber.ToString();
			}
			_latitudeText.Visible = !_editingLatLon;
			_longitudeText.Visible = !_editingLatLon;
			_latitudeInput.Visible = _editingLatLon;
			_longitudeInput.Visible = _editingLatLon;
			if (_groupPerformance.Visible && !_groupPerformance.Collapsed)
			{
				(_viewer?.PlanetScript?.QuadSphere as QuadSphereScript)?.UpdateStats(_quadSphereStats);
				int num = _quadSphereStats.QuadsLoadedPerLevel.Length;
				for (int i = 0; i < _quadsLoadedPerLevel.Length; i++)
				{
					TextModel obj = _quadsLoadedPerLevel[i];
					obj.Visible = i < num && _showQuadsLoadedPerLevel;
					if (obj.Visible)
					{
						_quadsLoadedPerLevel[i].Value = _quadSphereStats.QuadsLoadedPerLevel[i].ToString();
					}
				}
			}
			bool flag = false;
			if (_fpsStopwatch == null)
			{
				_fpsStopwatch = Stopwatch.StartNew();
				_fpsQueue = new Queue<(int, double)>();
				_fpsFrameCount = 0;
				flag = true;
			}
			else
			{
				_fpsFrameCount++;
				double num2 = (double)_fpsStopwatch.ElapsedMilliseconds / 1000.0;
				if (num2 > 0.25)
				{
					_fpsQueue.Enqueue((_fpsFrameCount, num2));
					if (_fpsQueue.Count >= 8)
					{
						_fpsQueue.Dequeue();
					}
					flag = true;
					_fpsStopwatch.Restart();
					_fpsFrameCount = 0;
				}
			}
			if (_groupPerformance.Visible)
			{
				int num3 = ((_fpsQueue.Count != 0) ? ((int)_fpsQueue.Average(((int frameCount, double seconds) x) => (double)x.frameCount / x.seconds)) : 0);
				_fpsText.Value = num3.ToString();
				if (flag)
				{
					Func<long, string> func = (long x) => ((float)x / 1048576f).ToString("F1") + " MB";
					_memoryMonoHeap.Value = func(Profiler.GetMonoHeapSizeLong());
					_memoryMonoUsed.Value = func(Profiler.GetMonoUsedSizeLong());
					_memoryAllocated.Value = func(Profiler.GetTotalAllocatedMemoryLong());
					_memoryReserved.Value = func(Profiler.GetTotalReservedMemoryLong());
					_memoryUnused.Value = func(Profiler.GetTotalUnusedReservedMemoryLong());
				}
			}
			_snapToGroundButton.Style = (_designer.CelestialBodyViewer.MovementScript.SnapToGround ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
		}

		private static string GetLaunchCraftId()
		{
			return Game.Instance.Settings.UserPrefs.GetString("PlanetStudio.LaunchCraftId", CraftDesigns.EditorCraftId);
		}

		private void LaunchIntoTemporaryFlightState(LaunchLocation launchLocation)
		{
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			CelestialFilePath celestialFilePath = CelestialFilePath.FromRelativePath(celestialDatabase.SpecialFiles.PlanetStudioCelestialBody.RelativePath);
			_designer.SaveCelestialBody(celestialFilePath.FullPath, useFilePaths: false);
			FlightSceneLoadParameters flightSceneLoadParameters = new FlightSceneLoadParameters();
			FlightSceneScript.ReturnToSceneAfterFlight = "PlanetStudio";
			flightSceneLoadParameters.LaunchCraftId = GetLaunchCraftId();
			flightSceneLoadParameters.LaunchCraftNodeName = "Player";
			flightSceneLoadParameters.AutoEnableCheats = true;
			flightSceneLoadParameters.LaunchLocation = launchLocation;
			IPlanetNode planetNode = _designer.CelestialBodyViewer.PlanetScript.PlanetNode;
			double rotationAngle = planetNode.RotationAngle;
			CelestialFileReference planetarySystemReferenceOverride = CelestialFileReference.CreateWithFileId(null, celestialDatabase.SpecialFiles.PlanetStudioPlanetarySystem.Id);
			string path = Utilities.CombinePaths(Game.PersistentDataPath, "GameData/FlightStates/", "PlanetStudioTest/FlightState.xml");
			string fileName = Utilities.CombinePaths(Game.Instance.GameStateManager.GetGameStateTagPath(Game.Instance.GameState.Id, "PlanetStudio.Active"), "FlightState.xml");
			FlightStateData flightStateData = new FlightStateData(path, planetarySystemReferenceOverride);
			flightStateData.PlanetNodes[1].Name = planetNode.Name;
			flightStateData.PlanetNodes[1].RotationAngle = rotationAngle;
			flightStateData.GenerateXml().Save(fileName);
			CelestialBodyDesignerScript.PrepareForTestFlight(_designer.CelestialBodyViewer.CameraPlanetPosition, rotationAngle);
			PlanetStudioScript.AutoLoadedCelestialBody = celestialDatabase.GetFile(celestialFilePath);
			Game.Instance.StartFlightScene(flightSceneLoadParameters);
		}

		private void OnBuildButtonClicked(ButtonModel button)
		{
			Rebuild(_viewer.QuadSphereScaledSpaceTransitionEnabled);
		}

		private void OnCelestialBodyModified(object sender, CelestialBodyModifiedEventArgs e)
		{
			_scaledSpacePendingChanges = true;
			_labelChanges.Visible = true;
			_buttonRebuild.Style = ButtonModel.ButtonStyle.Primary;
		}

		private void OnCelestialBodyViewRefreshed(object sender, CelestialBodyViewRefreshedEventArgs e)
		{
			CelestialBodyViewerScript viewer = _viewer;
			if ((object)viewer != null && viewer.QuadSphereScaledSpaceTransitionEnabled)
			{
				_scaledSpacePendingChanges = false;
			}
			if (_labelChanges != null)
			{
				_buttonRebuild.Style = ButtonModel.ButtonStyle.Default;
				_labelChanges.Visible = false;
			}
		}

		private void OnCopyPositionButtonClicked(IconButtonModel button)
		{
			GUIUtility.systemCopyBuffer = $"{_viewer.Latitude}, {_viewer.Longitude}";
		}

		private void OnEditModeChanged(object sender, EventArgs e)
		{
			_inspectorPanel.Visible = _designer.UI.EditMode == PlanetStudioEditMode.CelestialBody;
		}

		private void OnLatLonUpdated(double latitude, double longitude)
		{
			_viewer.MovementScript.AnimateToSurfacePosition(latitude * 0.01745329, longitude * 0.01745329, AltitudeType.AboveGroundLevel, _viewer.AltitudeGroundLevel, 2500.0);
		}

		private void OnRecenterCameraButtonClicked(ButtonModel button)
		{
			_designer.CelestialBodyViewer.ResetView();
		}

		private void OnSelectCraft(TextButtonModel button)
		{
			CraftDesignsViewModel craftDesignsViewModel = new CraftDesignsViewModel("SELECT", Game.Instance.Settings.UserPrefs.GetString("PlanetStudio.LaunchCraftId"));
			craftDesignsViewModel.OnCraftSelected = delegate(string id, CraftScript craftScript)
			{
				Game.Instance.Settings.UserPrefs.SetString("PlanetStudio.LaunchCraftId", id);
				button.Label = id;
			};
			((PlanetStudioUIScript)PlanetStudioScript.Instance.PlanetStudioUI).CreateListView(craftDesignsViewModel);
		}

		private void OnSelectLaunchLocation(ButtonModel button)
		{
			List<LaunchLocation> list = _designer.CurrentCelestialBody.DefaultLaunchLocations.ToList();
			Vector3d cameraPlanetPosition = _designer.CelestialBodyViewer.CameraPlanetPosition;
			IPlanetNode planetNode = _designer.CelestialBodyViewer.PlanetScript.PlanetNode;
			planetNode.GetSurfaceCoordinates(planetNode.PlanetVectorToSurfaceVector(cameraPlanetPosition), out var latitude, out var longitude);
			double altitudeAboveGroundLevel = cameraPlanetPosition.magnitude - (planetNode.PlanetData.Radius + planetNode.GetTerrainHeight(cameraPlanetPosition));
			LaunchLocation launchLocation = new LaunchLocation("Camera", LaunchLocationType.SurfaceLockedGround, _designer.CurrentCelestialBody.Name, latitude * 57.29578, longitude * 57.29578, Vector3d.zero, 0.0, altitudeAboveGroundLevel);
			list.Insert(0, launchLocation);
			foreach (LaunchLocation item in list)
			{
				item.PlanetName = _designer.CurrentCelestialBody.Name;
			}
			LaunchLocation selected = list.Where((LaunchLocation x) => x.Name == Game.Instance.Settings.UserPrefs.GetString("PlanetStudio.LaunchLocation")).FirstOrDefault() ?? launchLocation;
			LaunchLocationsViewModel launchLocationsViewModel = new LaunchLocationsViewModel(list, selected);
			launchLocationsViewModel.PrimaryButtonText = "LAUNCH";
			launchLocationsViewModel.LaunchLocationSelected = delegate(LaunchLocation l)
			{
				Game.Instance.Settings.UserPrefs.SetString("PlanetStudio.LaunchLocation", l.Name);
				LaunchIntoTemporaryFlightState(l);
			};
			PlanetStudioScript.Instance.PlanetStudioUI.CreateListView(launchLocationsViewModel);
		}

		private void OnSnapToGroundButtonClicked(IconButtonModel button)
		{
			_designer.CelestialBodyViewer.MovementScript.SnapToGround = !_designer.CelestialBodyViewer.MovementScript.SnapToGround;
		}

		private void Rebuild(bool cleanGeneratedData)
		{
			_designer.StartViewCelestialBodyInteractive(null, cleanGeneratedData);
		}
	}
}
