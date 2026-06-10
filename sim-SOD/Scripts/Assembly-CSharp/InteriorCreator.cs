using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class InteriorCreator : Creator
{
	public class LoaderThread
	{
		public Coroutine thread;

		public StreetController street;

		public NewFloor floor;

		public bool isDone;
	}

	[CompilerGenerated]
	private sealed class _003CGenChunk_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InteriorCreator _003C_003E4__this;

		private int _003Ccursor_003E5__2;

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
		public _003CGenChunk_003Ed__10(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
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
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public LoaderThread loaderReference;

		internal void _003CThreadedInteriorGeneration_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CThreadedInteriorGeneration_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoaderThread loaderReference;

		public InteriorCreator _003C_003E4__this;

		private _003C_003Ec__DisplayClass11_0 _003C_003E8__1;

		private Thread _003Cthread_003E5__2;

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
		public _003CThreadedInteriorGeneration_003Ed__11(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
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
		void IEnumerator.Reset()
		{
		}
	}

	public int loadChunk;

	public bool threadedInteriorCreationActive;

	[NonSerialized]
	public List<LoaderThread> threads;

	private static InteriorCreator _instance;

	public static InteriorCreator Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public override void StartLoading()
	{
	}

	[IteratorStateMachine(typeof(_003CGenChunk_003Ed__10))]
	private IEnumerator GenChunk()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CThreadedInteriorGeneration_003Ed__11))]
	private IEnumerator ThreadedInteriorGeneration(LoaderThread loaderReference)
	{
		return null;
	}
}
