using FullInspector;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomWallDefinition
	{
		public enum SubType
		{
			NoCorner = 0,
			LeftCorner = 1,
			RightCorner = 2,
			BothCorners = 3
		}

		public enum Type
		{
			Wall = 0,
			WallCornerLeft = 1,
			WallCornerRight = 2,
			WallCornerBoth = 3,
			CornerInner = 4,
			CornerOuter = 5,
			Door = 6,
			DoorCornerLeft = 7,
			DoorCornerRight = 8,
			DoorCornerBoth = 9,
			Window = 10,
			WindowCornerLeft = 11,
			WindowCornerRight = 12,
			WindowCornerBoth = 13,
			Pillar = 14,
			PillarCornerLeft = 15,
			PillarCornerRight = 16,
			PillarCornerBoth = 17,
			FillerLeft = 18,
			FillerRight = 19,
			Blank = 20,
			BlankCornerLeft = 21,
			BlankCornerRight = 22,
			BlankCornerBoth = 23,
			AmbulanceBayEntrance = 24,
			Max = 25
		}

		public static bool UseDefaultWallPrefabs;

		[SerializeField]
		private SharedInstance<WallsDefinition> WallsDefinition;

		[SerializeField]
		private ShadowCastingMode _wallShadowCastingMode = ShadowCastingMode.TwoSided;

		public bool NoExternalWalls;

		public bool InvisibleWalls;

		public ShadowCastingMode WallShadowCastingMode => _wallShadowCastingMode;

		public bool HasWallDefinition()
		{
			if (WallsDefinition != null)
			{
				return WallsDefinition.Instance != null;
			}
			return false;
		}

		public GameObject GetPiece(Type type)
		{
			if (WallsDefinition != null && WallsDefinition.Instance != null)
			{
				switch (type)
				{
				case Type.Wall:
					if (!UseDefaultWallPrefabs)
					{
						return WallsDefinition.Instance.Wall;
					}
					return GameAlgorithms.Config.DefaultWallPrefab;
				case Type.WallCornerLeft:
					return WallsDefinition.Instance.WallCornerLeft;
				case Type.WallCornerRight:
					return WallsDefinition.Instance.WallCornerRight;
				case Type.WallCornerBoth:
					return WallsDefinition.Instance.WallCornerBoth;
				case Type.Pillar:
					return WallsDefinition.Instance.Pillar;
				case Type.PillarCornerLeft:
					return WallsDefinition.Instance.PillarCornerLeft;
				case Type.PillarCornerRight:
					return WallsDefinition.Instance.PillarCornerRight;
				case Type.PillarCornerBoth:
					return WallsDefinition.Instance.PillarCornerBoth;
				case Type.CornerInner:
					return WallsDefinition.Instance.CornerInner;
				case Type.CornerOuter:
					return WallsDefinition.Instance.CornerOuter;
				case Type.Door:
					return WallsDefinition.Instance.Door;
				case Type.DoorCornerLeft:
					return WallsDefinition.Instance.DoorCornerLeft;
				case Type.DoorCornerRight:
					return WallsDefinition.Instance.DoorCornerRight;
				case Type.DoorCornerBoth:
					return WallsDefinition.Instance.DoorCornerBoth;
				case Type.Window:
					if (!UseDefaultWallPrefabs)
					{
						return WallsDefinition.Instance.Window;
					}
					return GameAlgorithms.Config.DefaultWindowPrefab;
				case Type.WindowCornerLeft:
					return WallsDefinition.Instance.WindowCornerLeft;
				case Type.WindowCornerRight:
					return WallsDefinition.Instance.WindowCornerRight;
				case Type.WindowCornerBoth:
					return WallsDefinition.Instance.WindowCornerBoth;
				case Type.FillerLeft:
					return WallsDefinition.Instance.FillerLeft;
				case Type.FillerRight:
					return WallsDefinition.Instance.FillerRight;
				}
			}
			return null;
		}

		public GameObject GetBackPieceWall()
		{
			if (WallsDefinition != null && WallsDefinition.Instance != null)
			{
				return WallsDefinition.Instance.WallBack;
			}
			return null;
		}

		public GameObject GetBackPieceWindow()
		{
			if (WallsDefinition != null && WallsDefinition.Instance != null)
			{
				return WallsDefinition.Instance.WindowBack;
			}
			return null;
		}

		public WallsDefinition GetWallsDefinition()
		{
			if (!WallsDefinition.IsNull())
			{
				return WallsDefinition.Instance;
			}
			return null;
		}
	}
}
