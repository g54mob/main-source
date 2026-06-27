using System;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class EquipmentSaveData
	{
		public bool IsCleanerActivated { get; set; }

		public bool IsNotebookActivated { get; set; }

		public bool IsCashRegisterActivated { get; set; }
	}
}
