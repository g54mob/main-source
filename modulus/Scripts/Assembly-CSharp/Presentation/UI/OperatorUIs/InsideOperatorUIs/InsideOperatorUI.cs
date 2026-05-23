using Data.Lighting;
using Data.Variables;
using Events;
using Events.Lighting;
using FMODUnity;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.InsideOperatorUIs
{
	public class InsideOperatorUI : UIMenu
	{
		[Header("Camera")]
		[SerializeField]
		private CameraLocator _mainCamera;

		[SerializeField]
		protected Camera _3DCamera;

		[Header("Lighting")]
		[SerializeField]
		private SetLightingConfigEventSO _setLightingConfigEvent;

		[SerializeField]
		private LightingConfig _lightingConfig;

		[SerializeField]
		private SetDirectionalLightEventSO _setDirectionalLightEvent;

		[SerializeField]
		private BaseEvent _resetToDefaultLightingEvent;

		[Header("Main Buttons")]
		[SerializeField]
		private MachineButton _readyButton;

		[SerializeField]
		private MachineButton _resetButton;

		[Header("Closing Menu")]
		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private GoBackSourceSO _insideOperatorUIGoBackSource;

		[SerializeField]
		private BoolVariableSO _operatorInteriorUIIsOpen;

		[SerializeField]
		private BaseEvent _readyButtonClickedEvent;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private EventReference _insideViewLoop;

		protected bool IsConfigured
		{
			set
			{
				if (value && !_readyButton.Interactable)
				{
					_readyButton.Interactable = true;
				}
				_readyButton.IsPressed = value;
			}
		}

		protected virtual void Awake()
		{
			_resetButton.OnClick += Reset;
			_readyButton.OnClick += Ready;
		}

		protected virtual void OnDestroy()
		{
			_resetButton.OnClick -= Reset;
			_readyButton.OnClick -= Ready;
		}

		protected virtual void Reset(int param1 = 0)
		{
			EnableReadyButton(enable: false);
		}

		private void Reset(int _, MachineButton __)
		{
			Reset();
		}

		protected virtual void Ready(int param1 = 0)
		{
			_readyButtonClickedEvent?.Fire();
			_uiMenuManagerLocator.UIMenuManager.GoBack(_insideOperatorUIGoBackSource);
		}

		private void Ready(int _, MachineButton __)
		{
			Ready();
		}

		private void Close()
		{
			_audioManagerLocator.AudioManager.SetInsideOperatorSnapshot(active: false);
			_uiMenuManagerLocator.UIMenuManager.GoBack(_insideOperatorUIGoBackSource);
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			_closeButton.onClick.AddListener(Close);
			_mainCamera.Camera.gameObject.SetActive(value: false);
			_3DCamera.gameObject.SetActive(value: true);
			SetLighting();
			base.gameObject.SetActive(value: true);
			_operatorInteriorUIIsOpen.SetValue(value: true);
			_audioManagerLocator.AudioManager.PlayInsideViewOpen();
			if (!_insideViewLoop.IsNull)
			{
				_audioManagerLocator.AudioManager.PlayInsideViewLoop(_insideViewLoop);
			}
			_audioManagerLocator.AudioManager.SetInsideOperatorSnapshot(active: true);
		}

		public override void HideMenu()
		{
			_closeButton.onClick.RemoveListener(Close);
			_operatorInteriorUIIsOpen.SetValue(value: false);
			base.gameObject.SetActive(value: false);
			_mainCamera.Camera.gameObject.SetActive(value: true);
			_3DCamera.gameObject.SetActive(value: false);
			ResetLighting();
			_audioManagerLocator.AudioManager.PlayInsideViewClose();
			if (!_insideViewLoop.IsNull)
			{
				_audioManagerLocator.AudioManager.StopInsideViewLoop();
			}
			_audioManagerLocator.AudioManager.SetInsideOperatorSnapshot(active: false);
		}

		protected void EnableResetButton(bool enable = true)
		{
			_resetButton.Interactable = enable;
		}

		protected void EnableReadyButton(bool enable = true)
		{
			_readyButton.Interactable = enable;
			if (enable)
			{
				_readyButton.IsPressed = false;
			}
		}

		private void SetLighting()
		{
			_setLightingConfigEvent.Fire(_lightingConfig);
			_setDirectionalLightEvent?.Fire(data: false);
		}

		private void ResetLighting()
		{
			_setDirectionalLightEvent?.Fire(data: true);
			_resetToDefaultLightingEvent.Fire();
		}
	}
}
