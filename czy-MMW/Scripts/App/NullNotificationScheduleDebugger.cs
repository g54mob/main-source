using System;
using System.Collections.Generic;

public class NullNotificationScheduleDebugger : INotificationScheduleDebugger
{
	public bool IsAvailable => false;

	public event OnMarkerAdded MarkerAdded
	{
		add
		{
		}
		remove
		{
		}
	}

	public event OnMarkerTypeRemoved MarkerTypeRemoved
	{
		add
		{
		}
		remove
		{
		}
	}

	public void AddDebugMarkersForTruePeriods(List<List<NotificationScheduler.DatePeriod>> truePeriodsForDescriptors, NotificationDescriptorDatabase descriptorDatabase)
	{
	}

	public void AddMarker(NotificationScheduleDebuggerMarkerType markerType, DateTime dateTime, string text)
	{
	}

	public void ClearMarkers()
	{
	}
}
