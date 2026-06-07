using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Polygon2DTriangulation
{
	public struct FixedBitArray3 : IEnumerable<bool>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CEnumerate_003Ed__10 : IEnumerable<bool>, IEnumerable, IEnumerator<bool>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private bool _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FixedBitArray3 _003C_003E4__this;

			public FixedBitArray3 _003C_003E3___003C_003E4__this;

			private int _003Ci_003E5__2;

			bool IEnumerator<bool>.Current
			{
				[DebuggerHidden]
				get
				{
					return false;
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
			public _003CEnumerate_003Ed__10(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public bool _0;

		public bool _1;

		public bool _2;

		public bool this[int index]
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Contains(bool value)
		{
			return false;
		}

		public int IndexOf(bool value)
		{
			return 0;
		}

		public void Clear()
		{
		}

		public void Clear(bool value)
		{
		}

		[IteratorStateMachine(typeof(_003CEnumerate_003Ed__10))]
		private IEnumerable<bool> Enumerate()
		{
			return null;
		}

		public IEnumerator<bool> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
