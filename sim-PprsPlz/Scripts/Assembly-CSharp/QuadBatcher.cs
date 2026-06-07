using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using app.vis;

public class QuadBatcher
{
	private class QuadMesh
	{
		private struct Vert
		{
			public Vector3 pos;

			public Vector4 color;

			public Vector2 uv;
		}

		private class Submesh
		{
			public int quadIndex0;

			public int quadIndex1;

			public Texture texture;

			public MaterialPropertyBlock materialPropertyBlock;

			public void Clear()
			{
			}
		}

		private Mesh mesh;

		private Vert[] verts;

		private ushort[] indexes;

		private int submeshCount;

		private List<Submesh> submeshes;

		private List<SubMeshDescriptor> submeshDescriptors;

		private const int kMaxQuads = 1024;

		private const int kMaxSubmeshes = 32;

		private static readonly MeshUpdateFlags kDefaultMeshUpdateFlags;

		private static readonly VertexAttributeDescriptor[] vertexLayout;

		public void Clear()
		{
		}

		public bool Add(Quad quad, Texture2D texture)
		{
			return false;
		}

		public void DrawAndClear(CommandBuffer commandBuffer, Material material)
		{
		}
	}

	private List<QuadMesh> quadMeshes;

	private int quadMeshIndex;

	public void Begin()
	{
	}

	public void Add(Quad quad, Texture2D texture)
	{
	}

	public void End(CommandBuffer commandBuffer, Material material)
	{
	}
}
