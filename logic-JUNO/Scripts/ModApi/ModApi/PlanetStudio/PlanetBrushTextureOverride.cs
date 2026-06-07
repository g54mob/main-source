using UnityEngine;

namespace ModApi.PlanetStudio
{
	public static class PlanetBrushTextureOverride
	{
		public delegate Texture2D GetTextureDelegate();

		public static GetTextureDelegate GetTexture { get; set; }

		public static string MapId { get; set; }
	}
}
