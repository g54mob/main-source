using System;

namespace PixelCrushers.DialogueSystem.Twine
{
	[Serializable]
	public class TwineStory
	{
		public TwinePassage[] passages;

		public string name;

		public string startnode;

		public string creator;
	}
}
