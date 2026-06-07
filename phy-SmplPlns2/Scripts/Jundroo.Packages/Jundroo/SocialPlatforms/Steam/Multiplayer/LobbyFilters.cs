using System.Collections.Generic;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer
{
	public class LobbyFilters
	{
		public LobbyDistanceFilterType Distance { get; set; }

		public int MaxResults { get; set; }

		public List<(string Key, int Value, LobbyComparisonType ComparisonType)> NumericalFilters { get; }

		public List<(string Key, int TargetValue)> ResultSorting { get; }

		public int SlotsAvailable { get; set; }

		public List<(string Key, string Value, LobbyComparisonType ComparisonType)> StringFilters { get; }

		public LobbyFilters()
		{
			Distance = LobbyDistanceFilterType.Default;
			SlotsAvailable = 1;
			MaxResults = 0;
			ResultSorting = new List<(string, int)>();
			NumericalFilters = new List<(string, int, LobbyComparisonType)>();
			StringFilters = new List<(string, string, LobbyComparisonType)>();
		}
	}
}
