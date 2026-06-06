using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class NewGameWindowUI : MonoBehaviour
{
	[SerializeField]
	private Button yesButton;

	[SerializeField]
	private Button noButton;

	private void Awake()
	{
		yesButton.onClick.AddListener(delegate
		{
			NewGame();
		});
		noButton.onClick.AddListener(delegate
		{
			Hide();
		});
	}

	private void Start()
	{
		MainMenuUI.Instance.OnNewGameButton += MainMenuUI_OnNewGameButton;
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		Hide();
	}

	private void OnDestroy()
	{
		MainMenuUI.Instance.OnNewGameButton -= MainMenuUI_OnNewGameButton;
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
	}

	private void NewGame()
	{
		MainMenuUI.Instance.SetNewGameStarted();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		Hide();
	}

	private void MainMenuUI_OnNewGameButton(object sender, EventArgs e)
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

	private void Show()
	{
		MainMenuUI.Instance.InnerWindowOpen = true;
		base.gameObject.SetActive(value: true);
	}
}
