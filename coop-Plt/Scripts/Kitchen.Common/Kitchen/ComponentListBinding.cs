using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class ComponentListBinding<T> : PropertyBinding<T>
	{
		public ComponentListBinding(List<Component> targets, Action<T> update, T value = default(T))
			: base(update, value)
		{
			Validate = delegate
			{
				foreach (Component target in targets)
				{
					if (target == null)
					{
						return false;
					}
				}
				return true;
			};
		}
	}
}
