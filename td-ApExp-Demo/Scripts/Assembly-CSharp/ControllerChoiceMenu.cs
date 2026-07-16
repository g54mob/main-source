using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerChoiceMenu : Menu
{
	[Header("Elements")]
	[SerializeField]
	private TextMeshProUGUI P1Text;

	[SerializeField]
	private Image P1ArrowImage;

	[SerializeField]
	private TextMeshProUGUI P2Text;

	[SerializeField]
	private Image P2ArrowImage;

	[SerializeField]
	private Animator textAnim;

	[SerializeField]
	private Button confirmButton;

	[SerializeField]
	private GameObject waitingForInputsGO;

	[SerializeField]
	private GameObject selectYourPlayersGO;

	[Header("Controller Images")]
	[SerializeField]
	private RectTransform p1KeyboardImage;

	[SerializeField]
	private RectTransform p1XboxImage;

	[SerializeField]
	private RectTransform p1PS4Image;

	[SerializeField]
	private RectTransform p1PS5Image;

	[SerializeField]
	private RectTransform p2KeyboardImage;

	[SerializeField]
	private RectTransform p2XboxImage;

	[SerializeField]
	private RectTransform p2PS4Image;

	[SerializeField]
	private RectTransform p2PS5Image;

	private InputDevice p1Device;

	private InputDevice p2Device;

	private CoopChoiceMode choiceMode = CoopChoiceMode.Choosing;

	private Action<int, InputAction.CallbackContext> confirmHandler;

	private InputDevice lastP1Device;

	private InputDevice lastP2Device;

	protected override void OnOpen()
	{
		base.OnOpen();
		confirmHandler = delegate
		{
			OnConfirmClicked();
		};
		InputManager.Instance.OnAPressed += confirmHandler;
		SetP1P2Colors();
		SetP1DeviceImage(ControllerType.None);
		SetP2DeviceImage(ControllerType.None);
		p1Device = null;
		p2Device = null;
		confirmButton.interactable = false;
		StartCoroutine(LateSubscribe());
	}

	private IEnumerator LateSubscribe()
	{
		yield return new WaitForSeconds(0.2f);
		InputManager.Instance.OnEnter += HandleEnterPressed;
		InputManager.Instance.OnBackPressed += HandleBackPressed;
	}

	protected override void OnClose()
	{
		base.OnClose();
		InputManager.Instance.OnEnter -= HandleEnterPressed;
		InputManager.Instance.OnBackPressed -= HandleBackPressed;
		InputManager.Instance.OnAPressed -= confirmHandler;
	}

	private void HandleBackPressed(int arg1, InputAction.CallbackContext arg2)
	{
		OnCancelClicked();
	}

	private void HandleEnterPressed(int arg1, InputAction.CallbackContext arg2)
	{
		OnConfirmClicked();
	}

	private void Update()
	{
		if (InputSystem.devices.Where((InputDevice d) => d is Gamepad).ToArray().Length != 0)
		{
			selectYourPlayersGO.SetActive(value: true);
			waitingForInputsGO.SetActive(value: false);
			HandleUiInput();
		}
		else
		{
			selectYourPlayersGO.SetActive(value: false);
			waitingForInputsGO.SetActive(value: true);
		}
		SetConfirmInteractable();
	}

	private void HandleUiInput()
	{
		MoveInput anyIdentifiedMoveInput = InputManager.Instance.GetAnyIdentifiedMoveInput();
		if (anyIdentifiedMoveInput.Move.magnitude > 0.5f)
		{
			if (anyIdentifiedMoveInput.Move.x < 0f)
			{
				SelectControllerForP1(anyIdentifiedMoveInput.Device);
			}
			else
			{
				SelectControllerForP2(anyIdentifiedMoveInput.Device);
			}
		}
	}

	private IEnumerator SelectConfirmButton()
	{
		if (confirmButton.interactable)
		{
			EventSystem.current.SetSelectedGameObject(confirmButton.gameObject);
			yield return null;
			EventSystem.current.SetSelectedGameObject(confirmButton.gameObject);
		}
	}

	private IEnumerator DeselectConfirmButton()
	{
		EventSystem.current.SetSelectedGameObject(null);
		yield return null;
		EventSystem.current.SetSelectedGameObject(null);
	}

	private void SetP1P2Colors()
	{
		P1Text.color = PlayerManager.Instance.GetPlayerColor(0);
		P1ArrowImage.color = PlayerManager.Instance.GetPlayerColor(0);
		P2Text.color = PlayerManager.Instance.GetPlayerColor(1);
		P2ArrowImage.color = PlayerManager.Instance.GetPlayerColor(1);
	}

	private void SetConfirmInteractable()
	{
		confirmButton.interactable = p1Device != null && p2Device != null;
	}

	private void SetP1DeviceImage(ControllerType controllerType)
	{
		p1KeyboardImage.gameObject.SetActive(controllerType == ControllerType.KeyboardMouse);
		p1XboxImage.gameObject.SetActive(controllerType == ControllerType.GamepadXBox);
		p1PS4Image.gameObject.SetActive(controllerType == ControllerType.GamepadPS4);
		p1PS5Image.gameObject.SetActive(controllerType == ControllerType.GamepadPS5);
	}

	private void SetP2DeviceImage(ControllerType controllerType)
	{
		p2KeyboardImage.gameObject.SetActive(controllerType == ControllerType.KeyboardMouse);
		p2XboxImage.gameObject.SetActive(controllerType == ControllerType.GamepadXBox);
		p2PS4Image.gameObject.SetActive(controllerType == ControllerType.GamepadPS4);
		p2PS5Image.gameObject.SetActive(controllerType == ControllerType.GamepadPS5);
	}

	private void SelectControllerForP1(InputDevice device)
	{
		if (lastP2Device == device)
		{
			p2Device = null;
			SetP2DeviceImage(ControllerType.None);
		}
		lastP1Device = device;
		p1Device = device;
		SetP1DeviceImage(StringControllerConverter.GetController(device.name));
	}

	private void SelectControllerForP2(InputDevice device)
	{
		if (lastP1Device == device)
		{
			p1Device = null;
			SetP1DeviceImage(ControllerType.None);
		}
		lastP2Device = device;
		p2Device = device;
		SetP2DeviceImage(StringControllerConverter.GetController(device.name));
	}

	public void OnConfirmClicked()
	{
		if (p1Device == null || p2Device == null)
		{
			Debug.Log("Cannot start coop without selected devices.");
			return;
		}
		PlayerManager.Instance.TryStartCoop(p1Device, p2Device);
		MenuManager.Instance.CloseAllMenus();
	}

	public void OnCancelClicked()
	{
		MenuManager.Instance.CloseAllMenus();
	}
}
