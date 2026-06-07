using System;

namespace Kamgam.SettingsGenerator
{
	public class GetSetConnection<T> : Connection<T>
	{
		protected T _value;

		public event Func<T> Getter;

		public event Action<T> Setter;

		public GetSetConnection(Func<T> getter, Action<T> setter)
		{
			Getter += getter;
			Setter += setter;
		}

		public override T Get()
		{
			if (this.Getter != null)
			{
				_value = this.Getter();
			}
			return _value;
		}

		public override void Set(T value)
		{
			_value = value;
			if (this.Setter != null)
			{
				this.Setter(value);
			}
		}

		public T GetLastKnownValue()
		{
			return _value;
		}

		public void SetLastKnownValue(T value)
		{
			_value = value;
		}
	}
}
