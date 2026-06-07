using System;

namespace Simulator
{
	public class ToggleInputHint : InputHintStateManagement<ToggleInputHint.EActionStates>
	{
		[Flags]
		public enum EActionStates
		{
			TRUE = 1,
			FALSE = 2
		}
	}
}
