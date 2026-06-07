using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class PlaytestCloseGameConfirmationMenu : Menu
	{
		[SerializeField]
		private Button m_surveyButton;

		[SerializeField]
		private Button m_wishlistButton;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_surveyButton.onClick.AddListener(OnSurveyButtonClicked);
			m_wishlistButton.onClick.AddListener(OnWishlistButtonClicked);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_surveyButton.onClick.RemoveListener(Back);
			m_wishlistButton.onClick.RemoveListener(OnWishlistButtonClicked);
		}

		private void OnSurveyButtonClicked()
		{
			Application.OpenURL(PlaytestSettings.SurveyUrl);
			Back();
		}

		private void OnWishlistButtonClicked()
		{
			Application.OpenURL(PlaytestSettings.SteamGameWishlistUrl);
			Back();
		}
	}
}
