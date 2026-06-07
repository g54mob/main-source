using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Calendar
{
	[Serializable]
	public struct CalendarEventInstance : INetworkSerializable, IEquatable<CalendarEventInstance>
	{
		public FixedString64Bytes EventId;

		public int StartDayIndex;

		public int DurationDays;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(CalendarEventInstance other)
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

		public bool IsActiveOn(int dayIndex)
		{
			return false;
		}
	}
}
