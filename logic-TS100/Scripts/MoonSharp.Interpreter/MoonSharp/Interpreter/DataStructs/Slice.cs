using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace MoonSharp.Interpreter.DataStructs
{
	internal class Slice<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private sealed class GetEnumerator_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private object _003C_003E2__current;

			private int _003C_003E1__state;

			public Slice<T> _003C_003E4__this;

			public int _003Ci_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003Ci_003E5__4 = 0;
					goto IL_0071;
				case 1:
					{
						_003C_003E1__state = -1;
						_003Ci_003E5__4++;
						goto IL_0071;
					}
					IL_0071:
					if (_003Ci_003E5__4 < _003C_003E4__this.m_Length)
					{
						_003C_003E2__current = _003C_003E4__this.m_SourceList[_003C_003E4__this.CalcRealIndex(_003Ci_003E5__4)];
						_003C_003E1__state = 1;
						return true;
					}
					break;
				}
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
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public GetEnumerator_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}
		}

		private IList<T> m_SourceList;

		private int m_From;

		private int m_Length;

		private bool m_Reversed;

		public T this[int index]
		{
			get
			{
				return m_SourceList[CalcRealIndex(index)];
			}
			set
			{
				m_SourceList[CalcRealIndex(index)] = value;
			}
		}

		public int From
		{
			get
			{
				return m_From;
			}
		}

		public int Count
		{
			get
			{
				return m_Length;
			}
		}

		public bool Reversed
		{
			get
			{
				return m_Reversed;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		public Slice(IList<T> list, int from, int length, bool reversed)
		{
			m_SourceList = list;
			m_From = from;
			m_Length = length;
			m_Reversed = reversed;
		}

		private int CalcRealIndex(int index)
		{
			if (index < 0 || index >= m_Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (m_Reversed)
			{
				return m_From + m_Length - index - 1;
			}
			return m_From + index;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < m_Length; i++)
			{
				yield return m_SourceList[CalcRealIndex(i)];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			GetEnumerator_003Ed__3 getEnumerator_003Ed__ = new GetEnumerator_003Ed__3(0);
			getEnumerator_003Ed__._003C_003E4__this = this;
			return getEnumerator_003Ed__;
		}

		public T[] ToArray()
		{
			T[] array = new T[m_Length];
			for (int i = 0; i < m_Length; i++)
			{
				array[i] = m_SourceList[CalcRealIndex(i)];
			}
			return array;
		}

		public List<T> ToList()
		{
			List<T> list = new List<T>(m_Length);
			for (int i = 0; i < m_Length; i++)
			{
				list.Add(m_SourceList[CalcRealIndex(i)]);
			}
			return list;
		}

		public int IndexOf(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i].Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Insert(int index, T item)
		{
			throw new InvalidOperationException("Slices are readonly");
		}

		public void RemoveAt(int index)
		{
			throw new InvalidOperationException("Slices are readonly");
		}

		public void Add(T item)
		{
			throw new InvalidOperationException("Slices are readonly");
		}

		public void Clear()
		{
			throw new InvalidOperationException("Slices are readonly");
		}

		public bool Contains(T item)
		{
			return IndexOf(item) >= 0;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = 0; i < Count; i++)
			{
				array[i + arrayIndex] = this[i];
			}
		}

		public bool Remove(T item)
		{
			throw new InvalidOperationException("Slices are readonly");
		}
	}
}
