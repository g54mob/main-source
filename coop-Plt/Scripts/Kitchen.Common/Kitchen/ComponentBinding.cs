using System;
using UnityEngine;

namespace Kitchen
{
	public class ComponentBinding<T> : PropertyBinding<T>
	{
		public ComponentBinding(Component target, Action<T> update, T value = default(T))
			: base(update, value)
		{
			Validate = () => target != null;
		}
	}
}
