namespace Plugins.Analytics
{
	public class AnalyticsTypes
	{
		public enum EventType
		{
			SessionStart = 0,
			SessionEnd = 1,
			LevelStart = 2,
			LevelEnd = 3,
			TutorialEnd = 4,
			ScreenInteraction = 5
		}

		public enum DataType
		{
			Timestamp = 0,
			TutorialEndReason = 1,
			TutorialDuration = 2,
			LevelID = 3,
			GameMode = 4,
			LevelEndReason = 5,
			PlayerScore = 6,
			LevelEndState = 7,
			UIItemId = 8
		}

		private JSON.Dictionary _eventTypes;

		private JSON.Dictionary _dataTypes;

		private readonly string _eventTypeFile = "Analytics\\AnalyticsEventTypeNames";

		private readonly string _dataTypeFile = "Analytics\\AnalyticsDataTypeNames";

		public AnalyticsTypes()
		{
			_dataTypes = (JSON.Dictionary)JSON.Load(_dataTypeFile);
			_eventTypes = (JSON.Dictionary)JSON.Load(_eventTypeFile);
		}

		public string GetDataString(DataType dataType)
		{
			return _dataTypes.GetString(dataType.ToString());
		}

		public string GetEventString(EventType eventType)
		{
			return _eventTypes.GetString(eventType.ToString());
		}
	}
}
