using UnityEngine;

namespace Gh.Tk
{
	public static class Layers
	{
		public const string UI = "UI";

		public const string UIIgnoreDaylight = "UI_IgnoreDaylight";

		public const string Text = "Text";

		public const string TransparentFX = "TransparentFX";

		public const string Occluder = "Occluder";

		public const string Default = "Default";

		public const string IgnoreRaycast = "Ignore Raycast";

		public const string Obstacle = "Obstacle";

		public const string Paintable = "Paintable";

		public const string Design = "Design";

		public const string Dirt = "Dirt";

		public const string WorldMap = "WorldMap";

		public const string DecorEntityGizmos = "DecorEntityGizmos";

		public const string Gizmos = "Gizmos";

		public const string Shadow = "Shadow";

		public const string DetailShadows = "DetailShadows";

		public const string LevelEditor = "LevelEditor";

		public const string CharacterPhysics = "CharacterPhysics";

		public const string InformationVisuals = "InformationVisuals";

		public const string SnappingPoints = "SnappingPoints";

		public const string ExteriorEnvironment = "ExteriorEnvironment";

		public const string StaticObstacles = "StaticObstacles";

		public static string OverlayInteractable;

		public static string CostField;

		public static void MoveToLayer(Transform root, int layer)
		{
		}
	}
}
