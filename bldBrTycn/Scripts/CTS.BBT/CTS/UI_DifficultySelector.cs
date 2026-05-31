using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_DifficultySelector : CTSBehaviour, ILocaleRepaint
	{
		[SerializeField]
		private Image _foregroundImageContainer;

		[SerializeField]
		private Image _backgroundImageContainer;

		[SerializeField]
		private TMP_Text _titleTextArea;

		[SerializeField]
		private TMP_Text _descriptionTextArea;

		[SerializeField]
		private CTSButton _button;

		[SerializeField]
		private DifficultySelectionData _difficulty;

		protected override void OnAwake()
		{
			base.OnAwake();
			_button.onClick.AddListener(OnButtonClicked);
			_foregroundImageContainer.overrideSprite = _difficulty.ForegroundImage;
			_backgroundImageContainer.overrideSprite = _difficulty.BackgroundImage;
			RepaintLocale();
		}

		private void OnButtonClicked()
		{
			CTSSingleton<Difficulty>.Instance.SetCurrentDifficulty(_difficulty.DifficultyPreset);
			CTSSingleton<UI_ProfileManager>.Instance.PlayNewGameOnCurrentProfile();
		}

		public void RepaintLocale()
		{
			_titleTextArea.text = _difficulty.Title.GetLocalizedStringSafe();
			_descriptionTextArea.text = _difficulty.Description.GetLocalizedStringSafe();
		}
	}
}
