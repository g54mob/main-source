using System;

namespace TinyGiantStudio.Text
{
	[Serializable]
	public struct KernPair
	{
		public int left;

		public int right;

		public KernPair(int left, int right)
		{
			this.left = 0;
			this.right = 0;
		}
	}
}
