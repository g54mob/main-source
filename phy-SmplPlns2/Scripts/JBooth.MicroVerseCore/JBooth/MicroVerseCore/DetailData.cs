using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class DetailData : StampData
	{
		public RenderTexture heightMap;

		public RenderTexture normalMap;

		public RenderTexture curveMap;

		public RenderTexture flowMap;

		public RenderTexture clearMap;

		public MicroVerse.DataCache dataCache;

		public int layerIndex;

		public DetailData(Terrain terrain, RenderTexture height, RenderTexture normal, RenderTexture curve, RenderTexture flow, RenderTexture clearMap, MicroVerse.DataCache dataCache)
			: base(terrain)
		{
			base.terrain = terrain;
			heightMap = height;
			normalMap = normal;
			curveMap = curve;
			flowMap = flow;
			this.dataCache = dataCache;
			this.clearMap = clearMap;
		}
	}
}
