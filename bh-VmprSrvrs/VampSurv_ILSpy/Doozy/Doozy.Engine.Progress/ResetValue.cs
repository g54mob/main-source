using System;

namespace Doozy.Engine.Progress;

[Serializable]
public enum ResetValue
{
	Disabled,
	ToMinValue,
	ToMaxValue,
	ToCustomValue
}
