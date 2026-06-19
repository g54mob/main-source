namespace Aggro.Core
{
	public struct QueryResult
	{
		public EntityKey key;

		public object obj;

		public int typeIndex;

		public QueryResult<T> As<T>() where T : class
		{
			return new QueryResult<T>
			{
				key = key,
				obj = (obj as T)
			};
		}
	}
	public struct QueryResult<T> where T : class
	{
		public EntityKey key;

		public T obj;

		public int typeIndex;
	}
}
