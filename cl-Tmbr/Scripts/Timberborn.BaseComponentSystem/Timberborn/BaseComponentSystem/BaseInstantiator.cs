using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Bindito.Core;
using Bindito.Unity;
using Timberborn.BlueprintSystem;
using Timberborn.Common;
using UnityEngine;

namespace Timberborn.BaseComponentSystem
{
	public class BaseInstantiator
	{
		private readonly IInstantiator _instantiator;

		private readonly IContainer _container;

		private readonly ComponentCacheService _componentCacheService;

		private readonly Dictionary<string, TypeIndexMap> _typeMaps = new Dictionary<string, TypeIndexMap>();

		internal BaseInstantiator(IInstantiator instantiator, IContainer container, ComponentCacheService componentCacheService)
		{
			_instantiator = instantiator;
			_container = container;
			_componentCacheService = componentCacheService;
		}

		public GameObject InstantiateInactive(GameObject prefab, Transform parent, Blueprint blueprint, ImmutableArray<Type> decoratedComponents, BaseComponent initializingComponent, out List<object> instantiatedComponents)
		{
			bool wasActive;
			GameObject gameObject = _instantiator.InstantiateInactive(prefab, parent, out wasActive);
			ComponentCache componentCache = _instantiator.AddComponent<ComponentCache>(gameObject);
			instantiatedComponents = InstantiateComponents(blueprint, initializingComponent, decoratedComponents);
			instantiatedComponents.Add(componentCache);
			string text = ((initializingComponent == null) ? blueprint.Name : (blueprint.Name + "." + initializingComponent.GetType().Name));
			_instantiator.AddComponent<BaseComponentUnityAdapter>(gameObject);
			_instantiator.AddComponent<BaseComponentUpdateUnityAdapter>(gameObject);
			_instantiator.AddComponent<BaseComponentLateUpdateUnityAdapter>(gameObject);
			TypeIndexMap orAdd = _typeMaps.GetOrAdd(text);
			componentCache.Initialize(instantiatedComponents, text, orAdd);
			return gameObject;
		}

		private List<object> InstantiateComponents(Blueprint blueprint, BaseComponent initializingComponent, ImmutableArray<Type> decoratedComponents)
		{
			List<object> list = new List<object>(_componentCacheService.GetComponentsCount(blueprint.Name));
			if (initializingComponent != null)
			{
				list.Add(initializingComponent);
			}
			ImmutableArray<Type>.Enumerator enumerator = decoratedComponents.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Type current = enumerator.Current;
				object item = InstantiateComponent(blueprint, current);
				list.Add(item);
			}
			return list;
		}

		private object InstantiateComponent(Blueprint blueprint, Type type)
		{
			if (typeof(ComponentSpec).IsAssignableFrom(type))
			{
				return blueprint.GetSpec(type) ?? throw new InvalidOperationException("Blueprint " + blueprint.Name + " does not contain spec for component " + type.Name);
			}
			return _container.GetInstance(type);
		}
	}
}
