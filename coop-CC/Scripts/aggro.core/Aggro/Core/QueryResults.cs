namespace Aggro.Core
{
	public struct QueryResults<T> where T : class
	{
		internal readonly ObjectQuery<T> query;

		public int count => query.count;

		public T this[int index] => query[index];

		internal QueryResults(ObjectQuery<T> query)
		{
			this.query = query;
		}

		public EntityKey GetEntityKey(int index)
		{
			return query.GetEntityKey(index);
		}

		public Entity GetEntity(int index)
		{
			return query.GetEntity(index);
		}

		public T GetObject(int index)
		{
			return query.GetObject(index);
		}

		public void Get(int index, out EntityKey key, out T obj)
		{
			query.Get(index, out key, out obj);
		}

		public void Get(int index, out Entity entity, out T obj)
		{
			query.Get(index, out entity, out obj);
		}
	}
}
