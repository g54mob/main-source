using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public interface IHoleModifier : IModifier
	{
		void ApplyHoleStamp(RenderTexture src, RenderTexture dest, HoleData holeData, OcclusionData od);

		bool IsValidHoleStamp();

		bool NeedCurvatureMap();

		bool NeedFlowMap();
	}
}
