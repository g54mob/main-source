namespace TH20
{
	public struct TypedEntityReference<T> where T : Entity
	{
		[DontSave]
		private T _entity;

		private int _id;

		public T Entity
		{
			get
			{
				return _entity;
			}
			set
			{
				_entity = value;
				_id = value?.ID ?? 0;
			}
		}

		public TypedEntityReference(T entity)
		{
			_entity = entity;
			_id = entity?.ID ?? 0;
		}

		public void RestoreFromSave(EntityManager entityManager)
		{
			if (_id > 0)
			{
				Entity entityByID = entityManager.GetEntityByID(_id);
				_entity = (T)entityByID;
			}
		}
	}
}
