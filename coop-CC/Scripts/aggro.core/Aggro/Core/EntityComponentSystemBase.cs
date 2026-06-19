namespace Aggro.Core
{
	public abstract class EntityComponentSystemBase<T> : EntitySystemBase where T : struct, IEntityStruct
	{
		private StructQuery<T> _query;

		protected virtual EntityQueryFlags _queryFlags => EntityQueryFlags.Default;

		protected sealed override void OnCreateSystem()
		{
			_query = base.entityManager.CreateStructQuery<T>(_queryFlags);
			OnCreateComponentSystem();
		}

		protected sealed override void OnDestroySystem()
		{
			OnDestroyComponentSystem();
		}

		protected sealed override void OnUpdateSystem()
		{
			_query.Run();
			OnUpdateComponentSystem(new CompQueryResults<T>(_query));
		}

		protected virtual void OnCreateComponentSystem()
		{
		}

		protected virtual void OnDestroyComponentSystem()
		{
		}

		protected abstract void OnUpdateComponentSystem(CompQueryResults<T> results);
	}
}
