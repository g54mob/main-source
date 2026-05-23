using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;
using VoxelMeshGeneration.Separation.Performing;

public class dq : fu
{
	[BurstCompile]
	private struct FloodFillSeparatedMeshDataJob : IJob
	{
		[ReadOnly]
		private VoxelMesh.Voxels m_allVoxelsData;

		private int3 m_initialIndex;

		private NativeList<int3> m_voxelsProcessQueue;

		private NativeHashSet<int3> m_checkedIndexes;

		private SeparatedMeshData m_separatedMeshData;

		public FloodFillSeparatedMeshDataJob(VoxelMesh.Voxels allVoxelsData, int3 initialIndex, NativeList<int3> voxelsProcessQueue, NativeHashSet<int3> checkedIndexes, SeparatedMeshData separatedMeshData)
		{
			m_allVoxelsData = default(VoxelMesh.Voxels);
			m_initialIndex = default(int3);
			m_voxelsProcessQueue = default(NativeList<int3>);
			m_checkedIndexes = default(NativeHashSet<int3>);
			m_separatedMeshData = default(SeparatedMeshData);
		}

		public void Execute()
		{
		}
	}

	private sealed class dp : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pnr;

		private object pns;

		public dq pnt;

		private JobHandle pnu;

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
		public dp(int a)
		{
		}

		[DebuggerHidden]
		private void dml()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dml
			this.dml();
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
		private void dmn()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dmn
			this.dmn();
		}
	}

	private readonly VoxelMesh pnv;

	private readonly int3 pnw;

	private SeparatedMeshData pnx;

	private NativeHashSet<int3> pny;

	public dq(VoxelMeshSeparationModule a, VoxelMesh b, int3 c, NativeHashSet<int3> d, SeparatedMeshData e)
		: base(null)
	{
	}

	[IteratorStateMachine(typeof(dp))]
	protected override IEnumerator dmk()
	{
		return null;
	}
}
