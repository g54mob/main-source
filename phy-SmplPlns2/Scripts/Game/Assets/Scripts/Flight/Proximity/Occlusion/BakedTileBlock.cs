using System;
using System.Collections.Generic;
using System.IO;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	[Serializable]
	public class BakedTileBlock
	{
		public int blockSize;

		public int startX;

		public int startY;

		public List<BakedTileData> tiles;

		public static BakedTileBlock Deserialize(BinaryReader reader)
		{
			BakedTileBlock bakedTileBlock = new BakedTileBlock
			{
				blockSize = reader.ReadInt32(),
				startX = reader.ReadInt32(),
				startY = reader.ReadInt32()
			};
			int num = reader.ReadInt32();
			bakedTileBlock.tiles = new List<BakedTileData>(num);
			for (int i = 0; i < num; i++)
			{
				bakedTileBlock.tiles.Add(BakedTileData.Deserialize(reader));
			}
			return bakedTileBlock;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(blockSize);
			writer.Write(startX);
			writer.Write(startY);
			writer.Write(tiles?.Count ?? 0);
			if (tiles == null)
			{
				return;
			}
			foreach (BakedTileData tile in tiles)
			{
				tile.Serialize(writer);
			}
		}
	}
}
