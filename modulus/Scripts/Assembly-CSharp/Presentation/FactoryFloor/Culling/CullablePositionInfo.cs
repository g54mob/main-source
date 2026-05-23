using Data.FactoryFloor.Maps;
using UnityEngine;

namespace Presentation.FactoryFloor.Culling
{
	public struct CullablePositionInfo
	{
		public Vector3 Position;

		public Vector3? Bounds;

		public IslandObject Island;
	}
}
