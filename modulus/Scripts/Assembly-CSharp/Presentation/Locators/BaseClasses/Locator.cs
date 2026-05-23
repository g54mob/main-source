using System;
using UnityEngine;

namespace Presentation.Locators.BaseClasses
{
	public class Locator<T> : BaseLocator where T : MonoBehaviour
	{
		public T Value { get; private set; }

		public void AssignLocator(T value)
		{
			Value = value;
		}

		public override void Assign(MonoBehaviour monoBehaviour)
		{
			AssignLocator(monoBehaviour as T);
		}

		public override bool ValueIsOfCorrectType(MonoBehaviour monoBehaviour)
		{
			Type type = monoBehaviour.GetType();
			if (!(type == typeof(T)))
			{
				return type.IsSubclassOf(typeof(T));
			}
			return true;
		}
	}
}
