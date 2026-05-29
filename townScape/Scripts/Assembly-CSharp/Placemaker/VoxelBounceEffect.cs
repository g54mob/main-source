using System.Collections.Generic;
using Placemaker.Graphs;
using UnityEngine;
using UnityEngine.Rendering;

namespace Placemaker
{
	public class VoxelBounceEffect : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter mf;

		[SerializeField]
		private Shader shader;

		[Space]
		[SerializeField]
		private Material material;

		[SerializeField]
		private RenderTexture tex;

		[SerializeField]
		private int count;

		private static readonly int voxelBounceTimeId;

		private static readonly int voxelBounceTexId;

		[SerializeField]
		private List<Vector3> verts;

		[SerializeField]
		private List<Color32> colors;

		[SerializeField]
		private List<int> tris;

		[SerializeField]
		private Mesh voxelBounceMesh;

		public void OnEnable()
		{
		}

		public void OnStart()
		{
		}

		public void VoxelPainted(Voxel voxel, Corner corner)
		{
		}

		public void VoxelAdded(Voxel voxel, Corner corner)
		{
		}

		public void VoxelRemoved(Voxel voxel, Corner corner)
		{
		}

		private void AddVoxel(Voxel voxel, Corner corner, bool sign)
		{
		}

		public void Begin()
		{
		}

		public void MaybeExecute()
		{
		}

		public void AppendBuffer(CommandBuffer buffer)
		{
		}
	}
}
