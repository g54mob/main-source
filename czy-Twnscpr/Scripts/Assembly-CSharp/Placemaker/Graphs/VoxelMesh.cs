using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Graphs
{
	public class VoxelMesh
	{
		[SerializeField]
		public int2 hexPos;

		[SerializeField]
		public byte uses;

		[SerializeField]
		public Mesh mesh;
	}
}
