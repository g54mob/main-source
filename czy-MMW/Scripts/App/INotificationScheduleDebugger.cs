using System;
using System.Collections.Generic;

public interface INotificationScheduleDebugger
{
	bool IsAvailable { get; }

	event OnMarkerAdded MarkerAdded;

	event OnMarkerTypeRemoved MarkerTypeRemoved;

	void AddDebugMarkersForTruePeriods(List<List<NotificationScheduler.DatePeriod>> truePeriodsForDescriptors, NotificationDescriptorDatabase descriptorDatabase);

	void AddMarker(NotificationScheduleDebuggerMarkerType markerType, DateTime dateTime, string text);

	void ClearMarkers();
}
