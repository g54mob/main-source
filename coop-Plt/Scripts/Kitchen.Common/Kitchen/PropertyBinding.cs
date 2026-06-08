using System;
using System.Collections.Generic;

namespace Kitchen
{
	public class PropertyBinding<T>
	{
		protected T _Value;

		protected Action<T> Update;

		protected Func<bool> Validate;

		public T Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (!EqualityComparer<T>.Default.Equals(_Value, value) && Validate())
				{
					_Value = value;
					Update(_Value);
				}
			}
		}

		public PropertyBinding(Action<T> update, T value = default(T))
		{
			Update = update;
			_Value = value;
			Validate = () => true;
		}
	}
}
