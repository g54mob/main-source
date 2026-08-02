using System;

namespace Polarith.AI.Move
{
	[Serializable]
	public class PlanarFleeBounds : PlanarSeekBounds
	{
		public PlanarFleeBounds()
		{
			inverted = true;
		}
	}
}
