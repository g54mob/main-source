using System;

namespace Mandragora.PWS
{
	[Serializable]
	public class DirtyPixelsCount
	{
		public int R;

		public int G;

		public int B;

		public int Total => R + G + B;
	}
}
