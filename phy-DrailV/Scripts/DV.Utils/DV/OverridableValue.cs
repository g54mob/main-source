using System;
using Newtonsoft.Json;

namespace DV
{
	[Serializable]
	public class OverridableValue<T>
	{
		private T _realValue;

		private T _overrideValue;

		public bool IsOverridden { get; private set; }

		[JsonIgnore]
		public T CurrentValue
		{
			get
			{
				if (!IsOverridden)
				{
					return _realValue;
				}
				return _overrideValue;
			}
			set
			{
				if (IsOverridden)
				{
					_overrideValue = value;
				}
				else
				{
					_realValue = value;
				}
			}
		}

		public T RealValue
		{
			get
			{
				return _realValue;
			}
			set
			{
				_realValue = value;
			}
		}

		public T OverriddenValue
		{
			get
			{
				return _overrideValue;
			}
			set
			{
				_overrideValue = value;
			}
		}

		public OverridableValue()
		{
			_realValue = default(T);
		}

		public OverridableValue(T value)
		{
			_realValue = value;
		}

		public void EngageOverride(T value)
		{
			_overrideValue = value;
			IsOverridden = true;
		}

		public void ClearOverride()
		{
			_overrideValue = default(T);
			IsOverridden = false;
		}

		public override string ToString()
		{
			return CurrentValue?.ToString() ?? "null";
		}

		public static implicit operator T(OverridableValue<T> value)
		{
			return value.CurrentValue;
		}
	}
}
