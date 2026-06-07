using System;
using Os.Utils;

namespace Placemaker.Modules.Processing
{
	[Serializable]
	public struct CornerTouch
	{
		public SbyteFloat3 pos;

		public byte cornerIndex;

		public byte axis;

		public bool inside;

		public byte distance;
	}
}
