using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TripledoseLibs.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;

public class ds : fu
{
	[BurstCompile]
	private struct MultiAdjacentFloodFillInLimitedAreaJob : IJob
	{
		[ReadOnly]
		private readonly VoxelMesh.Voxels m_allVoxelsData;

		[ReadOnly]
		private readonly NativeArray<int3> m_inspectedIndexes;

		private readonly NativeHashSet<int3> m_checkedIndexes;

		private readonly NativeList<int3> m_voxelsProcessQueue;

		[ReadOnly]
		private readonly NativeHashSet<int3> m_limitedAreaIndexes;

		[WriteOnly]
		private readonly NativeArray<int3> m_resultIndexes;

		public MultiAdjacentFloodFillInLimitedAreaJob(VoxelMesh.Voxels allVoxelsData, NativeArray<int3> inspectedIndexes, NativeHashSet<int3> limitedAreaIndexes, NativeHashSet<int3> checkedIndexes, NativeList<int3> voxelsProcessQueue, NativeArray<int3> resultIndexes)
		{
			m_allVoxelsData = default(VoxelMesh.Voxels);
			m_inspectedIndexes = default(NativeArray<int3>);
			m_checkedIndexes = default(NativeHashSet<int3>);
			m_voxelsProcessQueue = default(NativeList<int3>);
			m_limitedAreaIndexes = default(NativeHashSet<int3>);
			m_resultIndexes = default(NativeArray<int3>);
		}

		public void Execute()
		{
		}
	}

	private sealed class dr : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pnz;

		private object poa;

		public ds pob;

		private NativeArray<int3> poc;

		private JobHandle pod;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public dr(int a)
		{
		}

		[DebuggerHidden]
		private void dmp()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dmp
			this.dmp();
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private void dmr()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dmr
			this.dmr();
		}
	}

	private readonly VoxelMesh.Voxels pof;

	private readonly ReadOnlyNativeHashSet<int3> pog;

	public List<NativeHashSet<int3>> poe
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public ds(VoxelMeshSeparationModule a, VoxelMesh b, ReadOnlyNativeHashSet<int3> c)
		: base(null)
	{
	}

	[IteratorStateMachine(typeof(dr))]
	protected override IEnumerator dmk()
	{
		return null;
	}
}
