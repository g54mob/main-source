using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.DevConsole;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Input;
using Assets.Scripts.PlanetStudio.Flyouts;
using Assets.Scripts.PlanetStudio.UI.Inspector;
using Assets.Scripts.Terrain.Rendering;
using ModApi;
using ModApi.CelestialData;
using ModApi.Flight.GameView;
using ModApi.Flight.UI;
using ModApi.Planet;
using ModApi.Planet.Modifiers;
using ModApi.PlanetStudio;
using ModApi.PlanetStudio.Events;
using ModApi.State;
using ModApi.Ui;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.PlanetStudio
{
	public class CelestialBodyDesignerScript : MonoBehaviour, ICelestialBodyDesigner
	{
		private PlanetStudioTool _activeTool;

		[SerializeField]
		private Transform _celestialBodyDataTransform;

		[SerializeField]
		private CelestialBodyViewerScript _celestialBodyViewerScript;

		[SerializeField]
		[HideInInspector]
		private PlanetDataScript _currentCelestialBody;

		private InputResponder _inputResponder = new InputResponder("CelestialBodyViewer");

		private CelestialBodyDesignerInspectorScript _inspector;

		private string _lastSaveFileName;

		private string _previousXml;

		[SerializeField]
		private bool _regenOnRandomize = true;

		private bool _reloadingDueToExternalXmlChange;

		[SerializeField]
		[HideInInspector]
		private List<CelestialFileDesignerInfo> _supportFiles;

		[SerializeField]
		private PlanetStudioUIScript _ui;

		public static double InitialBodyRotation { get; set; }

		public static Vector3d? InitialCameraPosition { get; set; }

		public static List<LaunchLocation> TestFlightLaunchLocations { get; private set; }

		public PlanetStudioTool ActiveTool
		{
			get
			{
				return _activeTool;
			}
			set
			{
				if (_activeTool != value)
				{
					if (_activeTool != null)
					{
						_activeTool.Deactivate();
					}
					_activeTool = value;
					if (_activeTool != null)
					{
						_activeTool.Activate();
					}
				}
			}
		}

		public CelestialBodyViewerScript CelestialBodyViewer => _celestialBodyViewerScript;

		ICelestialBodyViewer ICelestialBodyDesigner.CelestialBodyViewer => CelestialBodyViewer;

		public PlanetDataScript CurrentCelestialBody => _currentCelestialBody;

		public GameObject GameObject => base.gameObject;

		public IGameView GameView => _celestialBodyViewerScript.GameView;

		public bool HasUnsavedChanges { get; set; }

		public IInputResponder InputResponder => _inputResponder;

		public CelestialFilePath LastSaveFilePath { get; protected set; }

		public bool RegenOnRandomize
		{
			get
			{
				return _regenOnRandomize;
			}
			set
			{
				_regenOnRandomize = value;
			}
		}

		public IReadOnlyList<CelestialFileDesignerInfo> SupportFiles => _supportFiles;

		public IPlanetStudioUI UI => _ui;

		public event EventHandler<CelestialBodyLoadedEventArgs> CelestialBodyLoaded;

		public event EventHandler<CelestialBodyLoadingEventArgs> CelestialBodyLoading;

		public event EventHandler<CelestialBodyModifiedEventArgs> CelestialBodyModified;

		public event EventHandler<CelestialBodyUnloadedEventArgs> CelestialBodyUnloaded;

		public event EventHandler<CelestialBodyUnloadingEventArgs> CelestialBodyUnloading;

		public event EventHandler<CelestialBodyViewRefreshedEventArgs> CelestialBodyViewRefreshed;

		public event EventHandler<CelestialBodyViewRefreshedEventArgs> CelestialBodyViewRefreshing;

		public static void PrepareForTestFlight(Vector3d cameraPlanetPosition, double rotationAngle)
		{
			InitialCameraPosition = cameraPlanetPosition;
			InitialBodyRotation = rotationAngle;
			TestFlightLaunchLocations = new List<LaunchLocation>();
		}

		public static void RegisterGlobalDevConsoleCommands()
		{
			DevConsoleApi.RegisterCommand("PlanetStudio", delegate
			{
				Game.Instance.DevConsole.CloseConsole();
				Game.Instance.SceneManager.LoadPlanetStudio();
			});
		}

		public OperationResult AddSupportFile(string filePath)
		{
			try
			{
				CelestialFile celestialFile = Game.Instance.CelestialDatabase.AddSupportFile(filePath);
				string localId = CelestialFileNameUtility.ToFriendlyFileName(celestialFile.Path, includeExtension: false);
				return AddSupportFile(celestialFile, localId);
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
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
				CelestialFileDesignerInfo celestialFileDesignerInfo = _supportFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.Id == localId);
				if (celestialFileDesignerInfo != null)
				{
					string warningMessage = "Unable to add support file '" + file.Path.RelativePath + "' because a file with the same id has already been added. ID: " + localId + ", Path: " + celestialFileDesignerInfo.File.Path.RelativePath;
					return OperationResult.Failure((string)null, warningMessage);
				}
				_supportFiles.Add(new CelestialFileDesignerInfo(file, localId));
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult CloneCelestialBody(CelestialFile celestialBodyFile, string celestialBodyName, string celestialBodyFileName, bool useFilePaths)
		{
			if (!celestialBodyFileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
			{
				celestialBodyFileName += ".xml";
			}
			OperationResult operationResult = LoadCelestialBody(celestialBodyFile);
			if (!operationResult.IsSuccess)
			{
				return operationResult;
			}
			_currentCelestialBody.Name = celestialBodyName;
			string filePath = Path.Combine(Game.Instance.CelestialDatabase.Paths.UserData.CelestialBodies, celestialBodyFileName);
			operationResult = SaveCelestialBody(filePath, useFilePaths);
			_ = operationResult.IsSuccess;
			return operationResult;
		}

		public string GetOrCreateSupportFileReference(string fullPath)
		{
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			CelestialFile celestialFile = celestialDatabase.GetFile(CelestialFilePath.FromFullPath(fullPath));
			if (celestialFile == null)
			{
				celestialFile = celestialDatabase.AddSupportFile(fullPath);
			}
			CelestialFileDesignerInfo celestialFileDesignerInfo = _supportFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.File.Id == celestialFile.Id);
			if (celestialFileDesignerInfo == null)
			{
				SupportFileData supportFile = celestialDatabase.GetSupportFile(celestialFile.Id);
				string localId = supportFile.FriendlyName;
				int num = 0;
				while (_supportFiles.Any((CelestialFileDesignerInfo x) => x.Id == localId))
				{
					localId = $"{supportFile.FriendlyName}({++num})";
				}
				celestialFileDesignerInfo = new CelestialFileDesignerInfo(celestialFile, localId);
				_supportFiles.Add(celestialFileDesignerInfo);
			}
			return celestialFileDesignerInfo.Id;
		}

		public CelestialFile GetSupportFile(string localId)
		{
			return _supportFiles.FirstOrDefault((CelestialFileDesignerInfo x) => x.Id == localId)?.File;
		}

		public OperationResult LoadCelestialBody(CelestialFile celestialBodyFile)
		{
			try
			{
				UnloadCelestialBody();
				this.CelestialBodyLoading?.Invoke(this, new CelestialBodyLoadingEventArgs(_reloadingDueToExternalXmlChange));
				CelestialBodyFileData celestialBody = Game.Instance.CelestialDatabase.GetCelestialBody(celestialBodyFile.Id);
				if (celestialBody == null)
				{
					return OperationResult.Failure($"Unable to find the celestial body with id '{celestialBodyFile.Id}'");
				}
				_supportFiles = new List<CelestialFileDesignerInfo>();
				List<string> list = new List<string>();
				foreach (CelestialFileReference value in celestialBody.SupportFileReferences.Values)
				{
					OperationResult operationResult = AddSupportFile(value);
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
				_currentCelestialBody = PlanetDataScript.CreateFromFile(celestialBodyFile, null, null, null, createTerrainData: true, applyScaleAndOverrides: false);
				_currentCelestialBody.transform.SetParent(_celestialBodyDataTransform, worldPositionStays: false);
				if (celestialBodyFile.Path.InUserData)
				{
					LastSaveFilePath = celestialBodyFile.Path;
				}
				this.CelestialBodyLoaded?.Invoke(this, new CelestialBodyLoadedEventArgs(_reloadingDueToExternalXmlChange));
				return (list.Count == 0) ? OperationResult.Success() : OperationResult.Success(null, string.Join(Environment.NewLine, list));
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public void LoadCelestialBodyFromXml(XElement xml, CelestialFile celestialBodyFile)
		{
			UnloadCelestialBody();
			this.CelestialBodyLoading?.Invoke(this, new CelestialBodyLoadingEventArgs(_reloadingDueToExternalXmlChange));
			List<CelestialFileReference> list = (from x in xml.Elements("FileReferences").Elements("File")
				select CelestialFileReference.LoadFromXml(x)).ToList();
			_supportFiles = new List<CelestialFileDesignerInfo>();
			foreach (CelestialFileReference item in list)
			{
				AddSupportFile(item).Log();
			}
			_currentCelestialBody = PlanetDataScript.CreateFromXml(xml, celestialBodyFile, null, null, null, createTerrainData: true, applyScaleAndOverrides: false);
			_currentCelestialBody.transform.SetParent(_celestialBodyDataTransform, worldPositionStays: false);
			if (celestialBodyFile.Path.InUserData)
			{
				LastSaveFilePath = celestialBodyFile.Path;
			}
			this.CelestialBodyLoaded?.Invoke(this, new CelestialBodyLoadedEventArgs(_reloadingDueToExternalXmlChange));
		}

		public void RaiseCelestialBodyModifiedEvent()
		{
			HasUnsavedChanges = true;
			this.CelestialBodyModified?.Invoke(this, new CelestialBodyModifiedEventArgs());
		}

		public void RefreshQuadSphereRenderer()
		{
			if (CelestialBodyViewer?.TerrainRendererManager?.QuadSphereRenderers == null)
			{
				return;
			}
			foreach (QuadSphereRenderer item in CelestialBodyViewer?.TerrainRendererManager?.QuadSphereRenderers)
			{
				item.RefreshDataAndUpdateRenderer();
			}
		}

		public OperationResult RemoveSupportFile(string localId)
		{
			try
			{
				int num = _supportFiles.FindIndex((CelestialFileDesignerInfo x) => x.Id == localId);
				if (num >= 0)
				{
					_supportFiles.RemoveAt(num);
				}
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public OperationResult SaveCelestialBody(string filePath, bool useFilePaths)
		{
			try
			{
				if (_currentCelestialBody == null)
				{
					return OperationResult.Failure("Unable to save the celestial body because it is not loaded.");
				}
				XDocument xDocument = SaveXml(useFilePaths);
				xDocument.Save(filePath);
				BackupXml(xDocument);
				Game.Instance.CelestialDatabase.AddOrUpdateFile(CelestialFilePath.FromFullPath(filePath), refreshDatabase: true);
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public IEnumerator SaveCelestialBodyInteractive(string saveDialogText, Action<OperationResult> onCompleted)
		{
			IUserInterface ui = Game.Instance.UserInterface;
			if (_currentCelestialBody == null)
			{
				OperationResult failure = OperationResult.Failure("Unable to save the celestial body because it is not loaded.");
				yield return ui.CreateErrorDialog(failure.ErrorMessage).WaitForResult();
				onCompleted(failure);
				yield break;
			}
			string fileName = _lastSaveFileName;
			if (fileName == null)
			{
				CelestialFilePath path = CurrentCelestialBody.File.Path;
				fileName = (path.InGameData ? CurrentCelestialBody.Name : path.FileName.Remove(path.FileName.LastIndexOf('.')));
			}
			bool done = false;
			while (!done)
			{
				InputDialogScript saveDialog = ui.CreateInputDialog();
				saveDialog.InputPlaceholderText = "FILE NAME";
				saveDialog.MessageText = (string.IsNullOrWhiteSpace(saveDialogText) ? "Enter a file name to save the celestial body." : saveDialogText);
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
				string path2 = Path.Combine(Game.Instance.CelestialDatabase.Paths.UserData.CelestialBodies, saveDialog.InputText + ".xml");
				if (File.Exists(path2))
				{
					MessageDialogScript overwriteDialog = ui.CreateMessageDialog(MessageDialogType.OkayCancel);
					overwriteDialog.MessageText = "A celestial body already exists with that name. Do you wish to overwrite it?";
					overwriteDialog.OkayButtonText = "OVERWRITE";
					overwriteDialog.UseDangerButtonStyle = true;
					yield return overwriteDialog.WaitForResult();
					if (overwriteDialog.Result.Value == MessageDialogResult.Cancel)
					{
						continue;
					}
				}
				OperationResult failure = SaveCelestialBody(path2, useFilePaths: true);
				if (!failure.IsSuccess)
				{
					yield return ui.CreateErrorDialog("An error occurred saving the celestial body. " + failure.ErrorMessage).WaitForResult();
				}
				LastSaveFilePath = CelestialFilePath.FromFullPath(path2);
				HasUnsavedChanges = false;
				onCompleted(failure);
				done = true;
			}
		}

		public XDocument SaveXml(bool useFilePaths)
		{
			string text = (string.IsNullOrWhiteSpace(Game.Instance.Settings.UserName) ? "Unknown" : Game.Instance.Settings.UserName);
			if (text != _currentCelestialBody.Author)
			{
				_currentCelestialBody.Author = text;
				_currentCelestialBody.Version = new Version(1, 0);
				_currentCelestialBody.VersionTag = string.Empty;
			}
			List<CelestialFileReference> supportFileReferences = GetSupportFileReferences(useFilePaths);
			RemoveUnusedSupportFileReferences(supportFileReferences);
			return _currentCelestialBody.Save(supportFileReferences);
		}

		public void StartViewCelestialBodyInteractive(CelestialFile celestialBodyFile = null, bool cleanGeneratedData = false, bool? resetView = null, Action<OperationResult> onCompleted = null)
		{
			StartCoroutine(ViewCelestialBodyInteractive(celestialBodyFile, cleanGeneratedData, resetView, onCompleted));
		}

		public void UnloadCelestialBody()
		{
			this.CelestialBodyUnloading?.Invoke(this, new CelestialBodyUnloadingEventArgs(_reloadingDueToExternalXmlChange));
			LastSaveFilePath = null;
			_lastSaveFileName = null;
			_celestialBodyViewerScript.UnloadCelestialBody();
			if (_supportFiles != null)
			{
				foreach (CelestialFileDesignerInfo supportFile in _supportFiles)
				{
					if (supportFile.Thumbnail != null)
					{
						UnityEngine.Object.Destroy(supportFile.Thumbnail);
					}
				}
				_supportFiles.Clear();
			}
			if (_currentCelestialBody != null)
			{
				UnityEngine.Object.Destroy(_currentCelestialBody.gameObject);
				_currentCelestialBody = null;
			}
			this.CelestialBodyUnloaded?.Invoke(this, new CelestialBodyUnloadedEventArgs(_reloadingDueToExternalXmlChange));
		}

		public OperationResult ViewCelestialBody(bool cleanGeneratedData, bool? resetView = null)
		{
			try
			{
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				if (TestFlightLaunchLocations != null)
				{
					Debug.Log($"Adding {TestFlightLaunchLocations.Count} launch location(s) saved from flight scene.");
					CurrentCelestialBody.DefaultLaunchLocations.AddRange(TestFlightLaunchLocations);
					TestFlightLaunchLocations = null;
				}
				CelestialFilePath celestialFilePath = CelestialFilePath.FromRelativePath(celestialDatabase.SpecialFiles.PlanetStudioCelestialBody.RelativePath);
				OperationResult operationResult = SaveCelestialBody(celestialFilePath.FullPath, useFilePaths: false);
				if (!operationResult.IsSuccess)
				{
					return operationResult;
				}
				CelestialFile file = celestialDatabase.GetFile(celestialFilePath);
				if (cleanGeneratedData)
				{
					celestialDatabase.ClearGeneratedData(file.Id);
				}
				this.CelestialBodyViewRefreshing?.Invoke(this, new CelestialBodyViewRefreshedEventArgs(cleanGeneratedData));
				_celestialBodyViewerScript.ViewCelestialBody(file, resetView ?? (_celestialBodyViewerScript.PlanetScript.PlanetNode == null));
				if (InitialCameraPosition.HasValue)
				{
					_celestialBodyViewerScript.ResetView(InitialCameraPosition.Value);
					InitialCameraPosition = null;
				}
				this.CelestialBodyViewRefreshed?.Invoke(this, new CelestialBodyViewRefreshedEventArgs(cleanGeneratedData));
				return OperationResult.Success();
			}
			catch (Exception exception)
			{
				return OperationResult.Failure(exception);
			}
		}

		public IEnumerator ViewCelestialBodyInteractive(CelestialFile celestialBodyFile = null, bool cleanGeneratedData = false, bool? resetView = null, Action<OperationResult> onCompleted = null)
		{
			OperationResult result = null;
			try
			{
				UI.IsLoading = true;
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				bool view = true;
				if (celestialBodyFile != null)
				{
					result = LoadCelestialBody(celestialBodyFile);
					if (!result.IsSuccess && !result.IsCanceled)
					{
						view = false;
						result.Log();
						MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateErrorDialog("Unable to load celestial body: " + result.ErrorMessage, ErrorDialogOptions.LongError);
						yield return messageDialogScript.WaitForResult();
					}
					else if (!string.IsNullOrEmpty(result.WarningMessage))
					{
						result.Log();
						MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateErrorDialog("The celestial body was loaded with warnings: " + result.WarningMessage, ErrorDialogOptions.LongError);
						yield return messageDialogScript2.WaitForResult();
					}
				}
				if (view)
				{
					result = ViewCelestialBody(cleanGeneratedData, resetView);
					if (!result.IsSuccess && !result.IsCanceled)
					{
						result.Log();
						MessageDialogScript messageDialogScript3 = Game.Instance.UserInterface.CreateErrorDialog("Unable to view celestial body: " + result.ErrorMessage, ErrorDialogOptions.LongError);
						yield return messageDialogScript3.WaitForResult();
					}
				}
			}
			finally
			{
				UI.IsLoading = false;
			}
			yield return null;
			yield return null;
			onCompleted?.Invoke(result);
		}

		protected void Awake()
		{
			RegisterDevConsoleCommands();
			Game.EnsureInitialized();
			_inputResponder.IsResponding = () => base.gameObject.activeInHierarchy;
			InputResponder inputResponder = _inputResponder;
			inputResponder.OnScroll = (InputResponderDelegates.InputResponderDelegate)Delegate.Combine(inputResponder.OnScroll, new InputResponderDelegates.InputResponderDelegate(OnScroll));
			InputResponder inputResponder2 = _inputResponder;
			inputResponder2.OnPinch = (InputResponderDelegates.InputPinchResponderDelegate)Delegate.Combine(inputResponder2.OnPinch, new InputResponderDelegates.InputPinchResponderDelegate(OnPinch));
			InputResponder inputResponder3 = _inputResponder;
			inputResponder3.OnDrag = (InputResponderDelegates.InputResponderDelegate)Delegate.Combine(inputResponder3.OnDrag, new InputResponderDelegates.InputResponderDelegate(OnDrag));
			InputResponder inputResponder4 = _inputResponder;
			inputResponder4.OnPointerDown = (InputResponderDelegates.InputResponderDelegate)Delegate.Combine(inputResponder4.OnPointerDown, new InputResponderDelegates.InputResponderDelegate(OnPointerDown));
			InputResponder inputResponder5 = _inputResponder;
			inputResponder5.OnPointerClick = (InputResponderDelegates.InputResponderDelegate)Delegate.Combine(inputResponder5.OnPointerClick, new InputResponderDelegates.InputResponderDelegate(OnPointerClick));
			InputResponder inputResponder6 = _inputResponder;
			inputResponder6.OnPointerUp = (InputResponderDelegates.InputResponderDelegate)Delegate.Combine(inputResponder6.OnPointerUp, new InputResponderDelegates.InputResponderDelegate(OnPointerUp));
			_inspector = CelestialBodyDesignerInspectorScript.Create(this);
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			if (!focus)
			{
				return;
			}
			CelestialFile celestialFile = _currentCelestialBody?.File;
			if (celestialFile == null)
			{
				return;
			}
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			List<(CelestialFile, FileInfo)> list = new List<(CelestialFile, FileInfo)>(SupportFiles.Count + 1) { (db.GetFile(celestialFile.Path), new FileInfo(celestialFile.Path.FullPath)) }.Where<(CelestialFile, FileInfo)>(((CelestialFile File, FileInfo Info) x) => x.Info.Exists && x.Info.LastWriteTime > x.File.LastModified).ToList();
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
				_reloadingDueToExternalXmlChange = true;
				StartViewCelestialBodyInteractive(celestialFile, cleanGeneratedData: false, false, delegate
				{
					_reloadingDueToExternalXmlChange = false;
				});
			}
		}

		protected void OnDestroy()
		{
			try
			{
				UnregisterDevConsoleCommands();
				UnloadCelestialBody();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			ActiveTool?.Update(Time.deltaTime);
			if (Game.Instance.Inputs.PlanetStudioRebuildPlanet.GetButtonDownIfEnabled())
			{
				StartViewCelestialBodyInteractive(null, CelestialBodyViewer.QuadSphereScaledSpaceTransitionEnabled, false);
			}
		}

		private void BackupXml(XDocument xmlDocument)
		{
			string text = xmlDocument.ToString();
			string previousXml = _previousXml;
			_previousXml = text;
			if (previousXml != null && previousXml != text)
			{
				DateTime now = DateTime.Now;
				string arg = (string)xmlDocument.Root.Attribute("name");
				string text2 = Path.Combine(Game.PersistentDataPath, string.Format("Dev\\Celestial Body Backups\\{0}\\{1}_{2}.xml", now.ToString("yyyy-MM-dd"), arg, now.ToString("HHmmss")));
				FileInfo fileInfo = new FileInfo(text2);
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				File.WriteAllText(text2, text);
			}
		}

		private List<CelestialFileReference> GetSupportFileReferences(bool useFilePaths)
		{
			if (useFilePaths)
			{
				return _supportFiles.Select((CelestialFileDesignerInfo x) => CelestialFileReference.CreateWithFilePath(x.Id, x.File)).ToList();
			}
			return _supportFiles.Select((CelestialFileDesignerInfo x) => CelestialFileReference.CreateWithFileId(x.Id, x.File)).ToList();
		}

		private List<string> GetUsedLocalFileReferenceIds()
		{
			List<string> list = new List<string>();
			list.AddRange(CurrentCelestialBody.TerrainData.Modifiers.SelectMany((PlanetModifier x) => x.GetSupportFileReferences()));
			list.AddRange(CurrentCelestialBody.TerrainData.Biomes.SelectMany((PlanetBiome b) => b.Modifiers.SelectMany((PlanetModifier x) => x.GetSupportFileReferences())));
			list.Add(CurrentCelestialBody.RingsData?.Texture);
			list.RemoveAll((string x) => string.IsNullOrWhiteSpace(x));
			return list.Distinct().ToList();
		}

		private bool OnDrag(PointerEventData eventData)
		{
			bool flag = false;
			if (ActiveTool != null)
			{
				flag = ActiveTool.OnDrag(eventData);
			}
			if (!flag)
			{
				CelestialBodyViewer.MovementScript.Drag(eventData);
			}
			return true;
		}

		private bool OnPinch(PinchEventData eventData)
		{
			bool flag = false;
			if (!flag)
			{
				float num = (eventData.Distance - eventData.DistanceDelta) / eventData.Distance;
				flag = CelestialBodyViewer.MovementScript.Zoom(num);
			}
			return flag;
		}

		private bool OnPointerClick(PointerEventData eventData)
		{
			if (ActiveTool == null && eventData.button == PointerEventData.InputButton.Left && eventData.clickCount == 2)
			{
				Vector3d? vector3d = CelestialBodyViewer.RaycastTerrain(eventData.position, useGraphicsRaycaster: true);
				RaycastHit? raycasthit = CelestialBodyViewer.PhysicsRaycast(eventData.position, 10000f);
				if (raycasthit.HasValue)
				{
					Vector3d vector3d2 = CelestialBodyViewer.ReferenceFrame.FrameToPlanetPosition(raycasthit.Value.point);
					PlanetObjectsFlyoutScript flyout = _ui.GetFlyout<PlanetObjectsFlyoutScript>();
					flyout?.OnColliderSelected(raycasthit.Value.collider);
					CelestialBodyViewer.MovementScript.Focus(vector3d2);
					if (DebugInput.GetKey(KeyCode.LeftShift) && flyout != null)
					{
						if (DebugInput.GetKey(KeyCode.Alpha1))
						{
							flyout.AddWindow(raycasthit, 1);
						}
						else if (DebugInput.GetKey(KeyCode.Alpha2))
						{
							flyout.AddWindow(raycasthit, 2);
						}
						else if (DebugInput.GetKey(KeyCode.Alpha3))
						{
							flyout.AddWindow(raycasthit, 3);
						}
						else if (DebugInput.GetKey(KeyCode.Alpha4))
						{
							flyout.AddWindow(raycasthit, 4);
						}
						else
						{
							flyout.AddWindow(raycasthit, 0);
						}
					}
					Vector3d surfacePosition = CelestialBodyViewer.PlanetScript.PlanetNode.PlanetVectorToSurfaceVector(vector3d2);
					CelestialBodyViewer.PlanetScript.PlanetNode.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
					double terrainHeight = CelestialBodyViewer.PlanetScript.PlanetNode.GetTerrainHeight(vector3d2);
					double num = vector3d2.magnitude - (CelestialBodyViewer.PlanetScript.PlanetNode.PlanetData.Radius + terrainHeight);
					Debug.Log($"Lat/Lon/AGL: {latitude * 57.29578},{longitude * 57.29578},{num}");
					return true;
				}
				if (vector3d.HasValue)
				{
					CelestialBodyViewer.MovementScript.Focus(vector3d.Value);
					return true;
				}
			}
			return false;
		}

		private bool OnPointerDown(PointerEventData eventData)
		{
			return ActiveTool?.OnPointerDown(eventData) ?? false;
		}

		private bool OnPointerUp(PointerEventData eventData)
		{
			return ActiveTool?.OnPointerUp(eventData) ?? false;
		}

		private bool OnScroll(PointerEventData eventData)
		{
			if (0 == 0 && (Game.Instance.UserInterface.ActiveDialog == null || Game.Instance.UserInterface.ActiveDialog.AllowCameraZoom))
			{
				float num = eventData.scrollDelta.y;
				if (Device.IsOsxRuntime)
				{
					num = Mathf.Clamp(num / 2f, -8f, 8f);
				}
				float num2 = 1.25f;
				float num3 = 1f - num * 0.05f * num2;
				return CelestialBodyViewer.MovementScript.Zoom(num3);
			}
			return false;
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

		private void UnregisterDevConsoleCommands()
		{
		}
	}
}
