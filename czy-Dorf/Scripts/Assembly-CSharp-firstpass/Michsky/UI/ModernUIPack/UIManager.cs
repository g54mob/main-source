using TMPro;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class UIManager : ScriptableObject
	{
		public enum ButtonThemeType
		{
			BASIC = 0,
			CUSTOM = 1
		}

		public enum DropdownThemeType
		{
			BASIC = 0,
			CUSTOM = 1
		}

		public enum DropdownAnimationType
		{
			FADING = 0,
			SLIDING = 1,
			STYLISH = 2
		}

		public enum NotificationThemeType
		{
			BASIC = 0,
			CUSTOM = 1
		}

		public enum SliderThemeType
		{
			BASIC = 0,
			CUSTOM = 1
		}

		public enum ToggleThemeType
		{
			BASIC = 0,
			CUSTOM = 1
		}

		public bool enableDynamicUpdate = true;

		public bool enableExtendedColorPicker = true;

		public bool editorHints = true;

		public Color animatedIconColor = new Color(255f, 255f, 255f, 255f);

		public Color contextBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public ButtonThemeType buttonThemeType;

		public TMP_FontAsset buttonFont;

		public float buttonFontSize = 22.5f;

		public Color buttonBorderColor = new Color(255f, 255f, 255f, 255f);

		public Color buttonFilledColor = new Color(255f, 255f, 255f, 255f);

		public Color buttonTextBasicColor = new Color(255f, 255f, 255f, 255f);

		public Color buttonTextColor = new Color(255f, 255f, 255f, 255f);

		public Color buttonTextHighlightedColor = new Color(255f, 255f, 255f, 255f);

		public Color buttonIconBasicColor = new Color(255f, 255f, 255f, 255f);

		public Color buttonIconColor = new Color(255f, 255f, 255f, 255f);

		public Color buttonIconHighlightedColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset dropdownItemFont;

		public float dropdownItemFontSize = 22.5f;

		public DropdownThemeType dropdownThemeType;

		public DropdownAnimationType dropdownAnimationType;

		public TMP_FontAsset dropdownFont;

		public float dropdownFontSize = 22.5f;

		public Color dropdownColor = new Color(255f, 255f, 255f, 255f);

		public Color dropdownTextColor = new Color(255f, 255f, 255f, 255f);

		public Color dropdownIconColor = new Color(255f, 255f, 255f, 255f);

		public Color dropdownItemColor = new Color(255f, 255f, 255f, 255f);

		public Color dropdownItemTextColor = new Color(255f, 255f, 255f, 255f);

		public Color dropdownItemIconColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset selectorFont;

		public float hSelectorFontSize = 28f;

		public Color selectorColor = new Color(255f, 255f, 255f, 255f);

		public Color selectorHighlightedColor = new Color(255f, 255f, 255f, 255f);

		public bool hSelectorInvertAnimation;

		public bool hSelectorLoopSelection;

		public TMP_FontAsset inputFieldFont;

		public float inputFieldFontSize = 28f;

		public Color inputFieldColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset modalWindowTitleFont;

		public TMP_FontAsset modalWindowContentFont;

		public DropdownThemeType modalThemeType;

		public Color modalWindowTitleColor = new Color(255f, 255f, 255f, 255f);

		public Color modalWindowDescriptionColor = new Color(255f, 255f, 255f, 255f);

		public Color modalWindowIconColor = new Color(255f, 255f, 255f, 255f);

		public Color modalWindowBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public Color modalWindowContentPanelColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset notificationTitleFont;

		public float notificationTitleFontSize = 22.5f;

		public TMP_FontAsset notificationDescriptionFont;

		public float notificationDescriptionFontSize = 18f;

		public NotificationThemeType notificationThemeType;

		public Color notificationBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public Color notificationTitleColor = new Color(255f, 255f, 255f, 255f);

		public Color notificationDescriptionColor = new Color(255f, 255f, 255f, 255f);

		public Color notificationIconColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset progressBarLabelFont;

		public float progressBarLabelFontSize = 25f;

		public Color progressBarColor = new Color(255f, 255f, 255f, 255f);

		public Color progressBarBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public Color progressBarLoopBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public Color progressBarLabelColor = new Color(255f, 255f, 255f, 255f);

		public Color scrollbarColor = new Color(255f, 255f, 255f, 255f);

		public Color scrollbarBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset sliderLabelFont;

		public float sliderLabelFontSize = 24f;

		public SliderThemeType sliderThemeType;

		public Color sliderColor = new Color(255f, 255f, 255f, 255f);

		public Color sliderBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public Color sliderLabelColor = new Color(255f, 255f, 255f, 255f);

		public Color sliderPopupLabelColor = new Color(255f, 255f, 255f, 255f);

		public Color sliderHandleColor = new Color(255f, 255f, 255f, 255f);

		public Color switchBorderColor = new Color(255f, 255f, 255f, 255f);

		public Color switchBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public Color switchHandleOnColor = new Color(255f, 255f, 255f, 255f);

		public Color switchHandleOffColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset toggleFont;

		public float toggleFontSize = 35f;

		public ToggleThemeType toggleThemeType;

		public Color toggleTextColor = new Color(255f, 255f, 255f, 255f);

		public Color toggleBorderColor = new Color(255f, 255f, 255f, 255f);

		public Color toggleBackgroundColor = new Color(255f, 255f, 255f, 255f);

		public Color toggleCheckColor = new Color(255f, 255f, 255f, 255f);

		public TMP_FontAsset tooltipFont;

		public float tooltipFontSize = 22f;

		public Color tooltipTextColor = new Color(255f, 255f, 255f, 255f);

		public Color tooltipBackgroundColor = new Color(255f, 255f, 255f, 255f);
	}
}
