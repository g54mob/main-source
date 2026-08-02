using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.ServiceSystem
{
	[CreateAssetMenu(fileName = "ServiceManager", menuName = "ServiceSystem/ServiceManagerConfig")]
	public class ServiceManagerConfig : ScriptableObject
	{
		public List<Service> services;

		public T GetService<T>() where T : Service
		{
			return null;
		}

		public bool HasService<T>() where T : Service
		{
			return false;
		}

		public void Init()
		{
		}
	}
}
