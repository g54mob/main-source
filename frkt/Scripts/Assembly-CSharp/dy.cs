using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;

public class dy
{
	private sealed class dx : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int ppf;

		private object ppg;

		public dy pph;

		public List<NativeHashSet<int3>> ppi;

		private List<ds> ppj;

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
		public dx(int a)
		{
		}

		[DebuggerHidden]
		private void dnp()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dnp
			this.dnp();
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
		private void dnr()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dnr
			this.dnr();
		}
	}

	private readonly VoxelMesh ppk;

	private readonly VoxelMeshSeparationModule ppl;

	private readonly eb ppm;

	private List<ds> ppn;

	public void mmf()
	{
	}

	public void mku()
	{
	}

	[IteratorStateMachine(typeof(dx))]
	public IEnumerator dnt(List<NativeHashSet<int3>> a)
	{
		return null;
	}

	public void dnu()
	{
	}

	public void mom()
	{
	}

	public dy(VoxelMesh a, VoxelMeshSeparationModule b, eb c)
	{
	}

	public void flm()
	{
	}
}
