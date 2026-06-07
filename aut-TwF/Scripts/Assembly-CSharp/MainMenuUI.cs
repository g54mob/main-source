using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : HUDMenu, ISavable
{
	[SerializeField]
	private GameObject versionWindow;

	[SerializeField]
	private Toggle showVersionWindowToggle;

	[SerializeField]
	private GameObject showVersionWindowButton;

	[SerializeField]
	private GameObject wishlistButton;

	[SerializeField]
	[Savable("autoShowVersionWindow", true, false)]
	private bool autoShowVersionWindow = true;

	private LTMainMenuHUD ltMainMenuHud;

	protected override void Awake()
	{
		base.Awake();
		versionWindow.SetActive(value: false);
	}

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
		wishlistButton.SetActive(value: false);
	}

	private void OnEnable()
	{
		base.Hud.BlurBackground(enable: false);
	}

	public override bool BackButtonPressed()
	{
		return true;
	}

	public void OnPlayButtonPressed()
	{
		ltMainMenuHud.ShowNewGameMenuUI();
	}

	public void OnUpgradesButtonPressed()
	{
		ltMainMenuHud.ShowUpgradesMenuUI();
	}

	public void OnSettingsButtonPressed()
	{
		ltMainMenuHud.ShowSettingsMenuUI();
	}

	public void OnProfileButtonPressed()
	{
		ltMainMenuHud.ShowProfileMenuUI();
	}

	public void OnCreditsButtonPressed()
	{
		ltMainMenuHud.ShowCreditsMenuUI();
	}

	public void OnExitButtonPressed()
	{
		Application.Quit();
	}

	public void OnTwitterButtonPressed()
	{
		Application.OpenURL("https://twitter.com/GiusCaminiti");
	}

	public void OnDiscordButtonPressed()
	{
		Application.OpenURL("https://discord.gg/WMf3U3WqBN");
	}

	public void OnWishlistButtonPressed()
	{
		Application.OpenURL("steam://openurl/https://store.steampowered.com/app/2707490/Tower_Factory/");
	}

	public void OnShowVersionWindowButtonPressed()
	{
		versionWindow.SetActive(value: true);
	}

	public void OnCloseVersionWindowButtonPressed()
	{
		versionWindow.SetActive(value: false);
	}

	public void OnShowOnUpdateTogglePressed(bool value)
	{
		autoShowVersionWindow = value;
		SaveSystem.instance.SaveData();
	}

	public void OnEndlessModeButtonPressed()
	{
		ltMainMenuHud.ShowEndlessModeMenuUI();
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		showVersionWindowToggle.isOn = autoShowVersionWindow;
		if (autoShowVersionWindow && SaveSystem.instance.LastSavedGameVersion != "" && LTFunctionLibrary.CompareVersionNumbers(Application.version, SaveSystem.instance.LastSavedGameVersion) == 1)
		{
			versionWindow.SetActive(value: true);
		}
	}
}
