namespace Assets.Scripts.Terrain.Pooling
{
	public class QuadSpherePoolItem<T>
	{
		public int Id { get; private set; }

		public T Item { get; set; }

		public QuadSpherePool<T> Pool { get; private set; }

		public QuadSpherePoolItemState State { get; set; }

		public QuadSpherePoolItem(int id, QuadSpherePool<T> pool)
		{
			Id = id;
			Item = default(T);
			Pool = pool;
			State = QuadSpherePoolItemState.Uninitialized;
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public void ReturnToPool()
		{
			Pool.ReturnItem(this);
		}

		public void ReturnToPoolAsync()
		{
			Pool.ReturnItemAsync(this);
		}
	}
}
