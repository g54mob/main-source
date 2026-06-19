#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;

namespace TH20
{
	public class EntityManager : MustCallDestroy
	{
		private int _currentID;

		private readonly List<Entity> _entities;

		private readonly List<Entity> _tickEntities;

		[DontSave]
		private List<Entity> _entitiesDontSave;

		[DontSave]
		private List<Entity> _tickEntitiesDontSave;

		public EntityManager()
		{
			_currentID = 1;
			_entities = new List<Entity>();
			_tickEntities = new List<Entity>();
			_entitiesDontSave = new List<Entity>();
			_tickEntitiesDontSave = new List<Entity>();
		}

		public void PreRestoreFromSave()
		{
			_entitiesDontSave = new List<Entity>();
			_tickEntitiesDontSave = new List<Entity>();
			foreach (Entity entity in _entities)
			{
				entity.HasBeenRestored = false;
			}
		}

		public void PostRestoreFromSave()
		{
			for (int num = _entities.Count - 1; num >= 0; num--)
			{
				Entity entity = _entities[num];
				if (!entity.HasBeenRestored)
				{
					entity.RestoreFromSave();
				}
			}
		}

		public void VerifyAfterLoad()
		{
			for (int num = _entities.Count - 1; num >= 0; num--)
			{
				_entities[num].VerifyAfterLoad();
			}
		}

		public override void Destroy()
		{
			for (int num = _entities.Count - 1; num >= 0; num--)
			{
				Entity entity = _entities[num];
				if (entity.AutoDestroy())
				{
					entity.Destroy();
				}
			}
			for (int num2 = _entitiesDontSave.Count - 1; num2 >= 0; num2--)
			{
				Entity entity2 = _entitiesDontSave[num2];
				if (entity2.AutoDestroy())
				{
					entity2.Destroy();
				}
			}
			LogEntityList(_entities);
			LogEntityList(_entitiesDontSave);
			LogEntityList(_tickEntities);
			LogEntityList(_tickEntitiesDontSave);
			base.Destroy();
		}

		private static void LogEntityList(List<Entity> list)
		{
			foreach (Entity item in list)
			{
				Logging.Warning(LogChannels.Debug, "Type: {0}. Entity: {1}", item.GetType(), item);
			}
		}

		public void Tick()
		{
			TickEntityList(_tickEntities);
			TickEntityList(_tickEntitiesDontSave);
		}

		private void TickEntityList(List<Entity> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Entity entity = list[i];
				for (int j = 0; j < entity.TickComponents.Count; j++)
				{
					EntityTickComponent entityTickComponent = entity.TickComponents[j];
					if (entityTickComponent.IsComponentTickEnabled())
					{
						entityTickComponent.Tick();
					}
				}
			}
		}

		public void LateTick()
		{
			LateTickEntityList(_tickEntities);
			LateTickEntityList(_tickEntitiesDontSave);
		}

		private void LateTickEntityList(List<Entity> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Entity entity = list[i];
				for (int j = 0; j < entity.TickComponents.Count; j++)
				{
					EntityTickComponent entityTickComponent = entity.TickComponents[j];
					if (entityTickComponent.IsComponentTickEnabled())
					{
						entityTickComponent.LateTick();
					}
				}
			}
		}

		public void AddTickableEntity(Entity entity)
		{
			if (entity.ShouldSave())
			{
				_tickEntities.AddUnique(entity);
			}
			else
			{
				_tickEntitiesDontSave.AddUnique(entity);
			}
		}

		public void RemoveTickableEntity(Entity entity)
		{
			if (entity.ShouldSave())
			{
				_tickEntities.Remove(entity);
			}
			else
			{
				_tickEntitiesDontSave.Remove(entity);
			}
		}

		public int AddEntity(Entity entity)
		{
			if (entity.ShouldSave())
			{
				_entities.Add(entity);
			}
			else
			{
				_entitiesDontSave.Add(entity);
			}
			int currentID = _currentID;
			_currentID++;
			return currentID;
		}

		public void RemoveEntity(Entity entity)
		{
			if (entity.ShouldSave())
			{
				_entities.Remove(entity);
			}
			else
			{
				_entitiesDontSave.Remove(entity);
			}
		}

		public Entity GetEntityByID(int ID)
		{
			foreach (Entity entity in _entities)
			{
				if (entity.ID == ID)
				{
					return entity;
				}
			}
			foreach (Entity item in _entitiesDontSave)
			{
				if (item.ID == ID)
				{
					return item;
				}
			}
			return null;
		}
	}
}
