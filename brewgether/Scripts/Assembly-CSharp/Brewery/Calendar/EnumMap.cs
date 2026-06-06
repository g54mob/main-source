using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Brewery.Calendar
{
	public sealed class EnumMap<TEnum, TValue> where TEnum : struct, Enum
	{
		[CompilerGenerated]
		private sealed class _003CEnumerate_003Ed__14 : IEnumerable<(TEnum, TValue)>, IEnumerable, IEnumerator<(TEnum, TValue)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (TEnum key, TValue value) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public EnumMap<TEnum, TValue> _003C_003E4__this;

			private int _003Ci_003E5__2;

			(TEnum, TValue) IEnumerator<(TEnum, TValue)>.Current
			{
				[DebuggerHidden]
				get
				{
					return default((TEnum, TValue));
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
			public _003CEnumerate_003Ed__14(int _003C_003E1__state)
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
			IEnumerator<(TEnum, TValue)> IEnumerable<(TEnum, TValue)>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private readonly TEnum[] _keys;

		private readonly TValue[] _values;

		private readonly Dictionary<int, int> _keyToIndex;

		public int Count => 0;

		public IReadOnlyList<TEnum> Keys => null;

		public TValue this[TEnum key]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public EnumMap()
		{
		}

		public EnumMap(TValue defaultValue)
		{
		}

		public bool TryGetValue(TEnum key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public void Reset(TValue unit)
		{
		}

		[IteratorStateMachine(typeof(EnumMap<, >._003CEnumerate_003Ed__14))]
		public IEnumerable<(TEnum, TValue)> Enumerate()
		{
			return null;
		}

		public EnumMap<TEnum, TValue> Clone()
		{
			return null;
		}

		private int IndexOf(TEnum key)
		{
			return 0;
		}
	}
}
