using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public static class BlitUtility
	{
		private struct MeshSetupResult
		{
			public readonly int ItemsToDraw;

			public readonly int VertexIndex;

			public readonly int TriangleIndex;

			public MeshSetupResult(int itemsToDraw, int vertexIndex, int triangleIndex)
			{
				ItemsToDraw = 0;
				VertexIndex = 0;
				TriangleIndex = 0;
			}
		}

		public struct Vertex
		{
			public Vector4 Position;

			public Vector3 Normal;
		}

		private static readonly int MainTexHash;

		private static readonly int NormalMatricesHash;

		private static Vector4[] normals;

		private static ushort[] tempIndicies;

		private static Vector4[] tempVertecies;

		private static readonly VertexAttributeDescriptor[] vertexParams;

		private const int BatchSize = 128;

		private const int DefaultBufferSize = 16;

		private static Vertex[] vertices;

		private static ushort[] indices;

		private static Matrix4x4[] matrices;

		private static Matrix4x4[] batchMatrices;

		private static Matrix4x4[] rotationMatrices;

		private static Matrix4x4[] batchRotationMatrices;

		private static readonly Matrix4x4[] identityMatrixArray;

		private static MeshSetupResult? currentSetupResult;

		private static MaterialPropertyBlock propertyBlock;

		private static bool? supportsInstancing;

		private static bool SupportsInstancing => false;

		private static void UpdateBounds(Renderer renderer, OutlineTarget target)
		{
		}

		public static void PrepareForRendering(OutlineParameters parameters)
		{
		}

		private static void CheckModel()
		{
		}

		private static MeshSetupResult? SetupForInstancing(OutlineParameters parameters)
		{
			return null;
		}

		private static MeshSetupResult? SetupForBruteForce(OutlineParameters parameters)
		{
			return null;
		}

		private static void RenderInstancedBatched(CommandBufferWrapper buffer, Mesh mesh, Material material, int pass, int count)
		{
		}

		public static void Blit(OutlineParameters parameters, RTHandle source, RTHandle destination, RTHandle destinationDepth, int eyeSlice, Material material, int pass = -1, Rect? viewport = null)
		{
		}

		public static void Draw(OutlineParameters parameters, RTHandle destination, RTHandle destinationDepth, int eyeSlice, Material material, int pass = -1, Rect? viewport = null)
		{
		}
	}
}
