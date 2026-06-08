using System.Collections.Generic;
using UnityEngine;

namespace LaundryBear
{
	[CreateAssetMenu(menuName = "Laundry Bear \ud83e\udd9d/Core/Create Services Asset")]
	public class ServicesList : ScriptableObject
	{
		[SerializeField]
		private GameObject[] m_services = new GameObject[0];

		private List<GameObject> m_runtimeCreatedObjects = new List<GameObject>();

		public GameObject[] GetServicesArray()
		{
			return m_services;
		}

		public IEnumerable<GameObject> GetRuntimeCreatedServices()
		{
			return m_runtimeCreatedObjects;
		}

		public void AddService(GameObject objectInstance)
		{
			GameObject[] array = new GameObject[m_services.Length + 1];
			m_services.CopyTo(array, 0);
			array[m_services.Length] = objectInstance;
			m_services = array;
		}

		public T AddService<T>() where T : Component, IService
		{
			GameObject gameObject = new GameObject(typeof(T).Name);
			T result = gameObject.AddComponent<T>();
			m_runtimeCreatedObjects.Add(gameObject);
			return result;
		}
	}
}
