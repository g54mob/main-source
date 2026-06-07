using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class HeightmapData : StampData
	{
		public HeightmapData(Terrain terrain)
			: base(terrain)
		{
			base.terrain = terrain;
		}
	}
}
