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

public class dw
{
	private sealed class dv : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pop;

		private object poq;

		public dw por;

		public ReadOnlyNativeHashSet<int3> pot;

		private du pou;

		private List<@do> pov;

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
		public dv(int a)
		{
		}

		[DebuggerHidden]
		private void dnc()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dnc
			this.dnc();
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
		private void dne()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dne
			this.dne();
		}
	}

	private readonly eb pow;

	private readonly VoxelMeshSeparationModule pox;

	private readonly VoxelMesh poy;

	private NativeHashSet<int3> poz;

	private NativeHashSet<int3> ppa;

	private bool ppb;

	private List<fu> ppc;

	private List<NativeHashSet<int3>> ppd;

	public int ppe
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public ReadOnlyNativeHashSet<int3> wvi => default(ReadOnlyNativeHashSet<int3>);

	public dw(eb a, VoxelMeshSeparationModule b, VoxelMesh c, NativeHashSet<int3> d, NativeHashSet<int3> e)
	{
	}

	public void jje(ReadOnlyNativeHashSet<int3> a, ReadOnlyNativeHashSet<int3> b)
	{
	}

	public void olw()
	{
	}

	public void nau(dw a)
	{
	}

	public void jim(dw a)
	{
	}

	public void dnm()
	{
	}

	private void dnn(ReadOnlyNativeHashSet<int3> a)
	{
	}

	public void dnl(dw a)
	{
	}

	public void dzd(ReadOnlyNativeHashSet<int3> a, ReadOnlyNativeHashSet<int3> b)
	{
	}

	[IteratorStateMachine(typeof(dv))]
	public IEnumerator dnj(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public void dxy(ReadOnlyNativeHashSet<int3> a, ReadOnlyNativeHashSet<int3> b)
	{
	}

	public void czo(dw a)
	{
	}

	public void dnk(ReadOnlyNativeHashSet<int3> a, ReadOnlyNativeHashSet<int3> b)
	{
	}

	public void lb(dw a)
	{
	}

	private void evx(ReadOnlyNativeHashSet<int3> a)
	{
	}

	public void beu(ReadOnlyNativeHashSet<int3> a, ReadOnlyNativeHashSet<int3> b)
	{
	}
}
