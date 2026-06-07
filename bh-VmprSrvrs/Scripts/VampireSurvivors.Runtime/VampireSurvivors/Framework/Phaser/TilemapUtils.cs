using System.Collections.Generic;
using SuperTiled2Unity;
using Unity.Mathematics;

namespace VampireSurvivors.Framework.Phaser
{
	public static class TilemapUtils
	{
		public static void RemoveTileAt(this SuperMap map, int x, int y, string layerName)
		{
		}

		public static bool BatchRemoveTileAt(this SuperMap map, List<int2> posList, string layerName)
		{
			return false;
		}
	}
}
