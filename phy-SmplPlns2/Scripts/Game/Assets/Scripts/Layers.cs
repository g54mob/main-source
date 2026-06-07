using System.Collections.Generic;

namespace Assets.Scripts
{
	public static class Layers
	{
		public const int AdjustmentGizmos = 10;

		public const int AdjustmentPlanes = 11;

		public const int AircraftCollisionNone = 25;

		public const int AircraftCollisionOnly = 24;

		public const int AircraftInteractable = 16;

		public const int AircraftLayer = 21;

		public const int AllLayersMask = -1;

		public const int AttachPointLayer = 14;

		public const int AttachPointLayerSurface = 15;

		public const int CarLayer = 13;

		public const int CarrierDeck = 23;

		public const int ChadLayer = 17;

		public const int DefaultLayer = 0;

		public const int ExplosionLayer = 19;

		public const int ExplosionMask = -67108865;

		public const int IgnoreRaycast = 2;

		public const int RemoteAircraftLayer = 26;

		public const int RoadLayer = 12;

		public const int TemporaryLayer = 20;

		public const int TerrainLayer = 20;

		public const int TransparentGrabPass = 18;

		public const int WaterLayer = 4;

		public static IReadOnlyDictionary<int, string> LayerNames { get; } = new Dictionary<int, string>
		{
			{ 0, "Default" },
			{ 1, "TransparentFX" },
			{ 2, "Ignore Raycast" },
			{ 4, "Water" },
			{ 5, "UI" },
			{ 8, "AttachSurface" },
			{ 9, "GUI" },
			{ 10, "AdjustmentGizmos" },
			{ 11, "AdjustmentPlanes" },
			{ 12, "Attach Point Layer Start; Road" },
			{ 13, "Attach Point Layer 1" },
			{ 14, "Attach Point Layer 2" },
			{ 15, "Attach Point Layer 3" },
			{ 16, "Attach Point Layer 4" },
			{ 17, "Attach Point Layer End" },
			{ 18, "TransparentGrabPass" },
			{ 19, "Explosion" },
			{ 20, "Terrain" },
			{ 21, "Aircraft" },
			{ 22, "Overlay" },
			{ 23, "CarrierDeck" },
			{ 24, "AircraftCollisionOnly" },
			{ 25, "AircraftCollisionNone" },
			{ 26, "RemoteAircraft" },
			{ 28, "Mod Layer 1" },
			{ 29, "Mod Layer 2" },
			{ 30, "Mod Layer 3" },
			{ 31, "Background" }
		};
	}
}
