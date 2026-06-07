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

public class ee
{
	private sealed class ec : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pqd;

		private object pqe;

		public ee pqf;

		public ReadOnlyNativeHashSet<int3> pqg;

		private du pqh;

		private List<NativeHashSet<int3>>.Enumerator pqi;

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
		private void dop()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dop
			this.dop();
		}

		[DebuggerHidden]
		private void dos()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dos
			this.dos();
		}

		private void mti()
		{
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
		public ec(int a)
		{
		}

		private void doq()
		{
		}
	}

	private sealed class ed : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pqj;

		private object pqk;

		public ee pql;

		public NativeHashSet<int3> pqm;

		private HashSet<dw> pqn;

		private NativeHashSet<int3>.Enumerator pqo;

		private int3 pqp;

		private int pqq;

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
		private void dov()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dov
			this.dov();
		}

		private void dow()
		{
		}

		private void myv()
		{
		}

		[DebuggerHidden]
		private void doy()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in doy
			this.doy();
		}

		private void ikx()
		{
		}

		[DebuggerHidden]
		public ed(int a)
		{
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
	}

	private const int pqr = 500;

	private readonly VoxelMesh pqs;

	private readonly VoxelMeshSeparationModule pqt;

	private readonly eb pqu;

	private int pqv;

	private du pqw;

	private List<NativeHashSet<int3>> pqx;

	private NativeHashSet<int3> pqy;

	public ee(VoxelMesh a, VoxelMeshSeparationModule b, eb c)
	{
	}

	public IEnumerator kch(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public IEnumerator moi(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public IEnumerator ncy(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public void dpb()
	{
	}

	public IEnumerator dpa(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	[IteratorStateMachine(typeof(ec))]
	private IEnumerator dpc(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	[IteratorStateMachine(typeof(ed))]
	private IEnumerator dpd(NativeHashSet<int3> a)
	{
		return null;
	}

	public IEnumerator dgm(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}
}
