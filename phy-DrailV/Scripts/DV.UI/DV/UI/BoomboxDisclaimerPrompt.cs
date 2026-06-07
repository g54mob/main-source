using DV.Localization;
using DV.UIFramework;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class BoomboxDisclaimerPrompt : NullCheckingMonoBehaviour
	{
		private const string LOC_DISCLAIMER = "item/boombox_disclaimer";

		private const string LOC_ORIGINAL_IN_ENGLISH = "item/boombox_disclaimer_original";

		[NullCheck]
		public TMP_Text tmPro;

		[NullCheck]
		public RectTransform panelBg;

		public float panelBgResizeTo = 770f;

		[NullCheck]
		public RectTransform shadow;

		public Vector2 shadowResizeTo = new Vector2(-215f, 127f);

		private void Start()
		{
			string text = LocalizationAPI.L("item/boombox_disclaimer");
			if (LocalizationManager.CurrentLanguage.ToLower().Contains("english"))
			{
				tmPro.text = text;
				return;
			}
			string text2 = LocalizationAPI.L("item/boombox_disclaimer_original");
			string text3 = LocalizationAPI.Lo("item/boombox_disclaimer", "English");
			tmPro.text = text + "\n\n" + text2 + "\n\n" + text3;
			panelBg.offsetMin = new Vector2(panelBg.offsetMin.x, panelBgResizeTo);
			panelBg.offsetMax = new Vector2(panelBg.offsetMax.x, 0f - panelBgResizeTo);
			shadow.offsetMin = new Vector2(shadowResizeTo.x, shadowResizeTo.y);
			shadow.offsetMax = new Vector2(0f - shadowResizeTo.x, 0f - shadowResizeTo.y);
		}
	}
}
