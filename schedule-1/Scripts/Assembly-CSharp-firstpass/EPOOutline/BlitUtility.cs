using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public static class BlitUtility
	{
		public struct MeshSetupResult
		{
			public readonly int VertexIndex;

			public readonly int TriangleIndex;

			public MeshSetupResult(int vertexIndex, int triangleIndex)
			{
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

		private static Vector4[] normals;

		private static Vector4[] tempVertecies;

		private static VertexAttributeDescriptor[] vertexParams;

		private static ushort[] indecies;

		private static Vertex[] vertices;

		private static Matrix4x4[] matrices;

		private static int itemsToDraw;

		private static bool? supportsInstancing;

		private static bool SupportsInstancing => false;

		private static void UpdateBounds(Renderer renderer, OutlineTarget target)
		{
		}

		public static void PrepareForRendering(OutlineParameters parameters)
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

		public static void Blit(OutlineParameters parameters, RenderTargetIdentifier source, RenderTargetIdentifier destination, RenderTargetIdentifier destinationDepth, Material material, CommandBuffer targetBuffer, int pass = -1, Rect? viewport = null)
		{
		}

		public static void Draw(OutlineParameters parameters, RenderTargetIdentifier target, RenderTargetIdentifier depth, Material material, Rect? viewport = null)
		{
		}
	}
}
