using System;
using System.Reflection;
using Noesis;
using NoesisApp;

namespace NoesisGUIExtensions
{
	public class DataEventTrigger : TriggerBase<FrameworkElement>
	{
		public static readonly DependencyProperty SourceProperty;

		public static readonly DependencyProperty EventNameProperty;

		private EventInfo currentEvent;

		private Delegate currentDelegate;

		private object currentTarget;

		public object Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		private static void OnSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnEventNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
		}

		private void UpdateHandler()
		{
		}

		private Delegate GetDelegate(EventInfo eventInfo, Action action)
		{
			return null;
		}

		private void OnMethod()
		{
		}

		private void OnEvent(object sender, System.EventArgs e)
		{
		}
	}
}
