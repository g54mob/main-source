using System;
using UnityEngine;

namespace __Project__.Scripts.FloorPaintSystem
{
	[Serializable]
	public class FloorTextureData
	{
		public FloorTextureType floorType;

		public Material floorMaterial;

		public FloorTextureData()
		{
		}

		public FloorTextureData(FloorTextureType type, Material mat)
		{
		}
	}
}
