using System;
using Bindito.Core;
using Timberborn.BaseComponentSystem;
using Timberborn.BlueprintSystem;
using Timberborn.SingletonSystem;
using Timberborn.TemplateInstantiation;
using UnityEngine;

namespace Timberborn.EntitySystem
{
	public class EntityService
	{
		private readonly TemplateInstantiator _templateInstantiator;

		private readonly IContainer _container;

		private readonly EntityRegistry _entityRegistry;

		private readonly EventBus _eventBus;

		public EntityService(TemplateInstantiator templateInstantiator, IContainer container, EntityRegistry entityRegistry, EventBus eventBus)
		{
			_templateInstantiator = templateInstantiator;
			_container = container;
			_entityRegistry = entityRegistry;
			_eventBus = eventBus;
		}

		public EntityComponent Instantiate(Blueprint template)
		{
			return Instantiate(template, Guid.NewGuid());
		}

		public EntityComponent Instantiate(Blueprint template, Guid id)
		{
			EntityComponent instance = _container.GetInstance<EntityComponent>();
			instance.SetEntityId(id);
			_templateInstantiator.Instantiate(template, null, instance);
			_entityRegistry.AddEntity(instance);
			_eventBus.Post(new EntityCreatedEvent(instance));
			return instance;
		}

		public void Delete(BaseComponent entity)
		{
			EntityComponent component = entity.GetComponent<EntityComponent>();
			component.Delete();
			_entityRegistry.RemoveEntity(component);
			UnityEngine.Object.Destroy(component.GameObject);
		}
	}
}
