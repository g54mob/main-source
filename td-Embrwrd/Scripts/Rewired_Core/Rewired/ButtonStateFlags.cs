using System;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[Flags]
	internal enum ButtonStateFlags
	{
		Off = 0,
		On = 1,
		Down = 2,
		Up = 4
	}
}
