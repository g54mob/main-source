using System;

namespace NotificationService.Conditions
{
	[Serializable]
	public enum Comparator
	{
		Equals = 0,
		LessThan = 1,
		LessThanOrEqual = 2,
		GreaterThan = 3,
		GreaterThanOrEqual = 4
	}
}
