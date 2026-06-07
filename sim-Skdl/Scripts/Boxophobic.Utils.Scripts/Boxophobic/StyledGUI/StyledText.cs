using UnityEngine;

namespace Boxophobic.StyledGUI
{
	public class StyledText : PropertyAttribute
	{
		public string text;

		public TextAnchor alignment;

		public float top;

		public float down;

		public StyledText()
		{
		}

		public StyledText(TextAnchor alignment)
		{
		}

		public StyledText(TextAnchor alignment, float top, float down)
		{
		}
	}
}
