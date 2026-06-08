namespace Kitchen
{
	public struct PoolElement<T>
	{
		public T Element;

		public ManagedPool<T> Pool;

		public void Free()
		{
			Pool?.Free(this);
		}

		public static explicit operator PoolElement<T>(T element)
		{
			return new PoolElement<T>
			{
				Element = element
			};
		}
	}
}
