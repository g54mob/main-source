using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaundryBear
{
	public class ServiceLocator : Singleton<ServiceLocator>, IService
	{
		public enum ServiceInitializationStatus
		{
			Uninitialized = 0,
			Initializing = 1,
			Ready = 2,
			Failed = 3
		}

		public delegate void OnManagersInitialized();

		private readonly int m_prefabCopyNameSuffixLength = 7;

		[SerializeField]
		private ServicesList m_services;

		private ServicesList m_servicesInstance;

		private List<IService> m_runtimeServices;

		public string Name => "Service Locator";

		public ServiceInitializationStatus InitializationStatus { get; private set; }

		public static ServiceInitializationStatus IsInitialized => Singleton<ServiceLocator>.Instance.InitializationStatus;

		private ServicesList Services
		{
			get
			{
				if (null == m_servicesInstance)
				{
					if (null != m_services)
					{
						m_servicesInstance = UnityEngine.Object.Instantiate(m_services);
					}
					else
					{
						m_servicesInstance = ScriptableObject.CreateInstance<ServicesList>();
					}
				}
				return m_servicesInstance;
			}
		}

		public static event OnManagersInitialized ManagersInitializedEvent;

		protected override void Awake()
		{
			base.Awake();
			if (Singleton<ServiceLocator>.HasInstance)
			{
				_ = this != Singleton<ServiceLocator>.Instance;
			}
		}

		public IEnumerator Initialize(bool sync = false)
		{
			List<IService> list = new List<IService>();
			GameObject[] servicesArray = Services.GetServicesArray();
			for (int i = 0; i < servicesArray.Length; i++)
			{
				IService[] collection = InstantiateServicePrefab(servicesArray[i]);
				list.AddRange(collection);
			}
			foreach (GameObject runtimeCreatedService in Services.GetRuntimeCreatedServices())
			{
				SetupServiceParent(runtimeCreatedService);
				list.AddRange(runtimeCreatedService.GetComponentsInChildren<IService>());
			}
			return InitializeManagersCoroutine(list, sync);
		}

		public IEnumerator InitializeSync()
		{
			List<IService> list = new List<IService>();
			if ((bool)Services)
			{
				GameObject[] servicesArray = Services.GetServicesArray();
				for (int i = 0; i < servicesArray.Length; i++)
				{
					IService[] collection = InstantiateServicePrefab(servicesArray[i]);
					list.AddRange(collection);
				}
				foreach (GameObject runtimeCreatedService in Services.GetRuntimeCreatedServices())
				{
					SetupServiceParent(runtimeCreatedService);
					list.AddRange(runtimeCreatedService.GetComponentsInChildren<IService>());
				}
			}
			foreach (GameObject runtimeCreatedService2 in Services.GetRuntimeCreatedServices())
			{
				SetupServiceParent(runtimeCreatedService2);
				list.AddRange(runtimeCreatedService2.GetComponentsInChildren<IService>());
			}
			return InitializeManagersCoroutine(list, forceSync: true);
		}

		private IEnumerator InitializeManagersCoroutine(List<IService> services, bool forceSync)
		{
			Coroutine[] coroutines = new Coroutine[services.Count];
			IEnumerator[] enumerators = new IEnumerator[services.Count];
			for (int i = 0; i < services.Count; i++)
			{
				enumerators[i] = services[i].Initialize(forceSync);
				if (!forceSync)
				{
					coroutines[i] = StartCoroutine(enumerators[i]);
				}
			}
			int serviceIndex = 0;
			while (serviceIndex < services.Count)
			{
				if (forceSync)
				{
					while (enumerators[serviceIndex].MoveNext())
					{
					}
				}
				else
				{
					yield return coroutines[serviceIndex];
				}
				Debug.Log("Service " + services[serviceIndex].Name + " completed initialization with status " + services[serviceIndex].InitializationStatus.ToString() + ".");
				int num = serviceIndex + 1;
				serviceIndex = num;
			}
			serviceIndex = 0;
			while (serviceIndex < services.Count)
			{
				if (ServiceInitializationStatus.Initializing == services[serviceIndex].InitializationStatus)
				{
					yield return null;
				}
				int num = serviceIndex + 1;
				serviceIndex = num;
			}
			InitializationStatus = ServiceInitializationStatus.Ready;
			m_runtimeServices = services;
			OnInitializationComplete();
			ServiceLocator.ManagersInitializedEvent?.Invoke();
		}

		protected virtual void OnInitializationComplete()
		{
		}

		private IService[] InstantiateServicePrefab(GameObject prefab)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
			SetupServiceParent(gameObject);
			return gameObject.GetComponentsInChildren<IService>();
		}

		private void SetupServiceParent(GameObject serviceObject)
		{
			if (serviceObject.name.EndsWith("(Clone)", StringComparison.InvariantCultureIgnoreCase))
			{
				serviceObject.name = serviceObject.name.Substring(0, serviceObject.name.Length - m_prefabCopyNameSuffixLength);
			}
			serviceObject.transform.SetParent(base.transform);
		}

		public T AddService<T>(out IEnumerator enumerator) where T : MonoBehaviour, IService
		{
			if (InitializationStatus != ServiceInitializationStatus.Uninitialized)
			{
				GameObject obj = new GameObject(typeof(T).Name);
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				T val = obj.AddComponent<T>();
				m_runtimeServices.Add(val);
				enumerator = val.Initialize();
				return val;
			}
			T result = Services.AddService<T>();
			enumerator = null;
			return result;
		}

		public bool AddServicesGameObject(GameObject prefab, out IEnumerator[] enumerators)
		{
			if (InitializationStatus != ServiceInitializationStatus.Uninitialized)
			{
				GameObject obj = UnityEngine.Object.Instantiate(prefab);
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				IService[] componentsInChildren = obj.GetComponentsInChildren<IService>();
				enumerators = new IEnumerator[componentsInChildren.Length];
				m_runtimeServices.AddRange(componentsInChildren);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					enumerators[i] = componentsInChildren[i].Initialize();
				}
				return true;
			}
			Services.AddService(prefab);
			enumerators = null;
			return false;
		}

		[Obsolete("GetService has been deprecated. Use TryGetService instead which has no allocations.")]
		public static T GetService<T>()
		{
			return Singleton<ServiceLocator>.sm_instance.GetComponentInChildren<T>();
		}

		[Obsolete("GetServices has been deprecated. Use TryGetServices instead which has no allocations.")]
		public static T[] GetServices<T>()
		{
			return Singleton<ServiceLocator>.sm_instance.GetComponentsInChildren<T>();
		}

		public static T GetServiceOrThrow<T>()
		{
			if (!TryGetService<T>(out var service))
			{
				throw new Exception("Could not find service of type T");
			}
			return service;
		}

		public static bool TryGetService<T>(out T service)
		{
			for (int i = 0; i < Singleton<ServiceLocator>.sm_instance.m_runtimeServices.Count; i++)
			{
				if (Singleton<ServiceLocator>.sm_instance.m_runtimeServices[i] is T)
				{
					service = (T)Singleton<ServiceLocator>.sm_instance.m_runtimeServices[i];
					return true;
				}
			}
			service = default(T);
			return false;
		}

		public static int TryGetServices<T>(T[] services)
		{
			int num = 0;
			for (int i = 0; i < Singleton<ServiceLocator>.sm_instance.m_runtimeServices.Count; i++)
			{
				if (Singleton<ServiceLocator>.sm_instance.m_runtimeServices[i] is T)
				{
					services[num++] = (T)Singleton<ServiceLocator>.sm_instance.m_runtimeServices[i];
				}
				if (num == services.Length)
				{
					break;
				}
			}
			return num;
		}

		public static void ExecuteOnServices<T>(Action<T> executor)
		{
			T[] componentsInChildren = Singleton<ServiceLocator>.Instance.GetComponentsInChildren<T>();
			foreach (T obj in componentsInChildren)
			{
				executor(obj);
			}
		}

		public static IEnumerator[] ReloadService<T>() where T : MonoBehaviour, IService
		{
			Singleton<ServiceLocator>.sm_instance.m_runtimeServices.RemoveAll(delegate(IService service)
			{
				if (service is T)
				{
					UnityEngine.Object.Destroy((service as T).gameObject);
					return true;
				}
				return false;
			});
			GameObject[] servicesArray = Singleton<ServiceLocator>.sm_instance.Services.GetServicesArray();
			foreach (GameObject gameObject in servicesArray)
			{
				if (gameObject.TryGetComponent<T>(out var _))
				{
					Singleton<ServiceLocator>.Instance.AddServicesGameObject(gameObject, out var enumerators);
					return enumerators;
				}
			}
			return null;
		}
	}
}
