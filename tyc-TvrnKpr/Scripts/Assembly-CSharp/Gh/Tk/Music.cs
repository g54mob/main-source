namespace Gh.Tk
{
	public static class Music
	{
		public static class LoadingScreen
		{
			public const string _KeyMusic = "LoadingScreenSplashImage_Music";

			public const string _KeyAmbience = "LoadingScreenSplashImage_Ambience";
		}

		public static class WorldMapMusicVariant
		{
			public const string _Key = "WorldMap_MusicVariant";

			public const string Base = "Base";

			public const string ErtingaleValley = "ElvenValley";

			public const string Unterdeep = "DwarvenMines";

			public const string Swamp = "Swamp";

			public const string Halflington = "Halflington";

			public const string Gugamush = "Gugamush";

			public const string WizardsTower = "Wizard";

			public const string MeraminCity = "City";

			public const string ItemWorkshop = "ItemWorkshop";

			public static string[] GetAllVariants()
			{
				return null;
			}

			public static string GetMusicVariantForLevel(string levelId)
			{
				return null;
			}

			public static string GetLevelForMusicVariant(string musicVariant)
			{
				return null;
			}
		}

		public const string PlayBackgroundMusic = "PlayBackgroundMusic";

		public const string StopBackgroundMusic = "StopBackgroundMusic";

		public const string PlayWorldMapMusic = "Play_Map_Music_Loop";

		public const string PlayLoadingScreenMapRegionMusic = "Play_LoadingScreen_MapRegionMusic_Loop";

		public const string PlayLoadingScreenThemeMusic = "Play_LoadingScreen_ThemeMusic_Loop";

		public const string PlayCreditsTrack1 = "Play_Track_Last_Call_Tavern_Keeper_End_Credits";

		public const string PlayCreditsTrack2 = "Play_Track_Closing_Time_Tavern_Keeper_End_Credits_2";
	}
}
