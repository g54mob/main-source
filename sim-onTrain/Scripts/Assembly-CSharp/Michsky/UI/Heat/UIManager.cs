using TMPro;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[CreateAssetMenu(fileName = "New UI Manager", menuName = "Heat UI/New UI Manager")]
	public class UIManager : ScriptableObject
	{
		public enum PressAnyKeyTextType
		{
			Default = 0,
			Custom = 1
		}

		public static string buildID = "R201-240201";

		public bool enableDynamicUpdate = true;

		public AchievementLibrary achievementLibrary;

		public Color commonColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color rareColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color legendaryColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public AudioClip hoverSound;

		public AudioClip clickSound;

		public AudioClip notificationSound;

		public Color accentColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color accentColorInvert = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color primaryColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color secondaryColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color negativeColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color backgroundColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public TMP_FontAsset fontLight;

		public TMP_FontAsset fontRegular;

		public TMP_FontAsset fontMedium;

		public TMP_FontAsset fontSemiBold;

		public TMP_FontAsset fontBold;

		public TMP_FontAsset customFont;

		public bool enableLocalization;

		public LocalizationSettings localizationSettings;

		public static string localizationSaveKey = "GameLanguage_";

		public LocalizationLanguage currentLanguage;

		public static bool isLocalizationEnabled = false;

		public Sprite brandLogo;

		public Sprite gameLogo;

		public bool enableSplashScreen = true;

		public bool showSplashScreenOnce = true;

		public PressAnyKeyTextType pakType;

		public string pakText = "Press {Any Key} To Start";

		public string pakLocalizationText = "PAK_Part1 {PAK_Key} PAK_Part2";
	}
}
