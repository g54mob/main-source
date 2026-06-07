using System;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuitGameWindowUI : MonoBehaviour
{
	[SerializeField]
	private Button yesButton;

	[SerializeField]
	private Button noButton;

	private PlayerInputActions playerInputActions;

	private void Awake()
	{
		yesButton.onClick.AddListener(delegate
		{
			QuitGame();
		});
		noButton.onClick.AddListener(delegate
		{
			Hide();
		});
		playerInputActions = new PlayerInputActions();
	}

	private void Start()
	{
		MainMenuUI.Instance.OnQuitButton += MainMenuUI_OnQuitButton;
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
		MainMenuUI.Instance.OnQuitButton -= MainMenuUI_OnQuitButton;
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

	private void MainMenuUI_OnQuitButton(object sender, EventArgs e)
	{
		Show();
	}

	private void QuitGame()
	{
		Application.Quit();
	}

	private void Hide()
	{
		if (base.isActiveAndEnabled)
		{
			MainMenuUI.Instance.ToggleMainMenu(value: true);
			MainMenuUI.Instance.InnerWindowOpen = false;
			base.gameObject.SetActive(value: false);
		}
	}

	private void Show()
	{
		MainMenuUI.Instance.InnerWindowOpen = true;
		base.gameObject.SetActive(value: true);
	}
}
