#define LOG_LEVEL_VERBOSE
using System;

namespace TH20
{
	public class EntityComponent : MustCallDestroyOnInstance
	{
		private Entity _owner;

		private int _ID;

		internal static bool CallRemove;

		internal bool HasBeenInitialized { get; private set; }

		public Level Level => _owner.Level;

		public int ID => _ID;

		internal void SetOwner(Entity owner, int id)
		{
			owner.GetType();
			ValidEntityType();
			_owner = owner;
			_ID = id;
		}

		internal virtual void InitializeComponent()
		{
			HasBeenInitialized = true;
		}

		internal virtual void RestoreComponentFromSave()
		{
		}

		protected EntityComponent()
		{
		}

		protected virtual Type ValidEntityType()
		{
			return typeof(Entity);
		}

		public override void Destroy()
		{
			if (_owner == null)
			{
				Logging.Warning(LogChannels.Debug, "{0} has already had Destroy called on it", this);
			}
			else
			{
				CallRemove = true;
				_owner.InternalRemoveComponent(this);
				_owner = null;
				CallRemove = false;
			}
			base.Destroy();
		}

		public Entity GetOwner()
		{
			return _owner;
		}

		public T GetOwner<T>() where T : Entity
		{
			return (T)_owner;
		}
	}
}
