using System;
using UnityEngine;

namespace JBooth.MicroSplat
{
	[Serializable]
	public class CombinedOverride
	{
		public Texture2D standardAlbedoOverride;

		public Texture2D standardNormalOverride;

		public Texture2D standardPackedOverride;

		public Texture2D standardMetalSmoothOverride;

		public Texture2D standardOcclusionOverride;

		public Texture2D standardHeightOverride;

		public Texture2D standardEmissionOverride;

		public Texture2D standardSpecularOverride;

		public Texture2D standardSSS;

		public bool bStandardUVOverride;

		public Vector4 standardUVOverride = new Vector4(1f, 1f, 0f, 0f);

		public bool bStandardColorOverride;

		public Color standardColorOverride = Color.white;

		public long GetHash()
		{
			long num = 3L;
			num = num * ((standardAlbedoOverride == null) ? 3 : standardAlbedoOverride.GetNativeTexturePtr().ToInt64()) * 3;
			num = num * ((standardNormalOverride == null) ? 5 : standardAlbedoOverride.GetNativeTexturePtr().ToInt64()) * 5;
			num = num * ((standardPackedOverride == null) ? 7 : standardAlbedoOverride.GetNativeTexturePtr().ToInt64()) * 7;
			num = num * ((standardMetalSmoothOverride == null) ? 13 : standardAlbedoOverride.GetNativeTexturePtr().ToInt64()) * 13;
			num = num * ((standardOcclusionOverride == null) ? 21 : standardAlbedoOverride.GetNativeTexturePtr().ToInt64()) * 17;
			num = num * ((standardHeightOverride == null) ? 31 : standardAlbedoOverride.GetNativeTexturePtr().ToInt64()) * 31;
			num = num * ((standardEmissionOverride == null) ? 37 : standardAlbedoOverride.GetNativeTexturePtr().ToInt64()) * 37;
			num = num * ((standardSpecularOverride == null) ? 41 : standardSpecularOverride.GetNativeTexturePtr().ToInt64()) * 41;
			num = num * ((standardSSS == null) ? 43 : standardSSS.GetNativeTexturePtr().ToInt64()) * 43;
			if (bStandardUVOverride)
			{
				num *= standardUVOverride.GetHashCode();
			}
			if (bStandardColorOverride)
			{
				num *= (int)(1f + standardColorOverride.r * 1001f + standardColorOverride.g * 1007f + standardColorOverride.b * 1009f + standardColorOverride.a * 1003f);
			}
			if (num == 0L)
			{
				Debug.Log("Combined override hash returned 0, this should not happen");
			}
			return num;
		}
	}
}
