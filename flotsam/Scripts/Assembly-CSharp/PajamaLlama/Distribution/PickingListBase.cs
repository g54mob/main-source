using System;
using UnityEngine;

namespace PajamaLlama.Distribution
{
	[Serializable]
	public abstract class PickingListBase<T> : IDisposable
	{
		public enum PickingOrder
		{
			InOrder = 0,
			Random = 16,
			RandomWithElimination = 17
		}

		[SerializeField]
		private PickingOrder _pickingOrder;

		[Tooltip("Limits the amount of items that can be picked, if the value is 0 the amount of items that can be picked is unlimited.")]
		[SerializeField]
		[Min(0f)]
		private int _pickingLimit;

		private ListPool<T>.List _pickingItemCache;

		private int _pickIndex;

		private int _pickedItemCount;

		public abstract T[] Items { get; }

		public int Count
		{
			get
			{
				if (Items != null)
				{
					return Items.Length;
				}
				return 0;
			}
		}

		public T PickItem()
		{
			return _pickingOrder switch
			{
				PickingOrder.Random => PickRandom(), 
				PickingOrder.RandomWithElimination => PickRandomWithElimination(), 
				_ => PickInOrder(), 
			};
		}

		public bool TryPickItem(out T pickedItem)
		{
			if (0 < _pickingLimit && _pickingLimit <= _pickedItemCount)
			{
				Dispose();
				pickedItem = default(T);
				return false;
			}
			pickedItem = PickItem();
			_pickedItemCount++;
			return true;
		}

		public bool IsEmpty()
		{
			return Items.IsNullOrEmpty();
		}

		private T PickInOrder()
		{
			T result = Items[_pickIndex++];
			if (Items.Length <= _pickIndex)
			{
				_pickIndex = 0;
			}
			return result;
		}

		private T PickRandom()
		{
			return Items.GetRandom();
		}

		private T PickRandomWithElimination()
		{
			if (_pickingItemCache == null)
			{
				_pickingItemCache = ListPool<T>.Get(Items.Length);
			}
			if (_pickingItemCache.Count == 0)
			{
				_pickingItemCache.AddRange(Items);
			}
			int randomIndex = _pickingItemCache.GetRandomIndex();
			T result = _pickingItemCache[randomIndex];
			_pickingItemCache.RemoveAt(randomIndex);
			return result;
		}

		public void Dispose()
		{
			_pickingItemCache?.Dispose();
			_pickedItemCount = 0;
			_pickIndex = 0;
		}
	}
}
