using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
	[SerializeField]
	private Button play;

	[SerializeField]
	private Button settings;

	[SerializeField]
	private Button wishlist;

	[SerializeField]
	private Button quit;

	[SerializeField]
	private ProfilesPopup profilesPopup;

	[SerializeField]
	private SettingsPopup settingsMenuPopup;

	[SerializeField]
	private TMP_Text versionText;

	private void Awake()
	{
		play.onClick.AddListener(profilesPopup.ShowContent);
		settings.onClick.AddListener(delegate
		{
			settingsMenuPopup.ShowContent();
		});
		wishlist.onClick.AddListener(ApplicationController.OpenStorePage);
		quit.onClick.AddListener(ApplicationController.Quit);
		versionText.SetText(Version.VERSION);
	}
}
