namespace TH20
{
	public struct EntityReference
	{
		[DontSave]
		private Entity _entity;

		private int _id;

		public Entity Entity
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

		public EntityReference(Entity entity)
		{
			_entity = entity;
			_id = entity?.ID ?? 0;
		}

		public void RestoreFromSave(EntityManager entityManager)
		{
			if (_id > 0)
			{
				_entity = entityManager.GetEntityByID(_id);
			}
		}
	}
}
