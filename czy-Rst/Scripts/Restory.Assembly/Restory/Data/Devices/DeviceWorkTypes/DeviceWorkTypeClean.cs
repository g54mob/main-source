using System;
using Restory.Data.Elements.ElementTypes;

namespace Restory.Data.Devices.DeviceWorkTypes
{
	[Serializable]
	public class DeviceWorkTypeClean : DeviceWorkType
	{
		public DirtType DirtType;
	}
}
