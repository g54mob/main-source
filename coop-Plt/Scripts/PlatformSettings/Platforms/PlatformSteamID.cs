namespace Platforms
{
	public struct PlatformSteamID
	{
		public ulong Value;

		public uint AccountId => (uint)(Value & 0xFFFFFFFFu);

		public bool IsValid => Value != 0;

		public static implicit operator PlatformSteamID(ulong value)
		{
			return new PlatformSteamID
			{
				Value = value
			};
		}

		public static implicit operator ulong(PlatformSteamID value)
		{
			return value.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
