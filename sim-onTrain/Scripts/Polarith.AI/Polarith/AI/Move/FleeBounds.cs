using System;

namespace Polarith.AI.Move
{
	[Serializable]
	public class FleeBounds : SeekBounds
	{
		public FleeBounds()
		{
			invertFactor = -1f;
		}
	}
}
