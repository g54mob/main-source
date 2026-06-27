using System;
using System.Collections.Generic;
using Restory.Data.PC;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class PcAppManagerSaveData
	{
		public List<PcAppInfo> InstalledApps { get; set; }

		public List<PcAppInfo> AvailableApps { get; set; }
	}
}
