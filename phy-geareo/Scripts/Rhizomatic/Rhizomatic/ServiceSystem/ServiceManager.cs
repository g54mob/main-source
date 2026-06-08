using UnityEngine;

namespace Rhizomatic.ServiceSystem
{
	public class ServiceManager : MonoBehaviour
	{
		public ServiceManagerConfig config;

		public static ServiceManager instance { get; private set; }

		private void Awake()
		{
		}

		public T GetService<T>() where T : Service
		{
			return null;
		}

		public bool HasService<T>() where T : Service
		{
			return false;
		}
	}
}
