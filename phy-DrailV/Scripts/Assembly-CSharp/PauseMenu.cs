using DV.Hacks;
using DV.UI;
using DV.Utils;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public PauseMenuController controller;

	public APauseMenuProvider provider;

	private void Awake()
	{
		controller.SetProvider(provider);
		controller.ExitLevelRequested += OnExitLevelRequested;
		controller.QuitGameRequested += OnQuitRequested;
		controller.CloseRequested += OnCloseMenuRequested;
	}

	private void OnExitLevelRequested()
	{
		Debug.Log("Exit back to main menu requested from pause menu");
		GamePreferences.SavePreferences();
		MainMenu.GoBackToMainMenu();
	}

	private void OnQuitRequested()
	{
		Debug.Log("Quit game requested from pause menu");
		GamePreferences.SavePreferences();
		BlackoutScreen.Blackout(delegate
		{
			Application.Quit();
		});
	}

	private void OnCloseMenuRequested()
	{
		SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: false);
	}
}
