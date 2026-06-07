using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class VegetationUtilities
	{
		public static int FindDetailIndex(Terrain terrain, DetailPrototypeSerializable prototype)
		{
			int result = -1;
			DetailPrototype[] detailPrototypes = terrain.terrainData.detailPrototypes;
			for (int i = 0; i < detailPrototypes.Length; i++)
			{
				DetailPrototype detail = detailPrototypes[i];
				if (prototype.IsEqualToDetail(detail))
				{
					result = i;
				}
			}
			return result;
		}

		public static int FindTreeIndex(Terrain terrain, TreePrototypeSerializable prototype)
		{
			int result = -1;
			TreePrototype[] treePrototypes = terrain.terrainData.treePrototypes;
			for (int i = 0; i < treePrototypes.Length; i++)
			{
				TreePrototype tree = treePrototypes[i];
				if (prototype.IsEqualToTree(tree))
				{
					result = i;
				}
			}
			return result;
		}
	}
}
