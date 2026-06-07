using Assets.Scripts.GuiNew;
using Assets.Scripts.UI;
using Assets.Scripts.XR;
using Jundroo.Common.Extensions;
using Rewired.UI.ControlMapper;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Input.Gui
{
	public class ControlMapperDialogScript : MonoBehaviour, IDialog
	{
		private static ControlMapperDialogScript _instance;

		private ControlMapper _controlMapper;

		[SerializeField]
		private EventSystem _controlMapperEventSystem;

		private EventSystem _existingEventSystem;

		public bool AllowCameraZoom => false;

		public ControlMapper ControlMapper
		{
			get
			{
				if (_controlMapper == null)
				{
					_controlMapper = GetComponent<ControlMapper>();
				}
				return _controlMapper;
			}
		}

		public bool IsModal => true;

		public event DialogDelegate Closed;

		public static ControlMapperDialogScript CreateDialog()
		{
			if (_instance != null)
			{
				return null;
			}
			string text = string.Empty;
			if (Game.Instance.Device.IsVRBuild)
			{
				XRDeviceManager xRDeviceManager = Game.Instance.XRDeviceManager;
				if (((object)xRDeviceManager != null && xRDeviceManager.HmdActive) || Game.Instance.SceneManager.CurrentScene == "LevelMenuVR")
				{
					text = "VR";
					goto IL_0078;
				}
			}
			if (Game.Instance.Device.IsMobileBuild)
			{
				text = "Mobile";
			}
			goto IL_0078;
			IL_0078:
			_instance = CreateDialog<ControlMapperDialogScript>("Input/ControlMapper" + text);
			_instance.Initialize();
			return _instance;
		}

		public virtual void Close()
		{
			if (this.Closed != null)
			{
				this.Closed(this);
			}
			Object.Destroy(base.gameObject);
			base.gameObject.SetActive(value: false);
		}

		protected static T CreateDialog<T>(string prefab) where T : MonoBehaviour
		{
			GameObject gameObject = Object.Instantiate(Resources.Load(prefab)) as GameObject;
			if (!gameObject.TryGetComponent<T>(out var component))
			{
				return gameObject.GetComponentInChildren<T>();
			}
			return component;
		}

		protected virtual void OnDestroy()
		{
			_instance = null;
			RestoreExistingEventSystem();
		}

		protected virtual void Start()
		{
			DisableExistingEventSystem();
			InputWrapper.SetControllerUINavigationEnabled(enabled: true);
			if (Game.Instance.Device.IsMobileBuild)
			{
				string key = "MobileControlsDialogWarning";
				if (!PlayerPrefs.HasKey(key))
				{
					Assets.Scripts.GuiNew.DialogScript.CreateDialog(showCancel: false).MessageText = "The mobile version of SimplePlanes does not require any additional keyboards or controllers to be fully enjoyed.\n\nFor players who do wish to use these devices however, this dialog can be used to configure those controls.";
					PlayerPrefs.SetInt(key, 1);
				}
			}
		}

		private void DisableExistingEventSystem()
		{
			if (_controlMapperEventSystem == null)
			{
				this.LogError("The control mapper event system is null");
				return;
			}
			EventSystem[] array = Object.FindObjectsByType<EventSystem>(FindObjectsSortMode.None);
			foreach (EventSystem eventSystem in array)
			{
				if (eventSystem != _controlMapperEventSystem)
				{
					_existingEventSystem = eventSystem;
					break;
				}
			}
			if (_existingEventSystem != null)
			{
				_existingEventSystem.gameObject.SetActive(value: false);
				_controlMapperEventSystem.gameObject.SetActive(value: true);
			}
		}

		private void Initialize()
		{
			ControlMapper.ScreenOpenedEvent += OnOpened;
			ControlMapper.ScreenClosedEvent += OnClosed;
		}

		private void OnClosed()
		{
			_instance = null;
			InputWrapper.ApplySceneControls();
			RestoreExistingEventSystem();
			Close();
		}

		private void OnOpened()
		{
		}

		private void RestoreExistingEventSystem()
		{
			if (!(_existingEventSystem == null) && !(_existingEventSystem.gameObject == null))
			{
				if (_controlMapperEventSystem != null)
				{
					_controlMapperEventSystem.gameObject.SetActive(value: false);
				}
				_existingEventSystem.gameObject.SetActive(value: true);
				_existingEventSystem = null;
			}
		}
	}
}
