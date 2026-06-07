using System;

namespace Simulator
{
	public class StallInteractableInputHint : InputHintStateManagement<StallInteractableInputHint.EActionStates>
	{
		[Flags]
		public enum EActionStates
		{
			ADD = 1,
			REMOVE = 2
		}
	}
}
