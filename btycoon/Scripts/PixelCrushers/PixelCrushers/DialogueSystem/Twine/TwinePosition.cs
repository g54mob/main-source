using System;

namespace PixelCrushers.DialogueSystem.Twine
{
	[Serializable]
	public class TwinePosition
	{
		public float x;

		public float y;

		public TwinePosition()
		{
		}

		public TwinePosition(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
