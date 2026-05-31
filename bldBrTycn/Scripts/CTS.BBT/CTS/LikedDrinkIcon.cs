using CTS.BBT;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class LikedDrinkIcon : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Image _background;

		[SerializeField]
		private LocalizedString _likedTitle;

		[SerializeField]
		private LocalizedString _hatedTitle;

		public DrinkSO Drink { get; private set; }

		public bool IsLiked { get; private set; }

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
		}

		public void Setup(DrinkSO drink, bool isLiked, Color colorBackground)
		{
			Drink = drink;
			_icon.sprite = drink.Icon;
			IsLiked = isLiked;
			_background.color = colorBackground;
		}

		public void SetupColor(Color color)
		{
			_background.color = color;
		}
	}
}
