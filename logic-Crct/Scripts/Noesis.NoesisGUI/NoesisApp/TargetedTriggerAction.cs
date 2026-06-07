using System;
using Noesis;

namespace NoesisApp
{
	public abstract class TargetedTriggerAction : TriggerAction
	{
		public static readonly DependencyProperty TargetObjectProperty;

		public static readonly DependencyProperty TargetNameProperty;

		public static readonly DependencyProperty TargetNameResolverProperty;

		private Type _targetType;

		private IntPtr _target;

		private object _keepTarget;

		public object TargetObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TargetName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected object Target => null;

		public object TargetNameResolver => null;

		protected TargetedTriggerAction(Type targetType)
			: base(null)
		{
		}

		public new TargetedTriggerAction Clone()
		{
			return null;
		}

		public new TargetedTriggerAction CloneCurrentValue()
		{
			return null;
		}

		private static void OnTargetObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnTargetNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected virtual void OnTargetChangedImpl(object oldTarget, object newTarget)
		{
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		private void UpdateTarget(object associatedObject)
		{
		}

		private void RegisterTarget(object target)
		{
		}

		private void UnregisterTarget(object target)
		{
		}

		private void OnTargetDestroyed(IntPtr d)
		{
		}

		private static void OnTargetNameResolverChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}
	}
	public abstract class TargetedTriggerAction<T> : TargetedTriggerAction where T : class
	{
		protected new T Target => null;

		protected TargetedTriggerAction()
			: base(null)
		{
		}

		protected sealed override void OnTargetChangedImpl(object oldTarget, object newTarget)
		{
		}

		protected virtual void OnTargetChanged(T oldTarget, T newTarget)
		{
		}
	}
}
