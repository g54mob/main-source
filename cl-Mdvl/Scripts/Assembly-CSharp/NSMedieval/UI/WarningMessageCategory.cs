using System;

namespace NSMedieval.UI
{
	[Serializable]
	public enum WarningMessageCategory
	{
		None = 0,
		Warning = 1,
		Notification = 2,
		Lesson = 3,
		Objective = 4,
		News = 5,
		WarningClosable = 6
	}
}
