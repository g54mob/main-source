using UnityEngine;

public class SettingsInitializer : MonoBehaviour
{
	private void Awake()
	{
		if (PlayerPrefs.GetInt("InitSettings") != 1)
		{
			PlayerPrefs.SetString("Up", "w");
			PlayerPrefs.SetString("Down", "s");
			PlayerPrefs.SetString("Left", "a");
			PlayerPrefs.SetString("Right", "d");
			PlayerPrefs.SetString("Jump", "space");
			PlayerPrefs.SetString("Interact", "e");
			PlayerPrefs.SetString("Drop", "g");
			PlayerPrefs.SetString("Use", "Mouse0");
			PlayerPrefs.SetInt("InitSettings", 1);
			PlayerPrefs.SetFloat("ChatScrollSpeed", 0.02f);
		}
	}
}
