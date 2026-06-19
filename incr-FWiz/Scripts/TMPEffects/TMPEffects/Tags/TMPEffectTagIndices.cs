using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TMPEffects.Tags
{
	public readonly struct TMPEffectTagIndices : IComparable<TMPEffectTagIndices>, IEquatable<TMPEffectTagIndices>
	{
		[CompilerGenerated]
		private sealed class _003Cget_ContainedIndices_003Ed__14 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private int _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public TMPEffectTagIndices _003C_003E4__this;

			public TMPEffectTagIndices _003C_003E3___003C_003E4__this;

			private int _003Ci_003E5__2;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0;
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
			public _003Cget_ContainedIndices_003Ed__14(int _003C_003E1__state)
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
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private readonly int startIndex;

		private readonly int endIndex;

		private readonly int orderAtIndex;

		public int StartIndex => 0;

		public int EndIndex => 0;

		public int OrderAtIndex => 0;

		public bool IsOpen => false;

		public int Length => 0;

		public bool IsEmpty => false;

		public IEnumerable<int> ContainedIndices
		{
			[IteratorStateMachine(typeof(_003Cget_ContainedIndices_003Ed__14))]
			get
			{
				return null;
			}
		}

		public bool Contains(int index)
		{
			return false;
		}

		public TMPEffectTagIndices(int startIndex, int endIndex, int orderAtIndex)
		{
			this.startIndex = 0;
			this.endIndex = 0;
			this.orderAtIndex = 0;
		}

		public int CompareTo(TMPEffectTagIndices other)
		{
			return 0;
		}

		public static bool operator ==(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return false;
		}

		public static bool operator !=(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return false;
		}

		public static bool operator >(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return false;
		}

		public static bool operator <(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(TMPEffectTagIndices other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
