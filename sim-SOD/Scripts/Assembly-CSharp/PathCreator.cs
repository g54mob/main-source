using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class PathCreator : Creator
{
	[CompilerGenerated]
	private sealed class _003CGenChunk_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PathCreator _003C_003E4__this;

		private int _003CpathsProgress_003E5__2;

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
		public _003CGenChunk_003Ed__8(int _003C_003E1__state)
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

	public Dictionary<NewNode, List<NewNode>> pathsNeededWalking;

	private static PathCreator _instance;

	public static PathCreator Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public override void StartLoading()
	{
	}

	[IteratorStateMachine(typeof(_003CGenChunk_003Ed__8))]
	private IEnumerator GenChunk()
	{
		return null;
	}
}
