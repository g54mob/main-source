using System;
using System.Collections.Generic;
using DV.Utils;

namespace DV.Customization.Gadgets.Implementations
{
	public class ProximitySensorNetwork : SingletonBehaviour<ProximitySensorNetwork>
	{
		public readonly List<ProximitySensor> active = new List<ProximitySensor>();

		public event Action<ProximitySensor> SensorSettingsChanged;

		public new static string AllowAutoCreate()
		{
			return "[proximity sensor network]";
		}

		internal void RaiseSensorSettingsChanged(ProximitySensor sensor)
		{
			this.SensorSettingsChanged?.Invoke(sensor);
		}
	}
}
