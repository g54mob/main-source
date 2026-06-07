using System;

namespace Simulator
{
	public class ShelfInteractableInputHint : InputHintStateManagement<ShelfInteractableInputHint.EActionStates>
	{
		[Flags]
		public enum EActionStates
		{
			PLACE = 1,
			TAKE = 2
		}
	}
}
