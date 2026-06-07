using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Input.Events
{
	public class InputEvent : IInputEvent
	{
		public Vector2 DeltaPosition { get; set; }

		public Vector2 DeltaPositionSinceBegin { get; set; }

		public float DragDistanceSinceBegin { get; set; }

		public FingerToolMode FingerToolMode { get; internal set; }

		public InputButton InputButton { get; set; }

		public int InputButtonIndex { get; set; }

		public InputState InputState { get; set; }

		public int PointerId { get; set; }

		public Vector2 Position { get; set; }

		public Ray Ray { get; set; }
	}
}
