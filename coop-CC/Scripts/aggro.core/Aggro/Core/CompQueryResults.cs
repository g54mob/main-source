namespace Aggro.Core
{
	public struct CompQueryResults<T> where T : struct, IEntityStruct
	{
		internal readonly StructQuery<T> query;

		public int count => query.count;

		internal CompQueryResults(StructQuery<T> query)
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

		public T GetComponentData(int index)
		{
			return query.GetComponentData(index);
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
