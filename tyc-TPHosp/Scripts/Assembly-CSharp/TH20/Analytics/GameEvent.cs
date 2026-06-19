using System;
using System.Collections.Generic;

namespace TH20.Analytics
{
	public class GameEvent<T> where T : GameEvent<T>
	{
		public readonly bool IsEnabled;

		private readonly EventParameters _parameters = new EventParameters();

		protected GameEvent(string name, int eventID, int eventRevision, int titleID, bool isEnabled)
		{
			IsEnabled = isEnabled;
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Name cannot be null or empty");
			}
			_parameters.AddParam("eventID", $"{titleID}.{eventID}.{eventRevision}");
			_parameters.AddParam("eventName", name);
			_parameters.AddParam("eventTimestampClient", DateTime.UtcNow.ToString("o"));
		}

		public T AddParam(string key, object value)
		{
			_parameters.AddParam(key, value);
			return (T)this;
		}

		public Dictionary<string, object> AsDictionary()
		{
			return _parameters.AsDictionary();
		}
	}
	public class GameEvent : GameEvent<GameEvent>
	{
		public GameEvent(GameEventInfo gameEventInfo, int titleID = 7)
			: base(gameEventInfo.Name, gameEventInfo.EventID, gameEventInfo.EventRevision, titleID, gameEventInfo.Enabled)
		{
		}
	}
}
