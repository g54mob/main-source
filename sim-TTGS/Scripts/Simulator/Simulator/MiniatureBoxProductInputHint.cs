using System;

namespace Simulator
{
	public class MiniatureBoxProductInputHint : InputHintStateManagement<MiniatureBoxProductInputHint.EActionStates>
	{
		[Flags]
		public enum EActionStates
		{
			UNPACK = 1,
			NEXT = 2
		}
	}
}
