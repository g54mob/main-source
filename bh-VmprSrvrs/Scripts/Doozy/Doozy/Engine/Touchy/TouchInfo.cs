using UnityEngine;

namespace Doozy.Engine.Touchy
{
	public struct TouchInfo
	{
		public Touch Touch;

		public Swipe Direction;

		public Vector2 RawDirection;

		public Vector2 StartPosition;

		public Vector2 EndPosition;

		public Vector2 Velocity;

		public float StartTime;

		public float EndTime;

		public float Duration;

		public bool Tap;

		public bool LongTap;

		public float Distance;

		public float LongestDistance;

		public GameObject GameObject;

		public GameObject DraggedObject;

		public Vector2 CurrentTouchPosition;

		public Vector2 PreviousTouchPosition;

		public float TouchDeltaTime;

		public bool IsDragging => false;

		public Vector2 TouchVelocity => default(Vector2);

		public void Update(Touch touch, GameObject gameObject = null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
