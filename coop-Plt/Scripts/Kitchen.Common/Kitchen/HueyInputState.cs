using Controllers;
using MessagePack;

namespace Kitchen
{
	public struct HueyInputState
	{
		[Key(1)]
		public ButtonState InteractAction;

		[Key(2)]
		public ButtonState GrabAction;

		[Key(3)]
		public ButtonState SecondaryAction1;

		[Key(4)]
		public ButtonState SecondaryAction2;

		[Key(5)]
		public SerializableVector2 SerializableMovement;

		[Key(6)]
		public ButtonState StopMoving;

		[Key(7)]
		public ButtonState MenuTrigger;

		[Key(8)]
		public ButtonState MenuUp;

		[Key(9)]
		public ButtonState MenuDown;

		[Key(10)]
		public ButtonState MenuLeft;

		[Key(11)]
		public ButtonState MenuRight;

		[Key(12)]
		public ButtonState MenuSelect;

		[Key(13)]
		public ButtonState MenuCancel;

		[Key(14)]
		public GameStateRequest Request;
	}
}
