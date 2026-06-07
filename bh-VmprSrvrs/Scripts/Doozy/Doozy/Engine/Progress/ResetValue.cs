using System;

namespace Doozy.Engine.Progress
{
	[Serializable]
	public enum ResetValue
	{
		Disabled = 0,
		ToMinValue = 1,
		ToMaxValue = 2,
		ToCustomValue = 3
	}
}
