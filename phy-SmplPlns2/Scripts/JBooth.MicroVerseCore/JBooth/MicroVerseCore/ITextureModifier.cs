using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public interface ITextureModifier : IModifier
	{
		bool ApplyTextureStamp(RenderTexture indexSrc, RenderTexture indexDest, RenderTexture weightSrc, RenderTexture weightDest, TextureData splatmapData, OcclusionData od);

		void InqTerrainLayers(Terrain terrain, List<TerrainLayer> prototypes);

		bool NeedCurvatureMap();

		bool NeedFlowMap();
	}
}
