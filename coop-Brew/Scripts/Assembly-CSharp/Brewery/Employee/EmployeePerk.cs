using System;

namespace Brewery.Employee
{
	[Flags]
	public enum EmployeePerk : byte
	{
		None = 0,
		CarefulHandler = 1,
		NightOwl = 2,
		SpeedDemon = 4,
		QualityEye = 8,
		EagerWorker = 0x10,
		LoyalWorker = 0x20
	}
}
