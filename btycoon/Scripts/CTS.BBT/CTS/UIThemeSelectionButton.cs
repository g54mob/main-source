using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UIThemeSelectionButton : MonoSingleton<UIThemeSelectionButton>
	{
		[SerializeField]
		private Image _contentImage;

		[SerializeField]
		private Sprite _lockedSprite;

		protected override void SingletonAwake()
		{
			ThemeManager.OnStyleChanged += OnThemeChanged;
			ThemeManager.OnThemeClosed += ThemeManager_OnThemeClosed;
			UnlockingManager.OnNewKeyAdded += UnlockingManager_OnNewKeyAdded;
		}

		private void ThemeManager_OnThemeClosed()
		{
			UpdateTheme();
		}

		protected override void OnSingletonDestroy()
		{
			ThemeManager.OnStyleChanged -= OnThemeChanged;
			ThemeManager.OnThemeClosed -= ThemeManager_OnThemeClosed;
			UnlockingManager.OnNewKeyAdded -= UnlockingManager_OnNewKeyAdded;
		}

		private void OnThemeChanged(EBarStyle barStyle)
		{
			UpdateTheme();
		}

		private void UnlockingManager_OnNewKeyAdded(EUnlockKey obj)
		{
			UpdateTheme();
		}

		private void UpdateTheme()
		{
			BarStyleParameters currentSelectedTheme = MonoSingleton<ThemeManager>.Instance.CurrentSelectedTheme;
			if ((bool)currentSelectedTheme.Icon)
			{
				_contentImage.sprite = (currentSelectedTheme.IsLocked ? _lockedSprite : currentSelectedTheme.Icon);
			}
		}
	}
}
