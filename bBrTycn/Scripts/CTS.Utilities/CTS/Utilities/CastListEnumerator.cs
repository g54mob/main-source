using System;
using System.Collections;
using System.Collections.Generic;

namespace CTS.Utilities
{
	public readonly struct CastListEnumerator<TList, TCast> : IEnumerable<TCast>, IEnumerable where TList : class
	{
		public struct Enumerator : IEnumerator<TCast>, IEnumerator, IDisposable
		{
			private readonly List<TList> _array;

			private int _index;

			private TCast _current;

			public TCast Current => _current;

			object IEnumerator.Current => Current;

			public Enumerator(List<TList> array)
			{
				_array = array;
				_index = -1;
				_current = default(TCast);
			}

			public bool MoveNext()
			{
				_index++;
				if (_index >= _array.Count)
				{
					_current = default(TCast);
					return false;
				}
				TList val = _array[_index];
				if (val == null)
				{
					_current = default(TCast);
					return true;
				}
				if (val is TCast current)
				{
					_current = current;
					return true;
				}
				return MoveNext();
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		private readonly List<TList> _array;

		public CastListEnumerator(List<TList> array)
		{
			_array = array;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(_array);
		}

		IEnumerator<TCast> IEnumerable<TCast>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
