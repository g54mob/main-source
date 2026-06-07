using System;

namespace CTS.BBT
{
	[Serializable]
	public readonly struct SeatLink : IEquatable<SeatLink>
	{
		public readonly Seat Seat;

		public SeatLink(Seat seat)
		{
			Seat = seat;
		}

		public static implicit operator SeatLink(Seat seat)
		{
			return new SeatLink(seat);
		}

		public bool Equals(SeatLink other)
		{
			return other.Seat == Seat;
		}

		public override int GetHashCode()
		{
			return Seat.GetHashCode();
		}
	}
}
