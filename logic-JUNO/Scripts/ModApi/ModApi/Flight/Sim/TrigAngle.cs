using ModApi.Math;

namespace ModApi.Flight.Sim
{
	public struct TrigAngle
	{
		private double _value;

		public double AsDegrees => _value * 57.29578;

		public double AsNegativePIToPI => MathUtils.LimitAngleNegPItoPI(_value);

		public double AsZeroTo2PI => MathUtils.LimitAngle0to2PI(_value);

		public double Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public TrigAngle(double angle)
		{
			_value = angle;
		}

		public static implicit operator double(TrigAngle a)
		{
			return a.Value;
		}

		public static implicit operator TrigAngle(double d)
		{
			return new TrigAngle(d);
		}

		public static bool operator !=(TrigAngle lhs, TrigAngle rhs)
		{
			return lhs.Value != rhs.Value;
		}

		public static bool operator !=(TrigAngle lhs, double rhs)
		{
			return lhs.Value != rhs;
		}

		public static bool operator <(TrigAngle lhs, TrigAngle rhs)
		{
			return lhs.Value < rhs.Value;
		}

		public static bool operator <(TrigAngle lhs, double rhs)
		{
			return lhs.Value < rhs;
		}

		public static bool operator <=(TrigAngle lhs, TrigAngle rhs)
		{
			return lhs.Value <= rhs.Value;
		}

		public static bool operator <=(TrigAngle lhs, double rhs)
		{
			return lhs.Value <= rhs;
		}

		public static bool operator ==(TrigAngle lhs, TrigAngle rhs)
		{
			return lhs.Value == rhs.Value;
		}

		public static bool operator ==(TrigAngle lhs, double rhs)
		{
			return lhs.Value == rhs;
		}

		public static bool operator >(TrigAngle lhs, double rhs)
		{
			return lhs.Value > rhs;
		}

		public static bool operator >(TrigAngle lhs, TrigAngle rhs)
		{
			return lhs.Value > rhs.Value;
		}

		public static bool operator >=(TrigAngle lhs, TrigAngle rhs)
		{
			return lhs.Value >= rhs.Value;
		}

		public static bool operator >=(TrigAngle lhs, double rhs)
		{
			return lhs.Value >= rhs;
		}

		public override bool Equals(object obj)
		{
			if (obj is TrigAngle)
			{
				return this == (TrigAngle)obj;
			}
			if (obj is double)
			{
				return this == (double)obj;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
