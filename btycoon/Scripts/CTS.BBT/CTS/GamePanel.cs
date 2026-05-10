using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class GamePanel : MonoBehaviour
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private Image _separator;

		[SerializeField]
		private TextMeshProUGUI _currentStateOfTheGame;

		[SerializeField]
		private TextMeshProUGUI _title;

		[SerializeField]
		private TextMeshProUGUI _subTitle;

		[SerializeField]
		private TextMeshProUGUI _description;

		private LocalizedString _descriptionLocalize;

		[SerializeField]
		private string _urlLandingPage;

		private void Awake()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			_description.text = _descriptionLocalize.GetLocalizedString();
		}

		public void SetUp(GamesSO gameSO)
		{
			_image.sprite = gameSO.MainImage;
			_separator.sprite = gameSO.Separator;
			_currentStateOfTheGame.text = gameSO.CurrentStateOfTheGame;
			_title.text = gameSO.Title;
			_descriptionLocalize = gameSO.Description;
			_description.text = _descriptionLocalize.GetLocalizedString();
			_urlLandingPage = gameSO.URL;
			_subTitle.text = gameSO.UnderTitle;
			_subTitle.color = gameSO.ThemeColor;
			_separator.color = gameSO.ThemeColor;
			_currentStateOfTheGame.color = gameSO.ThemeColor;
			_title.color = gameSO.ThemeColor;
		}

		public void OpenURL()
		{
			Application.OpenURL(_urlLandingPage);
		}
	}
}
