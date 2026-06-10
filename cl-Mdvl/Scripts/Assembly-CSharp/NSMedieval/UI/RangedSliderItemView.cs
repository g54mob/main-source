using NSEipix.View.UI;
using NSMedieval.Enums;

namespace NSMedieval.UI
{
	public class RangedSliderItemView : LayoutGroupItemView
	{
		private int textIndex;

		private int sliderIndex = 1;

		public CustomRangeSlider Slider => base.GroupItems[sliderIndex].GetComponent<CustomRangeSlider>();

		public void SetSliderData(string id, string formattedRange)
		{
			Language currentLanguageEnum = base.Localize.GetCurrentLanguageEnum();
			string text = ((id != null) ? (formattedRange + " " + base.Localize.GetText("menu_" + id)) : formattedRange);
			switch (currentLanguageEnum)
			{
			case Language.Polish:
				text = formattedRange;
				break;
			case Language.French:
			case Language.Spanish:
			case Language.German:
			case Language.Portuguese:
			case Language.Turkish:
				text = ((id != null) ? (base.Localize.GetText("menu_" + id) + " " + formattedRange) : formattedRange);
				break;
			}
			SetText(textIndex, text);
		}
	}
}
