using Motorways.Themes;
using Motorways.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways
{
	public class MapButtonTab : MonoBehaviour
	{
		public MapButton button;

		public ThemeTypeToggler backgroundThemeToggler;

		public ThemeTypeToggler iconThemeToggler;

		private Animator _animator;

		private TouchButton _touchButton;

		private GameMode _gameMode;

		private static readonly int Selected = Animator.StringToHash("Selected");

		private static readonly int Shown = Animator.StringToHash("Shown");

		public TouchButton TouchButton => _touchButton;

		public void Show()
		{
			_animator.SetBool(Shown, value: true);
			if (_touchButton.IsInitialized && !string.IsNullOrEmpty(_touchButton.NewContentId))
			{
				_touchButton.ShowNewContentIndicatorIfNeeded(playIntro: true);
			}
		}

		public void Hide()
		{
			_animator.SetBool(Shown, value: false);
		}

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_touchButton = GetComponent<TouchButton>();
		}

		public void OnOtherTabSelected()
		{
			backgroundThemeToggler.SetSelectedTheme(isFirstSelected: false);
			iconThemeToggler.SetSelectedTheme(isFirstSelected: true);
			_animator.SetBool(Selected, value: false);
		}

		public void OnClicked()
		{
			if (_gameMode != GameMode.Endless && _gameMode != GameMode.Expert)
			{
				backgroundThemeToggler.SetSelectedTheme(isFirstSelected: true);
			}
			iconThemeToggler.SetSelectedTheme(isFirstSelected: false);
			_animator.SetBool(Selected, value: true);
		}

		public void SetSelected(bool isSelected)
		{
			if (isSelected)
			{
				OnClicked();
			}
			else
			{
				OnOtherTabSelected();
			}
		}
	}
}
