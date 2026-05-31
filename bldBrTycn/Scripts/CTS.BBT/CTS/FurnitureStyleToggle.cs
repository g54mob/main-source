using CTS.BBT;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class FurnitureStyleToggle : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private Image _contentImage;

		[SerializeField]
		private Sprite _allThemesSprite;

		[SerializeField]
		private FurnitureShopPopulator _populator;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if ((bool)_toggle)
			{
				_toggle.onValueChanged.AddListener(OnToggleChanged);
			}
			ThemeManager.OnStyleChanged += OnThemeChanged;
			_contentImage.overrideSprite = MonoSingleton<ThemeManager>.Instance.CurrentSelectedTheme.Icon;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if ((bool)_toggle)
			{
				_toggle.onValueChanged.RemoveListener(OnToggleChanged);
			}
			ThemeManager.OnStyleChanged -= OnThemeChanged;
		}

		private void OnToggleChanged(bool isOn)
		{
			_populator.UseThemeFilter(isOn);
			if (MonoSingleton<ThemeManager>.InstanceExists())
			{
				OnThemeChanged(MonoSingleton<ThemeManager>.Instance.CurrentSelectedBarStyle);
			}
		}

		private void OnThemeChanged(EBarStyle obj)
		{
			if ((bool)_allThemesSprite && !_toggle.isOn)
			{
				_contentImage.overrideSprite = _allThemesSprite;
			}
			else
			{
				_contentImage.overrideSprite = MonoSingleton<ThemeManager>.Instance.CurrentSelectedTheme.Icon;
			}
		}
	}
}
