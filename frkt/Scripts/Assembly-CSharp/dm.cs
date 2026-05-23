using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TripledoseLibs.Collections;
using Unity.Collections;
using Unity.Mathematics;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;
using VoxelMeshGeneration.Separation.Performing;

public class dm
{
	private sealed class dj : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pmi;

		private object pmj;

		public dm pmk;

		public List<ReadOnlyNativeHashSet<int3>> pml;

		public List<SeparatedMeshData> pmm;

		private List<ReadOnlyNativeHashSet<int3>>.Enumerator pmn;

		private SeparatedMeshData pmo;

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
		public dj(int a)
		{
		}

		[DebuggerHidden]
		private void dlg()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dlg
			this.dlg();
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

		private void dle()
		{
		}

		[DebuggerHidden]
		private void dld()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dld
			this.dld();
		}

		private void ezd()
		{
		}

		private void lzl()
		{
		}
	}

	private sealed class dk : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pmp;

		private object pmq;

		public dm pmr;

		public List<ReadOnlyNativeHashSet<int3>> pms;

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
		public dk(int a)
		{
		}

		[DebuggerHidden]
		private void dli()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dli
			this.dli();
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
		private void dlk()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dlk
			this.dlk();
		}
	}

	private sealed class dl : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pmt;

		private object pmu;

		public dm pmv;

		public int3 pmw;

		public NativeHashSet<int3> pmx;

		public SeparatedMeshData pmy;

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
		public dl(int a)
		{
		}

		[DebuggerHidden]
		private void dlm()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dlm
			this.dlm();
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
		private void dlo()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dlo
			this.dlo();
		}
	}

	private readonly VoxelMesh pmz;

	private readonly VoxelMesh pna;

	private readonly VoxelMeshSeparationModule pnb;

	private dq pnc;

	private List<SeparatedMeshData> pnd;

	private em<NativeHashSet<int3>> pne;

	private int3 pnf;

	private int png;

	private Action<IReadOnlyList<SeparatedMeshData>, IReadOnlyCollection<int3>> pnh;

	private HashSet<int3> bqe(IReadOnlyList<SeparatedMeshData> a)
	{
		return null;
	}

	public dm(VoxelMesh a, VoxelMesh b, VoxelMeshSeparationModule c)
	{
	}

	private HashSet<int3> dlz(NativeHashSet<int3> a)
	{
		return null;
	}

	private HashSet<int3> dly(IReadOnlyList<SeparatedMeshData> a)
	{
		return null;
	}

	private void mfv(in IReadOnlyList<SeparatedMeshData> separatedMeshesData, out IReadOnlyList<SeparatedMeshData> a)
	{
		a = null;
	}

	public void dlu(int a)
	{
	}

	private bool dlx(SeparatedMeshData a, SeparatedMeshData b)
	{
		return false;
	}

	private void dlw(in IReadOnlyList<SeparatedMeshData> separatedMeshesData, out IReadOnlyList<SeparatedMeshData> a)
	{
		a = null;
	}

	private HashSet<int3> dap(NativeHashSet<int3> a)
	{
		return null;
	}

	private HashSet<int3> kvb(NativeHashSet<int3> a)
	{
		return null;
	}

	public void dlt(Action<IReadOnlyList<SeparatedMeshData>, IReadOnlyCollection<int3>> a)
	{
	}

	public void dls(int3 a)
	{
	}

	[IteratorStateMachine(typeof(dl))]
	private IEnumerator dmb(int3 a, NativeHashSet<int3> b, SeparatedMeshData c)
	{
		return null;
	}

	private int glm(List<ReadOnlyNativeHashSet<int3>> a)
	{
		return 0;
	}

	public void bay(int3 a)
	{
	}

	public void dlr()
	{
	}

	private HashSet<int3> up(NativeHashSet<int3> a)
	{
		return null;
	}

	private SeparatedMeshData dmc()
	{
		return default(SeparatedMeshData);
	}

	[IteratorStateMachine(typeof(dj))]
	private IEnumerator dlv(List<ReadOnlyNativeHashSet<int3>> a, List<SeparatedMeshData> b)
	{
		return null;
	}

	[IteratorStateMachine(typeof(dk))]
	public IEnumerator dlq(List<ReadOnlyNativeHashSet<int3>> a)
	{
		return null;
	}

	private void dma(IReadOnlyList<SeparatedMeshData> a)
	{
	}

	private void hdx(in IReadOnlyList<SeparatedMeshData> separatedMeshesData, out IReadOnlyList<SeparatedMeshData> a)
	{
		a = null;
	}

	private int dmd(List<ReadOnlyNativeHashSet<int3>> a)
	{
		return 0;
	}
}
