using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public static class LocaleUtility
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string callbackString;

		public bool complete;

		internal void _003CGetLocalizedStringAsync_003Eb__0(string s)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetLocalizedStringAsync_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string tableName;

		public string key;

		private _003C_003Ec__DisplayClass1_0 _003C_003E8__1;

		public Action<string> callback;

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
		public _003CGetLocalizedStringAsync_003Ed__1(int _003C_003E1__state)
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

	public static string GetLocalizedString(string tableName, string key)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetLocalizedStringAsync_003Ed__1))]
	public static IEnumerator GetLocalizedStringAsync(string tableName, string key, Action<string> callback)
	{
		return null;
	}
}
