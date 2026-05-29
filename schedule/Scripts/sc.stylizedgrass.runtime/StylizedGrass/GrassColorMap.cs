using UnityEngine;

namespace StylizedGrass
{
	public class GrassColorMap : ScriptableObject
	{
		public int resolution;

		public Bounds bounds;

		public Vector4 uv;

		public Texture2D texture;

		public Texture2D customTex;

		[Tooltip("When enabled, a custom color map texture can be used")]
		public bool overrideTexture;

		public bool hasScalemap;

		public static GrassColorMap Active;

		private static readonly int _ColorMap;

		private static readonly int _ColorMapUV;

		private static readonly int _ColorMapParams;

		public void SetActive()
		{
		}

		public static void DisableGlobally()
		{
		}
	}
}
