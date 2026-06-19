using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	public struct NativeFreeList<T> : IDisposable where T : unmanaged
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _currentIndex;

			private NativeFreeList<T> _nativeFreeList;

			public T Current
			{
				get
				{
					return _nativeFreeList[_currentIndex];
				}
				set
				{
					_nativeFreeList[_currentIndex] = value;
				}
			}

			object IEnumerator.Current => Current;

			public int CurrentIndex => _currentIndex;

			public Enumerator(NativeFreeList<T> nativeFreeList)
			{
				_nativeFreeList = nativeFreeList;
				_currentIndex = -1;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				_currentIndex++;
				int num = _currentIndex / 32;
				int i = _currentIndex % 32;
				uint num2 = (uint)(~((1 << i) - 1));
				while (num < _nativeFreeList._occupiedMask.Length && (_nativeFreeList._occupiedMask[num] & num2) == 0)
				{
					num++;
					i = 0;
					num2 = uint.MaxValue;
				}
				if (num < _nativeFreeList._occupiedMask.Length)
				{
					uint num3 = _nativeFreeList._occupiedMask[num];
					for (; i < 32; i++)
					{
						uint num4 = (uint)(1 << i);
						if ((num3 & num4) != 0)
						{
							break;
						}
					}
				}
				_currentIndex = num * 32 + i;
				return _currentIndex < _nativeFreeList._items.Length;
			}
		}

		public struct InsertEnumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _currentIndex;

			private NativeFreeList<T> _nativeFreeList;

			public T Current
			{
				get
				{
					return _nativeFreeList[_currentIndex];
				}
				set
				{
					_nativeFreeList.AddAt(_currentIndex, value);
				}
			}

			object IEnumerator.Current => Current;

			public int CurrentIndex => _currentIndex;

			public InsertEnumerator(NativeFreeList<T> nativeFreeList)
			{
				_nativeFreeList = nativeFreeList;
				_currentIndex = -1;
			}

			public void Reset()
			{
				_currentIndex = -1;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				_currentIndex++;
				int num = _currentIndex / 32;
				int i = _currentIndex % 32;
				uint num2 = (uint)(~((1 << i) - 1));
				while (num < _nativeFreeList._occupiedMask.Length && (_nativeFreeList._occupiedMask[num] & num2) == num2)
				{
					num++;
					i = 0;
					num2 = uint.MaxValue;
				}
				if (num < _nativeFreeList._occupiedMask.Length)
				{
					uint num3 = _nativeFreeList._occupiedMask[num];
					for (; i < 32; i++)
					{
						uint num4 = (uint)(1 << i);
						if ((num3 & num4) == 0)
						{
							break;
						}
					}
				}
				_currentIndex = num * 32 + i;
				_nativeFreeList.EnsureCapacity(_currentIndex + 1);
				return true;
			}
		}

		private NativeReference<int> _freeCount;

		private NativeList<uint> _occupiedMask;

		private NativeList<T> _items;

		public bool IsCreated
		{
			get
			{
				if (_items.IsCreated && _occupiedMask.IsCreated)
				{
					return _freeCount.IsCreated;
				}
				return false;
			}
		}

		public int ValueCount => _items.Length - _freeCount.Value;

		public int Capacity => _items.Length;

		public T this[int index]
		{
			get
			{
				return _items[index];
			}
			set
			{
				_items[index] = value;
			}
		}

		public NativeFreeList(int initialCapacity, Allocator allocator)
		{
			initialCapacity = math.max(initialCapacity, 32);
			initialCapacity = math.ceilpow2(initialCapacity);
			_freeCount = new NativeReference<int>(initialCapacity, allocator);
			_occupiedMask = new NativeList<uint>(initialCapacity / 32, allocator);
			_occupiedMask.Resize(_occupiedMask.Capacity, NativeArrayOptions.ClearMemory);
			_items = new NativeList<T>(initialCapacity, allocator);
			_items.Resize(_items.Capacity, NativeArrayOptions.UninitializedMemory);
		}

		public void Dispose()
		{
			if (_freeCount.IsCreated)
			{
				_freeCount.Dispose();
			}
			if (_occupiedMask.IsCreated)
			{
				_occupiedMask.Dispose();
			}
			if (_items.IsCreated)
			{
				_items.Dispose();
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		public InsertEnumerator GetInsertEnumerator()
		{
			return new InsertEnumerator(this);
		}

		public void DeFragAndShrink(NativeList<int> indexRemap, int minCapacityAfterShrink)
		{
			indexRemap.Clear();
			indexRemap.Resize(_items.Length, NativeArrayOptions.ClearMemory);
			if (_freeCount.Value < 32 || _freeCount.Value < _items.Length / 2)
			{
				for (int i = 0; i < _items.Length; i++)
				{
					indexRemap[i] = i;
				}
				return;
			}
			int num = 0;
			for (int j = 0; j < _items.Length; j++)
			{
				if (HasValueAt(j))
				{
					if (num != j)
					{
						_items[num] = _items[j];
						indexRemap[j] = num;
					}
					else
					{
						indexRemap[j] = j;
					}
					num++;
				}
			}
			int k;
			for (k = 0; k < num / 32; k++)
			{
				_occupiedMask[k] = uint.MaxValue;
			}
			if (num % 32 != 0)
			{
				uint value = (uint)((1 << num % 32) - 1);
				_occupiedMask[k] = value;
				k++;
			}
			for (; k < _occupiedMask.Length; k++)
			{
				_occupiedMask[k] = 0u;
			}
			int x = num;
			x = math.max(x, minCapacityAfterShrink);
			x = math.max(x, 32);
			x = math.ceilpow2(x);
			if (x != _items.Length)
			{
				_items.Resize(x, NativeArrayOptions.UninitializedMemory);
				_occupiedMask.Resize(x / 32, NativeArrayOptions.ClearMemory);
				_freeCount.Value = x - num;
			}
		}

		public void EnsureCapacity(int capacity)
		{
			capacity = math.ceilpow2(capacity);
			if (_items.Length < capacity)
			{
				_freeCount.Value += capacity - _items.Length;
				_items.Resize(capacity, NativeArrayOptions.UninitializedMemory);
				_occupiedMask.Resize(capacity / 32, NativeArrayOptions.ClearMemory);
			}
		}

		public bool HasValueAt(int index)
		{
			int index2 = index / 32;
			int num = index % 32;
			uint num2 = (uint)(1 << num);
			return (_occupiedMask[index2] & num2) != 0;
		}

		public void AddAt(InsertEnumerator enumerator, T value)
		{
			AddAt(enumerator.CurrentIndex, value);
		}

		public void AddAt(int index, T value)
		{
			int index2 = index / 32;
			int num = index % 32;
			uint num2 = (uint)(1 << num);
			_items[index] = value;
			_occupiedMask[index2] |= num2;
			_freeCount.Value--;
		}

		public void RemoveAt(Enumerator enumerator)
		{
			RemoveAt(enumerator.CurrentIndex);
		}

		public void RemoveAt(int index)
		{
			int index2 = index / 32;
			int num = index % 32;
			uint num2 = (uint)(1 << num);
			_occupiedMask[index2] &= ~num2;
			_freeCount.Value++;
		}
	}
}
