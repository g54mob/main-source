using System;
using UnityEngine;

namespace UIScripts.InfoHandles
{
	public abstract class ValueInfoHandle<T> : MonoBehaviour where T : IComparable<T>
	{
		[NonSerialized]
		public T value;

		public virtual void InitHandle()
		{
			OnValueChange();
		}

		public void UpdateValue(T val, bool check = true)
		{
			if (!(val.CompareTo(value) == 0 && check))
			{
				value = val;
				OnValueChange();
			}
		}

		protected abstract void OnValueChange();
	}
}
