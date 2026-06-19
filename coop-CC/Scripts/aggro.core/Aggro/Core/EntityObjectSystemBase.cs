namespace Aggro.Core
{
	public abstract class EntityObjectSystemBase<T> : EntitySystemBase where T : class
	{
		private ObjectQuery<T> _query;

		protected virtual EntityQueryFlags _queryFlags => EntityQueryFlags.Default;

		protected sealed override void OnCreateSystem()
		{
			_query = base.entityManager.CreateObjectQuery<T>(_queryFlags);
			OnCreateObjectSystem();
		}

		protected sealed override void OnDestroySystem()
		{
			OnDestroyObjectSystem();
		}

		protected sealed override void OnUpdateSystem()
		{
			if (ShouldRun())
			{
				_query.Run();
				OnUpdateObjectSystem(new QueryResults<T>(_query));
			}
		}

		protected virtual void OnCreateObjectSystem()
		{
		}

		protected virtual void OnDestroyObjectSystem()
		{
		}

		protected abstract void OnUpdateObjectSystem(QueryResults<T> results);

		protected virtual bool ShouldRun()
		{
			return true;
		}
	}
}
