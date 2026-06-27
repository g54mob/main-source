using System;
using Restory.Data.WorkshopStatus;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class WorkshopStatusServiceSaveData
	{
		public StatusInfo[] Statuses { get; set; }
	}
}
