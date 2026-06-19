using System;

namespace Sentry
{
	public readonly struct MeasurementUnit : IEquatable<MeasurementUnit>
	{
		public enum Duration
		{
			Nanosecond = 0,
			Microsecond = 1,
			Millisecond = 2,
			Second = 3,
			Minute = 4,
			Hour = 5,
			Day = 6,
			Week = 7
		}

		public enum Fraction
		{
			Ratio = 0,
			Percent = 1
		}

		public enum Information
		{
			Bit = 0,
			Byte = 1,
			Kilobyte = 2,
			Kibibyte = 3,
			Megabyte = 4,
			Mebibyte = 5,
			Gigabyte = 6,
			Gibibyte = 7,
			Terabyte = 8,
			Tebibyte = 9,
			Petabyte = 10,
			Pebibyte = 11,
			Exabyte = 12,
			Exbibyte = 13
		}

		private readonly Enum? _unit;

		private readonly string? _name;

		public static MeasurementUnit None = new MeasurementUnit("none");

		private MeasurementUnit(Enum unit)
		{
			_unit = unit;
			_name = null;
		}

		private MeasurementUnit(string name)
		{
			_unit = null;
			_name = name;
		}

		public static MeasurementUnit Custom(string name)
		{
			return new MeasurementUnit(name.ToLowerInvariant());
		}

		internal static MeasurementUnit Parse(string? name)
		{
			if (name == null)
			{
				return default(MeasurementUnit);
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				return default(MeasurementUnit);
			}
			if (name.Equals("none", StringComparison.OrdinalIgnoreCase))
			{
				return None;
			}
			if (Enum.TryParse<Duration>(name, ignoreCase: true, out var result))
			{
				return result;
			}
			if (Enum.TryParse<Information>(name, ignoreCase: true, out var result2))
			{
				return result2;
			}
			if (Enum.TryParse<Fraction>(name, ignoreCase: true, out var result3))
			{
				return result3;
			}
			return Custom(name);
		}

		public override string ToString()
		{
			return _unit?.ToString().ToLowerInvariant() ?? _name ?? "";
		}

		public bool Equals(MeasurementUnit other)
		{
			if (object.Equals(_unit, other._unit))
			{
				return _name == other._name;
			}
			return false;
		}

		public override bool Equals(object? obj)
		{
			if (obj is MeasurementUnit other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_unit, _name, _unit?.GetType());
		}

		public static bool operator ==(MeasurementUnit left, MeasurementUnit right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MeasurementUnit left, MeasurementUnit right)
		{
			return !left.Equals(right);
		}

		public static implicit operator MeasurementUnit(Duration unit)
		{
			return new MeasurementUnit(unit);
		}

		public static implicit operator MeasurementUnit(Fraction unit)
		{
			return new MeasurementUnit(unit);
		}

		public static implicit operator MeasurementUnit(Information unit)
		{
			return new MeasurementUnit(unit);
		}
	}
}
