using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TripledoseLibs.Collections;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;

public class @do : fu
{
	public struct FindNeighbourEnabledVoxelsIndexesJob : IJob
	{
		[ReadOnly]
		private readonly VoxelMesh.Voxels m_allIndexes;

		[ReadOnly]
		private readonly NativeArray<int3> m_inspectedIndexes;

		private readonly NativeHashSet<int3> m_checkedIndexes;

		[WriteOnly]
		private readonly NativeList<int3> m_resultIndexes;

		public FindNeighbourEnabledVoxelsIndexesJob(VoxelMesh.Voxels allIndexes, NativeArray<int3> inspectedIndexes, NativeHashSet<int3> checkedIndexes, NativeList<int3> resultIndexes)
		{
			m_allIndexes = default(VoxelMesh.Voxels);
			m_inspectedIndexes = default(NativeArray<int3>);
			m_checkedIndexes = default(NativeHashSet<int3>);
			m_resultIndexes = default(NativeList<int3>);
		}

		public void Execute()
		{
		}
	}

	private sealed class dn : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pni;

		private object pnj;

		public @do pnk;

		private NativeList<int3> pnl;

		private JobHandle pnm;

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
		public dn(int a)
		{
		}

		[DebuggerHidden]
		private void dme()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dme
			this.dme();
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
		private void dmg()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dmg
			this.dmg();
		}
	}

	private readonly VoxelMesh pnn;

	private readonly ReadOnlyNativeHashSet<int3> pno;

	private bool pnp;

	public NativeHashSet<int3> pnq
	{
		[CompilerGenerated]
		get
		{
			return default(NativeHashSet<int3>);
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public @do(VoxelMeshSeparationModule a, VoxelMesh b, ReadOnlyNativeHashSet<int3> c)
		: base(null)
	{
	}

	[IteratorStateMachine(typeof(dn))]
	protected override IEnumerator dmk()
	{
		return null;
	}
}
