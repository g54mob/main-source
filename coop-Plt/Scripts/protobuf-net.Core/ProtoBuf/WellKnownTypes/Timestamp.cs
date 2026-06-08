using System;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.WellKnownTypes
{
	[StructLayout(LayoutKind.Auto)]
	[ProtoContract(Name = ".google.protobuf.Timestamp", Serializer = typeof(PrimaryTypeProvider), Origin = "google/protobuf/timestamp.proto")]
	public readonly struct Timestamp
	{
		private static readonly DateTime TimestampEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		[ProtoMember(1, Name = "seconds", DataFormat = DataFormat.Default)]
		public long Seconds { get; }

		[ProtoMember(2, Name = "nanos", DataFormat = DataFormat.Default)]
		public int Nanoseconds { get; }

		public Timestamp(long seconds, int nanoseconds)
		{
			Seconds = seconds;
			Nanoseconds = nanoseconds;
		}

		public Timestamp(DateTime value)
		{
			Seconds = PrimaryTypeProvider.ToDurationSeconds(value - TimestampEpoch, out var nanos, isTimestamp: true);
			Nanoseconds = nanos;
		}

		public Timestamp Normalize()
		{
			long seconds = Seconds;
			int nanos = Nanoseconds;
			PrimaryTypeProvider.NormalizeSecondsNanoseconds(ref seconds, ref nanos, isTimestamp: true);
			return new Timestamp(seconds, nanos);
		}

		public DateTime AsDateTime()
		{
			return TimestampEpoch.AddTicks(PrimaryTypeProvider.ToTicks(Seconds, Nanoseconds));
		}

		public static implicit operator DateTime(Timestamp value)
		{
			return value.AsDateTime();
		}

		public static implicit operator Timestamp(DateTime value)
		{
			return new Timestamp(value);
		}
	}
}
