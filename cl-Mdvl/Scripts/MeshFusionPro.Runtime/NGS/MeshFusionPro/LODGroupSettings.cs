using UnityEngine;

namespace NGS.MeshFusionPro
{
	public struct LODGroupSettings
	{
		public int lodCount;

		public LODFadeMode fadeMode;

		public bool animateCrossFading;

		public float[] fadeTransitionsWidth;

		public LODGroupSettings(LODGroup group)
		{
			lodCount = group.lodCount;
			fadeMode = group.fadeMode;
			animateCrossFading = group.animateCrossFading;
			fadeTransitionsWidth = new float[lodCount];
			LOD[] lODs = group.GetLODs();
			for (int i = 0; i < lodCount; i++)
			{
				LOD lOD = lODs[i];
				fadeTransitionsWidth[i] = lOD.fadeTransitionWidth;
			}
		}

		public bool IsEqual(LODGroupSettings settings, float screenHeightThreshold = 0.0001f, float fadeWidthThreshold = 0.0001f)
		{
			if (lodCount != settings.lodCount)
			{
				return false;
			}
			if (fadeMode != settings.fadeMode)
			{
				return false;
			}
			if (animateCrossFading != settings.animateCrossFading)
			{
				return false;
			}
			for (int i = 0; i < lodCount; i++)
			{
				if (Mathf.Abs(fadeTransitionsWidth[i] - settings.fadeTransitionsWidth[i]) > fadeWidthThreshold)
				{
					return false;
				}
			}
			return true;
		}
	}
}
