using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration;

namespace LVA.Organs.Variants.Human
{
	public sealed class DefaultMuscle : ry<sg>
	{
		[SerializeField]
		private bool m_debug;

		[SerializeField]
		private float m_muscleForceToOrganIntegrityDeltaMult;

		protected override float xex => 0f;

		protected override void grf(rz a)
		{
		}

		protected override HashSet<ub> gre()
		{
			return null;
		}

		protected override hx<int3, VoxelMesh.Voxel> gsn()
		{
			return null;
		}
	}
}
