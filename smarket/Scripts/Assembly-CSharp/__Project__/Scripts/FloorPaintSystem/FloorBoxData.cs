using System;
using NaisuPorter.CommonScripts;
using UnityEngine;

namespace __Project__.Scripts.FloorPaintSystem
{
	[Serializable]
	public class FloorBoxData
	{
		public FloorTextureData textureData;

		public int floorId;

		public int floorCount;

		public SerializableVector3 floorPosition;

		public bool isOpen;

		public FloorSo Floor => null;

		public FloorBoxData()
		{
		}

		public FloorBoxData(FloorTextureData texData, int id, int count, Vector3 position, bool open)
		{
		}

		public FloorBoxData(FloorTextureData texData, int id, Vector3 pos)
		{
		}
	}
}
