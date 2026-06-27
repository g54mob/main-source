using System;

namespace DistantLands.Cozy
{
	[Serializable]
	public struct Overridable<T>
	{
		public T value;

		public bool overrideValue;

		public static implicit operator bool(Overridable<T> data)
		{
			return data.overrideValue;
		}

		public Overridable(T _value, bool _overrideValue)
		{
			overrideValue = _overrideValue;
			value = _value;
		}

		public static implicit operator T(Overridable<T> data)
		{
			if (!data.overrideValue)
			{
				return CozyUtilities.GetOverriableDefault<T>();
			}
			return data.value;
		}

		public static implicit operator Overridable<T>(T value)
		{
			return new Overridable<T>(value, _overrideValue: true);
		}
	}
}
