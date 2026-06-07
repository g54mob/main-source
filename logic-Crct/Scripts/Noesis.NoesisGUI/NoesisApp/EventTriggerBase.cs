using System;
using System.Reflection;
using Noesis;

namespace NoesisApp
{
	public abstract class EventTriggerBase : TriggerBase
	{
		public static readonly DependencyProperty SourceObjectProperty;

		public static readonly DependencyProperty SourceNameProperty;

		public static readonly DependencyProperty SourceNameResolverProperty;

		public static readonly MethodInfo OnEventMethod;

		private Type _sourceType;

		private IntPtr _source;

		private object _keepSource;

		private Delegate _handler;

		private EventInfo _event;

		public object SourceObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SourceName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected object Source => null;

		public object SourceNameResolver => null;

		protected EventTriggerBase(Type sourceType)
			: base(null)
		{
		}

		public new EventTriggerBase Clone()
		{
			return null;
		}

		public new EventTriggerBase CloneCurrentValue()
		{
			return null;
		}

		private static void OnSourceObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnSourceNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected virtual void OnSourceChangedImpl(object oldSource, object newSource)
		{
		}

		protected abstract string GetEventName();

		protected virtual void OnEventNameChanged(string oldName, string newName)
		{
		}

		protected virtual void OnEvent(object parameter)
		{
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		private void UpdateSource(object associatedObject)
		{
		}

		private void RegisterEvent(object source, string eventName)
		{
		}

		private void UnregisterEvent(object source)
		{
		}

		private void OnEventImpl(object sender, Noesis.EventArgs eventArgs)
		{
		}

		private static bool IsValidEvent(EventInfo eventInfo)
		{
			return false;
		}

		private void RegisterSource(object source)
		{
		}

		private void UnregisterSource(object source)
		{
		}

		private void OnSourceDestroyed(IntPtr d)
		{
		}

		private static void OnSourceNameResolverChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}
	}
	public abstract class EventTriggerBase<T> : EventTriggerBase where T : class
	{
		protected new T Source => null;

		protected EventTriggerBase()
			: base(null)
		{
		}

		protected sealed override void OnSourceChangedImpl(object oldSource, object newSource)
		{
		}

		protected virtual void OnSourceChanged(T oldSource, T newSource)
		{
		}
	}
}
