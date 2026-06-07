using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Net;
using Assets.Scripts.Scenes.Startup;
using Assets.Scripts.UI.Activity;
using Assets.Scripts.UI.CurveEditor;
using Assets.Scripts.UI.Dialogs;
using Assets.Scripts.UI.Settings;
using Assets.Scripts.UI.Settings.Controls;
using Assets.Scripts.UI.Sharing;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	public class UserInterface : ILinkHandler
	{
		private bool _anyDialogsOpen;

		private AudioSource _audioSource;

		private List<IDialog> _openDialogs = new List<IDialog>();

		private UserInterfaceScript _script;

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

		public bool AllowKeyboardInputs
		{
			get
			{
				if (!AnyDialogsOpen && !IsTextInputFocused)
				{
					return !SimplePlanesDevConsoleScript.IsConsoleOpen;
				}
				return false;
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

		public bool IsTextInputFocused
		{
			get
			{
				GameObject gameObject = EventSystem.current?.currentSelectedGameObject;
				if (gameObject != null)
				{
					InputField component2;
					if (!gameObject.TryGetComponent<TMP_InputField>(out var _))
					{
						return gameObject.TryGetComponent<InputField>(out component2);
					}
					return true;
				}
				return false;
			}
		}

		public ResourceLoader ResourceLoader { get; private set; }

		public UserInterfaceSoundPlayer Sound { get; } = new UserInterfaceSoundPlayer();

		public RectTransform Transform { get; private set; }

		public event AnyDialogsOpenChangedHandler AnyDialogsOpenChanged;

		public UserInterface(GameObject persistentScriptsGameObject)
		{
			SceneManager.sceneUnloaded += OnSceneUnloaded;
			SceneManager.sceneLoaded += OnSceneLoaded;
			GameObject gameObject = new GameObject("UIAudio");
			gameObject.transform.SetParent(persistentScriptsGameObject.transform, worldPositionStays: false);
			_audioSource = gameObject.AddComponent<AudioSource>();
			_audioSource.spatialBlend = 0f;
			_audioSource.playOnAwake = false;
			ResourceLoader = new ResourceLoader("UI/Widgets", "UI", GetType().Assembly);
			InitializeScript();
		}

		public ColorPickerDialogScript CreateColorPickerDialog()
		{
			ColorPickerDialogScript componentInChildren = _script.Context.LoadWidgetFromXml("Xml/Dialogs/ColorPickerDialog", _script.Context.Root).GetComponentInChildren<ColorPickerDialogScript>(includeInactive: true);
			componentInChildren.Initialize();
			return componentInChildren;
		}

		public ContentDownloadDialogScript CreateContentDownloadDialog()
		{
			return CreateDialog<ContentDownloadDialogScript>("Xml/Dialogs/ContentDownloadDialog");
		}

		public WidgetContext CreateContext(RectTransform rectTransform, object eventHandler)
		{
			return new WidgetContext(rectTransform, eventHandler, ResourceLoader, _audioSource)
			{
				LinkHandler = this,
				TooltipService = new TooltipService()
			};
		}

		public ControlSettingsDialogScript CreateControlSettingsDialog()
		{
			return CreateDialog<ControlSettingsDialogScript>("Xml/Dialogs/Controls/ControlSettingsDialog");
		}

		public CraftDownloadDialogScript CreateCraftDownloadDialog()
		{
			return CreateDialog<CraftDownloadDialogScript>("Xml/Dialogs/CraftDownloadDialog");
		}

		public CreateServerDialogScript CreateCreateServerDialog()
		{
			return CreateDialog<CreateServerDialogScript>("Xml/Dialogs/CreateServerDialog");
		}

		public CurveEditorDialogScript CreateCurveEditor(AnimationCurve curve, Action<AnimationCurve> saveBack)
		{
			CurveEditorDialogScript curveEditorDialogScript = CreateDialog<CurveEditorDialogScript>("Xml/Dialogs/CurveEditor");
			curveEditorDialogScript.Initialize(curve, saveBack);
			return curveEditorDialogScript;
		}

		public CustomizeCharacterScript CreateCustomizeCharacterFlyout()
		{
			CustomizeCharacterScript componentInChildren = _script.Context.LoadWidgetFromXml("Xml/CustomizeCharacter", _script.Context.Root).GetComponentInChildren<CustomizeCharacterScript>(includeInactive: true);
			componentInChildren.Flyout.Show(show: true);
			return componentInChildren;
		}

		public T CreateDialog<T>(string xmlResourcePath) where T : IDialog
		{
			IDialog componentInChildren = _script.Context.LoadWidgetFromXml(xmlResourcePath, _script.Context.Root).GetComponentInChildren<IDialog>();
			RegisterDialog(componentInChildren);
			return (T)componentInChildren;
		}

		public InputDialogScript CreateInputDialog()
		{
			return CreateDialog<InputDialogScript>("Xml/Dialogs/InputDialog");
		}

		public LoginDialogScript CreateLoginDialog()
		{
			return CreateDialog<LoginDialogScript>("Xml/Dialogs/LoginDialog");
		}

		public MessageDialogScript CreateMessageDialog(string messageText, string titleText = null, string buttonText = null, Action<MessageDialogScript> buttonClickAction = null)
		{
			MessageDialogScript messageDialogScript = CreateMessageDialog(MessageDialogType.Okay, messageText, titleText, buttonClickAction);
			if (buttonText != null)
			{
				messageDialogScript.OkayButtonText = buttonText;
			}
			return messageDialogScript;
		}

		public MessageDialogScript CreateMessageDialog(MessageDialogType type = MessageDialogType.Okay, string messageText = null, string titleText = null, Action<MessageDialogScript> okayClicked = null)
		{
			MessageDialogScript messageDialogScript = CreateDialog<MessageDialogScript>("Xml/Dialogs/MessageDialog");
			messageDialogScript.MessageDialogType = type;
			if (!string.IsNullOrEmpty(messageText))
			{
				messageDialogScript.MessageText = messageText;
			}
			if (!string.IsNullOrEmpty(titleText))
			{
				messageDialogScript.Title = titleText;
			}
			if (okayClicked != null)
			{
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					okayClicked(d);
				};
			}
			return messageDialogScript;
		}

		public NetworkStatsDialogScript CreateNetworkStatsDialog()
		{
			return CreateDialog<NetworkStatsDialogScript>("Xml/Dialogs/NetworkStatsDialog");
		}

		public PerformanceStatsDialogScript CreatePerformanceStatsDialog()
		{
			return CreateDialog<PerformanceStatsDialogScript>("Xml/Dialogs/PerformanceStatsDialog");
		}

		public ProgressBarDialogScript CreateProgressBarDialog()
		{
			return CreateDialog<ProgressBarDialogScript>("Xml/Dialogs/ProgressBarDialog");
		}

		public ResolutionDialogScript CreateResolutionDialog()
		{
			return CreateDialog<ResolutionDialogScript>("Xml/Dialogs/ResolutionDialog");
		}

		public ScreenshotDialogScript CreateScreenshotDialog(IScreenshotDialogHandler handler)
		{
			ScreenshotDialogScript screenshotDialogScript = CreateDialog<ScreenshotDialogScript>("Xml/Sharing/ScreenshotDialog");
			screenshotDialogScript.Initialize(handler);
			return screenshotDialogScript;
		}

		public SelectActivityDialogScript CreateSelectActivityDialog()
		{
			return CreateDialog<SelectActivityDialogScript>("Xml/Activity/SelectActivityDialog");
		}

		public ServerBrowserDialogScript CreateServerBrowserDialog()
		{
			return CreateDialog<ServerBrowserDialogScript>("Xml/Dialogs/ServerBrowserDialog");
		}

		public SettingsDialogScript CreateSettingsDialog()
		{
			return CreateDialog<SettingsDialogScript>("Xml/Dialogs/SettingsDialog");
		}

		public TexturePickerScript CreateTexturePickerFlyout(IEnumerable<TexturePickerItem> textures, string initiallySelectedId = null, Widget parent = null)
		{
			TexturePickerScript componentInChildren = _script.Context.LoadWidgetFromXml("Xml/Dialogs/TexturePicker", parent ?? _script.Context.Root).GetComponentInChildren<TexturePickerScript>(includeInactive: true);
			componentInChildren.Initialize(textures, initiallySelectedId);
			return componentInChildren;
		}

		public UploadBugReportDialogScript CreateUploadBugReportDialog(XElement aircraftXml, IScreenshotDialogHandler handler)
		{
			UploadBugReportDialogScript uploadBugReportDialogScript = CreateDialog<UploadBugReportDialogScript>("Xml/Sharing/UploadBugReportDialog");
			uploadBugReportDialogScript.Initialize(aircraftXml, handler);
			return uploadBugReportDialogScript;
		}

		public UploadCraftDialogScript CreateUploadCraftDialog(AircraftScript aircraft, IScreenshotDialogHandler handler)
		{
			UploadCraftDialogScript uploadCraftDialogScript = CreateDialog<UploadCraftDialogScript>("Xml/Sharing/UploadCraftDialog");
			uploadCraftDialogScript.Initialize(aircraft, handler);
			return uploadCraftDialogScript;
		}

		public GameObject FindGameObjectAtPosition(Vector3 position)
		{
			return _script.FindGameObjectAtPosition(position);
		}

		public void OpenDownloadCraftsUrl()
		{
			OpenUrl(Game.SimplePlanesWebsiteUrl + "/Airplanes/Game?appId=2840470");
		}

		public void OpenUrl(string url)
		{
			WebUtility.OpenUrl(url);
		}

		public void RegisterDialog(IDialog dialog)
		{
			if (dialog.IsModal)
			{
				if (_openDialogs.Contains(dialog))
				{
					throw new Exception("Dialog is already registered");
				}
				dialog.Closed += OnDialogClosed;
				_openDialogs.Add(dialog);
				AnyDialogsOpen = true;
			}
		}

		public void UnregisterDialog(IDialog dialog)
		{
			if (dialog.IsModal && _openDialogs.Contains(dialog))
			{
				dialog.Closed -= OnDialogClosed;
				_openDialogs.Remove(dialog);
				AnyDialogsOpen = _openDialogs.Count > 0;
			}
		}

		private void InitializeScript()
		{
			if (_script != null)
			{
				return;
			}
			Transform = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault((GameObject x) => x.name == "UserInterface")?.GetComponent<RectTransform>();
			if (Transform == null && Game.Instance.SceneManager.InMenuScene)
			{
				Transform = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault((GameObject x) => x.name == "Canvas")?.GetComponent<RectTransform>();
			}
			UpdateDragThreshold();
			if (Transform != null)
			{
				_script = Transform.gameObject.AddComponent<UserInterfaceScript>();
				_script.InitializeContext(this);
				Sound.OnRootContextLoaded(_script.Context);
			}
			else
			{
				Debug.LogWarning("Scene is missing a root UserInterface rect transform.");
			}
		}

		private void OnDialogClosed(IDialog dialog)
		{
			UnregisterDialog(dialog);
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			InitializeScript();
		}

		private void OnSceneUnloaded(Scene scene)
		{
			_openDialogs.Clear();
			AnyDialogsOpen = false;
			Sound.OnSceneUnloaded();
			_script = null;
			Transform = null;
		}

		private void UpdateDragThreshold()
		{
		}
	}
}
