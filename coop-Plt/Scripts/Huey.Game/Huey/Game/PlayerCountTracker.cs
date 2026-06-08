namespace Huey.Game
{
	public static class PlayerCountTracker
	{
		public const int MaxNumPlayers = 4;

		public static int CurrentNumPlayers;

		public static int RemainingSlots => 4 - CurrentNumPlayers;
	}
}
