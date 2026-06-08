using System.Collections.Generic;

namespace Huey.Game
{
	public static class CostumeChangeIndicatorTracker
	{
		private static readonly List<int> PlayersInCostumeChangeIndicator = new List<int>();

		public static bool IsPlayerChangingCostume(int player_id)
		{
			return PlayersInCostumeChangeIndicator.Contains(player_id);
		}

		public static void SetPlayerChangingCostume(int player_id, bool is_changing_costume)
		{
			if (!PlayersInCostumeChangeIndicator.Contains(player_id) && is_changing_costume)
			{
				PlayersInCostumeChangeIndicator.Add(player_id);
			}
			else if (PlayersInCostumeChangeIndicator.Contains(player_id) && !is_changing_costume)
			{
				PlayersInCostumeChangeIndicator.Remove(player_id);
			}
		}

		public static void Reset()
		{
			PlayersInCostumeChangeIndicator.Clear();
		}
	}
}
