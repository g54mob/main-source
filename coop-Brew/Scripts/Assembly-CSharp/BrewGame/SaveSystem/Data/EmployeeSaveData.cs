using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class EmployeeSaveData
	{
		public int slotIndex;

		public bool isHired;

		public bool hasQuit;

		public int assignedBarId;

		public int shiftStartHour;

		public int shiftEndHour;

		public float dailySalary;

		public int daysUnpaid;
	}
}
