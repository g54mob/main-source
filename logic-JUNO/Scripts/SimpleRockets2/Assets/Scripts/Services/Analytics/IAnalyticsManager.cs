using System.Collections.Generic;

namespace Assets.Scripts.Services.Analytics
{
	public interface IAnalyticsManager
	{
		bool Enabled { get; }

		bool Initialized { get; }

		SceneTimeTracker SceneTimeTracker { get; }

		void LogEvent(string eventName, Dictionary<string, object> eventData);
	}
}
