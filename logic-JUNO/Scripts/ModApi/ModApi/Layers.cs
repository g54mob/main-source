namespace ModApi
{
	public static class Layers
	{
		public static class BuiltIn
		{
			public const int Default = 0;

			public const int IgnoreRaycast = 2;

			public const int TransparentFX = 1;

			public const int UI = 5;

			public const int Water = 4;
		}

		public static class Design
		{
			public const int AttachPointLayer = 12;

			public const int AttachPointLayerCantReceive = 14;

			public const int AttachPointLayerSurface = 13;

			public const int GizmosInteractive = 10;

			public const int GizmosNonInteractive = 11;
		}

		public static class Flight
		{
			public const int CraftCollisionNone = 25;

			public const int DockingPort = 28;

			public const int MapView = 10;

			public const int MapViewItem = 11;

			public const int ScaledSpace = 8;

			public const int Terrain = 29;

			public const int TerrainFeature = 26;

			public const int Water = 4;
		}

		public const int CraftLayer = 31;

		public const int IgnoreCraft = 30;

		public const int PartPicture = 9;
	}
}
