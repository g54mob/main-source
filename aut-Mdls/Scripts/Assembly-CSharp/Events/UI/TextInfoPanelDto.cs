namespace Events.UI
{
	public class TextInfoPanelDto : InfoPanelDto
	{
		public string Text { get; private set; }

		public string ReplacementText1 { get; private set; }

		public string ReplacementText2 { get; private set; }

		public string ReplacementText3 { get; private set; }

		public bool EnableWrapping { get; private set; }

		public bool LocalizeText { get; private set; }

		public int FontSize { get; private set; }

		public bool HasReplacement => !string.IsNullOrEmpty(ReplacementText1);

		public TextInfoPanelDto(string text, bool enableWrapping = true, bool localizeText = true, string replacementText1 = "", string replacementText2 = "", string replacementText3 = "")
		{
			Text = text;
			ReplacementText1 = replacementText1;
			ReplacementText2 = replacementText2;
			ReplacementText3 = replacementText3;
			EnableWrapping = enableWrapping;
			LocalizeText = localizeText;
		}

		public void SetFontSize(int fontSize)
		{
			FontSize = fontSize;
		}
	}
}
