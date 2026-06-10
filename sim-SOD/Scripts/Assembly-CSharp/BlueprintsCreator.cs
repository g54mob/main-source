using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class BlueprintsCreator : Creator
{
	[CompilerGenerated]
	private sealed class _003CLoad_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BlueprintsCreator _003C_003E4__this;

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
		public _003CLoad_003Ed__7(int _003C_003E1__state)
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

	private static BlueprintsCreator _instance;

	public static BlueprintsCreator Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public override void StartLoading()
	{
	}

	[IteratorStateMachine(typeof(_003CLoad_003Ed__7))]
	private IEnumerator Load()
	{
		return null;
	}
}
