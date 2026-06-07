using UnityEngine;

namespace Slicer2D
{
	public class Slicer2DSettings : MonoBehaviour
	{
		public enum InstantiationMethod
		{
			Default = 0,
			Quality = 1,
			Performance = 2
		}

		public enum CenterOfSliceTransform
		{
			Default = 0,
			Origin = 1,
			ColliderCenter = 2
		}

		public enum Triangulation
		{
			Default = 0,
			Advanced = 1,
			Legacy = 2
		}

		public enum Batching
		{
			Default = 0,
			On = 1,
			Off = 2
		}

		public enum RenderingPipeline
		{
			Universal = 0,
			LightWeight = 1
		}

		public static Slicer2DSettingsProfile profile;

		public static Slicer2DSettingsProfile GetProfile()
		{
			return null;
		}

		public static bool GetBatching(bool setting)
		{
			return false;
		}

		public static Slicer2D.CenterOfSliceTransform GetCenterOfSliceTransform(Slicer2D.CenterOfSliceTransform setting)
		{
			return default(Slicer2D.CenterOfSliceTransform);
		}

		public static PolygonTriangulator2D.Triangulation GetTriangulation(PolygonTriangulator2D.Triangulation setting)
		{
			return default(PolygonTriangulator2D.Triangulation);
		}

		public static Slicer2D.InstantiationMethod GetComponentsCopy(Slicer2D.InstantiationMethod setting)
		{
			return default(Slicer2D.InstantiationMethod);
		}

		public static float GetGarbageCollector()
		{
			return 0f;
		}

		public static RenderingPipeline GetRenderingPipeline()
		{
			return default(RenderingPipeline);
		}

		public static int GetExplosionSlices()
		{
			return 0;
		}
	}
}
