namespace Novell.Directory.Ldap.Events.Edir
{
	public class EdirEventSpecifier
	{
		private EdirEventType event_type;

		private EdirEventResultType event_result_type;

		private string event_filter;

		public EdirEventType EventType
		{
			get
			{
				return event_type;
			}
		}

		public EdirEventResultType EventResultType
		{
			get
			{
				return event_result_type;
			}
		}

		public string EventFilter
		{
			get
			{
				return event_filter;
			}
		}

		public EdirEventSpecifier(EdirEventType eventType, EdirEventResultType eventResultType)
			: this(eventType, eventResultType, null)
		{
		}

		public EdirEventSpecifier(EdirEventType eventType, EdirEventResultType eventResultType, string filter)
		{
			event_type = eventType;
			event_result_type = eventResultType;
			event_filter = filter;
		}
	}
}
