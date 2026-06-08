using UnityEngine;

namespace GRP
{
	public class RingPartSim : PartSim<RingPart>
	{
		public RingVisual visual;

		public MeshGroupShape shape;

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		public static void CenterOfMass(Transform transform, RingPart part, out Vector3 centerOfMass, out float totalVolume)
		{
			centerOfMass = default(Vector3);
			totalVolume = default(float);
		}

		public static float Area(Vector3 A, Vector3 B, Vector3 C)
		{
			return 0f;
		}

		public static float Volume(Tetrahedron tet)
		{
			return 0f;
		}

		public static Vector3 Centroid(Tetrahedron tet)
		{
			return default(Vector3);
		}

		public static void DrawTet(Transform transform, Tetrahedron tet, Color color, Vector3 offset)
		{
		}

		public static void DrawBridge(Vector3 aStart, Vector3 aEnd, Vector3 bStart, Vector3 bEnd, Color color)
		{
		}
	}
}
