using System;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.WellKnownTypes
{
	[StructLayout(LayoutKind.Auto)]
	[ProtoContract(Name = ".google.protobuf.Duration", Serializer = typeof(PrimaryTypeProvider), Origin = "google/protobuf/duration.proto")]
	public readonly struct Duration
	{
		[ProtoMember(1, Name = "seconds", DataFormat = DataFormat.Default)]
		public long Seconds { get; }

		[ProtoMember(2, Name = "nanos", DataFormat = DataFormat.Default)]
		public int Nanoseconds { get; }

		public Duration(long seconds, int nanoseconds)
		{
			Seconds = seconds;
			Nanoseconds = nanoseconds;
		}

		public Duration(TimeSpan value)
		{
			Seconds = PrimaryTypeProvider.ToDurationSeconds(value, out var nanos, isTimestamp: false);
			Nanoseconds = nanos;
		}

		public TimeSpan AsTimeSpan()
		{
			return TimeSpan.FromTicks(PrimaryTypeProvider.ToTicks(Seconds, Nanoseconds));
		}

		public static implicit operator TimeSpan(Duration value)
		{
			return value.AsTimeSpan();
		}

		public static implicit operator Duration(TimeSpan value)
		{
			return new Duration(value);
		}

		public Duration Normalize()
		{
			long seconds = Seconds;
			int nanos = Nanoseconds;
			PrimaryTypeProvider.NormalizeSecondsNanoseconds(ref seconds, ref nanos, isTimestamp: false);
			return new Duration(seconds, nanos);
		}
	}
}
