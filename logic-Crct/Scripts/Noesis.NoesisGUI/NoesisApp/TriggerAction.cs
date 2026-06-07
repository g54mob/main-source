using System;
using Noesis;

namespace NoesisApp
{
	public abstract class TriggerAction : AttachableObject
	{
		public static readonly DependencyProperty IsEnabledProperty;

		public bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected TriggerAction(Type associatedType)
			: base(null)
		{
		}

		public new TriggerAction Clone()
		{
			return null;
		}

		public new TriggerAction CloneCurrentValue()
		{
			return null;
		}

		public void CallInvoke(object parameter)
		{
		}

		protected abstract void Invoke(object parameter);
	}
	public abstract class TriggerAction<T> : TriggerAction where T : DependencyObject
	{
		protected new T AssociatedObject => null;

		protected TriggerAction()
			: base(null)
		{
		}
	}
}
