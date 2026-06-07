using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration;

namespace TEST
{
	public class TestRaycast : MonoBehaviour
	{
		[SerializeField]
		private LayerMask m_layerMask;

		[SerializeField]
		private bool m_defaultChanging;

		private Ray? qde;

		private int3? qdf;

		private VoxelMesh qdg;

		private void Update()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private Vector3Int err(RaycastHit a)
		{
			return default(Vector3Int);
		}
	}
}
