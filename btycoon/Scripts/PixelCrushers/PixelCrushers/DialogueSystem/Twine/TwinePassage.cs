using System;

namespace PixelCrushers.DialogueSystem.Twine
{
	[Serializable]
	public class TwinePassage
	{
		public string text;

		public TwineLink[] links;

		public string name;

		public string pid;

		public TwinePosition position;
	}
}
