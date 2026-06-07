using UnityEngine;

namespace Brewery.Map.V2
{
	public static class MapCartographicState
	{
		public static bool IsActive;

		public static Camera MapCamera;

		public static float InkProgress;

		public static float OpenT;

		public static MapStyleProfile StyleProfile;

		public static Texture2D TerrainSurfaceMask;

		public static Vector4 TerrainOrigin;

		public static Vector4 TerrainSize;
	}
}
