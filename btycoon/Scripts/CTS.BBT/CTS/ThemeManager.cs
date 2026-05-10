using System;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class ThemeManager : MonoSingleton<ThemeManager>
	{
		[SerializeField]
		private UIThemeButton _themeButtonPrefab;

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private BarStyleParameters[] _themes;

		[SerializeField]
		private TMP_Text _styleNameText;

		[SerializeField]
		private TMP_Text _styleDescText;

		[SerializeField]
		private LocalizedString _lockedStyleNameText;

		[SerializeField]
		private LocalizedString _lockedStyleDescText;

		private List<UIThemeButton> _themeButtons = new List<UIThemeButton>();

		private CanvasGroupController _canvasController;

		public EBarStyle CurrentSelectedBarStyle => CurrentSelectedTheme.BarStyle;

		public List<LocalizedString> CurrentHumanAttracted => CurrentSelectedTheme.TypeOfHumanAttracted;

		public BarStyleParameters CurrentSelectedTheme { get; private set; }

		public static event Action<EBarStyle> OnStyleChanged;

		public static event Action<List<LocalizedString>, bool> OnStyleHumanAttractedChange;

		public static event Action OnThemeClosed;

		public static event Action ThemeUnlocked;

		public static event Action ThemeLocked;

		protected override void SingletonAwake()
		{
			UIThemeButton.OnThemeChanged += OnThemeChanged;
			UIThemeButton.OnThemeEnterOver += UIThemeButton_OnThemeEnterOver;
			UIThemeButton.OnThemeExitOver += UIThemeButton_OnThemeExitOver;
			_canvasController = GetComponent<CanvasGroupController>();
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
			_canvasController.CanvasShowned += CanvasController_CanvasShowned;
			UnlockingManager.OnNewKeyAdded += UnlockingManager_OnNewKeyAdded;
			CurrentSelectedTheme = _themes[0];
		}

		protected override void OnSingletonDestroy()
		{
			UIThemeButton.OnThemeChanged -= OnThemeChanged;
			UIThemeButton.OnThemeEnterOver -= UIThemeButton_OnThemeEnterOver;
			UIThemeButton.OnThemeExitOver -= UIThemeButton_OnThemeExitOver;
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
			_canvasController.CanvasShowned -= CanvasController_CanvasShowned;
			UnlockingManager.OnNewKeyAdded -= UnlockingManager_OnNewKeyAdded;
		}

		private void Start()
		{
			Populate();
		}

		public BarStyleParameters GetThemeFromStyle(EBarStyle style)
		{
			List<BarStyleParameters> list = _themes.Where((BarStyleParameters x) => x.BarStyle == style).ToList();
			if (list.Count != 1)
			{
				return null;
			}
			return list[0];
		}

		private void UnlockingManager_OnNewKeyAdded(EUnlockKey obj)
		{
			bool flag = false;
			bool flag2 = false;
			foreach (UIThemeButton themeButton in _themeButtons)
			{
				if (themeButton.ThemeButton.IsLocked != themeButton.IsLocked)
				{
					if (themeButton.IsLocked)
					{
						themeButton.SetLockState(locked: false);
						flag = true;
					}
					else
					{
						themeButton.SetLockState(locked: true);
						flag2 = true;
					}
				}
			}
			if (flag)
			{
				ThemeManager.ThemeUnlocked?.Invoke();
			}
			if (flag2)
			{
				ThemeManager.ThemeLocked?.Invoke();
			}
		}

		private void Populate()
		{
			for (int i = 0; i < _themes.Length; i++)
			{
				UIThemeButton uIThemeButton = UnityEngine.Object.Instantiate(_themeButtonPrefab, _container);
				uIThemeButton.Init(_themes[i], _toggleGroup, _themes[i].LockStyleNameText, _themes[i].LockStyleDescText);
				_themeButtons.Add(uIThemeButton);
			}
		}

		private void CanvasController_CanvasShowned(bool show)
		{
			if (!show)
			{
				ThemeManager.OnThemeClosed?.Invoke();
			}
		}

		private void OnThemeChanged(BarStyleParameters themeButton)
		{
			CurrentSelectedTheme = themeButton;
			ThemeManager.OnStyleChanged?.Invoke(themeButton.BarStyle);
			ThemeManager.OnStyleHumanAttractedChange?.Invoke(themeButton.TypeOfHumanAttracted, themeButton.IsLocked);
			LocalizationSettings_SelectedLocaleChanged(null);
		}

		private void UIThemeButton_OnThemeExitOver()
		{
			SetThemeLocalizationString(CurrentSelectedTheme);
			ThemeManager.OnStyleHumanAttractedChange?.Invoke(CurrentSelectedTheme.TypeOfHumanAttracted, CurrentSelectedTheme.IsLocked);
		}

		private void UIThemeButton_OnThemeEnterOver(BarStyleParameters theme)
		{
			SetThemeLocalizationString(theme);
			ThemeManager.OnStyleHumanAttractedChange?.Invoke(theme.TypeOfHumanAttracted, theme.IsLocked);
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			SetThemeLocalizationString(CurrentSelectedTheme);
		}

		private void SetThemeLocalizationString(BarStyleParameters theme)
		{
			_styleNameText.text = (theme.IsLocked ? _lockedStyleNameText.GetLocalizedString() : theme.StyleNameText.GetLocalizedString());
			_styleDescText.text = (theme.IsLocked ? _lockedStyleDescText.GetLocalizedString() : theme.StyleDescText.GetLocalizedString());
		}

		public void SetNextTheme()
		{
			int num = _themes.ToList().IndexOf(CurrentSelectedTheme) + 1;
			BarStyleParameters barStyleParameters;
			do
			{
				if (num >= _themes.Length)
				{
					num = 0;
				}
				barStyleParameters = _themes[num];
				num++;
			}
			while (barStyleParameters.IsLocked);
			_themeButtons[num - 1].EnableTheme();
		}

		public void SetPreviousTheme()
		{
			int num = _themes.ToList().IndexOf(CurrentSelectedTheme) - 1;
			BarStyleParameters barStyleParameters;
			do
			{
				if (num < 0)
				{
					num = _themes.Length - 1;
				}
				barStyleParameters = _themes[num];
				num--;
			}
			while (barStyleParameters.IsLocked);
			_themeButtons[num + 1].EnableTheme();
		}

		public void Show()
		{
			_canvasController.QuickShow();
		}

		public void Hide()
		{
			_canvasController.QuickHide();
		}
	}
}
