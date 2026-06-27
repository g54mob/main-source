using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Gameplay.Equipment.Ultrasonic;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class UltrasonicSaveData
	{
		public UltrasonicToolInfo ActiveTool { get; set; }

		public List<InsertedElementData> InsertedElements { get; set; }

		public SonicBathTimerData TimerData { get; set; }

		public bool IsCleaningDone { get; set; }
	}
}
