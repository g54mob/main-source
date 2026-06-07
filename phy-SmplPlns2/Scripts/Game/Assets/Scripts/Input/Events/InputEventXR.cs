using UnityEngine;

namespace Assets.Scripts.Input.Events
{
	public class InputEventXR : IInputEvent
	{
		public Vector3 DeltaPosition { get; set; }

		public Vector3 DeltaPositionSinceBegin { get; set; }

		public float DragDistanceSinceBegin { get; set; }

		public InputButton InputButton { get; set; }

		public InputState InputState { get; set; }

		public Vector3 Position { get; set; }
	}
}
