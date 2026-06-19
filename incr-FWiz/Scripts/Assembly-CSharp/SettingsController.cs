using UnityEngine;

public class SettingsController : MonoBehaviour
{
	public LanguageSettingsController LanguageSettings;

	public ControlSettingsController ControlSettings;

	public static SettingsController Instance { get; private set; }

	private void Start()
	{
	}

	public void Initiate()
	{
	}
}
