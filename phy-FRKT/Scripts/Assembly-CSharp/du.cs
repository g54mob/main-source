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

public class du : fu
{
	[BurstCompile]
	private struct MultiNeighbourFloodFillInLimitedAreaJob : IJob
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

		public MultiNeighbourFloodFillInLimitedAreaJob(VoxelMesh.Voxels allVoxelsData, NativeArray<int3> inspectedIndexes, NativeHashSet<int3> limitedAreaIndexes, NativeHashSet<int3> checkedIndexes, NativeList<int3> voxelsProcessQueue, NativeArray<int3> resultIndexes)
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

	private sealed class dt : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int poh;

		private object poi;

		public du poj;

		private NativeArray<int3> pok;

		private JobHandle pol;

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
		public dt(int a)
		{
		}

		[DebuggerHidden]
		private void dmv()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dmv
			this.dmv();
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
		private void dmx()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dmx
			this.dmx();
		}
	}

	private readonly VoxelMesh pom;

	private readonly ReadOnlyNativeHashSet<int3> pon;

	public List<NativeHashSet<int3>> poo
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

	public du(VoxelMeshSeparationModule a, VoxelMesh b, ReadOnlyNativeHashSet<int3> c)
		: base(null)
	{
	}

	[IteratorStateMachine(typeof(dt))]
	protected override IEnumerator dmk()
	{
		return null;
	}
}
