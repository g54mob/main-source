using UnityEngine;

namespace CTI
{
	public static class CTI_Utils
	{
		public static void SetTranslucentLightingFade(float TranslucentLightingRange, float FadeLengthFactor)
		{
			TranslucentLightingRange *= 0.9f;
			float num = TranslucentLightingRange * FadeLengthFactor;
			Shader.SetGlobalVector("_CTI_TransFade", new Vector2(TranslucentLightingRange * TranslucentLightingRange, num * num * (TranslucentLightingRange / num * 2f)));
		}
	}
}
