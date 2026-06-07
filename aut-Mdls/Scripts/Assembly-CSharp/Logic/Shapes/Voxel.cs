using System;
using UnityEngine;

namespace Logic.Shapes
{
	[Serializable]
	public struct Voxel
	{
		public Vector3Int Position;

		public bool IsOccupied;

		public Color Color;
	}
}
