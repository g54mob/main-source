using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	[ExecuteInEditMode]
	[CreateAssetMenu(fileName = "New UI Manager Manager", menuName = "DreamOS/New UI Manager")]
	public class UIManager : ScriptableObject
	{
		public enum SelectedTheme
		{
			Default = 0,
			Custom = 1
		}

		public static string buildID = "R201-240131";

		[HideInInspector]
		public bool enableDynamicUpdate = true;

		[HideInInspector]
		public bool enableExtendedColorPicker = true;

		[HideInInspector]
		public bool editorHints = true;

		public SelectedTheme selectedTheme;

		public AudioClip hoverSound;

		public AudioClip clickSound;

		public AudioClip errorSound;

		public AudioClip notificationSound;

		public bool enableKeystrokes = true;

		public bool enableKeyboardKeystroke = true;

		public bool enableMouseKeystroke = true;

		public List<AudioClip> keyboardStrokes = new List<AudioClip>();

		public List<AudioClip> mouseStrokes = new List<AudioClip>();

		public Color highlightedColorDark = new Color(255f, 255f, 255f, 255f);

		public Color highlightedColorSecondaryDark = new Color(255f, 255f, 255f, 255f);

		public Color primaryColorDark = new Color(255f, 255f, 255f, 255f);

		public Color secondaryColorDark = new Color(255f, 255f, 255f, 255f);

		public Color windowBGColorDark = new Color(255f, 255f, 255f, 255f);

		public Color backgroundColorDark = new Color(255f, 255f, 255f, 255f);

		public Color taskBarColorDark = new Color(255f, 255f, 255f, 255f);

		public Color highlightedColorCustom = new Color(255f, 255f, 255f, 255f);

		public Color highlightedColorSecondaryCustom = new Color(255f, 255f, 255f, 255f);

		public bool enableUIBlur = true;

		public TMP_FontAsset systemFontThin;

		public TMP_FontAsset systemFontLight;

		public TMP_FontAsset systemFontRegular;

		public TMP_FontAsset systemFontSemiBold;

		public TMP_FontAsset systemFontBold;

		public bool enableLocalization;

		public LocalizationSettings localizationSettings;

		public LocalizationLanguage currentLanguage;

		public static bool isLocalizationEnabled = false;
	}
}
