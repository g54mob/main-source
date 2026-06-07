using UnityEngine;

namespace Doozy.Engine.Touchy
{
	public static class CardinalDirection
	{
		public static readonly Vector2 None;

		public static readonly Vector2 Up;

		public static readonly Vector2 Down;

		public static readonly Vector2 Right;

		public static readonly Vector2 Left;

		public static readonly Vector2 UpRight;

		public static readonly Vector2 UpLeft;

		public static readonly Vector2 DownRight;

		public static readonly Vector2 DownLeft;

		public static Vector2 Get(Swipe swipe)
		{
			return default(Vector2);
		}
	}
}
