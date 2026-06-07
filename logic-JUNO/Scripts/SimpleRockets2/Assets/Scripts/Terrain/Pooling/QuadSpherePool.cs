using System;
using System.Collections.Generic;

namespace Assets.Scripts.Terrain.Pooling
{
	public abstract class QuadSpherePool<T> : IQuadSpherePool
	{
		private int _availableSizeBuffer;

		private int _currentPoolItemId = 1;

		public int AvailableSize => AvailablePool.Count;

		public int AvailableSizeBuffer
		{
			get
			{
				return _availableSizeBuffer;
			}
			set
			{
				_availableSizeBuffer = value;
			}
		}

		public int Size => TrackedPool.Count;

		public int TargetSize { get; protected set; }

		protected Queue<QuadSpherePoolItem<T>> AvailablePool { get; private set; }

		protected HashSet<QuadSpherePoolItem<T>> TrackedPool { get; private set; }

		protected Queue<QuadSpherePoolItem<T>> UninitializedPool { get; private set; }

		protected QuadSpherePool(int initialSize)
		{
			UninitializedPool = new Queue<QuadSpherePoolItem<T>>(initialSize);
			AvailablePool = new Queue<QuadSpherePoolItem<T>>(initialSize);
			for (int i = 0; i < initialSize; i++)
			{
				UninitializedPool.Enqueue(CreateNewPoolItem());
			}
			TrackedPool = new HashSet<QuadSpherePoolItem<T>>(UninitializedPool);
			TrackedPool.Clear();
			_availableSizeBuffer = 16;
		}

		public virtual QuadSpherePoolItem<T> GetItem()
		{
			int count = AvailablePool.Count;
			if (count < _availableSizeBuffer)
			{
				TargetSize = Math.Max(TargetSize, TrackedPool.Count + _availableSizeBuffer);
			}
			if (count > 0)
			{
				return AvailablePool.Dequeue();
			}
			return InitializeNewItem();
		}

		public virtual void Grow(int count)
		{
			for (int i = 0; i < count; i++)
			{
				AvailablePool.Enqueue(InitializeNewItem());
			}
		}

		public void Resize(int targetSize)
		{
			Resize(targetSize, targetSize);
		}

		public void Resize(int targetSize, int minimumSize)
		{
			TargetSize = targetSize;
			int count = TrackedPool.Count;
			if (count < targetSize)
			{
				if (count < minimumSize)
				{
					Grow(minimumSize - count);
				}
			}
			else if (count > targetSize)
			{
				Shrink(count - targetSize);
			}
		}

		public virtual void ReturnItem(QuadSpherePoolItem<T> item)
		{
			if (item.State == QuadSpherePoolItemState.PendingDestruction)
			{
				Destroy(item);
			}
			else
			{
				AvailablePool.Enqueue(item);
			}
		}

		public virtual void ReturnItemAsync(QuadSpherePoolItem<T> item)
		{
			throw new NotSupportedException();
		}

		public void Shrink(int count)
		{
			int num = 0;
			while (AvailablePool.Count > 0 && num < count)
			{
				QuadSpherePoolItem<T> item = AvailablePool.Dequeue();
				TrackedPool.Remove(item);
				Destroy(item);
				num++;
			}
			if (num >= count || TrackedPool.Count <= 0)
			{
				return;
			}
			List<QuadSpherePoolItem<T>> list = new List<QuadSpherePoolItem<T>>(count - num);
			foreach (QuadSpherePoolItem<T> item2 in TrackedPool)
			{
				item2.State = QuadSpherePoolItemState.PendingDestruction;
				list.Add(item2);
				num++;
				if (num >= count)
				{
					break;
				}
			}
			foreach (QuadSpherePoolItem<T> item3 in list)
			{
				TrackedPool.Remove(item3);
			}
		}

		protected abstract T CreateItem(int id);

		protected QuadSpherePoolItem<T> CreateNewPoolItem()
		{
			return new QuadSpherePoolItem<T>(_currentPoolItemId++, this);
		}

		protected void Destroy(QuadSpherePoolItem<T> item)
		{
			Destroy(item.Item);
			item.Item = default(T);
			item.State = QuadSpherePoolItemState.Uninitialized;
			UninitializedPool.Enqueue(item);
		}

		protected abstract void Destroy(T item);

		protected QuadSpherePoolItem<T> InitializeNewItem()
		{
			QuadSpherePoolItem<T> quadSpherePoolItem = ((UninitializedPool.Count > 0) ? UninitializedPool.Dequeue() : CreateNewPoolItem());
			quadSpherePoolItem.State = QuadSpherePoolItemState.Ready;
			quadSpherePoolItem.Item = CreateItem(quadSpherePoolItem.Id);
			TrackedPool.Add(quadSpherePoolItem);
			return quadSpherePoolItem;
		}
	}
}
