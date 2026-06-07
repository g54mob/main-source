using System;
using CreativeMode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConfirmationWindowUI : MonoBehaviour
{
	[SerializeField]
	private Button yesButton;

	[SerializeField]
	private Button noButton;

	private PlayerInputActions playerInputActions;

	private bool clearButton;

	private ClearItemsButtonUI _clearItemsButton;

	private RestartItemsPosionUI _restartItemsPosion;

	private void Awake()
	{
		noButton.onClick.AddListener(delegate
		{
			Hide();
		});
		yesButton.onClick.AddListener(delegate
		{
			YesButtonAction();
		});
		playerInputActions = new PlayerInputActions();
	}

	private void YesButtonAction()
	{
		if (clearButton)
		{
			_clearItemsButton.ClearAllItems();
		}
		else
		{
			_restartItemsPosion.RestartItemsPosition();
		}
		Hide();
	}

	private void Start()
	{
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		playerInputActions.MainMenu.CloseWindow.performed += CloseWindowButton;
		Hide();
	}

	private void OnEnable()
	{
		playerInputActions.MainMenu.Enable();
	}

	private void OnDisable()
	{
		playerInputActions.MainMenu.Disable();
	}

	private void OnDestroy()
	{
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
		playerInputActions.MainMenu.CloseWindow.performed -= CloseWindowButton;
	}

	private void CloseWindowButton(InputAction.CallbackContext obj)
	{
		Hide();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		Hide();
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void ShowClearItemsWindow(ClearItemsButtonUI clearItemsButtonUI)
	{
		_clearItemsButton = clearItemsButtonUI;
		clearButton = true;
		base.gameObject.SetActive(value: true);
	}

	public void ShowRestartItemWindow(RestartItemsPosionUI restartItemsPosionUI)
	{
		_restartItemsPosion = restartItemsPosionUI;
		clearButton = false;
		base.gameObject.SetActive(value: true);
	}
}
