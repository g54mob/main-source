using System;
using UnityEngine;

namespace TerrainComposer2
{
	[Serializable]
	public struct SplatCustom
	{
		public Vector4 select;

		public Vector4 map0;

		public Vector4 map1;

		public Vector4 map2;

		public Vector4 map3;

		public SplatCustom(Vector4 select, Vector4 map0, Vector4 map1, Vector4 map2, Vector4 map3)
		{
			this.select = select;
			this.map0 = map0;
			this.map1 = map1;
			this.map2 = map2;
			this.map3 = map3;
		}
	}
}
