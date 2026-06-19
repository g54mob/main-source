using System;
using System.Collections.Generic;
using FullSerializerSave;

namespace TH20
{
	public class Entity : MustCallDestroy
	{
		[fsProperty]
		private readonly int _ID;

		[fsProperty]
		private readonly Level _level;

		[fsProperty("_definition", Converter = typeof(EntityDefinitionConverter))]
		private IEntityDefinition _definition;

		[fsProperty]
		private readonly List<EntityComponent> _components;

		[fsProperty]
		private readonly List<EntityTickComponent> _tickComponents;

		[fsProperty]
		private bool _hasBeenInitialized;

		[fsProperty]
		private int _nextComponentID;

		[DontSave]
		private bool _hasBeenRestored;

		public List<EntityTickComponent> TickComponents => _tickComponents;

		public Level Level => _level;

		public int ID => _ID;

		public bool HasBeenRestored
		{
			get
			{
				return _hasBeenRestored;
			}
			set
			{
				_hasBeenRestored = value;
			}
		}

		protected Entity(IEntityDefinition definition, Level level)
		{
			_level = level;
			_definition = definition;
			_components = new List<EntityComponent>();
			_tickComponents = new List<EntityTickComponent>();
			_hasBeenInitialized = false;
			_hasBeenRestored = true;
			if (definition.Components != null)
			{
				EntityComponent[] components = definition.Components;
				foreach (EntityComponent obj in components)
				{
					AddComponent(MustCallDestroyOnInstance.CreateInstance(obj));
				}
			}
			_ID = Level.EntityManager.AddEntity(this);
		}

		public T GetDefinition<T>() where T : EntityDefinition
		{
			return (T)_definition;
		}

		public override void Destroy()
		{
			while (_components.Count != 0)
			{
				_components[0].Destroy();
			}
			Level.EntityManager.RemoveEntity(this);
			base.Destroy();
		}

		public EntityComponent GetComponent(Type type)
		{
			for (int i = 0; i < _components.Count; i++)
			{
				EntityComponent entityComponent = _components[i];
				if (type.IsInstanceOfType(entityComponent))
				{
					return entityComponent;
				}
			}
			return null;
		}

		public EntityComponent GetComponent(int componentID)
		{
			for (int i = 0; i < _components.Count; i++)
			{
				EntityComponent entityComponent = _components[i];
				if (entityComponent.ID == componentID)
				{
					return entityComponent;
				}
			}
			return null;
		}

		public T GetComponent<T>() where T : EntityComponent
		{
			for (int i = 0; i < _components.Count; i++)
			{
				if (_components[i] is T result)
				{
					return result;
				}
			}
			return null;
		}

		public List<EntityComponent> GetComponents(Type type)
		{
			List<EntityComponent> list = new List<EntityComponent>();
			for (int i = 0; i < _components.Count; i++)
			{
				EntityComponent entityComponent = _components[i];
				if (type.IsInstanceOfType(entityComponent))
				{
					list.Add(entityComponent);
				}
			}
			return list;
		}

		public List<T> GetComponents<T>() where T : EntityComponent
		{
			List<T> list = new List<T>();
			for (int i = 0; i < _components.Count; i++)
			{
				if (_components[i] is T item)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public T AddComponent<T>() where T : EntityComponent
		{
			T val = MustCallDestroyOnInstance.CreateInstance<T>();
			AddComponent(val);
			return val;
		}

		public void AddComponent<T>(T component) where T : EntityComponent
		{
			int nextComponentID = _nextComponentID;
			_nextComponentID++;
			component.SetOwner(this, nextComponentID);
			_components.Add(component);
			if (component is EntityTickComponent item)
			{
				_tickComponents.Add(item);
				Level.EntityManager.AddTickableEntity(this);
			}
			if (_hasBeenInitialized)
			{
				component.InitializeComponent();
			}
		}

		public T GetOrAddComponent<T>() where T : EntityComponent
		{
			return GetComponent<T>() ?? AddComponent<T>();
		}

		public void RemoveComponents<T>() where T : EntityComponent
		{
			foreach (T component in GetComponents<T>())
			{
				if (!component.HasBeenDestroyed())
				{
					component.Destroy();
				}
			}
		}

		protected void InitializeComponents()
		{
			_hasBeenInitialized = true;
			for (int i = 0; i < _components.Count; i++)
			{
				EntityComponent entityComponent = _components[i];
				if (!entityComponent.HasBeenInitialized)
				{
					entityComponent.InitializeComponent();
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_hasBeenRestored = true;
			foreach (EntityComponent component in _components)
			{
				component.RestoreComponentFromSave();
			}
		}

		public virtual bool ShouldSave()
		{
			return true;
		}

		public virtual bool AutoDestroy()
		{
			return false;
		}

		public virtual void VerifyAfterLoad()
		{
		}

		internal void InternalRemoveComponent<T>(T component) where T : EntityComponent
		{
			if (!EntityComponent.CallRemove)
			{
				throw new InvalidOperationException("Illegal call to Entity.RemoveComponent, use EntityComponent.Destroy instead");
			}
			_components.Remove(component);
			if (component is EntityTickComponent item)
			{
				_tickComponents.Remove(item);
				if (_tickComponents.Count == 0)
				{
					Level.EntityManager.RemoveTickableEntity(this);
				}
			}
		}
	}
}
