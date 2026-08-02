using UnityEngine;

namespace Rhizomatic.ServiceSystem
{
	public class Service : ScriptableObject
	{
		public ServiceManagerConfig serviceManager { get; private set; }

		public void _Init(ServiceManagerConfig serviceManager)
		{
		}

		protected virtual void Init()
		{
		}
	}
}
