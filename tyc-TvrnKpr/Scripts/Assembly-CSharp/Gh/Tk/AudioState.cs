namespace Gh.Tk
{
	public static class AudioState
	{
		public static class WorldMapMusicVocals
		{
			public const string _Key = "WorldMapMusicVocals";

			public const string Enabled = "Enabled";

			public const string Disabled = "Disabled";
		}

		public static class Weather
		{
			public const string _Key = "Weather";

			public const string None = "None";

			private const string Earthquake = "Earthquake";

			private const string FlowerPetals = "Flower_Petals";

			private const string Raining = "Raining";

			private const string Heatwave = "Heatwave";

			private const string Sandstorm = "Sandstorm";

			private const string SunRays = "Sunrays";

			public static string GetWeatherState(string weatherType)
			{
				return null;
			}
		}

		public static class GameTime
		{
			public const string _Key = "GameTime";

			public const string Day = "Day";

			public const string Night = "Night";
		}

		public static class TavernState
		{
			public const string _Key = "TavernState";

			public const string Open = "Open";

			public const string Closed = "Closed";
		}

		public static class GameMute
		{
			public const string MasterKey = "Master_Mute";

			public const string Muted = "Muted";

			public const string Unmuted = "Unmuted";

			public const string Narrator_Mute = "Narrator_Mute";

			public const string Advisor_Mute = "Advisor_Mute";

			public const string Music_Mute = "Music_Mute";
		}

		public static class DialogState
		{
			public const string _Key = "DialogState";

			public const string Open = "Open";

			public const string Closed = "Closed";
		}

		public static class DialogType
		{
			public const string _Key = "DialogType";

			public const string None = "None";

			public const string General = "General";

			public const string InteractiveFiction = "InteractiveFiction";

			public const string NoMusic = "NoMusic";

			public const string LowMusic = "LowMusic";
		}

		public static class View
		{
			public static SoundEngineStateControl StateControl;

			public const string _Key = "View";

			public const string Loading = "Loading";

			public const string WorldMap_MainMenu = "MainMenu_WorldMap";

			public const string WorldMap_Trade = "Trade_WorldMap";

			public const string Tavern = "Tavern";

			public const string StartUp = "StartUp";
		}

		public const string Level = "Level";

		public const string GameSpeed = "GameSpeed";

		public const string PatronSingVolume = "PatronSingVolume";
	}
}
