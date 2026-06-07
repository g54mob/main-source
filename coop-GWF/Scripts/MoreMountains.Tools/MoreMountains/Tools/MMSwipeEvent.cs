using UnityEngine;

namespace MoreMountains.Tools
{
	public struct MMSwipeEvent
	{
		public MMPossibleSwipeDirections SwipeDirection;

		public float SwipeAngle;

		public float SwipeLength;

		public Vector2 SwipeOrigin;

		public Vector2 SwipeDestination;

		public float SwipeDuration;

		private static MMSwipeEvent e;

		public MMSwipeEvent(MMPossibleSwipeDirections direction, float angle, float length, Vector2 origin, Vector2 destination, float swipeDuration)
		{
			SwipeDirection = direction;
			SwipeAngle = angle;
			SwipeLength = length;
			SwipeOrigin = origin;
			SwipeDestination = destination;
			SwipeDuration = swipeDuration;
		}

		public static void Trigger(MMPossibleSwipeDirections direction, float angle, float length, Vector2 origin, Vector2 destination, float swipeDuration)
		{
			e.SwipeDirection = direction;
			e.SwipeAngle = angle;
			e.SwipeLength = length;
			e.SwipeOrigin = origin;
			e.SwipeDestination = destination;
			e.SwipeDuration = swipeDuration;
			MMEventManager.TriggerEvent(e);
		}
	}
}
