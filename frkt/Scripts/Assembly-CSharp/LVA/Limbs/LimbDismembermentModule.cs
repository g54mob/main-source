using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Infrastructure.Project.Registration;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;
using VoxelMeshGeneration.Separation.Performing;
using Zenject;

namespace LVA.Limbs
{
	public class LimbDismembermentModule : MonoBehaviour
	{
		[SerializeField]
		private VoxelMeshSeparationModule m_meshSeparationModule;

		[SerializeField]
		private Vector3 m_ancestorIndexOffset;

		[SerializeField]
		private bool m_drawAncestorIndexPosition;

		private bio rxs;

		private bie rxt;

		private PrefabID rxu;

		private bbw<zq, AbstractLimb.wv> rxv;

		private VoxelMesh rxw;

		private LimbPhysics rxx;

		private bbz rxy;

		private bool rxz;

		public event Action<AbstractLimb, SeparatedMeshData, IReadOnlyCollection<int3>> rxr
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void hhq(bie a, bio b)
		{
		}

		public void hht(PrefabID a, bbw<zq, AbstractLimb.wv> b, VoxelMesh c, LimbPhysics d, bbz e, int f)
		{
		}

		private int3 hhu()
		{
			return default(int3);
		}

		private Vector3 hhv()
		{
			return default(Vector3);
		}

		private void hhw(IReadOnlyList<SeparatedMeshData> a, IReadOnlyCollection<int3> b)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
