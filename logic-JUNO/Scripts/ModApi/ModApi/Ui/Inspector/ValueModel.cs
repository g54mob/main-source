using System;
using System.Collections.Generic;

namespace ModApi.Ui.Inspector
{
	public class ValueModel<T> : ItemModel, IValueChanged
	{
		public virtual T Value
		{
			get
			{
				if (ValueGetter != null)
				{
					return ValueGetter();
				}
				return default(T);
			}
		}

		public Func<T> ValueGetter { get; set; }

		public Action<T> ValueSetter { get; set; }

		public event ValueChangedDelegate ValueChangedByUserInput;

		public ValueModel(Func<T> valueGetter, Action<T> valueSetter)
		{
			ValueGetter = valueGetter;
			ValueSetter = valueSetter;
		}

		public virtual void SetValueFromUserInput(T value, string name, bool finished = true, bool ignoreIfEqual = true)
		{
			if (!value.Equals(Value) || !ignoreIfEqual)
			{
				ValueSetter?.Invoke(value);
				this.ValueChangedByUserInput?.Invoke(this, name, finished);
			}
		}

		private bool Compare<Tx>(Tx x, Tx y)
		{
			return EqualityComparer<Tx>.Default.Equals(x, y);
		}
	}
}
