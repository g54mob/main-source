using Noesis;

namespace NoesisApp
{
	public class EventTrigger : EventTriggerBase<object>
	{
		public static readonly DependencyProperty EventNameProperty;

		public string EventName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EventTrigger()
		{
		}

		public EventTrigger(string eventName)
		{
		}

		public new EventTrigger Clone()
		{
			return null;
		}

		public new EventTrigger CloneCurrentValue()
		{
			return null;
		}

		private static void OnEventNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected override string GetEventName()
		{
			return null;
		}
	}
}
