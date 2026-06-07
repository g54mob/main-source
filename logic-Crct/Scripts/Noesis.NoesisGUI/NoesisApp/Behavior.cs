using System;
using Noesis;

namespace NoesisApp
{
	public abstract class Behavior : AttachableObject
	{
		protected Behavior(Type associatedType)
			: base(null)
		{
		}

		public new Behavior Clone()
		{
			return null;
		}

		public new Behavior CloneCurrentValue()
		{
			return null;
		}
	}
	public abstract class Behavior<T> : Behavior where T : DependencyObject
	{
		protected new T AssociatedObject => null;

		protected Behavior()
			: base(null)
		{
		}
	}
}
