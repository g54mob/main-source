using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class HoleData : StampData
	{
		public RenderTexture heightMap;

		public RenderTexture normalMap;

		public RenderTexture curveMap;

		public RenderTexture flowMap;

		public RenderTexture placementMask;

		public RenderTexture indexMap;

		public RenderTexture weightMap;

		public HoleData(Terrain terrain, RenderTexture heightMap, RenderTexture normalMap, RenderTexture curveMap, RenderTexture flowMap, RenderTexture indexMap, RenderTexture weightMap)
			: base(terrain)
		{
			this.heightMap = heightMap;
			this.normalMap = normalMap;
			this.curveMap = curveMap;
			this.flowMap = flowMap;
			this.indexMap = indexMap;
			this.weightMap = weightMap;
			base.terrain = terrain;
		}
	}
}
