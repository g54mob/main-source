using System;

namespace Rewired.Libraries.SharpDX.RawInput
{
	[Rewired.CustomObfuscation]
	[Flags]
	internal enum ScanCodeFlags : short
	{
		[Rewired.CustomObfuscation]
		Make = 0,
		[Rewired.CustomObfuscation]
		Break = 1,
		[Rewired.CustomObfuscation]
		E0 = 2,
		[Rewired.CustomObfuscation]
		E1 = 4
	}
}
