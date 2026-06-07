using System;
using System.Runtime.CompilerServices;
using Noesis;

namespace NoesisApp
{
	[ContentProperty("Actions")]
	public abstract class TriggerBase : AttachableObject
	{
		public static readonly DependencyProperty ActionsProperty;

		public TriggerActionCollection Actions => null;

		public event PreviewInvokeEventHandler PreviewInvoke
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected TriggerBase(Type associatedType)
			: base(null)
		{
		}

		public new TriggerBase Clone()
		{
			return null;
		}

		public new TriggerBase CloneCurrentValue()
		{
			return null;
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		protected void InvokeActions(object parameter)
		{
		}
	}
	public abstract class TriggerBase<T> : TriggerBase where T : DependencyObject
	{
		protected new T AssociatedObject => null;

		protected TriggerBase()
			: base(null)
		{
		}
	}
}
