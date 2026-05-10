using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CsvHelper.Configuration
{
	public class MemberNameCollection : IEnumerable<string>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__15 : IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			public MemberNameCollection _003C_003E4__this;

			private int _003Ci_003E5__2;

			string IEnumerator<string>.Current
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
			public _003CGetEnumerator_003Ed__15(int _003C_003E1__state)
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

		private readonly List<string> names;

		public string this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Prefix { get; set; }

		public List<string> Names => null;

		public int Count => 0;

		public void Add(string name)
		{
		}

		public void Clear()
		{
		}

		public void AddRange(IEnumerable<string> names)
		{
		}

		[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__15))]
		public IEnumerator<string> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
