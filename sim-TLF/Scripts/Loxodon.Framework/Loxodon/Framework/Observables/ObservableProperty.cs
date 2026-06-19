using System;

namespace Loxodon.Framework.Observables
{
	[Serializable]
	public class ObservableProperty : ObservablePropertyBase<object>, IObservableProperty
	{
		public override Type Type
		{
			get
			{
				if (_value == null)
				{
					return typeof(object);
				}
				return _value.GetType();
			}
		}

		public virtual object Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (!Equals(_value, value))
				{
					_value = value;
					RaiseValueChanged();
				}
			}
		}

		public ObservableProperty()
			: this(null)
		{
		}

		public ObservableProperty(object value)
			: base(value)
		{
		}

		public override string ToString()
		{
			object value = Value;
			if (value == null)
			{
				return "";
			}
			return value.ToString();
		}
	}
	[Serializable]
	public class ObservableProperty<T> : ObservablePropertyBase<T>, IObservableProperty<T>, IObservableProperty
	{
		public virtual T Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (!Equals(_value, value))
				{
					_value = value;
					RaiseValueChanged();
				}
			}
		}

		object IObservableProperty.Value
		{
			get
			{
				return Value;
			}
			set
			{
				Value = (T)value;
			}
		}

		public ObservableProperty()
			: this(default(T))
		{
		}

		public ObservableProperty(T value)
			: base(value)
		{
		}

		public override string ToString()
		{
			T value = Value;
			if (value == null)
			{
				return "";
			}
			return value.ToString();
		}

		public static implicit operator T(ObservableProperty<T> data)
		{
			return data.Value;
		}

		public static implicit operator ObservableProperty<T>(T data)
		{
			return new ObservableProperty<T>(data);
		}
	}
}
