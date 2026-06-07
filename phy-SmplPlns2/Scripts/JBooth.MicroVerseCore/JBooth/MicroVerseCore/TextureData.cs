using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class TextureData : StampData
	{
		public RenderTexture heightMap;

		public RenderTexture normalMap;

		public RenderTexture curveMap;

		public RenderTexture flowMap;

		public RenderTexture placementMask;

		public RenderTexture indexMap;

		public RenderTexture weightMap;

		public TextureData(Terrain terrain, int alphamapIndex, RenderTexture heightMap, RenderTexture normalMap, RenderTexture curveMap, RenderTexture flowMap)
			: base(terrain)
		{
			this.heightMap = heightMap;
			this.normalMap = normalMap;
			this.curveMap = curveMap;
			this.flowMap = flowMap;
			base.terrain = terrain;
		}
	}
}
