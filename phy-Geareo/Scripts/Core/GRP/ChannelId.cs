namespace GRP
{
	public struct ChannelId
	{
		public int value;

		public static readonly ChannelId none;

		public ChannelId(int value)
		{
			this.value = 0;
		}

		public static implicit operator int(ChannelId id)
		{
			return 0;
		}

		public static implicit operator ChannelId(int id)
		{
			return default(ChannelId);
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(ChannelId a, ChannelId b)
		{
			return false;
		}

		public static bool operator !=(ChannelId a, ChannelId b)
		{
			return false;
		}
	}
}
