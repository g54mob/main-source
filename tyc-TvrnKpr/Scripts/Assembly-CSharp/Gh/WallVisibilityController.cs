using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh
{
	public class WallVisibilityController : MonoBehaviour
	{
		public enum ViewDirection
		{
			North = 0,
			East = 1,
			South = 2,
			West = 3,
			All = 4,
			None = 5,
			Unset = 6
		}

		public readonly List<WallVisibilityData> WallData;

		public const string WALL_MODE_AUTO = "auto";

		public const string WALL_MODE_ALWAYS_VISIBLE = "alwaysVisible";

		private static bool _wallModeIsDirty;

		private static string _wallMode;

		private ViewDirection _viewDirectionOverride;

		private ViewDirection _currentDirection;

		public float yRotationOffset;

		public EventHandler ViewDirectionChanged;

		public static string WallMode
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Update()
		{
		}

		public void SetWallVisibility(ViewDirection newDirection)
		{
		}
	}
}
