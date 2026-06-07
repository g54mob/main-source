using System;
using Noesis;

namespace NoesisApp
{
	public abstract class AttachableObject : Animatable, IAttachedObject
	{
		private static readonly DependencyProperty AttachmentProperty;

		private const Visibility Detached = (Visibility)(-1);

		private Type _associatedType;

		private IntPtr _associatedObject;

		private IntPtr _view;

		protected Type AssociatedType => null;

		protected DependencyObject AssociatedObject => null;

		DependencyObject IAttachedObject.AssociatedObject => null;

		public View View => null;

		protected AttachableObject(Type associatedType)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public void Attach(DependencyObject associatedObject)
		{
		}

		public void Detach()
		{
		}

		protected virtual void OnAttached()
		{
		}

		protected virtual void OnDetaching()
		{
		}

		private static void OnAttachmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}
	}
}
