using System;
using UnityEngine;

namespace NekoLib.ReactiveProps
{
	[Serializable]
	public class BindableProp<T> : IBindableProp<T> where T : struct
	{
		[SerializeField]
		protected T _value;

		public virtual T Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (!_value.Equals(value))
				{
					_value = value;
					OnValueChange();
				}
			}
		}

		public event Action<T> ValueChanged;

		public BindableProp()
		{
		}

		public BindableProp(T value)
		{
			_value = value;
		}

		protected virtual void OnValueChange()
		{
			this.ValueChanged?.Invoke(Value);
		}
	}
}
