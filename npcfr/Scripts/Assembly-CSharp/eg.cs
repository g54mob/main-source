using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TripledoseLibs.Collections;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration.Separation;

public class eg
{
	private sealed class ef : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pqz;

		private object pra;

		public eg prb;

		public ReadOnlyNativeHashSet<int3> prc;

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
		public ef(int a)
		{
		}

		[DebuggerHidden]
		private void dpf()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dpf
			this.dpf();
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
		private void dph()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dph
			this.dph();
		}
	}

	private readonly VoxelMeshSeparationModule prd;

	private readonly eb pre;

	private List<Coroutine> prf;

	private Dictionary<dw, NativeHashSet<int3>> prg;

	[CompilerGenerated]
	private void dpm(Coroutine a)
	{
	}

	public IEnumerator gho(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public IEnumerator gtw(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	[IteratorStateMachine(typeof(ef))]
	private IEnumerator dpl(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public IEnumerator dpj(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public eg(VoxelMeshSeparationModule a, eb b)
	{
	}

	public IEnumerator djn(ReadOnlyNativeHashSet<int3> a)
	{
		return null;
	}

	public void dpk()
	{
	}

	public void jyo()
	{
	}
}
