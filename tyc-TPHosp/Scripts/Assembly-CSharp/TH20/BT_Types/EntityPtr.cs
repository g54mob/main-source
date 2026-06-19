namespace TH20.BT_Types
{
	public class EntityPtr<T> where T : Entity
	{
		private Entity _entity;

		private int _ID = -1;

		private string _stringID;

		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
				_entity = null;
			}
		}

		public void Set(T entity)
		{
			_ID = entity?.ID ?? (-1);
			_stringID = ((entity == null) ? string.Empty : entity.ToString());
			_entity = entity;
		}

		public T Get(Level level)
		{
			if (_ID != -1 && _entity == null)
			{
				_entity = level.EntityManager.GetEntityByID(_ID);
				if (_entity != null)
				{
					_ = _entity is T;
					if (_stringID != null)
					{
						_ = _entity.ToString() != _stringID;
					}
				}
			}
			return _entity as T;
		}
	}
}
