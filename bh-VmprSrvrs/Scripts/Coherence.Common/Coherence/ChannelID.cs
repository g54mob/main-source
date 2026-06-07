using System;

namespace Coherence
{
	public readonly struct ChannelID : IEquatable<ChannelID>, IComparable<ChannelID>
	{
		public static readonly ChannelID Default;

		public static readonly ChannelID Ordered;

		public static readonly ChannelID EndOfChannels;

		public static readonly ChannelID MinValue;

		public static readonly ChannelID MaxValue;

		private readonly byte value;

		public ChannelID(byte value)
		{
			this.value = 0;
		}

		public static explicit operator ChannelID(byte value)
		{
			return default(ChannelID);
		}

		public static explicit operator byte(ChannelID channelID)
		{
			return 0;
		}

		public bool IsValid()
		{
			return false;
		}

		public static bool operator ==(ChannelID left, ChannelID right)
		{
			return false;
		}

		public static bool operator !=(ChannelID left, ChannelID right)
		{
			return false;
		}

		public static bool operator <(ChannelID left, ChannelID right)
		{
			return false;
		}

		public static bool operator >(ChannelID left, ChannelID right)
		{
			return false;
		}

		public static bool operator <=(ChannelID left, ChannelID right)
		{
			return false;
		}

		public static bool operator >=(ChannelID left, ChannelID right)
		{
			return false;
		}

		public bool Equals(ChannelID other)
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

		public override string ToString()
		{
			return null;
		}

		public int CompareTo(ChannelID other)
		{
			return 0;
		}
	}
}
