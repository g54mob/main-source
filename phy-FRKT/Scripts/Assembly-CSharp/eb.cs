using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TripledoseLibs.Collections;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration;
using VoxelMeshGeneration.Separation;

public class eb
{
	private sealed class dz : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int ppo;

		private object ppp;

		public eb ppq;

		public List<NativeHashSet<int3>> ppr;

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
		public dz(int a)
		{
		}

		[DebuggerHidden]
		private void dnw()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dnw
			this.dnw();
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
		private void dny()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dny
			this.dny();
		}
	}

	private sealed class ea : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pps;

		private object ppt;

		public ReadOnlyNativeHashSet<int3> ppu;

		public eb ppv;

		public ReadOnlyNativeHashSet<int3> ppw;

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
		public ea(int a)
		{
		}

		[DebuggerHidden]
		private void doa()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in doa
			this.doa();
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
		private void doc()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in doc
			this.doc();
		}
	}

	private readonly VoxelMesh ppx;

	private readonly ee ppy;

	private readonly eg ppz;

	private readonly dy pqa;

	private readonly Dictionary<int3, dw> pqb;

	private readonly HashSet<dw> pqc;

	public IReadOnlyDictionary<int3, dw> wvp => null;

	public IReadOnlyCollection<dw> wvq => null;

	public eb(VoxelMesh a, VoxelMeshSeparationModule b)
	{
	}

	[IteratorStateMachine(typeof(dz))]
	public IEnumerator doh(List<NativeHashSet<int3>> a)
	{
		return null;
	}

	public void fek(int3 a, dw b)
	{
	}

	private void dom(dw a)
	{
	}

	private void mxp(dw a)
	{
	}

	public void doj(int3 a)
	{
	}

	public void mnf(int3 a, dw b)
	{
	}

	private void dol()
	{
	}

	public void hdp(int3 a, dw b)
	{
	}

	[IteratorStateMachine(typeof(ea))]
	public IEnumerator dog(ReadOnlyNativeHashSet<int3> a, ReadOnlyNativeHashSet<int3> b)
	{
		return null;
	}

	public void ohm(Color a)
	{
	}

	public void doi(int3 a, dw b)
	{
	}

	public void nty(int3 a)
	{
	}

	public void dok()
	{
	}

	public void iob(int3 a)
	{
	}

	private void fwp(dw a)
	{
	}

	public void lwy()
	{
	}

	private void dbq(dw a)
	{
	}

	public void cd(int3 a)
	{
	}

	public void don(Color a)
	{
	}
}
