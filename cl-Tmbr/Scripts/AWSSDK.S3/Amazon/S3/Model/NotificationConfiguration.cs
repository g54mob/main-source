using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public abstract class NotificationConfiguration
	{
		private List<EventType> _events = (AWSConfigs.InitializeCollections ? new List<EventType>() : null);

		private Filter filter;

		public List<EventType> Events
		{
			get
			{
				return _events;
			}
			set
			{
				_events = value;
			}
		}

		public Filter Filter
		{
			get
			{
				return filter;
			}
			set
			{
				filter = value;
			}
		}

		internal bool IsSetEvents()
		{
			if (_events != null)
			{
				if (_events.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetFilter()
		{
			return filter != null;
		}
	}
}
