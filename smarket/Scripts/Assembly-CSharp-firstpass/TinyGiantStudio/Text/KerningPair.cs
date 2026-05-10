using System;

namespace TinyGiantStudio.Text
{
	[Serializable]
	public struct KerningPair
	{
		public char left;

		public float offset;

		public char right;

		public KerningPair(char left, char right, float offset)
		{
			this.left = '\0';
			this.offset = 0f;
			this.right = '\0';
		}
	}
}
