using System;
using System.Collections.Generic;

namespace Jundroo.Common.Events
{
	public class EventMigrator<TEventObjectType>
	{
		private Action _actionOnMigration;

		private Func<TEventObjectType> _getEventObject;

		private Dictionary<Action<object>, object> _migrationTriggers = new Dictionary<Action<object>, object>();

		private TEventObjectType _objSubscribedTo;

		private Action<TEventObjectType> _subscribe;

		private Action<TEventObjectType> _unsubscribe;

		private object _updateEventData;

		public EventMigrator(Func<TEventObjectType> getEventObject, Action<TEventObjectType> subscribe, Action<TEventObjectType> unsubscribe)
		{
			Initialize(getEventObject, subscribe, unsubscribe, null);
		}

		public EventMigrator(Func<TEventObjectType> getEventObject, Action<TEventObjectType> subscribe, Action<TEventObjectType> unsubscribe, Action actionOnMigration)
		{
			Initialize(getEventObject, subscribe, unsubscribe, actionOnMigration);
		}

		public void AddMigrationTrigger<TMigrateEventObjectType>(Func<TMigrateEventObjectType> getEventObject, Action<EventMigrator<TEventObjectType>, TMigrateEventObjectType> subscribeToMigrationTriggerEvent, Action<EventMigrator<TEventObjectType>, TMigrateEventObjectType> unsubscribeFromMigrationTrigger)
		{
			TMigrateEventObjectType val = getEventObject();
			subscribeToMigrationTriggerEvent(this, val);
			Action<object> key = delegate(object x)
			{
				unsubscribeFromMigrationTrigger(this, (TMigrateEventObjectType)x);
			};
			_migrationTriggers.Add(key, val);
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		public void MigrateEvent()
		{
			Migrate();
		}

		public void MigrateEvent(object ignored1)
		{
			Migrate();
		}

		public void MigrateEvent(object ignored1, object ignored2)
		{
			Migrate();
		}

		public void MigrateEvent(object ignored1, object ignored2, object ignored3)
		{
			Migrate();
		}

		public void MigrateEvent(object ignored1, object ignored2, object ignored3, object ignored4)
		{
			Migrate();
		}

		public void Unsubscribe()
		{
			foreach (KeyValuePair<Action<object>, object> migrationTrigger in _migrationTriggers)
			{
				if (migrationTrigger.Value != null)
				{
					migrationTrigger.Key?.Invoke(migrationTrigger.Value);
				}
			}
			if (_objSubscribedTo != null)
			{
				_unsubscribe?.Invoke(_objSubscribedTo);
			}
		}

		private void Initialize(Func<TEventObjectType> getEventObject, Action<TEventObjectType> subscribe, Action<TEventObjectType> unsubscribe, Action actionOnMigration)
		{
			_getEventObject = getEventObject;
			_subscribe = subscribe;
			_unsubscribe = unsubscribe;
			_actionOnMigration = actionOnMigration;
			_objSubscribedTo = getEventObject();
			if (_objSubscribedTo != null)
			{
				_subscribe(_objSubscribedTo);
			}
		}

		private void Migrate()
		{
			RewireEvents();
			_actionOnMigration?.Invoke();
		}

		private void RewireEvents()
		{
			if (_objSubscribedTo != null)
			{
				_unsubscribe?.Invoke(_objSubscribedTo);
			}
			_objSubscribedTo = _getEventObject();
			if (_objSubscribedTo != null)
			{
				_subscribe(_objSubscribedTo);
			}
		}
	}
}
