using TMPro;

namespace NSMedieval.FloatingOverlaySystem
{
	public class TextFloatingElement : FloatingElementBase
	{
		private bool tmpTextCached;

		private TMP_Text tmpText;

		private string style = "Normal";

		private string text;

		public OverlayTextElementType Type { get; internal set; }

		public void SetText(string text)
		{
			this.text = text;
			if (!tmpTextCached)
			{
				tmpTextCached = true;
				tmpText = GetComponent<TMP_Text>();
			}
			tmpText.SetText("<style=" + style + ">" + this.text + "</style>");
		}

		public void SetStyle(string style)
		{
			this.style = style;
			SetText(text);
		}
	}
}
