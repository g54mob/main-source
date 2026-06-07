using System;
using CTS;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsMenu : MonoSingleton<OptionsMenu>
{
	public enum NameOfPanel
	{
		Sounds = 0,
		Gameplay = 1,
		Graphics = 2,
		Controls = 3,
		Twitch = 4
	}

	public static Action<NameOfPanel> OnOptionsReset;

	public InputActionAsset _inputActionAsset;

	[Tooltip("This will be the first panel to appear/button to be activated")]
	[SerializeField]
	private Toggle _firstSelected;

	[Foldout("Dev")]
	[SerializeField]
	private TMP_Text _backButtonText;

	[Foldout("Dev")]
	[SerializeField]
	private GameObject _mainMenuButton;

	[Foldout("Dev")]
	[SerializeField]
	private GameObject _canvasBlockRayCast;

	[SerializeField]
	[Foldout("Dev")]
	private UI_ParametersPanelReturnButton _backButton;

	private CanvasGroupController _canvasGroupController;

	private UI_PanelSelectionButton _panelCurrentSelectionButton;

	private LockToggle _timeScaleToggler;

	public GameObject OptionsMenuBackground { get; private set; }

	public void ResetOptions()
	{
		OnOptionsReset?.Invoke(_panelCurrentSelectionButton.ENameOfPanel);
	}

	[Button("Toggle Options Menu", EButtonEnableMode.Editor)]
	public void Show()
	{
		OptionsMenuBackground = base.transform.GetChild(0).gameObject;
		OptionsMenuBackground.SetActive(!OptionsMenuBackground.activeSelf);
		DeactivateInputs(OptionsMenuBackground.activeSelf);
		_backButtonText.color = Color.white;
		_firstSelected.isOn = true;
	}

	private void DeactivateInputs(bool inOptions)
	{
		if (inOptions)
		{
			_inputActionAsset.Disable();
		}
		else
		{
			_inputActionAsset.Enable();
		}
	}

	protected override void SingletonAwake()
	{
		_canvasGroupController = GetComponent<CanvasGroupController>();
		_canvasGroupController.CanvasShowned += ActiveRaycast;
		_backButton.ClosePanel += ClosePanel;
		MenusManager.OnMainMenuShown += IsInTheGame;
		_canvasBlockRayCast.SetActive(value: false);
		UI_PanelSelectionButton.OnPanelSelected += UI_PanelSelectionButton_OnPanelSelected;
	}

	private void UI_PanelSelectionButton_OnPanelSelected(UI_PanelSelectionButton obj)
	{
		_panelCurrentSelectionButton = obj;
	}

	private void ClosePanel()
	{
		MonoSingleton<MainCamera>.Instance.Movements.enabled = true;
		MonoSingleton<MainCamera>.Instance.CameraRotation.enabled = true;
		MonoSingleton<MainCamera>.Instance.Zoom.enabled = true;
		MonoSingleton<MainCamera>.Instance.MouseControls.enabled = true;
	}

	private void ActiveRaycast(bool obj)
	{
		_canvasBlockRayCast.SetActive(obj);
		if (_timeScaleToggler != null)
		{
			if (obj)
			{
				_timeScaleToggler.Lock();
			}
			else
			{
				_timeScaleToggler.Unlock();
			}
		}
	}

	public void OnClickButton()
	{
		if (_canvasGroupController.IsHidden)
		{
			_canvasBlockRayCast.SetActive(value: true);
			_canvasGroupController.QuickShow();
			MonoSingleton<MainCamera>.Instance.Movements.enabled = false;
			MonoSingleton<MainCamera>.Instance.CameraRotation.enabled = false;
			MonoSingleton<MainCamera>.Instance.Zoom.enabled = false;
			MonoSingleton<MainCamera>.Instance.MouseControls.enabled = false;
		}
		else
		{
			_canvasBlockRayCast.SetActive(value: false);
			_canvasGroupController.QuickHide();
			MonoSingleton<MainCamera>.Instance.Movements.enabled = true;
			MonoSingleton<MainCamera>.Instance.CameraRotation.enabled = true;
			MonoSingleton<MainCamera>.Instance.Zoom.enabled = true;
			MonoSingleton<MainCamera>.Instance.MouseControls.enabled = true;
		}
	}

	protected override void OnSingletonDestroy()
	{
		MenusManager.OnMainMenuShown -= IsInTheGame;
		_canvasGroupController.CanvasShowned -= ActiveRaycast;
		UI_PanelSelectionButton.OnPanelSelected -= UI_PanelSelectionButton_OnPanelSelected;
		_backButton.ClosePanel -= ClosePanel;
	}

	public void IsInTheGame(bool isInTheGame)
	{
		if (isInTheGame)
		{
			_mainMenuButton.gameObject.SetActive(value: false);
			_canvasGroupController.QuickHide();
			MonoSingleton<MainCamera>.Instance.Movements.enabled = true;
			MonoSingleton<MainCamera>.Instance.CameraRotation.enabled = true;
			MonoSingleton<MainCamera>.Instance.Zoom.enabled = true;
			MonoSingleton<MainCamera>.Instance.MouseControls.enabled = true;
			_timeScaleToggler = null;
		}
		else
		{
			_timeScaleToggler = new LockToggle(MonoSingleton<TimeController>.Instance);
			_mainMenuButton.gameObject.SetActive(value: true);
		}
	}
}
