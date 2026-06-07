using System;

namespace Simulator
{
	public class BaseBoxInputHint : InputHintStateManagement<BaseBoxInputHint.EActionFlags>
	{
		[Flags]
		public enum EActionFlags
		{
			GRABBABLE = 1,
			OPENABLE = 2
		}
	}
}
