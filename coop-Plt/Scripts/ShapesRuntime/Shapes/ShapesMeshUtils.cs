using UnityEngine;

namespace Shapes
{
	public static class ShapesMeshUtils
	{
		private static Mesh quadMesh;

		private static Mesh triangleMesh;

		private static Mesh sphereMesh;

		private static Mesh cuboidMesh;

		private static Mesh torusMesh;

		private static Mesh coneMesh;

		private static Mesh coneMeshUncapped;

		private static Mesh cylinderMesh;

		private static Mesh capsuleMesh;

		public static Mesh[] QuadMesh => ShapesAssets.Instance.meshQuad;

		public static Mesh[] TriangleMesh => ShapesAssets.Instance.meshTriangle;

		public static Mesh[] SphereMesh => ShapesAssets.Instance.meshSphere;

		public static Mesh[] CuboidMesh => ShapesAssets.Instance.meshCube;

		public static Mesh[] TorusMesh => ShapesAssets.Instance.meshTorus;

		public static Mesh[] ConeMesh => ShapesAssets.Instance.meshCone;

		public static Mesh[] ConeMeshUncapped => ShapesAssets.Instance.meshConeUncapped;

		public static Mesh[] CylinderMesh => ShapesAssets.Instance.meshCylinder;

		public static Mesh[] CapsuleMesh => ShapesAssets.Instance.meshCapsule;

		private static Mesh EnsureValidMeshBounds(Mesh mesh, Bounds bounds)
		{
			mesh.hideFlags = HideFlags.HideInInspector;
			mesh.bounds = bounds;
			return mesh;
		}

		public static Mesh GetLineMesh(LineGeometry geometry, LineEndCap endCaps, DetailLevel detail)
		{
			switch (geometry)
			{
			case LineGeometry.Flat2D:
			case LineGeometry.Billboard:
				return QuadMesh[0];
			case LineGeometry.Volumetric3D:
				if (endCaps != LineEndCap.Round)
				{
					return CylinderMesh[(int)detail];
				}
				return CapsuleMesh[(int)detail];
			default:
				return null;
			}
		}
	}
}
