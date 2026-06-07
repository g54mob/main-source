using System;
using System.Collections.Generic;

public class NotificationScheduleDebugger : INotificationScheduleDebugger
{
	public bool IsAvailable => true;

	public event OnMarkerAdded MarkerAdded;

	public event OnMarkerTypeRemoved MarkerTypeRemoved;

	public void AddDebugMarkersForTruePeriods(List<List<NotificationScheduler.DatePeriod>> truePeriodsForDescriptors, NotificationDescriptorDatabase descriptorDatabase)
	{
		for (int i = 0; i < truePeriodsForDescriptors.Count; i++)
		{
			NotificationDescriptor notificationDescriptor = descriptorDatabase.gameNotifications[i];
			foreach (NotificationScheduler.DatePeriod item in truePeriodsForDescriptors[i])
			{
				AddMarker(NotificationScheduleDebuggerMarkerType.DescriptorConditionsTrueStart, item.startDate, notificationDescriptor.Id ?? "");
				if (item.endDate.HasValue)
				{
					AddMarker(NotificationScheduleDebuggerMarkerType.DescriptorConditionsTrueEnd, item.endDate.Value, notificationDescriptor.Id ?? "");
				}
			}
		}
		for (int j = 0; j < truePeriodsForDescriptors.Count; j++)
		{
			NotificationDescriptor notificationDescriptor2 = descriptorDatabase.gameNotifications[j];
			foreach (NotificationScheduler.DatePeriod item2 in truePeriodsForDescriptors[j])
			{
				AddMarker(NotificationScheduleDebuggerMarkerType.ScheduledNotification, item2.startDate, notificationDescriptor2.Id ?? "");
			}
		}
	}

	public void AddMarker(NotificationScheduleDebuggerMarkerType markerType, DateTime dateTime, string text)
	{
		this.MarkerAdded?.Invoke(markerType, dateTime, text);
	}

	public void ClearMarkers()
	{
		RemoveEventsWithType(NotificationScheduleDebuggerMarkerType.DescriptorConditionsTrue);
		RemoveEventsWithType(NotificationScheduleDebuggerMarkerType.DescriptorConditionsTrueStart);
		RemoveEventsWithType(NotificationScheduleDebuggerMarkerType.DescriptorConditionsTrueEnd);
		RemoveEventsWithType(NotificationScheduleDebuggerMarkerType.ScheduledNotification);
	}

	private void RemoveEventsWithType(NotificationScheduleDebuggerMarkerType type)
	{
		this.MarkerTypeRemoved?.Invoke(type);
	}
}
