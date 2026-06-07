using System.ComponentModel;
using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class LanguageSelectorViewElement : AViewElement<LanguageItem>
	{
		private const float RED_THRESH = 50f;

		private const float GREEN_THRESH = 90f;

		private const string DEFAULT_LANGUAGE = "English";

		[NullCheck]
		public TextMeshProUGUI languageBig;

		[NullCheck]
		public TextMeshProUGUI languageSmall;

		[NullCheck]
		public Slider uiPercentSlider;

		[NullCheck]
		public Slider manualPercentSlider;

		[NullCheck]
		public UIElementTooltipNonLocalizedText tooltip;

		private LanguageItem data;

		public override void SetData(LanguageItem data, AGridView<LanguageItem> _)
		{
			if (this.data != null)
			{
				this.data = null;
			}
			if (data != null)
			{
				this.data = data;
			}
			UpdateView();
		}

		private void UpdateView(object sender = null, PropertyChangedEventArgs e = null)
		{
			if (data == null)
			{
				TextMeshProUGUI textMeshProUGUI = languageBig;
				string text = (languageSmall.text = string.Empty);
				textMeshProUGUI.text = text;
				return;
			}
			languageBig.text = data.languageNameNative;
			languageSmall.text = data.languageName;
			bool flag = data.languageName.Equals("English");
			if (flag)
			{
				tooltip.text = LocalizationAPI.Lo("mm/language_translated_percent_og", data.languageName);
			}
			else if (data.percentTranslated + data.percentTranslatedManual < 0)
			{
				tooltip.text = LocalizationAPI.Lo("mm/language_translated_unknown", data.languageName);
			}
			else
			{
				tooltip.text = LocalizationAPI.Lo("mm/language_translated_percent", data.languageName, data.percentTranslated.ToString(), data.percentTranslatedManual.ToString());
			}
			DoTranslationSlider(uiPercentSlider, data.percentTranslated, flag);
			DoTranslationSlider(manualPercentSlider, data.percentTranslatedManual, flag);
			void DoTranslationSlider(Slider slider, int percentage, bool isDefault)
			{
				float value = NumberUtil.Map(percentage, 0f, 100f, 0.1f, 0.9f);
				Color color;
				if (!isDefault)
				{
					color = (((float)percentage < 50f) ? UIColors.RED : ((!((float)percentage > 90f)) ? UIColors.YELLOW : UIColors.GREEN));
				}
				else
				{
					color = UIColors.BLUE;
					value = 1f;
				}
				slider.value = value;
				slider.fillRect.GetComponent<Image>().color = color;
			}
		}
	}
}
