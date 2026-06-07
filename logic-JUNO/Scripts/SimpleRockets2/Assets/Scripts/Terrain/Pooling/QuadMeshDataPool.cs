using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModApi.Planet;

namespace Assets.Scripts.Terrain.Pooling
{
	public abstract class QuadMeshDataPool<T> : QuadSpherePool<T>
	{
		private readonly object _asyncReturnLock = new object();

		private List<QuadSpherePoolItem<T>> _asyncReturns;

		public Type MeshVertexType { get; private set; }

		public QuadMeshPoolType PoolType { get; private set; }

		public QuadMeshDataFlags RequiredData { get; private set; }

		public int VertexCount { get; private set; }

		public QuadMeshDataPool(QuadMeshPoolType poolType, int vertexCount, QuadMeshDataFlags requiredData, int initialSize)
			: base(initialSize)
		{
			PoolType = poolType;
			VertexCount = vertexCount;
			RequiredData = requiredData;
			_asyncReturns = new List<QuadSpherePoolItem<T>>();
		}

		public override QuadSpherePoolItem<T> GetItem()
		{
			if (_asyncReturns.Count > 0)
			{
				ProcessAsyncReturns();
			}
			if (base.AvailablePool.Count <= 0)
			{
				return InitializeNewItem();
			}
			return base.AvailablePool.Dequeue();
		}

		public override void Grow(int count)
		{
			object lockObject = new object();
			Action action = delegate
			{
				QuadSpherePoolItem<T> quadSpherePoolItem;
				lock (lockObject)
				{
					quadSpherePoolItem = ((base.UninitializedPool.Count > 0) ? base.UninitializedPool.Dequeue() : CreateNewPoolItem());
				}
				quadSpherePoolItem.State = QuadSpherePoolItemState.Ready;
				quadSpherePoolItem.Item = CreateItem(quadSpherePoolItem.Id);
				lock (lockObject)
				{
					base.TrackedPool.Add(quadSpherePoolItem);
					base.AvailablePool.Enqueue(quadSpherePoolItem);
				}
			};
			Parallel.For(0, count, (Action<int>)delegate
			{
				action();
			});
		}

		public void Initialize(int vertexCount, QuadMeshDataFlags requiredData)
		{
			int vertexCount2 = VertexCount;
			_ = RequiredData;
			Type meshVertexType = MeshVertexType;
			VertexCount = vertexCount;
			RequiredData = requiredData;
			MeshVertexType = QuadMeshPool.GetMeshVertexType(PoolType, requiredData);
			if (VertexCount != vertexCount2 || MeshVertexType != meshVertexType)
			{
				Shrink(base.Size);
				ProcessAsyncReturns();
			}
		}

		public override void ReturnItemAsync(QuadSpherePoolItem<T> item)
		{
			lock (_asyncReturnLock)
			{
				_asyncReturns.Add(item);
			}
		}

		protected override void Destroy(T item)
		{
		}

		private void ProcessAsyncReturns()
		{
			lock (_asyncReturnLock)
			{
				foreach (QuadSpherePoolItem<T> asyncReturn in _asyncReturns)
				{
					ReturnItem(asyncReturn);
				}
				_asyncReturns.Clear();
			}
		}
	}
}
