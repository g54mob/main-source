using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Packages.DevConsole;
using Assets.Scripts.DevConsole;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Menu.ListView.Career;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Ui.GradientEditor;
using Assets.Scripts.Ui.Inspector;
using Assets.Scripts.Ui.Settings;
using CodeStage.AdvancedFPSCounter;
using ModApi;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Ui;
using ModApi.Ui.Events;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class UserInterface : IUserInterface
	{
		private bool _anyDialogsOpen;

		private BuildInspectorPanelDelegate _buildAllInspectorPanelActions;

		private BuildUserInterfaceXmlDelegate _buildAllUserInterfaceXmlActions;

		private Dictionary<string, BuildInspectorPanelDelegate> _buildInspectorPanelActions;

		private Dictionary<string, BuildUserInterfaceXmlDelegate> _buildUserInterfaceXmlActions;

		private GameObject _fpsDisplay;

		private InspectorController _inspectorController;

		private List<IDialog> _openDialogs = new List<IDialog>();

		public IDialog ActiveDialog
		{
			get
			{
				if (_openDialogs.Count > 0)
				{
					return _openDialogs[_openDialogs.Count - 1];
				}
				return null;
			}
		}

		public bool AnyDialogsOpen
		{
			get
			{
				return _anyDialogsOpen;
			}
			private set
			{
				bool anyDialogsOpen = _anyDialogsOpen;
				_anyDialogsOpen = value;
				if (_anyDialogsOpen != anyDialogsOpen)
				{
					this.AnyDialogsOpenChanged?.Invoke(value);
				}
			}
		}

		public Camera Camera { get; private set; }

		public bool IgnoreKeyboardInputs
		{
			get
			{
				if (!IsTextInputFocused && !ControlSettingsDialogScript.CurrentlyBindingInput)
				{
					return DevConsoleManagerScript.IsConsoleOpen;
				}
				return true;
			}
		}

		public bool InspectorPanelsVisible
		{
			get
			{
				return _inspectorController?.gameObject.activeSelf ?? false;
			}
			set
			{
				if (_inspectorController != null)
				{
					_inspectorController.gameObject.SetActive(value);
				}
			}
		}

		public bool IsTextInputFocused
		{
			get
			{
				GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
				if (currentSelectedGameObject != null)
				{
					InputField component2;
					if (!currentSelectedGameObject.TryGetComponent<TMP_InputField>(out var _))
					{
						return currentSelectedGameObject.TryGetComponent<InputField>(out component2);
					}
					return true;
				}
				return false;
			}
		}

		public IUIResourceDatabase ResourceDatabase => XmlLayoutResourceDatabase.instance;

		public Transform Transform { get; private set; }

		public event AnyDialogsOpenChangedHandler AnyDialogsOpenChanged;

		public event EventHandler<InspectorPanelLoadedEventArgs> InspectorPanelLoaded;

		public event EventHandler<InspectorPanelLoadingEventArgs> InspectorPanelLoading;

		public event EventHandler<UserInterfaceLoadedEventArgs> UserInterfaceLoaded;

		public event EventHandler<UserInterfaceLoadingEventArgs> UserInterfaceLoading;

		public UserInterface()
		{
			_buildInspectorPanelActions = new Dictionary<string, BuildInspectorPanelDelegate>();
			_buildUserInterfaceXmlActions = new Dictionary<string, BuildUserInterfaceXmlDelegate>();
			SceneManager.sceneUnloaded += OnSceneUnloaded;
			SceneManager.sceneLoaded += OnSceneLoaded;
			XmlLayoutResourceDatabase.instance.LoadedXml += OnUserInterfaceXmlLoaded;
			InitializeResourceDatabaseOverrides();
			UpdateDragThreshold();
			DevConsoleApi.RegisterCommand("RefreshUIResourceDatabase", delegate
			{
				InitializeResourceDatabaseOverrides();
				Game.Instance.SceneManager.LoadScene(Game.Instance.SceneManager.CurrentScene);
			});
		}

		public void AddBuildInspectorPanelAction(BuildInspectorPanelDelegate buildAction)
		{
			_buildAllInspectorPanelActions = (BuildInspectorPanelDelegate)Delegate.Combine(_buildAllInspectorPanelActions, buildAction);
		}

		public void AddBuildInspectorPanelAction(string inspectorId, BuildInspectorPanelDelegate buildAction)
		{
			inspectorId = inspectorId ?? string.Empty;
			if (_buildInspectorPanelActions.ContainsKey(inspectorId))
			{
				Dictionary<string, BuildInspectorPanelDelegate> buildInspectorPanelActions = _buildInspectorPanelActions;
				string key = inspectorId;
				buildInspectorPanelActions[key] = (BuildInspectorPanelDelegate)Delegate.Combine(buildInspectorPanelActions[key], buildAction);
			}
			else
			{
				_buildInspectorPanelActions[inspectorId] = buildAction;
			}
		}

		public void AddBuildUserInterfaceXmlAction(BuildUserInterfaceXmlDelegate buildAction)
		{
			_buildAllUserInterfaceXmlActions = (BuildUserInterfaceXmlDelegate)Delegate.Combine(_buildAllUserInterfaceXmlActions, buildAction);
		}

		public void AddBuildUserInterfaceXmlAction(string userInterfaceId, BuildUserInterfaceXmlDelegate buildAction)
		{
			userInterfaceId = userInterfaceId ?? string.Empty;
			if (_buildUserInterfaceXmlActions.ContainsKey(userInterfaceId))
			{
				Dictionary<string, BuildUserInterfaceXmlDelegate> buildUserInterfaceXmlActions = _buildUserInterfaceXmlActions;
				string key = userInterfaceId;
				buildUserInterfaceXmlActions[key] = (BuildUserInterfaceXmlDelegate)Delegate.Combine(buildUserInterfaceXmlActions[key], buildAction);
			}
			else
			{
				_buildUserInterfaceXmlActions[userInterfaceId] = buildAction;
			}
		}

		public void BuildUserInterfaceFromRequest(BuildUserInterfaceXmlRequest request, GameObject obj, object eventTarget, Action<IXmlLayoutController> layoutRebuiltAction)
		{
			if (Device.IsUnityEditor && obj.GetComponent<RectTransform>() == null)
			{
				Debug.LogError("Attempted to create an XmlLayout on an object that does not have a RectTransform. This probably isn't going to work.");
			}
			XmlLayout xmlLayout = obj.AddComponent<XmlLayout>();
			XmlLayoutController xmlLayoutController = obj.AddComponent<XmlLayoutController>();
			xmlLayoutController.EventTarget = eventTarget;
			xmlLayoutController.OnLayoutRebuilt = layoutRebuiltAction;
			BuildUserInterfaceFromRequest(request, xmlLayout);
		}

		public void BuildUserInterfaceFromRequest(BuildUserInterfaceXmlRequest request, IXmlLayout xmlLayout)
		{
			try
			{
				this.UserInterfaceLoading?.Invoke(this, new UserInterfaceLoadingEventArgs(request, xmlLayout));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			xmlLayout.Xml = BuildUserInterfaceXml(request);
			if (request.OnLayoutRebuilt != null)
			{
				IXmlLayoutController xmlLayoutController = xmlLayout.XmlLayoutController;
				xmlLayoutController.OnLayoutRebuilt = (Action<IXmlLayoutController>)Delegate.Combine(xmlLayoutController.OnLayoutRebuilt, request.OnLayoutRebuilt);
			}
			xmlLayout.RebuildLayout(forceEvenIfXmlUnchanged: true, throwExceptionIfXmlIsInvalid: true);
			try
			{
				this.UserInterfaceLoaded?.Invoke(this, new UserInterfaceLoadedEventArgs(request.UserInterfaceId, xmlLayout));
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}

		public T BuildUserInterfaceFromResource<T>(string xmlPath, Action<T, IXmlLayoutController> layoutRebuiltAction = null, Transform parentTransform = null) where T : MonoBehaviour
		{
			GameObject gameObject = UiUtilities.CreateUiGameObject(typeof(T).Name, parentTransform ?? Transform);
			T script = gameObject.AddComponent<T>();
			BuildUserInterfaceXmlRequest request = BuildUserInterfaceXmlRequest.CreateFromResource(xmlPath);
			BuildUserInterfaceFromRequest(request, gameObject, script, delegate(IXmlLayoutController controller)
			{
				layoutRebuiltAction?.Invoke(script, controller);
			});
			return script;
		}

		public void BuildUserInterfaceFromResource(string xmlPath, MonoBehaviour script, Action<IXmlLayoutController> layoutRebuiltAction)
		{
			BuildUserInterfaceXmlRequest request = BuildUserInterfaceXmlRequest.CreateFromResource(xmlPath);
			BuildUserInterfaceFromRequest(request, script.gameObject, script, layoutRebuiltAction);
		}

		public void BuildUserInterfaceFromResource(string xmlPath, IXmlLayout xmlLayout)
		{
			BuildUserInterfaceFromRequest(BuildUserInterfaceXmlRequest.CreateFromResource(xmlPath), xmlLayout);
		}

		public T BuildUserInterfaceFromXml<T>(string xml, string userInterfaceId, Action<T, IXmlLayoutController> layoutRebuiltAction = null, Transform parentTransform = null) where T : MonoBehaviour
		{
			GameObject gameObject = UiUtilities.CreateUiGameObject(typeof(T).Name, parentTransform ?? Transform);
			T script = gameObject.AddComponent<T>();
			BuildUserInterfaceXmlRequest request = BuildUserInterfaceXmlRequest.CreateFromXml(xml, userInterfaceId);
			BuildUserInterfaceFromRequest(request, gameObject, script, delegate(IXmlLayoutController controller)
			{
				layoutRebuiltAction?.Invoke(script, controller);
			});
			return script;
		}

		public void BuildUserInterfaceFromXml(string xml, string userInterfaceId, MonoBehaviour script, Action<IXmlLayoutController> layoutRebuiltAction)
		{
			BuildUserInterfaceXmlRequest request = BuildUserInterfaceXmlRequest.CreateFromXml(xml, userInterfaceId);
			BuildUserInterfaceFromRequest(request, script.gameObject, script, layoutRebuiltAction);
		}

		public void BuildUserInterfaceFromXml(string xml, string userInterfaceId, IXmlLayout xmlLayout)
		{
			BuildUserInterfaceFromRequest(BuildUserInterfaceXmlRequest.CreateFromXml(xml, userInterfaceId), xmlLayout);
		}

		public CareerDialogScript CreateCareerDialog(bool allowChanges = true)
		{
			CareerDialogScript careerDialogScript = (UnityEngine.Object.Instantiate(Resources.Load("Ui/Prefabs/Dialog")) as GameObject).AddComponent<CareerDialogScript>();
			careerDialogScript.Initialize(allowChanges);
			careerDialogScript.transform.SetParent(Transform, worldPositionStays: false);
			return careerDialogScript;
		}

		public void CreateColorPicker(bool allowTransparency, Color initialColor, Action<Color> onComplete, Action<Color> onPreviewColorChanged = null, bool allowHDR = false)
		{
			ColorPickerDialogScript colorPickerDialogScript = ColorPickerDialogScript.Create(Transform, allowTransparency, allowHDR);
			colorPickerDialogScript.AdjustedColor = initialColor;
			colorPickerDialogScript.OkayClicked += delegate(ColorPickerDialogScript d)
			{
				onComplete(d.AdjustedColor);
				d.Close();
			};
			if (onPreviewColorChanged != null)
			{
				colorPickerDialogScript.ColorChanged += delegate(ColorPickerDialogScript d)
				{
					onPreviewColorChanged(d.AdjustedColor);
				};
			}
		}

		public void CreateCurveEditor(AnimationCurve curve, Action<AnimationCurve> saveBack)
		{
			CurveEditorDialogScript.Create(Transform, curve, saveBack);
		}

		public T CreateDialog<T>(Transform parent, bool registerWithUserInterface = true, bool fadeIn = true) where T : DialogScript
		{
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Ui/Prefabs/Dialog");
			gameObject.name = typeof(T).Name;
			Transform parent2 = ((parent != null) ? parent : Transform);
			gameObject.transform.SetParent(parent2, worldPositionStays: false);
			T val = gameObject.AddComponent<T>();
			val.FadeInUponStart = fadeIn;
			if (registerWithUserInterface)
			{
				RegisterDialog(val);
			}
			gameObject.AddComponent<TabSupportScript>().Initialize(val);
			return val;
		}

		public T CreateDialog<T>(string xmlResourcePath, Transform parent, Action<T, IXmlLayoutController> layoutRebuiltAction, Action<T> initializeAction = null, bool fadeIn = true) where T : DialogScript
		{
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Ui/Prefabs/Dialog");
			gameObject.name = typeof(T).Name;
			Transform parent2 = ((parent != null) ? parent : Transform);
			gameObject.transform.SetParent(parent2, worldPositionStays: false);
			T dialog = gameObject.AddComponent<T>();
			dialog.FadeInUponStart = fadeIn;
			RegisterDialog(dialog);
			gameObject.AddComponent<TabSupportScript>().Initialize(dialog);
			initializeAction?.Invoke(dialog);
			BuildUserInterfaceFromResource(xmlResourcePath, dialog, delegate(IXmlLayoutController x)
			{
				layoutRebuiltAction(dialog, x);
			});
			return dialog;
		}

		public ModApi.Ui.MessageDialogScript CreateErrorDialog(string errorMessage, Action action = null, Transform parent = null)
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = CreateMessageDialog(MessageDialogType.Okay, parent);
			messageDialogScript.MessageText = errorMessage;
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				action?.Invoke();
			};
			return messageDialogScript;
		}

		public ModApi.Ui.MessageDialogScript CreateErrorDialog(string errorMessage, ErrorDialogOptions options)
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = CreateMessageDialog(MessageDialogType.Okay, options.ParentTransform);
			messageDialogScript.MessageText = errorMessage;
			messageDialogScript.ExtraWide = options.ExtraWide;
			messageDialogScript.MaxLines = options.MaxLines;
			if (!string.IsNullOrWhiteSpace(options.OkayButtonText))
			{
				messageDialogScript.OkayButtonText = options.OkayButtonText;
			}
			if (!string.IsNullOrWhiteSpace(options.TruncationMessage))
			{
				messageDialogScript.TruncationMessage = options.TruncationMessage;
			}
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				options.OnCloseAction?.Invoke();
			};
			return messageDialogScript;
		}

		public void CreateGradientEditor(Gradient gradient, Action<Gradient> saveBack, bool hasAlpha, bool allowHDR)
		{
			GradientEditorDialogScript.Create(Transform, gradient, saveBack, hasAlpha, allowHDR);
		}

		public ModApi.Ui.InputDialogScript CreateInputDialog(Transform parent = null)
		{
			return InputDialogScript.Create(parent?.transform);
		}

		public IInspectorPanel CreateInspectorPanel(InspectorModel model, InspectorPanelCreationInfo creationInfo = null)
		{
			InitializeInspectorController();
			if (creationInfo == null)
			{
				creationInfo = new InspectorPanelCreationInfo();
			}
			BuildInspectorPanelRequest request = new BuildInspectorPanelRequest(model, creationInfo);
			this.InspectorPanelLoading?.Invoke(this, new InspectorPanelLoadingEventArgs(model, creationInfo));
			if (_buildInspectorPanelActions.TryGetValue(model.Id ?? string.Empty, out var value))
			{
				value?.Invoke(request);
			}
			_buildAllInspectorPanelActions?.Invoke(request);
			IInspectorPanel inspectorPanel = _inspectorController.ElementBuilder.CreatePanel(request);
			this.InspectorPanelLoaded?.Invoke(this, new InspectorPanelLoadedEventArgs(inspectorPanel, model));
			return inspectorPanel;
		}

		public IListView CreateListView(IListViewModel viewModel, IListViewObjectViewer objectViewer = null)
		{
			ListViewDialogScript listViewDialogScript = (UnityEngine.Object.Instantiate(Resources.Load("Ui/Prefabs/Dialog")) as GameObject).AddComponent<ListViewDialogScript>();
			listViewDialogScript.Initialize(viewModel as ListViewModel, objectViewer);
			listViewDialogScript.transform.SetParent(Transform, worldPositionStays: false);
			return listViewDialogScript;
		}

		public ModApi.Ui.MessageDialogScript CreateMessageDialog(MessageDialogType type = MessageDialogType.Okay, Transform parent = null, bool fadeIn = true)
		{
			return MessageDialogScript.Create(type, parent?.transform, fadeIn);
		}

		public ModApi.Ui.MessageDialogScript CreateMessageDialog(string message, Action action = null, Transform parent = null, bool fadeIn = true)
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = CreateMessageDialog(MessageDialogType.Okay, parent);
			messageDialogScript.FadeInUponStart = fadeIn;
			messageDialogScript.MessageText = message;
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				action?.Invoke();
			};
			return messageDialogScript;
		}

		public void RegisterDialog(IDialog dialog)
		{
			if (!_openDialogs.Contains(dialog))
			{
				dialog.Closed += OnDialogClosed;
				_openDialogs.Add(dialog);
				AnyDialogsOpen = true;
				return;
			}
			throw new Exception("Dialog is already registered");
		}

		public void RemoveBuildInspectorPanelAction(BuildInspectorPanelDelegate buildAction)
		{
			_buildAllInspectorPanelActions = (BuildInspectorPanelDelegate)Delegate.Remove(_buildAllInspectorPanelActions, buildAction);
		}

		public void RemoveBuildInspectorPanelAction(string inspectorId, BuildInspectorPanelDelegate buildAction)
		{
			inspectorId = inspectorId ?? string.Empty;
			if (_buildInspectorPanelActions.ContainsKey(inspectorId))
			{
				Dictionary<string, BuildInspectorPanelDelegate> buildInspectorPanelActions = _buildInspectorPanelActions;
				string key = inspectorId;
				buildInspectorPanelActions[key] = (BuildInspectorPanelDelegate)Delegate.Remove(buildInspectorPanelActions[key], buildAction);
			}
		}

		public void RemoveBuildUserInterfaceXmlAction(BuildUserInterfaceXmlDelegate buildAction)
		{
			_buildAllUserInterfaceXmlActions = (BuildUserInterfaceXmlDelegate)Delegate.Remove(_buildAllUserInterfaceXmlActions, buildAction);
		}

		public void RemoveBuildUserInterfaceXmlAction(string userInterfaceId, BuildUserInterfaceXmlDelegate buildAction)
		{
			userInterfaceId = userInterfaceId ?? string.Empty;
			if (_buildUserInterfaceXmlActions.ContainsKey(userInterfaceId))
			{
				Dictionary<string, BuildUserInterfaceXmlDelegate> buildUserInterfaceXmlActions = _buildUserInterfaceXmlActions;
				string key = userInterfaceId;
				buildUserInterfaceXmlActions[key] = (BuildUserInterfaceXmlDelegate)Delegate.Remove(buildUserInterfaceXmlActions[key], buildAction);
			}
		}

		public void ToggleFps()
		{
			if (_fpsDisplay == null)
			{
				_fpsDisplay = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("DevConsole/FpsCounter"));
				_fpsDisplay.SetActive(value: false);
			}
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				Canvas componentInChildren = _fpsDisplay.GetComponentInChildren<Canvas>(includeInactive: true);
				if (componentInChildren != null)
				{
					componentInChildren.gameObject.AddMissingComponent<UserInterfaceScaleScript>();
					foreach (Transform item in componentInChildren.transform)
					{
						item.gameObject.AddMissingComponent<SafeAreaScript>();
					}
				}
			});
			bool flag = false;
			AFPSCounter component = _fpsDisplay.GetComponent<AFPSCounter>();
			if (!_fpsDisplay.activeSelf)
			{
				_fpsDisplay.SetActive(value: true);
			}
			else if (!component.memoryCounter.Enabled)
			{
				flag = true;
			}
			else
			{
				_fpsDisplay.SetActive(value: false);
				flag = false;
			}
			component.memoryCounter.Enabled = flag;
			component.deviceInfoCounter.Enabled = flag;
			component.fpsCounter.Milliseconds = flag;
			component.fpsCounter.Average = flag;
			component.fpsCounter.MinMax = flag;
		}

		public void UnregisterDialog(IDialog dialog)
		{
			if (_openDialogs.Contains(dialog))
			{
				dialog.Closed -= OnDialogClosed;
				_openDialogs.Remove(dialog);
				AnyDialogsOpen = _openDialogs.Count > 0;
			}
		}

		private string BuildUserInterfaceXml(BuildUserInterfaceXmlRequest request)
		{
			try
			{
				if (_buildUserInterfaceXmlActions.TryGetValue(request.UserInterfaceId ?? string.Empty, out var value))
				{
					value?.Invoke(request);
				}
				_buildAllUserInterfaceXmlActions?.Invoke(request);
				return request.Xml;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return request.Xml;
			}
		}

		private void InitializeInspectorController()
		{
			if (_inspectorController == null)
			{
				if (Transform == null)
				{
					Debug.LogError("Inspector is currently only supported in designer and flight scenes");
				}
				_inspectorController = InspectorController.Create(Transform);
			}
		}

		private void InitializeResourceDatabaseOverrides()
		{
			try
			{
				XmlLayoutCustomResourceDatabase xmlLayoutCustomResourceDatabase = XmlLayoutResourceDatabase.instance.customResourceDatabases.FirstOrDefault((XmlLayoutCustomResourceDatabase x) => x.name == "UIResourceDatabase");
				if (xmlLayoutCustomResourceDatabase == null)
				{
					Debug.LogError("Could not find XmlLayoutResourceDatabase 'UIResourceDatabase'");
					return;
				}
				string path = Path.Combine(Game.PersistentDataPath, "UserInterface");
				string text = Path.Combine(path, "Reference");
				string text2 = Path.Combine(path, "Overrides");
				bool flag = Game.Instance.Settings.AppVersionLastRun != Game.Version;
				if (!Directory.Exists(text) || flag)
				{
					try
					{
						if (Directory.Exists(text))
						{
							Utilities.DeleteDirectory(text);
						}
						Directory.CreateDirectory(text);
						foreach (XmlLayoutResourceEntry item in xmlLayoutCustomResourceDatabase.entries.Where((XmlLayoutResourceEntry x) => x.resource is TextAsset && x.path.StartsWith("Ui/Xml/", StringComparison.OrdinalIgnoreCase)))
						{
							FileInfo fileInfo = new FileInfo(Path.Combine(text, item.path + ".xml"));
							if (!fileInfo.Directory.Exists)
							{
								fileInfo.Directory.Create();
							}
							File.WriteAllText(fileInfo.FullName, ((TextAsset)item.resource).text);
						}
					}
					catch (Exception exception)
					{
						Debug.LogError("An error occurred initializing the UI XML reference files.");
						Debug.LogException(exception);
					}
				}
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				else if (flag && Directory.EnumerateFileSystemEntries(text2, "*", SearchOption.AllDirectories).Any())
				{
					Directory.Move(text2, text2 + "_Backup_" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss"));
					Directory.CreateDirectory(text2);
				}
				int num = 0;
				Uri uri = new Uri(text2);
				string[] files = Directory.GetFiles(uri.OriginalString, "*.*", SearchOption.AllDirectories);
				foreach (string text3 in files)
				{
					UnityEngine.Object obj = null;
					if (text3.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
					{
						obj = new TextAsset(File.ReadAllText(text3));
					}
					else if (text3.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || text3.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || text3.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
					{
						Texture2D texture2D = new Texture2D(2, 2);
						texture2D.LoadImage(File.ReadAllBytes(text3));
						obj = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(texture2D.width / 2, texture2D.height / 2));
					}
					if (obj != null)
					{
						string assetPath = Uri.UnescapeDataString(uri.MakeRelativeUri(new Uri(text3)).ToString()).Replace(Path.DirectorySeparatorChar, '/').Replace(Path.AltDirectorySeparatorChar, '/');
						assetPath = assetPath.Substring(assetPath.IndexOf('/') + 1);
						assetPath = assetPath.Substring(0, assetPath.Length - 4);
						XmlLayoutResourceEntry xmlLayoutResourceEntry = xmlLayoutCustomResourceDatabase.entries.FirstOrDefault((XmlLayoutResourceEntry x) => x.path == assetPath);
						if (xmlLayoutResourceEntry != null)
						{
							xmlLayoutCustomResourceDatabase.entries.Remove(xmlLayoutResourceEntry);
						}
						xmlLayoutCustomResourceDatabase.AddEntry(assetPath, obj);
						num++;
					}
				}
				if (num > 0)
				{
					Debug.Log("UI Overrides Count: " + num);
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}

		private void OnDialogClosed(IDialog dialog)
		{
			UnregisterDialog(dialog);
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			if (Game.InFlightScene)
			{
				Transform = Game.Instance.FlightScene.FlightSceneUI.Transform;
				if (Transform != null)
				{
					InitializeInspectorController();
				}
			}
			else if (Game.InDesignerScene)
			{
				Transform = Game.Instance.Designer.DesignerUi.Transform;
			}
			else if (Game.InMenuScene)
			{
				Transform = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault((GameObject x) => x.name == "Menu")?.transform;
			}
			else if (Game.InPlanetStudioScene)
			{
				Transform = PlanetStudioScript.Instance.PlanetStudioUI.Transform;
			}
			else if (Game.InTechTreeScene)
			{
				Transform = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault((GameObject x) => x.name == "UserInterface")?.transform;
			}
			else
			{
				Transform = null;
			}
			Camera = UnityEngine.Object.FindObjectOfType<PrimaryUICameraScript>()?.GetComponent<Camera>();
			UpdateDragThreshold();
		}

		private void OnSceneUnloaded(Scene scene)
		{
			Camera = null;
			_openDialogs.Clear();
			AnyDialogsOpen = false;
			_inspectorController = null;
			Transform = null;
		}

		private void OnUserInterfaceXmlLoaded(object sender, XmlLayoutResourceDatabase.LoadedXmlEventArgs e)
		{
			BuildUserInterfaceXmlRequest buildUserInterfaceXmlRequest = BuildUserInterfaceXmlRequest.CreateFromXml(e.Xml, e.Path);
			e.Xml = BuildUserInterfaceXml(buildUserInterfaceXmlRequest);
			e.OnLayoutRebuilt = buildUserInterfaceXmlRequest.OnLayoutRebuilt;
		}

		private void UpdateDragThreshold()
		{
			EventSystem.current.pixelDragThreshold = 5;
			if (Screen.dpi > 0f && Device.IsMobileBuild)
			{
				int pixelDragThreshold = EventSystem.current.pixelDragThreshold;
				int b = (int)((float)pixelDragThreshold * Screen.dpi / 160f * Game.Instance.QualitySettings.Display.MobileResolutionScale.Value);
				EventSystem.current.pixelDragThreshold = Mathf.Max(pixelDragThreshold, b);
			}
		}
	}
}
