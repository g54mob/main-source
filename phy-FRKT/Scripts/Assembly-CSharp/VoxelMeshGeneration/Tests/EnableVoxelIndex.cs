using Unity.Mathematics;
using UnityEngine;

namespace VoxelMeshGeneration.Tests
{
	public class EnableVoxelIndex : MonoBehaviour
	{
		[SerializeField]
		private int3 m_voxelIndex;

		[SerializeField]
		private KeyCode m_enableKey;

		[SerializeField]
		private VoxelMesh m_mesh;

		private void Update()
		{
		}
	}
}
