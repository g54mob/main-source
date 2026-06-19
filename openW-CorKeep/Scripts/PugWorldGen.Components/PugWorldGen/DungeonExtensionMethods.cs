namespace PugWorldGen
{
	public static class DungeonExtensionMethods
	{
		public static bool Matches(this RoomFlags flags, RoomFlags otherFlags)
		{
			return (flags & otherFlags) != 0;
		}

		public static bool MatchesAll(this RoomFlags flags, RoomFlags otherFlags)
		{
			return (flags & otherFlags) == otherFlags;
		}
	}
}
