using System.Collections.Generic;

namespace __Project__.Scripts.Managers
{
	public class ElectricalDeviceManager : NoktaSingleton<ElectricalDeviceManager>
	{
		private List<ElectricalDevice> m_ElectricalDevices;

		public List<ElectricalDevice> ElectricalDevices => null;

		private void Update()
		{
		}
	}
}
