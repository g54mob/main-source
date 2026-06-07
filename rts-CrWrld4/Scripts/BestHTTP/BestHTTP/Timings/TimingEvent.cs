using System;

namespace BestHTTP.Timings
{
	public struct TimingEvent : IEquatable<TimingEvent>
	{
		public static readonly TimingEvent Empty;

		public readonly string Name;

		public readonly TimeSpan Duration;

		public readonly DateTime When;

		public TimingEvent(string name, TimeSpan duration)
		{
			Name = null;
			Duration = default(TimeSpan);
			When = default(DateTime);
		}

		public TimeSpan CalculateDuration(TimingEvent @event)
		{
			return default(TimeSpan);
		}

		public bool Equals(TimingEvent other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(TimingEvent lhs, TimingEvent rhs)
		{
			return false;
		}

		public static bool operator !=(TimingEvent lhs, TimingEvent rhs)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
