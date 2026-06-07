using System;

namespace Simulator
{
	public class CashBoxElementInputHint : InputHintStateManagement<CashBoxElementInputHint.EActionStates>
	{
		[Flags]
		public enum EActionStates
		{
			ADD = 1,
			REMOVE = 2
		}
	}
}
