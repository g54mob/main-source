using UnityEngine;

namespace Events.UI
{
	public class AdvancedTextInfoPanelDto : InfoPanelDto
	{
		public string Text1 { get; private set; }

		public string Text2 { get; private set; }

		public Color Text1Color { get; private set; }

		public Color Text2Color { get; private set; }

		public float Text1Size { get; private set; }

		public float Text2Size { get; private set; }

		public bool EnableWrapping { get; private set; }

		public AdvancedTextInfoPanelDto(string text1, string text2, Color text1Color, Color text2Color, float text1Size, float text2Size, bool enableWrapping = true)
		{
			Text1 = text1;
			Text2 = text2;
			Text1Color = text1Color;
			Text2Color = text2Color;
			Text1Size = text1Size;
			Text2Size = text2Size;
			EnableWrapping = enableWrapping;
		}
	}
}
