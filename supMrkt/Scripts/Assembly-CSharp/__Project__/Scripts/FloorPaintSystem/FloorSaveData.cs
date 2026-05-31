using System;

namespace __Project__.Scripts.FloorPaintSystem
{
	[Serializable]
	public class FloorSaveData
	{
		public int floorId;

		public FloorTextureType textureType;

		public FloorSaveData()
		{
		}

		public FloorSaveData(int id, FloorTextureType textureType)
		{
		}
	}
}
