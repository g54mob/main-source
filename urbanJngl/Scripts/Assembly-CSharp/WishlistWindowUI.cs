using System;
using Steamworks;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WishlistWindowUI : MonoBehaviour
{
	[SerializeField]
	private Button exitButton;

	[SerializeField]
	private NextLevelWindowUI nextLevelWindowUI;

	private PlayerInputActions playerInputActions;

	private void Awake()
	{
		playerInputActions = new PlayerInputActions();
	}

	private void Start()
	{
		MainMenuUI.Instance.OnWishlistButton += MainMenuUI_OnWishlistButton;
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		nextLevelWindowUI.OnGameFinished += NextLevelWindowUI_OnGameFinished;
		exitButton.onClick.AddListener(delegate
		{
			Hide();
		});
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
		MainMenuUI.Instance.OnWishlistButton -= MainMenuUI_OnWishlistButton;
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
		nextLevelWindowUI.OnGameFinished -= NextLevelWindowUI_OnGameFinished;
		playerInputActions.MainMenu.CloseWindow.performed -= CloseWindowButton;
		exitButton.onClick.RemoveAllListeners();
	}

	private void CloseWindowButton(InputAction.CallbackContext obj)
	{
		Hide();
	}

	private void NextLevelWindowUI_OnGameFinished(object sender, EventArgs e)
	{
		Show();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		Hide();
	}

	private void MainMenuUI_OnWishlistButton(object sender, EventArgs e)
	{
		Show();
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

	public void Show()
	{
		MainMenuUI.Instance.InnerWindowOpen = true;
		base.gameObject.SetActive(value: true);
	}

	public void OpenSteamPage()
	{
		try
		{
			SteamFriends.OpenStoreOverlay(2744010);
		}
		catch (Exception)
		{
			Application.OpenURL("https://store.steampowered.com/app/2744010/Urban_Jungle/");
		}
	}

	public void OpenGoogleForm()
	{
		Application.OpenURL("https://docs.google.com/forms/d/1uIjc8Oqid5F5MpsRUwmmP67Yqo3x5T4M2KDcvUTHCak/viewform?edit_requested=true");
	}
}
