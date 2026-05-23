using UnityEngine;

namespace NGS.MeshFusionPro
{
	public struct LODGroupSettings
	{
		public float size;

		public int lodCount;

		public LODFadeMode fadeMode;

		public bool animateCrossFading;

		public float[] screenTransitionsHeight;

		public float[] fadeTransitionsWidth;

		public LODGroupSettings(LODGroup group)
		{
			size = group.size;
			lodCount = group.lodCount;
			fadeMode = group.fadeMode;
			animateCrossFading = group.animateCrossFading;
			screenTransitionsHeight = new float[lodCount];
			fadeTransitionsWidth = new float[lodCount];
			LOD[] lODs = group.GetLODs();
			for (int i = 0; i < lodCount; i++)
			{
				LOD lOD = lODs[i];
				screenTransitionsHeight[i] = lOD.screenRelativeTransitionHeight;
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
				if (Mathf.Abs(screenTransitionsHeight[i] - settings.screenTransitionsHeight[i]) > screenHeightThreshold)
				{
					return false;
				}
				if (Mathf.Abs(fadeTransitionsWidth[i] - settings.fadeTransitionsWidth[i]) > fadeWidthThreshold)
				{
					return false;
				}
			}
			return true;
		}
	}
}
