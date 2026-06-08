using TMPro;
using UnityEngine;

namespace Dorfromantik.UI
{
	public class UiTextAttributeModifier : MonoBehaviour
	{
		[SerializeField]
		private string replacementStringPrefix = "[h]";

		[SerializeField]
		private string replacementStringSuffix = "[/h]";

		[SerializeField]
		private bool useHighlightColor;

		[SerializeField]
		private bool shouldOverwriteHighlightColor;

		[SerializeField]
		private Color overwriteHighlightColor;

		[SerializeField]
		private Material highlightMaterial;

		[SerializeField]
		private bool useHighlightFont;

		[SerializeField]
		private TextMeshProUGUI displayedText;

		private void Start()
		{
			if (displayedText == null)
			{
				displayedText = GetComponent<TextMeshProUGUI>();
			}
			UpdateText();
		}

		internal void UpdateText()
		{
			string targetText = ReplaceTextAttributes(displayedText.text);
			HorizontalAlignmentOptions horizontalAlignment = displayedText.horizontalAlignment;
			LocalizationManager.Instance.UpdateTextMesh(displayedText, LocalizedFontStyle.SemiBold, targetText, horizontalAlignment);
		}

		private string ReplaceTextAttributes(string inputString)
		{
			string text = "";
			string text2 = "";
			if (useHighlightColor)
			{
				Color color = highlightMaterial.color;
				if (shouldOverwriteHighlightColor)
				{
					color = overwriteHighlightColor;
				}
				text = text + "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">";
				text2 += "</color>";
			}
			if (useHighlightFont)
			{
				text = text + "<font=\"" + LocalizationManager.Instance.GetFont(LocalizedFontStyle.ExtraBold).name + "\">";
				text2 += "</font>";
			}
			if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text = StringUtility.Reverse(text);
				text2 = StringUtility.Reverse(text2);
			}
			inputString = inputString.Replace(replacementStringPrefix, text).Replace(replacementStringSuffix, text2);
			return inputString;
		}
	}
}
