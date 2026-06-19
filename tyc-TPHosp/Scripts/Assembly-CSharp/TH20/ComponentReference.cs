#define LOG_LEVEL_VERBOSE
namespace TH20
{
	public struct ComponentReference
	{
		[DontSave]
		private EntityComponent _component;

		private int _entityId;

		private int _componentId;

		public EntityComponent Component
		{
			get
			{
				return _component;
			}
			set
			{
				_component = value;
				if (value == null)
				{
					_entityId = 0;
					_componentId = 0;
				}
				else
				{
					_entityId = value.GetOwner().ID;
					_componentId = value.ID;
				}
			}
		}

		public ComponentReference(EntityComponent component)
		{
			_component = component;
			if (component == null)
			{
				_entityId = 0;
				_componentId = 0;
			}
			else
			{
				_entityId = component.GetOwner().ID;
				_componentId = component.ID;
			}
		}

		public void RestoreFromSave(EntityManager entityManager)
		{
			if (_entityId > 0)
			{
				Entity entityByID = entityManager.GetEntityByID(_entityId);
				if (entityByID == null)
				{
					Logging.Warning("Restoring a component for an entity which has been destroyed. Entity ID: {0}, Component ID: {1}", _entityId, _componentId);
				}
				else
				{
					_component = entityByID.GetComponent(_componentId);
				}
			}
		}
	}
}
