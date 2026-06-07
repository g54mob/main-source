namespace FractureField.PoolManagers
{
	public class ObjectPoolContainer<T>
	{
		private T item;

		public bool Used { get; private set; }

		public T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public void Consume()
		{
		}

		public void Release()
		{
		}
	}
}
