using UnityEngine;
using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public struct NavigationModel
	{
		public Vector2 Move;

		public int ConsecutiveMoveCount;

		public MoveDirection LastMoveDirection;

		public float LastMoveTime;

		public AxisEventData EventData;
	}
}
