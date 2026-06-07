using System;
using System.Collections.Generic;
using System.IO;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	[Serializable]
	public class BakedTileData
	{
		public List<BakedSortedFeatureResult> sortedFeatureResults;

		public int tileX;

		public int tileY;

		public static BakedTileData Deserialize(BinaryReader reader)
		{
			BakedTileData bakedTileData = new BakedTileData
			{
				tileX = reader.ReadInt32(),
				tileY = reader.ReadInt32()
			};
			int num = reader.ReadInt32();
			bakedTileData.sortedFeatureResults = new List<BakedSortedFeatureResult>(num);
			for (int i = 0; i < num; i++)
			{
				bakedTileData.sortedFeatureResults.Add(BakedSortedFeatureResult.Deserialize(reader));
			}
			return bakedTileData;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(tileX);
			writer.Write(tileY);
			writer.Write(sortedFeatureResults?.Count ?? 0);
			if (sortedFeatureResults == null)
			{
				return;
			}
			foreach (BakedSortedFeatureResult sortedFeatureResult in sortedFeatureResults)
			{
				sortedFeatureResult.Serialize(writer);
			}
		}
	}
}
