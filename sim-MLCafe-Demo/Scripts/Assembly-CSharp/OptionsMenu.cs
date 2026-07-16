using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject content;

	[SerializeField]
	private GeneralGameSettingsComponent gameSettingsComponent;

	[SerializeField]
	private GraphicsComponent graphicsComponent;

	[SerializeField]
	private AudioSettingsComponent audioSettingsComponent;

	[SerializeField]
	private TwitchGameSettingsComponent twitchGameSettingsComponent;

	public void ShowOptionsMenu()
	{
		content.SetActive(value: true);
	}

	public void HideOptionsMenu()
	{
		content.SetActive(value: false);
	}

	public void ReloadSettings()
	{
		if (GameSettings.GetActiveConfig() == null)
		{
			Debug.LogError("No Active Config found!");
			return;
		}
		gameSettingsComponent.OnConfigLoad(GameSettings.GetActiveConfig());
		graphicsComponent.OnConfigLoad(GameSettings.GetActiveConfig());
		audioSettingsComponent.OnConfigLoad(GameSettings.GetActiveConfig());
		twitchGameSettingsComponent.OnConfigLoad(GameSettings.GetActiveConfig());
	}
}
