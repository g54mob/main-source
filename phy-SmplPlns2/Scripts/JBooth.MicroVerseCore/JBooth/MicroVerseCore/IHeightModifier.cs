using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public interface IHeightModifier : IModifier
	{
		bool ApplyHeightStamp(RenderTexture source, RenderTexture dest, HeightmapData heightmapData, OcclusionData od);
	}
}
