using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.DebugScripts;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.CelestialData;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Math;
using ModApi.Planet;
using ModApi.PlanetStudio;
using ModApi.State;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetarySystemDesignerScript : MonoBehaviour, IPlanetarySystemDesigner
	{
		private const int MaxValidationPeriods = 50000;

		private const float NumValidationYears = 1000f;

		[SerializeField]
		private List<CelestialFileDesignerInfo> _celestialBodyFiles;

		private IMapViewCoordinateConverter _coordinateConverter;

		[SerializeField]
		[HideInInspector]
		private SolarSystemDataScript _currentPlanetarySystem;

		private IGameTime _gameTime;

		private IItemRegistry _itemRegistry;

		private string _lastSaveFileName;

		private MapViewManagerScript _mapViewManager;

		private IMapOptions _options;

		[SerializeField]
		private PlanetarySystemViewerScript _planetarySystemViewerScript;

		[SerializeField]
		private PlanetStudioUIScript _planetStudioUIScript;

		[SerializeField]
		private List<CelestialFileDesignerInfo> _supportFiles;

		public static PlanetarySystemDesignerScript Instance { get; private set; }

		public IReadOnlyList<CelestialFileDesignerInfo> CelestialBodyFiles => _celestialBodyFiles;

		public SolarSystemDataScript CurrentPlanetarySystem => _currentPlanetarySystem;

		public GameObject GameObject => base.gameObject;

		public bool HasUnsavedChanges { get; set; }

		public CelestialFilePath LastSaveFilePath { get; protected set; }

		public MapViewManagerScript MapViewManager => _mapViewManager;

		public PlanetarySystemViewerScript PlanetarySystemViewer => _planetarySystemViewerScript;

		public IPlanetNode RootNode { get; set; }

		public IReadOnlyList<CelestialFileDesignerInfo> SupportFiles => _supportFiles;

		public bool UIVisible
		{
			get
			{
				return true;
			}
			set
			{
				MapViewManager.MapView.UiVisible = value;
			}
		}

		public event SimpleNotificationDelegate PlanetarySystemLoaded;

		public event SimpleNotificationDelegate PlanetarySystemModified;

		public static void RegisterGlobalDevConsoleCommands()
		{
		}

		public OperationResult AddCelestialBody(CelestialFile celestialBodyFile, string localId, string parentCelestialBodyLocalId, XElement orbitXml = null)
		{
			try
			{
				CelestialBodyFileData celestialBody = Game.Instance.CelestialDatabase.GetCelestialBody(celestialBodyFile.Id);
				if (celestialBody == null)
				{
					return OperationResult.Failure($"Unable to add the celestial body because the the celestial body data for ID '{celestialBodyFile.Id}' could not be found.");
				}
				PlanetDataScript planetDataScript = null;
				if (parentCelestialBodyLocalId != null)
				{
					planetDataScript = GetCelestialBodyScript(parentCelestialBodyLocalId);
					if (planetDataScript == null)
					{
						return OperationResult.Failure("Unable to add the celestial body because the parent with ID '" + parentCelestialBodyLocalId + "' could not be found.");
					}
				}
				OperationResult operationResult = AddCelestialBodyFile(celestialBodyFile, localId ?? celestialBody.Name);
				if (!operationResult.IsSuccess)
				{
					return operationResult;
				}
				CelestialBodyPlanetarySystemDefinedData celestialBodyPlanetarySystemDefinedData = new CelestialBodyPlanetarySystemDefinedData();
				celestialBodyPlanetarySystemDefinedData.Orbit = ((orbitXml == null) ? null : new OrbitData(orbitXml));
				PlanetDataScript planetDataScript2 = CurrentPlanetarySystem.CreateCelestialBody(celestialBodyFile, celestialBodyPlanetarySystemDefinedData, planetDataScript, createTerrainData: false, applyScaleAndOverrides: false);
				planetDataScript2.SolarSystemData.PlanetCubemapManager.LoadPlanet(planetDataScript2);
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult AddCelestialBodyFile(CelestialFileReference fileReference)
		{
			try
			{
				CelestialFile file = Game.Instance.CelestialDatabase.GetFile(fileReference);
				if (file == null)
				{
					return OperationResult.Failure($"Unable to find celestial database file for file reference '{fileReference}'");
				}
				return AddCelestialBodyFile(file, fileReference.LocalId);
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult AddCelestialBodyFile(CelestialFile file, string localId)
		{
			try
			{
				CelestialFileDesignerInfo celestialFileDesignerInfo = _celestialBodyFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.File.Id == file.Id);
				if (celestialFileDesignerInfo != null)
				{
					string empty = string.Empty;
					empty = ((!(celestialFileDesignerInfo.File.Path.RelativePath == file.Path.RelativePath)) ? ("Unable to add celestial body '" + file.Path.RelativePath + "' because an identical file has already been added. ID: " + celestialFileDesignerInfo.Id + ", Path: " + celestialFileDesignerInfo.File.Path.RelativePath) : ("Unable to add celestial body '" + file.Path.RelativePath + "' because it has already been added. ID: " + celestialFileDesignerInfo.Id));
					return OperationResult.Failure((string)null, empty);
				}
				_celestialBodyFiles.Add(new CelestialFileDesignerInfo(file, localId));
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public IPlanetNode AddPlanetNode(MapItem parent, CelestialFile celestialFile, double orbitTime, bool repositionCamera, ICurrentCameraTarget cameraTarget, ISolarSystemData solarSystemData)
		{
			if (Game.Instance.CelestialDatabase.GetCelestialBody(celestialFile.Id) == null)
			{
				Debug.Log($"Unable to find the celestial body with id '{celestialFile.Id}'");
			}
			CelestialBodyPlanetarySystemDefinedData celestialBodyPlanetarySystemDefinedData = new CelestialBodyPlanetarySystemDefinedData();
			PlanetNode planetNode = null;
			PlanetDataScript parentCelestialBody = null;
			if (parent != null)
			{
				planetNode = parent.OrbitInfo.OrbitNode as PlanetNode;
				parentCelestialBody = planetNode.PlanetData as PlanetDataScript;
				celestialBodyPlanetarySystemDefinedData.Orbit = new OrbitData();
				celestialBodyPlanetarySystemDefinedData.Orbit.ArgumentOfPeriapsis = 0.0;
				celestialBodyPlanetarySystemDefinedData.Orbit.Eccentricity = 0.0010000000474974513;
				celestialBodyPlanetarySystemDefinedData.Orbit.Inclination = 0.0;
				celestialBodyPlanetarySystemDefinedData.Orbit.Prograde = true;
				celestialBodyPlanetarySystemDefinedData.Orbit.RightAscensionOfAscendingNode = 0.0;
				celestialBodyPlanetarySystemDefinedData.Orbit.SemiMajorAxis = planetNode.MaxChildDistance * 0.5;
				celestialBodyPlanetarySystemDefinedData.Orbit.Time = orbitTime;
				celestialBodyPlanetarySystemDefinedData.Orbit.TrueAnomaly = 0.0;
			}
			PlanetDataScript planetDataScript = _currentPlanetarySystem.CreateCelestialBody(celestialFile, celestialBodyPlanetarySystemDefinedData, parentCelestialBody, createTerrainData: false, applyScaleAndOverrides: false);
			PlanetNode planetNode2 = CreatePlanetNode(planetNode, planetDataScript);
			MapPlanet cameraFocus = _mapViewManager.MapView.AddPlanet(planetNode2, _mapViewManager.MapView.MapCamera);
			_mapViewManager.MapView.SetInspectorFocus(cameraFocus, CameraTransitionSpeed.Default, repositionCamera);
			OperationResult operationResult = AddCelestialBodyFile(celestialFile, planetDataScript.Name);
			if (!operationResult.IsSuccess)
			{
				Debug.LogError("Error adding new celestial body: " + operationResult.Message);
			}
			planetNode2.PlanetData.SolarSystemData.PlanetCubemapManager.LoadPlanet(planetNode2.PlanetData);
			List<LaunchLocation> defaultLaunchLocations = CurrentPlanetarySystem.GetDefaultLaunchLocations();
			foreach (LaunchLocation defaultLaunchLocation in planetDataScript.DefaultLaunchLocations)
			{
				defaultLaunchLocation.PlanetName = planetDataScript.Name;
				defaultLaunchLocations.Add(defaultLaunchLocation);
			}
			CurrentPlanetarySystem.SetLaunchLocations(defaultLaunchLocations);
			RaisePlanetarySystemModifiedEvent();
			return planetNode2;
		}

		public OperationResult AddSupportFile(CelestialFileReference fileReference)
		{
			try
			{
				CelestialFile file = Game.Instance.CelestialDatabase.GetFile(fileReference);
				if (file == null)
				{
					return OperationResult.Failure($"Unable to find celestial database file for file reference '{fileReference}'");
				}
				return AddSupportFile(file, fileReference.LocalId);
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult AddSupportFile(CelestialFile file, string localId)
		{
			try
			{
				CelestialFileDesignerInfo celestialFileDesignerInfo = _supportFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.File.Id == file.Id);
				if (celestialFileDesignerInfo != null)
				{
					string empty = string.Empty;
					empty = ((!(celestialFileDesignerInfo.File.Path.RelativePath == file.Path.RelativePath)) ? ("Unable to add support file '" + file.Path.RelativePath + "' because an identical file has already been added. ID: " + celestialFileDesignerInfo.Id + ", Path: " + celestialFileDesignerInfo.File.Path.RelativePath) : ("Unable to add support file '" + file.Path.RelativePath + "' because it has already been added. ID: " + celestialFileDesignerInfo.Id));
					return OperationResult.Failure((string)null, empty);
				}
				_supportFiles.Add(new CelestialFileDesignerInfo(file, localId));
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult ClonePlanetarySystem(CelestialFile planetarySystemFile, string planetarySystemName, string planetarySystemFileName, bool useFilePaths)
		{
			if (!planetarySystemFileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
			{
				planetarySystemFileName += ".xml";
			}
			OperationResult operationResult = LoadPlanetarySystem(planetarySystemFile);
			if (!operationResult.IsSuccess)
			{
				return operationResult;
			}
			_currentPlanetarySystem.Name = planetarySystemName;
			string filePath = Path.Combine(Game.Instance.CelestialDatabase.Paths.UserData.PlanetarySystems, planetarySystemFileName);
			ViewPlanetarySystem(cleanGeneratedData: false, true);
			return SavePlanetarySystem(filePath, useFilePaths);
		}

		public PlanetNode CreatePlanetNode(PlanetNode parentNode, PlanetDataScript planetData)
		{
			PlanetNode planetNode;
			if (parentNode == null)
			{
				planetNode = new PlanetNode(new PlanetNodeData(planetData), planetData, null);
			}
			else
			{
				Orbit orbit = new Orbit(planetData.OrbitData.Time, planetData.OrbitData.Eccentricity, planetData.OrbitData.SemiMajorAxis, planetData.OrbitData.ArgumentOfPeriapsis, planetData.OrbitData.TrueAnomaly, planetData.OrbitData.Inclination, planetData.OrbitData.RightAscensionOfAscendingNode, parentNode.PlanetData.Mass, prograde: false);
				planetNode = new PlanetNode(new PlanetNodeData(planetData), planetData, orbit);
				parentNode.AddChildNode(planetNode);
			}
			return planetNode;
		}

		public void EditPlanet(string name)
		{
			Action action = delegate
			{
				PlanetDataScript planetDataScript = CurrentPlanetarySystem.Planets.Where((PlanetDataScript x) => x.Name == name).FirstOrDefault();
				if (planetDataScript != null)
				{
					PlanetStudioScript.LoadAndViewCelestialBody(planetDataScript.File);
				}
			};
			if (HasUnsavedChanges)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.MessageText = "You have unsaved changes that will be lost if you continue.";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					action();
				};
			}
			else
			{
				action();
			}
		}

		public float GetMaxValidationTime()
		{
			return OrbitAnalyser.GetMaxValidationTime(_itemRegistry.OrbitNodes.Select((MapOrbitNode x) => x.OrbitInfo.OrbitNode).ToList(), 1000.0, 50000, _mapViewManager.Ioc, _options.Targeting.SoiEntryLocalMinimaModifier);
		}

		public OperationResult LoadPlanetarySystem(CelestialFile planetarySystemFile)
		{
			try
			{
				UnloadPlanetarySystem();
				PlanetarySystemFileData planetarySystem = Game.Instance.CelestialDatabase.GetPlanetarySystem(planetarySystemFile.Id);
				if (planetarySystem == null)
				{
					return OperationResult.Failure($"Unable to find the planetary system with id '{planetarySystemFile.Id}'");
				}
				_celestialBodyFiles = new List<CelestialFileDesignerInfo>();
				_supportFiles = new List<CelestialFileDesignerInfo>();
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, CelestialFileReference> allFileReference in planetarySystem.AllFileReferences)
				{
					OperationResult operationResult = ((!planetarySystem.CelestialBodyFileReferences.ContainsKey(allFileReference.Key)) ? AddSupportFile(allFileReference.Value) : AddCelestialBodyFile(allFileReference.Value));
					if (!operationResult.IsSuccess)
					{
						if (!string.IsNullOrEmpty(operationResult.WarningMessage))
						{
							list.Add(operationResult.WarningMessage);
						}
						if (!string.IsNullOrEmpty(operationResult.ErrorMessage))
						{
							list.Add(operationResult.ErrorMessage);
						}
					}
				}
				_currentPlanetarySystem = SolarSystemDataScript.CreateFromFile(planetarySystemFile, createTerrainData: false, applyScaleAndOverrides: false);
				_currentPlanetarySystem.transform.SetParent(base.transform, worldPositionStays: false);
				HasUnsavedChanges = false;
				return (list.Count == 0) ? OperationResult.Success() : OperationResult.Success(null, string.Join(Environment.NewLine, list));
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public void RaisePlanetarySystemModifiedEvent()
		{
			HasUnsavedChanges = true;
			this.PlanetarySystemModified?.Invoke();
		}

		public OperationResult RemoveCelestialBody(string celestialBodyLocalId)
		{
			try
			{
				PlanetDataScript celestialBodyScript = GetCelestialBodyScript(celestialBodyLocalId);
				if (celestialBodyScript == null)
				{
					return OperationResult.Failure("Unable to find celestial body with ID '" + celestialBodyLocalId + "' to be removed.");
				}
				List<LaunchLocation> defaultLaunchLocations = CurrentPlanetarySystem.GetDefaultLaunchLocations();
				List<PlanetDataScript> allChildren = GetAllChildren(celestialBodyScript, includeDescendants: true, includeRootParent: true);
				allChildren.Reverse();
				foreach (PlanetDataScript celestialBody in allChildren)
				{
					celestialBody.SolarSystemData.PlanetCubemapManager.UnloadPlanet(celestialBody);
					_celestialBodyFiles.RemoveAll((CelestialFileDesignerInfo x) => x.File.Id == celestialBody.FileData.FileId);
					CurrentPlanetarySystem.Planets.Remove(celestialBody);
					defaultLaunchLocations.RemoveAll((LaunchLocation x) => x.PlanetName == celestialBody.Name);
					UnityEngine.Object.Destroy(celestialBody.gameObject);
				}
				CurrentPlanetarySystem.SetLaunchLocations(defaultLaunchLocations);
				RaisePlanetarySystemModifiedEvent();
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult RemoveSupportFile(string supportFileLocalId)
		{
			try
			{
				_supportFiles.RemoveAll((CelestialFileDesignerInfo x) => x.Id == supportFileLocalId);
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult ReplaceCelestialBody(CelestialFile file, string localId)
		{
			try
			{
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				_ = CurrentPlanetarySystem.Planets;
				CelestialBodyFileData celestialBody = celestialDatabase.GetCelestialBody(file.Id);
				if (celestialBody == null)
				{
					return OperationResult.Failure($"Unable to add the celestial body because the the celestial body data for ID '{file.Id}' could not be found.");
				}
				PlanetDataScript bodyToReplace = GetCelestialBodyScript(localId);
				if (bodyToReplace == null)
				{
					return OperationResult.Failure("Unable to find celestial body with ID '" + localId + "' to be replaced.");
				}
				string replacementLocalId = celestialBody.Name;
				var list = (from x in GetAllChildren(bodyToReplace, includeDescendants: true, includeRootParent: true)
					select new
					{
						FileData = ((x == bodyToReplace) ? file : _celestialBodyFiles.First((CelestialFileDesignerInfo f) => f.File.Id == x.FileData.FileId).File),
						OrbitXml = x.OrbitData?.GenerateXml(),
						LocalId = ((x == bodyToReplace) ? replacementLocalId : _celestialBodyFiles.First((CelestialFileDesignerInfo f) => f.File.Id == x.FileData.FileId).Id),
						ParentLocalId = ((x.Parent == null) ? null : ((x.Parent.FileData.FileId == bodyToReplace.FileData.FileId) ? replacementLocalId : _celestialBodyFiles.First((CelestialFileDesignerInfo f) => f.File.Id == x.Parent.FileData.FileId).Id))
					}).ToList();
				List<LaunchLocation> defaultLaunchLocations = CurrentPlanetarySystem.GetDefaultLaunchLocations();
				defaultLaunchLocations.RemoveAll((LaunchLocation x) => x.PlanetName == localId);
				RemoveCelestialBody(localId);
				foreach (var item in list)
				{
					OperationResult operationResult = AddCelestialBody(item.FileData, item.LocalId, item.ParentLocalId, item.OrbitXml);
					if (!operationResult.IsSuccess)
					{
						return operationResult;
					}
				}
				PlanetDataScript planetDataScript = CurrentPlanetarySystem.Planets.Where((PlanetDataScript x) => x.Name == replacementLocalId).FirstOrDefault();
				foreach (LaunchLocation defaultLaunchLocation in planetDataScript.DefaultLaunchLocations)
				{
					defaultLaunchLocation.PlanetName = planetDataScript.Name;
					defaultLaunchLocations.Add(defaultLaunchLocation);
				}
				CurrentPlanetarySystem.SetLaunchLocations(defaultLaunchLocations);
				RaisePlanetarySystemModifiedEvent();
				_ = CurrentPlanetarySystem.Planets;
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult SavePlanetarySystem(string filePath, bool useFilePaths)
		{
			try
			{
				if (_currentPlanetarySystem == null)
				{
					return OperationResult.Failure("Unable to save the planetary system because it is not loaded.");
				}
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				List<string> list = _celestialBodyFiles.Concat(_supportFiles).GetUniqueDuplicates((CelestialFileDesignerInfo x) => x.Id).ToList();
				if (list.Count > 0)
				{
					return OperationResult.Failure("Unable to save the planetary system because the included celestial bodies and referenced files contain duplicate IDs: " + string.Join(", ", list));
				}
				string text = (string.IsNullOrWhiteSpace(Game.Instance.Settings.UserName) ? "Unknown" : Game.Instance.Settings.UserName);
				if (text != _currentPlanetarySystem.Author)
				{
					_currentPlanetarySystem.Author = text;
					_currentPlanetarySystem.Version = new Version(1, 0);
					_currentPlanetarySystem.VersionTag = string.Empty;
				}
				List<CelestialFileReference> fileReferences = GetFileReferences(useFilePaths);
				RemoveUnusedSupportFileReferences(fileReferences);
				_currentPlanetarySystem.Planets = GetPlanetDataScripts(RootNode);
				_currentPlanetarySystem.Save(fileReferences).Save(filePath);
				celestialDatabase.AddOrUpdateFile(CelestialFilePath.FromFullPath(filePath), refreshDatabase: true);
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public IEnumerator SavePlanetarySystemInteractive(string saveDialogText, bool updateSystemNameToMatchFile, Action<OperationResult> onCompleted)
		{
			IUserInterface ui = Game.Instance.UserInterface;
			if (_currentPlanetarySystem == null)
			{
				OperationResult failure = OperationResult.Failure("Unable to save the planetary system because it is not loaded.");
				yield return ui.CreateErrorDialog(failure.ErrorMessage).WaitForResult();
				onCompleted(failure);
				yield break;
			}
			string fileName = _lastSaveFileName;
			if (fileName == null)
			{
				CelestialFilePath path = CurrentPlanetarySystem.File.Path;
				fileName = (path.InGameData ? CurrentPlanetarySystem.Name : path.FileName.Remove(path.FileName.LastIndexOf('.')));
			}
			bool done = false;
			while (!done)
			{
				InputDialogScript saveDialog = ui.CreateInputDialog();
				saveDialog.InputPlaceholderText = "FILE NAME";
				saveDialog.MessageText = (string.IsNullOrWhiteSpace(saveDialogText) ? "Enter a file name to save the planetary system." : saveDialogText);
				saveDialog.OkayButtonText = "SAVE";
				saveDialog.CancelButtonText = "CANCEL";
				saveDialog.InputText = Utilities.ScrubFileName(fileName);
				saveDialog.InvalidCharacters.AddRange(Path.GetInvalidFileNameChars());
				yield return saveDialog.WaitForResult();
				if (saveDialog.Result == InputDialogResult.Cancel)
				{
					onCompleted(OperationResult.Cancel());
					break;
				}
				if (string.IsNullOrWhiteSpace(saveDialog.InputText))
				{
					yield return ui.CreateErrorDialog("A valid file name is required.").WaitForResult();
					continue;
				}
				_lastSaveFileName = saveDialog.InputText;
				string path2 = Path.Combine(Game.Instance.CelestialDatabase.Paths.UserData.PlanetarySystems, saveDialog.InputText + ".xml");
				if (File.Exists(path2))
				{
					MessageDialogScript overwriteDialog = ui.CreateMessageDialog(MessageDialogType.OkayCancel);
					overwriteDialog.MessageText = "A planetary system already exists with that name. Do you wish to overwrite it?";
					overwriteDialog.OkayButtonText = "OVERWRITE";
					overwriteDialog.UseDangerButtonStyle = true;
					yield return overwriteDialog.WaitForResult();
					if (overwriteDialog.Result.Value == MessageDialogResult.Cancel)
					{
						continue;
					}
				}
				if (updateSystemNameToMatchFile)
				{
					CurrentPlanetarySystem.Name = saveDialog.InputText;
				}
				OperationResult failure = SavePlanetarySystem(path2, useFilePaths: true);
				if (!failure.IsSuccess)
				{
					yield return ui.CreateErrorDialog("An error occurred saving the planetary system. " + failure.ErrorMessage, ErrorDialogOptions.LongError).WaitForResult();
				}
				LastSaveFilePath = CelestialFilePath.FromFullPath(path2);
				HasUnsavedChanges = false;
				onCompleted(failure);
				done = true;
			}
		}

		public void TareTime()
		{
			foreach (MapItem item in _itemRegistry.Items)
			{
				IOrbit orbit = item.OrbitInfo.OrbitNode.Orbit;
				orbit?.UpdateFromStateVectors(orbit.Position, orbit.Velocity, 0.0, orbit.PrimaryMass);
			}
			_gameTime.Time = 0.0;
		}

		public void UnloadPlanetarySystem()
		{
			LastSaveFilePath = null;
			_lastSaveFileName = null;
			_planetarySystemViewerScript.UnloadPlanetarySystem();
			foreach (CelestialFileDesignerInfo item in _celestialBodyFiles.Concat(_supportFiles))
			{
				if (item.Thumbnail != null)
				{
					UnityEngine.Object.Destroy(item.Thumbnail);
				}
			}
			if (_currentPlanetarySystem != null)
			{
				UnityEngine.Object.Destroy(_currentPlanetarySystem.gameObject);
				_currentPlanetarySystem = null;
			}
		}

		public bool ValidatePlanetOrbits()
		{
			List<IOrbitNode> list = _itemRegistry.OrbitNodes.Select((MapOrbitNode x) => x.OrbitInfo.OrbitNode).ToList();
			foreach (IOrbitNode item in list)
			{
				MapOrbitLine orbitLine = _itemRegistry.GetOrbitLine(item);
				if (orbitLine != null)
				{
					orbitLine.IsValidRendering = true;
					orbitLine.InvalidTrueAnomaly = null;
				}
			}
			if (!OrbitAnalyser.CheckForNodeEncounters(list, 1000.0, 50000, OnEachEncounterCheck, _mapViewManager.Ioc, _options.Targeting.SoiEntryLocalMinimaModifier) && !OrbitAnalyser.AnyChildrenLeavesParentSoi(_itemRegistry.RootPlanet.OrbitInfo.OrbitNode as IPlanetNode, OnEachLeftParentCheck) && !OrbitAnalyser.AnyChildrenSoiIntersectsParent(_itemRegistry.RootPlanet.OrbitInfo.OrbitNode as IPlanetNode, OnEachIntersectParentCheck))
			{
				return !HasDuplicatePlanets(_itemRegistry.Planets.Select((MapPlanet x) => x.OrbitInfo.OrbitNode as IPlanetNode).ToList(), OnEachDuplicateCheck);
			}
			return false;
			bool HasDuplicatePlanets(IReadOnlyList<IPlanetNode> planetNodes, Action<IOrbitNode, bool> callback)
			{
				bool result = false;
				List<IPlanetNode> list2 = planetNodes.ToList();
				while (list2.Count > 0)
				{
					IPlanetNode node = list2.First();
					list2.Remove(node);
					IEnumerable<IPlanetNode> enumerable = list2.Where((IPlanetNode x) => x.Name == node.Name);
					if (enumerable.Count() != 0)
					{
						callback(node, arg2: true);
						list2 = list2.Except(enumerable).ToList();
						result = true;
						_itemRegistry.GetOrbitLine(node).IsValidRendering = false;
						foreach (IPlanetNode item2 in enumerable)
						{
							_itemRegistry.GetOrbitLine(item2).IsValidRendering = false;
							callback(item2, arg2: true);
						}
					}
					else
					{
						callback(node, arg2: false);
					}
				}
				return result;
			}
			void OnEachDuplicateCheck(IOrbitNode node, bool invalid)
			{
				SetLineRenderingMode(node, invalid, null);
			}
			void OnEachEncounterCheck(IOrbitNode nodeA, IOrbitNode nodeB, bool encounterFound, OrbitAnalyser.SoiEnterInfo encounterInfo)
			{
				SetLineRenderingMode(nodeA, encounterFound, encounterInfo?.PointA);
				SetLineRenderingMode(nodeB, encounterFound, encounterInfo?.PointB);
				if (encounterFound)
				{
					Debug.Log($"Encounter found at {Units.GetRelativeTimeString(encounterInfo.Time)}, {encounterInfo.Time}s");
				}
			}
			void OnEachIntersectParentCheck(IOrbitNode parentNode, IOrbitNode childNode, bool childIntersectedParent)
			{
				SetLineRenderingMode(childNode, childIntersectedParent, childNode.Periapsis);
			}
			void OnEachLeftParentCheck(IOrbitNode parentNode, IOrbitNode childNode, bool childLeftParent)
			{
				SetLineRenderingMode(childNode, childLeftParent, childNode.Apoapsis);
			}
			void SetLineRenderingMode(IOrbitNode node, bool invalid, IOrbitPoint pointToPlaceError)
			{
				MapOrbitLine orbitLine2 = _itemRegistry.GetOrbitLine(node);
				if (orbitLine2 != null && invalid)
				{
					orbitLine2.IsValidRendering = false;
					orbitLine2.InvalidTrueAnomaly = pointToPlaceError?.TrueAnomaly;
				}
			}
		}

		public OperationResult ViewPlanetarySystem(bool cleanGeneratedData, bool? resetView = null)
		{
			try
			{
				_planetarySystemViewerScript.ViewPlanetarySystem(_currentPlanetarySystem.File, resetView ?? (_planetarySystemViewerScript.PlanetarySystemData == null));
				RootNode = CreatePlanetNodes(_currentPlanetarySystem.Planets);
				CreateMapView(ref _mapViewManager, RootNode, base.transform, _currentPlanetarySystem.MapViewScale, _currentPlanetarySystem.MaximumMapViewZoom);
				IMapViewContext context = _mapViewManager.MapView.Context;
				IIocContainer ioc = _mapViewManager.Ioc;
				_gameTime = ioc.Resolve<IGameTime>();
				_itemRegistry = ioc.Resolve<IItemRegistry>(context);
				_coordinateConverter = ioc.Resolve<IMapViewCoordinateConverter>(context);
				_options = ioc.Resolve<IMapOptions>();
				this.PlanetarySystemLoaded?.Invoke();
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		protected void Awake()
		{
			Instance = this;
			RegisterDevConsoleCommands();
			Game.EnsureInitialized();
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			if (!focus)
			{
				return;
			}
			CelestialFile celestialFile = _currentPlanetarySystem?.File;
			if (celestialFile == null)
			{
				return;
			}
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			List<(CelestialFile, FileInfo)> list = new List<(CelestialFile, FileInfo)>(CelestialBodyFiles.Count + 1) { (db.GetFile(celestialFile.Path), new FileInfo(celestialFile.Path.FullPath)) }.Where<(CelestialFile, FileInfo)>(((CelestialFile File, FileInfo Info) x) => x.Info.Exists && x.Info.LastWriteTime > x.File.LastModified).ToList();
			if (list.Count > 0)
			{
				list.ForEach(delegate((CelestialFile File, FileInfo Info) x)
				{
					Debug.Log("Reloading modified file: " + x.Info.FullName);
				});
				list.Select<(CelestialFile, FileInfo), string>(((CelestialFile File, FileInfo Info) x) => x.Info.Directory.FullName).Distinct().ToList()
					.ForEach(delegate(string x)
					{
						db.ScanFiles(x);
					});
				db.RefreshDatabase();
				celestialFile = db.GetFile(celestialFile.Path);
				LoadPlanetarySystem(celestialFile).Log();
				ViewPlanetarySystem(cleanGeneratedData: false, false).Log();
			}
		}

		protected void OnDestroy()
		{
			try
			{
				UnregisterDevConsoleCommands();
				UnloadPlanetarySystem();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			Instance = null;
		}

		protected virtual void Update()
		{
			OrbitMath.ReturnAllPoolItems();
			PlanetStudioTimeManager timeManager = _planetStudioUIScript.Controller.TimePanelController.TimeManager;
			RootNode.UpdateRotation(timeManager.DeltaTime);
		}

		private static void CreateMapView(ref MapViewManagerScript currentMapView, IPlanetNode rootNode, Transform parent, double scale, double maxZoomDistance)
		{
			if (currentMapView != null)
			{
				UnityEngine.Object.DestroyImmediate(currentMapView.gameObject);
			}
			currentMapView = MapViewManagerScript.Create(rootNode as PlanetNode, parent, scale, maxZoomDistance);
		}

		private static List<PlanetDataScript> GetPlanetDataScripts(IPlanetNode root)
		{
			List<PlanetDataScript> list = new List<PlanetDataScript>();
			if (root.PlanetData.OrbitData != null)
			{
				UpdateOrbitData(root.PlanetData.OrbitData, root.Orbit);
			}
			list.Add(root.PlanetData as PlanetDataScript);
			GetChildPlanetDataScripts(list, root);
			return list;
			static void GetChildPlanetDataScripts(List<PlanetDataScript> current, IPlanetNode parent)
			{
				foreach (IPlanetNode childPlanet in parent.ChildPlanets)
				{
					UpdateOrbitData(childPlanet.PlanetData.OrbitData, childPlanet.Orbit);
					current.Add(childPlanet.PlanetData as PlanetDataScript);
					GetChildPlanetDataScripts(current, childPlanet);
				}
			}
		}

		private static void UpdateOrbitData(OrbitData orbitData, IOrbit orbit)
		{
			orbitData.ArgumentOfPeriapsis = orbit.PeriapsisAngle;
			orbitData.Eccentricity = orbit.Eccentricity;
			orbitData.Inclination = orbit.Inclination;
			orbitData.Prograde = orbit.IsPrograde;
			orbitData.RightAscensionOfAscendingNode = orbit.RightAscensionOfAscendingNode;
			orbitData.SemiMajorAxis = orbit.SemiMajorAxis;
			orbitData.Time = orbit.Time;
			orbitData.TrueAnomaly = orbit.TrueAnomaly;
		}

		private IPlanetNode CreatePlanetNodes(List<PlanetDataScript> planetData)
		{
			PlanetNode result = null;
			Dictionary<PlanetDataScript, PlanetNode> dictionary = new Dictionary<PlanetDataScript, PlanetNode>();
			foreach (PlanetDataScript planetDatum in planetData)
			{
				PlanetNode parentNode = null;
				if (planetDatum.Parent != null)
				{
					parentNode = dictionary[planetDatum.Parent];
				}
				PlanetNode planetNode = CreatePlanetNode(parentNode, planetDatum);
				dictionary.Add(planetDatum, planetNode);
				if (planetNode.Parent == null)
				{
					result = planetNode;
				}
			}
			return result;
		}

		private void DrawDebugValidationInfo(IOrbitNode orbitNode, MapOrbitLine orbitLine, IOrbitNode otherNode)
		{
			OrbitAnalyser.GetAscendingDescendingNodes(orbitNode.Orbit, otherNode.Orbit, out var _, out var _, out var planeIntersection);
			Vector3d vector3d = _coordinateConverter.ConvertSolarToMapView(orbitNode.Parent.SolarPosition);
			DebugGizmos.DrawRay("PlaneIntersect_" + orbitNode.Name, (Vector3)vector3d, (Vector3)planeIntersection, (float)(100000000000.0 * _coordinateConverter.MapScale), Color.gray, 10);
		}

		private List<PlanetDataScript> GetAllChildren(PlanetDataScript parentCelestialBody, bool includeDescendants, bool includeRootParent)
		{
			List<PlanetDataScript> list = new List<PlanetDataScript>();
			list.Add(parentCelestialBody);
			bool flag = true;
			while (flag)
			{
				flag = false;
				foreach (PlanetDataScript planet in CurrentPlanetarySystem.Planets)
				{
					if (!list.Contains(planet) && list.Contains(planet.Parent))
					{
						list.Add(planet);
						flag = includeDescendants;
					}
				}
			}
			if (!includeRootParent)
			{
				list.RemoveAt(0);
			}
			return list;
		}

		private PlanetDataScript GetCelestialBodyScript(string localId)
		{
			CelestialFile file = _celestialBodyFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.Id == localId)?.File;
			if (file != null)
			{
				return CurrentPlanetarySystem.Planets.FirstOrDefault((PlanetDataScript x) => x.FileData.FileId == file.Id);
			}
			return null;
		}

		private List<CelestialFileReference> GetFileReferences(bool useFilePaths)
		{
			if (useFilePaths)
			{
				return (from x in _celestialBodyFiles.Concat(_supportFiles)
					select CelestialFileReference.CreateWithFilePath(x.Id, x.File)).ToList();
			}
			return (from x in _celestialBodyFiles.Concat(_supportFiles)
				select CelestialFileReference.CreateWithFileId(x.Id, x.File)).ToList();
		}

		private List<string> GetUsedLocalFileReferenceIds()
		{
			List<string> list = new List<string>();
			list.AddRange(CelestialBodyFiles.Select((CelestialFileDesignerInfo x) => x.Id));
			SkyboxData skyboxData = CurrentPlanetarySystem.SkyboxData;
			if (skyboxData != null)
			{
				list.Add(skyboxData.XNegativeTextureId);
				list.Add(skyboxData.XPositiveTextureId);
				list.Add(skyboxData.YNegativeTextureId);
				list.Add(skyboxData.YPositiveTextureId);
				list.Add(skyboxData.ZNegativeTextureId);
				list.Add(skyboxData.ZPositiveTextureId);
			}
			list.RemoveAll((string x) => string.IsNullOrWhiteSpace(x));
			return list.Distinct().ToList();
		}

		private void OnEditModeChanged(object sender, EventArgs e)
		{
			MapViewManager.MapView.MapViewUi.MapViewInspector.InspectorPanel.Visible = _planetStudioUIScript.EditMode == PlanetStudioEditMode.PlanetarySystem;
		}

		private void RegisterDevConsoleCommands()
		{
		}

		private void RemoveUnusedSupportFileReferences(List<CelestialFileReference> supportFileReferences)
		{
			List<string> ids = GetUsedLocalFileReferenceIds();
			foreach (string id in (from x in SupportFiles
				where !ids.Contains(x.Id)
				select x.Id).ToList())
			{
				if (supportFileReferences.RemoveAll((CelestialFileReference x) => x.LocalId == id) > 0)
				{
					Debug.Log("Removed unused support file '" + id + "'.");
				}
			}
		}

		private void Start()
		{
			_planetStudioUIScript.EditModeChanged += OnEditModeChanged;
		}

		private void UnregisterDevConsoleCommands()
		{
		}
	}
}
