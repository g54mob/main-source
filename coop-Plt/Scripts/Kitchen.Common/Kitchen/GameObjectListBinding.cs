using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class GameObjectListBinding<T> : PropertyBinding<T>
	{
		public GameObjectListBinding(List<GameObject> targets, Action<T> update, T value = default(T))
			: base(update, value)
		{
			Validate = delegate
			{
				foreach (GameObject target in targets)
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
