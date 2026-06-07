namespace DV.UI
{
	public class UIElementTooltipNonLocalizedText : UIElementTooltipCustomText
	{
		public string text;

		public override string GetText()
		{
			return text;
		}
	}
}
