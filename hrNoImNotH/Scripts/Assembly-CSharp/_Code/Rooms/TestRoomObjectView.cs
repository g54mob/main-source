using UnityEngine;

namespace _Code.Rooms
{
	public sealed class TestRoomObjectView : ARoomObjectView<ERoomTestObjectStates>
	{
		[SerializeField]
		private RoomObjectState<ERoomTestObjectStates>[] _states;

		[SerializeField]
		private ERoomTestObjectStates _startState;

		protected override RoomObjectState<ERoomTestObjectStates>[] States => null;

		protected override ERoomTestObjectStates StartState => default(ERoomTestObjectStates);

		protected override void Awake()
		{
		}
	}
}
