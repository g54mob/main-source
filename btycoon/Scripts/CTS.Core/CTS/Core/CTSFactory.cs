using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS.Core
{
	public static class CTSFactory
	{
		private readonly struct OrderedBehaviour : IComparable<OrderedBehaviour>
		{
			private readonly int _order;

			public readonly CTSBehaviour Behaviour;

			public OrderedBehaviour(int order, CTSBehaviour behaviour)
			{
				_order = order;
				Behaviour = behaviour;
			}

			public int CompareTo(OrderedBehaviour other)
			{
				if (_order > other._order)
				{
					return 1;
				}
				if (_order < other._order)
				{
					return -1;
				}
				return 0;
			}
		}

		internal static readonly Dictionary<Type, TypeInjector> Resolvers = new Dictionary<Type, TypeInjector>();

		private static readonly List<int> _scenesHandled = new List<int>();

		private static readonly List<OrderedBehaviour> _constructionNeeded = new List<OrderedBehaviour>();

		private static readonly List<OrderedBehaviour> _awakeNeeded = new List<OrderedBehaviour>();

		private static Transform _factoryRoot;

		private static bool ConstructionInProgress => _constructionNeeded.Count > 0;

		private static bool AwakeningInProgress => _awakeNeeded.Count > 0;

		private static Transform FactoryRoot
		{
			get
			{
				if ((bool)_factoryRoot)
				{
					return _factoryRoot;
				}
				_factoryRoot = new GameObject("CTSFactory").transform;
				_factoryRoot.gameObject.SetActive(value: false);
				return _factoryRoot;
			}
		}

		internal static event Action CurrentConstructionFinished;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialization()
		{
			_constructionNeeded.Clear();
			_scenesHandled.Clear();
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}

		private static void OnSceneUnloaded(Scene scene)
		{
			Debug.Log("Scene unloaded !");
			_scenesHandled.Remove(scene.handle);
		}

		internal static void Construct(CTSBehaviour behaviour)
		{
			if (!behaviour.Constructed)
			{
				if (Application.isPlaying && !_scenesHandled.Contains(behaviour.gameObject.scene.handle))
				{
					ConstructScene(behaviour.gameObject.scene);
				}
				else
				{
					ConstructBehaviour(behaviour);
				}
			}
		}

		private static void ConstructBehaviour(CTSBehaviour behaviour)
		{
			bool constructionInProgress = ConstructionInProgress;
			CreateResolver(behaviour);
			SortQueue();
			if (!constructionInProgress)
			{
				RunConstructors();
			}
		}

		private static void ConstructObject(GameObject obj)
		{
			bool constructionInProgress = ConstructionInProgress;
			CTSBehaviour[] componentsInChildren = obj.GetComponentsInChildren<CTSBehaviour>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				CreateResolver(componentsInChildren[i]);
			}
			SortQueue();
			if (!constructionInProgress)
			{
				RunConstructors();
			}
		}

		private static void ConstructScene(Scene scene)
		{
			if (_scenesHandled.Contains(scene.handle))
			{
				return;
			}
			_scenesHandled.Add(scene.handle);
			GameObject[] rootGameObjects = scene.GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				CTSBehaviour[] componentsInChildren = rootGameObjects[i].GetComponentsInChildren<CTSBehaviour>(includeInactive: true);
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					CreateResolver(componentsInChildren[j]);
				}
			}
			SortQueue();
			RunConstructors();
		}

		private static void RunConstructors()
		{
			bool awakeningInProgress = AwakeningInProgress;
			while (_constructionNeeded.Count > 0)
			{
				CTSBehaviour behaviour = _constructionNeeded[0].Behaviour;
				_constructionNeeded.RemoveAt(0);
				Type type = behaviour.GetType();
				TypeInjector typeInjector = Resolvers[type];
				typeInjector.Construct(behaviour);
				_awakeNeeded.Add(new OrderedBehaviour(typeInjector.ExecutionOrder, behaviour));
			}
			_awakeNeeded.Sort();
			if (!awakeningInProgress)
			{
				RunAwake();
			}
		}

		private static void RunAwake()
		{
			foreach (OrderedBehaviour item in _awakeNeeded)
			{
				CTSBehaviour behaviour = item.Behaviour;
				Type type = behaviour.GetType();
				Resolvers[type].InjectFields(behaviour);
			}
			while (_awakeNeeded.Count > 0)
			{
				CTSBehaviour behaviour2 = _awakeNeeded[0].Behaviour;
				_awakeNeeded.RemoveAt(0);
				if (behaviour2.gameObject.activeInHierarchy)
				{
					behaviour2.Awake();
				}
			}
			CTSFactory.CurrentConstructionFinished?.Invoke();
			CTSFactory.CurrentConstructionFinished = null;
		}

		internal static TypeInjector GetOrCreateInjector(Type type)
		{
			if (!Resolvers.TryGetValue(type, out var value))
			{
				value = new TypeInjector(type);
				Resolvers.Add(type, value);
			}
			return value;
		}

		private static void CreateResolver(CTSBehaviour behaviour)
		{
			TypeInjector orCreateInjector = GetOrCreateInjector(behaviour.GetType());
			_constructionNeeded.Add(new OrderedBehaviour(orCreateInjector.ExecutionOrder, behaviour));
		}

		private static void SortQueue()
		{
			_constructionNeeded.Sort();
		}

		public static TComponent AddCTSComponent<TComponent>(this GameObject gameObject) where TComponent : CTSBehaviour
		{
			bool activeInHierarchy = gameObject.activeInHierarchy;
			TComponent val = gameObject.AddComponent<TComponent>();
			if (!activeInHierarchy)
			{
				ConstructBehaviour(val);
			}
			return val;
		}

		public static TComponent AddCTSComponent<TComponent>(this Component component) where TComponent : CTSBehaviour
		{
			return component.gameObject.AddCTSComponent<TComponent>();
		}

		private static GameObject GetInactiveInstance(GameObject original, Transform parent)
		{
			if ((bool)parent)
			{
				FactoryRoot.SetParent(parent, worldPositionStays: false);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(original, FactoryRoot);
			Construct(gameObject, parent);
			return gameObject;
		}

		private static TComponent GetInactiveInstance<TComponent>(TComponent original, Transform parent, IConstructor<TComponent> constructor) where TComponent : Component
		{
			if ((bool)parent)
			{
				FactoryRoot.SetParent(parent, worldPositionStays: false);
			}
			TComponent val = UnityEngine.Object.Instantiate(original, FactoryRoot);
			constructor?.Construct(val);
			Construct(val.gameObject, parent);
			return val;
		}

		private static Component GetInactiveInstance(Component original, Transform parent, IConstructor<Component> constructor)
		{
			if ((bool)parent)
			{
				FactoryRoot.SetParent(parent, worldPositionStays: false);
			}
			Component component = UnityEngine.Object.Instantiate(original, FactoryRoot);
			constructor?.Construct(component);
			Construct(component.gameObject, parent);
			return component;
		}

		private static void Construct(GameObject instance, Transform parent)
		{
			instance.gameObject.SetActive(value: false);
			instance.transform.SetParent(parent, worldPositionStays: false);
			FactoryRoot.SetParent(null, worldPositionStays: false);
			ConstructObject(instance);
		}

		public static GameObject Instantiate(GameObject original)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, null);
			inactiveInstance.SetActive(original.activeSelf);
			return inactiveInstance;
		}

		public static GameObject Instantiate(GameObject original, bool activeState)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, null);
			if (activeState)
			{
				inactiveInstance.SetActive(value: true);
			}
			return inactiveInstance;
		}

		public static GameObject Instantiate(GameObject original, Transform parent)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, parent);
			inactiveInstance.transform.SetLocalPositionAndRotation(original.transform.localPosition, original.transform.localRotation);
			inactiveInstance.SetActive(original.activeSelf);
			return inactiveInstance;
		}

		public static GameObject Instantiate(GameObject original, Transform parent, bool instantiateInWorldSpace = false, bool? activeState = null)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, parent);
			if (instantiateInWorldSpace)
			{
				inactiveInstance.transform.SetPositionAndRotation(original.transform.localPosition, original.transform.localRotation);
			}
			else
			{
				inactiveInstance.transform.SetLocalPositionAndRotation(original.transform.localPosition, original.transform.localRotation);
			}
			inactiveInstance.SetActive(activeState ?? original.activeSelf);
			return inactiveInstance;
		}

		public static GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, null);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.SetActive(original.activeSelf);
			return inactiveInstance;
		}

		public static GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation, bool activeState)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, null);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.SetActive(activeState);
			return inactiveInstance;
		}

		public static GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, parent);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.SetActive(original.activeSelf);
			return inactiveInstance;
		}

		public static GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation, Transform parent, bool activeState)
		{
			if (original == null)
			{
				return null;
			}
			GameObject inactiveInstance = GetInactiveInstance(original, parent);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.SetActive(activeState);
			return inactiveInstance;
		}

		public static TComponent Instantiate<TComponent>(TComponent original, bool? activeState = null, IConstructor<TComponent> constructor = null) where TComponent : Component
		{
			if (original == null)
			{
				return null;
			}
			TComponent inactiveInstance = GetInactiveInstance(original, null, constructor);
			inactiveInstance.gameObject.SetActive(activeState ?? original.gameObject.activeSelf);
			return inactiveInstance;
		}

		public static Component Instantiate(Component original, bool? activeState = null, IConstructor<Component> constructor = null)
		{
			if (original == null)
			{
				return null;
			}
			Component inactiveInstance = GetInactiveInstance(original, null, constructor);
			inactiveInstance.gameObject.SetActive(activeState ?? original.gameObject.activeSelf);
			return inactiveInstance;
		}

		public static TComponent Instantiate<TComponent>(TComponent original, Transform parent) where TComponent : Component
		{
			return (TComponent)InstantiateComponent(original, parent);
		}

		public static Component Instantiate(Component original, Transform parent)
		{
			return InstantiateComponent(original, parent);
		}

		private static Component InstantiateComponent(Component original, Transform parent)
		{
			if (original == null)
			{
				return null;
			}
			Component inactiveInstance = GetInactiveInstance(original, parent, null);
			inactiveInstance.transform.SetLocalPositionAndRotation(original.transform.localPosition, original.transform.localRotation);
			return inactiveInstance;
		}

		public static TComponent Instantiate<TComponent>(TComponent original, Transform parent, bool instantiateInWorldSpace = false, bool? activeState = null, IConstructor<TComponent> constructor = null) where TComponent : Component
		{
			if (original == null)
			{
				return null;
			}
			return (TComponent)Setup(GetInactiveInstance(original, parent, constructor), original, instantiateInWorldSpace, activeState);
		}

		public static Component Instantiate(Component original, Transform parent, bool instantiateInWorldSpace = false, bool? activeState = null, IConstructor<Component> constructor = null)
		{
			if (original == null)
			{
				return null;
			}
			return Setup(GetInactiveInstance(original, parent, constructor), original, instantiateInWorldSpace, activeState);
		}

		private static Component Setup(Component instance, Component original, bool instantiateInWorldSpace, bool? activeState)
		{
			Transform transform = original.transform;
			if (instantiateInWorldSpace)
			{
				instance.transform.SetPositionAndRotation(transform.localPosition, transform.localRotation);
			}
			else
			{
				instance.transform.SetLocalPositionAndRotation(transform.localPosition, transform.localRotation);
			}
			instance.gameObject.SetActive(activeState ?? original.gameObject.activeSelf);
			return instance;
		}

		public static TComponent Instantiate<TComponent>(TComponent original, Vector3 position, Quaternion rotation, bool? activeState = null, IConstructor<TComponent> constructor = null) where TComponent : Component
		{
			if (original == null)
			{
				return null;
			}
			TComponent inactiveInstance = GetInactiveInstance(original, null, constructor);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.gameObject.SetActive(activeState ?? original.gameObject.activeSelf);
			return inactiveInstance;
		}

		public static Component Instantiate(Component original, Vector3 position, Quaternion rotation, bool? activeState = null, IConstructor<Component> constructor = null)
		{
			if (original == null)
			{
				return null;
			}
			Component inactiveInstance = GetInactiveInstance(original, null, constructor);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.gameObject.SetActive(activeState ?? original.gameObject.activeSelf);
			return inactiveInstance;
		}

		public static TComponent Instantiate<TComponent>(TComponent original, Vector3 position, Quaternion rotation, Transform parent, bool? activeState = null, IConstructor<TComponent> constructor = null) where TComponent : Component
		{
			if (original == null)
			{
				return null;
			}
			TComponent inactiveInstance = GetInactiveInstance(original, parent, constructor);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.gameObject.SetActive(activeState ?? original.gameObject.activeSelf);
			return inactiveInstance;
		}

		public static Component Instantiate(Component original, Vector3 position, Quaternion rotation, Transform parent, bool? activeState = null, IConstructor<Component> constructor = null)
		{
			if (original == null)
			{
				return null;
			}
			Component inactiveInstance = GetInactiveInstance(original, parent, constructor);
			inactiveInstance.transform.SetPositionAndRotation(position, rotation);
			inactiveInstance.gameObject.SetActive(activeState ?? original.gameObject.activeSelf);
			return inactiveInstance;
		}
	}
}
